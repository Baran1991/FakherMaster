using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Fakher.UI.Exam.Online_Exam_UI;
using Fakher.UI.Holding;
using rComponents;

namespace Fakher.UI.Exam
{
    public partial class frmExamDetail : rRadDetailForm
    {
        public bool SaveExamHolding { get; set; }

        public frmExamDetail(Core.DomainModel.Exam exam)
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;

            rCmbResultType.DataSource = typeof(ExamResultType).GetEnumDescriptions();
            rCmbRankCalculation.DataSource = typeof(RankCalculation).GetEnumDescriptions();

            rGridComboBoxMajor.Columns.Add("نام", "نام", "Name");

            rGridTrainingPlan.Columns.Add("نام", "نام", "Name");
            rGridExamItem.Columns.Add("نام", "نام", "Name");

            rGridComboBoxMajor.DataSource = Program.CurrentDepartment.Majors;

            rGridViewForms.Mappings.Add(new ColumnMapping{Caption = "نام فرم", ObjectProperty = "Name"});
            rGridViewForms.DataBind(exam.Forms);

            rGridViewItems.Mappings.Add(new ColumnMapping{Caption = "نام", ObjectProperty = "Name"});
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "از سئوال", ObjectProperty = "StartIndex" });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "تا سئوال", ObjectProperty = "EndIndex" });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "تعداد سئوال", ObjectProperty = "QuestionCount", AggregateSummary = AggregateSummary.Sum});
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "ضریب", ObjectProperty = "Coefficient" });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "درس", ObjectProperty = "Lesson.Name" });
            rGridViewItems.DataBind(exam.Items);

            rGridCmbPoll.Columns.Add("نام نظرسنجی", "نام نظرسنجی", "Name");
            rGridCmbPoll.Columns.Add("تاریخ شروع", "تاریخ شروع", "StartDateText");
            rGridCmbPoll.Columns.Add("تاریخ پایان", "تاریخ پایان", "EndDateText");
            rGridCmbPoll.DataSource = Core.DomainModel.Poll.Poll.GetAllPolls();


            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = exam,
                ObjectProperty = "Name"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker1,
                ControlProperty = "Date",
                DataObject = exam,
                ObjectProperty = "Date"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox2,
                ControlProperty = "Value",
                DataObject = exam,
                ObjectProperty = "Capacity"
            });

//            ControlMappings.Add(new ControlMapping
//            {
//                Control = rTextBox4,
//                ControlProperty = "Value",
//                DataObject = exam,
//                ObjectProperty = "TuitionFee"
//            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox5,
                ControlProperty = "Value",
                DataObject = exam,
                ObjectProperty = "NegativeScore"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rGridExamItem,
                ControlProperty = "Value",
                DataObject = exam,
                ObjectProperty = "ExamTrainingItem"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbResultType,
                ControlProperty = "SelectedIndex",
                DataObject = exam,
                ObjectProperty = "ResultType"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbRankCalculation,
                ControlProperty = "SelectedIndex",
                DataObject = exam,
                ObjectProperty = "RankCalculation"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox3,
                ControlProperty = "Value",
                DataObject = exam,
                ObjectProperty = "CardNote"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCheckBox1,
                ControlProperty = "IsChecked",
                DataObject = exam,
                ObjectProperty = "CanViewWebReportCard"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker2,
                ControlProperty = "Date",
                DataObject = exam,
                ObjectProperty = "WebReportCardStartDate"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtStartTime,
                ControlProperty = "Text",
                DataObject = exam,
                ObjectProperty = "WebReportCardStartTime"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtRegStartTime,
                ControlProperty = "Text",
                DataObject = exam,
                ObjectProperty = "InternetRegisterStartTime"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtRegEndTime,
                ControlProperty = "Text",
                DataObject = exam,
                ObjectProperty = "InternetRegisterFinishTime"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rCheckBox4,
                ControlProperty = "IsChecked",
                DataObject = exam,
                ObjectProperty = "InternetRegisterable"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker3,
                ControlProperty = "Date",
                DataObject = exam,
                ObjectProperty = "InternetRegisterStartDate"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker4,
                ControlProperty = "Date",
                DataObject = exam,
                ObjectProperty = "InternetRegisterFinishDate"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rChkHasPoll,
                ControlProperty = "Checked",
                DataObject = exam,
                ObjectProperty = "HasPoll"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rGridCmbPoll,
                ControlProperty = "Value",
                DataObject = exam,
                ObjectProperty = "Poll"
            });


            if (exam.ExamTrainingItem != null)
            {
                rGridComboBoxMajor.Value = exam.ExamTrainingItem.Lesson.Major;
                rGridTrainingPlan.Value = exam.ExamTrainingItem.Plan;
                rGridExamItem.Value = exam.ExamTrainingItem;
            }

            rDatePicker2.Enabled = rTxtStartTime.Enabled = exam.CanViewWebReportCard;
            rDatePicker3.Enabled = rDatePicker4.Enabled=rTxtRegEndTime.Enabled=rTxtRegStartTime.Enabled = exam.InternetRegisterable;

            rGridViewAttachments.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            rGridViewAttachments.DataBind(exam.Attachments);

            rGridCmbPoll.Enabled = exam.HasPoll;
        }

        private void rGridViewItems_Add(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = GetProcessingObject<Core.DomainModel.Exam>();
            Major major = rGridComboBoxMajor.GetValue<Major>();
            if (major == null)
            {
                rMessageBox.ShowError("ابتدا رشته را انتخاب کنید.");
                return;
            }
            ExamItem item = new ExamItem { Exam = exam };
            List<Lesson> lessons = major.GetLessons(exam.Period, HoldingType.Lesson).ToList();
            frmExamItemDetail frm = new frmExamItemDetail(item, lessons);
            if(!frm.ProcessObject())
                return;
            rGridViewItems.Insert(item);
        }

        private void rGridViewItems_Edit(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = GetProcessingObject<Core.DomainModel.Exam>();
            Major major = rGridComboBoxMajor.GetValue<Major>();
            if (major == null)
            {
                rMessageBox.ShowError("ابتدا رشته را انتخاب کنید.");
                return;
            }
            ExamItem item = rGridViewItems.GetSelectedObject<ExamItem>();
            List<Lesson> lessons = major.GetLessons(exam.Period, HoldingType.Lesson).ToList();
            frmExamItemDetail frm = new frmExamItemDetail(item, lessons);
            if (!frm.ProcessObject())
                return;
            rGridViewItems.UpdateGridView();
        }

        private void rGridViewItems_Delete(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = GetProcessingObject<Core.DomainModel.Exam>();
            ExamItem item = rGridViewItems.GetSelectedObject<ExamItem>();
            rGridViewItems.RemoveSelectedRow();
        }

        private void rGridViewForms_Add(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = GetProcessingObject<Core.DomainModel.Exam>();
            ExamForm form = new ExamForm() { Exam = exam };
            frmExamFormDetail frm = new frmExamFormDetail(form);
            if(!frm.ProcessObject())
                return;
            rGridViewForms.Insert(form);
        }

        private void rGridViewForms_Edit(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = GetProcessingObject<Core.DomainModel.Exam>();
            ExamForm form = rGridViewForms.GetSelectedObject<ExamForm>();
            frmExamFormDetail frm = new frmExamFormDetail(form);
            if (!frm.ProcessObject())
                return;
            rGridViewForms.UpdateGridView();
        }

        private void rGridViewForms_Delete(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = GetProcessingObject<Core.DomainModel.Exam>();
            ExamForm form = rGridViewForms.GetSelectedObject<ExamForm>();
            if(form.GetParticipates().Any())
            {
                rMessageBox.ShowError("در این فرم از آزمون شرکت کننده وجود دارد و بنابراین امکان حذف آن نیست.");
                return;
            }

            rGridViewForms.RemoveSelectedRow();
        }

        protected override void AfterBindToObject()
        {
            Core.DomainModel.Exam exam = GetProcessingObject<Core.DomainModel.Exam>();

            if(exam.InternetRegisterable)
            {
                long fee = exam.GetTuitionFee(exam.Lesson.Major, RegisterParticipation.ClassAndGeneralExams);
                if(fee == 0)
                {
                    if(rMessageBox.ShowQuestion("برای این آزمون شهریه ای تعریف نشده است و رایگان است. بنابراین دانشجویان رایگان میتوانند ثبت نام کنند. آیا مطمئن هستید؟") != DialogResult.Yes)
                    {
                        CancelClosing();
                        return;
                    }
                }
            }

            exam.EvaluationItem = exam.ExamTrainingItem.EvaluationItem;
            exam.Lesson = exam.ExamTrainingItem.Lesson;

//            exam.Formations.SyncWith(rGridViewFormations.DataSource);            
            exam.Forms.SyncWith(rGridViewForms.DataSource);
            exam.Items.SyncWith(rGridViewItems.DataSource);
            exam.Attachments.SyncWith(rGridViewAttachments.DataSource);

            
        }

        private void rGridComboBoxMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Major major = rGridComboBoxMajor.GetValue<Major>();
            rGridTrainingPlan.Clear();
            if (major == null)
                return;
            IList<TrainingPlan> plans = TrainingPlan.GetPlans(Program.CurrentPeriod, major);
            rGridTrainingPlan.DataSource = plans;
        }

        private void lnkExamKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExamForm examForm = rGridViewForms.GetSelectedObject<ExamForm>();
            if(examForm == null)
            {
                rMessageBox.ShowError("یک فرم را انتخاب کنید.");
                return;
            }

            frmExamKeyDetail frm = new frmExamKeyDetail(examForm);
            if(!frm.ProcessObject())
                return;
        }

        private void rGridTrainingPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridExamItem.Clear();
            TrainingPlan plan = rGridTrainingPlan.GetValue<TrainingPlan>();
            if (plan == null)
                return;

            rGridExamItem.DataSource = plan.GetExamItems();
        }

        private void lnkExamHoldingAssign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Core.DomainModel.Exam exam = GetProcessingObject<Core.DomainModel.Exam>();

            if (rMessageBox.ShowQuestion("برای این آزمون قبلا برگزاری انتساب داده شده است. از انتساب برگزاری جدید به این آزمون اطمینان دارید؟") != DialogResult.Yes)
                return;

            List<Core.DomainModel.Exam> exams = Core.DomainModel.Exam.GetExams(exam.Period);
            frmSelect frm = new frmSelect(exams, new ColumnMapping() { Caption = "نام آزمون", ObjectProperty = "Name" }, new ColumnMapping { Caption = "رشته", ObjectProperty = "Lesson.Major.Name" });
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            
            Core.DomainModel.Exam selectedExam = frm.GetSelectedObject<Core.DomainModel.Exam>();
            if(!selectedExam.HasHolding)
            {
                rMessageBox.ShowError("برای این آزمون برگزاری همزمان تعریف نشده است.");
                return;
            }
            if(!selectedExam.ExamHolding.Exams.Contains(exam))
            {
                selectedExam.ExamHolding.Exams.Add(exam);
                SaveExamHolding = true;
            }
        }

        private void lnkExamHoldingEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Core.DomainModel.Exam exam = GetProcessingObject<Core.DomainModel.Exam>();
            if(!exam.HasHolding)
            {
                rMessageBox.ShowError("برای این آزمون برگزاری همزمان تعریف نشده است.");
                return;
            }

            if (exam.ExamHolding is OnlineExamHolding)
            {
                frmOnlineExamHoldingDetail frmOnlineHolding = new frmOnlineExamHoldingDetail(exam.ExamHolding as OnlineExamHolding);
                if (!frmOnlineHolding.ProcessObject())
                    return;

                SaveExamHolding = true;
            }
            else
            {
                frmExamHoldingDetail frm = new frmExamHoldingDetail(exam.ExamHolding);
                if (!frm.ProcessObject())
                    return;

                SaveExamHolding = true;
            }
        }

        private void rCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rDatePicker2.Enabled = rTxtStartTime.Enabled = rCheckBox1.IsChecked;
        }

        private void rCheckBox4_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rDatePicker3.Enabled = rDatePicker4.Enabled =rTxtRegStartTime.Enabled=rTxtRegEndTime.Enabled= rCheckBox4.Checked;
        }

        private void rGridViewAttachments_Add(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            WebMedia media = WebMedia.FromFileName(dialog.FileName, WebMediaType.Attachment);
            rGridViewAttachments.Insert(media);
        }

        private void rGridViewAttachments_Edit(object sender, EventArgs e)
        {
            WebMedia media = rGridViewAttachments.GetSelectedObject<WebMedia>();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            media.SetFile(dialog.FileName);
            rGridViewAttachments.UpdateGridView();
        }

        private void rGridViewAttachments_Delete(object sender, EventArgs e)
        {
            WebMedia media = rGridViewAttachments.GetSelectedObject<WebMedia>();
            rGridViewAttachments.RemoveSelectedRow();
        }

        private void rChkHasPoll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rGridCmbPoll.Enabled = rChkHasPoll.Checked;
        }

    }
}
