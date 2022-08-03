using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Buffet;
using rComponents;

namespace Fakher.UI.Store
{
    public partial class frmEducationalToolSupplyDetail : rRadDetailForm
    {
        public frmEducationalToolSupplyDetail(EducationalToolSupply supply)
        {
            InitializeComponent();

            SetProcessingObject(supply);

            ControlMappings.Add(new ControlMapping { Control = rTxtBillNo, ControlProperty = "Value", DataObject = supply, ObjectProperty = "BillNo" });
            ControlMappings.Add(new ControlMapping { Control = rTxtCount, ControlProperty = "Value", DataObject = supply, ObjectProperty = "Count" });
            ControlMappings.Add(new ControlMapping { Control = rTxtRemainder, ControlProperty = "Value", DataObject = supply, ObjectProperty = "Remainder" });
            ControlMappings.Add(new ControlMapping { Control = rTxtBuyPrice, ControlProperty = "Value", DataObject = supply, ObjectProperty = "BuyPrice" });
            ControlMappings.Add(new ControlMapping { Control = rTxtSellPrice, ControlProperty = "Value", DataObject = supply, ObjectProperty = "SellPrice" });
        }


        protected override void AfterValidate()
        {
            EducationalToolSupply supply = GetProcessingObject<EducationalToolSupply>();
            supply.Remainder = supply.Count;
            if (rTxtCount.GetValue<int>() == 0)
            {
                rMessageBox.ShowError("تعداد کل نمی تواند صفر باشد.");
                CancelClosing();
                return;
            }
            //if (rTxtRemainder.GetValue<int>() == 0)
            //{
            //    rMessageBox.ShowError("تعداد باقیمانده نمی تواند صفر باشد.");
            //    CancelClosing();
            //    return;
            //}
            if (rTxtSellPrice.GetValue<int>() == 0)
            {
                rMessageBox.ShowError("قیمت فروش نمی تواند صفر باشد.");
                CancelClosing();
                return;
            }
            //if (rTxtCount.GetValue<int>() < rTxtRemainder.GetValue<int>())
            //{
            //    rMessageBox.ShowError("تعداد کل از باقیمانده کمتر است.");
            //    CancelClosing();
            //    return;
            //}
        }

        protected override void AfterBindToObject()
        {
            EducationalToolSupply supply = GetProcessingObject<EducationalToolSupply>();
        }

        private void frmEducationalToolSupplyDetail_Load(object sender, EventArgs e)
        {
            EducationalToolSupply supply = GetProcessingObject<EducationalToolSupply>();
//            if (supply.Remainder != supply.Count)
//            {
//                rMessageBox.ShowWarning("به دلیل اینکه از این پارت، تعدادی کالا فروخته شده است، اصلاح موجودی امکان پذیر نمی باشد.");
//                DialogResult = DialogResult.Cancel;
//            }
        }
    }
}
