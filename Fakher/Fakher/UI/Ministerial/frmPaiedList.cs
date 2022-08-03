using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Reports.Ministerial_Reports;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Ministerial
{
    public partial class frmPaidList : rRadForm
    {
        static Payroll selectedPayroll;
        public frmPaidList(Payroll payroll)
        {
            InitializeComponent();

            selectedPayroll = payroll;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "بانک پرداخت کننده", ObjectProperty = "BankName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره حساب", ObjectProperty = "AccountNo" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ ", ObjectProperty = "Date", TextAlign = HorizontalAlignment.Center});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ ", ObjectProperty = "Amount", Type = ColumnType.Money,AggregateSummary=AggregateSummary.Sum});
            rGridView1.DataBind(payroll.AllPaied);
        }

       

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            if (rMessageBox.ShowQuestion("با انجام عمل حذف، مبلغ پرداختی به طور کامل حذف خواهد شد. آیا مطمئن هستید؟") != DialogResult.Yes)
                return;
            PayrollPaid paid = rGridView1.GetSelectedObject<PayrollPaid>();
            paid.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            PayrollPaid payroll = rGridView1.GetSelectedObject<PayrollPaid>();
            frmPayrollPaiedDetail frm = new frmPayrollPaiedDetail(payroll, selectedPayroll.PayrollContracts.ToArray());
            if (!frm.ProcessObject())
                return;
            payroll.Save();
            rGridView1.UpdateGridView();
        }
        private void rGridView1_Add(object sender, EventArgs e)
        {
            PayrollPaid paid = new PayrollPaid();
            
            frmPayrollPaiedDetail frm = new frmPayrollPaiedDetail(paid, selectedPayroll.PayrollContracts.ToArray());
            if (!frm.ProcessObject())
                return;
            paid.PayrollContract.AddPayment(paid);
            paid.Save();
            rGridView1.Insert(paid);
        }
        }
    }
