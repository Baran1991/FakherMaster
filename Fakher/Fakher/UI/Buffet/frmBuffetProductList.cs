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
    public partial class frmBuffetProductList : rRadForm
    {
        public frmBuffetProductList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نــام", ObjectProperty = "Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "موجودی کل", ObjectProperty = "Count" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "باقیمانده", ObjectProperty = "Remainder" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "قیمت خرید", ObjectProperty = "LastBuyPrice" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "قیمت فروش", ObjectProperty = "LastSellPrice" });

            rGridView1.CustomButtons.Add(new rGridViewButton {Text = "افزایش موجودی", VisibleOnSelect = true, Position = rGridViewButtonPosition.After});

            rGridView1.DataBind(BuffetProduct.GetAllProducts());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            BuffetProduct product = new BuffetProduct();
            frmBuffetProductDetail frm = new frmBuffetProductDetail(product);
            if (!frm.ProcessObject())
                return;
            product.Save();
            rGridView1.Insert(product);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            BuffetProduct product = rGridView1.GetSelectedObject<BuffetProduct>();
            frmBuffetProductDetail frm = new frmBuffetProductDetail(product);
            if (!frm.ProcessObject())
                return;
            product.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {

        }

        private void rGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            if(e.ButtonIndex == 0)
            {
                BuffetProduct product = rGridView1.GetSelectedObject<BuffetProduct>();
                BuffetSupply supply = new BuffetSupply();
                frmBuffetSupplyDetail frm = new frmBuffetSupplyDetail(supply);
                if (!frm.ProcessObject())
                    return;
                supply.BuffetProduct = product;
                supply.Save();
                product.Supplies.Add(supply);
                rGridView1.UpdateGridView();
            }
        }
    }
}
