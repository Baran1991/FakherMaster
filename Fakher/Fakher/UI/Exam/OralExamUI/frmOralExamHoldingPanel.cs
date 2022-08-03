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
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Exam
{
    public partial class frmOralExamHoldingPanel : rRadForm
    {
        private OralExamParticipate mExamParticipate;

        public frmOralExamHoldingPanel()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نمره", ObjectProperty = "Value", AggregateSummary = AggregateSummary.Avg});
        }

        private void radBtnSearch_Click(object sender, EventArgs e)
        {
            long code = rTextBox1.GetValue<long>();
            Search(code);
        }

        private void Search(long code)
        {
            mExamParticipate = OralExamParticipate.GetExamParticipate(code);
            if (mExamParticipate == null)
            {
                rMessageBox.ShowError("داوطلبی با این شماره وجود ندارد.");
                return;
            }
            if (mExamParticipate.ExamForm.Exam.Type != ExamType.OralExam)
            {
                rMessageBox.ShowError("آزمون موردنظر مصاحبه نیست.");
                return;
            }

            examParticipateInfo1.Enabled = rGroupBox2.Enabled = true;
            rGridView1.DataBind(mExamParticipate.OralMarks); 
            examParticipateInfo1.DataBind(mExamParticipate);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            if(mExamParticipate == null)
            {
                rMessageBox.ShowError("ابتدا داوطلب موردنظر را جستجو کنید.");
                return;
            }

            OralMark mark = mExamParticipate.CreateOralMark();
            frmOralMarkDetail frm = new frmOralMarkDetail(mark);
            if(!frm.ProcessObject())
                return;
            mExamParticipate.AddOralMark(mark);
            mExamParticipate.Save();
            rGridView1.Insert(mark);
            examParticipateInfo1.UpdateInfoPanel();
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            OralMark mark = rGridView1.GetSelectedObject<OralMark>();
            frmOralMarkDetail frm = new frmOralMarkDetail(mark);
            if (!frm.ProcessObject())
                return;
            mark.Save();
            rGridView1.UpdateGridView();
            examParticipateInfo1.UpdateInfoPanel();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            OralMark mark = rGridView1.GetSelectedObject<OralMark>();
            mark.Participate.OralMarks.Remove(mark);
            mark.Delete();
            rGridView1.RemoveSelectedRow();
            examParticipateInfo1.UpdateInfoPanel();
        }

        private void rTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                long code = rTextBox1.GetValue<long>();
                Search(code);
            }
        }

    }
}
