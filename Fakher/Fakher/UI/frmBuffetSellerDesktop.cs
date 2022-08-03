using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel.Buffet;
using Fakher.Reports;
using Fakher.UI.Buffet;
using Fakher.UI.Report;
using NHibernate;
using rComponents;

namespace Fakher.UI
{
    public partial class frmBuffetSellerDesktop : rRadForm
    {
        public frmBuffetSellerDesktop()
        {
            InitializeComponent();
            Program.SetTheme("Office2010Silver");
            Services.SetLanguageFarsi();

            rGridViewProducts.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            rGridViewProducts.Mappings.Add(new ColumnMapping { Caption = "تعداد باقیمانده", ObjectProperty = "Remainder" });
            rGridViewProducts.Mappings.Add(new ColumnMapping { Caption = "قیمت", ObjectProperty = "LastSellPrice", Type = ColumnType.Money });

            rGridViewCart.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "BuffetProduct.Name" });
            rGridViewCart.Mappings.Add(new ColumnMapping { Caption = "تعداد", ObjectProperty = "Count" });
            rGridViewCart.Mappings.Add(new ColumnMapping { Caption = "فی", ObjectProperty = "BuffetProduct.LastSellPrice" });
            rGridViewCart.Mappings.Add(new ColumnMapping { Caption = "قیمت", ObjectProperty = "Price", Type = ColumnType.Money, AggregateSummary = AggregateSummary.Sum });

            rGridViewProducts.DataBind(BuffetProduct.GetAllProducts().OrderBy(x => x.Name));

            lblName.Text = "فروشنـــــده: " + Program.CurrentBuffetSeller.FarsiFullname;
        }

        private void AddToCart(BuffetProduct product, int count)
        {
            foreach (BuffetSaleItem item in rGridViewCart.DataSource)
            {
                if (item.BuffetProduct.Id == product.Id)
                {
                    item.Count += count;
                    rGridViewCart.UpdateGridView();
                    return;
                }
            }

            BuffetSaleItem newItem = new BuffetSaleItem();
            newItem.BuffetProduct = product;
            newItem.Count = count;
            rGridViewCart.Insert(newItem);
        }

        private void ClearCart()
        {
            rGridViewCart.Clear();
        }

        private void rGridViewProducts_Edit(object sender, EventArgs e)
        {
            BuffetProduct product = rGridViewProducts.GetSelectedObject<BuffetProduct>();
            if(!product.HasRemainder)
            {
                rMessageBox.ShowError("موجودی این کالا تمام شده است.");
                return;
            }
            frmBuffetCount frm = new frmBuffetCount {Count = 1};
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            if(!product.Has(frm.Count))
            {
                rMessageBox.ShowError("از این کالا به اندازه کافی موجود نیست.");
                return;
            }

            AddToCart(product, frm.Count);
        }

        private void rGridViewCart_Delete(object sender, EventArgs e)
        {
            BuffetSaleItem saleItem = rGridViewCart.GetSelectedObject<BuffetSaleItem>();
            if (saleItem.Count == 1)
                rGridViewCart.RemoveSelectedRow();
            else
            {
                frmBuffetCount frm = new frmBuffetCount {Count = 1};
                if (frm.ShowDialog(this) != DialogResult.OK)
                    return;

                if (frm.Count > saleItem.Count)
                {
                    rMessageBox.ShowError("تعداد درخواستی بیشتر از تعداد ثبت شده است.");
                    return;
                }
                saleItem.Count -= frm.Count;
            }
            rGridViewCart.UpdateGridView();
        }

        private void rGridViewCart_Add(object sender, EventArgs e)
        {
            ITransaction transaction = DbContext.BeginTransaction();

            try
            {
                foreach (BuffetSaleItem item in rGridViewCart.DataSource)
                {
                    item.SaleItemProfit = item.BuffetProduct.Decrease(item.Count);
                    item.BuffetProduct.Save();
                }

                BuffetSale buffetSale = new BuffetSale();
                foreach (BuffetSaleItem item in rGridViewCart.DataSource)
                    buffetSale.AddItem(item);
                buffetSale.Seller = Program.CurrentBuffetSeller;
                buffetSale.Save();

                Program.CurrentBuffetSeller.RegisterTransactionFor(buffetSale);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                transaction.Rollback();
            }

            ClearCart();
            rMessageBox.ShowInformation("فروش ثبت گردید.");
        }

        private void گزارشفروشروزانهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptBuffetSellerSales rpt = new rptBuffetSellerSales {BuffetSeller = Program.CurrentBuffetSeller};
            rpt.DataSource = Program.CurrentBuffetSeller.GetBuffetSaleItems(PersianDate.Today, PersianDate.Today);
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }

        private void rGridViewProducts_Load(object sender, EventArgs e)
        {

        }
    }
}
