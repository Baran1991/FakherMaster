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
using Fakher.UI.Educational.Students;
using rComponents;

namespace Fakher.UI.Store
{
    public partial class frmStorePanel : rRadForm
    {
        public frmStorePanel()
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;
            //IList<Major> majors = Student.GetRegisteredMajorsName(students);
            //IList<EducationalPeriod> periods = Student.GetRegisteredPeriodsName();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام پدر", ObjectProperty = "FarsiFatherName" });
            //rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "majors" });
            //rGridView1.Mappings.Add(new ColumnMapping { Caption = "دوره", ObjectProperty = "periods" });
            rGridView1.CustomButtons.Add(new rGridViewButton { VisibleOnSelect = true, Text = "لیست", Position = rGridViewButtonPosition.After });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFirstName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام پدر", ObjectProperty = "FarsiFatherName" });
            rGridView2.CustomButtons.Add(new rGridViewButton { VisibleOnSelect = true, Text = "لیست", Position = rGridViewButtonPosition.After });

            rGridView3.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFirstName" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "نام پدر", ObjectProperty = "FarsiFatherName" });
            rGridView3.CustomButtons.Add(new rGridViewButton { VisibleOnSelect = true, Text = "لیست", Position = rGridViewButtonPosition.After });

        }

        private void radBtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            DbContext.CurrentSession.Clear();

            string firstName = rTextBox1.Text;
            string lastName = rTextBox2.Text;

            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                rMessageBox.ShowError("نام یا نام خانوادگی را وارد کنید.");
                return;
            }
            IList<Student> students = Student.Search(firstName, lastName);
            IList<Teacher> teachers = Teacher.Search(firstName, lastName);
            IList<Employee> employees = Employee.Search(firstName, lastName);
            
            rGridView1.DataBind(students);
            rGridView2.DataBind(teachers);
            rGridView3.DataBind(employees);

            string studentsText = students.Count > 0 ? " (" + students.Count + ")" : "";
            string teacherText = teachers.Count > 0 ? " (" + teachers.Count + ")" : "";
            string employeesText = employees.Count > 0 ? " (" + employees.Count + ")" : "";

            radPageViewPage1.Text = "دانـــشــجـــــویــــان" + studentsText;
            radPageViewPage2.Text = "اســــاتــیـــد" + teacherText;
            radPageViewPage3.Text = "پــــــرســـنل" + employeesText;

            if (students.Count > 0)
                radPageView1.SelectedPage = radPageViewPage1;
            else if (teachers.Count > 0)
                radPageView1.SelectedPage = radPageViewPage2;
            else if (employees.Count > 0)
                radPageView1.SelectedPage = radPageViewPage3;
        }

        private void rTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search();
        }

        private void rTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search();
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            // Core.DomainModel.Person person = rGridView1.GetSelectedObject<Core.DomainModel.Person>();
            Core.DomainModel.Person person = rGridView1.GetSelectedObject<Core.DomainModel.Person>();
            frmSell frm = new frmSell(person);
            frm.ShowDialog(this);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = rGridView1.GetSelectedObject<Core.DomainModel.Person>();
            frmBorrow frm = new frmBorrow(person);
            frm.ShowDialog(this);
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = rGridView2.GetSelectedObject<Core.DomainModel.Person>();
            frmSell frm = new frmSell(person);
            frm.ShowDialog(this);
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = rGridView2.GetSelectedObject<Core.DomainModel.Person>();
            frmBorrow frm = new frmBorrow(person);
            frm.ShowDialog(this);
        }

        private void rGridView3_Edit(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = rGridView3.GetSelectedObject<Core.DomainModel.Person>();
            frmSell frm = new frmSell(person);
            frm.ShowDialog(this);
        }

        private void rGridView3_Delete(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = rGridView3.GetSelectedObject<Core.DomainModel.Person>();
            frmBorrow frm = new frmBorrow(person);
            frm.ShowDialog(this);
        }

        private void rGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            Core.DomainModel.Person person = rGridView1.GetSelectedObject<Core.DomainModel.Person>();
            if (e.ButtonIndex == 0)
            {
                frmPersonUseList frm = new frmPersonUseList(person);
                frm.ShowDialog(this);
            }
        }

        private void rGridView2_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            Core.DomainModel.Person person = rGridView2.GetSelectedObject<Core.DomainModel.Person>();
            if (e.ButtonIndex == 0)
            {
                frmPersonUseList frm = new frmPersonUseList(person);
                frm.ShowDialog(this);
            }
        }

        private void rGridView3_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            Core.DomainModel.Person person = rGridView3.GetSelectedObject<Core.DomainModel.Person>();
            if (e.ButtonIndex == 0)
            {
                frmPersonUseList frm = new frmPersonUseList(person);
                frm.ShowDialog(this);
            }
        }

        private void frmStorePanel_Load(object sender, EventArgs e)
        {

        }
    }
}
