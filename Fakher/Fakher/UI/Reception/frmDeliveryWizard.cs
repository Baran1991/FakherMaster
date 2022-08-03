using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using NHibernate;
using DataAccessLayer;

namespace Fakher.UI.Reception
{
    public partial class frmDeliveryWizard : rRadDetailForm
    {
        private bool mCustomChangeTabs;
        private ExamParticipate mExamParticipate;

        public bool IsUsed { get; set; }

        public frmDeliveryWizard()
        {
            InitializeComponent();

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage6;
            mCustomChangeTabs = false;

            //            rGridViewExams.Mappings.Add(new ColumnMapping { Caption = "نام آزمون", ObjectProperty = "TrainingItem.Name" });
            //            rGridViewExams.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "TrainingItem.Lesson.Major.Name" });
            rGridViewExams.Mappings.Add(new ColumnMapping { Caption = "نام آزمون", ObjectProperty = "Name" });
            rGridViewExams.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Lesson.Major.Name" });
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

        private void btnPrev_Click(object sender, EventArgs e)
        {
            GotoPrevStep();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //            Enrollment selectedEnrollment = rGridViewExams.GetSelectedObject<Enrollment>();
            Enrollment selectedEnrollment = null;
            ExamTrainingItem selectedTrainingItem = rGridViewExams.GetSelectedObject<ExamTrainingItem>();
            bool assignSeatNumber = rRadioBtnAssignExamNumber.ToggleState == ToggleState.On;
            bool randomSeatNumber = rRadioBtnAssignRandomExamNumber.ToggleState == ToggleState.On;
            bool reSignup = rChkReSignup.IsChecked;

            if (StepIndex == 0) //Start
            {

            }

            if (StepIndex == 1) //Register Search
            {
                if (registerSearchBox1.SelectedRegister == null)
                {
                    rMessageBox.ShowError("یک دانشجو را انتخاب کنید.");
                    return;
                }

                if (registerSearchBox1.SelectedRegister.Type != RegisterType.Participation)
                {
                    rMessageBox.ShowError("دانشجوی انتخابی شما، در وضعیت مرخصی/انصراف است و امکان تحویل کارت به آن وجود ندارد.");
                    return;
                }

                if (registerSearchBox1.SelectedRegister.Student.Photo.Picture == null)
                {
                    if (rMessageBox.ShowQuestion("این دانشجو عکس ندارد. آیا مایل به ادامه هستید؟") != DialogResult.Yes)
                        return;
                }

                //                IQueryable<Enrollment> examEnrollments = registerSearchBox1.SelectedRegister.GetGeneralExamEnrollments();
                //                rGridViewExams.DataBind(examEnrollments);

                IQueryable<ExamTrainingItem> examTrainingItems = registerSearchBox1.SelectedRegister.Major.GetGeneralExamItems(registerSearchBox1.SelectedRegister.Period);
                rGridViewExams.DataBind(examTrainingItems);
            }

            if (StepIndex == 2) //Exam Enrollments
            {
                if (selectedTrainingItem == null)
                {
                    rMessageBox.ShowError("یک آزمون را انتخاب کنید.");
                    return;
                }

                try
                {
                    selectedEnrollment = registerSearchBox1.SelectedRegister.GetEnrollment(selectedTrainingItem);

                    if (selectedEnrollment == null)
                    {
                        if (rMessageBox.ShowQuestion("این دانشجو، قبلا در این آزمون ثبت نام اولیه نشده است. آیا می خواهید ثبت نام اولیه ثبت گردد؟") != DialogResult.Yes)
                            return;

                        Enrollment enrollment = registerSearchBox1.SelectedRegister.Enroll(selectedTrainingItem);
                        registerSearchBox1.SelectedRegister.AddEnrollment(enrollment);
                        registerSearchBox1.SelectedRegister.Save();
                        selectedEnrollment = enrollment;
                    }

                    if (selectedEnrollment == null)
                    {
                        rMessageBox.ShowError("سیستم قادر به ثبت نام این شخص نیست.");
                        return;
                    }

                    IQueryable<ExamParticipate> examParticipates =
                        registerSearchBox1.SelectedRegister.GetExamParticipates(selectedEnrollment);
                    mExamParticipate = examParticipates.FirstOrDefault();

                    if (mExamParticipate == null || reSignup)
                    {
                        Core.DomainModel.Exam exam = null;
                        List<Core.DomainModel.Exam> exams =
                            Core.DomainModel.Exam.GetExams(selectedEnrollment.Register.Period,
                                                           selectedEnrollment.TrainingItem as ExamTrainingItem)
                                .Where(x => x.Type == ExamType.PaperBasedExam).ToList();
                        if (exams.Count == 0)
                        {
                            rMessageBox.ShowError("این آزمون هنوز تعریف نشده است. لطفا به مسئول آموزش اطلاع دهید.");
                            return;
                        }
                        if (exams.Count == 1)
                        {
                            exam = exams.LastOrDefault();
                        }
                        else
                        {
                            frmSelect frm = new frmSelect(exams,
                                                          new ColumnMapping { Caption = "نام آزمون", ObjectProperty = "Name" },
                                                          new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
                            frm.MultiSelect = false;
                            if (frm.ShowDialog(this) != DialogResult.OK)
                                return;
                            exam = frm.GetSelectedObject<Core.DomainModel.Exam>();
                        }
                        if (exam == null)
                        {
                            rMessageBox.ShowError("امکان ثبت نام در آزمون وجود ندارد. لطفا به مسئول آموزش اطلاع دهید.");
                            return;
                        }


                        IList<ExamParticipate> absentExamParticipates = registerSearchBox1.SelectedRegister.GetAbsentExamParticipates().ToList();
                        if (absentExamParticipates.Count > 0)
                        {
                            string text = "";
                            foreach (ExamParticipate examParticipate in absentExamParticipates)
                            {
                                text += examParticipate.ExamForm.Exam.Name.Trim();
                                if (absentExamParticipates.IndexOf(examParticipate) != absentExamParticipates.Count - 1)
                                    text += " و ";
                            }

                            if (rMessageBox.ShowQuestion("این دانشجو قبلا در {0} آزمون ({1}) غائب بوده است. از تحویل کارت این آزمون مطمئن هستید؟", absentExamParticipates.Count, text) != DialogResult.Yes)
                                return;
                        }

                        mExamParticipate = exam.GetParticipate(registerSearchBox1.SelectedRegister).FirstOrDefault();
                        if ((mExamParticipate == null && assignSeatNumber) || reSignup)
                        {
                            ExamForm examForm = exam.GetRandomExamForm();
                            mExamParticipate = examForm.Signup(selectedEnrollment, null, false, reSignup);
                        }
                    }

                    if (mExamParticipate == null)
                    {
                        rMessageBox.ShowError("دانشجو در این آزمون شماره صندلی ندارد.");
                        return;
                    }

                    if (!mExamParticipate.ExamForm.Exam.HasHolding)
                    {
                        rMessageBox.ShowError("این آزمون فاقد برگزاری است. ابتدا برای آن برگزاری ثبت کنید.");
                        return;
                    }

                    if (registerSearchBox1.SelectedRegister.Major.Id != selectedEnrollment.TrainingItem.Lesson.Major.Id)
                    {
                        rMessageBox.ShowError("رشته آزمون با رشته ثبت نامی داوطلب متفاوت است.");
                        return;
                    }


                    if (mExamParticipate.CardDelivered)
                    {
                        if (assignSeatNumber)
                        {
                            rMessageBox.ShowWarning(
                                "به این دانشجو قبلا شماره صندلی انتساب داده شده است. انتساب جدید شماره صندلی امکان پذیر نیست.");
                            return;
                        }
                        //                        if (assignSeatNumber && rMessageBox.ShowQuestion("برای این دانشجو قبلا شماره صندلی انتساب داده شده است. از انتساب جدید شماره صندلی مطمئن هستید؟") != DialogResult.Yes)
                        //                            return;
                        if (!assignSeatNumber && rMessageBox.ShowQuestion("برای این دانشجو قبلا کارت صادر و چاپ شده است. از چاپ مجدد کارت برای مطمئن هستید؟") != DialogResult.Yes)
                            return;
                    }

                    if (assignSeatNumber)
                    {
                        mExamParticipate.ExamForm.Exam.ExamHolding.RefreshEntity();
                        mExamParticipate.Prepare(randomSeatNumber);
                    }
                    mExamParticipate.PrepareExamCardForDelivery();
                    mExamParticipate.ConfirmEnrollment();

                    if (mExamParticipate.ExamForm.Exam.HasHolding)
                        mExamParticipate.ExamForm.Exam.ExamHolding.Save();
                    mExamParticipate.Save();
                }
                catch (Exception ex)
                {
                    Program.SaveLog("خطا در تحویل کارت - " + ex.Message);
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
                btnNext.Text = "تـــایــیــد";
                btnPrev.Enabled = false;
            }

            if (StepIndex == 3) // End
            {
                Program.SaveLog(string.Format("تحویل کارت ({0}) ({1}) در آزمون ({2}) در ({3})",
                              mExamParticipate.Register.Student.FarsiFullname,
                              assignSeatNumber.ToString(),
                              mExamParticipate.ExamForm.Exam.Name,
                              mExamParticipate.SeatNumber + " - " + mExamParticipate.Formation.FarsiText));

                rptFaExamCard rpt = new rptFaExamCard();
                rpt.DataSource = new[] { mExamParticipate };
                frmReportViewer frm = new frmReportViewer(rpt) { AutoPrint = true };
                frm.ShowDialog(this);

                IsUsed = true;
                Close();
            }
            GotoNextStep();
        }

        private void rChkReSignup_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rChkReSignup.IsChecked)
                rRadioBtnAssignExamNumber.ToggleState = ToggleState.On;
        }
    }
}
