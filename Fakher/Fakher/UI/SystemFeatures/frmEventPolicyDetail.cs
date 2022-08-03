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
using rApplicationEventFramework;
using rComponents;
using Telerik.WinControls.UI;

namespace Fakher.UI
{
    public partial class frmEventPolicyDetail : rRadDetailForm
    {
        public frmEventPolicyDetail(DbPolicy policy)
        {
            InitializeComponent();

//            rGridComboBox1.Columns.Add("نام", "نام", "Name");

            rComboBox1.DataSource = DbContext.ApplicationEventFactory.Classes;
            rComboBox3.DataSource = typeof (EntityEventAction).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = policy, ObjectProperty = "EventCode" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Text", DataObject = policy, ObjectProperty = "Expression" });
            ControlMappings.Add(new ControlMapping { Control = rComboBox3, ControlProperty = "SelectedIndex", DataObject = policy, ObjectProperty = "Action" });

            foreach (RadListDataItem item in rComboBox1.Items)
            {
                if ((item.DataBoundItem as EventClass).FullName == policy.FullTypeName)
                {
                    item.Selected = true;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(policy.FullFieldName))
            {
                foreach (RadListDataItem item in rComboBox2.Items)
                {
                    EventClassProperty property = item.DataBoundItem as EventClassProperty;
                    if (property.Fullname == policy.FullFieldName)
                    {
                        item.Selected = true;
                        break;
                    }
                }

                //                foreach (GridViewRowInfo row in rGridComboBox1.EditorControl.Rows)
                //                {
                //                    EventClassProperty property = row.DataBoundItem as EventClassProperty;
                //                    if (property.Fullname == policy.FullFieldName)
                //                    {
                //                        row.IsSelected = true;
                //                        break;
                //                    }
                //                }
            }
            else
                rComboBox2.SelectedIndex = -1;
        }

        protected override void AfterBindToObject()
        {
            DbPolicy policy = GetProcessingObject<DbPolicy>();
            
            EventClass eventClass = rComboBox1.SelectedValue as EventClass;
            EventClassProperty property = rComboBox2.SelectedValue as EventClassProperty;

            policy.TypeName = eventClass.Name;
            policy.FullTypeName = eventClass.FullName;

            if(property != null)
            {
                policy.FieldName = property.Name;
                policy.FullFieldName = property.Fullname;
            }
            else
            {
                policy.FieldName = null;
                policy.FullFieldName = null;
            }
        }

        private void rComboBox1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            EventClass eventClass = rComboBox1.SelectedValue as EventClass;
            if (eventClass == null)
                return;

//            rGridComboBox1.DataSource = eventClass.EventProperties;
//            rGridComboBox1.Value = null;

            rComboBox2.DataSource = eventClass.EventProperties;
            rComboBox2.SelectedIndex = -1;

            FillListBox(eventClass);
        }

        private void FillListBox(EventClass eventClass)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(rApplicationEventFactory.OldValueDescription);
            listBox1.Items.Add(rApplicationEventFactory.NewValueDescription);

            foreach (EventClassProperty property in eventClass.EventProperties)
                listBox1.Items.Add(property);
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listBox1.SelectedItem == null)
                return;
            if ((listBox1.SelectedItem + "") == rApplicationEventFactory.OldValueDescription)
                rTextBox2.SelectedText = rApplicationEventFactory.OldValueText;
            else if ((listBox1.SelectedItem + "") == rApplicationEventFactory.NewValueDescription)
                rTextBox2.SelectedText = rApplicationEventFactory.NewValueText;
            else
                rTextBox2.SelectedText = "{" + (listBox1.SelectedItem as EventClassProperty).Name + "}";
        }
    }
}
