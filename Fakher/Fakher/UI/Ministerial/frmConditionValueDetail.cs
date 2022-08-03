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
    public partial class frmConditionValueDetail : rRadDetailForm
    {
        public frmConditionValueDetail(ConditionValue conditionValue)
        {
            InitializeComponent();

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Value",
                DataObject = conditionValue,
                ObjectProperty = "RateElement.Amount"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox2,
                ControlProperty = "Value",
                DataObject = conditionValue,
                ObjectProperty = "RateElement.Value"
            });

        }
    }
}
