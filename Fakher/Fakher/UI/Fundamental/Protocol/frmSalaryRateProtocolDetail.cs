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

namespace Fakher.UI.Fundamental.Protocol
{
    public partial class frmSalaryRateProtocolDetail : rRadDetailForm
    {
        public frmSalaryRateProtocolDetail(SalaryRateProtocol protocol)
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "ConditionText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Amount" });
            rGridView1.DataBind(protocol.Items);

            ControlMappings.Add(new ControlMapping { Control = radTxtName, ControlProperty = "Text", DataObject = protocol, ObjectProperty = "Name" });
        }

        #region Overrides of rRadDetailForm

        protected override void AfterBindToObject()
        {
            SalaryRateProtocol protocol = GetProcessingObject<SalaryRateProtocol>();
            protocol.Items.SyncWith(rGridView1.DataSource);
        }

        #endregion

        private void rGridView1_Add(object sender, EventArgs e)
        {
            SalaryRateItem item = new SalaryRateItem();
            frmSalaryRateItemDetail frm = new frmSalaryRateItemDetail(item);
            if(!frm.ProcessObject())
                return;
            rGridView1.Insert(item);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            SalaryRateItem item = rGridView1.GetSelectedObject<SalaryRateItem>();
            frmSalaryRateItemDetail frm = new frmSalaryRateItemDetail(item);
            if (!frm.ProcessObject())
                return;
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            SalaryRateItem item = rGridView1.GetSelectedObject<SalaryRateItem>();
            rGridView1.RemoveSelectedRow();
        }
    }
}
