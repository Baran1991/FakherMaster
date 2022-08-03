using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Consult;
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Consult
{
    public partial class frmConsultationsList : rRadForm
    {
        private ConsultationCategory mCategory;
        private bool mTotalLoaded;

        public frmConsultationsList(ConsultationCategory category)
        {
            InitializeComponent();
            radPageView1.SelectedPage = radPageViewPage1;
            mCategory = category;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "SubmitDate.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان", ObjectProperty = "SubmitTime" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Fullname" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "موضوع", ObjectProperty = "CategoryText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت نمایش", ObjectProperty = "ViewPolicyText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView1.CustomButtons.Add(new rGridViewButton { Text = "چاپ", VisibleOnSelect = true, Position = rGridViewButtonPosition.After });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "SubmitDate.ToShortDateString()" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "زمان", ObjectProperty = "SubmitTime" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Fullname" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "موضوع", ObjectProperty = "CategoryText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت نمایش", ObjectProperty = "ViewPolicyText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView2.CustomButtons.Add(new rGridViewButton { Text = "چاپ", VisibleOnSelect = true, Position = rGridViewButtonPosition.After });

            Fill();
        }

        private void Fill()
        {
            rGridView1.DataBind(Consultation.GetNotRepliedConsultations(mCategory));
//            rGridView2.DataBind(Consultation.GetConsultations(mCategory));
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Consultation consultation = rGridView1.GetSelectedObject<Consultation>();
            frmConsultationDetail frm = new frmConsultationDetail(consultation);
            if (!frm.ProcessObject())
                return;

            consultation.SetConsultant(Program.CurrentPerson);
            consultation.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Consultation consultation = rGridView2.GetSelectedObject<Consultation>();
            frmConsultationDetail frm = new frmConsultationDetail(consultation);
            if (!frm.ProcessObject())
                return;

            consultation.SetConsultant(Program.CurrentPerson);
            consultation.Save();
            rGridView2.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Consultation consultation = rGridView1.GetSelectedObject<Consultation>();
            if (rMessageBox.ShowQuestion("از حذف این مشاوره واقعا مطمئن هستید؟") != DialogResult.Yes)
                return;
            if (consultation.Student != null)
                consultation.Student.Consultations.Remove(consultation);
            consultation.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            Consultation consultation = rGridView2.GetSelectedObject<Consultation>();
            if (rMessageBox.ShowQuestion("از حذف این مشاوره واقعا مطمئن هستید؟") != DialogResult.Yes)
                return;
            if (consultation.Student != null)
                consultation.Student.Consultations.Remove(consultation);
            consultation.Delete();
            rGridView2.RemoveSelectedRow();
        }

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {
            if(radPageView1.SelectedPage == radPageViewPage2 && !mTotalLoaded)
            {
                try
                {
                    Program.StartWaiting();
                    rGridView2.DataBind(Consultation.GetConsultations(mCategory));
                    mTotalLoaded = true;
                }
                finally
                {
                    Program.EndWaiting();
                }
            }
        }

        private void rGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            if(e.ButtonIndex == 0)
            {
                Consultation consultation = rGridView1.GetSelectedObject<Consultation>();
                consultation.RefreshEntity();

                rptConsultation rpt = new rptConsultation();
                rpt.DataSource = new[] {consultation};
                
                frmReportViewer frm = new frmReportViewer(rpt);
                frm.ShowDialog();
            }
        }

        private void rGridView2_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            if (e.ButtonIndex == 0)
            {
                Consultation consultation = rGridView2.GetSelectedObject<Consultation>();
                consultation.RefreshEntity();

                rptConsultation rpt = new rptConsultation();
                rpt.DataSource = new[] { consultation };

                frmReportViewer frm = new frmReportViewer(rpt);
                frm.ShowDialog();
            }
        }
    }
}
