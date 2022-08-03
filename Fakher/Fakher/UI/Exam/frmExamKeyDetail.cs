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
    public partial class frmExamKeyDetail : rRadDetailForm
    {
        public frmExamKeyDetail(ExamForm examForm)
        {
            InitializeComponent();

            SetProcessingObject(examForm);

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = examForm,
                ObjectProperty = "Name"
            });

            Fill(examForm.Key);
        }

        private void Fill(string rawAnswers)
        {
            ExamForm examForm = GetProcessingObject<ExamForm>();

            rGridView1.RadGridView.AllowEditRow = true;
            rGridView1.RadGridView.Columns.Clear();

            GridViewTextBoxColumn columnCode = new GridViewTextBoxColumn();
            columnCode.HeaderText = "شماره سئوال";
            columnCode.ReadOnly = true;
            rGridView1.RadGridView.Columns.Add(columnCode);

            GridViewMaskBoxColumn column = new GridViewMaskBoxColumn();
            column.HeaderText = "گزینه";
            column.MaskType = MaskType.Numeric;
            column.Mask = "d";
            column.ReadOnly = false;
            rGridView1.RadGridView.Columns.Add(column);

            rGridView1.RadGridView.Rows.Clear();
            if (!string.IsNullOrEmpty(rawAnswers))
            {
                rGridView1.RadGridView.ColumnCount = examForm.Exam.QuestionCount;
                for (int i = 0; i < examForm.Exam.QuestionCount; i++)
                {
                    if (i >= rawAnswers.Length)
                        break;
                    char ch = rawAnswers.ToCharArray()[i];
                    GridViewRowInfo row = rGridView1.RadGridView.Rows.AddNew();
                    // GridViewRowInfo row = rGridView1.RadGridView.Rows[i];
                    row.Cells[0].Value = i + 1;
                    row.Cells[1].Value = ch;                    
                }
                rGridView1.RadGridView.ColumnCount = 2;
            }

            if (rGridView1.RadGridView.Rows.Count == examForm.Exam.QuestionCount - 1)
            {
                rGridView1.RadGridView.CurrentRow = rGridView1.RadGridView.Rows[examForm.Exam.QuestionCount - 1];
                rGridView1.RadGridView.Rows[examForm.Exam.QuestionCount - 1].EnsureVisible();
            }
            rGridView1.RadGridView.VerticalScroll.Enabled = true;
            rGridView1.RadGridView.Refresh();
            rGridView1.RadGridView.VerticalScroll.Visible = VerticalScroll.Visible;
            rGridView1.VerticalScroll.Visible = VerticalScroll.Visible;
        }

        #region Overrides of rRadDetailForm

        protected override void AfterBindToObject()
        {
            ExamForm examForm = GetProcessingObject<ExamForm>();

            List<char> chars = new List<char>();
            foreach (GridViewRowInfo row in rGridView1.RadGridView.Rows)
                chars.Add(char.Parse(row.Cells[1].Value + ""));

            if (chars.Count > 0)
            {
                string key = new string(chars.ToArray());
                try
                {
                    //examForm.SetKey(key);
                    examForm.Key = key;
                }
                catch (Exception e)
                {
                    rMessageBox.ShowError(e.Message);
                    CancelClosing();
                    return;
                }
            }
        }

        #endregion

        private void lnkManualKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExamForm examForm = GetProcessingObject<ExamForm>();
            if (examForm.HasKey)
            {
                if (rMessageBox.ShowQuestion("برای این آزمون قبلا کلید وارد شده است. آیا مطمئن هستید؟") !=
                    DialogResult.Yes)
                    return;
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < examForm.Exam.QuestionCount; i++)
                builder.Append('0');

            Fill(builder.ToString());
        }

        private void rGridView1_CellValidating(object sender, CellValidatingEventArgs e)
        {
            ExamForm examForm = GetProcessingObject<ExamForm>();

            int value = int.Parse(e.Value+ "");
            if (value < 0 || value > 4)
            {
                rMessageBox.ShowError(string.Format("مقدار گزینه باید بین صفر و چهار باشد"));
                e.Cancel = true;
            }
        }
    }
}
