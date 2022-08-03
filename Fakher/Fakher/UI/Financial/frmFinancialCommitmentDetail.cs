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
    public partial class frmFinancialCommitmentDetail : rRadDetailForm
    {
        public frmFinancialCommitmentDetail(FinancialCommitment commitment)
        {
            InitializeComponent();
            SetProcessingObject(commitment);

            rCmbType.DataSource = typeof (FinancialCommitmentType).GetEnumDescriptions();
            rCmbStatus.DataSource = typeof (FinancialCommitmentStatus).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = commitment, ObjectProperty = "Date" });
            ControlMappings.Add(new ControlMapping { Control = rCmbType, ControlProperty = "SelectedIndex", DataObject = commitment, ObjectProperty = "Type" });
            ControlMappings.Add(new ControlMapping { Control = radTextBox1, ControlProperty = "Value", DataObject = commitment, ObjectProperty = "Amount" });
            ControlMappings.Add(new ControlMapping { Control = rCmbStatus, ControlProperty = "SelectedIndex", DataObject = commitment, ObjectProperty = "Status" });
            ControlMappings.Add(new ControlMapping { Control = rDatePicker2, ControlProperty = "Date", DataObject = commitment, ObjectProperty = "PayOffDate" });
        }
    }
}
