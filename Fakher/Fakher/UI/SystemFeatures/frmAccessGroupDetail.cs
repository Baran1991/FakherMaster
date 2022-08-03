using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.SystemFeatures;
using rComponents;
using Telerik.WinControls.UI;

namespace Fakher.UI
{
    public partial class frmAccessGroupDetail : rRadDetailForm
    {
        public frmAccessGroupDetail(AccessGroup accessGroup)
        {
            InitializeComponent();
            radPageView1.SelectedPage = radPageViewPage1;
            SetProcessingObject(accessGroup);

            rComboBox1.DataSource = typeof (AccessPanel).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping { Control = radTextBox1, ControlProperty = "Text", DataObject = accessGroup, ObjectProperty = "Name" });
            ControlMappings.Add(new ControlMapping { Control = rComboBox1, ControlProperty = "SelectedIndex", DataObject = accessGroup, ObjectProperty = "AccessPanel" });

            rGridViewAccessTags.Mappings.Add(new ColumnMapping {Caption = "نــوع", ObjectProperty = "TypeText"});
            rGridViewAccessTags.DataBind(accessGroup.AccessTags);
        }

        protected override void AfterBindToObject()
        {
            AccessGroup accessGroup = GetProcessingObject<AccessGroup>();

            string menuTxt = "";
            foreach (RadTreeNode node in radTreeView1.Nodes)
                if (node.Checked)
                    menuTxt += node.Text + " - ";
            accessGroup.AccessString = menuTxt;

            accessGroup.AccessTags.SyncWith(rGridViewAccessTags.DataSource);
        }

        private void انتخـــابهـــمــــهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (RadTreeNode node in radTreeView1.Nodes)
                node.Checked = true;
        }

        private void انــتـــخــــابهـیـچکـدامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (RadTreeNode node in radTreeView1.Nodes)
                node.Checked = false;
        }

        private void rComboBox1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            AccessGroup accessGroup = GetProcessingObject<AccessGroup>();
            AccessPanel accessPanel = (AccessPanel) rComboBox1.SelectedIndex;

            radTreeView1.Nodes.Clear();

            if (accessPanel == AccessPanel.EmployeePanel)
            {
                foreach (string menu in Program.GetAccessEvents())
                {
                    RadTreeNode radTreeNode = radTreeView1.Nodes.Add(menu);
                    if (accessGroup.IsAllowed(menu))
                        radTreeNode.Checked = true;
                }
            }

            if (accessPanel == AccessPanel.TeacherPanel)
            {
                


                foreach (string menu in Program.GetTeacherAccessEvents())
                {
                    
                    RadTreeNode radTreeNode = radTreeView1.Nodes.Add(menu);
                    if (accessGroup.IsAllowed(menu))
                        radTreeNode.Checked = true;
                }
            }
        }

        private void rGridViewAccessTags_Add(object sender, EventArgs e)
        {
            AccessTag accessTag = new AccessTag();
            frmAccessTagDetail frm = new frmAccessTagDetail(accessTag);
            if (!frm.ProcessObject())
                return;

            foreach (AccessTag tag in rGridViewAccessTags.DataSource)
            {
                if(tag.Type == accessTag.Type)
                {
                    rMessageBox.ShowError("این مجوز قبلا اضافه شده است.");
                    return;
                }
            }

            rGridViewAccessTags.Insert(accessTag);
        }

        private void rGridViewAccessTags_Edit(object sender, EventArgs e)
        {
            AccessTag accessTag = rGridViewAccessTags.GetSelectedObject<AccessTag>();
            frmAccessTagDetail frm = new frmAccessTagDetail(accessTag);
            if (!frm.ProcessObject())
                return;
            rGridViewAccessTags.UpdateGridView();
        }

        private void rGridViewAccessTags_Delete(object sender, EventArgs e)
        {
            AccessTag accessTag = rGridViewAccessTags.GetSelectedObject<AccessTag>();
            rGridViewAccessTags.RemoveSelectedRow();
        }
    }
}
