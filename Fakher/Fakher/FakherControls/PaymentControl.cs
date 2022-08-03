using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI;
using Fakher.UI.Financial;
using rComponents;

namespace Fakher.Controls
{
    public partial class PaymentControl : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private FinancialDocument mRawDocument;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private FinancialDocument mLocalDocument;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private FinancialHeading mHeading;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList DataSource
        {
            get { return rGridView5.DataSource; }
        }

        public bool ShowCash { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        public PaymentControl()
        {
            InitializeComponent();

            mLocalDocument = new FinancialDocument();

            rGridViewCash.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Payment.Date" });
            rGridViewCash.Mappings.Add(new ColumnMapping { Caption = "شماره سند داخلی", ObjectProperty = "Payment.InternalDocumentNumber" });
            rGridViewCash.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Amount", Type = ColumnType.Money, AggregateSummary = AggregateSummary.Sum });

            rGridViewDiscount.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Payment.Title" });
            rGridViewDiscount.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Amount", Type = ColumnType.Money, AggregateSummary = AggregateSummary.Sum });

            rGridViewReceipt.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Payment.Date" });
            rGridViewReceipt.Mappings.Add(new ColumnMapping { Caption = "شماره فیش", ObjectProperty = "Payment.ReceiptNumber" });
            rGridViewReceipt.Mappings.Add(new ColumnMapping { Caption = "بانک", ObjectProperty = "BankAccount" });
            rGridViewReceipt.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Amount", Type = ColumnType.Money, AggregateSummary = AggregateSummary.Sum });

            rGridViewCheque.Mappings.Add(new ColumnMapping { Caption = "تاریخ سررسید", ObjectProperty = "Payment.Date" });
            rGridViewCheque.Mappings.Add(new ColumnMapping { Caption = "شماره چک", ObjectProperty = "Payment.ChequeNumber" });
            rGridViewCheque.Mappings.Add(new ColumnMapping { Caption = "بانک", ObjectProperty = "Payment.BankName" });
            rGridViewCheque.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "Payment.StatusText" });
            rGridViewCheque.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Amount", Type = ColumnType.Money, AggregateSummary = AggregateSummary.Sum });

            rGridViewEPayments.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Payment.Date" });
            rGridViewEPayments.Mappings.Add(new ColumnMapping { Caption = "توضیحات", ObjectProperty = "Payment.Description" });
            rGridViewEPayments.Mappings.Add(new ColumnMapping { Caption = "بانک", ObjectProperty = "BankAccount" });
            rGridViewEPayments.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Amount", Type = ColumnType.Money, AggregateSummary = AggregateSummary.Sum });

            rGridView5.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "DescriptionText" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "بدهکار", ObjectProperty = "DebtText" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "بستانکار", ObjectProperty = "CreditText" });

            CanAdd = true;
            CanEdit = true;
            CanDelete = true;
        }

        public void Databind(FinancialDocument document,FinancialHeading heading)
        {
            mRawDocument = document;
            mHeading = heading;
            AddItems(document.Items);
        }

        public void AddItems(IList<FinancialItem> items)
        {
            foreach (FinancialItem item in items)
                AddItem(item);
        }

        public void AddItem(FinancialItem item)
        {
            if (item.Payment is Cash)
                rGridViewCash.Insert(item);
            if (item.Payment is Receipt)
                rGridViewReceipt.Insert(item);
            if (item.Payment is Cheque)
                rGridViewCheque.Insert(item);
            if (item.Payment is ElectronicPayment)
                rGridViewEPayments.Insert(item);
            if (item.Payment is Discount)
                rGridViewDiscount.Insert(item);
            rGridView5.Insert(item);
            mLocalDocument.Items.Add(item);
            UpdateBottomBar();
        }

        public void UpdateGrids()
        {
            rGridViewCash.UpdateGridView();
            rGridViewReceipt.UpdateGridView();
            rGridViewCheque.UpdateGridView();
            rGridViewEPayments.UpdateGridView();
            rGridViewDiscount.UpdateGridView();
            rGridView5.UpdateGridView();
            UpdateBottomBar();
        }

        public void RemoveItem(FinancialItem item)
        {
            if (item.Payment is Cash)
                rGridViewCash.Remove(item);
            if (item.Payment is Receipt)
                rGridViewReceipt.Remove(item);
            if (item.Payment is Cheque)
                rGridViewCheque.Remove(item);
            if (item.Payment is ElectronicPayment)
                rGridViewEPayments.Remove(item);
            if (item.Payment is Discount)
                rGridViewDiscount.Remove(item);
            rGridView5.Remove(item);
            mLocalDocument.Items.Remove(item);
            UpdateBottomBar();
        }

        public void BindToObject()
        {
            mRawDocument.Items.SyncWith(rGridView5.DataSource);
            //            Document.Items.SyncWith(rGridViewCash.DataSource);
            //            Document.Items.SyncWith(rGridViewReceipt.DataSource);
            //            Document.Items.SyncWith(rGridViewCheque.DataSource);
            //            Document.Items.SyncWith(rGridViewEPayments.DataSource);
            //            Document.Items.SyncWith(rGridViewDiscount.DataSource);
        }

        private void rGridViewCash_Add(object sender, EventArgs e)
        {
            Cash cash = new Cash();
            frmCashDetail frm = new frmCashDetail(cash);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            cash.Item.Heading = mHeading;
            AddItem(cash.Item);
//            rGridViewCash.Insert(cash.Item);
//            rGridView5.Insert(cash.Item);
        }

        private void rGridViewCash_Edit(object sender, EventArgs e)
        {
            FinancialItem item = rGridViewCash.GetSelectedObject<FinancialItem>();
            frmCashDetail frm = new frmCashDetail(item.Payment as Cash);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            UpdateGrids();
//            rGridViewCash.UpdateGridView();
//            rGridView5.UpdateGridView();
        }

        private void rGridViewCash_Delete(object sender, EventArgs e)
        {
            FinancialItem item = rGridViewCash.GetSelectedObject<FinancialItem>();
            RemoveItem(item);
//            rGridViewCash.RemoveSelectedRow();
//            rGridView5.Remove(item);
        }

        private void rGridViewReceipt_Add(object sender, EventArgs e)
        {
            Receipt receipt = new Receipt();
            frmReceiptDetail frm = new frmReceiptDetail(receipt);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            receipt.Item.Heading = mHeading;
            AddItem(receipt.Item);
//            rGridViewReceipt.Insert(receipt.Item);
//            rGridView5.Insert(receipt.Item);
        }

        private void rGridViewReceipt_Edit(object sender, EventArgs e)
        {
            FinancialItem item = rGridViewReceipt.GetSelectedObject<FinancialItem>();
            frmReceiptDetail frm = new frmReceiptDetail(item.Payment as Receipt);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            UpdateGrids();
//            rGridViewReceipt.UpdateGridView();
//            rGridView5.UpdateGridView();
        }

        private void rGridViewReceipt_Delete(object sender, EventArgs e)
        {
            FinancialItem item = rGridViewReceipt.GetSelectedObject<FinancialItem>();
            RemoveItem(item);
//            rGridViewReceipt.RemoveSelectedRow();
//            rGridView5.Remove(item);
        }

        private void rGridViewEPayments_Add(object sender, EventArgs e)
        {
            ElectronicPayment electronicPayment = new ElectronicPayment();
            frmElectronicPaymentDetail frm = new frmElectronicPaymentDetail(electronicPayment);
            if (!frm.ProcessObject())
                return;
            electronicPayment.Item.Heading = mHeading;
            AddItem(electronicPayment.Item);
//            rGridViewEPayments.Insert(electronicPayment.Item);
//            rGridView5.Insert(electronicPayment.Item);
        }

        private void rGridViewEPayments_Edit(object sender, EventArgs e)
        {
            FinancialItem item = rGridViewEPayments.GetSelectedObject<FinancialItem>();
            ElectronicPayment electronicPayment = item.Payment as ElectronicPayment;
            frmElectronicPaymentDetail frm = new frmElectronicPaymentDetail(electronicPayment);
            if (!frm.ProcessObject())
                return;
            UpdateGrids();
//            rGridViewEPayments.UpdateGridView();
//            rGridView5.UpdateGridView();
        }

        private void rGridViewEPayments_Delete(object sender, EventArgs e)
        {
            FinancialItem item = rGridViewEPayments.GetSelectedObject<FinancialItem>();
            RemoveItem(item);
//            rGridViewEPayments.RemoveSelectedRow();
//            rGridView5.Remove(item);
        }

        private void rGridViewCheque_Add(object sender, EventArgs e)
        {
            Cheque cheque = new Cheque();
            frmChequeDetail frm = new frmChequeDetail(cheque);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            cheque.Item.Heading = mHeading;
            AddItem(cheque.Item);
//            rGridViewCheque.Insert(cheque.Item);
//            rGridView5.Insert(cheque.Item);
        }

        private void rGridViewCheque_Edit(object sender, EventArgs e)
        {
            FinancialItem item = rGridViewCheque.GetSelectedObject<FinancialItem>();
            frmChequeDetail frm = new frmChequeDetail(item.Payment as Cheque);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            UpdateGrids();
//            rGridViewCheque.UpdateGridView();
//            rGridView5.UpdateGridView();
        }

        private void rGridViewCheque_Delete(object sender, EventArgs e)
        {
            FinancialItem item = rGridViewCheque.GetSelectedObject<FinancialItem>();
            RemoveItem(item);
//            rGridViewCheque.RemoveSelectedRow();
//            rGridView5.Remove(item);
        }

        private void rGridViewDiscount_Add(object sender, EventArgs e)
        {
            Discount discount = new Discount();
            frmDiscountDetail frm = new frmDiscountDetail(discount);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            discount.Item.Heading = mHeading;
            AddItem(discount.Item);
//            rGridViewDiscount.Insert(discount.Item);
//            rGridView5.Insert(discount.Item);
        }
        //private void rGridViewDiscount_Add(object sender, EventArgs e)
        //{
        //    Discount discount = new Discount();
        //    frmDiscountDetail frm = new frmDiscountDetail(discount);
        //    if (frm.ShowDialog(this) != DialogResult.OK)
        //        return;
        //    discount.Item.Heading = mHeading;
        //    AddItem(discount.Item);
        //    //            rGridViewDiscount.Insert(discount.Item);
        //    //            rGridView5.Insert(discount.Item);
        //}
        private void rGridViewDiscount_Edit(object sender, EventArgs e)
        {
            FinancialItem item = rGridViewDiscount.GetSelectedObject<FinancialItem>();
            frmDiscountDetail frm = new frmDiscountDetail(item.Payment as Discount);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            UpdateGrids();
//            rGridViewDiscount.UpdateGridView();
//            rGridView5.UpdateGridView();
        }

        private void rGridViewDiscount_Delete(object sender, EventArgs e)
        {
            FinancialItem item = rGridViewDiscount.GetSelectedObject<FinancialItem>();
            RemoveItem(item);
//            rGridViewDiscount.RemoveSelectedRow();
//            rGridView5.Remove(item);
        }

        private void FinancialDocumentControl_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            radPageView2.SelectedPage = radPageViewReceipt;

            radPageView2.Pages.Remove(radPageViewPage1);
            if (!ShowCash)
                radPageView2.Pages.Remove(radPageViewCash);

            rGridViewCash.CanAdd =
                rGridViewDiscount.CanAdd =
                rGridViewReceipt.CanAdd =
                rGridViewCheque.CanAdd =
                rGridViewEPayments.CanAdd = CanAdd;

            rGridViewCash.CanEdit = rGridViewDiscount.CanEdit = rGridViewReceipt.CanEdit =
                                                              rGridViewCheque.CanEdit =
                                                              rGridViewEPayments.CanEdit = CanEdit;

            rGridViewCash.CanDelete = rGridViewDiscount.CanDelete = rGridViewReceipt.CanDelete =
                                                              rGridViewCheque.CanDelete =
                                                              rGridViewEPayments.CanDelete = CanDelete;
            rGridViewCash.UpdateTopToolbar();
            rGridViewDiscount.UpdateTopToolbar();
            rGridViewReceipt.UpdateTopToolbar();
            rGridViewCheque.UpdateTopToolbar();
            rGridViewEPayments.UpdateTopToolbar();
            UpdateBottomBar();
        }

        private void UpdateBottomBar()
        {
            radLabelElement3.Text = "جــمـــع پـــــرداخــــت: " + mLocalDocument.PayedBalance.ToString("C0");
            radLabelElement1.Text = "جــمـــع تــخــفــیــــف: " + mLocalDocument.DiscountBalance.ToString("C0");
        }
    }
}
