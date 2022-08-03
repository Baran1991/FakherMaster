using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Report;
using NHibernate;
using rComponents;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace Fakher.UI.Reception
{
    public partial class frmSmsWizard : rRadDetailForm
    {
        private bool mCustomChangeTabs;
        private SmsGroup SmsGroup;
        public frmSmsWizard(Major major,Lesson lesson,SectionItem section)
        {
            InitializeComponent();
            if(major!=null)
                majorSelector1.Major=major;
            if(lesson!=null)
                lessonSelector1.Lesson=lesson;
            if (section != null)
                sectionItemSelector1.SectionItem = section;
            rTxtSms.Text = "فاخر هم اکنون می توانید کارنامه ازمون  خود را مشاهده نمایید";
            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage1;
            radPageView2.SelectedPage = radPageViewPage2;
            mCustomChangeTabs = false;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "گیرنده", ObjectProperty = "Text" });

            rGridCmbTrainingPlan.Columns.Add("نام", "نام", "Name");
            rGridCmbExamItem.Columns.Add("نام", "نام", "Name");
            rGridCmbReserveList.Columns.Add("نام", "نام", "Name");
            rGridCmbLavelDeterminationList.Columns.Add("نام", "نام", "Name");
            rGridCmbPreEnrollmentList.Columns.Add("نام", "نام", "Name");
            rGridCmbCareer.Columns.Add("نام", "نام", "Name");

            rGridCmbCareer.DataSource = Fakher.Core.DomainModel.Career.GetCareers();

            SmsGroup = new SmsGroup();
            UpdateSmsLabel();

            rDatePicker1.Date = PersianDate.Today;
            rTextBox1.Text = rComponents.Time.Now.ToShortTimeString();
            rDatePicker2.Date = Program.CurrentPeriod.StartDate;
            rDatePicker3.Date = Program.CurrentPeriod.EndDate;
        }
        public frmSmsWizard()
        {
            InitializeComponent();

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage1;
            radPageView2.SelectedPage = radPageViewPage2;
            mCustomChangeTabs = false;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "گیرنده", ObjectProperty = "Text" });

            rGridCmbTrainingPlan.Columns.Add("نام", "نام", "Name");
            rGridCmbExamItem.Columns.Add("نام", "نام", "Name");
            rGridCmbReserveList.Columns.Add("نام", "نام", "Name");
            rGridCmbPreEnrollmentList.Columns.Add("نام", "نام", "Name");
            rGridCmbLavelDeterminationList.Columns.Add("نام", "نام", "Name");

            rGridCmbCareer.Columns.Add("نام", "نام", "Name");

            rGridCmbCareer.DataSource = Fakher.Core.DomainModel.Career.GetCareers();

            SmsGroup = new SmsGroup();
            UpdateSmsLabel();

            rDatePicker1.Date = PersianDate.Today;
            rTextBox1.Text = rComponents.Time.Now.ToShortTimeString();
            rDatePicker2.Date = Program.CurrentPeriod.StartDate;
            rDatePicker3.Date = Program.CurrentPeriod.EndDate;
        }

        private int StepIndex
        {
            get
            {
                return radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            }
        }

        private void GotoNextStep()
        {
            mCustomChangeTabs = true;
            int index = radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            if (index + 1 < radPageView1.Pages.Count)
                radPageView1.SelectedPage = radPageView1.Pages[index + 1];
            mCustomChangeTabs = false;
        }

        private void GotoPrevStep()
        {
            mCustomChangeTabs = true;
            int index = radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            if (index - 1 >= 0)

                radPageView1.SelectedPage = radPageView1.Pages[index - 1];
            mCustomChangeTabs = false;
        }

        private void radPageView1_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {
            e.Cancel = !mCustomChangeTabs;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            GotoPrevStep();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (StepIndex == 0) //Receivers
            {
                if (rGridView1.DataSource.Count == 0)
                {
                    rMessageBox.ShowError("گیرندگان پیامک را مشخص کنید.");
                    return;
                }

                try
                {
                    foreach (SmsReceiver receiver in rGridView1.DataSource)
                    {
                        receiver.LoadNumbers();
                        if (receiver.Numbers.Count == 0)
                        {
                            rMessageBox.ShowError("گیرنده ({0}) هیچ شماره تلفن معتبری برای ارسال پیامک ندارند.", receiver.Text);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
            }

            if (StepIndex == 1) //Sms Text
            {
                string smsText = rTxtSms.Text.Trim();
                if (string.IsNullOrEmpty(smsText))
                {
                    rMessageBox.ShowError("متن پیامک را مشخص کنید.");
                    return;
                }


                SmsGroup.Text = smsText;
                SmsGroup.Smses.Clear();
                SmsGroup.Status = SmsGroupStatus.Created;

                string txt = "";
                foreach (SmsReceiver receiver in rGridView1.DataSource)
                {
                    foreach (string number in receiver.Numbers)
                    {
                        Sms sms = SmsGroup.CreateSms();
                        sms.Number = number;
                        SmsGroup.AddSms(sms);
                    }

                    txt += receiver.Text + "\n";
                }

                SmsGroup.ReceiverText = txt;

                btnNext.Text = "تـــایــیــد";
            }

            if (StepIndex == 2) //End
            {
                try
                {
                    bool sent = false;
                    if (radioButton1.Checked)
                    {
                        if (rMessageBox.ShowQuestion("از ارسال {0} پیامک در این بسته، اطمینان دارید؟", SmsGroup.Smses.Count) != DialogResult.Yes)
                            return;

                        rLblMessage.Text = "در حال ارسال بسته پیامک...";
                        Application.DoEvents();

                        Program.StartWaiting("در حال ارسال بسته پیامک...");
                        SmsPostMaster.Send(SmsGroup);
                        SmsGroup.Sent();
                        sent = true;
                    }
                    if (radioButton2.Checked)
                    {
                        if(rDatePicker1.Date == null)
                        {
                            rMessageBox.ShowError("تاریخ ارسال را مشخص کنید");
                            return;
                        }

                        PersianDate date = rDatePicker1.Date;
                        rComponents.Time time = rComponents.Time.FromString(rTextBox1.Text.Trim());

                        if (rMessageBox.ShowQuestion("از ارسال {0} پیامک در تاریخ {1} ساعت {2}، اطمینان دارید؟", SmsGroup.Smses.Count, date, time) != DialogResult.Yes)
                            return;

                        SmsGroup.PrepareForSend(date, time);
                    }

                    rLblMessage.Text = "در حال ذخیره بسته پیامک...";
                    Program.StartWaiting("در حال ذخیره بسته پیامک...");
                    Application.DoEvents();

                    ITransaction transaction = null;
                    try
                    {
                        transaction = DbContext.BeginTransaction();

                        SmsGroup.Save();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }

                    Program.EndWaiting();

                    if (sent)
                        rMessageBox.ShowInformation("بسته پیامک با موفقیت ارسال گردید.");
                }
                catch (Exception ex)
                {
                    Program.EndWaiting();
                    rMessageBox.ShowError(ex.Message);
                    return;
                }

                Close();
            }

            GotoNextStep();
        }

        private ColumnMapping[] GetGridMappings()
        {
            List<ColumnMapping> mappings = new List<ColumnMapping>();

            if (radPageView2.SelectedPage == radPageViewPage2)
            {
                mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
                mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });
                mappings.Add(new ColumnMapping { Caption = "نوع ثبت نام", ObjectProperty = "RegisterParticipationText" });

                if (rChkEducationalStatus.Checked)
                    mappings.Add(new ColumnMapping { Caption = "آخرین وضعیت آموزشی", ObjectProperty = "Student.GetCurrentEducationalStatus()" });

                if (rChkFinancialStatus.Checked)
                    mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "Student.GetCurrentFinancialStatus()" });

                if (rChkWebLogin.Checked)
                    mappings.Add(new ColumnMapping { Caption = "شناسه وب سایت", ObjectProperty = "Student.UserInfo.WebLoginText" });

                if(rCheckBox7.Checked)
                    mappings.Add(new ColumnMapping { Caption = "وضعیت عکس", ObjectProperty = "Student.Photo.HasPictureText" });

                if(rCheckBox8.Checked)
                {
                    mappings.Add(new ColumnMapping { Caption = "روز تولد", ObjectProperty = "Student.BirthDate.Day" });
                    mappings.Add(new ColumnMapping { Caption = "ماه تولد", ObjectProperty = "Student.BirthDate.Month" });
                }
            }

            if (radPageView2.SelectedPage == radPageViewPage8)
            {
                mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
                mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });
                mappings.Add(new ColumnMapping { Caption = "نوع ثبت نام", ObjectProperty = "RegisterParticipationText" });

                if (rChkEducationalStatus3.Checked)
                    mappings.Add(new ColumnMapping { Caption = "آخرین وضعیت آموزشی", ObjectProperty = "Student.GetCurrentEducationalStatus()" });

                if (rChkFinancialStatus3.Checked)
                    mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "Student.GetCurrentFinancialStatus()" });

                if (rChkWebLogin3.Checked)
                    mappings.Add(new ColumnMapping { Caption = "شناسه وب سایت", ObjectProperty = "Student.UserInfo.WebLoginText" });
            }

            if (radPageView2.SelectedPage == radPageViewPage9)
            {
                mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
                mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });

                if (rCheckBox3.Checked)
                    mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });

                if (rCheckBox1.Checked)
                    mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });
            }

            if (radPageView2.SelectedPage == radPageViewPage16)
            {
                mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
                mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });

                if (rCheckBox17.Checked)
                    mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });

            }

            if (radPageView2.SelectedPage == radPageViewPage10)
            {
                mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FirstName" });
                mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "LastName" });
                mappings.Add(new ColumnMapping { Caption = "استان", ObjectProperty = "Province" });
                mappings.Add(new ColumnMapping { Caption = "شهر", ObjectProperty = "City" });

                if (rCheckBox5.Checked)
                    mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            }  
            
            if (radPageView2.SelectedPage == radPageViewPage11)
            {
                mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFirstName" });
                mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });
            }

            if (radPageView2.SelectedPage == radPageViewPage12)
            {
                mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFirstName" });
                mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });
            } 
            
            if (radPageView2.SelectedPage == radPageViewPage13)
            {
                mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "PersonalInfo.FarsiFirstName" });
                mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "PersonalInfo.FarsiLastName" });
                mappings.Add(new ColumnMapping { Caption = "مدرک تحصیلی", ObjectProperty = "EducationalInfo.EducationalDegreeText" });
            }

            if (radPageView2.SelectedPage == radPageViewPage14)
            {
                mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
                mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });
                mappings.Add(new ColumnMapping { Caption = "نوع ثبت نام", ObjectProperty = "RegisterParticipationText" });

                if (rCheckBox11.Checked)
                    mappings.Add(new ColumnMapping { Caption = "آخرین وضعیت آموزشی", ObjectProperty = "Student.GetCurrentEducationalStatus()" });

                if (rCheckBox9.Checked)
                    mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "Student.GetCurrentFinancialStatus()" });
            }

            return mappings.ToArray();
        }

        private SmsReceiver CreateSmsReceiver()
        {
            SmsReceiver receiver = new SmsReceiver();
            receiver.Period = Program.CurrentPeriod;
            receiver.Department = Program.CurrentDepartment;

            return receiver;
        }

        private void radBtnAddFromStructure_Click(object sender, EventArgs e)
        {
            SmsReceiver receiver = CreateSmsReceiver();
            if (sectionItemSelector1.SectionItem != null)
                receiver.SectionItem = sectionItemSelector1.SectionItem;
            else if (lessonSelector1.Lesson != null)
                receiver.Lesson = lessonSelector1.Lesson;
            else if (majorSelector1.Major != null)
                receiver.Major = majorSelector1.Major;


            if (rChkSectionItemSubset.Checked)
            {
                frmSelect frm = new frmSelect(receiver.GetRegisters(), GetGridMappings()) { MultiSelect = true };

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    receiver.SectionItem = null;
                    receiver.Lesson = null;
                    receiver.Major = null;
                    receiver.Persons = frm.GetSelectedObjects<Register>().Select(x => x.Student as Fakher.Core.DomainModel.Person).ToList();
                }
                else
                    return;
            }

            rGridView1.Insert(receiver);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            SmsReceiver receiver = rGridView1.GetSelectedObject<SmsReceiver>();
            rGridView1.RemoveSelectedRow();
        }

        private void radBtnAddFromExam_Click(object sender, EventArgs e)
        {
            if (examSelector1.Exam == null)
            {
                rMessageBox.ShowWarning("آزمون را انتخاب کنید.");
                return;
            }

            SmsReceiver receiver = CreateSmsReceiver();

            if (rChkExamSubset.Checked)
            {
                IQueryable<ExamParticipate> examParticipates = examSelector1.Exam.GetParticipates();
                frmSelect frm = new frmSelect(examParticipates, new ColumnMapping { Caption = "شناسه", ObjectProperty = "Code" }
                    , new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" }
                    , new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" }
                    , new ColumnMapping { Caption = "کارت", ObjectProperty = "CardStatusText" }
                    , new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
                frm.MultiSelect = true;
                if (frm.ShowDialog(this) != DialogResult.OK)
                    return;

                receiver.Persons = frm.GetSelectedObjects<ExamParticipate>().Select(x => x.Person).ToList();
            }
            else
            {
                receiver.Exam = examSelector1.Exam;
            }

            rGridView1.Insert(receiver);
        }

        private void radBtnAddFromTo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rTxtFrom.Text.Trim()))
            {
                rMessageBox.ShowWarning("شماره شروع را وارد کنید.");
                return;
            }

            if (string.IsNullOrEmpty(rTxtTo.Text.Trim()))
            {
                rMessageBox.ShowWarning("شماره انتهایی را وارد کنید.");
                return;
            }

            if (rTxtFrom.Text.StartsWith("0"))
            {
                rMessageBox.ShowWarning("صفر اول شماره شروع را حذف کنید.");
                return;
            }

            if (rTxtTo.Text.StartsWith("0"))
            {
                rMessageBox.ShowWarning("صفر اول شماره انتهایی را حذف کنید.");
                return;
            }

            if (rTxtFrom.Text.Trim().Length != 10)
            {
                rMessageBox.ShowWarning("شماره شروع را به صورت معتبر وارد کنید.");
                return;
            }

            if (rTxtTo.Text.Trim().Length != 10)
            {
                rMessageBox.ShowWarning("شماره انتهایی را به صورت معتبر وارد کنید.");
                return;
            }

            SmsReceiver receiver = CreateSmsReceiver();
            receiver.FromNumber = Convert.ToInt64(rTxtFrom.Text.Trim());
            receiver.ToNumber = Convert.ToInt64(rTxtTo.Text.Trim());

            rGridView1.Insert(receiver);
        }

        private void radBtnAddFromFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rTextBox2.Text.Trim()))
            {
                rMessageBox.ShowWarning("مسیر فایل را انتخاب کنید.");
                return;
            }

            SmsReceiver receiver = CreateSmsReceiver();
            receiver.FilePath = rTextBox2.Text.Trim();

            rGridView1.Insert(receiver);
        }

        private void lnkSelectFilePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "*.CSV File|*.csv";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;
            rTextBox2.Text = dialog.FileName;
        }

        private void rTxtSms_TextChanged(object sender, EventArgs e)
        {
            UpdateSmsLabel();
        }

        private void UpdateSmsLabel()
        {
            int pages = rTxtSms.Text.Length / 70;
            rLblSms.Text = string.Format("{0}/259 ({1} صفحه)", rTxtSms.Text.Length, (pages + 1));
        }

        private void linkLblPreviousTexts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //List<SmsGroup> groups = DbContext.GetAllEntities<SmsGroup>().OrderByDescending(x => x.CreateDate).ToList();
            List<SmsGroup> groups = DbContext.GetAllEntities<SmsGroup>().GroupBy(x => x.SingleLineText.Trim()).Select(m=>m.First()).ToList();
            frmSelect frm = new frmSelect(groups,
                                          //new ColumnMapping {Caption = "تـاریـخ", ObjectProperty = "CreateDate.ToShortDateString()"},
                                          new ColumnMapping {Caption = "متــن", ObjectProperty = "SingleLineText"}
                                          //,new ColumnMapping { Caption = "گیرنده", ObjectProperty = "SingleLineReceiverText" }
                                          );
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            SmsGroup selectedGroup = frm.SelectedObject as SmsGroup;
            rTxtSms.Text = selectedGroup.Text;
        }

        private void majorSelector2_SelectedChanged(object sender, EventArgs e)
        {
            rGridCmbTrainingPlan.Clear();
            if (majorSelector2.Major == null)
                return;
            IList<TrainingPlan> plans = TrainingPlan.GetPlans(Program.CurrentPeriod, majorSelector2.Major);
            rGridCmbTrainingPlan.DataSource = plans;
        }

        private void rGridCmbTrainingPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridCmbExamItem.Clear();
            TrainingPlan plan = rGridCmbTrainingPlan.GetValue<TrainingPlan>();
            if (plan == null)
                return;

            rGridCmbExamItem.DataSource = plan.GetExamItems();
        }

        private void radBtnAddFromEnrollment_Click(object sender, EventArgs e)
        {
            ExamTrainingItem examTrainingItem = rGridCmbExamItem.GetValue<ExamTrainingItem>();
            if (examTrainingItem == null)
            {
                rMessageBox.ShowError("آزمون را انتخاب کنید.");
                return;
            }

            IEnumerable<Register> registers = examTrainingItem.GetEnrollments().Select(x => x.Register).ToList();

            if (rChkEnrollmentSubset.IsChecked)
            {
                frmSelect frm = new frmSelect(registers, GetGridMappings()) { MultiSelect = true };

                if (frm.ShowDialog(this) == DialogResult.OK)
                    registers = frm.GetSelectedObjects<Register>();
                else
                    return;
            }

            SmsReceiver receiver = CreateSmsReceiver();
            receiver.Persons = registers.Select(x => x.Student as Fakher.Core.DomainModel.Person).ToList();
            rGridView1.Insert(receiver);
        }

        private void rChkSectionItemSubset_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rChkEducationalStatus.Enabled =
                rChkFinancialStatus.Enabled = rChkWebLogin.Enabled = rCheckBox7.Enabled = rCheckBox8.Enabled = rChkSectionItemSubset.Checked;
        }

        private void rChkEnrollmentSubset_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rChkEducationalStatus3.Enabled =
                rChkFinancialStatus3.Enabled = rChkWebLogin3.Enabled = rChkEnrollmentSubset.Checked;
        }

        private void majorSelector3_SelectedChanged(object sender, EventArgs e)
        {
            rGridCmbReserveList.Clear();
            if (majorSelector3.Major == null)
                return;

            rGridCmbReserveList.DataSource = ReserveList.GetReserveList(Program.CurrentPeriod, majorSelector3.Major);
        }

        private void radBtnAddFromReserves_Click(object sender, EventArgs e)
        {
            ReserveList reserveList = rGridCmbReserveList.GetValue<ReserveList>();
            if(reserveList == null)
            {
                rMessageBox.ShowInformation("لیست رزرو را انتخاب کنید");
                return;
            }

            List<Reserve> reserves = reserveList.Reserves.ToList();
            if(rCheckBox4.Checked)
            {
               frmSelect frm = new frmSelect(reserveList.Reserves, GetGridMappings()) { MultiSelect = true };

                if (frm.ShowDialog(this) == DialogResult.OK)
                    reserves = frm.GetSelectedObjects<Reserve>();
                else
                    return;
            }

            SmsReceiver receiver = CreateSmsReceiver();
            receiver.Reserves = reserves;
            rGridView1.Insert(receiver);
        }

        private void rCheckBox4_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rCheckBox3.Enabled = rCheckBox1.Enabled = rCheckBox4.Checked;
        }
        private void rCheckBox18_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rCheckBox17.Enabled = rCheckBox18.Checked;
        }

        private void majorSelector4_SelectedChanged(object sender, EventArgs e)
        {
            rGridCmbPreEnrollmentList.Clear();
            if (majorSelector4.Major == null)
                return;

            rGridCmbPreEnrollmentList.DataSource = PreEnrollmentList.GetLists(majorSelector4.Major);
        }
        private void majorSelector6_SelectedChanged(object sender, EventArgs e)
        {
            rGridCmbLavelDeterminationList.Clear();
            if (majorSelector6.Major == null)
                return;

            rGridCmbLavelDeterminationList.DataSource = ReserveList.GetReserveListByType(Program.CurrentPeriod, majorSelector6.Major,ReserveList.ReserveType.LevelDetermination);

        }

        private void radBtnAddFromPreEnrollmentList_Click(object sender, EventArgs e)
        {
            PreEnrollmentList enrollmentList = rGridCmbPreEnrollmentList.GetValue<PreEnrollmentList>();
            if (enrollmentList == null)
            {
                rMessageBox.ShowInformation("لیست پیش ثبت نام را انتخاب کنید");
                return;
            }

            List<Core.DomainModel.PreEnrollment> enrollments = enrollmentList.PreEnrollments.ToList();
            if (rCheckBox6.Checked)
            {
                frmSelect frm = new frmSelect(enrollmentList.PreEnrollments, GetGridMappings()) { MultiSelect = true };

                if (frm.ShowDialog(this) == DialogResult.OK)
                    enrollments = frm.GetSelectedObjects<Core.DomainModel.PreEnrollment>();
                else
                    return;
            }

            SmsReceiver receiver = CreateSmsReceiver();
            receiver.PreEnrollments = enrollments;
            rGridView1.Insert(receiver);
        }

        private void rCheckBox6_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rCheckBox5.Enabled = rCheckBox6.Checked;
        }

        private void radBtnAddFromTeachers_Click(object sender, EventArgs e)
        {
            List<Teacher> teachers;
            frmSelect frm = new frmSelect(Teacher.GetActiveTeachers(), GetGridMappings()) { MultiSelect = true };

            if (frm.ShowDialog(this) == DialogResult.OK)
                teachers = frm.GetSelectedObjects<Teacher>();
            else
                return;

            SmsReceiver receiver = CreateSmsReceiver();
            receiver.Teachers = teachers;
            rGridView1.Insert(receiver);
        }

        private void radBtnAddFromEmployee_Click(object sender, EventArgs e)
        {
            List<Employee> employees;
            frmSelect frm = new frmSelect(Employee.GetActiveEmployees(), GetGridMappings()) { MultiSelect = true };

            if (frm.ShowDialog(this) == DialogResult.OK)
                employees = frm.GetSelectedObjects<Employee>();
            else
                return;

            SmsReceiver receiver = CreateSmsReceiver();
            receiver.Employees = employees;
            rGridView1.Insert(receiver);
        }

        private void radBtnAddFromCareerApplicant_Click(object sender, EventArgs e)
        {
            Core.DomainModel.Career career = rGridCmbCareer.GetValue<Fakher.Core.DomainModel.Career>();
            if(career == null)
            {
                rMessageBox.ShowInformation("فرصت همکاری را انتخاب کنید");
                return;
            }

            List<CareerApplicant> applicants = career.GetApplicants().ToList();
            if (rCheckBox2.Checked)
            {
                frmSelect frm = new frmSelect(applicants, GetGridMappings()) {MultiSelect = true};

                if (frm.ShowDialog(this) == DialogResult.OK)
                    applicants = frm.GetSelectedObjects<CareerApplicant>();
                else
                    return;
            }

            SmsReceiver receiver = CreateSmsReceiver();
            receiver.CareerApplicants = applicants;
            rGridView1.Insert(receiver);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            rDatePicker1.Enabled = rTextBox1.Enabled = radioButton2.Checked;
        }

        private void rCheckBox12_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rCheckBox9.Enabled = rCheckBox11.Enabled = rCheckBox12.Checked;
        }

        private void radBtnAddFromQuit_Click(object sender, EventArgs e)
        {
            SmsReceiver receiver = CreateSmsReceiver();

            if (majorSelector5.Major == null)
            {
                rMessageBox.ShowError("رشته را انتخاب کنید");
                return;
            }
            if (rDatePicker2.Date == null)
            {
                rMessageBox.ShowError("تاریخ شروع را وارد کنید");
                return;
            }
            if (rDatePicker3.Date == null)
            {
                rMessageBox.ShowError("تاریخ انتها را وارد کنید");
                return;
            }

            receiver.QuitMajor = majorSelector5.Major;
            receiver.QuitStartDate = rDatePicker2.Date;
            receiver.QuitEndDate = rDatePicker3.Date;

            if (rCheckBox12.Checked)
            {
                frmSelect frm = new frmSelect(receiver.GetRegisters(), GetGridMappings()) { MultiSelect = true };

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    receiver.QuitMajor = null;
                    receiver.QuitStartDate = null;
                    receiver.QuitEndDate = null;
                    receiver.Persons = frm.GetSelectedObjects<Register>().Select(x => x.Student as Fakher.Core.DomainModel.Person).ToList();
                }
                else
                    return;
            }

            rGridView1.Insert(receiver);
        }

        private void radBtnAddFromNewsletter_Click(object sender, EventArgs e)
        {
            SmsReceiver receiver = CreateSmsReceiver();
            receiver.FromWebsiteNewsletter = true;
            rGridView1.Insert(receiver);
        }


        private void radBtnAddFromLevelDetermination_Click(object sender, EventArgs e)
        {
            ReserveList reserveList = rGridCmbLavelDeterminationList.GetValue<ReserveList>();
            if (reserveList == null)
            {
                rMessageBox.ShowInformation("لیست رزرو را انتخاب کنید");
                return;
            }

            List<Reserve> reserves = reserveList.Reserves.ToList();
            if (rCheckBox18.Checked)
            {
                frmSelect frm = new frmSelect(reserveList.Reserves, GetGridMappings()) { MultiSelect = true };

                if (frm.ShowDialog(this) == DialogResult.OK)
                    reserves = frm.GetSelectedObjects<Reserve>();
                else
                    return;
            }

            SmsReceiver receiver = CreateSmsReceiver();
            receiver.Reserves = reserves;
            rGridView1.Insert(receiver);
        }
    }
}
