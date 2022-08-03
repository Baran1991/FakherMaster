using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Holding;
using rComponents;

namespace Fakher.UI.Educational.Sections
{
    public partial class frmMakeupDetail : rRadDetailForm
    {
        public frmMakeupDetail(Makeup makeup)
        {
            InitializeComponent();

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rDatePicker1,
                                        ControlProperty = "Date",
                                        DataObject = makeup,
                                        ObjectProperty = "Date"
                                    });
        }

        private void lnkFormation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Makeup makeup = GetProcessingObject<Makeup>();
            if(rDatePicker1.Date != null)
                makeup.Formation.Day = rDatePicker1.Date.GetDayOfWeek();

            frmFormationDetail frm = new frmFormationDetail(makeup.Formation);
            frm.ProcessObject();
        }
    }
}
