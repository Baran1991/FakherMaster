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

namespace Fakher.UI.SystemFeatures
{
    public partial class frmAccessTagDetail : rRadDetailForm
    {
        public frmAccessTagDetail(AccessTag accessTag)
        {
            InitializeComponent();

            rComboBox3.DataSource = typeof(AccessTagType).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping { Control = rComboBox3, ControlProperty = "SelectedIndex", DataObject = accessTag, ObjectProperty = "Type" });
            ControlMappings.Add(new ControlMapping { Control = rCheckBox1, ControlProperty = "IsChecked", DataObject = accessTag, ObjectProperty = "HasPassword" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = accessTag, ObjectProperty = "Password" });

            rTextBox1.Enabled = accessTag.HasPassword;
        }

        private void rCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rTextBox1.Enabled = rCheckBox1.IsChecked;
        }
    }
}
