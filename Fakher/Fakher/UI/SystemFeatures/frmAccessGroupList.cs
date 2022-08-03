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

namespace Fakher.UI
{
    public partial class frmAccessGroupList : rRadForm
    {
        public frmAccessGroupList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping {Caption = "نام گروه", ObjectProperty = "Name"});

            rGridView1.DataBind(DbContext.GetAllEntities<AccessGroup>());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            AccessGroup accessGroup = new AccessGroup();
            frmAccessGroupDetail frm = new frmAccessGroupDetail(accessGroup);
            if(!frm.ProcessObject())
                return;
            accessGroup.Save();
            rGridView1.Insert(accessGroup);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            AccessGroup accessGroup = rGridView1.GetSelectedObject<AccessGroup>();
            frmAccessGroupDetail frm = new frmAccessGroupDetail(accessGroup);
            if (!frm.ProcessObject())
                return;
            accessGroup.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            try { 
            AccessGroup accessGroup = rGridView1.GetSelectedObject<AccessGroup>();
                if(!accessGroup.CanDelete())
                {
                    rMessageBox.ShowError("بدلیل ارتباط با اطلاعات دیگر، حذف امکان پذیر نمیباشد!");
                    return;
                }
            accessGroup.Delete();
            rGridView1.RemoveSelectedRow();
        }
         
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
    }
}
