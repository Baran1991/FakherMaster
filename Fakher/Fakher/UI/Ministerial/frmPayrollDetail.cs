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

namespace Fakher.UI.Ministerial
{
    public partial class frmPayrollDetail : rRadDetailForm
    {
        public frmPayrollDetail(Payroll payroll)
        {
            InitializeComponent();
            SetProcessingObject(payroll);

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "سرفصل", ObjectProperty = "HeadingText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FinancialTypeText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نوع پرداخت", ObjectProperty = "PayrollContract.Contract.PaymentSystemText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "Description" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد", ObjectProperty = "Count" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "واحد", ObjectProperty = "Unit" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نرخ", ObjectProperty = "Fee", Type = ColumnType.Money });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Amount", Type = ColumnType.Money, AggregateSummary = AggregateSummary.Sum });

            rGridView1.DataBind(payroll.AllItems);
        }

        protected override void AfterBindToObject()
        {
            Payroll payroll = GetProcessingObject<Payroll>();
            foreach (PayrollContract contract in payroll.PayrollContracts)
            {
                IEnumerable<PayrollItem> items = rGridView1.DataSource.Cast<PayrollItem>().Where(x => x.PayrollContract.Id == contract.Id);
                contract.Items.SyncWith(items);
            }
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Payroll payroll = GetProcessingObject<Payroll>();
            PayrollItem item = new PayrollItem() ;
            frmPayrollItemDetail frm = new frmPayrollItemDetail(item, payroll.PayrollContracts.ToArray());
            if (!frm.ProcessObject())
                return;
            
            item.PayrollContract.AddItem(item);
            rGridView1.Insert(item);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Payroll payroll = GetProcessingObject<Payroll>();
            PayrollItem item = rGridView1.GetSelectedObject<PayrollItem>();
            frmPayrollItemDetail frm = new frmPayrollItemDetail(item, payroll.PayrollContracts.ToArray());
            if (!frm.ProcessObject())
                return;
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Payroll payroll = GetProcessingObject<Payroll>();
            PayrollItem item = rGridView1.GetSelectedObject<PayrollItem>();
            if (payroll.PayrollContracts.Count == 0)
                return;
            item.PayrollContract.Items.Remove(item);
            rGridView1.RemoveSelectedRow();
        }
    }
}
