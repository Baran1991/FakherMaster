using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rComponents;
using Fakher.Core.DomainModel;
using Fakher.UI.Educational.Common;
using System.IO;

namespace Fakher.UI.Teachers
{
    public partial class frmTeacherPresenceWizard : rRadDetailForm
    {
        private string mFilename;
        List<Presence> mPresences;

        public frmTeacherPresenceWizard()
        {
            InitializeComponent();

            rGridComboBoxTeacher.Columns.Add("نام", "نام", "FarsiFullname");

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "گــروه", ObjectProperty = "SectionItem.Section.FarsiName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان شروع", ObjectProperty = "StartTime" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان پایان", ObjectProperty = "EndTime" });
            rGridView1.Mappings.Add(new ColumnMapping
            {
                Caption = "مدت",
                ObjectProperty = "Duration.TotalHours",
                AggregateSummary = AggregateSummary.Sum
            });

            rGridComboBoxTeacher.DataSource = Teacher.GetActiveTeachers();
        }

        private void lnkSelectFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV File|*.csv";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;
            rTextBox1.Text = mFilename = dialog.FileName;
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Presence presence = rGridView1.GetSelectedObject<Presence>();

            frmPresenceDetail frm = new frmPresenceDetail(presence);
            if (!frm.ProcessObject())
                return;
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Presence presence = rGridView1.GetSelectedObject<Presence>();
            rGridView1.RemoveSelectedRow();
        }

        private void radBtnCalculate_Click(object sender, EventArgs e)
        {
            rGridView1.Clear();
            Teacher teacher = rGridComboBoxTeacher.GetValue<Teacher>();
            mPresences = new List<Presence>();

            if (teacher == null)
            {
                rMessageBox.ShowError("مدرس را انتخاب کنید.");
                return;
            }
            string[] lines = File.ReadAllLines(mFilename);
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                string[] items = line.Split(';', ',');
                PersianDate date = PersianDate.FromString(items[0].Trim());
                WeekDay day = date.GetDayOfWeek();
                Time startTime = Time.FromString(items[1].Trim());
                Time endTime = Time.FromString(items[2].Trim());
                
                IList<Section> sections = teacher.GetTeachingSections(date, date);
                foreach (Section section in sections)
                {
                    foreach (Formation formation in section.Formations)
                    {
                        Time formationStartTime = Time.FromString(formation.StartTime);
                        Time formationFinishTime = Time.FromString(formation.FinishTime);

                        if(formation.Day == day
                            && (formationStartTime >= startTime && formationStartTime <= endTime)
                            && (formationFinishTime >= startTime && formationFinishTime <= endTime))
                        {
                            Presence presence = new Presence { SectionItem = section.Items[0], Person = teacher };
                            presence.Date = date;
                            presence.StartTime = formation.StartTime;
                            presence.EndTime = formation.FinishTime;
                            mPresences.Add(presence);
                        }
                    }
                }
            }

            rGridView1.DataBind(mPresences);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Teacher teacher = rGridComboBoxTeacher.GetValue<Teacher>();
            foreach (Presence presence in mPresences)
            {
                teacher.Presences.UniqueAdd(presence);
            }
            teacher.Save();
            Close();
        }
    }
}
