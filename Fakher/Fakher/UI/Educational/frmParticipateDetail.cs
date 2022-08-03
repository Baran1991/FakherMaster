using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI
{
    public partial class frmParticipateDetail : rRadDetailForm
    {
        public frmParticipateDetail(Participate participate)
        {
            InitializeComponent();

            lblStudentName.Text = participate.Register.Student.FarsiFullname;
            pictureBoxStudent.Image = participate.Register.Student.Picture;
            lblDepartment.Text = Program.CurrentDepartment.Name;


            rGridComboBoxMajor.Columns.Add("نام رشته", "نام رشته", "Name");
            rGridComboBoxLesson.Columns.Add("نام درس", "نام درس", "Name");
            rGridComboBoxSection.Columns.Add("نام درس", "نام درس", "Name");
            rGridComboBoxSection.Columns.Add("ظرفیت باقیمانده", "ظرفیت باقیمانده", "RemainderCount");
            rGridComboBoxSection.Columns.Add("زمان تشکیل", "زمان تشکیل", "FormationText");

            rGridComboBoxMajor.DataSource = Program.CurrentDepartment.Majors;

            if (participate.Holding is Section)
            {
                rLblCode.Text = "شماره دانشجویی:";
            }

            ControlMappings.Add(new ControlMapping { Control = rGridComboBoxSection, ControlProperty = "Value", DataObject = participate, ObjectProperty = "Holding" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = participate, ObjectProperty = "RegisterCode" });

            rGridViewCash.Mappings.Add(new ColumnMapping{ Caption = "تاریخ", ObjectProperty = "Payment.Date"});
            rGridViewCash.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Amount" });

            rGridViewDiscount.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Payment.Title" });
            rGridViewDiscount.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Amount" });

            rGridViewReceipt.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Payment.Date" });
            rGridViewReceipt.Mappings.Add(new ColumnMapping { Caption = "شماره فیش", ObjectProperty = "Payment.ReceiptNumber" });
            rGridViewReceipt.Mappings.Add(new ColumnMapping { Caption = "مبلغ واریزی", ObjectProperty = "Amount" });

            rGridViewCheque.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Payment.Date" });
            rGridViewCheque.Mappings.Add(new ColumnMapping { Caption = "شماره چک", ObjectProperty = "Payment.ChequeNumber" });
            rGridViewCheque.Mappings.Add(new ColumnMapping { Caption = "مبلغ واریزی", ObjectProperty = "Amount" });
            rGridViewCheque.Mappings.Add(new ColumnMapping { Caption = "بانک", ObjectProperty = "Payment.BankName" });
            rGridViewCheque.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "Payment.StatusText" });

            rGridView5.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "DescriptionText" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "بدهکار", ObjectProperty = "DebtText" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "بستانکار", ObjectProperty = "CreditText" });

            rGridViewCash.DataBind(participate.FinancialDocument.GetPaymentItems<Cash>());
            rGridViewReceipt.DataBind(participate.FinancialDocument.GetPaymentItems<Receipt>());
            rGridViewCheque.DataBind(participate.FinancialDocument.GetPaymentItems<Cheque>());
            rGridViewDiscount.DataBind(participate.FinancialDocument.GetPaymentItems<Discount>());
            rGridView5.DataBind(participate.FinancialDocument.Items);
        }

        private void rGridViewCash_Add(object sender, EventArgs e)
        {
//            FinancialDocumentItem item = new FinancialDocumentItem(FinancialType.Credit);
            Cash cash = new Cash ();
//            item.Payment = cash;
            frmCashDetail frm = new frmCashDetail(cash);
            if(frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridViewCash.Insert(cash.DocumentItem);
            rGridView5.Insert(cash.DocumentItem);
        }

        private void rGridViewCash_Edit(object sender, EventArgs e)
        {
            FinancialDocumentItem item = rGridViewCash.GetSelectedObject<FinancialDocumentItem>();
            frmCashDetail frm = new frmCashDetail(item.Payment as Cash);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridViewCash.UpdateGridView();
            rGridView5.UpdateGridView();
        }

        private void rGridViewCash_Delete(object sender, EventArgs e)
        {
            FinancialDocumentItem item = rGridViewCash.GetSelectedObject<FinancialDocumentItem>();
            rGridViewCash.RemoveSelectedRow();
            rGridView5.Remove(item);
        }

        private void rGridViewReceipt_Add(object sender, EventArgs e)
        {
//            FinancialDocumentItem item = new FinancialDocumentItem(FinancialType.Credit);
            Receipt receipt = new Receipt();
            frmReceiptDetail frm = new frmReceiptDetail(receipt);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridViewReceipt.Insert(receipt.DocumentItem);
            rGridView5.Insert(receipt.DocumentItem);
        }

        private void rGridViewReceipt_Edit(object sender, EventArgs e)
        {
            FinancialDocumentItem item = rGridViewReceipt.GetSelectedObject<FinancialDocumentItem>();
            frmReceiptDetail frm = new frmReceiptDetail(item.Payment as Receipt);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridViewReceipt.UpdateGridView();
            rGridView5.UpdateGridView();
        }

        private void rGridViewReceipt_Delete(object sender, EventArgs e)
        {
            FinancialDocumentItem item = rGridViewReceipt.GetSelectedObject<FinancialDocumentItem>();
            rGridViewReceipt.RemoveSelectedRow();
            rGridView5.Remove(item);
        }

        private void rGridViewCheque_Add(object sender, EventArgs e)
        {
//            FinancialDocumentItem item = new FinancialDocumentItem(FinancialType.Credit);
            Cheque cheque = new Cheque();
            frmChequeDetail frm = new frmChequeDetail(cheque);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridViewCheque.Insert(cheque.DocumentItem);
            rGridView5.Insert(cheque.DocumentItem);
        }

        private void rGridViewCheque_Edit(object sender, EventArgs e)
        {
            FinancialDocumentItem item = rGridViewCheque.GetSelectedObject<FinancialDocumentItem>();
            frmChequeDetail frm = new frmChequeDetail(item.Payment as Cheque);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridViewCheque.UpdateGridView();
            rGridView5.UpdateGridView();
        }

        private void rGridViewCheque_Delete(object sender, EventArgs e)
        {
            FinancialDocumentItem item = rGridViewCheque.GetSelectedObject<FinancialDocumentItem>();
            rGridViewCheque.RemoveSelectedRow();
            rGridView5.Remove(item);
        }

        private void rGridViewDiscount_Add(object sender, EventArgs e)
        {
//            FinancialDocumentItem item = new FinancialDocumentItem(FinancialType.Credit);
            Discount discount = new Discount();
            frmDiscountDetail frm = new frmDiscountDetail(discount);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridViewDiscount.Insert(discount.DocumentItem);
            rGridView5.Insert(discount.DocumentItem);
        }

        private void rGridViewDiscount_Edit(object sender, EventArgs e)
        {
            FinancialDocumentItem item = rGridViewDiscount.GetSelectedObject<FinancialDocumentItem>();
            frmDiscountDetail frm = new frmDiscountDetail(item.Payment as Discount);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridViewDiscount.UpdateGridView();
            rGridView5.UpdateGridView();
        }

        private void rGridViewDiscount_Delete(object sender, EventArgs e)
        {
            FinancialDocumentItem item = rGridViewDiscount.GetSelectedObject<FinancialDocumentItem>();
            rGridViewDiscount.RemoveSelectedRow();
            rGridView5.Remove(item);
        }

        protected override void AfterValidate()
        {
            if(rGridView5.DataSource.Count == 0)
            {
                if(rMessageBox.ShowQuestion("اطلاعات مالی این دانشجو وارد نشده است. آیا مایل به ذخیره بدون اطلاعات مالی هستید ؟") != DialogResult.Yes)
                    CancelClosing();
            }
        }

        protected override void AfterBindToObject()
        {
            Participate participate = GetProcessingObject<Participate>();
            participate.FinancialDocument.Items.SyncWith(rGridView5.DataSource);
//            participate.Formations.AddRange(participate.Holding.Formations);

            participate.FinancialDocument.Items.Add(new FinancialDocumentItem(FinancialType.Debt) { Amount = participate.Holding.RegisterationFee, ItemDescription = string.Format("ثبت نام در {0} رشته {1}", participate.Holding.Name, participate.Holding.Major.Name) });

            if (participate.Holding.RemainderCount <= 0)
            {
                rMessageBox.ShowError("ظرفیت این کلاس پر شده است. بنابراین امکان ثبت نام در این کلاس وجود ندارد.");
                CancelClosing();
            }
        }

        private void rGridComboBoxMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Major major = rGridComboBoxMajor.GetValue<Major>();

            rGridComboBoxSection.DataSource = null;
            rGridComboBoxLesson.DataSource = major.Lessons;
        }

        private void rGridComboBoxLesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lesson lesson = rGridComboBoxLesson.GetValue<Lesson>();
            rGridComboBoxSection.DataSource = Section.GetSections(Program.CurrentPeriod, lesson);
        }
    }
}
