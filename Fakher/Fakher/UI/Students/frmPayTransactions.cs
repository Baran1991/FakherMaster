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

namespace Fakher.UI.Students
{
    public partial class frmPayTransactions : rRadForm
    {
        public frmPayTransactions(Register register)
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ شروع تراکنش", ObjectProperty = "StartDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان شروع تراکنش", ObjectProperty = "StartTime" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ تایید تراکنش", ObjectProperty = "ConfirmDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان تایید تراکنش", ObjectProperty = "ConfirmTime" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شــرح", ObjectProperty = "Description" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Amount", Type = ColumnType.Money});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText"});

            IList<PayTransaction> transactions = register.FinancialDocument.GetPayTransactions();
//            List<FinancialItem> items = new List<FinancialItem>();
//            foreach (FinancialDocument document in student.FinancialDocuments)
//            {
//                foreach (FinancialItem item in document.Items)
//                {
//                    if(item.Payment is ElectronicPayment)
//                    {
//                        ElectronicPayment payment = item.Payment as ElectronicPayment;
//                        items.Add(item);
//                    }
//                }
//            }

            rGridView1.DataBind(transactions);
        }
    }
}
