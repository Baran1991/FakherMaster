using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.Website;
using Telerik.WinControls.UI;
using rComponents;
using MenuItem = Fakher.Core.Website.MenuItem;

namespace Fakher.UI.Website
{
    public partial class frmWebsiteSectionList : rRadForm
    {
        public frmWebsiteSectionList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Id" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Name" });

            rGridView1.DataBind(WebsiteSection.GetWebsiteSections());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            WebsiteSection section = new WebsiteSection();

            frmWebsiteSectionDetail frm = new frmWebsiteSectionDetail(section);
            if (!frm.ProcessObject())
                return;
            section.Save();
            rGridView1.Insert(section);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            WebsiteSection section = rGridView1.GetSelectedObject<WebsiteSection>();
            frmWebsiteSectionDetail frm = new frmWebsiteSectionDetail(section);
            if (!frm.ProcessObject())
                return;
            section.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            WebsiteSection section = rGridView1.GetSelectedObject<WebsiteSection>();
            section.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            WebsiteSection section = rGridView1.GetSelectedObject<WebsiteSection>();
            if (section == null)
                return;

            FillNodes(section);
        }

        #region Section Menus

        private void FillNodes(WebsiteSection sectionContainer)
        {
            IList<MenuItem> menuItems = MenuItem.GetTopMenuItems(sectionContainer);

            radTreeView1.Nodes.Clear();
            foreach (MenuItem menuItem in menuItems)
            {
                AddNode(null, menuItem);
            }
        }

        private void AddNode(RadTreeNode root, MenuItem item)
        {
            RadTreeNode radTreeNode;
            if (root != null)
                radTreeNode = root.Nodes.Add(item.Name);
            else
                radTreeNode = radTreeView1.Nodes.Add(item.Name);

            radTreeNode.Tag = item;
            radTreeNode.Expanded = true;
            foreach (MenuItem child in item.Childs)
                AddNode(radTreeNode, child);
        }

        private void toolStripBtnAdd_Click(object sender, EventArgs e)
        {
            WebsiteSection section = rGridView1.GetSelectedObject<WebsiteSection>();
            if (section == null)
                return;

            MenuItem item = new MenuItem {Place = MenuItemPlace.SectionRightMenu};
            item.SectionContainer = section;

            frmMenuItemDetail frm = new frmMenuItemDetail(item);
            if (!frm.ProcessObject())
                return;

            item.Save();
            FillNodes(section);
        }

        private void toolStripBtnAddSubMenu_Click(object sender, EventArgs e)
        {
            WebsiteSection section = rGridView1.GetSelectedObject<WebsiteSection>();
            if (section == null)
                return;

            RadTreeNode selectedNode = radTreeView1.SelectedNode;
            if (selectedNode == null)
                return;

            MenuItem parent = selectedNode.Tag as MenuItem;
            MenuItem item = new MenuItem {Place = MenuItemPlace.SectionRightMenu, Parent = parent };
            item.SectionContainer = section;

            frmMenuItemDetail frm = new frmMenuItemDetail(item);
            if (!frm.ProcessObject())
                return;

            parent.Childs.Add(item);
            item.Save();
            FillNodes(section);
        }

        private void toolStripBtnEdit_Click(object sender, EventArgs e)
        {
            WebsiteSection section = rGridView1.GetSelectedObject<WebsiteSection>();
            if (section == null)
                return;

            RadTreeNode selectedNode = radTreeView1.SelectedNode;
            if (selectedNode == null)
                return;

            MenuItem item = selectedNode.Tag as MenuItem;
            frmMenuItemDetail frm = new frmMenuItemDetail(item);
            if (!frm.ProcessObject())
                return;

            item.Save();
            FillNodes(section);
        }

        private void toolStripBtnDelete_Click(object sender, EventArgs e)
        {
            WebsiteSection section = rGridView1.GetSelectedObject<WebsiteSection>();
            if (section == null)
                return;

            RadTreeNode selectedNode = radTreeView1.SelectedNode;
            if (selectedNode == null)
                return;

            if (rMessageBox.ShowQuestion("عمل حذف غیرقابل بازگشت است. آیا مطمئن هستید؟") != DialogResult.Yes)
                return;

            MenuItem item = selectedNode.Tag as MenuItem;
            if (item.Parent != null)
                item.Parent.Childs.Remove(item);
            item.Delete();
            FillNodes(section);
        }

        private void radTreeView1_DoubleClick(object sender, EventArgs e)
        {
            if (radTreeView1.SelectedNode == null)
                return;
            toolStripBtnEdit_Click(sender, e);
        }

        #endregion
    }
}
