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
using Fakher.Core.Sentinel;
using rComponents;

namespace Fakher.UI.Financial
{
    public partial class frmTodayChequeList : rRadForm
    {
        public frmTodayChequeList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره چک", ObjectProperty = "ChequeNumber" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ سررسید", ObjectProperty = "Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Item.Document.Person.FarsiFullname" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Item.Amount" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "بانک", ObjectProperty = "BankName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGroupBox1.Text = "سررسید چک: " + PersianDate.Today;
            var list = Cheque.GetCheques(PersianDate.Today, PersianDate.Today);

            rGridView1.DataBind(list);
        }

        

       
    }
}
