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
using rComponents;

namespace Fakher.UI
{
    public partial class frmReceiptDetail : rRadDetailForm
    {
        public frmReceiptDetail(Receipt receipt)
        {
            InitializeComponent();

            ReceiptStatus status = ReceiptStatus.SentToBank;

            if (receipt.Status == status)
                receipt.SendingtoBankDate = PersianDate.Today;

            rComboBoxStatus.DataSource = typeof(ReceiptStatus).GetEnumDescriptions();
            rComboBoxReceiptColleague.DataSource = Employee.GetActiveEmployees();
            rComboBoxSendingToBankName.DataSource = BankAccount.GetBankName();

            rGridCmbBankAccounts.Columns.Add("بانک", "بانک", "BankName");
            rGridCmbBankAccounts.Columns.Add("شعبه", "شعبه", "Branch");
            rGridCmbBankAccounts.DataSource = DbContext.GetAllEntities<BankAccount>();

            if (receipt.Item.BankAccount == null)
                rGridCmbBankAccounts.Value = Program.CurrentPeriod.ReceiptBankAccount;

            //if (rComboBoxStatus.SelectedIndex == 4)
            //{
            //    rLabel6.Visible = true;
            //    rComboBoxReceiptColleague.Visible = true;
            //}

            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = receipt, ObjectProperty = "Date" });
            ControlMappings.Add(new ControlMapping { Control = radTextBox1, ControlProperty = "Value", DataObject = receipt, ObjectProperty = "Amount", ConvertNeeded = true});
            ControlMappings.Add(new ControlMapping { Control = radTextBox2, ControlProperty = "Text", DataObject = receipt, ObjectProperty = "ReceiptNumber" });
//            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = receipt, ObjectProperty = "BankName" });
            ControlMappings.Add(new ControlMapping { Control = rGridCmbBankAccounts, ControlProperty = "Value", DataObject = receipt, ObjectProperty = "Item.BankAccount" });
            ControlMappings.Add(new ControlMapping { Control = rComboBoxStatus, ControlProperty = "SelectedIndex", DataObject = receipt, ObjectProperty = "Status" });
            ControlMappings.Add(new ControlMapping { Control = rComboBoxSendingToBankName, ControlProperty = "SelectedValue", DataObject = receipt, ObjectProperty = "SendingtoBankName" });
            ControlMappings.Add(new ControlMapping { Control = rComboBoxReceiptColleague, ControlProperty = "SelectedValue", DataObject = receipt, ObjectProperty = "employee" });

        }

        private void rComboBoxStatus_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (rComboBoxStatus.SelectedIndex == 1)
            {
                rComboBoxSendingToBankName.Visible = true;
                rLabel7.Visible = true;
            }
            else
            {
                rComboBoxSendingToBankName.Visible = false;
                rLabel7.Visible = false;
            }
        }
    }
}
