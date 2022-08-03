using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using NHibernate;
using Telerik.WinControls.Enumerations;
using rComponents;
using System.IO;

namespace Fakher.UI.Reception
{
    public partial class frmBatchSignupWizard : rRadDetailForm
    {
        private static string mLastActionText;
        private BatchSignupWizardAction mAction;
        private bool mCustomChangeTabs;
        private Dictionary<BatchSignupWizardAction, List<int>> steps;

        public frmBatchSignupWizard()
        {
            InitializeComponent();

            steps = new Dictionary<BatchSignupWizardAction, List<int>>();
            steps.Add(BatchSignupWizardAction.LessonRegister, new List<int> { 0, 1, 2, 3 });
            steps.Add(BatchSignupWizardAction.ExamRegister, new List<int> { 0, 1, 2, 3 });

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage1;
            radPageView2.SelectedPage = radPageViewPage5;
            mCustomChangeTabs = false;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });

            rGridCmbTrainingPlan.Columns.Add("نام", "نام", "Name");
            rGridCmbExamItem.Columns.Add("نام", "نام", "Name");

//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "آخرین وضعیت آموزشی", ObjectProperty = "Student.GetCurrentEducationalStatus()" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "Student.GetCurrentFinancialStatus()" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شناسه وب سایت", ObjectProperty = "Student.UserInfo.WebLoginText" });
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

        private void radPageView1_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            e.Cancel = !mCustomChangeTabs;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = examSelector1.Exam;

            try
            {
                if (StepIndex == 0) //Start
                {
                    if (rRadioButton1.ToggleState == ToggleState.On)
                    {
                        mAction = BatchSignupWizardAction.LessonRegister;
                        mLastActionText = rRadioButton1.Text;
                    }
                    if (rRadioButton2.ToggleState == ToggleState.On)
                    {
                        mAction = BatchSignupWizardAction.ExamRegister;
                        mLastActionText = rRadioButton2.Text;
                    }

                    rGroupBoxLesson.Visible = mAction == BatchSignupWizardAction.LessonRegister;
                    rGroupBoxExam.Visible = mAction == BatchSignupWizardAction.ExamRegister;
                }

                if (StepIndex == 1) //Student List
                {
                    if (rGridView1.DataSource.Count == 0)
                    {
                        rMessageBox.ShowError("لیست دانشجویان را برای ثبت نام گروهی مشخص کنید.");
                        return;
                    }
                }

                if (StepIndex == 2) //Destination
                {
                    if (mAction == BatchSignupWizardAction.LessonRegister)
                    {
                        if (lessonSelector2.Lesson == null)
                        {
                            rMessageBox.ShowError("درس/سطح مقصد را انتخاب کنید.");
                            return;
                        }

                        throw new NotImplementedException("این بخش هنوز پیاده سازی نشده است. به مدیر سیستم اطلاع دهید.");
                    }

                    if (mAction == BatchSignupWizardAction.ExamRegister)
                    {
                        if (exam == null)
                        {
                            rMessageBox.ShowError("آزمون را انتخاب کنید.");
                            return;
                        }
                        if (!exam.HasHolding)
                        {
                            rMessageBox.ShowError("این آزمون فاقد برگزاری است. ابتدا برای آن برگزاری ثبت کنید.");
                            return;
                        }

                        ExamForm mSelectedExamForm;
                        Formation mSelectedExamFormation;

                        mSelectedExamForm = exam.GetNextFreeExamForm();
                        if (mSelectedExamForm == null)
                            mSelectedExamForm = exam.GetRandomExamForm();
                        mSelectedExamFormation = exam.ExamHolding.GetRandomFormation();

                        
//                        Stopwatch s = new Stopwatch();
//                        s.Start();
                        ITransaction transaction = null;
                        try
                        {
                            transaction = DbContext.BeginTransaction();

                            foreach (Register register in rGridView1.DataSource)
                            {
                                if (exam.IsSignedUp(register))
                                    continue;

                                ExamParticipate mExamParticipate;

                                if(exam.Type == ExamType.PaperBasedExam)
                                {
                                    mExamParticipate = mSelectedExamForm.Signup(register, null, false, false);
                                    mExamParticipate.Prepare(false); //for paperbased examparticipates
                                }
                                else
                                {
                                    mExamParticipate = mSelectedExamForm.Signup(register, mSelectedExamFormation, false, false);
                                }

                                mExamParticipate.PrepareExamCardForDelivery();
                                mExamParticipate.ConfirmEnrollment();
                                mExamParticipate.SavePartially();
                            }

                            if (exam.Type == ExamType.PaperBasedExam
                                && exam.HasHolding)
                                    exam.ExamHolding.SavePartially();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            rMessageBox.ShowError(ex.Message);
                            return;
                        }
                        
//                        s.Stop();
//                        rMessageBox.ShowInformation(s.Elapsed.ToString());
                    }

                    btnNext.Text = "تـــایــیــد";
                }

                if (StepIndex == 3) //End
                {
                    exam.Save();

                    Close();
                    return;
                }

                GotoNextStep();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            btnNext.Text = "گـــــام بــعــدی";
            GotoPrevStep();
        }

        private void FillGrid1()
        {
            rGridView1.Mappings.Clear();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });
            if(rChkEducationalStatus.Checked)
                rGridView1.Mappings.Add(new ColumnMapping { Caption = "آخرین وضعیت آموزشی", ObjectProperty = "Student.GetCurrentEducationalStatus()" });
            if(rChkFinancialStatus.Checked)
                rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "Student.GetCurrentFinancialStatus()" });
            if(rChkWebLogin.Checked)
                rGridView1.Mappings.Add(new ColumnMapping { Caption = "شناسه وب سایت", ObjectProperty = "Student.UserInfo.WebLoginText" });
        }
        private void radBtnAddFromStructure_Click(object sender, EventArgs e)
        {
            FillGrid1();            

            IEnumerable<Register> registers = new List<Register>();

            if (sectionItemSelector1.SectionItem != null)
            {
                IList<Participate> participates = sectionItemSelector1.SectionItem.GetParticipates();
                registers = participates.GroupBy(x => x.Register).Select(x => x.Key);
            }
            else if (lessonSelector1.Lesson != null)
            {
                IList<Participate> participates = Participate.GetParticipates(Program.CurrentPeriod, lessonSelector1.Lesson);
                registers = participates.GroupBy(x => x.Register).Select(x => x.Key);
            }
            else if (majorSelector1.Major != null)
            {
                registers = Register.GetRegisters(Program.CurrentPeriod, majorSelector1.Major);
            }

            if (rChkSubSet.IsChecked)
            {
                frmSelect frm = new frmSelect(registers, rGridView1.Mappings.ToArray()) { MultiSelect = true };
                if (frm.ShowDialog(this) == DialogResult.OK)
                    registers = frm.GetSelectedObjects<Register>();
                else
                    return;
            }

            foreach (Register register in registers)
                rGridView1.Insert(register);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            rGridView1.RemoveSelectedRow();
        }

        private void lnkSelectFilePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "*.CSV File|*.csv";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;
            rTextBox2.Text = dialog.FileName;
        }

        private void radBtnAddFromFile_Click(object sender, EventArgs e)
        {
            string FilePath = rTextBox2.Text.Trim();
            List<Register> registers = new List<Register>();

            if (string.IsNullOrEmpty(FilePath))
            {
                rMessageBox.ShowWarning("مسیر فایل را انتخاب کنید.");
                return;
            }

            string errors = "";
            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                string[] items = line.Split(';', ',');
                foreach (string code in items)
                {
                    Register register = Register.FromCode(code).FirstOrDefault();
                    if (register == null)
                        errors += code + ", ";
                    else
                    {
                        registers.UniqueAdd(register);
                    }
                }

                if (!string.IsNullOrEmpty(errors))
                    rMessageBox.ShowError("دانشجویی با این شماره ها پیدا نشد؛ " + errors);
            }

            foreach (Register register in registers)
                rGridView1.Insert(register);
        }

        private void majorSelector2_SelectedChanged(object sender, EventArgs e)
        {
            rGridCmbTrainingPlan.Clear();
            if (majorSelector2.Major == null)
                return;
            IList<TrainingPlan> plans = TrainingPlan.GetPlans(Program.CurrentPeriod, majorSelector2.Major);
            rGridCmbTrainingPlan.DataSource = plans;
        }

        private void rGridCmbTrainingPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridCmbExamItem.Clear();
            TrainingPlan plan = rGridCmbTrainingPlan.GetValue<TrainingPlan>();
            if (plan == null)
                return;

            rGridCmbExamItem.DataSource = plan.GetExamItems();
        }

        private void rGridCmbExamItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radBtnAddFromEnrollments_Click(object sender, EventArgs e)
        {
            ExamTrainingItem examTrainingItem = rGridCmbExamItem.GetValue<ExamTrainingItem>();
            if(examTrainingItem == null)
            {
                rMessageBox.ShowError("آزمون را انتخاب کنید.");
                return;
            }
            
            List<Register> registers = examTrainingItem.GetEnrollments().Select(x => x.Register).ToList();
            foreach (Register register in registers)
                rGridView1.Insert(register);
        }
    }

    public enum BatchSignupWizardAction
    {
        LessonRegister,
        ExamRegister,
    }
}
