using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Exam;
using Fakher.UI.Fundamental.Protocol;
using Fakher.UI.Holding;
using rComponents;

namespace Fakher.UI
{
    public partial class frmExerciseTrainingItemDetail : rRadDetailForm
    {
        public frmExerciseTrainingItemDetail(ExerciseTrainingItem item)
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;
            //var examTypes=new List<s ;
            //examTypes.
            rCmbType.DataSource = typeof(ExamType).GetEnumDescriptions();// ExamType.Exercise.ToDescription();// 

            rCmbResultType.DataSource = typeof(ExamResultType).GetEnumDescriptions();
            rCmbRankCalculation.DataSource = typeof(RankCalculation).GetEnumDescriptions();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرکت کننده", ObjectProperty = "RegisterParticipationText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شهریه", ObjectProperty = "Fee", Type = ColumnType.Money });

            rGridComboBoxMajor.Columns.Add("نام", "نام", "Name");

            rGridComboBoxLesson.Columns.Add("نام", "نام", "Name");
            rGridComboBoxLesson.Columns.Add("رشته", "رشته", "Major.Name");

            rGridComboBoxGroup.Columns.Add("نام", "نام", "Name");
            rGridComboBoxItem.Columns.Add("نام", "نام", "Name");
            rGridViewForms.Mappings.Add(new ColumnMapping { Caption = "نام فرم", ObjectProperty = "Name" });

            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "از سئوال", ObjectProperty = "StartIndex" });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "تا سئوال", ObjectProperty = "EndIndex" });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "تعداد سئوال", ObjectProperty = "QuestionCount", AggregateSummary = AggregateSummary.Sum });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "ضریب", ObjectProperty = "Coefficient" });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "درس", ObjectProperty = "Lesson.Name" });

            rGridComboBoxMajor.DataSource = new[] { item.Plan.Major };
            rGridViewForms.DataBind(item.Forms);
            rGridViewItems.DataBind(item.Items);
            rGridView1.DataBind(item.TuitionFees);

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = item,
                ObjectProperty = "Name"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox2,
                ControlProperty = "Value",
                DataObject = item,
                ObjectProperty = "Capacity"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox3,
                ControlProperty = "Value",
                DataObject = item,
                ObjectProperty = "NegativeScore"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbType,
                ControlProperty = "SelectedIndex",
                DataObject = item,
                ObjectProperty = "Type"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbResultType,
                ControlProperty = "SelectedIndex",
                DataObject = item,
                ObjectProperty = "ResultType"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbRankCalculation,
                ControlProperty = "SelectedIndex",
                DataObject = item,
                ObjectProperty = "RankCalculation"
            });

           

            ControlMappings.Add(new ControlMapping
            {
                Control = rGridComboBoxLesson,
                ControlProperty = "Value",
                DataObject = item,
                ObjectProperty = "Lesson"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rGridComboBoxItem,
                ControlProperty = "Value",
                DataObject = item,
                ObjectProperty = "EvaluationItem"
            });

            if (item.Lesson != null)
            {
                rGridComboBoxMajor.Value = item.Lesson.Major;
                rGridComboBoxLesson.Value = item.Lesson;
            }
            if (item.EvaluationItem != null)
            {
                rGridComboBoxGroup.Value = item.EvaluationItem.EvaluationGroup;
                rGridComboBoxItem.Value = item.EvaluationItem;
            }
        }

        private void rGridViewItems_Add(object sender, EventArgs e)
        {
            ExerciseTrainingItem item = GetProcessingObject<ExerciseTrainingItem>();
            Major major = rGridComboBoxMajor.GetValue<Major>();
            if (major == null)
            {
                rMessageBox.ShowError("ابتدا رشته را انتخاب کنید.");
                return;
            }

            ExamItem examItem = new ExamItem { ExerciseTrainingItem = item };
            List<Lesson> lessons = major.GetLessons(item.Plan.Period, HoldingType.Lesson).ToList();
//            List<Lesson> lessons = major.GetLessons(item.Plan.Period).ToList();
            frmExamItemDetail frm = new frmExamItemDetail(examItem, lessons);
            if (!frm.ProcessObject())
                return;
            rGridViewItems.Insert(examItem);
        }

        private void rGridViewItems_Edit(object sender, EventArgs e)
        {
            ExerciseTrainingItem item = GetProcessingObject<ExerciseTrainingItem>();
            ExamItem examItem = rGridViewItems.GetSelectedObject<ExamItem>();
            Major major = rGridComboBoxMajor.GetValue<Major>();
            if (major == null)
            {
                rMessageBox.ShowError("ابتدا رشته را انتخاب کنید.");
                return;
            }

            List<Lesson> lessons = major.GetLessons(item.Plan.Period, HoldingType.Lesson).ToList();
//            List<Lesson> lessons = major.GetLessons(item.Plan.Period).ToList();
            frmExamItemDetail frm = new frmExamItemDetail(examItem, lessons);
            if (!frm.ProcessObject())
                return;
            rGridViewItems.UpdateGridView();
        }

        private void rGridViewItems_Delete(object sender, EventArgs e)
        {
            ExerciseTrainingItem item = GetProcessingObject<ExerciseTrainingItem>();
            ExamItem examItem = rGridViewItems.GetSelectedObject<ExamItem>();
            rGridViewItems.RemoveSelectedRow();
        }

        private void rGridViewForms_Add(object sender, EventArgs e)
        {
            ExerciseTrainingItem item = GetProcessingObject<ExerciseTrainingItem>();
            ExamForm form = new ExamForm { ExerciseTrainingItem = item };
            frmExamFormDetail frm = new frmExamFormDetail(form);
            if (!frm.ProcessObject())
                return;
            rGridViewForms.Insert(form);
        }

        private void rGridViewForms_Edit(object sender, EventArgs e)
        {
            ExerciseTrainingItem item = GetProcessingObject<ExerciseTrainingItem>();
            ExamForm form = rGridViewForms.GetSelectedObject<ExamForm>();
            frmExamFormDetail frm = new frmExamFormDetail(form);
            if (!frm.ProcessObject())
                return;
            rGridViewForms.UpdateGridView();
        }

        private void rGridViewForms_Delete(object sender, EventArgs e)
        {
            ExerciseTrainingItem item = GetProcessingObject<ExerciseTrainingItem>();
            ExamForm form = rGridViewForms.GetSelectedObject<ExamForm>();
            rGridViewForms.RemoveSelectedRow();
        }

        protected override void AfterBindToObject()
        {
            ExerciseTrainingItem item = GetProcessingObject<ExerciseTrainingItem>();
            if (rGridViewItems.DataSource.Count == 0)
            {
                if (rMessageBox.ShowQuestion("برای این آیتم، هیچ مواد تمرین تعریف نشده است. آیا مطمئن هستید ؟")
                    != DialogResult.Yes)
                {
                    CancelClosing();
                    return;
                }
            }
            item.Forms.SyncWith(rGridViewForms.DataSource);
            item.Items.SyncWith(rGridViewItems.DataSource);
            item.TuitionFees.SyncWith(rGridView1.DataSource);
        }

        private void rGridComboBoxMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridComboBoxLesson.Clear();
            rGridComboBoxGroup.Clear();
            rGridComboBoxItem.Clear();
            Major major = rGridComboBoxMajor.GetValue<Major>();
            if (major == null)
                return;
//            rGridComboBoxLesson.DataSource = major.GetLessons(Program.CurrentPeriod);
            rGridComboBoxLesson.DataSource = major.Lessons;
        }

        private void rGridComboBoxLesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridComboBoxGroup.Clear();
            rGridComboBoxItem.Clear();
            Lesson lesson = rGridComboBoxLesson.GetValue<Lesson>();
            if (lesson == null)
                return;
            if (lesson.GetEvaluationProtocol(Program.CurrentPeriod) == null)
                return;
            rGridComboBoxGroup.DataSource = lesson.GetEvaluationProtocol(Program.CurrentPeriod).EvaluationGroups;
        }

        private void rGridComboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            EvaluationGroup evaluationGroup = rGridComboBoxGroup.GetValue<EvaluationGroup>();
            if (evaluationGroup == null)
                return;
            rGridComboBoxItem.DataSource = evaluationGroup.Items;
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Lesson lesson = rGridComboBoxLesson.GetValue<Lesson>();
            LessonHolding lessonHolding = lesson.GetLessonHolding(Program.CurrentPeriod);
            if (lessonHolding == null)
            {
                rMessageBox.ShowError("برای این درس در این ترم هیچ ارائه ای تعریف نشده است.");
                return;
            }
            TuitionFee tuitionFee = new TuitionFee();
            frmTuitionFeeDetail frm = new frmTuitionFeeDetail(tuitionFee, lessonHolding.AllowedMajors);
            if (!frm.ProcessObject())
                return;
            foreach (TuitionFee fee in rGridView1.DataSource)
                if (fee.Major.Id == tuitionFee.Major.Id && fee.RegisterParticipation == tuitionFee.RegisterParticipation)
                {
                    rMessageBox.ShowError("برای این رشته و همین نوع شرکت کننده قبلا شهریه ثبت شده است.");
                    return;
                }
            rGridView1.Insert(tuitionFee);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Lesson lesson = rGridComboBoxLesson.GetValue<Lesson>();
            LessonHolding lessonHolding = lesson.GetLessonHolding(Program.CurrentPeriod);
            if (lessonHolding == null)
            {
                rMessageBox.ShowError("برای این درس در این ترم هیچ ارائه ای تعریف نشده است.");
                return;
            }
            TuitionFee tuitionFee = rGridView1.GetSelectedObject<TuitionFee>();
            frmTuitionFeeDetail frm = new frmTuitionFeeDetail(tuitionFee, lessonHolding.AllowedMajors);
            if (!frm.ProcessObject())
                return;

            foreach (TuitionFee fee in rGridView1.DataSource)
                if (fee.Major.Id == tuitionFee.Major.Id && tuitionFee.RegisterParticipation == fee.RegisterParticipation && tuitionFee.Id != fee.Id)
                {
                    rMessageBox.ShowError("برای این رشته قبلا شهریه ثبت شده است.");
                    return;
                }
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            TuitionFee tuitionFee = rGridView1.GetSelectedObject<TuitionFee>();
            rGridView1.RemoveSelectedRow();
        }
    }
}
