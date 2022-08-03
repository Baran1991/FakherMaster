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
using Fakher.Reports;
using DataAccessLayer;
using Fakher.UI.Report;

namespace Fakher.UI.Financial
{
    public partial class frmChequeSearch : rRadForm
    {
        public frmChequeSearch()
        {
            InitializeComponent();
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره چک", ObjectProperty = "ChequeNumber" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ سررسید", ObjectProperty = "Item.Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Item.Document.Person.FarsiFullname" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Item.Amount" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "بانک", ObjectProperty = "BankName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "همکار دریافت کننده", ObjectProperty = "employee"});
            rGridView1.CustomButtons.Add(new rGridViewButton { Text = "چاپ رسید عودت", VisibleOnSelect = true, Position = rGridViewButtonPosition.Before });
            rGridView1.CustomButtonClick += rGridView1_CustomButtonClick;

        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            ChequeStatus sentToBank = ChequeStatus.SentToBank;
            ChequeStatus returned = ChequeStatus.Returned;
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.ChequeChangeStatus);
                Cheque cheque = rGridView1.GetSelectedObject<Cheque>();

                
            frmChequeDetail frm = new frmChequeDetail(cheque);
            if(!frm.ProcessObject())
                return;
                if(cheque.Status== sentToBank && cheque.SendingtoBankDate==null)
                    cheque.SendingtoBankDate = PersianDate.Today;
                if (cheque.Status == returned && cheque.ReturningDate==null)
                    cheque.ReturningDate = PersianDate.Today;
                cheque.Save();
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
            string chequeNumber = rTextBox1.Text.Trim();
            rGridView1.Clear();
            if (string.IsNullOrEmpty(chequeNumber))
            {
                rMessageBox.ShowWarning("شماره چک را وارد کنید");
                return;
            }

//            IList<Cheque> cheques = Cheque.FromNumber(chequeNumber);
            IList<Cheque> cheques = Cheque.Search(chequeNumber);
            if (cheques.Count > 0)
                rGridView1.DataBind(cheques);
            else
            {
                rMessageBox.ShowWarning("چکی با این شماره پیدا نشد.");
                return;
            }
        }

        private void rTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search();
        }

        private void rGridView1_CustomButtonClick(object sender, EventArgs e)
        {
            var items = rGridView1.GetCheckedObjects<Cheque>();
            if (rGridView1.GetCheckedObjects<object>().Count == 0)
            {
                rMessageBox.ShowWarning("جهت چاپ رسید عودت لطفا چک مورد نظر را انتخاب نمایید.");
            }
            
            rptChequeListReturningDates rpt = new rptChequeListReturningDates();
            rpt.fItems = items;
            rpt.ReportName = " رسید تحویل چک به  "  + items[0].employee+" جهت عودت به ذینفع در تاریخ"+ items[0].SendingtoBankDate;
            rpt.PrepareDataset(null);
            rpt.Apply(null);
            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }
    }
}
