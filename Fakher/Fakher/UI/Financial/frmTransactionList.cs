using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rComponents;

namespace Fakher.UI.Financial
{
    public partial class frmTransactionList : rRadForm
    {
        public frmTransactionList(Core.DomainModel.Person person)
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "DescriptionText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "بدهکار", ObjectProperty = "DebtText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "بستانکار", ObjectProperty = "CreditText" });

            rGridView1.DataBind(person.GetAllFinancialItems());
            rGroupBox1.HeaderText = "لیست تراکنش های " + person.FarsiFullname;
        }
    }
}
