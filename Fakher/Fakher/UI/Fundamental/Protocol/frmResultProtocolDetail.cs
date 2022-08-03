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

namespace Fakher.UI
{
    public partial class frmResultProtocolDetail : rRadDetailForm
    {
        public frmResultProtocolDetail(ResultProtocol protocol)
        {
            InitializeComponent();
            rGridView1.Mappings.Add(new ColumnMapping{ Caption = "نام نتیجه", ObjectProperty = "Name"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "Text" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "از", ObjectProperty = "MinimumValue" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تا", ObjectProperty = "MaximumValue" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "Status" });
            rGridView1.DataBind(protocol.Labels);

            ControlMappings.Add(new ControlMapping{Control = radTxtName, ControlProperty = "Text", DataObject = protocol, ObjectProperty = "Name"});
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            ResultProtocol protocol = Tag as ResultProtocol;
            ResultLabel resultLabel = new ResultLabel{ResultProtocol = protocol};
            frmResultLabelDetail frm = new frmResultLabelDetail(resultLabel);
            if(frm.ShowDialog(this) != DialogResult.OK)
                return;
//            if(resultLabel.HasMarkRule)
//                foreach (ResultLabel label in rGridView1.DataSource)
//                {
//                    if (label.HasIntersect(resultLabel))
//                    {
//                        rMessageBox.ShowError(string.Format("این آیتم با آیتم [{0}] تداخل دارد.", label.Name));
//                        return;
//                    }
//                }
            rGridView1.Insert(resultLabel);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            ResultProtocol protocol = Tag as ResultProtocol;
            ResultLabel resultLabel = rGridView1.GetSelectedObject<ResultLabel>();
            frmResultLabelDetail frm = new frmResultLabelDetail(resultLabel);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
//            if(resultLabel.HasMarkRule)
//                foreach (ResultLabel label in rGridView1.DataSource)
//                {
//                    if (label.HasIntersect(resultLabel) && label.Id != resultLabel.Id)
//                    {
//                        rMessageBox.ShowError(string.Format("این آیتم با آیتم [{0}] تداخل دارد.", label.Name));
//                        return;
//                    }
//                }
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            rGridView1.RemoveSelectedRow();
        }

        protected override void AfterBindToObject()
        {
            ResultProtocol protocol = Tag as ResultProtocol;
            protocol.Labels.SyncWith(rGridView1.DataSource);
        }
    }
}
