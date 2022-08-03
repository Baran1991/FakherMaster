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
using rComponents;
using Telerik.WinControls.UI;

namespace Fakher.UI.Struture
{
    public partial class frmPlaceDetail : rRadDetailForm
    {
        public frmPlaceDetail(Place place)
        {
            InitializeComponent();
//            string[] descriptions = typeof(CapacityType).GetEnumDescriptions();

            radDropDownList1.DataSource = typeof(CapacityType).GetEnumDescriptions();
//            foreach (string description in descriptions)
//            {
//                RadListDataItem item = new RadListDataItem(description);
//                item.Font = radDropDownList1.Font;
//                radDropDownList1.Items.Add(item);
//            }

            ControlMappings.Add(new ControlMapping
            {
                Control = radTextBox1,
                ControlProperty = "Text",
                DataObject = place,
                ObjectProperty = "Name"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = radDropDownList1,
                ControlProperty = "SelectedIndex",
                DataObject = place,
                ObjectProperty = "CapacityType",
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = radSpinEditor1,
                ControlProperty = "Value",
                DataObject = place,
                ObjectProperty = "Capacity",
                ConvertNeeded = true
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
