using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.Sentinel;
using rComponents;

namespace Fakher.UI.Financial
{
    public partial class frmReceiptSearch : rRadForm
    {
        public frmReceiptSearch()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره فیش", ObjectProperty = "ReceiptNumber" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Item.Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Item.Document.Person.FarsiFullname" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Item.Amount" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "بانک", ObjectProperty = "Item.BankAccount" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "Item.StatusText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "همکار دریافت کننده", ObjectProperty = "employee" });

        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.RecieptChangeStatus);
                Receipt receipt = rGridView1.GetSelectedObject<Receipt>();
                frmReceiptDetail frm = new frmReceiptDetail(receipt);
                if(!frm.ProcessObject())
                    return;
                receipt.Save();
                rGridView1.UpdateGridView();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void radBtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            string receiptNumber = rTextBox1.Text.Trim();
            rGridView1.Clear();
            if (string.IsNullOrEmpty(receiptNumber))
            {
                rMessageBox.ShowWarning("شماره فیش را وارد کنید");
                return;
            }

//            IList<Receipt> receipts = Receipt.FromNumber(receiptNumber);
            IList<Receipt> receipts = Receipt.Search(receiptNumber);
            if (receipts.Count > 0)
                rGridView1.DataBind(receipts);            
            else
            {
                rMessageBox.ShowWarning("فیش با این شماره پیدا نشد.");
                return;
            }
        }

        private void rTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search();
        }
    }
}
