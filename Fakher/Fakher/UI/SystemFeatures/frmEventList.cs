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

namespace Fakher.UI.SystemFeatures
{
    public partial class frmEventList : rRadForm
    {
        public frmEventList()
        {
            InitializeComponent();

            rDatePicker1.Date = PersianDate.Today;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date", Width = 50});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان", ObjectProperty = "Time", Width = 20});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "عمل", ObjectProperty = "Operator" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "Description" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کاربر", ObjectProperty = "Actor" });
        }

        private void lnkShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IList<AppEvent> appEvents = AppEvent.GetEvents(rDatePicker1.Date);
            rGridView1.DataBind(appEvents);
        }
    }
}
