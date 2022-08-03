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
using Fakher.Reports;
using Fakher.UI.Financial;
using Fakher.UI.Person;
using Fakher.UI.Report;
using rComponents;
using Telerik.WinControls.Enumerations;

namespace Fakher.UI.Reception
{
    public partial class frmSignupWizard : rRadDetailForm
    {
        private static string mLastActionText;
        private SignupWizardAction mAction;
        private Register mRegister;
        private ExamParticipate mExamParticipate;
        private Formation mSelectedExamFormation;
        private ExamForm mSelectedExamForm;
        private bool mCustomChangeTabs;
        private Dictionary<SignupWizardAction, List<int>> steps;
        private Department mDepartment;
        private EducationalPeriod mEducationalPeriod;

        public frmSignupWizard()
        {
            InitializeComponent();
            mDepartment = Program.CurrentDepartment;
            mEducationalPeriod = Program.CurrentPeriod;
            steps = new Dictionary<SignupWizardAction, List<int>>();
            steps.Add(SignupWizardAction.NewRegister, new List<int> { 0, 1, 3, 4, 6 });
            steps.Add(SignupWizardAction.ReserveRegister, new List<int> { 0, 1, 2, 3, 4, 6 });
            steps.Add(SignupWizardAction.ExamRegister, new List<int> { 0, 1, 3, 5, 6 });
            steps.Add(SignupWizardAction.SpecialCaseRegister, new List<int> { 0, 1, 3, 4, 6 });
            steps.Add(SignupWizardAction.LevelDeterminationReserve, new List<int> { 0, 1, 2, 3, 4, 6 });

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage12;
            radPageView2.SelectedPage = radPageViewPage6;
            rPageView1.SelectedPage = radPageViewPage8;
            mCustomChangeTabs = false;

            rGridViewCommitments.Mappings.Add(new ColumnMapping { Caption = "سررسید تعهد", ObjectProperty = "Date" });
            rGridViewCommitments.Mappings.Add(new ColumnMapping { Caption = "نوع", ObjectProperty = "TypeText" });
            rGridViewCommitments.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "AmountText" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام لیست", ObjectProperty = "ReserveList.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "دوره/ترم", ObjectProperty = "ReserveList.Period.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ رزرو", ObjectProperty = "ReserveDate" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی رزرو", ObjectProperty = "FarsiFinancialStatusText" });

            rGridViewSectionItems.Mappings.Add(new ColumnMapping { Caption = "درس", ObjectProperty = "Lesson.Name" });
            rGridViewSectionItems.Mappings.Add(new ColumnMapping { Caption = "نام کلاس", ObjectProperty = "Section.Name" });
            rGridViewSectionItems.Mappings.Add(new ColumnMapping { Caption = "زمان تشکیل", ObjectProperty = "Section.FarsiFormationText" });

            rGridViewGeneralExams.Mappings.Add(new ColumnMapping { Caption = "نام آزمون", ObjectProperty = "Name" });

            rGridComboBoxExam.Columns.Add("نام آزمون", "نام آزمون", "Name");
            rGridComboBoxExam.Columns.Add("کلاس/گروه", "کلاس/گروه", "FarsiExamSectionsText");
            rGridComboBoxExam.Columns.Add("آیتم نتیجه", "آیتم نتیجه", "EvaluationItem.Name");
            rGridComboBoxExam.Columns.Add("نوع آزمون", "نوع آزمون", "FarsiTypeText");

            rGridComboBoxExamItems.Columns.Add("نام آیتم", "نام آیتم", "Name");

        }

        private int StepIndex
        {
            get
            {
                return radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            }
        }

        private void GotoFinalStep()
        {
            btnPrev.Enabled = false;
            btnNext.Text = "تـــایــیــد";
            GotoStep(6);
        }

        private void GotoNextStep()
        {
            mCustomChangeTabs = true;
            int index = radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            int indexOf = steps[mAction].IndexOf(index);
            if (indexOf < steps[mAction].Count)
                GotoStep(steps[mAction][indexOf + 1]);
            mCustomChangeTabs = false;
        }

        private void GotoStep(int index)
        {
            mCustomChangeTabs = true;
            if (index >= 0)
                radPageView1.SelectedPage = radPageView1.Pages[index];
            mCustomChangeTabs = false;
        }

        private void GotoPrevStep()
        {
            mCustomChangeTabs = true;
            int index = radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            int indexOf = steps[mAction].IndexOf(index);
            if (indexOf > 0)
                GotoStep(steps[mAction][indexOf - 1]);
            mCustomChangeTabs = false;
        }

        private Register GetProcessingRegister(Major major)
        {
            Student student = studentSearchBox1.SelectedStudent;
            if (mRegister == null || (mRegister != null && mRegister.Student.Id != student.Id))
            {
                mRegister = student.GetRegister(Program.CurrentPeriod, major);
                if (mRegister == null || mRegister.Type == RegisterType.TermVacation || mRegister.Type == RegisterType.PartialVacation)
                {
                    mRegister = student.CreateRegister(Program.CurrentPeriod, major, RegisterType.Participation, true);
                    mRegister.Registrar = Program.CurrentEmployee.FarsiFormalName;
                    //                    mRegister.RegistrarText = Program.CurrentEmployee.FarsiFormalName;
                }
            }
            return mRegister;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Student student = studentSearchBox1.SelectedStudent;

            try
            {
                if (StepIndex == 0) //Start
                {
                    paymentControl2.Databind(new FinancialDocument(),FinancialHeading.PaidTution);
                    if (rRadioButton1.ToggleState == ToggleState.On)
                    {
                        mAction = SignupWizardAction.NewRegister;
                        mLastActionText = rRadioButton1.Text;
                        paymentControl1.Databind(new FinancialDocument(),FinancialHeading.Signup);
                    }
                    if (rRadioButton2.ToggleState == ToggleState.On)
                    {
                        mAction = SignupWizardAction.ReserveRegister;
                        mLastActionText = rRadioButton2.Text;
                        paymentControl1.Databind(new FinancialDocument(),FinancialHeading.ReserveSignup);                    
                    }
                    if (rRadioButton3.ToggleState == ToggleState.On)
                    {
                        mAction = SignupWizardAction.ExamRegister;
                        mLastActionText = rRadioButton3.Text;
                        paymentControl1.Databind(new FinancialDocument(),FinancialHeading.ExamSignup);                    
                    }
                    if (rRadioButton4.ToggleState == ToggleState.On)
                    {
                        mAction = SignupWizardAction.SpecialCaseRegister;
                        mLastActionText = rRadioButton4.Text;
                        paymentControl1.Databind(new FinancialDocument(),FinancialHeading.Signup);                    
                    }
                    if (rRadioButton5.ToggleState == ToggleState.On)
                    {
                        mAction = SignupWizardAction.LevelDeterminationReserve;
                        mLastActionText = rRadioButton5.Text;
                        paymentControl1.Databind(new FinancialDocument(), FinancialHeading.LevelDeterminationSignup);                       
                    }

                    GotoNextStep();
                    return;
                }
              

                if (StepIndex == 1) //Student Search
                {
                    if (student == null)
                    {
                        rMessageBox.ShowError("یک دانشجو را مشخص کنید.");
                        return;
                    }
                    if (mAction == SignupWizardAction.ReserveRegister && student.Id == 0)
                    {
                        rMessageBox.ShowError("ثبت نام رزرو برای دانشجویانی که پرونده جدید دارند امکان پذیر نیست.");
                        return;
                    }

                    if (mAction == SignupWizardAction.ReserveRegister)
                    {
                        rGridView2.DataBind(student.GetNotRegisteredReserves());
                    }
                    if (mAction == SignupWizardAction.LevelDeterminationReserve && student.Id == 0)
                    {
                        rMessageBox.ShowError("ثبت نام رزرو برای دانشجویانی که پرونده جدید دارند امکان پذیر نیست.");
                        return;
                    }
                    if (mAction == SignupWizardAction.LevelDeterminationReserve)
                    {
                        rGridView2.DataBind(student.GetNotRegisteredLevelDeteminationReserves());
                    }

                    GotoNextStep();
                    return;
                }

                if (StepIndex == 2) //Reserve Register
                {
                    Reserve reserve = rGridView2.GetSelectedObject<Reserve>();
                    if (reserve == null)
                    {
                        rMessageBox.ShowError("رزرو دانشجو را انتخاب کنید.");
                        return;
                    }

                    majorSelector2.Major = reserve.ReserveList.Major;
                    if (reserve.ReserveList.Section != null)
                    {
                        if (reserve.ReserveList.Section.Items.Count > 0)
                            lessonSelector2.Lesson = reserve.ReserveList.Section.Items[0].Item.Lesson;
                        //                    sectionSelector2.Section = reserve.ReserveList.Section;
                    }
                    if(mAction == SignupWizardAction.LevelDeterminationReserve)
                    {
                        foreach (FinancialItem item in reserve.FinancialDocument.PaymentItems)
                        {
                            FinancialItem clone = item.Clone();
                            clone.Heading = FinancialHeading.LevelDeterminationSignup;
                            paymentControl1.AddItem(clone);
                            //paymentControl2.AddItem(clone);
                        }
                    }
                    if (mAction == SignupWizardAction.ReserveRegister)
                    {
                        foreach (FinancialItem item in reserve.FinancialDocument.PaymentItems)
                        {
                            FinancialItem clone = item.Clone();
                            clone.Heading = FinancialHeading.ReserveSignup;
                            paymentControl1.AddItem(clone);
                            //paymentControl2.AddItem(clone);
                        }
                    }

                    foreach (FinancialItem item in reserve.FinancialDocument.DiscountItems)
                    {
                        FinancialItem clone = item.Clone();
                        clone.Heading = FinancialHeading.Signup;
                        paymentControl1.AddItem(clone);
                        paymentControl2.AddItem(clone);
                    }                  
                    GotoNextStep();
                    return;
                }
                if (StepIndex == 3) //Financial
                {
                    if (paymentControl1.DataSource.Count == 0 && paymentControl2.DataSource.Count == 0)
                    {
                        if (rMessageBox.ShowQuestion("اطلاعات مالی این دانشجو وارد نشده است. آیا مایل به ذخیره بدون اطلاعات مالی هستید ؟") != DialogResult.Yes)
                            return;
                    }

                    //                if (mAction == SignupWizardAction.NewRegister)
                    //                    GotoStep(2);
                    //                if (mAction == SignupWizardAction.ReserveRegister)
                    //                    GotoStep(2);
                    //                if (mAction == SignupWizardAction.ExamRegister)
                    //                    GotoStep(1);
                    if (mAction == SignupWizardAction.SpecialCaseRegister)
                    {
                        rChkAutoSignup.Checked = false;
                        rChkAutoSignup.Enabled = false;
                        //                    GotoStep(2);
                    }

                    GotoNextStep();
                    return;
                }

                if (StepIndex == 4) //NewRegister
                {
                    List<ExamTrainingItem> examTrainingItems = rGridViewGeneralExams.GetCheckedObjects<ExamTrainingItem>();

                    if (rGridViewSectionItems.DataSource.Count == 0
                        && examTrainingItems.Count == 0)
                    {
                        rMessageBox.ShowError("این دانشجو در هیچ کلاس یا آزمونی ثبت نام نشده است.");
                        return;
                    }

                    Reserve reserve = rGridView2.GetSelectedObject<Reserve>();
                    Major major = majorSelector2.Major;
                    Register register = GetProcessingRegister(major);

                    Register lastRegister = register.Student.GetLastRegister(major);
                    if (lastRegister != null && lastRegister.NextEnrollmentBanned)
                    {
                        rMessageBox.ShowError("این دانشجو از ثبت نام در ترم جـدید منع شده است. علت منع: " + lastRegister.NextEnrollmentBanReason, true);
                        return;
                    }

                    if (rGridViewSectionItems.DataSource.Count == 0 && examTrainingItems.Count > 0)
                    {
                        if (rMessageBox.ShowQuestion("این دانشجو فقط در آزمون ها ثبت نام خواهد شد. آیا مطمئن هستید؟")
                            != DialogResult.Yes)
                            return;
                        //                        register.RegisterParticipation = RegisterParticipation.GeneralExamsOnly;
                    }

                    register.Major = major;
                    register.FinancialDocument.Items.Clear();
                    foreach (FinancialItem item in paymentControl1.DataSource)
                        register.FinancialDocument.Items.Add(item);
                    foreach (FinancialItem item in paymentControl2.DataSource)
                        register.FinancialDocument.Items.Add(item);
                    register.FinancialCommitments.Clear();
                    foreach (FinancialCommitment commitment in rGridViewCommitments.DataSource)
                    {
                        commitment.Register = register;
                        register.FinancialCommitments.Add(commitment);
                    }


                    //                    for (int i = register.Participates.Count - 1; i >= 0 ; i--)
                    //                    {
                    //                        Participate participate = register.Participates[i];
                    //                        bool found = false;
                    //                        foreach (SectionItem sectionItem in rGridViewSectionItems.DataSource)
                    //                        {
                    //                            if (participate.SectionItem.Id == sectionItem.Id)
                    //                            {
                    //                                found = true;
                    //                                break;
                    //                            }
                    //                        }
                    //
                    //                        if (!found)
                    //                        {
                    //                            register.Participates.Remove(participate);
                    //                        }
                    //                    }

                    foreach (SectionItem sectionItem in rGridViewSectionItems.DataSource)
                    {
                        if (!register.GetParticipates(sectionItem.Lesson).Any())
                        {
                            Participate participate = register.Signup(sectionItem, !rChkAutoSignup.Checked);
                            register.AddParticipate(participate);
                            register.AddEnrollment(participate.Enrollment);
                        }
                    }

                    foreach (ExamTrainingItem trainingItem in examTrainingItems)
                    {
                        Enrollment enrollment = register.Enroll(trainingItem);
                        register.AddEnrollment(enrollment);
                    }

                    if (mAction == SignupWizardAction.ReserveRegister)
                    {
                        reserve.Register = register;
                        if (register.Major.Id == reserve.ReserveList.Major.Id && register.Period.Id == reserve.ReserveList.Period.Id)
                        {
                            register.EducationalCode = reserve.EducationalCode;
                            //                            register.Code = reserve.Code;
                        }
                    }
                    if (mAction == SignupWizardAction.LevelDeterminationReserve)
                    {
                        reserve.Register = register;
                        if (register.Major.Id == reserve.ReserveList.Major.Id && register.Period.Id == reserve.ReserveList.Period.Id)
                        {
                            register.EducationalCode = reserve.EducationalCode;
                            //                            register.Code = reserve.Code;
                        }
                    }

                    UpdateSignupAbstract();
                    GotoFinalStep();

                    return;
                }
             


                if (StepIndex == 5) //Exam
                {
                    if (rRadioManualExamForm.ToggleState == ToggleState.On && mSelectedExamForm == null)
                    {
                        rMessageBox.ShowError("فرم آزمون را انتخاب کنید.");
                        return;
                    }
                    if (rRadioManualExamFormation.ToggleState == ToggleState.On && mSelectedExamFormation == null)
                    {
                        rMessageBox.ShowError("زمان/مکان آزمون را انتخاب کنید.");
                        return;
                    }

                    Core.DomainModel.Exam exam = rGridComboBoxExam.GetValue<Core.DomainModel.Exam>();
                    Register register = GetProcessingRegister(majorSelector1.Major);
                    if (register == null)
                    {
                        rMessageBox.ShowError(string.Format("دانشجو در این ترم در رشته {0} ثبت نام نشده است.", majorSelector1.Major));
                        return;
                    }
                    if (register.Id == 0 && !exam.IsEntranceExam)
                    {
                        rMessageBox.ShowError(string.Format("دانشجو در این ترم در رشته {0} ثبت نام نشده است.", majorSelector1.Major));
                        return;
                    }
                    if (!exam.HasHolding)
                    {
                        rMessageBox.ShowError("این آزمون فاقد برگزاری است. ابتدا برای آن برگزاری ثبت کنید.");
                        return;
                    }
                    if (exam.Type == ExamType.PaperBasedExam)
                    {
                        if (rMessageBox.ShowQuestion("در آزمونهای کتبی نیازی به ثبت نام نیست. فقط باید نسبت به تحویل کارت سریع اقدام شود. با این حال آیا مطمئن هستید که ثبت نام انجام شود؟") != DialogResult.Yes)
                            return;
                    }
                    if (exam.IsSignedUp(register))
                    {
                        rMessageBox.ShowError("این دانشجو قبلا در همین آزمون ثبت نام شده است.");
                        return;
                    }

                    try
                    {
                        if (rRadioAutoExamForm.ToggleState == ToggleState.On)
                        {
                            mSelectedExamForm = exam.GetNextFreeExamForm();
                            if (mSelectedExamForm == null)
                                mSelectedExamForm = exam.GetRandomExamForm();
                        }
                        if (rRadioAutoExamFormation.ToggleState == ToggleState.On)
                            mSelectedExamFormation = exam.ExamHolding.GetRandomFormation();

                        if (exam.Type == ExamType.PaperBasedExam)
                        {
                            if(rRadioAutoExamFormation.ToggleState == ToggleState.On)
                            {
                                mExamParticipate = mSelectedExamForm.Signup(register, null, false, false);
                                mExamParticipate.Prepare(false); //for paperbased examparticipates
                            }
                        }
                        else
                        {
                            mExamParticipate = mSelectedExamForm.Signup(register, mSelectedExamFormation, false, false);
                        }

                        foreach (FinancialItem item in paymentControl1.DataSource)
                            mExamParticipate.FinancialDocument.Items.Add(item);
                        foreach (FinancialItem item in paymentControl2.DataSource)
                            mExamParticipate.FinancialDocument.Items.Add(item);
                    }
                    catch (Exception ex)
                    {
                        rMessageBox.ShowError(ex.Message);
                        return;
                    }

                    UpdateSignupAbstract();
                    GotoFinalStep();
                    return;
                }

                if (StepIndex == 6) // Final
                {
                    Core.DomainModel.Exam exam = rGridComboBoxExam.GetValue<Core.DomainModel.Exam>();
                    Major major = majorSelector2.Major;
                    Register register = GetProcessingRegister(major);

                    if (mAction == SignupWizardAction.NewRegister
                        || mAction == SignupWizardAction.ReserveRegister
                            || mAction == SignupWizardAction.SpecialCaseRegister
                                || mAction == SignupWizardAction.LevelDeterminationReserve)
                    {

                        mRegister.ConfirmEnrollment();
                        student.Registers.Add(mRegister);
                        student.Save();

                        Program.CurrentEmployee.RegisterTransactionFor(mRegister);

                        rptSignupReceipt rpt = new rptSignupReceipt();
                        rpt.DataSource = new object[] { register };
                        frmReportViewer frmReport = new frmReportViewer(rpt) { AutoPrint = true };
                        frmReport.ShowDialog(this);
                    }

                    if (mAction == SignupWizardAction.ExamRegister)
                    {
                        Program.SaveLog(string.Format("ثبت نام سریع ({0}) در آزمون ({1})",
                                                      mExamParticipate.Register.Student.FarsiFullname, exam.Name));

                        mExamParticipate.PrepareExamCardForDelivery();
                        mExamParticipate.ConfirmEnrollment();

//                        mExamParticipate.Register.Save();
                        if(!student.Registers.Contains(mRegister))
                        {
                            student.Registers.Add(mRegister);
                            student.Save();
                        }

                        if (exam.Type == ExamType.PaperBasedExam
                            && mExamParticipate.ExamForm.Exam.HasHolding)
                            mExamParticipate.ExamForm.Exam.ExamHolding.Save();
                        mExamParticipate.Save();

                        Program.CurrentEmployee.RegisterTransactionFor(mExamParticipate);

                        rptFaExamCard rpt = new rptFaExamCard();
                        rpt.DataSource = new[] { mExamParticipate };
                        frmReportViewer frm = new frmReportViewer(rpt) { AutoPrint = true };
                        frm.ShowDialog(this);
                    }
                    Program.SetCurrentDepartment(mDepartment);
                    Program.SetCurrentPeriod(mEducationalPeriod);
                    Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void UpdateSignupAbstract()
        {
            FinancialEntity financialEntity;
            if (mAction == SignupWizardAction.ExamRegister)
                financialEntity = mExamParticipate;
            else
            {
                Register register = GetProcessingRegister(majorSelector1.Major);
                financialEntity = register;

                Register prevRegister = register.GetPrevRegister();
                if (prevRegister != null)
                {
                    rLblPrevRegisterFinancial.Text = prevRegister.FarsiFinancialStatusVerboseText;
                    panel4.Visible = true;
                }
            }
            rLblTuitionFee.Text = financialEntity.PayableTuition.ToString("C0");
            rLblTuitionDifferent.Text = financialEntity.TuitionDifference.ToString("C0");
            rLblTotalTuitionFee.Text = financialEntity.EffectivePayableTuition.ToString("C0");
            rLblPayedBalance.Text = financialEntity.FinancialDocument.PayedBalance.ToString("C0");
            rLblDiscountBalance.Text = financialEntity.FinancialDocument.DiscountBalance.ToString("C0");                   
            rLblFinancialStatus.Text = "وضعیت مالی: " + financialEntity.FarsiFinancialStatusVerboseText;
        }
        private void rBtnSignup_Click(object sender, EventArgs e)
        {
            Major major = majorSelector2.Major;
            Lesson lesson = lessonSelector2.Lesson;
            SectionItem sectionItem = sectionItemSelector1.SectionItem;
            Register register = GetProcessingRegister(major);

            #region Repeat-Validation

            if (lesson == null)
            {
                rMessageBox.ShowError("درس را انتخاب کنید.");
                return;
            }

            if (sectionItem == null)
            {
                rMessageBox.ShowError("گــروه را انتخاب کنید.");
                return;
            }

            try
            {
                sectionItem.RefreshEntity();
                sectionItem.CheckCapacity();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }

            foreach (SectionItem item in rGridViewSectionItems.DataSource)
            {
                if (item.Lesson.Id == sectionItem.Lesson.Id)
                {
                    rMessageBox.ShowError("این درس/سطح قبلا اخذ شده است.");
                    return;
                }
            }

            foreach (SectionItem item in rGridViewSectionItems.DataSource)
            {
                if (item.Id == sectionItem.Id)
                {
                    rMessageBox.ShowError("این گــروه قبلا اخذ شده است.");
                    return;
                }
            }

            if (register.Student.SignedUpIn(sectionItem))
            {
                rMessageBox.ShowError("دانشجو قبلا در همین کلاس ثبت نام شده است.");
                return;
            }

            if (register.Student.SignedUpIn(sectionItem.Lesson, sectionItem.Section.Period))
            {
                rMessageBox.ShowError("دانشجو قبلا در این درس/سطح ثبت نام شده است و دارای گروه می باشد.");
                return;
            }

            #endregion

            try
            {
                if (mAction == SignupWizardAction.ReserveRegister)
                {
                    Reserve reserve = rGridView2.GetSelectedObject<Reserve>();
                    if (reserve.ReserveList.Section != null && reserve.ReserveList.Section.Id != sectionItem.Section.Id)
                    {
                        rMessageBox.ShowError(
                            string.Format("رزرو این دانشجو در کلاس {0} بوده است. بنابراین امکان ثبت نام در کلاس دیگری وجود ندارد.", reserve.ReserveList.Section));
                        return;
                    }
                }

                rGridViewSectionItems.Insert(sectionItem);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void radPageView1_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            e.Cancel = !mCustomChangeTabs;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            btnNext.Text = "گـــــام بــعــدی";
            GotoPrevStep();
        }

        private void lnkSelectExamFormaion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Core.DomainModel.Exam exam = rGridComboBoxExam.GetValue<Core.DomainModel.Exam>();
            if (exam == null)
            {
                rMessageBox.ShowError("ابتدا آزمون موردنظر را انتخاب کنید.");
                return;
            }

            //            List<Formation> formations = new List<Formation>();
            //            foreach (Formation formation in exam.Formations)
            //                if (exam.GetParticipates(formation).Count() == 0)
            //                    formations.Add(formation);

            frmSelect frm = new frmSelect(exam.ExamHolding.Formations,
                                          new ColumnMapping { Caption = "روز", ObjectProperty = "DayText" },
                                          new ColumnMapping { Caption = "از ساعت", ObjectProperty = "StartTime" },
                                          new ColumnMapping { Caption = "تا ساعت", ObjectProperty = "FinishTime" },
                                          new ColumnMapping { Caption = "مکان", ObjectProperty = "Place.Name" },
                                          new ColumnMapping
                                              {
                                                  Caption = "تعداد ثبت نام شده",
                                                  ObjectProperty = "ExamParticipatesCount",
                                                  TextAlign = HorizontalAlignment.Center
                                              });

            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            Formation selectedExamFormation = frm.GetSelectedObject<Formation>();
            try
            {
                selectedExamFormation.CheckExamCapacity();
                rRadioAutoExamFormation.ToggleState = ToggleState.Off;
                rRadioManualExamFormation.ToggleState = ToggleState.On;
                mSelectedExamFormation = selectedExamFormation;
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void lnkSelectExamForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Core.DomainModel.Exam exam = rGridComboBoxExam.GetValue<Core.DomainModel.Exam>();
            if (exam == null)
            {
                rMessageBox.ShowError("ابتدا آزمون موردنظر را انتخاب کنید.");
                return;
            }

            frmSelect frm = new frmSelect(exam.Forms,
                              new ColumnMapping { Caption = "نام فرم", ObjectProperty = "Name" },
                              new ColumnMapping { Caption = "تعداد ثبت نام شده", ObjectProperty = "Participates.Count", TextAlign = HorizontalAlignment.Center });
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            ExamForm selectedExamForm = frm.GetSelectedObject<ExamForm>();

            try
            {
                selectedExamForm.CheckCapacity();
                rRadioAutoExamForm.ToggleState = ToggleState.Off;
                rRadioManualExamForm.ToggleState = ToggleState.On;
                mSelectedExamForm = selectedExamForm;
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void rGridComboBoxExam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmSignupWizard_Load(object sender, EventArgs e)
        {
            if (mLastActionText != null)
            {
                rRadioButton1.IsChecked = rRadioButton1.Text == mLastActionText;
                rRadioButton2.IsChecked = rRadioButton2.Text == mLastActionText;
                rRadioButton3.IsChecked = rRadioButton3.Text == mLastActionText;
                rRadioButton4.IsChecked = rRadioButton4.Text == mLastActionText;
                rRadioButton5.IsChecked = rRadioButton5.Text == mLastActionText;
            }
        }

        private void rGridComboBoxExamItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            EvaluationItem item = rGridComboBoxExamItems.GetValue<EvaluationItem>();
            if (item == null)
                return;
            rGridComboBoxExam.DataSource = majorSelector1.Major.GetExams(Program.CurrentPeriod, item);
        }

        private void majorSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if (majorSelector1.Major == null)
                return;
            rGridComboBoxExamItems.DataSource = majorSelector1.Major.GetExamEvaluationItems(Program.CurrentPeriod);
        }

        private void rGridViewSectionItems_Delete(object sender, EventArgs e)
        {
            SectionItem item = rGridViewSectionItems.GetSelectedObject<SectionItem>();
            rGridViewSectionItems.RemoveSelectedRow();
        }
        private void departmentSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if (departmentSelector1.Department == null)
                return;
            Program.SetCurrentDepartment(departmentSelector1.Department);
            periodSelector1.Databind(departmentSelector1.Department.EducationalPeriods.OrderByDescending(x => x.Id));
            Program.SetCurrentPeriod(periodSelector1.Period);
            majorSelector2.Databind(departmentSelector1.Department.Majors);
                    
        }

            private void majorSelector2_SelectedChanged(object sender, EventArgs e)
        {
            rGridViewGeneralExams.Clear();
            Major major = majorSelector2.Major;
            if (major == null)
                return;

            IQueryable<ExamTrainingItem> items = major.GetGeneralExamItems(Program.CurrentPeriod);
            rGridViewGeneralExams.DataBind(items);
            rGridViewGeneralExams.CheckAll();

            Register register = studentSearchBox1.SelectedStudent.GetRegister(Program.CurrentPeriod, major);
            rGridViewSectionItems.Clear();
            if(register != null)
            {
                rGridViewSectionItems.DataBind(register.GetParticipatedSectionItems());
            }
        }

        private void lnkAddTuitionDifference_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetProcessingRegister(majorSelector1.Major);
            FinancialItem item = new FinancialItem(FinancialType.Debt) { Heading = FinancialHeading.TuitionDifference, Text = "ما به التفاوت شهریه",Person=Program.CurrentPerson };
            frmFinancialItemDetail frm = new frmFinancialItemDetail(item) { CanEditHeading = false, CanEditType = false };
            if (!frm.ProcessObject())
                return;
            register.FinancialDocument.Items.Add(item);
            UpdateSignupAbstract();
        }

        private void lnkReduceTuitionDefference_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetProcessingRegister(majorSelector1.Major);
            FinancialItem item = new FinancialItem(FinancialType.Credit) { Heading = FinancialHeading.TuitionDifference, Text = "ما به التفاوت شهریه", Person = Program.CurrentPerson };
            frmFinancialItemDetail frm = new frmFinancialItemDetail(item) { CanEditHeading = false, CanEditType = false };
            if (!frm.ProcessObject())
                return;
            register.FinancialDocument.Items.Add(item);
            UpdateSignupAbstract();
        }

        private void rGridViewCommitments_Add(object sender, EventArgs e)
        {
            FinancialCommitment commitment = new FinancialCommitment();
            frmFinancialCommitmentDetail frm = new frmFinancialCommitmentDetail(commitment);
            if (!frm.ProcessObject())
                return;
            rGridViewCommitments.Insert(commitment);
        }

        private void rGridViewCommitments_Edit(object sender, EventArgs e)
        {
            FinancialCommitment commitment = rGridViewCommitments.GetSelectedObject<FinancialCommitment>();
            frmFinancialCommitmentDetail frm = new frmFinancialCommitmentDetail(commitment);
            if (!frm.ProcessObject())
                return;
            rGridViewCommitments.UpdateGridView();
        }

        private void rGridViewCommitments_Delete(object sender, EventArgs e)
        {
            rGridViewCommitments.RemoveSelectedRow();
        }
    }

    public enum SignupWizardAction
    {
        NewRegister,
        ReserveRegister,
        ExamRegister,
        SpecialCaseRegister,
        LevelDeterminationReserve
    }
}
