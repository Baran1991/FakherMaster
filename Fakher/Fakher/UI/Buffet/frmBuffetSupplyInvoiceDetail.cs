using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Buffet;
using rComponents;

namespace Fakher.UI.Store
{
    public partial class frmBuffetSupplyInvoiceDetail : rRadForm
    {
        public frmBuffetSupplyInvoiceDetail()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره فاکتور", ObjectProperty = "BillNo" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس افزار", ObjectProperty = "EducationalTool.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تـاریخ", ObjectProperty = "Date.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "قیمت خرید", ObjectProperty = "BuyPrice" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "قیمت فروش", ObjectProperty = "SellPrice" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد", ObjectProperty = "Count", AggregateSummary = AggregateSummary.Sum });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "باقیمانده", ObjectProperty = "Remainder", AggregateSummary = AggregateSummary.Sum });
        }

        private void radBtnSearch_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(rTextBox1.Text.Trim()))
            {
                rMessageBox.ShowWarning("شماره فاکتور را وارد کنید.");
                return;
            }

            IQueryable<BuffetSupply> suplies = BuffetSupply.GetSuplies(rTextBox1.Text.Trim());
            rGridView1.DataBind(suplies);
        }

        private void frmStoreSupplyInvoiceDetail_Shown(object sender, EventArgs e)
        {
            rTextBox1.Focus();
        }
    }
}
