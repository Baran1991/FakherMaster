using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.Sentinel;
using rComponents;

namespace Fakher.UI.Reception
{
    public partial class frmStudentConfigurations : rRadForm
    {
        public frmStudentConfigurations(Student student)
        {
            InitializeComponent();
            SetProcessingObject(student);
            radPageView1.SelectedPage = radPageViewPage1;
            radPageView1.Enabled = false;

            rGridCmbMajor.Columns.Add("نـام", "نـام", "Name");

            rGridCmbPeriod.Columns.Add("نـام", "نـام", "Name");

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "Lesson.Name" });
            rGridView1.CustomButtons.Add(new rGridViewButton {Text = "محاسبه خودکار", Position = rGridViewButtonPosition.After});

            rGridCmbMajor.DataSource = student.GetRegisteredMajors().OrderBy(x => x.Name);
        }

        private void rGridCmbMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Major major = rGridCmbMajor.GetValue<Major>();
            rGridCmbPeriod.DataSource = major.Department.EducationalPeriods.OrderByDescending(x => x.Id);
        }

        private void rGridCmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Major major = rGridCmbMajor.GetValue<Major>();
            EducationalPeriod period = rGridCmbPeriod.GetValue<EducationalPeriod>();
            Fill();
        }

        private StudentConfiguration GetConfiguration()
        {
            Student student = GetProcessingObject<Student>();
            Major major = rGridCmbMajor.GetValue<Major>();
            EducationalPeriod period = rGridCmbPeriod.GetValue<EducationalPeriod>();
            if (major == null || period == null)
                return null;

            StudentConfiguration configuration = student.GetConfiguration(major, period);
//            if (configuration == null)
//            {
//                configuration = student.CreateConfiguration(major, period);
//                student.AddConfiguration(configuration);
//                configuration.Save();
//            }
            return configuration;
        }

        private void Fill()
        {
            radPageView1.Enabled = false;

            Student student = GetProcessingObject<Student>();
            StudentConfiguration configuration = GetConfiguration();
            if (configuration == null)
                return;

            radPageView1.Enabled = true;
            rGridView1.DataBind(configuration.EnrollableLessons);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Major major = rGridCmbMajor.GetValue<Major>();
            EducationalPeriod period = rGridCmbPeriod.GetValue<EducationalPeriod>();
            StudentConfiguration configuration = GetConfiguration();
            if (configuration == null)
            {
                rMessageBox.ShowWarning("تنظیمات آموزشی این رشته و ترم ساخته نشده است.");
                return;
            }

            frmSelect frm = new frmSelect(major.Lessons, new ColumnMapping {Caption = "نـام", ObjectProperty = "Name"});
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            Lesson lesson = frm.GetSelectedObject<Lesson>();

            configuration.AddEnrollableLesson(new EnrollableLesson {Lesson = lesson});
            configuration.Save();

            Fill();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Major major = rGridCmbMajor.GetValue<Major>();
            EducationalPeriod period = rGridCmbPeriod.GetValue<EducationalPeriod>();
            StudentConfiguration configuration = GetConfiguration();
            if (configuration == null)
            {
                rMessageBox.ShowWarning("تنظیمات آموزشی این رشته و ترم ساخته نشده است.");
                return;
            }

            EnrollableLesson enrollableLesson = rGridView1.GetSelectedObject<EnrollableLesson>();

            configuration.EnrollableLessons.Remove(enrollableLesson);
            enrollableLesson.Delete();
            configuration.Save();

            Fill();
        }

        private void rGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            StudentConfiguration configuration = GetConfiguration();
            configuration.CalculateEnrollableLessons();
            configuration.Save();

            Fill();
        }

        private void lnkGenerate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.StudentConfiguration);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }

            Student student = GetProcessingObject<Student>();
            Major major = rGridCmbMajor.GetValue<Major>();
            EducationalPeriod period = rGridCmbPeriod.GetValue<EducationalPeriod>();
            if (major == null || period == null)
            {
                rMessageBox.ShowError("رشته و ترم را انتخاب کنید.");
                return;
            }

            StudentConfiguration configuration = GetConfiguration();
            if (configuration == null)
            {
                configuration = student.CreateConfiguration(major, period);
                student.AddConfiguration(configuration);
                configuration.Save();

                Fill();
                rMessageBox.ShowInformation("تنظیمات آموزشی ایجاد گردید.");
            }
        }
    }
}
