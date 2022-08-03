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
    public partial class frmPresenceDetail : rRadDetailForm
    {
        public frmPresenceDetail(Presence presence)
        {
            InitializeComponent();

            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = presence, ObjectProperty = "Date" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = presence, ObjectProperty = "StartTime" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Text", DataObject = presence, ObjectProperty = "EndTime" });
        }

        protected override void AfterBindToObject()
        {
            Presence presence = GetProcessingObject<Presence>();

            if (presence.StartTimeInMinutes >= presence.EndTimeInMinutes)
            {
                rMessageBox.ShowError("زمان شروع باید کوچکتر از زمان پایان باشد.");
                CancelClosing();
                return;
            }
        }
    }
}
