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
    public partial class frmBankAccountDetail : rRadDetailForm
    {
        public frmBankAccountDetail(BankAccount bankAccount)
        {
            InitializeComponent();
            SetProcessingObject(bankAccount);

            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = bankAccount, ObjectProperty = "BankName" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Text", DataObject = bankAccount, ObjectProperty = "Branch" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox3, ControlProperty = "Text", DataObject = bankAccount, ObjectProperty = "AccountNumber" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox4, ControlProperty = "Value", DataObject = bankAccount, ObjectProperty = "InitialBalance" });
            ControlMappings.Add(new ControlMapping { Control = rCheckBox1, ControlProperty = "Checked", DataObject = bankAccount, ObjectProperty = "HasPOS" });
        }
    }
}
