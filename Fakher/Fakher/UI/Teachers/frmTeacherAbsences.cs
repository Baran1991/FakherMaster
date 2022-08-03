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
using Fakher.UI.Educational.Common;
using rComponents;

namespace Fakher.UI.Educational.Teachers
{
    public partial class frmTeacherAbsences : rRadForm
    {
        public frmTeacherAbsences()
        {
            InitializeComponent();

            rGridComboBoxTeacher.Columns.Add("نام", "نام", "FarsiFullname");

            rGridComboBoxSection.Columns.Add("نام کلاس", "نام کلاس", "Name");
            rGridComboBoxSection.Columns.Add("شیفت برگزاری", "شیفت برگزاری", "FarsiFormationText");

            rGridComboBoxItem.Columns.Add("نام", "نام", "Lesson.Name");

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "علت", ObjectProperty = "Reason" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });

            rGridComboBoxTeacher.DataSource = Teacher.GetActiveTeachers();
        }

        private void rGridComboBoxTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridComboBoxSection.Clear();
            rGridView1.Clear();
            Teacher teacher = rGridComboBoxTeacher.GetValue<Teacher>();
            if (teacher == null)
                return;

            IList<Section> sections = teacher.GetTeachingSections(Program.CurrentPeriod);
            rGridComboBoxSection.DataSource = sections;
        }

        private void rGridComboBoxSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridView1.Clear();
            Section section = rGridComboBoxSection.GetValue<Section>();
            if (section == null)
                return;
            rGridComboBoxItem.DataSource = section.Items;
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Teacher teacher = rGridComboBoxTeacher.GetValue<Teacher>();
            Section section = rGridComboBoxSection.GetValue<Section>();
            SectionItem item = rGridComboBoxItem.GetValue<SectionItem>();
            if (item == null)
                return;

            Absence absence = new Absence { SectionItem = item, Person = teacher};
            frmAbsenceDetail frm = new frmAbsenceDetail(absence);
            if(!frm.ProcessObject())
                return;
            teacher.Absences.Add(absence);
            absence.Save();
            rGridView1.Insert(absence);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Absence absence = rGridView1.GetSelectedObject<Absence>();

            frmAbsenceDetail frm = new frmAbsenceDetail(absence);
            if (!frm.ProcessObject())
                return;
            absence.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Teacher teacher = rGridComboBoxTeacher.GetValue<Teacher>();
            Absence absence = rGridView1.GetSelectedObject<Absence>();
            teacher.Absences.Remove(absence);
            absence.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridComboBoxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridView1.Clear();
            Teacher teacher = rGridComboBoxTeacher.GetValue<Teacher>();
            SectionItem item = rGridComboBoxItem.GetValue<SectionItem>();
            if (item == null)
                return;
            rGridView1.DataBind(teacher.GetAbsences(item).ToList());
        }
    }
}
