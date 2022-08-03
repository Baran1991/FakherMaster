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
    public partial class frmCashDetail : rRadDetailForm
    {
        public frmCashDetail(Cash cash)
        {
            InitializeComponent();
            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = cash, ObjectProperty = "Date" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Value", DataObject = cash, ObjectProperty = "InternalDocumentNumber", ConvertNeeded = true});
            ControlMappings.Add(new ControlMapping { Control = radTextBox1, ControlProperty = "Value", DataObject = cash, ObjectProperty = "Amount", ConvertNeeded = true});
        }
    }
}
