using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.UI.Website
{
    public partial class frmWebsiteSectionDetail : rRadDetailForm
    {
        public frmWebsiteSectionDetail(WebsiteSection section)
        {
            InitializeComponent();

            rCmbDepartment.DataSource = Department.GetDepartments().OrderBy(x => x.Name);

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = section,
                ObjectProperty = "Name"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rChkDepartmentBinding,
                ControlProperty = "IsChecked",
                DataObject = section,
                ObjectProperty = "DepartmentBinding"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rCheckBox1,
                ControlProperty = "IsChecked",
                DataObject = section,
                ObjectProperty = "ShowCalendar"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbDepartment,
                ControlProperty = "SelectedValue",
                DataObject = section,
                ObjectProperty = "Department"
            });

            rCmbDepartment.Enabled = rCheckBox1.Enabled = section.DepartmentBinding;
        }

        private void rChkDepartmentBinding_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rCmbDepartment.Enabled = rCheckBox1.Enabled = rChkDepartmentBinding.IsChecked;
        }
    }
}
