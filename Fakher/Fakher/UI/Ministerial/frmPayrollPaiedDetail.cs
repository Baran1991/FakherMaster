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
    public partial class frmPayrollPaiedDetail : rRadDetailForm
    {
        public frmPayrollPaiedDetail(PayrollPaid item, PayrollContract[] contracts)
        {
            InitializeComponent();


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
                Control = rTxtAccountNo,
                ControlProperty = "Text",
                DataObject = item,
                ObjectProperty = "AccountNo"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtAmount,
                ControlProperty = "Value",
                DataObject = item,
                ObjectProperty = "Amount"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtBank,
                ControlProperty = "Text",
                DataObject = item,
                ObjectProperty = "BankName"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker1,
                ControlProperty = "Date",
                DataObject = item,
                ObjectProperty = "Date"
            });

          
        }

      
    }
}
