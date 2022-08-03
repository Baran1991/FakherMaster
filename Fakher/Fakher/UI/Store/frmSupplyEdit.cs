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
using rComponents;

namespace Fakher.UI.Store
{
    public partial class frmSupplyEdit : rRadDetailForm
    {
        public frmSupplyEdit()
        {
            InitializeComponent();
            rGridComboBox1.Columns.Add("نام کتاب", "نام کتاب", "Name");
            rGridComboBox1.DataSource = DbContext.GetAllEntities<EducationalTool>();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EducationalTool educationalTool = rGridComboBox1.GetValue<EducationalTool>();
//            educationalTool.EditSupply(rTxtAllCount.GetValue<int>(), 
//                                        rTxtCount.GetValue<int>(), 
//                                        rTxtBuyPrice.GetValue<long>(), 
//                                        rTxtSellPrice.GetValue<long>());
            educationalTool.Save();

            rMessageBox.ShowInformation(string.Format("تصحیح موجودی کالا انجام شد. موجودی فعلی این کالا {0} عدد است.",
                                                      educationalTool.Remainder));
            DialogResult = DialogResult.None;
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EducationalTool educationalTool = rGridComboBox1.GetValue<EducationalTool>();
            if(educationalTool == null)
                return;

            rTxtAllCount.Value = educationalTool.Count;
            rTxtCount.Value = educationalTool.Remainder;
            rTxtBuyPrice.Text = educationalTool.LastBuyPrice + "";
            rTxtSellPrice.Text = educationalTool.LastSellPrice + "";
        }
    }
}
