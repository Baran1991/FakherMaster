using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Financial;
using Fakher.UI.Students;
using rComponents;

namespace Fakher.UI
{
    public partial class frmRegister : rRadDetailForm
    {
//        private Major mLastMajor;
        private bool mManualCodeAssigned;
        private EducationalCode mEducationalCode;

        public frmRegister(Register register)
        {
            InitializeComponent();

            mManualCodeAssigned = false;
            radPageView1.SelectedPage = radPageViewPage7;
            SetProcessingObject(register);

            studentInfo1.Student = register.Student;

            rGridComboBoxMajor.Columns.Add("نام رشته", "نام رشته", "Name");

            rGridComboBoxLesson.Columns.Add("نام درس", "نام درس", "Name");

            rGridComboBoxSectionItems.Columns.Add("نام کلاس", "نام کلاس", "Section.Name");
            rGridComboBoxSectionItems.Columns.Add("ظرفیت باقیمانده", "ظرفیت باقیمانده", "RemainderCount");
            rGridComboBoxSectionItems.Columns.Add("زمان تشکیل", "زمان تشکیل", "Section.FarsiFormationText");

            rGridViewParticipates.Mappings.Add(new ColumnMapping { Caption = "درس", ObjectProperty = "SectionItem.Lesson.Name" });
            rGridViewParticipates.Mappings.Add(new ColumnMapping { Caption = "نام کلاس", ObjectProperty = "SectionItem.Section.Name" });
            rGridViewParticipates.Mappings.Add(new ColumnMapping { Caption = "زمان تشکیل", ObjectProperty = "SectionItem.Section.FarsiFormationText" });

            rGridViewGeneralExams.Mappings.Add(new ColumnMapping { Caption = "نام آزمون", ObjectProperty = "Name" });

            ControlMappings.Add(new ControlMapping { Control = rGridComboBoxMajor, ControlProperty = "Value", DataObject = register, ObjectProperty = "Major" });
            ControlMappings.Add(new ControlMapping { Control = rChkEnrollmentBan, ControlProperty = "IsChecked", DataObject = register, ObjectProperty = "NextEnrollmentBanned" });
            ControlMappings.Add(new ControlMapping { Control = rTxtEnrollmentBanReason, ControlProperty = "Text", DataObject = register, ObjectProperty = "NextEnrollmentBanReason" });

            mEducationalCode = register.EducationalCode;
            rTextBox1.Text = register.Code;
            rGridComboBoxMajor.DataSource = register.Major.Department.Majors;
            rTxtEnrollmentBanReason.Enabled = register.NextEnrollmentBanned;

            paymentControl1.Databind(register.FinancialDocument, FinancialHeading.Signup);
            financialDocumentView1.Databind(register.FinancialDocument);

            rGridViewParticipates.DataBind(register.Participates);
        }

        protected override void BeforeValidate()
        {
            Register register = GetProcessingObject<Register>();
            Major major = rGridComboBoxMajor.GetValue<Major>();

            if (register.Id == 0)
            {
                Register reg = register.Student.GetRegister(Program.CurrentPeriod, major);
                if (reg != null)
                {
                    rMessageBox.ShowError("این دانشجو، قبلا در این ترم، در همین رشته ثبت نام شده است.");
                    CancelClosing();
                    return;
                }
            }
        }

        protected override void AfterValidate()
        {
            Register register = GetProcessingObject<Register>();
            Major major = rGridComboBoxMajor.GetValue<Major>();

            if (paymentControl1.DataSource.Count == 0)
            {
                if(rMessageBox.ShowQuestion("اطلاعات مالی این دانشجو وارد نشده است. آیا مایل به ذخیره بدون اطلاعات مالی هستید ؟") != DialogResult.Yes)
                {
                    CancelClosing();
                    return;
                }
            }

            if(rGridViewParticipates.DataSource.Count == 0)
            {
                if (rMessageBox.ShowQuestion("این دانشجو در هیچ کلاسی ثبت نام نشده است. آیا مطمئن هستید؟") != DialogResult.Yes)
                {
                    CancelClosing();
                    return;
                }
                if (rMessageBox.ShowQuestion("این دانشجو در هیچ کلاسی ثبت نام نشده است. آیا واقعا مطمئن هستید؟") != DialogResult.Yes)
                {
                    CancelClosing();
                    return;
                }
            }

//            mLastMajor = register.Major;
            //change student code with major, it is before bind to object
            if (register.Major != null && major != null && !mManualCodeAssigned && major.Id != register.Major.Id)
            {
                if (rMessageBox.ShowQuestion("با تغییر رشته ثبت نامی به {0}، شماره دانشجویی این دانشجو تغییر خواهد کرد، آیا مطمئن هستید؟", major.Name) != DialogResult.Yes)
                {
                    CancelClosing();
                    return;
                }

                foreach (Participate participate in rGridViewParticipates.DataSource)
                {
                    if(participate.SectionItem.Lesson.Major.Id != major.Id)
                    {
                        rMessageBox.ShowError(
                            "کلاس بندی دانشجو مربوط به رشته {0} است. کلاس بندی را تصحیح کنید.",
                            participate.SectionItem.Lesson.Major.Name);
                        CancelClosing();
                        return;
                    }
                }

                mEducationalCode = register.Student.GenerateCode(register.Period, major, false);
                rTextBox1.Text = mEducationalCode.Code;
//                register.Code = register.Student.GenerateCode(register.Period, major);
            }

            if(rTxtEnrollmentBanReason.Enabled && string.IsNullOrEmpty(rTxtEnrollmentBanReason.Text.Trim()))
            {
                rMessageBox.ShowError("علت منع ثبت نام را برای ارائه به دانشجو در وب سایت وارد کنید.");
                CancelClosing();
                return;
            }
        }

        protected override void AfterBindToObject()
        {
            Register register = GetProcessingObject<Register>();

            register.EducationalCode = mEducationalCode;
            if (string.IsNullOrEmpty(register.Code) || register.Code == "0")
                register.EducationalCode = register.Student.GenerateCode(register.Period, register.Major, false);

            paymentControl1.BindToObject();
            foreach (FinancialItem item in register.FinancialDocument.Items)
                Program.CurrentEmployee.RegisterItem(item);

            register.Participates.SyncWith(rGridViewParticipates.DataSource);

            register.UpdateParticipateEnrollments();
            List<ExamTrainingItem> checkedObjects = rGridViewGeneralExams.GetCheckedObjects<ExamTrainingItem>();
            register.UpdateExamEnrollments(checkedObjects);
//            register.SyncParticipation();

            register.ConfirmEnrollment();
        }

        private void rGridComboBoxMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridComboBoxLesson.Clear();

            Register register = GetProcessingObject<Register>();
            Major major = rGridComboBoxMajor.GetValue<Major>();

            if(major == null)
                return;

            mManualCodeAssigned = false;
            //rTextBox1.BackColor = Color.Gray;

            rGridComboBoxLesson.DataSource = major.GetLessons(register.Period, HoldingType.Lesson);

            IQueryable<ExamTrainingItem> items = major.GetGeneralExamItems(register.Period);
            rGridViewGeneralExams.DataBind(items);

            IQueryable<Enrollment> examEnrollments = register.GetGeneralExamEnrollments();
            foreach (Enrollment examEnrollment in examEnrollments)
                rGridViewGeneralExams.Check(examEnrollment.TrainingItem as ExamTrainingItem);
        }

        private void rGridComboBoxLesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridComboBoxSectionItems.Clear();
            Register register = GetProcessingObject<Register>();
            Major major = rGridComboBoxMajor.GetValue<Major>();
            Lesson lesson = rGridComboBoxLesson.GetValue<Lesson>();
            if(lesson == null)
                return;
            rGridComboBoxSectionItems.DataSource = SectionItem.GetSectionItems(register.Period, major, lesson);
        }

        private void rBtnSignup_Click(object sender, EventArgs e)
        {
            Lesson lesson = rGridComboBoxLesson.GetValue<Lesson>();
            SectionItem sectionItem = rGridComboBoxSectionItems.GetValue<SectionItem>();
            Register register = GetProcessingObject<Register>();

            #region Repeat-Validation
            if (lesson == null)
            {
                rMessageBox.ShowError("درس را انتخاب کنید.");
                return;
            }

            if (sectionItem == null)
            {
                rMessageBox.ShowError("کلاس را انتخاب کنید.");
                return;
            }

            try
            {
                sectionItem.CheckCapacity();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }

            foreach (Participate participate1 in rGridViewParticipates.DataSource)
            {
                if (participate1.SectionItem.Id == sectionItem.Id)
                {
                    rMessageBox.ShowError("این کلاس قبلا اخذ شده است.");
                    return;
                }
            }

            if (register.Student.SignedUpIn(sectionItem))
            {
                rMessageBox.ShowError("این کلاس قبلا اخذ شده است.");
                return;
            }
            #endregion

            Participate participate;
            try
            {
                if (rChkAutoSignup.Checked)
                    participate = register.Signup(sectionItem, false);
                else
                    participate = register.Signup(sectionItem, true);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }

            rGridViewParticipates.Insert(participate);

//            rGridView5.Insert(participate.FinancialItem);
            paymentControl1.AddItem(participate.FinancialItem);
        }

        private void rGridViewParticipates_Delete(object sender, EventArgs e)
        {
            Participate participate = rGridViewParticipates.GetSelectedObject<Participate>();
            rGridViewParticipates.RemoveSelectedRow();
//            rGridView5.Remove(participate.FinancialItem);
            paymentControl1.RemoveItem(participate.FinancialItem);
        }

        private void lnkNewCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetProcessingObject<Register>();
            Major major = rGridComboBoxMajor.GetValue<Major>();
            if(rMessageBox.ShowQuestion("از انتساب شماره دانشجویی جدید در رشته {0} مطمئن هستید؟", major.Name) != DialogResult.Yes)
                return;
            mEducationalCode = register.Student.GenerateCode(register.Period, major, true);
            rTextBox1.Text = mEducationalCode.Code;
            mManualCodeAssigned = true;
        }

        private void rChkEnrollmentBan_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rTxtEnrollmentBanReason.Enabled = rChkEnrollmentBan.IsChecked;
        }

        private void lnkEnrollmentList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetProcessingObject<Register>();
            frmRegisterEnrollments frm = new frmRegisterEnrollments(register);
            if (!frm.ProcessObject())
                return;
        }
    }
}
