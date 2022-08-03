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

namespace Fakher.UI.Ministerial
{
    public partial class frmPayrollItemDetail : rRadDetailForm
    {
        public frmPayrollItemDetail(PayrollItem item, PayrollContract[] contracts)
        {
            InitializeComponent();

            rCmbHeading.DataSource = typeof(PayrollItemHeading).GetEnumDescriptions();
            rCmbFinancialType.DataSource = typeof(FinancialType).GetEnumDescriptions();
            
            rGridComboBox1.Columns.Add("نام", "نام", "Contract.Text");
            rGridComboBox1.DataSource = contracts;

            ControlMappings.Add(new ControlMapping
            {
                Control = rGridComboBox1,
                ControlProperty = "Value",
                DataObject = item,
                ObjectProperty = "PayrollContract"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbHeading,
                ControlProperty = "SelectedIndex",
                DataObject = item,
                ObjectProperty = "Heading"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbFinancialType,
                ControlProperty = "SelectedIndex",
                DataObject = item,
                ObjectProperty = "FinancialType"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtCount,
                ControlProperty = "Value",
                DataObject = item,
                ObjectProperty = "Count"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtUnit,
                ControlProperty = "Text",
                DataObject = item,
                ObjectProperty = "Unit"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtFee,
                ControlProperty = "Value",
                DataObject = item,
                ObjectProperty = "Fee"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtDescription,
                ControlProperty = "Text",
                DataObject = item,
                ObjectProperty = "Description"
            });
        }

        private void rTxtFee_ValueChanged(object sender, EventArgs e)
        {
            int amount = rTxtCount.GetValue<int>()*rTxtFee.GetValue<int>();
            rLblAmount.Text = amount.ToString("C0");
        }
    }
}
