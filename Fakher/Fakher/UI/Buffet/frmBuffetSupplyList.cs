using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel.Buffet;
using rComponents;

namespace Fakher.UI.Buffet
{
    public partial class frmBuffetSupplyList : rRadForm
    {
        public frmBuffetSupplyList()
        {
            InitializeComponent();

            rGridComboBox1.Columns.Add("نام محصول", "نام محصول", "Name");

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره فاکتور", ObjectProperty = "BillNo" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تـاریخ", ObjectProperty = "Date.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "قیمت خرید", ObjectProperty = "BuyPrice" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "قیمت فروش", ObjectProperty = "SellPrice" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد", ObjectProperty = "Count", AggregateSummary = AggregateSummary.Sum });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "باقیمانده", ObjectProperty = "Remainder", AggregateSummary = AggregateSummary.Sum });

            rGridView1.CustomButtons.Add(new rGridViewButton { Text = "افزایش موجودی", VisibleOnSelect = true, Position = rGridViewButtonPosition.Before });

            FillCombo();
        }

        private void FillCombo()
        {
            IList<BuffetProduct> products = BuffetProduct.GetAllProducts();
            rGridComboBox1.DataSource = products;
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridView1.Clear();
            BuffetProduct product = rGridComboBox1.GetValue<BuffetProduct>();
            if (product == null)
                return;

            rGridView1.DataBind(product.Supplies);
        }

        private void rGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            if (e.ButtonIndex == 0)
            {
                BuffetProduct product = rGridComboBox1.GetValue<BuffetProduct>();
                BuffetSupply supply = new BuffetSupply();
                frmBuffetSupplyDetail frm = new frmBuffetSupplyDetail(supply);
                if (!frm.ProcessObject())
                    return;
                supply.BuffetProduct = product;
                supply.Save();
                product.Supplies.Add(supply);
                rGridView1.Insert(supply);
            }
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            BuffetSupply supply = rGridView1.GetSelectedObject<BuffetSupply>();
            frmBuffetSupplyDetail frm = new frmBuffetSupplyDetail(supply);
            if (!frm.ProcessObject())
                return;
            supply.Save();

            rGridView1.UpdateGridView();
        }
    }
}
