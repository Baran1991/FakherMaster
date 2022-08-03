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
    public partial class frmChequeSendingDates : rRadForm
    {
        public frmChequeSendingDates()
        {
        
            InitializeComponent();
            ChequeStatus status = ChequeStatus.SentToBank;
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره چک", ObjectProperty = "ChequeNumber" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ ارسال به بانک", ObjectProperty = "SendingtoBankDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "بانک ارسالی", ObjectProperty = "SendingtoBankName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "همکار دریافت کننده چک", ObjectProperty = "employee" });
            rGridView1.CustomButtons.Add(new rGridViewButton { Text = "چاپ رسید", VisibleOnSelect = true, Position = rGridViewButtonPosition.Before });
            rGridView1.CustomButtonClick += rGridView1_CustomButtonClick;
            List<Cheque> cheques = Cheque.GetSendingTobankCheques(status).Distinct().ToList();
            rGridView1.DataBind(cheques);
        }

        private void rGridView1_CustomButtonClick(object sender, EventArgs e)
        {
            if (rGridView1.GetCheckedObjects<object>().Count == 0)
            {
                rMessageBox.ShowWarning("چکهای مورد نظر را انتخاب نمایید.");
            }
            var items = rGridView1.GetCheckedObjects<Cheque>();
            rptChequeListSendingDates rpt = new rptChequeListSendingDates();
            rpt.fItems = items;
            rpt.ReportName = "لیست چک های ارسالی به بانک در تاریخ   " + items[0].SendingtoBankDate+"توسط  "+items[0].employee;
            rpt.PrepareDataset(null);
            rpt.Apply(null);
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }
    }
    
}
