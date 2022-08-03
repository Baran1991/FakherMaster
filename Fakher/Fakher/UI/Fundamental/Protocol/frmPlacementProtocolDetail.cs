using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Struture.Protocol
{
    public partial class frmPlacementProtocolDetail : rRadDetailForm
    {
        public frmPlacementProtocolDetail(PlacementProtocol protocol)
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "از نمره", ObjectProperty = "FromValue" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تا نمره", ObjectProperty = "ToValue" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس", ObjectProperty = "Lesson.Name" });
            rGridView1.DataBind(protocol.PlacementItems);

            ControlMappings.Add(new ControlMapping{Control = radTxtName, ControlProperty = "Text", DataObject = protocol, ObjectProperty = "Name"});
        }

        protected override void AfterBindToObject()
        {
            PlacementProtocol protocol = GetProcessingObject<PlacementProtocol>();
            protocol.PlacementItems.SyncWith(rGridView1.DataSource);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            PlacementProtocol protocol = GetProcessingObject<PlacementProtocol>();
            PlacementItem item = new PlacementItem {Protocol = protocol};
            frmPlacementItemDetail frm = new frmPlacementItemDetail(item);
            if(frm.ShowDialog(this) != DialogResult.OK)
                return;
            foreach (PlacementItem placementItem in rGridView1.DataSource)
            {
                if(placementItem.HasIntersect(item))
                {
                    rMessageBox.ShowError(string.Format("این آیتم با آیتم [{0}] تداخل دارد.", placementItem.Lesson.Name));
                    return;
                }
            }
            rGridView1.Insert(item);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            PlacementProtocol protocol = GetProcessingObject<PlacementProtocol>();
            PlacementItem item = rGridView1.GetSelectedObject<PlacementItem>();
            frmPlacementItemDetail frm = new frmPlacementItemDetail(item);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            foreach (PlacementItem placementItem in rGridView1.DataSource)
            {
                if (placementItem.HasIntersect(item) && placementItem.Id != item.Id)
                {
                    rMessageBox.ShowError(string.Format("این آیتم با آیتم [{0}] تداخل دارد.", placementItem.Lesson.Name));
                    return;
                }
            }
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            PlacementProtocol protocol = GetProcessingObject<PlacementProtocol>();
            PlacementItem item = rGridView1.GetSelectedObject<PlacementItem>();
            rGridView1.RemoveSelectedRow();
        }
    }
}
