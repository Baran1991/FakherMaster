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
using Fakher.UI.Financial;
using Fakher.UI.Report;
using rComponents;
using Telerik.WinControls.Enumerations;

namespace Fakher.UI.Reception
{
    public partial class frmRegisterFinancialWizard : rRadForm
    {
//        private static string mLastActionText;
        private bool mCustomChangeTabs;
//        private RegisterFinancialWizardAction mAction;
        private Register mRegister;

        private int StepIndex
        {
            get
            {
                return radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            }
        }

        public frmRegisterFinancialWizard(Register register)
        {
            InitializeComponent();

            mRegister = register;

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage1;
            mCustomChangeTabs = false;

            rDatePicker1.Date = PersianDate.Today;
            rCmbHeading.DataSource = typeof(FinancialHeading).GetEnumDescriptions(); 
            rCmbFinancialType.DataSource = typeof(FinancialType).GetEnumDescriptions();
        }

        private void radPageView1_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            e.Cancel = !mCustomChangeTabs;
        }

        private void GotoPrevStep()
        {
            mCustomChangeTabs = true;
            if (StepIndex > 0)
                GotoStep(StepIndex - 1);
            mCustomChangeTabs = false;
        }

        private void GotoNextStep()
        {
            mCustomChangeTabs = true;
            if (StepIndex < radPageView1.Pages.Count - 1)
                GotoStep(StepIndex + 1);
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
            btnNext.Text = "تـــایــیــد";
            GotoStep(radPageView1.Pages.Count - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (StepIndex == 0)
            {
//                if (rRadioButton1.ToggleState == ToggleState.On)
//                {
//                    mAction = RegisterFinancialWizardAction.DebtAndPay;
//                    mLastActionText = rRadioButton1.Text;
//                    GotoStep(2);
//                }
//                if (rRadioButton2.ToggleState == ToggleState.On)
//                {
//                    mAction = RegisterFinancialWizardAction.DebtOnly;
//                    mLastActionText = rRadioButton2.Text;
//                    GotoStep(2);
//                }
//                if (rRadioButton3.ToggleState == ToggleState.On)
//                {
//                    mAction = RegisterFinancialWizardAction.TuitionDefference;
//                    mLastActionText = rRadioButton3.Text;
//                    UpdateSignupAbstract();
//                    GotoStep(1);
//                }
                GotoNextStep();
                return;
            }

            if (StepIndex == 1)
            {
                if(rDatePicker1.Date == null)
                {
                    rMessageBox.ShowError("تاریخ را مشخص کنید.");
                    return;
                }
                if(rTextBox1.GetValue<long>() <= 0)
                {
                    rMessageBox.ShowError("مقدار مبلغ باید بزرگتر از صفر باشد.");
                    return;
                }

//                if (mAction == RegisterFinancialWizardAction.DebtOnly)
//                    GotoFinalStep();
//                else
                    GotoNextStep();
                return;
            }

            if (StepIndex == 2)
            {
                if (paymentControl1.DataSource.Count == 0)
                {
                    if (rMessageBox.ShowQuestion("اطلاعات مالی این دانشجو وارد نشده است. آیا مایل به ذخیره بدون اطلاعات مالی هستید ؟") != DialogResult.Yes)
                        return;
                }

                GotoNextStep();
            }

            //if (StepIndex == 3) // Final
            //{
            //    FinancialHeading heading = (FinancialHeading) rCmbHeading.SelectedIndex;
            //    FinancialType type = (FinancialType)rCmbFinancialType.SelectedIndex;
            //    FinancialItem newItem = new FinancialItem { Type = type,Person=Program.CurrentPerson };
            //    newItem.Heading = heading;
            //    newItem.Date = rDatePicker1.Date;
            //    newItem.Amount = rTextBox1.GetValue<long>();
            //    newItem.OnAcountOf = rTextBox2.Text;
            //    mRegister.FinancialDocument.Items.Add(newItem);
            //    rptFaStudentFinancialReciept rpt = new rptFaStudentFinancialReciept();
            //    rpt.register = mRegister;
            //    rpt.student = mRegister.Student;
            //    rpt.Date = rDatePicker1.Date;
            //    rpt.fItems = new List<FinancialItem>();

            //    rpt.ReportName ="رسید "+ heading.ToDescription();
            //    foreach (FinancialItem item in paymentControl1.DataSource)
            //    {
            //        item.Heading = heading;
            //        item.Person= Program.CurrentPerson;

            //        mRegister.FinancialDocument.Items.Add(item); 
            //        rpt.fItems.Add(item);
            //    }

            //    mRegister.Save();
            //    GotoFinalStep();

            //    rpt.PrepareDataset(null);
            //    rpt.Apply(null);
            //    frmReportViewer frm = new frmReportViewer(rpt);
            //    frm.ShowDialog(this);
            //    Close();
            //    return;
            //}
            if (StepIndex == 3) // Final
            {
                FinancialHeading heading = (FinancialHeading)rCmbHeading.SelectedIndex;
                FinancialType type = (FinancialType)rCmbFinancialType.SelectedIndex;
                rptFaStudentFinancialReciept rpt = new rptFaStudentFinancialReciept();               
                rpt.register = mRegister;
                rpt.student = mRegister.Student;
                rpt.Date = rDatePicker1.Date;
                rpt.fItems = new List<FinancialItem>();
                rpt.ReportName = "رسید " + heading.ToDescription();
                
                if(rCmbHeading.SelectedIndex==1 )
                {
                    if(rCmbFinancialType.SelectedIndex == 0)
                    {
                        try
                        {
                            FinancialItem item = new FinancialItem(FinancialType.Debt) { Heading = FinancialHeading.TuitionDifference, Text = "ما به التفاوت شهریه", Person = Program.CurrentPerson };
                            mRegister.FinancialDocument.Items.Add(item);
                            item.Heading = heading;
                            item.Person = Program.CurrentPerson;
                            item.RegisterDocumentDate = rDatePicker1.Date;
                            item.Amount = rTextBox1.GetValue<long>();
                            item.OnAcountOf = rTextBox2.Text;
                            rpt.fItems.Add(item);
                        }
                        catch (Exception ex)
                        {
                        
                        }
                    }
                    else if (rCmbFinancialType.SelectedIndex == 1)
                    {
                        try
                        {
                            FinancialItem item = new FinancialItem(FinancialType.Credit) { Heading = FinancialHeading.TuitionDifference, Text = "ما به التفاوت شهریه", Person = Program.CurrentPerson };
                            mRegister.FinancialDocument.Items.Add(item);
                            item.Heading = heading;
                            item.Person = Program.CurrentPerson;
                            item.RegisterDocumentDate = rDatePicker1.Date;
                            item.Amount = rTextBox1.GetValue<long>();
                            item.OnAcountOf = rTextBox2.Text;
                            rpt.fItems.Add(item);
                        }
                        catch (Exception ex)
                        {

                        }
                    }                  
                }
                else
                    foreach (FinancialItem item in paymentControl1.DataSource)
                    {
                        item.Heading = heading;
                        item.Person = Program.CurrentPerson;
                        item.RegisterDocumentDate = rDatePicker1.Date;
                        item.Amount = rTextBox1.GetValue<long>();
                        item.OnAcountOf = rTextBox2.Text;

                        mRegister.FinancialDocument.Items.Add(item);
                        rpt.fItems.Add(item);
                    }


                mRegister.Save();
                GotoFinalStep();

                rpt.PrepareDataset(null);
                rpt.Apply(null);
                frmReportViewer frm = new frmReportViewer(rpt);
                frm.ShowDialog(this);
                Close();
                return;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            GotoPrevStep();
        }

//        private void UpdateSignupAbstract()
//        {
//            FinancialEntity financialEntity = mRegister;
//
//            rLblTuitionFee.Text = financialEntity.PayableTuition.ToString("C0");
//            rLblTuitionDifferent.Text = financialEntity.TuitionDifference.ToString("C0");
//            rLblTotalTuitionFee.Text = financialEntity.EffectivePayableTuition.ToString("C0");
//
//            rLblPayedBalance.Text = financialEntity.FinancialDocument.PayedBalance.ToString("C0");
//            rLblDiscountBalance.Text = financialEntity.FinancialDocument.DiscountBalance.ToString("C0");
//
//            rLblFinancialStatus.Text = "وضعیت مالی: " + financialEntity.FarsiFinancialStatusVerboseText;
//        }
//
//        private void toolStripBtnAddTuitionDifference_Click(object sender, EventArgs e)
//        {
//            FinancialItem item = new FinancialItem(FinancialType.Debt) { Heading = FinancialHeading.TuitionDifference, Text = "ما به التفاوت شهریه" };
//            frmFinancialItemDetail frm = new frmFinancialItemDetail(item) { CanEditHeading = false, CanEditType = false };
//            if (!frm.ProcessObject())
//                return;
//            mRegister.FinancialDocument.Items.Add(item);
//            UpdateSignupAbstract();
//        }
//
//        private void toolStripBtnReduceTuitionDefference_Click(object sender, EventArgs e)
//        {
//            FinancialItem item = new FinancialItem(FinancialType.Credit) { Heading = FinancialHeading.TuitionDifference, Text = "ما به التفاوت شهریه" };
//            frmFinancialItemDetail frm = new frmFinancialItemDetail(item) { CanEditHeading = false, CanEditType = false };
//            if (!frm.ProcessObject())
//                return;
//            mRegister.FinancialDocument.Items.Add(item);
//            UpdateSignupAbstract();
//        }
    }

    public enum RegisterFinancialWizardAction
    {
        TuitionDefference,
        DebtAndPay,
        DebtOnly
    }
}
