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
    public partial class frmReportCardLicenseDetail : rRadDetailForm
    {
        public frmReportCardLicenseDetail(ReportCardLicense license)
        {
            InitializeComponent();

            majorSelector1.Period = license.EducationalPeriod;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نـام آزمـون", ObjectProperty = "FarsiText" });

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
                ControlProperty = "Text",
                DataObject = license,
                ObjectProperty = "StartTime"
            });
            
            ControlMappings.Add(new ControlMapping
            {
                Control = rChkInternetReportCard,
                ControlProperty = "IsChecked",
                DataObject = license,
                ObjectProperty = "ShowEducationalReportCard"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = majorSelector1,
                ControlProperty = "Major",
                DataObject = license,
                ObjectProperty = "Major"
            });

            rGridView1.DataBind(license.Exams);
        }

        protected override void AfterBindToObject()
        {
            ReportCardLicense license = GetProcessingObject<ReportCardLicense>();

            license.Exams.SyncWith(rGridView1.DataSource);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            ReportCardLicense license = GetProcessingObject<ReportCardLicense>();

            List<Core.DomainModel.Exam> exams = Core.DomainModel.Exam.GetExams(license.EducationalPeriod, majorSelector1.Major);
            frmSelect frm = new frmSelect(exams, new ColumnMapping { Caption = "نام آزمون", ObjectProperty = "Name" }, new ColumnMapping { Caption = "گروه", ObjectProperty = "FarsiExamSectionsText" });
            frm.MultiSelect = true;
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            List<Core.DomainModel.Exam> selectedExams = frm.GetSelectedObjects<Core.DomainModel.Exam>();
            foreach (Core.DomainModel.Exam selectedExam in selectedExams)
                rGridView1.Insert(selectedExam);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = rGridView1.GetSelectedObject<Core.DomainModel.Exam>();
            rGridView1.RemoveSelectedRow();
        }
    }
}
