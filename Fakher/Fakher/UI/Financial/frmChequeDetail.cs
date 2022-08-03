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
    public partial class frmChequeDetail : rRadDetailForm
    {
        public frmChequeDetail(Cheque cheque)
        {
            InitializeComponent();

            rComboBoxStatus.DataSource = typeof (ChequeStatus).GetEnumDescriptions();
            rComboBoxRecipientColleague.DataSource = Employee.GetActiveEmployees();
            rComboBoxSendingToBankName.DataSource=BankAccount.GetBankName();
            
            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = cheque, ObjectProperty = "Date" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Value", DataObject = cheque, ObjectProperty = "Amount", ConvertNeeded = true });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Text", DataObject = cheque, ObjectProperty = "ChequeNumber" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox3, ControlProperty = "Text", DataObject = cheque, ObjectProperty = "BankName" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox4, ControlProperty = "Text", DataObject = cheque, ObjectProperty = "BankBranch" });
            ControlMappings.Add(new ControlMapping { Control = rComboBoxStatus, ControlProperty = "SelectedIndex", DataObject = cheque, ObjectProperty = "Status"});
            ControlMappings.Add(new ControlMapping { Control = rComboBoxSendingToBankName, ControlProperty = "SelectedValue", DataObject = cheque, ObjectProperty = "SendingtoBankName" });
            ControlMappings.Add(new ControlMapping { Control = rDatePicker2, ControlProperty = "Date", DataObject = cheque, ObjectProperty = "CreateDate" });
            ControlMappings.Add(new ControlMapping { Control = rComboBoxRecipientColleague, ControlProperty = "SelectedValue", DataObject = cheque, ObjectProperty = "employee" });
        }

        private void rComboBoxStatus_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (rComboBoxStatus.SelectedIndex == 5)
            {
                rComboBoxSendingToBankName.Visible = true;
                rLabel9.Visible = true;
            }
            else
            {
                rComboBoxSendingToBankName.Visible = false;
                rLabel9.Visible = false;
            }
        }
    }
}
