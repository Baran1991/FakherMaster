using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Controls;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Exam
{
    public partial class frmOralExamManagePanel : rRadForm
    {
        public frmOralExamManagePanel()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره داوطلبی", ObjectProperty = "Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "فرم آزمون", ObjectProperty = "ExamForm.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان آزمون", ObjectProperty = "ExamTimeText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تلفن", ObjectProperty = "Register.Student.ContactInfo.Phone" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تلفن همراه", ObjectProperty = "Register.Student.ContactInfo.Mobile" });
        }

        private void examSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if(examSelector1.Exam == null)
                return;

//            rGridView1.DataBind(examSelector1.Exam.Participates);
            rGridView1.DataBind(examSelector1.Exam.GetParticipates());
        }

        private void UpdatePanel()
        {
            if (examSelector1.Exam == null)
                return;
            if(rGridView1.DataSource.Count == 0)
                return;
            ExamParticipate examParticipate = rGridView1.GetSelectedObject<ExamParticipate>();
            if(examParticipate == null)
                return;
            examParticipate.RefreshEntity();
            examParticipateInfo1.DataBind(examParticipate);
        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            UpdatePanel();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdatePanel();
        }

        private void frmOralExamManagePanel_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void frmOralExamManagePanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void lnkResultReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (examSelector1.Exam == null)
                return;

            rptFaOralExamResult report = new rptFaOralExamResult();
            rptFaOralExamResult.Exams = new[] {examSelector1.Exam};
            report.DataSource = examSelector1.Exam.GetFarsiOrderedParticipates();

            frmReportViewer frm = new frmReportViewer(report);
            frm.ShowDialog(this);
        }
    }
}
