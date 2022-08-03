using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.UI.Website
{
    public partial class frmEnrollmentLicenseDetail : rRadDetailForm
    {
        public frmEnrollmentLicenseDetail(EnrollmentLicense enrollmentLicense)
        {
            InitializeComponent();
            SetProcessingObject(enrollmentLicense);

            rCmbType.DataSource = typeof(EnrollmentLicenseType).GetEnumDescriptions();
            rCmbParticipantType.DataSource = typeof (EnrollmentLicenseParticipantType).GetEnumDescriptions();

            majorSelector1.Period = enrollmentLicense.EducationalPeriod;

            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbType,
                ControlProperty = "SelectedIndex",
                DataObject = enrollmentLicense,
                ObjectProperty = "LicenseType"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbParticipantType,
                ControlProperty = "SelectedIndex",
                DataObject = enrollmentLicense,
                ObjectProperty = "ParticipantType"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker1,
                ControlProperty = "Date",
                DataObject = enrollmentLicense,
                ObjectProperty = "StartDate"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtStartTime,
                ControlProperty = "Text",
                DataObject = enrollmentLicense,
                ObjectProperty = "StartTime"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker2,
                ControlProperty = "Date",
                DataObject = enrollmentLicense,
                ObjectProperty = "EndDate"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtEndTime,
                ControlProperty = "Text",
                DataObject = enrollmentLicense,
                ObjectProperty = "EndTime"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = majorSelector1,
                ControlProperty = "Major",
                DataObject = enrollmentLicense,
                ObjectProperty = "Major"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = lessonSelector1,
                ControlProperty = "Lesson",
                DataObject = enrollmentLicense,
                ObjectProperty = "Lesson"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = enrollmentLicense,
                ObjectProperty = "Description"
            });
        }

        private void rCmbType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            EnrollmentLicenseType type = (EnrollmentLicenseType)rCmbType.SelectedIndex;
            rCmbParticipantType.Enabled = type == EnrollmentLicenseType.SectionEnrollment;
        }

        private void rCmbParticipantType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            EnrollmentLicenseParticipantType participantType = (EnrollmentLicenseParticipantType)rCmbParticipantType.SelectedIndex;
            lessonSelector1.Enabled = (participantType == EnrollmentLicenseParticipantType.LessonStudents
                                        || participantType == EnrollmentLicenseParticipantType.LessonBalancedStudents
//                                        || participantType == EnrollmentLicenseParticipantType.LessonCreditorStudents
                                        || participantType == EnrollmentLicenseParticipantType.LessonDebtorStudents);
        }
    }
}
