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
using rComponents;
using Telerik.WinControls.UI;

namespace Fakher.UI.Exam
{
    public partial class frmEnterMark : rRadForm
    {
        public frmEnterMark()
        {
            InitializeComponent();

            rGridComboBoxItems.Columns.Add("گروه", "گروه", "EvaluationGroup.Name");
            rGridComboBoxItems.Columns.Add("نام آیتم", "نام آیتم", "Name");
            rGridComboBoxItems.Columns.Add("مقدار", "مقدار", "Value");
        }

        private void Fill(SectionItem sectionItem, Lesson lesson, EvaluationItem item)
        {
            if (sectionItem == null)
                return;
            if (lesson == null)
                return;
            if (item == null)
                return;

            rGridView1.RadGridView.Columns.Clear();
            rGridView1.Reset();
            rGridView1.RadGridView.AllowEditRow = true;

            GridViewTextBoxColumn columnCode = new GridViewTextBoxColumn();
            columnCode.HeaderText = "شماره دانشجویی";
            columnCode.ReadOnly = true;
            rGridView1.RadGridView.Columns.Add(columnCode);

            GridViewTextBoxColumn columnName = new GridViewTextBoxColumn();
            columnName.HeaderText = "نام";
            columnName.ReadOnly = true;
            rGridView1.RadGridView.Columns.Add(columnName);

            GridViewTextBoxColumn columnLastName = new GridViewTextBoxColumn();
            columnLastName.HeaderText = "نام خانوادگی";
            columnLastName.ReadOnly = true;
            rGridView1.RadGridView.Columns.Add(columnLastName);

            List<int> batchNumbers = sectionItem.Section.GetMarkBatchNumbers(lesson, item).ToList();
            for (int i = 0; i < batchNumbers.Count; i++)
            {
                int batchNumber = batchNumbers[i];

                GridViewMaskBoxColumn column = new GridViewMaskBoxColumn();
                column.HeaderText = "نمره " + (i + 1);
                column.MaskType = MaskType.Numeric;
                column.Mask = "f";
                column.ReadOnly = false;
                rGridView1.RadGridView.Columns.Add(column);
                rGridView1.ColumnTags.Add(rGridView1.RadGridView.Columns.Count - 1, batchNumber);
            }

            rGridView1.RadGridView.Rows.Clear();
            List<Participate> participates = sectionItem.GetEnglishOrderedParticipates().ToList();
            foreach (Participate participate in participates)
            {
                GridViewRowInfo row = rGridView1.RadGridView.Rows.AddNew();
                row.Cells[0].Value = participate.Register.Code;
                row.Cells[1].Value = participate.Register.Student.FarsiFirstName;
                row.Cells[2].Value = participate.Register.Student.FarsiLastName;
                row.Tag = participate;

                int idx = 3;
                foreach (int batchNumber in batchNumbers)
                {
                    Mark mark = participate.GetMark(item, batchNumber);
                    if (mark != null)
                    {
                        row.Cells[idx].Value = mark.Value;
                        row.Cells[idx].Tag = mark;
                        idx++;
                    }
                    else
                    {

                    }
                }
            }
            if(rGridView1.RadGridView.Rows.Count > 0)
            {
                GridViewRowInfo row = rGridView1.RadGridView.Rows[0];
                rGridView1.RadGridView.CurrentRow = row;
                if(row.Cells.Count > 0)
                    row.Cells[0].IsSelected = true;
//                row.IsSelected = true;
                row.EnsureVisible();
            }
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Lesson lesson = lessonSelector1.Lesson;
            EvaluationItem item = rGridComboBoxItems.GetValue<EvaluationItem>();
            SectionItem sectionItem = sectionItemSelector1.SectionItem;
            if (sectionItem == null)
                return;
            if (lesson == null)
                return;
            if (item == null)
                return;

            int batchNumber = Mark.GetNextBatchNumber();
            foreach (GridViewRowInfo row in rGridView1.RadGridView.Rows)
            {
                Participate participate = row.Tag as Participate;
                if(participate.SectionItem.Lesson.Id != lesson.Id)
                {
                    rMessageBox.ShowError("درس/سطح انتخاب شده با درس/سطح دانشجوها متفاوت است.");
                    return;
                }
                Mark mark = participate.CreateMark(lesson, item, PersianDate.Today, batchNumber);
                mark.BatchNumber = batchNumber;
                participate.Marks.Add(mark);
                participate.Save();
            }

            Fill(sectionItem, lesson, item);
        }

        private void rGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            Lesson lesson = lessonSelector1.Lesson;
            EvaluationItem item = rGridComboBoxItems.GetValue<EvaluationItem>();
            
            float value = float.Parse(e.Value + "");

            Participate participate = e.Row.Tag as Participate;
            int batchNumber = (int) rGridView1.ColumnTags[e.Column.Index];

            Mark mark = participate.GetMark(item, batchNumber);
            if (mark == null)
            {
                Mark newMark = participate.CreateMark(lesson, item, PersianDate.Today, batchNumber);
                mark = newMark;
                participate.Marks.Add(newMark);
            }
            mark.BatchNumber = batchNumber;
            mark.Value = value;
            participate.Save();
        }

        private void rGridView1_CellValidating(object sender, CellValidatingEventArgs e)
        {
            EvaluationItem item = rGridComboBoxItems.GetValue<EvaluationItem>();

            float value = float.Parse(e.Value + "");
            if (value < 0 || value > item.Value)
            {
                rMessageBox.ShowError(string.Format("مقدار نمره باید بزرگتر از صفر و کوچکتر از {0} باشد",
                                                                     item.Value));
                e.Cancel = true;
            }
        }

        private void lessonSelector1_SelectedChanged(object sender, EventArgs e)
        {
            Lesson lesson = lessonSelector1.Lesson;
            if (lesson == null)
                return;
        }

        private void rGridComboBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            EvaluationItem item = rGridComboBoxItems.GetValue<EvaluationItem>();
            Lesson lesson = lessonSelector1.Lesson;
            SectionItem sectionItem = sectionItemSelector1.SectionItem;
            if (sectionItem == null)
                return;
            if (lesson == null)
                return;
            if (item == null)
                return;

            Fill(sectionItem, lesson, item);
        }

        private void sectionItemSelector1_SelectedChanged(object sender, EventArgs e)
        {
            EvaluationItem item = rGridComboBoxItems.GetValue<EvaluationItem>();
            Lesson lesson = lessonSelector1.Lesson;
            SectionItem sectionItem = sectionItemSelector1.SectionItem;
            if (sectionItem == null)
                return;
            if (lesson == null)
                return;

            EvaluationProtocol evaluationProtocol = lesson.GetEvaluationProtocol(Program.CurrentPeriod);
            if (evaluationProtocol == null)
            {
                rMessageBox.ShowError(string.Format("آیین نامه ارزشیابی درس {0} تعریف نشده است.", lesson.Name));
                return;
            }

            rGridComboBoxItems.DataSource = evaluationProtocol.GetAllItems().ToList();
            Fill(sectionItem, lesson, item);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Lesson lesson = lessonSelector1.Lesson;
            EvaluationItem item = rGridComboBoxItems.GetValue<EvaluationItem>();
            SectionItem sectionItem = sectionItemSelector1.SectionItem;
            if (sectionItem == null)
                return;
            if (lesson == null)
                return;
            if (item == null)
                return;

            if(rGridView1.RadGridView.CurrentColumn == null)
            {
                rMessageBox.ShowError("یک نمره از ستون موردنظر را انتخاب کنید.");
                return;
            }
            if(!rGridView1.ColumnTags.ContainsKey(rGridView1.RadGridView.CurrentColumn.Index))
            {
                rMessageBox.ShowError("یک نمره از ستون موردنظر را انتخاب کنید.");
                return;
            }

            int batchNumber = (int)rGridView1.ColumnTags[rGridView1.RadGridView.CurrentColumn.Index];

            if (rMessageBox.ShowQuestion("از حذف همه نمره های این ستون اطمینان دارید؟ ") != DialogResult.Yes)
                return;

            foreach (GridViewRowInfo row in rGridView1.RadGridView.Rows)
            {
                Participate participate = row.Tag as Participate;
                if (participate.SectionItem.Lesson.Id != lesson.Id)
                {
                    rMessageBox.ShowError("درس/سطح انتخاب شده با درس/سطح دانشجوها متفاوت است.");
                    return;
                }
                Mark mark = participate.GetMark(item, batchNumber);
                if (mark != null)
                {
                    participate.Marks.Remove(mark);
                    mark.Delete();
                }
            }

            Fill(sectionItem, lesson, item);
        }
    }
}
