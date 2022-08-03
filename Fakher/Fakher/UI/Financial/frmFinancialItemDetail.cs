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

namespace Fakher.UI.Financial
{
    public partial class frmFinancialItemDetail : rRadDetailForm
    {
        public bool CanEditDate { get; set; }
        public bool CanEditHeading { get; set; }
        public bool CanEditType { get; set; }

        public frmFinancialItemDetail(FinancialItem item)
        {
            InitializeComponent();
            
            rCmbHeading.DataSource = typeof (FinancialHeading).GetEnumDescriptions();
            rCmbType.DataSource = typeof (FinancialType).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = item, ObjectProperty = "Date" });
            ControlMappings.Add(new ControlMapping { Control = rCmbHeading, ControlProperty = "SelectedIndex", DataObject = item, ObjectProperty = "Heading" });
            ControlMappings.Add(new ControlMapping { Control = radTextBox1, ControlProperty = "Value", DataObject = item, ObjectProperty = "Amount" });
            ControlMappings.Add(new ControlMapping { Control = rCmbType, ControlProperty = "SelectedIndex", DataObject = item, ObjectProperty = "Type" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = item, ObjectProperty = "Text" });

            CanEditDate = true;
            CanEditHeading = true;
            CanEditType = true;
        }

        private void frmFinancialItemDetail_Load(object sender, EventArgs e)
        {
            rDatePicker1.Enabled = CanEditDate;
            rCmbHeading.Enabled = CanEditHeading;
            rCmbType.Enabled = CanEditType;
        }
    }
}
