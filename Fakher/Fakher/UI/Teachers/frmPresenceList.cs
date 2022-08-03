using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Educational.Common;
using rComponents;

namespace Fakher.UI.Educational
{
    public partial class frmPresenceList : rRadForm
    {
        private EducationalPeriod mCurrentPeriod;
        private bool mConfirm;

        public frmPresenceList()
        {
            InitializeComponent();
            Fill();
            mCurrentPeriod = Program.CurrentPeriod;
            rGridComboBoxTeacher.DataSource = Teacher.GetActiveTeachers();
        }

        public frmPresenceList(Teacher teacher, EducationalPeriod period)
        {
            InitializeComponent();
            Fill();
            mCurrentPeriod = period;
            rGridView1.CanDelete = false;
            rGridComboBoxTeacher.DataSource = new[] { teacher };
        }

        private void Fill()
        {
            rGridComboBoxTeacher.Columns.Add("نام", "نام", "FarsiFullname");

            rGridCmbSectionItem.Columns.Add("نام", "نام", "Section.Name");
            rGridCmbSectionItem.Columns.Add("مدرس", "مدرس", "Section.Teacher.FarsiFullname");
            //            rGridComboBoxSection.Columns.Add("شیفت برگزاری", "شیفت برگزاری", "FarsiFormationText");
            //
            //            rGridComboBoxItem.Columns.Add("نام", "نام", "Lesson.Name");

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان شروع", ObjectProperty = "StartTime" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان پایان", ObjectProperty = "EndTime" });
            rGridView1.Mappings.Add(new ColumnMapping
                                        {
                                            Caption = "مدت",
                                            ObjectProperty = "Duration.TotalHours",
                                            AggregateSummary = AggregateSummary.Sum
                                        });

            majorSelector1.Period = mCurrentPeriod;
            lessonSelector1.Period = mCurrentPeriod;
        }

        private void rGridComboBoxTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
//            rGridComboBoxSection.Clear();
//            rGridComboBoxItem.Clear();
//            Teacher teacher = rGridComboBoxTeacher.GetValue<Teacher>();
//            if (teacher == null)
//                return;
//            if (mCurrentPeriod == null)
//                return;
//            IList<Section> sections = teacher.GetTeachingSections(mCurrentPeriod);
//            rGridComboBoxSection.DataSource = sections;
        }

        //        private void rGridComboBoxSection_SelectedIndexChanged(object sender, EventArgs e)
        //        {
        //            rGridView1.Clear();
        //            Section section = rGridComboBoxSection.GetValue<Section>();
        //            if (section == null)
        //                return;
        //            rGridComboBoxItem.DataSource = section.Items;
        //        }
        //
        //        private void rGridComboBoxItem_SelectedIndexChanged(object sender, EventArgs e)
        //        {
        //            rGridView1.Clear();
        //            Teacher teacher = rGridComboBoxTeacher.GetValue<Teacher>();
        //            SectionItem item = rGridComboBoxItem.GetValue<SectionItem>();
        //            if (item == null)
        //                return;
        //            rGridView1.DataBind(teacher.GetPresences(item).ToList());
        //        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Teacher teacher = rGridComboBoxTeacher.GetValue<Teacher>();
//            SectionItem sectionItem = rGridComboBoxItem.GetValue<SectionItem>();
            SectionItem sectionItem = rGridCmbSectionItem.GetValue<SectionItem>();
//            SectionItem sectionItem = sectionItemSelector1.SectionItem;
            if (sectionItem == null)
                return;

            if(!mConfirm)
            {
                if (sectionItem.Section.Teacher != teacher)
                {
                    IList<Section> teachingSections = teacher.GetTeachingSections(mCurrentPeriod);
                    if (!teachingSections.Contains(sectionItem.Section))
                    {
                        if (rMessageBox.ShowQuestion(
                            " {0} از {1} مربوط به {2} در ترم {3} نیست. گروه و سطح را درست انتخاب کرده اید؟",
                            sectionItem.Section.FarsiName, sectionItem.Lesson.Name, teacher.FarsiFullname,
                            mCurrentPeriod.Name) != DialogResult.Yes)
                            return;
                    }

                    if (rMessageBox.ShowQuestion("دقت کنید؛ از ثبت حضور [{0}] در [{1}] مطمئن هستید؟",
                                                 teacher.FarsiFullname,
                                                 sectionItem.Section.FarsiName + " - " + sectionItem.Lesson.Name + " - " +
                                                 sectionItem.Lesson.Major.Name) != DialogResult.Yes)
                        return;
                    if (rMessageBox.ShowQuestion("بسیار دقت کنید؛ از ثبت حضور [{0}] در [{1}] واقعا مطمئن هستید؟",
                                                 teacher.FarsiFullname,
                                                 sectionItem.Section.FarsiName + " - " + sectionItem.Lesson.Name + " - " +
                                                 sectionItem.Lesson.Major.Name) != DialogResult.Yes)
                        return;
                }

                mConfirm = true;
            }

            Presence presence = new Presence { SectionItem = sectionItem, Person = teacher };
            List<Formation> formations = sectionItem.Section.GetFormations(presence.Date.GetDayOfWeek()).ToList();
            if (formations.Count > 0)
            {
                presence.StartTime = formations[0].StartTime;
                presence.EndTime = formations[0].FinishTime;
            }

            frmPresenceDetail frm = new frmPresenceDetail(presence);
            if (!frm.ProcessObject())
                return;

            double num = teacher.GetPresences(sectionItem).Sum(x => x.Duration.TotalHours) + presence.Duration.TotalHours;
            if (num > sectionItem.Section.HoldingHours)
                if (rMessageBox.ShowQuestion("ساعات حضور مدرس، بیشتر از ساعات مجاز کلاس خواهد شد. آیا مطمئن هستید؟") !=
                    DialogResult.Yes)
                    return;

            teacher.Presences.Add(presence);
            presence.Save();
            rGridView1.Insert(presence);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Presence presence = rGridView1.GetSelectedObject<Presence>();

            frmPresenceDetail frm = new frmPresenceDetail(presence);
            if (!frm.ProcessObject())
                return;
            presence.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Teacher teacher = rGridComboBoxTeacher.GetValue<Teacher>();
            Presence presence = rGridView1.GetSelectedObject<Presence>();
            teacher.Presences.Remove(presence);
            presence.Delete();
            rGridView1.RemoveSelectedRow();
        }

//        private void sectionItemSelector1_SelectedChanged(object sender, EventArgs e)
//        {
//            Teacher teacher = rGridComboBoxTeacher.GetValue<Teacher>();
//            if (sectionItemSelector1.SectionItem == null)
//                return;
//            rGridView1.DataBind(teacher.GetPresences(sectionItemSelector1.SectionItem).ToList());
//            mConfirm = false;
//        }

        private void lessonSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if (lessonSelector1.Lesson == null)
                return;

            List<SectionItem> sectionItems = SectionItem.GetSectionItems(mCurrentPeriod, lessonSelector1.Lesson);
            rGridCmbSectionItem.DataSource = sectionItems;
        }

        private void rGridCmbSectionItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Teacher teacher = rGridComboBoxTeacher.GetValue<Teacher>();
            SectionItem sectionItem = rGridCmbSectionItem.GetValue<SectionItem>();
            if (sectionItem == null)
                return;
            rGridView1.DataBind(teacher.GetPresences(sectionItem).ToList());
            mConfirm = false;
        }
    }
}
