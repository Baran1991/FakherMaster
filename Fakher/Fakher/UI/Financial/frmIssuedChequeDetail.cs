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

namespace Fakher.UI
{
    public partial class frmIssuedChequeDetail : rRadDetailForm
    {
        public frmIssuedChequeDetail(Cheque cheque)
        {
            InitializeComponent();
            SetProcessingObject(cheque);

            rGridCmbChequeBook.Columns.Add("ابتدا", "ابتدا", "StartNumber");
            rGridCmbChequeBook.Columns.Add("انتها", "انتها", "EndNumber");
            rGridCmbChequeBook.DataSource = cheque.Item.BankAccount.GetChequeBooks();

            rComboBoxStatus.DataSource = typeof (ChequeStatus).GetEnumDescriptions();
            rCmbHeading.DataSource = typeof (FinancialHeading).GetEnumDescriptions();
            
            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = cheque, ObjectProperty = "Date" });
            ControlMappings.Add(new ControlMapping { Control = rGridCmbChequeBook, ControlProperty = "Value", DataObject = cheque, ObjectProperty = "ChequeBook" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Text", DataObject = cheque, ObjectProperty = "ChequeNumber" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Value", DataObject = cheque, ObjectProperty = "Amount", ConvertNeeded = true });
            ControlMappings.Add(new ControlMapping { Control = rTextBox3, ControlProperty = "Text", DataObject = cheque, ObjectProperty = "OrderOf" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox4, ControlProperty = "Text", DataObject = cheque, ObjectProperty = "Payee" });
            ControlMappings.Add(new ControlMapping { Control = rComboBoxStatus, ControlProperty = "SelectedIndex", DataObject = cheque, ObjectProperty = "Status"});
            ControlMappings.Add(new ControlMapping { Control = rCmbHeading, ControlProperty = "SelectedIndex", DataObject = cheque, ObjectProperty = "Item.Heading" });
        }

        protected override void AfterBindToObject()
        {
            Cheque cheque = GetProcessingObject<Cheque>();
            cheque.Item.Mode = FinancialItemMode.Issued;
            cheque.Item.Text = cheque.OrderOf;
        }
    }
}
