using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Exam;
using Fakher.UI.Fundamental.Protocol;
using Fakher.UI.Holding;
using rComponents;

namespace Fakher.UI
{
    public partial class frmLessonTrainingItemDetail : rRadDetailForm
    {
        public frmLessonTrainingItemDetail(LessonTrainingItem item)
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;
            //var examTypes=new List<s ;
            //examTypes.
            rCmbType.DataSource = typeof(ExamType).GetEnumDescriptions();// ExamType.Exercise.ToDescription();// 
            rGridComboBoxMajor.Columns.Add("نام", "نام", "Name");

            rGridComboBoxLesson.Columns.Add("نام", "نام", "Name");
            rGridComboBoxLesson.Columns.Add("رشته", "رشته", "Major.Name");
            rGridComboBoxMajor.DataSource = new[] { item.Plan.Major };
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = item,
                ObjectProperty = "Name"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rGridComboBoxLesson,
                ControlProperty = "Value",
                DataObject = item,
                ObjectProperty = "Lesson"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox2,
                ControlProperty = "Value",
                DataObject = item,
                ObjectProperty = "Capacity"
            });

          

            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbType,
                ControlProperty = "SelectedIndex",
                DataObject = item,
                ObjectProperty = "Type"
            });

            if (item.Lesson != null)
            {
                rGridComboBoxMajor.Value = item.Lesson.Major;
                rGridComboBoxLesson.Value = item.Lesson;
            }


        }
        protected override void AfterBindToObject()
        {
            LessonTrainingItem item = GetProcessingObject<LessonTrainingItem>();
            if (item.Forms == null|item.Forms.Count()==0)
                item.Forms.Add(new ExamForm() { LessonTrainingItem = item,Name="A" });
           
        }
        private void rGridComboBoxMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridComboBoxLesson.Clear();
            rGridComboBoxGroup.Clear();
            rGridComboBoxItem.Clear();
            Major major = rGridComboBoxMajor.GetValue<Major>();
            if (major == null)
                return;
            //            rGridComboBoxLesson.DataSource = major.GetLessons(Program.CurrentPeriod);
            rGridComboBoxLesson.DataSource = major.Lessons;
        }

        private void radPageViewPage1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
