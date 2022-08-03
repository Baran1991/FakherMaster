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
    public partial class frmResultProtocolList : rRadForm
    {
        public frmResultProtocolList()
        {
            InitializeComponent();
            rGridView1.Mappings.Add(new ColumnMapping{ Caption = "نام آیین نامه", ObjectProperty = "Name"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نتایج", ObjectProperty = "Labels.Count" });
//            rGridView1.DataBind(DbContext.GetAllEntities<ResultProtocol>());
            rGridView1.DataBind(ResultProtocol.GetProtocols(Program.CurrentPeriod));
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            ResultProtocol protocol = new ResultProtocol();
            protocol.Period = Program.CurrentPeriod;
            frmResultProtocolDetail frm = new frmResultProtocolDetail(protocol);
            if(frm.ShowDialog(this) != DialogResult.OK)
                return;
            protocol.Save();
            rGridView1.Insert(protocol);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            ResultProtocol protocol = rGridView1.GetSelectedObject<ResultProtocol>();
            frmResultProtocolDetail frm = new frmResultProtocolDetail(protocol);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            protocol.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            ResultProtocol protocol = rGridView1.GetSelectedObject<ResultProtocol>();
            protocol.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
