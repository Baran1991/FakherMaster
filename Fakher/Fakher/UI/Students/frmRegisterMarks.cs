using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Telerik.WinControls.UI;
using rComponents;

namespace Fakher.UI.Educational.Students
{
    public partial class frmRegisterMarks : rRadForm
    {
        private IList<string> mGroups;

        public frmRegisterMarks(Register register)
        {
            InitializeComponent();
            SetProcessingObject(register);

            rPageView1.SelectedPage = radPageViewPage1;

            rGridView2.RadGridView.Columns.Add(new GridViewTextBoxColumn("تـرم"));
            rGridView2.RadGridView.Columns.Add(new GridViewTextBoxColumn("درس/سطح"));
            mGroups = GetGroups();
            foreach (string @group in mGroups)
                rGridView2.RadGridView.Columns.Add(@group);
            rGridView2.RadGridView.Columns.Add(new GridViewTextBoxColumn("نمره"));
            rGridView2.RadGridView.Columns.Add(new GridViewTextBoxColumn("نتیجه"));

            Fill();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "آیتم ارزشیابی", ObjectProperty = "EvaluationItem.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نمره", ObjectProperty = "Value" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "دسته نمره", ObjectProperty = "BatchNumber" });

            lessonSelector1.Databind(register.Major.Lessons);
        }

        private void Fill()
        {
            Register register = GetProcessingObject<Register>();
            Major major = register.Major;
            IQueryable<Participate> participates = register.Student.GetParticipates(major).OrderByDescending(x => x.Id);

            //            IEnumerable<EducationalPeriod> periods =
            //                register.Student.GetRegisteredPeriods(major).OrderByDescending(x => x.StartDate);

            foreach (Participate participate in participates)
            {
                LessonHolding lessonHolding = participate.SectionItem.Lesson.GetLessonHolding(participate.Register.Period);
                IList<EvaluationGroup> groups = null;
                if (lessonHolding.EvaluationProtocol != null)
                    groups = lessonHolding.EvaluationProtocol.EvaluationGroups;

                GridViewRowInfo row = rGridView2.RadGridView.Rows.AddNew();
                row.Cells[0].Value = participate.Register.Period.Name;
                row.Cells[1].Value = participate.SectionItem.Lesson.Name;
                for (int i = 0; i < mGroups.Count; i++)
                {
                    string @group = mGroups[i];
                    string mark = "نامشخص";
                    if (groups != null)
                    {
                        EvaluationGroup evaluationGroup = groups.FirstOrDefault(x => x.Name == @group);
                        if (evaluationGroup != null)
                            mark = participate.CalculateMark(evaluationGroup) + "";
                    }
                    row.Cells[i + 2].Value = mark;
                }
                row.Cells[mGroups.Count + 2].Value = participate.CalculateMark();
                row.Cells[mGroups.Count + 3].Value = participate.GetResultLabel().Name;
            }

            IEnumerable<Lesson> lessons = register.Major.GetLessons(register.Period, HoldingType.Exam);
            //IEnumerable<Lesson> lessons = register.Major.GetLessons( HoldingType.Exam);
            foreach (Lesson lesson in lessons)
            {
                IQueryable<ExamParticipate> examParticipates = register.GetExamParticipates(lesson);
                foreach (ExamParticipate examParticipate in examParticipates)
                {
                    GridViewRowInfo row = rGridView2.RadGridView.Rows.AddNew();
                    row.Cells[0].Value = examParticipate.Register.Period.Name;
                    row.Cells[1].Value = examParticipate.Exam.Lesson.Name;
                    for (int i = 0; i < mGroups.Count; i++)
                        row.Cells[i + 2].Value = "";

                    row.Cells[mGroups.Count + 2].Value = examParticipate.CalculateMark();
                    row.Cells[mGroups.Count + 3].Value = examParticipate.StatusText;
                }
            }

            if (rGridView2.RadGridView.Rows.Count > 0)
            {
                rGridView2.RadGridView.CurrentRow = rGridView2.RadGridView.Rows[0];
                rGridView2.RadGridView.CurrentRow.IsSelected = true;
                rGridView2.RadGridView.CurrentRow.Cells[0].IsSelected = true;
                rGridView2.RadGridView.CurrentRow.EnsureVisible();
            }
        }

        private IList<string> GetGroups()
        {
            Register register = GetProcessingObject<Register>();
            List<string> groups = new List<string>();
            foreach (Register reg in register.Student.Registers)
            {
                IEnumerable<Lesson> lessons = reg.GetParticipatedLessons();
                foreach (Lesson lesson in lessons)
                {
                    LessonHolding lessonHolding = lesson.GetLessonHolding(reg.Period);
                    if (lessonHolding.EvaluationProtocol != null)
                        groups.AddRange(lessonHolding.EvaluationProtocol.EvaluationGroups.Select(x => x.Name));
                }

                //                lessons = reg.Major.GetLessons(reg.Period, HoldingType.Exam);
                //                foreach (Lesson lesson in lessons)
                //                {
                //                    LessonHolding lessonHolding = lesson.GetLessonHolding(reg.Period);
                //                    if (lessonHolding.EvaluationProtocol != null)
                //                        groups.AddRange(lessonHolding.EvaluationProtocol.EvaluationGroups.Select(x => x.Name));
                //                }
            }

            return groups.Distinct().ToList();
        }

        private void lessonSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if (lessonSelector1.Lesson == null)
                return;
            Register register = GetProcessingObject<Register>();
            Participate participate = register.GetFirstParticipate(lessonSelector1.Lesson);
            if (participate != null)
                rGridView1.DataBind(participate.Marks);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Mark mark = rGridView1.GetSelectedObject<Mark>();
            mark.Participate.Marks.Remove(mark);
            mark.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView2_Add(object sender, EventArgs e)
        {
            List<GridData> datas = new List<GridData>();
            foreach (GridViewRowInfo row in rGridView2.RadGridView.Rows)
            {
                GridData data = new GridData();
                data.Term = row.Cells[0].Value + "";
                data.Lesson = row.Cells[1].Value + "";
                data.Mark = row.Cells[row.Cells.Count - 2].Value + "";
                data.Status = row.Cells[row.Cells.Count - 1].Value + "";
                datas.Add(data);
            }

            frmSelect frm = new frmSelect(datas, new ColumnMapping {Caption = "تـرم", ObjectProperty = "Term"},
                                          new ColumnMapping {Caption = "درس/سطح", ObjectProperty = "Lesson"},
                                          new ColumnMapping {Caption = "نمره", ObjectProperty = "Mark"},
                                          new ColumnMapping {Caption = "نتیجه", ObjectProperty = "Status"}
                ) {MultiSelect = true};
            if (frm.ShowDialog() != DialogResult.OK)
                return;
            List<GridData> selectedObjects = frm.GetSelectedObjects<GridData>();
            if (selectedObjects.Count == 0)
                return;

            float sum = 0;
            int count = 0;
            foreach (GridData data in selectedObjects)
            {
                sum += (float) Convert.ToDouble(data.Mark);
                count++;
            }

            rMessageBox.ShowInformation("معدل: " + (sum/count).ToString("N2"));
        }

        private class GridData
        {
            public string Term { get; set; }
            public string Lesson { get; set; }
            public string Mark { get; set; }
            public string Status { get; set; }
        }
    }
}
