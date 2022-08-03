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
using Fakher.UI.Store;
using rComponents;

namespace Fakher.UI.Buffet
{
    public partial class frmEducationalToolSupplyList : rRadForm
    {
        public frmEducationalToolSupplyList()
        {
            InitializeComponent();

            rGridComboBox1.Columns.Add("نام", "نام", "Name");
            rGridComboBox1.Columns.Add("وضعیت", "وضعیت", "StatusText");

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره فاکتور", ObjectProperty = "BillNo" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تـاریخ", ObjectProperty = "Date.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "قیمت خرید", ObjectProperty = "BuyPrice" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "قیمت فروش", ObjectProperty = "SellPrice" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد", ObjectProperty = "Count", AggregateSummary = AggregateSummary.Sum });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "باقیمانده", ObjectProperty = "Remainder", AggregateSummary = AggregateSummary.Sum });

            FillCombo();
        }

        private void FillCombo()
        {
            IQueryable<EducationalTool> products = EducationalTool.GetAllTools().Where(m=>!m.Disabled);
            rGridComboBox1.DataSource = products;
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridView1.Clear();
            EducationalTool product = rGridComboBox1.GetValue<EducationalTool>();
            if (product == null)
                return;

            rGridView1.DataBind(product.Supplies);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            EducationalTool product = rGridComboBox1.GetValue<EducationalTool>();
            EducationalToolSupply supply = new EducationalToolSupply();
            frmEducationalToolSupplyDetail frm = new frmEducationalToolSupplyDetail(supply);
            if (!frm.ProcessObject())
                return;
            supply.EducationalTool = product;
            supply.Remainder = supply.Count;
            product.Supplies.Add(supply);
            supply.Save();

            rGridView1.Insert(supply);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            //EducationalTool product = rGridComboBox1.GetValue<EducationalTool>();
            EducationalToolSupply supply = rGridView1.GetSelectedObject<EducationalToolSupply>();

            if (supply.Remainder != supply.Count)
            {
                rMessageBox.ShowWarning("به دلیل اینکه از این پارت، تعدادی کالا فروخته شده است، اصلاح موجودی امکان پذیر نمی باشد.");
                return;
            }

            frmEducationalToolSupplyDetail frm = new frmEducationalToolSupplyDetail(supply);
            if (!frm.ProcessObject())
                return;

            supply.Remainder = supply.Count;
            supply.Save();

            rGridView1.UpdateGridView();
        }
    }
}
