using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Consult;
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Reception
{
    public partial class frmConsultationApplicantList : rRadForm
    {
        public frmConsultationApplicantList(Student student)
        {
            InitializeComponent();
            SetProcessingObject(student);

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نــــام", ObjectProperty = "Session.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Session.HoldingDate.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان", ObjectProperty = "Formation.Time" });
            rGridView1.CustomButtons.Add(new rGridViewButton {Position = rGridViewButtonPosition.After, Text = "چاپ کارت"});

            rGridView1.DataBind(student.ConsultationApplicants);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Student student = GetProcessingObject<Student>();
            ConsultationApplicant applicant = new ConsultationApplicant {Student = student};
            frmAssignConsultationSession frm = new frmAssignConsultationSession(applicant);
            if (!frm.ProcessObject())
                return;

            applicant.Save();
            rGridView1.Insert(applicant);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            ConsultationApplicant applicant = rGridView1.GetSelectedObject<ConsultationApplicant>();
            applicant.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            ConsultationApplicant applicant = rGridView1.GetSelectedObject<ConsultationApplicant>();
            if(e.ButtonIndex == 0)
            {
                rptFaConsultationApplicantCard rpt = new rptFaConsultationApplicantCard();
                rpt.DataSource = applicant;
                frmReportViewer frm = new frmReportViewer(rpt) {AutoPrint = true};
                frm.ShowDialog(this);
            }
        }
    }
}
