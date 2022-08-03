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
using Fakher.UI.Educational.Students;
using Fakher.UI.Report;
using rComponents;
using Telerik.WinControls.Enumerations;

namespace Fakher.UI.Reception
{
    public partial class frmTransitionWizard : rRadForm
    {
        private static string mLastActionText;
        private bool mCustomChangeTabs;
        private TransitionWizardAction mAction;
        private Register mRegister;
        private Dictionary<TransitionWizardAction, List<int>> steps;

        private int StepIndex
        {
            get
            {
                return radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            }
        }

        public frmTransitionWizard()
        {
            InitializeComponent();
            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage1;
            mCustomChangeTabs = false;

            steps = new Dictionary<TransitionWizardAction, List<int>>();
            steps.Add(TransitionWizardAction.FullTransition, new List<int> { 0, 1, 3, 5 });
            steps.Add(TransitionWizardAction.LessonTransition, new List<int> { 0, 1, 2, 5 });
            steps.Add(TransitionWizardAction.ReserveTransition, new List<int> { 0, 1, 4, 5 });

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "SectionItem.Lesson.Major.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس", ObjectProperty = "SectionItem.Lesson.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کلاس", ObjectProperty = "SectionItem.Section.Name" });

            rGridComboBox1.Columns.Add("درس", "درس", "SectionItem.Lesson.Name");
            rGridComboBox1.Columns.Add("کلاس", "کلاس", "SectionItem.Section.Name");

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره انتقال", ObjectProperty = "Transition.Id" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ انتقال", ObjectProperty = "Transition.Date" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "درس", ObjectProperty = "SectionItem.Lesson.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "کلاس", ObjectProperty = "SectionItem.Section.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "علت", ObjectProperty = "Transition.Reason" });

            rGridView3.Mappings.Add(new ColumnMapping { Caption = "نام لیست", ObjectProperty = "ReserveList.Name" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "دوره/ترم", ObjectProperty = "ReserveList.Period.Name" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "تاریخ رزرو", ObjectProperty = "ReserveDate" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی رزرو", ObjectProperty = "Status" });

        }

        private Register GetRegister()
        {
            Student student = studentSearchBox1.SelectedStudent;
            List<Register> registers = student.GetRegisters(Program.CurrentPeriod);

            if (registers.Count == 0)
            {
                rMessageBox.ShowError("این دانشجو در این دپارتمان و در این ترم، در هیچ رشته ای ثبت نام نشده است.");
                return null;
            }
            if (registers.Count == 1)
                return registers[0];

            frmSelect frm = new frmSelect(registers, new ColumnMapping { Caption = "رشته های ثبت نامی در این ترم", ObjectProperty = "Major.Name" });
            if (frm.ShowDialog(this) != DialogResult.OK)
                return null;
            return frm.GetSelectedObject<Register>();
        }

        private void radPageView1_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            e.Cancel = !mCustomChangeTabs;
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

        private void GotoFinalStep()
        {
            btnPrev.Enabled = false;
            btnNext.Text = "تـــایــیــد";
            GotoStep(radPageView1.Pages.Count - 1);
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

        private void btnPrev_Click(object sender, EventArgs e)
        {
            GotoPrevStep();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Student student = studentSearchBox1.SelectedStudent;

            if (StepIndex == 0)
            {
                if (rRadioButton1.ToggleState == ToggleState.On)
                {
                    mAction = TransitionWizardAction.FullTransition;
                    mLastActionText = rRadioButton1.Text;
                }
                if (rRadioButton2.ToggleState == ToggleState.On)
                {
                    mAction = TransitionWizardAction.LessonTransition;
                    mLastActionText = rRadioButton2.Text;
                }
                if (rRadioButton3.ToggleState == ToggleState.On)
                {
                    mAction = TransitionWizardAction.ReserveTransition;
                    mLastActionText = rRadioButton3.Text;
                }

                GotoNextStep();
                return;
            }

            if (StepIndex == 1)
            {
                if (studentSearchBox1.SelectedStudent == null)
                {
                    rMessageBox.ShowError("یک دانشجو را مشخص کنید.");
                    return;
                }

                if (mAction == TransitionWizardAction.ReserveTransition)
                {
                    rGridView3.DataBind(student.GetNotRegisteredReserves());
                }
                else
                {
                    mRegister = GetRegister();
                    if (mRegister == null)
                        return;
                    if (mAction == TransitionWizardAction.LessonTransition)
                        rGridComboBox1.DataSource = mRegister.GetParticipates(ParticipateStatus.Participating);
                    if (mAction == TransitionWizardAction.FullTransition)
                        rGridView1.DataBind(mRegister.GetParticipates(ParticipateStatus.Participating));
                }
                GotoNextStep();
                return;
            }

            if (StepIndex == 2) // Lesson Transition
            {
                if(rGridView2.DataSource.Count == 0)
                {
                    rMessageBox.ShowError("برای دانشجو هیچ انتقالی ثبت نشده است.");
                    return;
                }

                GotoFinalStep();
                return;
            }

            if (StepIndex == 3) // Full Transition
            {
                Transition Transition = new Transition();
                frmTransitionDetail frm = new frmTransitionDetail(Transition, mRegister.FinancialDocument);
                if (!frm.ProcessObject())
                    return;

//                Transition.PenaltyFee = mRegister.PayableTuition - Transition.FinancialItem.Amount;
//                if (Transition.PenaltyFee < 0)
//                {
//                    rMessageBox.ShowError("مقدار جریمه انصراف منفی شده است.");
//                    return;
//                }
                Transition.FinancialItem.Text = "بازگشتی جهت انتقال  " + mRegister.ToString();
                Transition.Person = Program.CurrentEmployee;
                
                mRegister.Transition = Transition;
                mRegister.Type = RegisterType.Transmition;

                GotoFinalStep();
                return;
            }

            if (StepIndex == 4) // Reserve Transition
            {
                Reserve reserve = rGridView3.GetSelectedObject<Reserve>();
                if (reserve == null)
                {
                    rMessageBox.ShowError("رزرو دانشجو را انتخاب کنید.");
                    return;
                }

                Transition Transition = new Transition();

                frmTransitionDetail frm = new frmTransitionDetail(Transition, reserve.FinancialDocument);
                if (!frm.ProcessObject())
                    return;
                Transition.PenaltyFee = reserve.FinancialDocument.PayedBalance - Transition.FinancialItem.Amount;
                Transition.FinancialItem.Text = "بازگشتی جهت انصراف رزرو " + reserve.ToString();

                reserve.Transition = Transition;

                GotoFinalStep();
                return;
            }

            if (StepIndex == 5) // Final
            {
                student.Save();

                rptTransitionFirstReceipt rpt = new rptTransitionFirstReceipt();
                rpt.DataSource = new[] { mRegister };
                frmReportViewer frm = new frmReportViewer(rpt) { AutoPrint = true };
                frm.ShowDialog(this);

                Close();
                return;
            }
        }

        private void radBtnLessonTransition_Click(object sender, EventArgs e)
        {
            Participate participate = rGridComboBox1.GetValue<Participate>();
            if (participate.Status != ParticipateStatus.Transitioned)
            {
                Transition Transition = new Transition();
                frmTransitionDetail frm = new frmTransitionDetail(Transition, participate.Register.FinancialDocument);
                if (!frm.ProcessObject())
                    return;
                Transition.PenaltyFee = participate.TuitionFee - Transition.FinancialItem.Amount;
                participate.Transition = Transition;
                rGridView2.Insert(participate);
            }
        }
    }

    public enum TransitionWizardAction
    {
        LessonTransition,
        FullTransition,
        ReserveTransition
    }
}
