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
    public partial class frmEvalItemDetail : rRadDetailForm
    {
        public frmEvalItemDetail(EvaluationItem item)
        {
            InitializeComponent();
            ControlMappings.Add(new ControlMapping {Control = rTxtName, ControlProperty = "Text", DataObject = item, ObjectProperty = "Name"});
            ControlMappings.Add(new ControlMapping { Control = rTxtValue, ControlProperty = "Value", DataObject = item, ObjectProperty = "Value", ConvertNeeded = true });
        }
    }
}
