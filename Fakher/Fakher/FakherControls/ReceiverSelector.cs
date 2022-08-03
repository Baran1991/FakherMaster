using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.UI;
using rComponents;

namespace Fakher.Controls
{
    public partial class ReceiverSelector : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Department> SelectedDepartments { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Person> SelectedPersons { get; set; }

        public bool SelectDepartment { get; set; }
        public bool SelectEmployee { get; set; }
        public bool SelectTeacher { get; set; }

        public ReceiverSelector()
        {
            InitializeComponent();
            SelectedDepartments = new List<Department>();
            SelectedPersons = new List<Person>();
            SelectDepartment = SelectEmployee = SelectTeacher = true;
        }

        public bool HasReciever
        {
            get { return SelectedDepartments.Count > 0 || SelectedPersons.Count > 0; }
        }

        public void AddReciever(Person person)
        {
            if(SelectedPersons.Contains(person))
                throw new Exception("این شخص قبلا به لیست اضافه شده است.");
            rTextBox1.Text += " " + person.MessageAddress + " ";
            SelectedPersons.Add(person);
        }

        public void AddReciever(Department department)
        {
            if (SelectedDepartments.Contains(department))
                throw new Exception("این دپارتمان قبلا به لیست اضافه شده است.");
            rTextBox1.Text += " " + department.MessageAddress + " ";
            SelectedDepartments.Add(department);
        }

        public void Clear()
        {
            SelectedDepartments.Clear();
            SelectedPersons.Clear();
            rTextBox1.Text = "";
        }

        private void lnkSelectEmployee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IQueryable<Employee> employees = DbContext.GetAll<Employee>();
            frmSelect frmSelect = new frmSelect(employees, new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFullname" });
            frmSelect.MultiSelect = true;

            if (frmSelect.ShowDialog(this) != DialogResult.OK)
                return;

            List<Person> persons = frmSelect.GetSelectedObjects<Person>();
            foreach (Person person in persons)
            {
                try
                {
                    AddReciever(person);
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
            }
        }

        private void lnkSelectTeacher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<Teacher> teachers = DbContext.GetAll<Teacher>().ToList();
            frmSelect frmSelect = new frmSelect(teachers, new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFullname" });
            frmSelect.MultiSelect = true;

            if (frmSelect.ShowDialog(this) != DialogResult.OK)
                return;

            List<Teacher> persons = frmSelect.GetSelectedObjects<Teacher>();
            foreach (Teacher person in persons)
            {
                try
                {
                    if (persons.IndexOf(person) != persons.Count - 1)
                        AddReciever(person);
                    else
                        AddReciever(person);
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
            }
        }

        private void lnkSelectDepartment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IList<Department> departments = Program.CurrentPerson.AllowedDepartments;
            frmSelect frmSelect = new frmSelect(departments, new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            frmSelect.MultiSelect = true;

            if (frmSelect.ShowDialog(this) != DialogResult.OK)
                return;

            List<Department> selectedDepartments = frmSelect.GetSelectedObjects<Department>();
            foreach (Department department in selectedDepartments)
            {
                try
                {
                    AddReciever(department);
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
            }
        }

        private void ReceiverSelector_Load(object sender, EventArgs e)
        {
            lnkSelectDepartment.Visible = SelectDepartment;
            lnkSelectEmployee.Visible = SelectEmployee;
            lnkSelectTeacher.Visible = SelectTeacher;
        }
    }
}
