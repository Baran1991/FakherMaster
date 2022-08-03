using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Exam;
using Fakher.UI.Report;

namespace Fakher.Controls
{
    public partial class ExamParticipateInfo : UserControl
    {
        private ExamParticipate mExamParticipate;

        public ExamParticipateInfo()
        {
            InitializeComponent();
        }

        private void lnkMasterCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rptMasterCard rpt = new rptMasterCard();
            rpt.DataBind(mExamParticipate.Register.Major, mExamParticipate.Register.Period, new object[] { mExamParticipate.Register });
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }

        private void lnkComment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmExamParticipateComment frm = new frmExamParticipateComment(mExamParticipate);
            if (!frm.ProcessObject())
                return;
            mExamParticipate.Save();
            UpdateInfoPanel();
        }

        public void DataBind(ExamParticipate examParticipate)
        {
            mExamParticipate = examParticipate;
            UpdateInfoPanel();
        }

        public void UpdateInfoPanel()
        {
            if (mExamParticipate.Register != null)
                pictureBox1.Image = mExamParticipate.Register.Student.Photo.Picture;
            else
                pictureBox1.Image = null;
            rLblExam.Text = mExamParticipate.ExamForm.Exam.FarsiText;
            rLblExamForm.Text = mExamParticipate.ExamForm.Name;
            rLblExamFormation.Text = mExamParticipate.Formation.FarsiText;
            rLblCode.Text = mExamParticipate.Code + "";
            if (mExamParticipate.Register != null)
                rLblName.Text = mExamParticipate.Register.Student.FarsiFullname;
            else
                rLblName.Text = "";
            rLblComment.Text = mExamParticipate.Comment;
            rLblStatus.Text = mExamParticipate.StatusText;
            rLblMark.Text = Math.Round(mExamParticipate.CalculateMark(), 2) + "";
        }
    }
}
