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

namespace Fakher.UI.Educational.Sections
{
    public partial class frmObserveDetail : rRadDetailForm
    {
        public frmObserveDetail(ObserveMark observeMark)
        {
            InitializeComponent();

            rCmbType.DataSource = typeof(ObserveMarkType).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = observeMark, ObjectProperty = "Date" });
            ControlMappings.Add(new ControlMapping { Control = rCmbType, ControlProperty = "SelectedIndex", DataObject = observeMark, ObjectProperty = "Type" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Value", DataObject = observeMark, ObjectProperty = "Mark" });
        }
    }
}
