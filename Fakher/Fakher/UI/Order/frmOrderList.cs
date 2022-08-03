using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Order
{
    public partial class frmOrderList : rRadForm
    {
        public frmOrderList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "خریدار", ObjectProperty = "Person.FarsiFullname" });
            rGridView1.Mappings.Add(new ColumnMapping {Caption = "تاریخ", ObjectProperty = "DateTimeText"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت تراکنش", ObjectProperty = "PayTransactionText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FinancialStatusText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت سفارش", ObjectProperty = "StatusText" });

            rGridView1.DataBind(Core.DomainModel.Order.Order.GetOrdersQuery().ToList());
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Core.DomainModel.Order.Order order = rGridView1.GetSelectedObject<Core.DomainModel.Order.Order>();
            rptOrderReceipt rpt = new rptOrderReceipt();
            rpt.DataSource = order;
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Core.DomainModel.Order.Order order = rGridView1.GetSelectedObject<Core.DomainModel.Order.Order>();
            order.Sent();
            order.Save();
            rGridView1.UpdateGridView();
        }
    }
}
