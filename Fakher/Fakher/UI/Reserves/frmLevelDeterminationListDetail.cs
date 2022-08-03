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

namespace Fakher.UI.Educational.Reserves
{
    public partial class frmLevelDeterminationListDetail : rRadDetailForm
    {
        public frmLevelDeterminationListDetail(ReserveList reserveList)
        {
            InitializeComponent();
            ControlMappings.Add(new ControlMapping {Control = rTextBox1, ControlProperty = "Text", DataObject = reserveList, ObjectProperty = "Name"});
            ControlMappings.Add(new ControlMapping {Control = rTextBox2, ControlProperty = "Value", DataObject = reserveList, ObjectProperty = "Capacity"});
            ControlMappings.Add(new ControlMapping {Control = rTextBox3, ControlProperty = "Value", DataObject = reserveList, ObjectProperty = "TuitionFee"});
            ControlMappings.Add(new ControlMapping { Control = rTextBox4, ControlProperty = "Value", DataObject = reserveList, ObjectProperty = "RecieptNote" });

            List<Section> sections = Section.GetSections(Program.CurrentPeriod, reserveList.Major);
            sectionSelector1.Databind(sections);

            if (reserveList.Section != null)
            {
                rCheckBox1.Checked = true;
                sectionSelector1.Section = reserveList.Section;
                rGroupBox1.Enabled = true;
            }
            else
            {
                rCheckBox1.Checked = false;
                rGroupBox1.Enabled = false;
            }
        }

        protected override void AfterBindToObject()
        {
            ReserveList list = GetProcessingObject<ReserveList>();
            if (rCheckBox1.Checked)
                list.Section = sectionSelector1.Section;
        }

        private void rCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rGroupBox1.Enabled = rCheckBox1.Checked;
        }
    }
}
