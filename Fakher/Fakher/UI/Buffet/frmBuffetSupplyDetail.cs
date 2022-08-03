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
    public partial class frmBuffetSupplyDetail : rRadDetailForm
    {
        public frmBuffetSupplyDetail(BuffetSupply supply)
        {
            InitializeComponent();

            SetProcessingObject(supply);

            ControlMappings.Add(new ControlMapping { Control = rTxtBillNo, ControlProperty = "Value", DataObject = supply, ObjectProperty = "BillNo" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Value", DataObject = supply, ObjectProperty = "Count" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Value", DataObject = supply, ObjectProperty = "BuyPrice" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox3, ControlProperty = "Value", DataObject = supply, ObjectProperty = "SellPrice" });
        }

        protected override void AfterValidate()
        {
            /*if (rMessageBox.ShowQuestion("ثبت موجودی قابل ویرایش یا حذف نیست. بنابراین اطلاعات آن باید کاملا صحیح و معتبر باشد. با اطلاع از این موضوع، آیا این اطلاعات صحیح است؟") != DialogResult.Yes)
            {
                CancelClosing();
                return;
            }*/
        }

        protected override void AfterBindToObject()
        {
            BuffetSupply supply = GetProcessingObject<BuffetSupply>();
            if (supply.SellPrice == 0)
            {
                rMessageBox.ShowError("قیمت فروش نمی تواند صفر باشد.");
                CancelClosing();
                return;
            }
            supply.Remainder = supply.Count;
        }

        private void frmBuffetSupplyDetail_Load(object sender, EventArgs e)
        {
            BuffetSupply supply = GetProcessingObject<BuffetSupply>();
            if (supply.Remainder != supply.Count)
            {
                rMessageBox.ShowWarning("امکان اصلاح موجودی نمی باشد، مقدار باقی مانده کمتر از موجودی اولیه است.");
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
