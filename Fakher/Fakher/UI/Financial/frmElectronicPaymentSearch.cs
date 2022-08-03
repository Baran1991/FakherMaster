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
    public partial class frmElectronicPaymentSearch : rRadForm
    {
        public frmElectronicPaymentSearch()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره کارت", ObjectProperty = "CardNumber" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره پیگیری", ObjectProperty = "TraceNumber" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره تراکنش", ObjectProperty = "TransactionNumber" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Item.Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Item.Document.Person.FarsiFullname" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Item.Amount" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "بانک", ObjectProperty = "Item.BankAccount" });
           
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            try
            {
                
                ElectronicPayment receipt = rGridView1.GetSelectedObject<ElectronicPayment>();
            frmElectronicPaymentDetail frm = new frmElectronicPaymentDetail(receipt);
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
            string cardNumber = rTextBox1.Text.Trim();
            string transNumber = rTextBox2.Text.Trim();
            string traceNumber = rTextBox3.Text.Trim();
            rGridView1.Clear();
            if (string.IsNullOrEmpty(cardNumber)& string.IsNullOrEmpty(transNumber)& string.IsNullOrEmpty(traceNumber))
            {
                rMessageBox.ShowWarning("یکی از مقادیر را وارد کنید!");
                return;
            }

//            IList<Receipt> receipts = Receipt.FromNumber(receiptNumber);
            IList<ElectronicPayment> receipts = ElectronicPayment.Search(cardNumber,transNumber,traceNumber);
            if (receipts.Count > 0)
                rGridView1.DataBind(receipts);
            else
            {
                rMessageBox.ShowWarning(" پرداخت الکترونیکی پیدا نشد.");
                return;
            }
        }

        private void rTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    Search();
        }
    }
}
