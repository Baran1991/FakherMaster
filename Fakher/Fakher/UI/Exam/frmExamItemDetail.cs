using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Exam
{
    public partial class frmExamItemDetail : rRadDetailForm
    {
        public frmExamItemDetail(ExamItem examItem, IList<Lesson> lessons)
        {
            InitializeComponent();

            rGridComboBox1.Columns.Add("نام", "نام", "Name");
            rGridComboBox1.Columns.Add("رشته", "رشته", "Major.Name");
            rGridComboBox1.DataSource = lessons;

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = examItem,
                ObjectProperty = "Name"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox3,
                ControlProperty = "Value",
                DataObject = examItem,
                ObjectProperty = "StartIndex"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox2,
                ControlProperty = "Value",
                DataObject = examItem,
                ObjectProperty = "EndIndex"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rGridComboBox1,
                ControlProperty = "Value",
                DataObject = examItem,
                ObjectProperty = "Lesson"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox4,
                ControlProperty = "Value",
                DataObject = examItem,
                ObjectProperty = "Coefficient"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtFixedMark,
                ControlProperty = "Value",
                DataObject = examItem,
                ObjectProperty = "FixedMark"
            });
            
            rRadioBtnAutoMarkType.IsChecked = examItem.MarkType == ExamItemMarkType.Automatic;
            rRadioBtnFixedMarkType.IsChecked = examItem.MarkType == ExamItemMarkType.Fixed;
        }

        protected override void AfterBindToObject()
        {
            ExamItem examItem = GetProcessingObject<ExamItem>();

            if(rRadioBtnAutoMarkType.IsChecked)
                examItem.MarkType = ExamItemMarkType.Automatic;
            if (rRadioBtnFixedMarkType.IsChecked)
                examItem.MarkType = ExamItemMarkType.Fixed;
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rTextBox1.Text = "";
            if(rGridComboBox1.Value == null)
                return;
            Lesson lesson = rGridComboBox1.GetValue<Lesson>();
            rTextBox1.Text = lesson.Name;
        }

        private void rRadioBtnFixedMarkType_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rTxtFixedMark.Enabled = rRadioBtnFixedMarkType.IsChecked;
        }

        private void rRadioBtnAutoMarkType_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rTxtFixedMark.Enabled = !rRadioBtnAutoMarkType.IsChecked;
        }
    }
}
