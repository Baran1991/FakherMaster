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

namespace Fakher.UI.Struture.Protocol
{
    public partial class frmEducationalRuleDetail : rRadDetailForm
    {
        public frmEducationalRuleDetail(EducationalRule rule)
        {
            InitializeComponent();

            rGridComboBoxProtocol.Columns.Add("نام آیین نامه", "نام آیین نامه", "Name");
            
            rGridComboBoxLabel.Columns.Add("نام آیتم", "نام آیتم", "Name");

            rComboBox1.DataSource = typeof (CountOperator).GetEnumDescriptions();
            rComboBox2.DataSource = typeof (RecurrenceType).GetEnumDescriptions();
            rComboBox3.DataSource = typeof(EducationalRuleResult).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping { Control = rGridComboBoxLabel, ControlProperty = "Value", DataObject = rule, ObjectProperty = "ResultLabel"});
            ControlMappings.Add(new ControlMapping { Control = rComboBox1, ControlProperty = "SelectedIndex", DataObject = rule, ObjectProperty = "RecurrenceOperator" });
            ControlMappings.Add(new ControlMapping { Control = rTxtCount, ControlProperty = "Value", DataObject = rule, ObjectProperty = "RecurrenceCount" });
            ControlMappings.Add(new ControlMapping { Control = rComboBox2, ControlProperty = "SelectedIndex", DataObject = rule, ObjectProperty = "RecurrenceType" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Value", DataObject = rule, ObjectProperty = "NextIndex" });
            ControlMappings.Add(new ControlMapping { Control = rTxtDiscount, ControlProperty = "Value", DataObject = rule, ObjectProperty = "DiscountPercent" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Value", DataObject = rule, ObjectProperty = "PenaltyPercent" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox3, ControlProperty = "Value", DataObject = rule, ObjectProperty = "Position" });
            ControlMappings.Add(new ControlMapping { Control = rComboBox3, ControlProperty = "SelectedIndex", DataObject = rule, ObjectProperty = "Result" });

            rGridComboBoxProtocol.DataSource = ResultProtocol.GetProtocols(Program.CurrentPeriod);
            if(rule.ResultLabel != null)
                rGridComboBoxProtocol.Value = rule.ResultLabel.ResultProtocol;
        }

        private void rGridComboBoxProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResultProtocol protocol = rGridComboBoxProtocol.GetValue<ResultProtocol>();
            if(protocol == null)
                return;
            rGridComboBoxLabel.DataSource = protocol.Labels;
        }
    }
}
