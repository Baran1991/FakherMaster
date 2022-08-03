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

using Telerik.WinControls.UI;

namespace Fakher.UI.Struture
{
    public partial class frmBranchDetail : rRadDetailForm
    {
        public frmBranchDetail(Branch branch)
        {
            InitializeComponent();
//            string[] descriptions = typeof(CapacityType).GetEnumDescriptions();

          

            ControlMappings.Add(new ControlMapping
            {
                Control = radTextBox1,
                ControlProperty = "Text",
                DataObject = branch,
                ObjectProperty = "Name"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtAddress,
                ControlProperty = "Text",
                DataObject = branch,
                ObjectProperty = "Address"
            });


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Validate();
                BindControlsToObject();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
    }
}
