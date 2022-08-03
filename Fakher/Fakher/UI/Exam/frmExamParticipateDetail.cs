using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;
using Telerik.WinControls.UI;

namespace Fakher.UI.Exam
{
    public partial class frmExamParticipateDetail : rRadDetailForm
    {
        private PaperBasedExamParticipate PaperBasedExamParticipate { get; set; }
        private OralExamParticipate OralExamParticipate { get; set; }
        private OnlineExamParticipate OnlineExamParticipate { get; set; }

        public frmExamParticipateDetail(ExamParticipate examParticipate)
        {
            InitializeComponent();

            SetProcessingObject(examParticipate);
            radPageView1.SelectedPage = radPageViewPage2;
            PaperBasedExamParticipate = examParticipate as PaperBasedExamParticipate;
            OralExamParticipate = examParticipate as OralExamParticipate;
            OnlineExamParticipate = examParticipate as OnlineExamParticipate;

            rGridComboBoxForms.Columns.Add("نام", "نام", "Name");
            rGridComboBoxForms.DataSource = examParticipate.ExamForm.Exam.Forms;

            if(OralExamParticipate != null)
            {
                rGridViewOralMarks.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
                rGridViewOralMarks.Mappings.Add(new ColumnMapping { Caption = "نمره", ObjectProperty = "Value" });
                rGridViewOralMarks.DataBind(OralExamParticipate.OralMarks);
            }

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox1,
                                        ControlProperty = "Value",
                                        DataObject = examParticipate,
                                        ObjectProperty = "AdditiveMark"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTxtIdentifier,
                                        ControlProperty = "Value",
                                        DataObject = examParticipate,
                                        ObjectProperty = "Code"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rChkExclusiveParticipation,
                                        ControlProperty = "IsChecked",
                                        DataObject = examParticipate,
                                        ObjectProperty = "ExclusiveParticipation"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rGridComboBoxForms,
                                        ControlProperty = "Value",
                                        DataObject = examParticipate,
                                        ObjectProperty = "ExamForm"
                                    });
            
            rGroupBox1.Enabled = examParticipate.ExamForm.Exam.Type == ExamType.PaperBasedExam;
            rGroupBox2.Enabled = examParticipate.ExamForm.Exam.Type == ExamType.OralExam;

            paymentControl1.Databind(examParticipate.FinancialDocument, FinancialHeading.ExamSignup);

            try
            {
                if (PaperBasedExamParticipate != null)
                {
                    PaperBasedExamParticipate.ExamForm.Exam.CheckKey();
                    Fill(PaperBasedExamParticipate.RawAnswers);
                }
                if(OnlineExamParticipate != null)
                {
                    OnlineExamParticipate.ExamForm.Exam.CheckKey();
                    Fill(OnlineExamParticipate.RawAnswers);
                }
                pictureBox1.Image = examParticipate.GetAnswersheetView();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void Fill(string rawAnswers)
        {
            ExamParticipate examParticipate = GetProcessingObject<ExamParticipate>();

            rGridView2.RadGridView.AllowEditRow = true;
            rGridView2.RadGridView.Columns.Clear();

            if (string.IsNullOrEmpty(rawAnswers))
                return;

            GridViewTextBoxColumn columnCode = new GridViewTextBoxColumn();
            columnCode.HeaderText = "شماره سئوال";
            columnCode.ReadOnly = true;
            rGridView2.RadGridView.Columns.Add(columnCode);

            GridViewMaskBoxColumn column = new GridViewMaskBoxColumn();
            column.HeaderText = "گزینه";
            column.MaskType = MaskType.Numeric;
            column.Mask = "d";
            column.ReadOnly = false;
            rGridView2.RadGridView.Columns.Add(column);

            rGridView2.RadGridView.Rows.Clear();
            for (int i = 0; i < examParticipate.ExamForm.Exam.QuestionCount; i++)
            {
                rGridView2.RadGridView.ColumnCount = examParticipate.ExamForm.Exam.QuestionCount;
                char ch = rawAnswers.ToCharArray()[i];
                GridViewRowInfo row = rGridView2.RadGridView.Rows.AddNew();
                row.Cells[0].Value = i + 1;
                row.Cells[1].Value = ch;
            }
            rGridView2.RadGridView.ColumnCount = 2;

            if (rGridView2.RadGridView.Rows.Count > 0)
            {
                rGridView2.RadGridView.CurrentRow = rGridView2.RadGridView.Rows[0];
                rGridView2.RadGridView.Rows[0].EnsureVisible();
            }
        }

        #region Overrides of rRadDetailForm

        protected override void AfterValidate()
        {
            ExamParticipate examParticipate = GetProcessingObject<ExamParticipate>();

            if(PaperBasedExamParticipate != null)
            {
                List<char> chars = new List<char>();
                foreach (GridViewRowInfo row in rGridView2.RadGridView.Rows)
                    chars.Add(char.Parse(row.Cells[1].Value + ""));
                if(chars.Count > 0)
                    PaperBasedExamParticipate.SetAnswers(new string(chars.ToArray()));
            }

            if(OnlineExamParticipate != null)
            {
                Dictionary<int, int> testAnswers = new Dictionary<int, int>();
                foreach (GridViewRowInfo row in rGridView2.RadGridView.Rows)
                    testAnswers.Add(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(row.Cells[1].Value));

                if (testAnswers.Count > 0)
                    OnlineExamParticipate.SetAnswers(testAnswers, new Dictionary<int, string>());
            }
        }


        #region Overrides of rRadDetailForm

        protected override void AfterBindToObject()
        {
            ExamParticipate examParticipate = GetProcessingObject<ExamParticipate>();
            if(OralExamParticipate != null)
                OralExamParticipate.OralMarks.SyncWith(rGridViewOralMarks.DataSource);

            paymentControl1.BindToObject();
            foreach (FinancialItem item in examParticipate.FinancialDocument.Items)
                Program.CurrentEmployee.RegisterItem(item);
        }

        #endregion

        #endregion

        private void rGridView2_CellValidating(object sender, CellValidatingEventArgs e)
        {
            int value = Convert.ToInt32(e.Value);
            if (value < 0 || value > 4)
                e.Cancel = true;
        }

        private void rGridViewOralMarks_Add(object sender, EventArgs e)
        {
            ExamParticipate examParticipate = GetProcessingObject<ExamParticipate>();
            OralMark oralMark = new OralMark();
            frmOralMarkDetail frm = new frmOralMarkDetail(oralMark);
            if (!frm.ProcessObject())
                return;
            rGridViewOralMarks.Insert(oralMark);
        }

        private void rGridViewOralMarks_Edit(object sender, EventArgs e)
        {
            ExamParticipate examParticipate = GetProcessingObject<ExamParticipate>();
            OralMark oralMark = rGridViewOralMarks.GetSelectedObject<OralMark>();
            frmOralMarkDetail frm = new frmOralMarkDetail(oralMark);
            if (!frm.ProcessObject())
                return;
            rGridViewOralMarks.UpdateGridView();
        }

        private void rGridViewOralMarks_Delete(object sender, EventArgs e)
        {
            ExamParticipate examParticipate = GetProcessingObject<ExamParticipate>();
            OralMark oralMark = rGridViewOralMarks.GetSelectedObject<OralMark>();
            rGridViewOralMarks.RemoveSelectedRow();
        }

        private void lnkManualMarks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExamParticipate examParticipate = GetProcessingObject<ExamParticipate>();
            StringBuilder builder = new StringBuilder();

            if (PaperBasedExamParticipate != null)
            {
                if (!string.IsNullOrEmpty(PaperBasedExamParticipate.RawAnswers))
                    return;
                for (int i = 0; i < PaperBasedExamParticipate.ExamForm.Exam.QuestionCount; i++)
                    builder.Append(PaperBasedExamParticipate.ExamForm.Exam.WhiteChar);
            }

            if(OnlineExamParticipate != null)
            {
                builder.Append(OnlineExamParticipate.RawAnswers);
            }

            if (builder.Length > 0)
            {
                rGroupBox1.Enabled = true;
                Fill(builder.ToString());
            }
        }
    }
}
