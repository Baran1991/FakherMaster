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
    public partial class frmDiscountDetail : rRadDetailForm
    {
        public frmDiscountDetail(Discount discount)
        {
            InitializeComponent();

            ControlMappings.Add(new ControlMapping{ Control = rTextBox1, ControlProperty = "Text", DataObject = discount, ObjectProperty = "Title"});
            ControlMappings.Add(new ControlMapping{ Control = rTextBox2, ControlProperty = "Value", DataObject = discount, ObjectProperty = "Amount", ConvertNeeded = true});
        }
    }
}
