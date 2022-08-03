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
using Time = rComponents.Time;

namespace Fakher.UI.Exam.Online_Exam_UI
{
    public partial class frmOnlineExamWizard : rRadDetailForm
    {
        private bool mCustomChangeTabs;
        private Core.DomainModel.Exam mCurrentExam;
        private ExamTrainingItem examTrainingItem;

        public frmOnlineExamWizard()
        {
            InitializeComponent();

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage1;
            mCustomChangeTabs = false;

            rGridTrainingPlan.Columns.Add("نام", "نام", "Name");
            rGridExamItem.Columns.Add("نام", "نام", "Name");

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

        private void majorSelector1_SelectedChanged(object sender, EventArgs e)
        {
            rGridTrainingPlan.Clear();
            if (majorSelector1.Major == null)
                return;
            IList<TrainingPlan> plans = TrainingPlan.GetPlans(Program.CurrentPeriod, majorSelector1.Major);
            rGridTrainingPlan.DataSource = plans;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            examTrainingItem = rGridExamItem.GetValue<ExamTrainingItem>();

            if (StepIndex == 0)
            {
                try
                {
                    if(examTrainingItem.Type != ExamType.OnlineExam)
                        throw new MessageException("نوع این آزمون در برنامه آموزشی انتخاب شده آنلاین نیست و قابل برگزاری به صورت آنلاین نیست.");
                    rTxtName.Validate();
                    if (rGridExamItem.Value == null)
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
                    rDatePickerStart.Validate();
                    if(rCheckBox1.IsChecked)
                        rDatePickerFinish.Validate();
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }

                btnNext.Text = "تـــایــیــد";
            }

            if (StepIndex == 2) // End
            {
                try
                {
                    OnlineExamHolding mHolding = new OnlineExamHolding();
                    mCurrentExam = Core.DomainModel.Exam.FromTrainingItem(examTrainingItem);

                    mCurrentExam.Type = ExamType.OnlineExam;
                    mCurrentExam.Period = Program.CurrentPeriod;
                    mCurrentExam.Name = rTxtName.Text;
                    mCurrentExam.Date = rDatePickerStart.Date;
                    mCurrentExam.CanViewWebReportCard = rCheckBox3.Checked;
                    mCurrentExam.WebReportCardStartDate = rDatePickerWebReporStart.Date;
                    mCurrentExam.WebReportCardStartTime = rTxtWebReportTime.Text;

                    mHolding.StartDate = rDatePickerStart.Date;
                    mHolding.StartTime = rTxtStartTime.Text;
                    mHolding.HasEnd = rCheckBox1.IsChecked;
                    mHolding.EndDate = rDatePickerFinish.Date;
                    mHolding.EndTime = rTxtFinishTime.Text;
                    mHolding.HasDuration = rCheckBox2.IsChecked;
                    mHolding.Duration = rTextBoxDuration.GetValue<int>();

                    mHolding.AddExam(mCurrentExam);
                    mCurrentExam.Save();
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }

                Close();
            }
            GotoNextStep();
        }

        private void rGridTrainingPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridExamItem.Clear();
            TrainingPlan plan = rGridTrainingPlan.GetValue<TrainingPlan>();
            if (plan == null)
                return;

            rGridExamItem.DataSource = plan.GetExamItems();
        }

        private void rGridExamItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExamTrainingItem examItem = rGridExamItem.GetValue<ExamTrainingItem>();
            if (examItem == null)
                return;
            rTxtName.Text = examItem.Name;
        }

        private void rCheckBox1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rDatePickerFinish.Enabled = rTxtFinishTime.Enabled = rCheckBox1.IsChecked;
        }

        private void rCheckBox2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rTextBoxDuration.Enabled = rCheckBox2.IsChecked;
        }

        private void rCheckBox3_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rDatePickerWebReporStart.Enabled = rTxtWebReportTime.Enabled = rCheckBox3.Checked;
        }
    }
}
