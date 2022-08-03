using DataAccessLayer;
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
using Fakher.Reports;
using rComponents;
using Fakher.UI.Report;

namespace Fakher.UI.Financial
{
    public partial class frmReceiptSendingDates : rRadForm
    {
        //private Cheque selectedCheque;
        //public frmChequeSendingDates(Cheque cheque)
        public frmReceiptSendingDates()
        {        
            InitializeComponent();
            ReceiptStatus status = ReceiptStatus.SentToBank;
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره فیش", ObjectProperty = "ReceiptNumber" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ ارسال به بانک", ObjectProperty = "SendingtoBankDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "بانک ارسالی", ObjectProperty = "SendingtoBankName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "همکار دریافت کننده فیش", ObjectProperty = "employee" });
            rGridView1.CustomButtons.Add(new rGridViewButton { Text = "چاپ رسید", VisibleOnSelect = true, Position = rGridViewButtonPosition.Before });
            rGridView1.CustomButtonClick += rGridView1_CustomButtonClick;

            List<Receipt> receipt = Receipt.GetSendingTobankReceipt(status).ToList();
            rGridView1.DataBind(receipt);
        }      

        private void rGridView1_CustomButtonClick(object sender, EventArgs e)
        {
            if (rGridView1.GetCheckedObjects<object>().Count == 0)
            {
                rMessageBox.ShowWarning("فیش های مورد نظر را انتخاب نمایید.");
            }
            var items = rGridView1.GetCheckedObjects<Receipt>();
            rptReceiptListSendingDates rpt = new rptReceiptListSendingDates();
            rpt.fItems = items;
            rpt.ReportName = "لیست فیش های ارسالی به بانک در تاریخ   " + items[0].SendingtoBankDate + "توسط  " + items[0].employee;
            rpt.PrepareDataset(null);
            rpt.Apply(null);
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }
    }
}
