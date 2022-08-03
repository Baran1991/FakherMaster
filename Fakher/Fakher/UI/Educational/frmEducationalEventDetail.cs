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

namespace Fakher.UI.Educational
{
    public partial class frmEducationalEventDetail : rRadDetailForm
    {
        public frmEducationalEventDetail(EducationalEvent @event)
        {
            InitializeComponent();

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker1,
                ControlProperty = "Date",
                DataObject = @event,
                ObjectProperty = "Date"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = @event,
                ObjectProperty = "Title"
            });
        }
    }
}
