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
    public partial class frmEventPolicyList : rRadForm
    {
        public frmEventPolicyList()
        {
            InitializeComponent();
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کد", ObjectProperty = "EventCode" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "اپراتور", ObjectProperty = "ActionText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شی", ObjectProperty = "TypeName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ویژگی", ObjectProperty = "FieldName" });

            rGridView1.DataBind(DbContext.GetAll<DbPolicy>());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            DbPolicy policy = new DbPolicy();
            frmEventPolicyDetail frm = new frmEventPolicyDetail(policy);
            if(!frm.ProcessObject())
                return;
            policy.Save();
            rGridView1.Insert(policy);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            DbPolicy policy = rGridView1.GetSelectedObject<DbPolicy>();
            frmEventPolicyDetail frm = new frmEventPolicyDetail(policy);
            if (!frm.ProcessObject())
                return;
            policy.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            DbPolicy policy = rGridView1.GetSelectedObject<DbPolicy>();
            policy.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
