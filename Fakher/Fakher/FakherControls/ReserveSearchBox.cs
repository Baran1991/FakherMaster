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
using Fakher.UI.Person;
using rComponents;

namespace Fakher.Controls
{
    public partial class ReserveSearchBox : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Student SelectedStudent { get; set; }
        public bool OpenUowOnSearch { get; set; }
        public bool CanAddNew { get; set; }
        public bool TeacherSearch { get; set; }
        public event EventHandler SelectedChanged;

        public ReserveSearchBox()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام پدر", ObjectProperty = "FarsiFatherName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = " آخرین وضعیت آموزشی", ObjectProperty = "GetCurrentEducationalStatus()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "GetCurrentFinancialStatus()" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFirstName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام پدر", ObjectProperty = "FarsiFatherName" });
        }

        protected void OnSelectedChanged()
        {
            if (SelectedChanged != null)
                SelectedChanged(this, EventArgs.Empty);
        }

        private void radTxtFirstname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search();
        }

        private void radTxtLastname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search();
        }

        private void Search()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Application.UseWaitCursor = true;
                Application.DoEvents();

                if (OpenUowOnSearch)
                    DbContext.OpenUnitOfWork();

                SearchStudents();
                if(TeacherSearch)
                    SearchTeachers();
            }
            finally
            {
                Cursor = Cursors.Default;
                Application.UseWaitCursor = false;
                Application.DoEvents();
            }
        }

        private void SearchStudents()
        {
            string firstName = radTxtFirstname.Text.Trim();
            string lastName = radTxtLastname.Text.Trim();

            List<Student> result = new List<Student>();
            
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                rMessageBox.ShowError("جستجو فقط می تواند بر اساس (نام و نام خانوادگی) انجام شود.");
                return;
            }

            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                result.AddRange(Student.Search(firstName, lastName));
            }
            else
            {
                result.AddRange(Student.SearchByFirstname(firstName));
                result.AddRange(Student.SearchByLastname(lastName));
            }

            rGridView1.DataBind(result);
            string studentsText = result.Count > 0 ? " (" + result.Count + ")" : "";
            radPageViewPage1.Text = "دانـــشــجـــــویــــان" + studentsText;
        }

        private void SearchTeachers()
        {
            string firstName = radTxtFirstname.Text.Trim();
            string lastName = radTxtLastname.Text.Trim();

            List<Teacher> result = new List<Teacher>();
            
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                rMessageBox.ShowError("جستجو فقط می تواند بر اساس (نام و نام خانوادگی) انجام شود.");
                return;
            }

            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                result.AddRange(Teacher.Search(firstName, lastName));
            }
            else
            {
                result.AddRange(Teacher.SearchByFirstname(firstName));
                result.AddRange(Teacher.SearchByLastname(lastName));
            }

            rGridView2.DataBind(result);
            string teacherText = result.Count > 0 ? " (" + result.Count + ")" : "";
            radPageViewPage2.Text = "اســــاتــیـــد" + teacherText;
        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            SelectedStudent = rGridView1.GetSelectedObject<Student>();
            OnSelectedChanged();
        }

        public void Clear()
        {
            rGridView1.Clear();
        }

        private void StudentSearchBox_Load(object sender, EventArgs e)
        {
            pictureBox2.Visible = rLabel2.Visible = lnkNewStudent.Visible = CanAddNew;
            radPageView1.SelectedPage = radPageViewPage1;

            if(!CanAddNew)
            {
                rGridView1.Height += 55;
            }
            if (!TeacherSearch)
                radPageView1.Pages.Remove(radPageViewPage2);
        }

        private void lnkNewStudent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string firstName = radTxtFirstname.Text.Trim();
            string lastName = radTxtLastname.Text.Trim();

            rGridView1.Clear();

            Student student = new Student();
            student.FarsiFirstName = firstName;
            student.FarsiLastName = lastName;

            frmReservePersonDetail frm = new frmReservePersonDetail(student);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            SelectedStudent = student;
            rGridView1.Insert(student);
        }

        private void radBtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

    }
}
