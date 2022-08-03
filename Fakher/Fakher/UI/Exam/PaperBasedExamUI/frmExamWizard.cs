using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Holding;
using rComponents;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace Fakher.UI.Exam
{
    public partial class frmExamWizard : rRadForm
    {
        private bool mCustomChangeTabs;
        private Core.DomainModel.Exam mCurrentExam;
        private ExamTrainingItem examTrainingItem;
        private List<SectionItem> checkedSectionItems;
        private List<Enrollment> checkedEnrollments;

        public frmExamWizard()
        {
            InitializeComponent();

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage1;
            radPageView2.SelectedPage = radPageViewPage7;
            mCustomChangeTabs = false;

            rGridTrainingPlan.Columns.Add("نام", "نام", "Name");
            rGridExamItem.Columns.Add("نام", "نام", "Name");

            rGridViewSections.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Section.FarsiName" });
            rGridViewSections.Mappings.Add(new ColumnMapping { Caption = "مدرس", ObjectProperty = "Section.Teacher.FarsiFullname" });
            rGridViewSections.Mappings.Add(new ColumnMapping { Caption = "تعداد دانشجو", ObjectProperty = "ParticipateCount()", AggregateSummary = AggregateSummary.Sum});

            rGridViewEnrollments.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridViewEnrollments.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });
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
            checkedSectionItems = rGridViewSections.GetCheckedObjects<SectionItem>();
            examTrainingItem = rGridExamItem.GetValue<ExamTrainingItem>();
            checkedEnrollments = rGridViewEnrollments.GetCheckedObjects<Enrollment>();

            if (StepIndex == 0) //Start
            {

            }
            if (StepIndex == 1) //Exam Information
            {
                if (rGridExamItem.Value == null)
                {
                    rMessageBox.ShowError("آزمون را انتخاب کنید.");
                    return;
                }
                if (rDatePicker1.Date == null)
                {
                    rMessageBox.ShowError("تاریخ برگزاری آزمون را وارد کنید");
                    return;
                }
                if (rCheckBoxWebReportCard.IsChecked && rDatePickerWebReportCard.Date == null)
                {
                    rMessageBox.ShowError("تاریخ ارائه کارنامه اینترنتی را وارد کنید");
                    return;
                }

                try
                {
                    mCurrentExam = Core.DomainModel.Exam.FromTrainingItem(examTrainingItem);
                    mCurrentExam.Name = rTextBox1.Text.Trim();
                    mCurrentExam.Period = Program.CurrentPeriod;
                    mCurrentExam.Type = ExamType.PaperBasedExam;
                    mCurrentExam.Date = rDatePicker1.Date;
                    mCurrentExam.CanViewWebReportCard = rCheckBoxWebReportCard.IsChecked;
                    mCurrentExam.WebReportCardStartDate = rDatePickerWebReportCard.Date;
                    mCurrentExam.WebReportCardStartTime = rTxtStartTimeWebReportCard.Text;


                    IList<SectionItem> items = SectionItem.GetSectionItems(Program.CurrentPeriod, majorSelector1.Major,
                                                                           examTrainingItem.Lesson);
                    rGridViewSections.DataBind(items);
                    rGridViewEnrollments.DataBind(examTrainingItem.GetEnrollments());

                    rComboBoxForms.DataSource = mCurrentExam.Forms;

                    if (items.Count > 0)
                    {
                        mCustomChangeTabs = true;
                        radPageView2.SelectedPage = radPageViewPage7;
                        mCustomChangeTabs = false;
                    }
                    if (examTrainingItem.Enrollments.Count > 0)
                    {
                        mCustomChangeTabs = true;
                        radPageView2.SelectedPage = radPageViewPage8;
                        mCustomChangeTabs = false;
                    }
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
            }

            if (StepIndex == 2) //Participates
            {
                if (checkedSectionItems.Count == 0 && checkedEnrollments.Count == 0)
                {
                    if (rMessageBox.ShowQuestion("برای این آزمون هیچ شرکت کننده در حال حاضر انتخاب نشده است. آیا مطمئن هستید؟") != DialogResult.Yes)
                        return;
                }

                if (checkedSectionItems.Count > 0)
                {
                    foreach (SectionItem sectionItem in checkedSectionItems)
                    {
                        IList<Participate> participates = sectionItem.GetParticipates();
                        if(participates.Count == 0)
                        {
                            rMessageBox.ShowError(
                                "در گروه {0} و درس/سطح {1} هیچ دانشجویی وجود ندارد. بنابراین امکان ثبت آزمون برای این گروه وجود ندارد.", sectionItem.Section.GroupNumber, sectionItem.Item.Lesson.Name);
                            return;
                        }
                        List<Core.DomainModel.Exam> exams = Core.DomainModel.Exam.GetExams(Program.CurrentPeriod,
                                                                                           examTrainingItem, sectionItem);
                        if (exams.Count > 0)
                        {
                            if (
                                rMessageBox.ShowQuestion(
                                    "برای {0} و این آیتم، قبلا در همین ترم آزمون ساخته شده است. از ساخت مجدد آزمون مطمئن هستید؟", sectionItem.Section.FarsiName) !=
                                DialogResult.Yes)
                                return;
                        }
                    }
                }
                else
                {
                    List<Core.DomainModel.Exam> exams = Core.DomainModel.Exam.GetExams(Program.CurrentPeriod,
                                                                                       examTrainingItem);
                    if (exams.Count > 0)
                    {
                        if (
                            rMessageBox.ShowQuestion(
                                "برای این آیتم، قبلا در همین ترم آزمون ساخته شده است. از ساخت مجدد آزمون مطمئن هستید؟") !=
                            DialogResult.Yes)
                            return;
                    }
                }
                if(checkedEnrollments.Count > 0)
                {
                    if (rMessageBox.ShowQuestion("برای ساخت آزمون، نیازی نیست که شرکت کنندگان را علامت زده باشید. مگر در موارد خاص. شرکت کنندگان به طور خودکار در هنگام دریافت کارت ثبت نام می شوند. آیا مطمئن هستید؟") != DialogResult.Yes)
                        return;
                    if (rMessageBox.ShowQuestion("برای ساخت آزمون، نیازی نیست که شرکت کنندگان را علامت زده باشید. مگر در موارد خاص. شرکت کنندگان به طور خودکار در هنگام دریافت کارت ثبت نام می شوند. آیا واقعا مطمئن هستید؟") != DialogResult.Yes)
                        return;
                }

                int participateCount = 0;
                foreach (SectionItem sectionItem in checkedSectionItems)
                    participateCount += sectionItem.GetParticipates().Count();
                rLblParticipateMessage.Text = string.Format("تعداد {0} شرکت کننده از {1} گروه و {2} شرکت کننده آزاد در این آزمون ثبت نام خواهند شد.",
                                                participateCount, checkedSectionItems.Count, checkedEnrollments.Count);
            }

            if (StepIndex == 3) //Exam Policies
            {
                btnNext.Text = "تـــایــیــد";
            }

            if (StepIndex == 4) // End
            {
                mCurrentExam.Save();

                #region Section Exam Participates

                foreach (SectionItem sectionItem in checkedSectionItems)
                {
                    IList<Participate> participates = null;
                    if (rRadioBtnEnglishSort.ToggleState == ToggleState.On)
                        participates = sectionItem.GetEnglishOrderedParticipates().ToList();
                    if (rRadioBtnFarsiSort.ToggleState == ToggleState.On)
                        participates = sectionItem.GetFarsiOrderedParticipates().ToList();

                    try
                    {
                        mCurrentExam.AddSection(sectionItem);

                        if (rRadioButton2.ToggleState == ToggleState.On) //One Form
                        {
                            ExamForm examForm = rComboBoxForms.SelectedValue as ExamForm;
                            for (int i = 0; i < participates.Count; i++)
                            {
                                Participate participate = participates[i];
                                ExamParticipate examParticipate = examForm.Signup(participate, null, true, false);
                                examParticipate.Save();
                            }
                        }
                        if (rRadioButton3.ToggleState == ToggleState.On) //Alternative Form
                        {
                            for (int i = 0; i < participates.Count; i++)
                            {
                                Participate participate = participates[i];
                                ExamForm form = mCurrentExam.Forms[i % mCurrentExam.Forms.Count];
                                ExamParticipate examParticipate = form.Signup(participate, null, true, false);
                                examParticipate.Save();
                            }
                        }
                        if (rRadioButton4.ToggleState == ToggleState.On) //Random Form
                        {
                            for (int i = 0; i < participates.Count; i++)
                            {
                                Participate participate = participates[i];
                                ExamForm form = mCurrentExam.GetRandomExamForm();
                                ExamParticipate examParticipate = form.Signup(participate, null, true, false);
                                examParticipate.Save();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        rMessageBox.ShowError(ex.Message);
                        return;
                    }
                }

                #endregion

                #region Enrolled Exam Participates

                if (rRadioBtnEnglishSort.ToggleState == ToggleState.On)
                    checkedEnrollments.OrderBy(x => x.Register.Student.EnglishLastName).ToList();
                if (rRadioBtnFarsiSort.ToggleState == ToggleState.On)
                    checkedEnrollments.OrderBy(x => x.Register.Student.FarsiLastName).ToList();

                if (rRadioButton2.ToggleState == ToggleState.On) //One Form
                {
                    foreach (Enrollment enrollment in checkedEnrollments)
                    {
                        ExamForm examForm = rComboBoxForms.SelectedValue as ExamForm;
                        ExamParticipate examParticipate = examForm.Signup(enrollment, null, true, false);
                        examParticipate.Save();
                    }
                }
                if (rRadioButton3.ToggleState == ToggleState.On) //Alternative Form
                {
                    for (int i = 0; i < checkedEnrollments.Count; i++)
                    {
                        Enrollment enrollment = checkedEnrollments[i];
                        ExamForm form = mCurrentExam.Forms[i % mCurrentExam.Forms.Count];
                        ExamParticipate examParticipate = form.Signup(enrollment, null, true, false);
                        examParticipate.Save();
                    }
                }
                if (rRadioButton4.ToggleState == ToggleState.On) //Random Form
                {
                    foreach (Enrollment enrollment in checkedEnrollments)
                    {
                        ExamForm form = mCurrentExam.GetRandomExamForm();
                        ExamParticipate examParticipate = form.Signup(enrollment, null, true, false);
                        examParticipate.Save();
                    }
                }

                #endregion

                Close();
            }
            GotoNextStep();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            GotoPrevStep();
        }

        private void rDatePicker1_Leave(object sender, EventArgs e)
        {
            rLblDay.Text = rDatePicker1.Date.GetDayOfWeek().ToDescription();
        }

        private void rRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rComboBoxForms.Enabled = args.ToggleState == ToggleState.On;
        }

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

        private void rGridExamItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExamTrainingItem examItem = rGridExamItem.GetValue<ExamTrainingItem>();
            if (examItem == null)
                return;
            rTextBox1.Text = examItem.Name;
        }

        private void rCheckBoxWebReportCard_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rDatePickerWebReportCard.Enabled = rTxtStartTimeWebReportCard.Enabled = rCheckBoxWebReportCard.IsChecked;
        }
    }
}
