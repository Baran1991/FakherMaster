using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Struture.Protocol
{
    public partial class frmPlacementItemDetail : rRadDetailForm
    {
        public frmPlacementItemDetail(PlacementItem item)
        {
            InitializeComponent();

            rComboBox1.DataSource = typeof (PlacementItemType).GetEnumDescriptions();

            rGridComboBox1.Columns.Add("کد درس", "کد درس", "Code");
            rGridComboBox1.Columns.Add("نام درس", "نام درس", "Name");
            rGridComboBox1.DataSource = DbContext.GetAllEntities<Lesson>();

            ControlMappings.Add(new ControlMapping { Control = rComboBox1, ControlProperty = "SelectedIndex", DataObject = item, ObjectProperty = "Type" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Value", DataObject = item, ObjectProperty = "FromValue"});
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Value", DataObject = item, ObjectProperty = "ToValue"});
            ControlMappings.Add(new ControlMapping { Control = rGridComboBox1, ControlProperty = "Value", DataObject = item, ObjectProperty = "Lesson" });
        }
    }
}
