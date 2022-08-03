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
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace Fakher.UI.Exam
{
    public partial class frmExamSignupWizard : rRadDetailForm
    {
        private bool mCustomChangeTabs;
        private List<SectionItem> checkedSectionItems;
        private List<Enrollment> checkedEnrollments;
        private Core.DomainModel.Exam mCurrentExam;

        public frmExamSignupWizard()
        {
            InitializeComponent();

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage1;
            radPageView2.SelectedPage = radPageViewPage7;
            mCustomChangeTabs = false;

            rGridViewSections.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Section.FarsiName" });
            rGridViewSections.Mappings.Add(new ColumnMapping { Caption = "مدرس", ObjectProperty = "Section.Teacher.FarsiFullname" });
            rGridViewSections.Mappings.Add(new ColumnMapping { Caption = "تعداد دانشجو", ObjectProperty = "ParticipateCount()" });

            rGridViewEnrollments.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridViewEnrollments.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });
//            rGridViewEnrollments.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "Register.FarsiFinancialStatusVerboseText" });

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

        private void examSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if (examSelector1.Exam == null)
                return;

            IList<SectionItem> items = SectionItem.GetSectionItems(Program.CurrentPeriod, examSelector1.Exam.Lesson.Major, examSelector1.Exam.Lesson);
            rGridViewSections.DataBind(items);
            rGridViewEnrollments.DataBind(examSelector1.Exam.ExamTrainingItem.Enrollments);
            rGridViewEnrollments.CheckAll();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            GotoPrevStep();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            checkedSectionItems = rGridViewSections.GetCheckedObjects<SectionItem>();
            checkedEnrollments = rGridViewEnrollments.GetCheckedObjects<Enrollment>();

            if (StepIndex == 0)
            {
                
            }

            if (StepIndex == 1)
            {
                if(examSelector1.Exam == null)
                {
                    rMessageBox.ShowError("آزمون را انتخاب کنید.");
                    return;
                }
                if (checkedSectionItems.Count == 0 && checkedEnrollments.Count == 0)
                {
                    if (rMessageBox.ShowQuestion("برای این آزمون هیچ شرکت کننده در حال حاضر انتخاب نشده است. آیا مطمئن هستید؟") != DialogResult.Yes)
                        return;
                }

                mCurrentExam = examSelector1.Exam;
                int participateCount = 0;
                foreach (SectionItem sectionItem in checkedSectionItems)
                    participateCount += sectionItem.GetParticipates().Count();
                rLblParticipateMessage.Text = string.Format("تعداد {0} شرکت کننده از {1} گروه و {2} شرکت کننده آزاد در این آزمون ثبت نام خواهند شد.",
                                                participateCount, checkedSectionItems.Count, checkedEnrollments.Count);
                btnNext.Text = "تـــایــیــد";
            }

            if (StepIndex == 2)
            {
                
            }

            if (StepIndex == 3)
            {
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
                        if (!mCurrentExam.IsSignedUp(sectionItem))
                            mCurrentExam.AddSection(sectionItem);

                        if (rRadioButton2.ToggleState == ToggleState.On) //One Form
                        {
                            ExamForm examForm = rComboBoxForms.SelectedValue as ExamForm;
                            for (int i = 0; i < participates.Count; i++)
                            {
                                Participate participate = participates[i];
                                if(!mCurrentExam.IsSignedUp(participate.Register))
                                    examForm.Signup(participate, GetFormation(), true, false);
                            }
                        }
                        if (rRadioButton3.ToggleState == ToggleState.On) //Alternative Form
                        {
                            for (int i = 0; i < participates.Count; i++)
                            {
                                Participate participate = participates[i];
                                ExamForm form = mCurrentExam.Forms[i % mCurrentExam.Forms.Count];
                                if (!mCurrentExam.IsSignedUp(participate.Register))
                                    form.Signup(participate, GetFormation(), true, false);
                            }
                        }
                        if (rRadioButton4.ToggleState == ToggleState.On) //Random Form
                        {
                            for (int i = 0; i < participates.Count; i++)
                            {
                                Participate participate = participates[i];
                                ExamForm form = mCurrentExam.GetRandomExamForm();
                                if (!mCurrentExam.IsSignedUp(participate.Register))
                                    form.Signup(participate, GetFormation(), true, false);
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
                        if (!mCurrentExam.IsSignedUp(enrollment.Register))
                            examForm.Signup(enrollment, GetFormation(), true, false);
                    }
                }
                if (rRadioButton3.ToggleState == ToggleState.On) //Alternative Form
                {
                    for (int i = 0; i < checkedEnrollments.Count; i++)
                    {
                        Enrollment enrollment = checkedEnrollments[i];
                        ExamForm form = mCurrentExam.Forms[i % mCurrentExam.Forms.Count];
                        if (!mCurrentExam.IsSignedUp(enrollment.Register))
                            form.Signup(enrollment, GetFormation(), true, false);
                    }
                }
                if (rRadioButton4.ToggleState == ToggleState.On) //Random Form
                {
                    foreach (Enrollment enrollment in checkedEnrollments)
                    {
                        ExamForm form = mCurrentExam.GetRandomExamForm();
                        if (!mCurrentExam.IsSignedUp(enrollment.Register))
                            form.Signup(enrollment, GetFormation(), true, false);
                    }
                }

                #endregion

                mCurrentExam.Save();
                Close();
            }

            GotoNextStep();
        }

        private Formation GetFormation()
        {
            Formation formation = null;
            if (rRadioButton1.ToggleState == ToggleState.On)
                formation = mCurrentExam.ExamHolding.Formations[0];
            if (rRadioButton5.ToggleState == ToggleState.On)
                formation = mCurrentExam.ExamHolding.GetRandomFormation();
            return formation;
        }

        private void rRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rComboBoxForms.Enabled = args.ToggleState == ToggleState.On;
            if (rComboBoxForms.Enabled)
                rComboBoxForms.DataSource = mCurrentExam.Forms;
        }
    }
}
