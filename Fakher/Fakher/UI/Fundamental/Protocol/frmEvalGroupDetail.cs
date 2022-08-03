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
    public partial class frmEvalGroupDetail : rRadDetailForm
    {
        public frmEvalGroupDetail(EvaluationGroup group)
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping{Caption = "نام آیتم", ObjectProperty = "Name"});
            rGridView1.Mappings.Add(new ColumnMapping{Caption = "مقدار", ObjectProperty = "Value", AggregateSummary = AggregateSummary.Sum});
            rGridView1.DataBind(group.Items);

            ControlMappings.Add(new ControlMapping { Control = radTxtName, ControlProperty = "Text", DataObject = group, ObjectProperty = "Name"});
        }

        protected override void AfterBindToObject()
        {
            EvaluationGroup group = Tag as EvaluationGroup;
            group.Items.SyncWith(rGridView1.DataSource);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            EvaluationGroup group = Tag as EvaluationGroup;
            EvaluationItem item = new EvaluationItem {EvaluationGroup = group};
            frmEvalItemDetail frm = new frmEvalItemDetail(item);
            if(frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridView1.Insert(item);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            EvaluationGroup group = Tag as EvaluationGroup;
            EvaluationItem item = rGridView1.GetSelectedObject<EvaluationItem>();
            frmEvalItemDetail frm = new frmEvalItemDetail(item);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            rGridView1.RemoveSelectedRow();
        }
    }
}
