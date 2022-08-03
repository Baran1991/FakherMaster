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
    public partial class frmEvalProtocolDetail : rRadDetailForm
    {
        public frmEvalProtocolDetail(EvaluationProtocol protocol)
        {
            InitializeComponent();

            rComboBoxOperator.DataSource = typeof (EvaluationOperator).GetEnumDescriptions();

            rGridView1.Mappings.Add(new ColumnMapping{ Caption = "نام گروه", ObjectProperty = "Name"});
            rGridView1.Mappings.Add(new ColumnMapping{ Caption = "تعداد آیتم", ObjectProperty = "Items.Count"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مقدار", ObjectProperty = "TotalValue", AggregateSummary = AggregateSummary.Sum});
            rGridView1.DataBind(protocol.EvaluationGroups);

            ControlMappings.Add(new ControlMapping { Control = radTxtName, ControlProperty = "Text", DataObject = protocol, ObjectProperty = "Name"});
            ControlMappings.Add(new ControlMapping { Control = rComboBoxOperator, ControlProperty = "SelectedIndex", DataObject = protocol, ObjectProperty = "Operator" });
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            EvaluationProtocol protocol = Tag as EvaluationProtocol;
            EvaluationGroup group = new EvaluationGroup{ EvaluationProtocol = protocol};
            frmEvalGroupDetail frm = new frmEvalGroupDetail(group);
            if(frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridView1.Insert(group);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            EvaluationProtocol protocol = Tag as EvaluationProtocol;
            EvaluationGroup group = rGridView1.GetSelectedObject<EvaluationGroup>();
            frmEvalGroupDetail frm = new frmEvalGroupDetail(group);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            rGridView1.RemoveSelectedRow();
        }

        protected override void AfterBindToObject()
        {
            EvaluationProtocol protocol = Tag as EvaluationProtocol;
            protocol.EvaluationGroups.SyncWith(rGridView1.DataSource);
        }

    }
}
