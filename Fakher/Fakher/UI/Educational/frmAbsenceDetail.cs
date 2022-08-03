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

namespace Fakher.UI.Educational.Common
{
    public partial class frmAbsenceDetail : rRadDetailForm
    {
        public frmAbsenceDetail(Absence absence)
        {
            InitializeComponent();

            rComboBox1.DataSource = typeof (AbsenceStatus).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = absence, ObjectProperty = "Date"});
            ControlMappings.Add(new ControlMapping{Control = rTextBox1, ControlProperty = "Text", DataObject = absence, ObjectProperty = "Reason"});
            ControlMappings.Add(new ControlMapping { Control = rComboBox1, ControlProperty = "SelectedIndex", DataObject = absence, ObjectProperty = "Status" });
        }
    }
}
