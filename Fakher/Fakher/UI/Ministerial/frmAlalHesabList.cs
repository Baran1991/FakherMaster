using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Reports.Ministerial_Reports;
using Fakher.UI.Financial;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Ministerial
{
    public partial class frmAlalHesabList : rRadForm
    {
        public frmAlalHesabList(bool forTeacher, bool forEmployee)
        {
            InitializeComponent();

            rGridComboBox1.Columns.Add("نام", "نام", "FarsiFirstName");
            rGridComboBox1.Columns.Add("نام خانوادگی", "نام خانوادگی", "FarsiLastName");

            rGridView1.Mappings.Clear();
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "DescriptionText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Balance", AggregateSummary = AggregateSummary.Sum, Type = ColumnType.GroupedNumber, TextAlign = HorizontalAlignment.Left });


            if (forTeacher)
            {
                rGridComboBox1.DataSource = Teacher.GetActiveTeachers();
                this.Text = "پرداخت های علی الحساب مدرسین";
            }
            if (forEmployee)
            {
                rGridComboBox1.DataSource = Employee.GetActiveEmployees();
                this.Text = "پرداخت های علی الحساب پرسنل";
            }
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Staff staff = rGridComboBox1.GetValue<Staff>();
            if (staff == null)
                return;
            var items = staff.GetAlalHesabFinancialItems();
            if(items!=null)
            rGridView1.DataBind(items);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            if (rMessageBox.ShowQuestion("با انجام عمل حذف، پرداخت علی الحساب به طور کامل حذف خواهد شد. آیا مطمئن هستید؟") != DialogResult.Yes)
                return;
            var item = rGridView1.GetSelectedObject<FinancialItem>();
            item.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            var item = rGridView1.GetSelectedObject<FinancialItem>();
            frmFinancialItemDetail frm = new frmFinancialItemDetail(item);
            if (!frm.ProcessObject())
                return;
            item.Save();
            rGridView1.UpdateGridView();
        }
        private void rGridView1_Add(object sender, EventArgs e)
        {
            Staff staff = rGridComboBox1.GetValue<Staff>();
            var item = new FinancialItem();
            item.Heading = FinancialHeading.AlalHesab;
            item.Type = FinancialType.Credit;
            item.Person = staff;
            frmFinancialItemDetail frm = new frmFinancialItemDetail(item);
            
            if (!frm.ProcessObject())
                return;
            item.Save();
            rGridView1.Insert(item);
        }

        private void frmAlalHesabList_Load(object sender, EventArgs e)
        {

        }
    }
}
