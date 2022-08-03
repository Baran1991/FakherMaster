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

namespace Fakher.UI.Person
{
    public partial class frmEmployeeList : rRadForm
    {
        public frmEmployeeList()
        {
            InitializeComponent();

            rPageView1.SelectedPage = radPageViewPage1;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Id" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره پرونده پرسنلی", ObjectProperty = "Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام کاربری", ObjectProperty = "UserInfo.GetRawUsername()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "آخرین ورود", ObjectProperty = "UserInfo.LastSigninDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "گروه کاربری", ObjectProperty = "UserInfo.AccessGroup.Name" });
            rGridView1.CustomButtons.Add(new rGridViewButton { Text = "بازنشانی ورود", VisibleOnSelect = true, Position = rGridViewButtonPosition.After });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Id" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره پرونده پرسنلی", ObjectProperty = "Code" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFirstName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام کاربری", ObjectProperty = "UserInfo.GetRawUsername()" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "آخرین ورود", ObjectProperty = "UserInfo.LastSigninDate" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "گروه کاربری", ObjectProperty = "UserInfo.AccessGroup.Name" });

            Fill();
        }

        private void Fill()
        {
            rGridView1.DataBind(Employee.GetActiveEmployees());
            rGridView2.DataBind(Employee.GetAllEmployees());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            frmPersonDetail frm = new frmPersonDetail(employee);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            employee.Code = Core.DomainModel.Person.GetNextCode<Employee>();
            employee.Save();
            rGridView1.Insert(employee);
            rMessageBox.ShowInformation(string.Format("پرسنل [{0}] با شماره پرونده [{1}] ثبت گردید.", employee.FarsiFullname, employee.Code));
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Employee employee = rGridView1.GetSelectedObject<Employee>();
            employee.RefreshEntity();

            frmPersonDetail frm = new frmPersonDetail(employee);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            employee.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Employee employee = rGridView1.GetSelectedObject<Employee>();

            employee.Disabled = true;
            employee.Save();
            
            Fill();

            rMessageBox.ShowInformation("پرسنل غیرفعال شد.");
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Employee employee = rGridView2.GetSelectedObject<Employee>();
            employee.RefreshEntity();

            frmPersonDetail frm = new frmPersonDetail(employee);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            employee.Save();
            rGridView2.UpdateGridView();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            Employee employee = rGridView2.GetSelectedObject<Employee>();

            employee.Disabled = false;
            employee.Save();

            Fill();

            rMessageBox.ShowInformation("پرسنل فعال شد.");
        }

        private void rGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            Employee employee = rGridView1.GetSelectedObject<Employee>();
            if (e.ButtonIndex == 0)
            {
                employee.UserInfo.Signin("127.0.0.1");
                employee.UserInfo.Save();
            }
            rMessageBox.ShowInformation("ورود پرسنل بازنشانی شد.");
        } 
    }
}
