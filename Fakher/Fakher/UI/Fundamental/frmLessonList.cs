using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Fakher.UI.Struture
{
    public partial class frmLessonList : rRadForm
    {
        public frmLessonList()
        {
            InitializeComponent();
            rGridComboBoxDepartments.Columns.Add("نام", "نام", "Name");

            rGridComboBox1.Columns.Add("نام", "نام", "Name");

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "کد درس", ObjectProperty = "Code" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام درس", ObjectProperty = "Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نوع برگزاری", ObjectProperty = "HoldingTypeText" });

            rGridComboBoxDepartments.DataSource = DbContext.GetAllEntities<Department>();
            if (Program.CurrentDepartment != null)
                rGridComboBoxDepartments.Value = Program.CurrentDepartment;
        }

        private void radMultiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Major major = rGridComboBox1.GetValue<Major>();
            if (major == null)
                return;

            rGridView2.DataBind(major.Lessons);
        }

        private void rGridView2_Add(object sender, EventArgs e)
        {
            Major major = rGridComboBox1.GetValue<Major>();
            if (major == null)
                return;
            Lesson item = new Lesson { Major = major};
            item.Code = Lesson.GetNextCode();
            frmLessonDetail frm = new frmLessonDetail(item);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            major.Lessons.Add(item);
            major.Save();
            rGridView2.Insert(item);
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Major major = rGridComboBox1.GetValue<Major>();
            Lesson item = rGridView2.GetSelectedObject<Lesson>();
            frmLessonDetail frm = new frmLessonDetail(item);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            item.Save();
            rGridView2.UpdateGridView();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            Lesson item = rGridView2.GetSelectedObject<Lesson>();
            item.Major.Lessons.Remove(item);
            item.Major.Save();
//            item.Delete();
            rGridView2.RemoveSelectedRow();
        }

        private void rGridComboBoxDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Department department = rGridComboBoxDepartments.GetValue<Department>();
            rGridView2.Clear();
            rGridComboBox1.DataSource = department.Majors;
        }
    }
}
