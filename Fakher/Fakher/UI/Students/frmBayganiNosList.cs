using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fakher.UI.Persons
{
    public partial class frmBayganiNosList : rRadForm
    {
        public frmBayganiNosList()
        {
            InitializeComponent();
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Code" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "دوره ", ObjectProperty = "Period.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام کاربر ثبت نام کننده", ObjectProperty = "Registrar" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت نام", ObjectProperty = "RegisterDate" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره بایگانی", ObjectProperty = "Student.BayganiNo" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ بایگانی", ObjectProperty = "Student.BayganiDate" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "اپراتور", ObjectProperty = "Student.BayganiCreatedBy" });
                    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersianDate date1 = rDatePicker1.Date;
            PersianDate date2 = rDatePicker2.Date;
            if (date1 == null | date2 == null)
            {
                rMessageBox.ShowError("تاریخ را وارد کنید.");
                return;
            }
            if (rComboBox1.SelectedIndex == 0)
            {
                var list = DbContext.Entity<Register>().Where(m => m.Student.BayganiDate <= date2 && m.Student.BayganiDate >= date1);
                rGridView2.DataBind(list);
            }
           else if (rComboBox1.SelectedIndex == 1)
            {
                var list = DbContext.Entity<Register>().Where(m => m.Student.BayganiDate <= date2 && m.Student.BayganiDate >= date1 && m.Student.BayganiNo > 0);
                rGridView2.DataBind(list);
            }
            else if (rComboBox1.SelectedIndex == 2)
            {
                var list = DbContext.Entity<Register>().Where(m => m.Student.BayganiDate <= date2 && m.Student.BayganiDate >= date1 && (m.Student.BayganiNo == 0 || m.Student.BayganiNo < 1000));
                rGridView2.DataBind(list);
            }
        }
    }
}
