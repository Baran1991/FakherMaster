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
    public partial class frmActivityMarkDetail : rRadDetailForm
    {
        public frmActivityMarkDetail(ActivityMark mark)
        {
            InitializeComponent();

         
            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = mark, ObjectProperty = "Date"});
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Value",
                DataObject = mark,
                ObjectProperty = "Mark"
            });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Text", DataObject = mark, ObjectProperty = "Description" });
        }
    }
}
