using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.UI.Website.License
{
    public partial class frmMarkEntryLicenseDetail : rRadDetailForm
    {
        public frmMarkEntryLicenseDetail(MarkEntryLicense license)
        {
            InitializeComponent();
            SetProcessingObject(license);

            rGridComboBoxItem.Columns.Add("گروه", "گروه", "EvaluationGroup.Name");
            rGridComboBoxItem.Columns.Add("نام آیتم", "نام آیتم", "Name");
            rGridComboBoxItem.Columns.Add("مقدار", "مقدار", "Value");

            majorSelector1.Period = license.EducationalPeriod;
            if (lessonSelector1.Lesson != null)
                FillItems(license, lessonSelector1.Lesson);

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = license,
                ObjectProperty = "EntryCode"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = majorSelector1,
                ControlProperty = "Major",
                DataObject = license,
                ObjectProperty = "Major"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = lessonSelector1,
                ControlProperty = "Lesson",
                DataObject = license,
                ObjectProperty = "Lesson"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rGridComboBoxItem,
                ControlProperty = "Value",
                DataObject = license,
                ObjectProperty = "EvaluationItem"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker1,
                ControlProperty = "Date",
                DataObject = license,
                ObjectProperty = "StartDate"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtStartTime,
                ControlProperty = "Value",
                DataObject = license,
                ObjectProperty = "StartTime"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker2,
                ControlProperty = "Date",
                DataObject = license,
                ObjectProperty = "EndDate"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtEndTime,
                ControlProperty = "Value",
                DataObject = license,
                ObjectProperty = "EndTime"
            });
        }

        private void lessonSelector1_SelectedChanged(object sender, EventArgs e)
        {
            Lesson lesson = lessonSelector1.Lesson;
            MarkEntryLicense entryLicense = GetProcessingObject<MarkEntryLicense>();
            if (lesson == null)
                return;

            FillItems(entryLicense, lesson);
        }

        private void FillItems(MarkEntryLicense entryLicense, Lesson lesson)
        {
            EvaluationProtocol evaluationProtocol = lesson.GetEvaluationProtocol(entryLicense.EducationalPeriod);
            if (evaluationProtocol == null)
            {
                rMessageBox.ShowError(string.Format("آیین نامه ارزشیابی درس {0} تعریف نشده است.", lesson.Name));
                return;
            }

            rGridComboBoxItem.DataSource = evaluationProtocol.GetAllItems().ToList();
        }
    }
}
