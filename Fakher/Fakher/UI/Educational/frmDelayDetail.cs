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
    public partial class frmDelayDetail : rRadDetailForm
    {
        public frmDelayDetail(Delay delay)
        {
            InitializeComponent();

           
            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = delay, ObjectProperty = "Date"});
         }
    }
}
