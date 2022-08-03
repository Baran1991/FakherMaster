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
    public partial class frmPlacementProtocolList : rRadForm
    {
        public frmPlacementProtocolList()
        {
            InitializeComponent();
            rGridView1.Mappings.Add(new ColumnMapping {Caption = "نام آیین نامه", ObjectProperty = "Name"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد آیتم", ObjectProperty = "PlacementItems.Count" });

//            rGridView1.DataBind(DbContext.GetAllEntities<PlacementProtocol>());
            rGridView1.DataBind(PlacementProtocol.GetProtocols(Program.CurrentPeriod));

        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            PlacementProtocol protocol = new PlacementProtocol();
            protocol.Period = Program.CurrentPeriod;
            frmPlacementProtocolDetail frm = new frmPlacementProtocolDetail(protocol);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            protocol.Save();
            rGridView1.Insert(protocol);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            PlacementProtocol protocol = rGridView1.GetSelectedObject<PlacementProtocol>();
            frmPlacementProtocolDetail frm = new frmPlacementProtocolDetail(protocol);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            protocol.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            PlacementProtocol protocol = rGridView1.GetSelectedObject<PlacementProtocol>();
            protocol.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
