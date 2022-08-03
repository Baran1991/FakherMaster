using System;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Educational.Students
{
    public partial class frmQuitDetail : rRadDetailForm
    {
        private long payedAmount;

        public frmQuitDetail(Quit quit, FinancialDocument document)
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;

            rCmbStatus.DataSource = typeof (QuitStatus).GetEnumDescriptions();

            rGridCmbBankAccounts.Columns.Add("بانک", "بانک", "BankName");
            rGridCmbBankAccounts.Columns.Add("شعبه", "شعبه", "Branch");
            rGridCmbBankAccounts.DataSource = DbContext.GetAllEntities<BankAccount>();

            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = quit, ObjectProperty = "Date"});
            ControlMappings.Add(new ControlMapping { Control = rDatePicker4, ControlProperty = "Date", DataObject = quit, ObjectProperty = "RefundDate" });

            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = quit, ObjectProperty = "Reason" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Value", DataObject = quit, ObjectProperty = "FinancialItem.Amount" });
            ControlMappings.Add(new ControlMapping { Control = rCheckBox1, ControlProperty = "Checked", DataObject = quit, ObjectProperty = "ReturnByCheque" });
            ControlMappings.Add(new ControlMapping { Control = rCheckBox2, ControlProperty = "Checked", DataObject = quit, ObjectProperty = "ReturnByEpayment" });
//            ControlMappings.Add(new ControlMapping { Control = rDatePicker2, ControlProperty = "Date", DataObject = quit, ObjectProperty = "FinancialItem.Date" });
//            ControlMappings.Add(new ControlMapping { Control = rTextBox3, ControlProperty = "Value", DataObject = quit, ObjectProperty = "FinancialItem.Payment.ChequeNumber" });
//            ControlMappings.Add(new ControlMapping { Control = rTextBox4, ControlProperty = "Value", DataObject = quit, ObjectProperty = "FinancialItem.Payment.BankName" });
//            ControlMappings.Add(new ControlMapping { Control = rTextBox5, ControlProperty = "Value", DataObject = quit, ObjectProperty = "FinancialItem.Payment.BankBranch" });
            ControlMappings.Add(new ControlMapping { Control = rCmbStatus, ControlProperty = "SelectedIndex", DataObject = quit, ObjectProperty = "Status" });

            if(quit.ReturnByCheque)
            {
                Cheque cheque = quit.FinancialItem.Payment as Cheque;
                if (cheque != null)
                {
                    rTextBox3.Text = cheque.ChequeNumber;
                    rDatePicker2.Date = cheque.Date;
                }
            }
            if(quit.ReturnByEpayment)
            {
                ElectronicPayment payment = quit.FinancialItem.Payment as ElectronicPayment;
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
            Quit quit = GetProcessingObject<Quit>();
            if(rCheckBox1.Checked)
            {
                if(quit.FinancialItem.Payment == null)
                {
                    quit.FinancialItem.Payment = new Cheque();
                }
            }
        }

        protected override void AfterBindToObject()
        {
            Quit quit = GetProcessingObject<Quit>();
            quit.PenaltyFee = payedAmount - quit.FinancialItem.Amount;
            if (quit.PenaltyFee < 0)
            {
                rMessageBox.ShowError("مقدار جریمه انصراف منفی شده است.");
                CancelClosing();
                return;
            }

            if (quit.ReturnByCheque)
            {
                if (quit.FinancialItem.Payment == null)
                {
                    quit.FinancialItem.Payment = new Cheque();
                    quit.FinancialItem.Mode = FinancialItemMode.Issued;
                }

                Cheque cheque = quit.FinancialItem.Payment as Cheque;
                cheque.ChequeNumber = rTextBox3.Text.Trim();
                cheque.Date = rDatePicker2.Date;
            }
            if (quit.ReturnByEpayment)
            {
                if (quit.FinancialItem.Payment == null)
                {
                    quit.FinancialItem.Payment = new ElectronicPayment();
                    quit.FinancialItem.Mode = FinancialItemMode.Issued;
                }

                ElectronicPayment payment = quit.FinancialItem.Payment as ElectronicPayment;
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
    }
}
