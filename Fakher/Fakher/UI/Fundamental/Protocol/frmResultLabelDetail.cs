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
    public partial class frmResultLabelDetail : rRadDetailForm
    {
        public frmResultLabelDetail(ResultLabel label)
        {
            InitializeComponent();

            rComboBox1.DataSource = typeof(CountOperator).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping { Control = radTextBox2, ControlProperty = "Text", DataObject = label, ObjectProperty = "Name"});
            ControlMappings.Add(new ControlMapping { Control = radTextBox1, ControlProperty = "Value", DataObject = label, ObjectProperty = "MinimumValue"});
            ControlMappings.Add(new ControlMapping { Control = radTextBox3, ControlProperty = "Value", DataObject = label, ObjectProperty = "MaximumValue"});
            ControlMappings.Add(new ControlMapping { Control = rComboBox1, ControlProperty = "SelectedIndex", DataObject = label, ObjectProperty = "CountOperator" });
            ControlMappings.Add(new ControlMapping { Control = rTextBoxAbsenceCount, ControlProperty = "Value", DataObject = label, ObjectProperty = "AbsenceCount" });
            ControlMappings.Add(new ControlMapping { Control = rCheckBox1, ControlProperty = "Checked", DataObject = label, ObjectProperty = "HasMarkRule" });
            ControlMappings.Add(new ControlMapping { Control = rCheckBox2, ControlProperty = "Checked", DataObject = label, ObjectProperty = "HasAbsenceRule" });
            ControlMappings.Add(new ControlMapping { Control = rCheckBox3, ControlProperty = "Checked", DataObject = label, ObjectProperty = "HasMandatoryExamRule" });

            rGroupBox1.Enabled = label.HasMarkRule;
            rGroupBox2.Enabled = label.HasAbsenceRule;
        }

        protected override void AfterBindToObject()
        {
            ResultLabel resultLabel = GetProcessingObject<ResultLabel>();

            if(resultLabel.HasMarkRule)
            {
                if(resultLabel.MinimumValue < 0)
                {
                    rMessageBox.ShowError("مقدار نمره شروع باید بزرگتر از صفر باشد.");
                    return;
                }
                if(resultLabel.MaximumValue < 1)
                {
                    rMessageBox.ShowError("مقدار نمره پایان باید بزرگتر از صفر باشد.");
                    return;
                }
            }
            if(resultLabel.HasAbsenceRule)
            {
                if(resultLabel.AbsenceCount <= 0)
                {
                    rMessageBox.ShowError("تعداد غیبت ها باید بزرگتر از صفر باشد.");
                    return;
                }
            }
        }

        private void rCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rGroupBox1.Enabled = rCheckBox1.Checked;
        }

        private void rCheckBox2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rGroupBox2.Enabled = rCheckBox2.Checked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void frmResultLabelDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
