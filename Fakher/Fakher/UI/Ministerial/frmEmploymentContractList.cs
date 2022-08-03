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
using rComponents;

namespace Fakher.UI.Ministerial
{
    public partial class frmEmploymentContractList : rRadForm
    {
        public frmEmploymentContractList()
        {
            InitializeComponent();

            rGridComboBox1.Columns.Add("نام", "نام", "FarsiFullname");
//            rGridComboBox1.Columns.Add("نام خانوادگی", "نام خانوادگی", "FarsiLastName");

//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کد", ObjectProperty = "Id" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ترم", ObjectProperty = "Period.Name" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نوع قرارداد", ObjectProperty = "PaymentSystemText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ شروع", ObjectProperty = "StartDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ پایان", ObjectProperty = "EndDate" });

            rGridComboBox1.DataSource = Employee.GetActiveEmployees();
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Employee employee = rGridComboBox1.GetValue<Employee>();
            if (employee == null)
                return;

            EmploymentContract contract = new EmploymentContract
                                            {
                                                Staff = employee,
                                                StartDate = Program.CurrentPeriod.StartDate,
                                                EndDate = Program.CurrentPeriod.EndDate
                                            };
            frmEmploymentContractDetail frm = new frmEmploymentContractDetail(contract);
            if(!frm.ProcessObject())
                return;
            contract.Save();
            rGridView1.Insert(contract);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            EmploymentContract contract = rGridView1.GetSelectedObject<EmploymentContract>();
            contract.RefreshEntity();

            frmEmploymentContractDetail frm = new frmEmploymentContractDetail(contract);
            if (!frm.ProcessObject())
                return;
            contract.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            EmploymentContract contract = rGridView1.GetSelectedObject<EmploymentContract>();
            contract.Staff.Contracts.Remove(contract);
            contract.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee employee = rGridComboBox1.GetValue<Employee>();
            rGridView1.Clear();
            if (employee == null)
                return;
            employee.RefreshEntity();
            rGridView1.DataBind(employee.Contracts);
        }
    }
}
