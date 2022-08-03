using System;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Educational.Students
{
    public partial class frmTransitionDetail : rRadDetailForm
    {
        private long payedAmount;
        private Transition mTransition;
        public frmTransitionDetail(Transition Transition, FinancialDocument document)
        {
            InitializeComponent();
            mTransition = Transition;
            radPageView1.SelectedPage = radPageViewPage1;

            rCmbStatus.DataSource = typeof (TransitionStatus).GetEnumDescriptions();

            rGridCmbBankAccounts.Columns.Add("بانک", "بانک", "BankName");
            rGridCmbBankAccounts.Columns.Add("شعبه", "شعبه", "Branch");
            rGridCmbBankAccounts.DataSource = DbContext.GetAllEntities<BankAccount>();
            rcmbBranch.Columns.Add("نام", "نام", "Name");
            rcmbBranch.DataSource = DbContext.GetAllEntities<Branch>();
            //Transition.Branch = rcmbBranch.GetValue<Branch>();
            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = Transition, ObjectProperty = "Date"});
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = Transition, ObjectProperty = "Reason" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Value", DataObject = Transition, ObjectProperty = "FinancialItem.Amount" });
            ControlMappings.Add(new ControlMapping { Control = rCheckBox1, ControlProperty = "Checked", DataObject = Transition, ObjectProperty = "ReturnByCheque" });
            ControlMappings.Add(new ControlMapping { Control = rCheckBox2, ControlProperty = "Checked", DataObject = Transition, ObjectProperty = "ReturnByEpayment" });
//            ControlMappings.Add(new ControlMapping { Control = rDatePicker2, ControlProperty = "Date", DataObject = Transition, ObjectProperty = "FinancialItem.Date" });
//            ControlMappings.Add(new ControlMapping { Control = rTextBox3, ControlProperty = "Value", DataObject = Transition, ObjectProperty = "FinancialItem.Payment.ChequeNumber" });
//            ControlMappings.Add(new ControlMapping { Control = rTextBox4, ControlProperty = "Value", DataObject = Transition, ObjectProperty = "FinancialItem.Payment.BankName" });
//            ControlMappings.Add(new ControlMapping { Control = rTextBox5, ControlProperty = "Value", DataObject = Transition, ObjectProperty = "FinancialItem.Payment.BankBranch" });
            ControlMappings.Add(new ControlMapping { Control = rCmbStatus, ControlProperty = "SelectedIndex", DataObject = Transition, ObjectProperty = "Status" });
            //ControlMappings.Add(new ControlMapping { Control = rcmbBranch, ControlProperty = "SelectedIndex", DataObject = Transition, ObjectProperty = "Branch.Id" });

            if (Transition.ReturnByCheque)
            {
                Cheque cheque = Transition.FinancialItem.Payment as Cheque;
                if (cheque != null)
                {
                    rTextBox3.Text = cheque.ChequeNumber;
                    rDatePicker2.Date = cheque.Date;
                }
            }
            if(Transition.ReturnByEpayment)
            {
                ElectronicPayment payment = Transition.FinancialItem.Payment as ElectronicPayment;
                if (payment != null)
                {
                    rTextBox4.Text = payment.CardNumber;
                    rDatePicker3.Date = payment.Date;
                }
            }

            payedAmount = document.PayedBalance;
            rLblTuition.Text = payedAmount.ToString("C0");
            financialDocumentView1.Databind(document);
        }

        protected override void AfterValidate()
        {
            if(rTextBox2.GetValue<int>() > payedAmount)
            {
                rMessageBox.ShowError("مبلغ قابل بازگشت نامعتبر است.");
                CancelClosing();
                return;
            }
        }

        #region Overrides of rRadDetailForm

        protected override void BeforeBindToObject()
        {
            Transition Transition = GetProcessingObject<Transition>();
            if(rCheckBox1.Checked)
            {
                if(Transition.FinancialItem.Payment == null)
                {
                    Transition.FinancialItem.Payment = new Cheque();
                }
            }
        }

        protected override void AfterBindToObject()
        {
            Transition Transition = GetProcessingObject<Transition>();
            Transition.PenaltyFee = payedAmount - Transition.FinancialItem.Amount;
            if (Transition.PenaltyFee < 0)
            {
                rMessageBox.ShowError("مقدار جریمه انتقال منفی شده است.");
                CancelClosing();
                return;
            }

            if (Transition.ReturnByCheque)
            {
                if (Transition.FinancialItem.Payment == null)
                {
                    Transition.FinancialItem.Payment = new Cheque();
                    Transition.FinancialItem.Mode = FinancialItemMode.Issued;
                }

                Cheque cheque = Transition.FinancialItem.Payment as Cheque;
                cheque.ChequeNumber = rTextBox3.Text.Trim();
                cheque.Date = rDatePicker2.Date;
            }
            if (Transition.ReturnByEpayment)
            {
                if (Transition.FinancialItem.Payment == null)
                {
                    Transition.FinancialItem.Payment = new ElectronicPayment();
                    Transition.FinancialItem.Mode = FinancialItemMode.Issued;
                }

                ElectronicPayment payment = Transition.FinancialItem.Payment as ElectronicPayment;
                payment.CardNumber = rTextBox4.Text.Trim();
                payment.Date = rDatePicker3.Date;
            }
        }

        #endregion

        private void rCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rGroupBox4.Enabled = rCheckBox1.Checked;
        }

        private void financialDocumentView1_Edit(object sender, EventArgs e)
        {
            FinancialItem financialItem = financialDocumentView1.GetSelectedItem();
            if(financialItem.IsPaying && financialItem.Payment is Cheque)
            {
                frmChequeDetail frm = new frmChequeDetail(financialItem.Payment as Cheque);
                frm.ShowDialog(this);
            }
            else
            {
                rMessageBox.ShowWarning("فقط چک ها قابل ویرایش (بازگشت به دانشجو) هستند");
                return;
            }
        }

        private void rCheckBox2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rGroupBox5.Enabled = rCheckBox2.Checked;
        }

        private void rcmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Transition Transition = GetProcessingObject<Transition>();
            mTransition.Branch = rcmbBranch.GetValue<Branch>();
            SetProcessingObject(mTransition);
        }
    }
}
