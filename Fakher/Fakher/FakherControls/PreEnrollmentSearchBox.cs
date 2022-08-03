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
using Fakher.UI.PreEnrollment;
using rComponents;

namespace Fakher.Controls
{
    public partial class PreEnrollmentSearchBox : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PreEnrollment SelectedPreEnrollment { get; set; }
        public bool OpenUowOnSearch { get; set; }
        public bool CanAddNew { get; set; }
        public event EventHandler SelectedChanged;

        public PreEnrollmentSearchBox()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "LastName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "استان", ObjectProperty = "Province" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شهر", ObjectProperty = "City" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تلفن", ObjectProperty = "Phone" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ایمیل", ObjectProperty = "Email" });
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

            foreach (Student student in result)
            {
                rGridView1.Insert(PreEnrollment.FromStudent(student));
            }

            string studentsText = result.Count > 0 ? " (" + result.Count + ")" : "";
            radPageViewPage1.Text = "دانـــشــجـــــویــــان" + studentsText;
        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            SelectedPreEnrollment = rGridView1.GetSelectedObject<PreEnrollment>();
            OnSelectedChanged();
        }

        public void Clear()
        {
            rGridView1.Clear();
        }

        private void StudentSearchBox_Load(object sender, EventArgs e)
        {
            pictureBox2.Visible = rLabel2.Visible = lnkNewPreEnrollment.Visible = CanAddNew;
            radPageView1.SelectedPage = radPageViewPage1;

            if(!CanAddNew)
            {
                rGridView1.Height += 55;
            }
        }

        private void radBtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void lnkNewPreEnrollment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string firstName = radTxtFirstname.Text.Trim();
            string lastName = radTxtLastname.Text.Trim();

            rGridView1.Clear();

            PreEnrollment preEnrollment = new PreEnrollment();
            preEnrollment.FirstName = firstName;
            preEnrollment.LastName = lastName;

            frmPreEnrollmentDetail frm = new frmPreEnrollmentDetail(preEnrollment);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            SelectedPreEnrollment = preEnrollment;
            rGridView1.Insert(preEnrollment);
        }
    }
}
