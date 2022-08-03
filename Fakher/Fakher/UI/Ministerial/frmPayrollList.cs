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
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Ministerial
{
    public partial class frmPayrollList : rRadForm
    {
        public frmPayrollList(bool forTeacher, bool forEmployee)
        {
            InitializeComponent();

            rGridComboBox1.Columns.Add("نام", "نام", "FarsiFirstName");
            rGridComboBox1.Columns.Add("نام خانوادگی", "نام خانوادگی", "FarsiLastName");

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کد فیش حقوقی", ObjectProperty = "Id" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "قرارداد", ObjectProperty = "MajorText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ شروع", ObjectProperty = "StartDate", TextAlign = HorizontalAlignment.Center});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ پایان", ObjectProperty = "EndDate", TextAlign = HorizontalAlignment.Center });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ قابل پرداخت", ObjectProperty = "PayableAmount", Type = ColumnType.Money});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ پرداخت شده", ObjectProperty = "PaidAmount", Type = ColumnType.Money });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت حساب", ObjectProperty = "PaymentStatus"});

            rGridView1.CustomButtons.Add(new rGridViewButton{VisibleOnSelect = true, Position = rGridViewButtonPosition.Before, Text = "مشاهده فیش"});
            rGridView1.CustomButtons.Add(new rGridViewButton { VisibleOnSelect = true, Position = rGridViewButtonPosition.Before, Text = "پرداختی ها" });

            if (forTeacher)
                rGridComboBox1.DataSource = Teacher.GetActiveTeachers();
            if (forEmployee)
                rGridComboBox1.DataSource = Employee.GetActiveEmployees();
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Staff staff = rGridComboBox1.GetValue<Staff>();
            if (staff == null)
                return;
            rGridView1.DataBind(staff.Payrolls);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            if (rMessageBox.ShowQuestion("با انجام عمل حذف، فیش به طور کامل حذف خواهد شد. آیا مطمئن هستید؟") != DialogResult.Yes)
                return;
            Payroll payroll = rGridView1.GetSelectedObject<Payroll>();
            payroll.Staff.Payrolls.Remove(payroll);
            payroll.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Payroll payroll = rGridView1.GetSelectedObject<Payroll>();
            frmPayrollDetail frm = new frmPayrollDetail(payroll);
            if (!frm.ProcessObject())
                return;
            payroll.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            Payroll payroll = rGridView1.GetSelectedObject<Payroll>();
            if (payroll == null)
                return;
            if (e.ButtonIndex == 0)
            {
                rptPayrollReceipt rpt = new rptPayrollReceipt();
                rpt.Fill(payroll);
                rpt.DataSource = new[] { payroll };
                frmReportViewer frmViewer = new frmReportViewer(rpt) { CanPrint = false };
                frmViewer.ShowDialog(this);
            }
            else
            {
                frmPaidList frm = new frmPaidList(payroll);
                frm.ShowDialog();
                rGridView1.UpdateGridView();
            }
        }
    }
}
