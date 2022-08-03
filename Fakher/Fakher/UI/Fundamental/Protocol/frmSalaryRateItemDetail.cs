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
using Telerik.WinControls.Enumerations;

namespace Fakher.UI.Fundamental.Protocol
{
    public partial class frmSalaryRateItemDetail : rRadDetailForm
    {
        public frmSalaryRateItemDetail(SalaryRateItem salaryRateItem)
        {
            InitializeComponent();

            rCmbItem.DataSource = typeof(SalaryCondition).GetEnumDescriptions();
            rCmbOperator.DataSource = typeof (SalaryRateItemOperator).GetEnumDescriptions();
            rCmbDegree.DataSource = typeof(EducationalDegree).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Value", DataObject = salaryRateItem, ObjectProperty = "Minimum" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Value", DataObject = salaryRateItem, ObjectProperty = "Maximum" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox3, ControlProperty = "Value", DataObject = salaryRateItem, ObjectProperty = "Amount" });
            ControlMappings.Add(new ControlMapping { Control = rCmbItem, ControlProperty = "SelectedIndex", DataObject = salaryRateItem, ObjectProperty = "SalaryCondition" });
            ControlMappings.Add(new ControlMapping { Control = rCmbOperator, ControlProperty = "SelectedIndex", DataObject = salaryRateItem, ObjectProperty = "Operator" });
            ControlMappings.Add(new ControlMapping { Control = rCmbDegree, ControlProperty = "SelectedIndex", DataObject = salaryRateItem, ObjectProperty = "EducationalDegree" });
            ControlMappings.Add(new ControlMapping { Control = rCheckBox1, ControlProperty = "Checked", DataObject = salaryRateItem, ObjectProperty = "IsInSectionWage" });
            ControlMappings.Add(new ControlMapping { Control = rCheckBox2, ControlProperty = "Checked", DataObject = salaryRateItem, ObjectProperty = "IsInReplacementWage" });

            UpdateControls(salaryRateItem.SalaryCondition);
        }

        #region Overrides of rRadDetailForm

        protected override void AfterBindToObject()
        {
//            SalaryRateItem item = GetProcessingObject<SalaryRateItem>();
//            SalaryCondition condition = (SalaryCondition)rCmbItem.SelectedIndex;
//            LastEducationalDegree degree = (LastEducationalDegree) rCmbDegree.SelectedIndex;
        }

        #endregion

        private void rCmbItem_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            SalaryCondition condition = (SalaryCondition) rCmbItem.SelectedIndex;
            UpdateControls(condition);
        }

        private void UpdateControls(SalaryCondition condition)
        {
            rCmbDegree.Enabled = condition == SalaryCondition.LastDegree;
            rTextBox1.Enabled =
                rTextBox2.Enabled =
                (condition != SalaryCondition.IeltsToefleDegree && condition != SalaryCondition.LastDegree);
        }

        private void rCmbOperator_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            rTextBox2.Enabled = rCmbOperator.SelectedIndex != 2;
        }
    }
}
