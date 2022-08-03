using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.Website;
using rComponents;
using MenuItem = Fakher.Core.Website.MenuItem;
using Telerik.WinControls.UI;

namespace Fakher.UI.Website
{
    public partial class frmMenuItemList : rRadForm
    {
        public frmMenuItemList()
        {
            InitializeComponent();

            FillNodes();
        }

        private void FillNodes()
        {
            IList<MenuItem> menuItems = MenuItem.GetTopMenuItems();

            radTreeView1.Nodes.Clear();
            foreach (MenuItem menuItem in menuItems)
            {
                AddNode(null, menuItem);
            }
        }

        private void AddNode(RadTreeNode root, MenuItem item)
        {
            RadTreeNode radTreeNode;
            if(root != null)
                radTreeNode = root.Nodes.Add(item.Name);
            else
                radTreeNode = radTreeView1.Nodes.Add(item.Name);

            radTreeNode.Tag = item;
            radTreeNode.Expanded = true;
            foreach (MenuItem child in item.OrderedChilds)
                AddNode(radTreeNode, child);
        }

        private void toolStripBtnAdd_Click(object sender, EventArgs e)
        {
            MenuItem item = new MenuItem {Place = MenuItemPlace.MainTopMenu};

            frmMenuItemDetail frm = new frmMenuItemDetail(item);
            if (!frm.ProcessObject())
                return;

            item.Save();
            FillNodes();
        }

        private void toolStripBtnAddSubMenu_Click(object sender, EventArgs e)
        {
            RadTreeNode selectedNode = radTreeView1.SelectedNode;
            if (selectedNode == null)
                return;

            MenuItem parent = selectedNode.Tag as MenuItem;
            MenuItem item = new MenuItem { Place = MenuItemPlace.MainTopMenu, Parent = parent };

            frmMenuItemDetail frm = new frmMenuItemDetail(item);
            if (!frm.ProcessObject())
                return;

            parent.Childs.Add(item);
            item.Save();
            FillNodes();
        }

        private void toolStripBtnEdit_Click(object sender, EventArgs e)
        {
            RadTreeNode selectedNode = radTreeView1.SelectedNode;
            if (selectedNode == null)
                return;

            MenuItem item = selectedNode.Tag as MenuItem;
            frmMenuItemDetail frm = new frmMenuItemDetail(item);
            if (!frm.ProcessObject())
                return;

            item.Save();
            FillNodes();
        }

        private void toolStripBtnDelete_Click(object sender, EventArgs e)
        {
            RadTreeNode selectedNode = radTreeView1.SelectedNode;
            if (selectedNode == null)
                return;

            if (rMessageBox.ShowQuestion("عمل حذف غیرقابل بازگشت است. آیا مطمئن هستید؟") != DialogResult.Yes)
                return;

            MenuItem item = selectedNode.Tag as MenuItem;
            if (item.Parent != null)
                item.Parent.Childs.Remove(item);
            item.Delete();
            FillNodes();
        }

        private void radTreeView1_DoubleClick(object sender, EventArgs e)
        {
            if (radTreeView1.SelectedNode == null)
                return;
            toolStripBtnEdit_Click(sender, e);
        }
    }
}
