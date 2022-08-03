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
using Fakher.UI.Website.License;
using rComponents;
using Fakher.Core.Website;
using Fakher.UI.Website;

namespace Fakher.UI.Educational
{
    public partial class frmEducationalPeriodDetail : rRadDetailForm
    {
        public frmEducationalPeriodDetail(EducationalPeriod period)
        {
            InitializeComponent();
            radPageView1.SelectedPage = radPageViewPage1;
            radPageView2.SelectedPage = radPageViewPage7;

            rCmbFinancialPolicy.DataSource = typeof (FinancialPolicy).GetEnumDescriptions();

            rGridCmbBankAccounts.Columns.Add("بانک", "بانک", "BankName");
            rGridCmbBankAccounts.Columns.Add("شعبه", "شعبه", "Branch");
            rGridCmbBankAccounts.Columns.Add("شماره حساب", "شماره حساب", "AccountNumber");
            rGridCmbBankAccounts.DataSource = DbContext.GetAllEntities<BankAccount>();

            rGridViewEnrollmentLicenses.Mappings.Add(new ColumnMapping { Caption = "نوع مجوز", ObjectProperty = "LicenseTypeText" });
            rGridViewEnrollmentLicenses.Mappings.Add(new ColumnMapping { Caption = "شرکت کنندگان", ObjectProperty = "ParticipantTypeText" });
            rGridViewEnrollmentLicenses.Mappings.Add(new ColumnMapping { Caption = "تاریخ شروع", ObjectProperty = "StartDate.ToShortDateString()" });
            rGridViewEnrollmentLicenses.Mappings.Add(new ColumnMapping { Caption = "زمان شروع", ObjectProperty = "StartTime" });
            rGridViewEnrollmentLicenses.Mappings.Add(new ColumnMapping { Caption = "تاریخ پایان", ObjectProperty = "EndDate.ToShortDateString()" });
            rGridViewEnrollmentLicenses.Mappings.Add(new ColumnMapping { Caption = "زمان پایان", ObjectProperty = "EndTime" });

            rGridViewMarkEntryLicense.Mappings.Add(new ColumnMapping { Caption = "کد", ObjectProperty = "EntryCode" });
            rGridViewMarkEntryLicense.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridViewMarkEntryLicense.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "Lesson.Name" });
            rGridViewMarkEntryLicense.Mappings.Add(new ColumnMapping { Caption = "آیتم", ObjectProperty = "EvaluationItem.Name" });
            rGridViewMarkEntryLicense.Mappings.Add(new ColumnMapping { Caption = "تاریخ شروع", ObjectProperty = "StartDate.ToShortDateString()" });
            rGridViewMarkEntryLicense.Mappings.Add(new ColumnMapping { Caption = "زمان شروع", ObjectProperty = "StartTime" });
            rGridViewMarkEntryLicense.Mappings.Add(new ColumnMapping { Caption = "تاریخ پایان", ObjectProperty = "EndDate.ToShortDateString()" });
            rGridViewMarkEntryLicense.Mappings.Add(new ColumnMapping { Caption = "زمان پایان", ObjectProperty = "EndTime" });

//            rGridViewReportCardLicenses.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "StartDate.ToShortDateString()" });
//            rGridViewReportCardLicenses.Mappings.Add(new ColumnMapping { Caption = "زمان", ObjectProperty = "StartTime" });
//            rGridViewReportCardLicenses.Mappings.Add(new ColumnMapping { Caption = "کارنامه کل", ObjectProperty = "ShowEducationalReportCardText" });
//            rGridViewReportCardLicenses.Mappings.Add(new ColumnMapping { Caption = "آزمون ها", ObjectProperty = "ExamsText" });

            ControlMappings.Add(new ControlMapping
            {
                Control = radTextBox2,
                ControlProperty = "Text",
                DataObject = period,
                ObjectProperty = "Code"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = period,
                ObjectProperty = "Name"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker1,
                ControlProperty = "Date",
                DataObject = period,
                ObjectProperty = "StartDate"
            });
            
            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker2,
                ControlProperty = "Date",
                DataObject = period,
                ObjectProperty = "EndDate"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox3,
                ControlProperty = "Text",
                DataObject = period,
                ObjectProperty = "SignupReceiptNote"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox7,
                ControlProperty = "Text",
                DataObject = period,
                ObjectProperty = "QuitReceiptNote"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox2,
                ControlProperty = "Value",
                DataObject = period,
                ObjectProperty = "VacationFee"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox4,
                ControlProperty = "Value",
                DataObject = period,
                ObjectProperty = "VacationReceiptNote"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox5,
                ControlProperty = "Value",
                DataObject = period,
                ObjectProperty = "RegistrationNote"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox8,
                ControlProperty = "Value",
                DataObject = period,
                ObjectProperty = "CertificateFee"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rGridCmbBankAccounts,
                ControlProperty = "Value",
                DataObject = period,
                ObjectProperty = "ReceiptBankAccount"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox6,
                ControlProperty = "Value",
                DataObject = period,
                ObjectProperty = "PayrollNote"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbFinancialPolicy,
                ControlProperty = "SelectedIndex",
                DataObject = period,
                ObjectProperty = "FinancialPolicy"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCheckBox1,
                ControlProperty = "IsChecked",
                DataObject = period,
                ObjectProperty = "CanViewWebReportCard"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker3,
                ControlProperty = "Date",
                DataObject = period,
                ObjectProperty = "WebReportCardStartDate"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtStartTime,
                ControlProperty = "Text",
                DataObject = period,
                ObjectProperty = "WebReportCardStartTime"
            });

            rGridViewEnrollmentLicenses.DataBind(period.EnrollmentLicenses);
            rGridViewMarkEntryLicense.DataBind(period.MarkEntryLicenses);

            rDatePicker3.Enabled = rTxtStartTime.Enabled = period.CanViewWebReportCard;
        }

        private void rGridViewEnrollmentLicenses_Add(object sender, EventArgs e)
        {
            EducationalPeriod period = GetProcessingObject<EducationalPeriod>();
            EnrollmentLicense enrollmentLicense = new EnrollmentLicense { EducationalPeriod = period };
            frmEnrollmentLicenseDetail frm = new frmEnrollmentLicenseDetail(enrollmentLicense);
            if (!frm.ProcessObject())
                return;
            rGridViewEnrollmentLicenses.Insert(enrollmentLicense);
        }

        private void rGridViewEnrollmentLicenses_Edit(object sender, EventArgs e)
        {
            EnrollmentLicense enrollmentLicense = rGridViewEnrollmentLicenses.GetSelectedObject<EnrollmentLicense>();
            frmEnrollmentLicenseDetail frm = new frmEnrollmentLicenseDetail(enrollmentLicense);
            if (!frm.ProcessObject())
                return;
            rGridViewEnrollmentLicenses.UpdateGridView();
        }

        private void rGridViewEnrollmentLicenses_Delete(object sender, EventArgs e)
        {
            EnrollmentLicense enrollmentLicense = rGridViewEnrollmentLicenses.GetSelectedObject<EnrollmentLicense>();
            rGridViewEnrollmentLicenses.RemoveSelectedRow();
        }

        private void frmEducationalPeriodDetail_Load(object sender, EventArgs e)
        {

        }

        protected override void AfterValidate()
        {
            if (rCheckBox1.IsChecked && rDatePicker3.Date == null)
            {
                rMessageBox.ShowError("تاریخ شروع مشاهده کارنامه اینترنتی را مشخص کنید.");
                CancelClosing();
                return;
            }
        }

        protected override void AfterBindToObject()
        {
            EducationalPeriod period = GetProcessingObject<EducationalPeriod>();

            period.EnrollmentLicenses.SyncWith(rGridViewEnrollmentLicenses.DataSource);
            period.MarkEntryLicenses.SyncWith(rGridViewMarkEntryLicense.DataSource);
        }

        private void rCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rDatePicker3.Enabled = rTxtStartTime.Enabled = rCheckBox1.IsChecked;
        }

        private void rGridViewMarkEntryLicense_Add(object sender, EventArgs e)
        {
            EducationalPeriod period = GetProcessingObject<EducationalPeriod>();

            MarkEntryLicense entryLicense = new MarkEntryLicense { EducationalPeriod = period };
            entryLicense.EntryCode = MarkEntryLicense.GenerateCode();
            frmMarkEntryLicenseDetail frm = new frmMarkEntryLicenseDetail(entryLicense);
            if (!frm.ProcessObject())
                return;
            rGridViewMarkEntryLicense.Insert(entryLicense);
        }

        private void rGridViewMarkEntryLicense_Edit(object sender, EventArgs e)
        {
            EducationalPeriod period = GetProcessingObject<EducationalPeriod>();
            MarkEntryLicense entryLicense = rGridViewMarkEntryLicense.GetSelectedObject<MarkEntryLicense>();

            frmMarkEntryLicenseDetail frm = new frmMarkEntryLicenseDetail(entryLicense);
            if (!frm.ProcessObject())
                return;
            rGridViewMarkEntryLicense.UpdateGridView();
        }

        private void rGridViewMarkEntryLicense_Delete(object sender, EventArgs e)
        {
            EducationalPeriod period = GetProcessingObject<EducationalPeriod>();
            MarkEntryLicense entryLicense = rGridViewMarkEntryLicense.GetSelectedObject<MarkEntryLicense>();

            rGridViewMarkEntryLicense.RemoveSelectedRow();
        }
    }
}
