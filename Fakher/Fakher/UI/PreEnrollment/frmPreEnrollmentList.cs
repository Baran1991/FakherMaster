using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.PreEnrollment;
using Fakher.UI.Report;
using Fakher.UI.SystemFeatures;
using rComponents;

namespace Fakher.UI.Reserves
{
    public partial class frmPreEnrollmentList : rRadForm
    {
        public frmPreEnrollmentList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام لیست", ObjectProperty = "Name" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت نام", ObjectProperty = "Date.ToShortDateString()" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FirstName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام و نام خانوادگی", ObjectProperty = "LastName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "استان", ObjectProperty = "Province" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شهر", ObjectProperty = "City" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تلفن", ObjectProperty = "Phone" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "ایمیل", ObjectProperty = "Email" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت نام", ObjectProperty = "RegisterationTypeText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });

            rGridView2.CustomButtons.Add(new rGridViewButton {Text = "چاپ رسید", VisibleOnSelect = true, Position = rGridViewButtonPosition.After});
            rGridView2.CustomButtons.Add(new rGridViewButton {Text = "ارسال ایمیل", VisibleOnSelect = true, Position = rGridViewButtonPosition.After});
            rGridView2.CustomButtons.Add(new rGridViewButton {Text = "ارسال پیامک", VisibleOnSelect = true, Position = rGridViewButtonPosition.After});
        }

        private void majorSelector1_SelectedChanged(object sender, EventArgs e)
        {
            rGridView1.Clear();
            if (majorSelector1.Major == null)
                return;
            rGridView1.DataBind(PreEnrollmentList.GetLists(majorSelector1.Major));
        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            PreEnrollmentList preEnrollmentList = rGridView1.GetSelectedObject<PreEnrollmentList>();
            rGridView2.Clear();
            if (preEnrollmentList == null)
                return;
            rGridView2.DataBind(preEnrollmentList.PreEnrollments);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            if (majorSelector1.Major == null)
                return;

            PreEnrollmentList enrollmentList = new PreEnrollmentList { Major = majorSelector1.Major };
            frmPreEnrollmentListDetail frm = new frmPreEnrollmentListDetail(enrollmentList);
            if (!frm.ProcessObject())
                return;
            enrollmentList.Save();
            rGridView1.Insert(enrollmentList);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            PreEnrollmentList enrollmentList = rGridView1.GetSelectedObject<PreEnrollmentList>();
            frmPreEnrollmentListDetail frm = new frmPreEnrollmentListDetail(enrollmentList);
            if (!frm.ProcessObject())
                return;
            enrollmentList.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            PreEnrollmentList enrollmentList = rGridView1.GetSelectedObject<PreEnrollmentList>();
            enrollmentList.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            Fakher.Core.DomainModel.PreEnrollment preEnrollment = rGridView2.GetSelectedObject<Fakher.Core.DomainModel.PreEnrollment>();
            preEnrollment.PreEnrollmentList.PreEnrollments.Remove(preEnrollment);

            preEnrollment.Delete();
            rGridView2.RemoveSelectedRow();
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Fakher.Core.DomainModel.PreEnrollment enrollment = rGridView2.GetSelectedObject<Fakher.Core.DomainModel.PreEnrollment>();
            frmPreEnrollmentDetail frm = new frmPreEnrollmentDetail(enrollment);
            if (!frm.ProcessObject())
                return;

            enrollment.LastUpdateDate = PersianDate.Today;
            enrollment.Employee = Program.CurrentEmployee;

            enrollment.Save();
            rGridView2.UpdateGridView();
        }

        private void rGridView2_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            Fakher.Core.DomainModel.PreEnrollment enrollment = rGridView2.GetSelectedObject<Fakher.Core.DomainModel.PreEnrollment>();
            if (e.ButtonIndex == 0) //Receipt
            {
                rptPreEnrollmentReceipt rpt = new rptPreEnrollmentReceipt();
                rpt.DataSource = new[] { enrollment };
                frmReportViewer frm = new frmReportViewer(rpt) { AutoPrint = true };
                frm.ShowDialog(this);
            }
            if (e.ButtonIndex == 1) //Email
            {
                frmEmailDetail frm = new frmEmailDetail(enrollment.Email);
                frm.ShowDialog();
            }
            if(e.ButtonIndex == 2) //Sms
            {
                frmSmsDetail frm = new frmSmsDetail(enrollment.Phone);
                frm.ShowDialog();
            }
        }
    }
}
