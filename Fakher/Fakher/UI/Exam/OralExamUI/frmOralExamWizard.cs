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
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using Time = rComponents.Time;

namespace Fakher.UI.Exam
{
    public partial class frmOralExamWizard : rRadDetailForm
    {
        private bool mCustomChangeTabs;
        private Core.DomainModel.Exam mCurrentExam;
        private ExamTrainingItem examTrainingItem;

        public frmOralExamWizard()
        {
            InitializeComponent();

            mCustomChangeTabs = true;
            radPageView1.Pages.Remove(radPageViewPage3);
            radPageView1.SelectedPage = radPageViewPage1;
            mCustomChangeTabs = false;

            rGridTrainingPlan.Columns.Add("نام", "نام", "Name");
            rGridExamItem.Columns.Add("نام", "نام", "Name");

            rGridComboBoxPlace.Columns.Add("نام", "نام", "Name");
            rGridComboBoxPlace.DataSource = DbContext.GetAllEntities<Place>();

            rTxtFormationCapacity.Text = "1";
            rTxtFormCapacity.Text = "1";
        }

        private int StepIndex
        {
            get
            {
                return radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            }
        }

        private void GotoNextStep()
        {
            mCustomChangeTabs = true;
            int index = radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            if (index + 1 < radPageView1.Pages.Count)
                radPageView1.SelectedPage = radPageView1.Pages[index + 1];
            mCustomChangeTabs = false;
        }

        private void GotoPrevStep()
        {
            mCustomChangeTabs = true;
            int index = radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            if (index - 1 >= 0)
                radPageView1.SelectedPage = radPageView1.Pages[index - 1];
            mCustomChangeTabs = false;
        }

        private void radPageView1_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {
            e.Cancel = !mCustomChangeTabs;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            examTrainingItem = rGridExamItem.GetValue<ExamTrainingItem>();

//            if (StepIndex == 0)
//            {
//            }
            if (StepIndex == 0)
            {
                try
                {
                    rTxtName.Validate();
                    rDatePicker1.Validate();
//                    rTxtTuitionFee.Validate();
                    rTxtCapacity.Validate();

                    if(rGridExamItem.Value == null)
                        throw new Exception("آیتم ارزشیابی نتیجه آزمون را انتخاب کنید.");
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
            }
            if (StepIndex == 1)
            {
                try
                {
                    rTxtStartTime.Validate();
                    rtxtEndTime.Validate();
                    rtxtInterval.Validate();
                    rTxtRestInterval.Validate();
                    rTxtQuestionCount.Validate();
                    if (rGridComboBoxPlace.Value == null)
                        throw new Exception("مکان برگزاری آزمون را انتخاب کنید.");
                    if (rCheckBoxWebReportCard.IsChecked && rDatePickerWebReportCard.Date == null)
                        throw new Exception("تاریخ ارائه کارنامه اینترنتی را وارد کنید");
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }


                int intervalMinutes = rtxtInterval.GetValue<int>();
                int restMinutes = rTxtRestInterval.GetValue<int>();
                int questionCount = rTxtQuestionCount.GetValue<int>();

                try
                {
                    mCurrentExam = Core.DomainModel.Exam.FromTrainingItem(examTrainingItem);
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }

                OralExamHolding mHolding = new OralExamHolding();

                mHolding.AddExam(mCurrentExam);
//                mHolding.SeatNumberPolicy = SeatNumberPolicy.Sequential;
//                mHolding.SeatAssignPolicy = SeatAssignPolicy.OnCardDelivery;
                
                mCurrentExam.Type = ExamType.OralExam;
                mCurrentExam.Period = Program.CurrentPeriod;
                mCurrentExam.Name = rTxtName.Text;
                mCurrentExam.Date = mHolding.StartDate = rDatePicker1.Date;
//                mCurrentExam.TuitionFee = rTxtTuitionFee.GetValue<long>();
                mCurrentExam.Capacity = rTxtCapacity.GetValue<int>();
//                mCurrentExam.Lesson = examTrainingItem.Lesson;
//                mCurrentExam.EvaluationItem = rGridExamItem.GetValue<EvaluationItem>();
                mCurrentExam.CanViewWebReportCard = rCheckBoxWebReportCard.IsChecked;
                mCurrentExam.WebReportCardStartDate = rDatePickerWebReportCard.Date;
                mCurrentExam.WebReportCardStartTime = rTxtStartTimeWebReportCard.Text;

                ExamItem item = new ExamItem();
                item.StartFarakhanNo =int.Parse( rTextBoxFarakhanFrom.Text);
                item.Name = mCurrentExam.Name;
                item.StartIndex = 1;
                item.EndIndex = 1;
                item.Lesson = null;
                item.Coefficient = 1;
                mCurrentExam.Items.Clear();
                mCurrentExam.AddExamItem(item);

                Time startTime = Time.FromString(rTxtStartTime.Text);
                Time endTime = Time.FromString(rtxtEndTime.Text);
                DateTime startDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                      startTime.Hour, startTime.Minute, 0);
                DateTime endDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                    endTime.Hour, endTime.Minute, 0);
                DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startDateTime.Hour,
                                             startDateTime.Minute, startDateTime.Second);
                var counter = item.StartFarakhanNo;
                while (time < endDateTime)
                {
                    Formation formation = new Formation();
                    formation.FarakhanNo = counter;
                    counter++;
                    formation.StartHour = time.Hour;
                    formation.StartMinute = time.Minute;
                    DateTime formationEndDateTime = time.AddMinutes(intervalMinutes);
                    formation.FinishHour = formationEndDateTime.Hour;
                    formation.FinishMinute = formationEndDateTime.Minute;
                    formation.Day = rDatePicker1.Date.GetDayOfWeek();
                    formation.CapacityPolicy = FormationCapacityPolicy.Specific;
                    formation.Capacity = rTxtFormationCapacity.GetValue<int>();
                    formation.Place = rGridComboBoxPlace.GetValue<Place>();
                    
                    mHolding.AddFormation(formation);

                    formationEndDateTime = formationEndDateTime.AddMinutes(restMinutes);
                    time = new DateTime(formationEndDateTime.Year, formationEndDateTime.Month, formationEndDateTime.Day,
                                        formationEndDateTime.Hour, formationEndDateTime.Minute,
                                        formationEndDateTime.Second);
                }

                mCurrentExam.Forms.Clear();
                for (int i = 1; i < questionCount + 1; i++)
                {
                    ExamForm examForm = new ExamForm();
                    examForm.Name = "پاکت سئوال " + i;
                    examForm.CapacityPolicy = CapacityType.Determined;
                    examForm.Capacity = rTxtFormCapacity.GetValue<int>();
                    mCurrentExam.AddExamForm(examForm);
                }

                btnNext.Text = "تـــایــیــد";
            }
            if (StepIndex == 2) // End
            {
                mCurrentExam.Save();
                Close();
            }
            GotoNextStep();
        }

//        private void lessonSelector1_SelectedChanged(object sender, EventArgs e)
//        {
//            rGridExamItem.Clear();
//            if (lessonSelector1.Lesson == null)
//                return;
//            EvaluationProtocol evaluationProtocol = lessonSelector1.Lesson.GetEvaluationProtocol(Program.CurrentPeriod);
//            if(evaluationProtocol == null)
//            {
//                rMessageBox.ShowError("آیین نامه ارزشیابی این درس/سطح تعریف نشده است.");
//                return;
//            }
//            List<EvaluationItem> evaluationItems = evaluationProtocol.GetAllItems().ToList();
//            rGridExamItem.DataSource = evaluationItems;
//        }

        private void majorSelector1_SelectedChanged(object sender, EventArgs e)
        {
            rGridTrainingPlan.Clear();
            if (majorSelector1.Major == null)
                return;
            IList<TrainingPlan> plans = TrainingPlan.GetPlans(Program.CurrentPeriod, majorSelector1.Major);
            rGridTrainingPlan.DataSource = plans;
        }

        private void rGridTrainingPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridExamItem.Clear();
            TrainingPlan plan = rGridTrainingPlan.GetValue<TrainingPlan>();
            if (plan == null)
                return;

            rGridExamItem.DataSource = plan.GetExamItems();
        }

        private void rCheckBoxWebReportCard_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rDatePickerWebReportCard.Enabled = rTxtStartTimeWebReportCard.Enabled = rCheckBoxWebReportCard.IsChecked;
        }
    }
}
