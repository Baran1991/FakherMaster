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

namespace Fakher.UI.Struture
{
    public partial class frmBranchList : rRadForm
    {
        public frmBranchList()
        {
            InitializeComponent();
            rGridView1.Mappings.Add(new ColumnMapping { Caption="نام ", ObjectProperty="Name"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "آدرس", ObjectProperty = "Address" });
            rGridView1.DataBind(DbContext.GetAllEntities<Branch>());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Branch branch = new Branch();
            frmBranchDetail frm = new frmBranchDetail(branch);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            branch.Save();
            rGridView1.Insert(branch);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Branch branch = rGridView1.GetSelectedObject<Branch>();
            frmBranchDetail frm = new frmBranchDetail(branch);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            branch.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Branch branch = rGridView1.GetSelectedObject<Branch>();
            branch.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
