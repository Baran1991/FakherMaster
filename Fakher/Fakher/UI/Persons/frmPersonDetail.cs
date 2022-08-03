using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core;
using Fakher.Core.DomainModel;
using Fakher.UI.Persons;
using Fakher.UI.SystemFeatures;
using rComponents;
using rTwain;
using Telerik.WinControls.UI;
using Fakher.UI.Report;
using Fakher.Core.Report;
using Fakher.Reports;

namespace Fakher.UI.Person
{
    public partial class frmPersonDetail : rRadDetailForm
    {
        private Core.DomainModel.Person selectedperson;
        public frmPersonDetail(Core.DomainModel.Person person)
        {
            InitializeComponent();
            selectedperson = person;
            SetProcessingObject(person);

            radPageView1.SelectedPage = radPageViewPage1;
            radPageView2.SelectedPage = radPageViewPage10;
            rTextBox1.Focus();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام دپارتمان", ObjectProperty = "Name" });
            rGridView1.DataBind(person.AllowedDepartments);
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "Text" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView2.DataBind(person.NoteList.Where(m => !m.Financial && m.NotesType == NotesType.Explanations_EduFa));
            rComboBoxGender.DataSource = typeof(Gender).GetEnumDescriptions();
            rComboBoxDegree.DataSource = typeof(EducationalDegree).GetEnumDescriptions();
            rComboBoxMarriage.DataSource = typeof(MarriageStatus).GetEnumDescriptions();
            rCmbIntroduceMethod.DataSource = typeof(IntroduceMethod).GetEnumDescriptions();
            rCmbProvince.DataSource = Services.GetAllProvinces();
            //            rCmbAccessPanel.DataSource = typeof(AccessPanel).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = person, ObjectProperty = "FarsiFirstName" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox3, ControlProperty = "Text", DataObject = person, ObjectProperty = "FarsiLastName" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox5, ControlProperty = "Text", DataObject = person, ObjectProperty = "FarsiFatherName" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Text", DataObject = person, ObjectProperty = "EnglishFirstName" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox4, ControlProperty = "Text", DataObject = person, ObjectProperty = "EnglishLastName" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox6, ControlProperty = "Text", DataObject = person, ObjectProperty = "EnglishFatherName" });

            ControlMappings.Add(new ControlMapping { Control = rComboBoxGender, ControlProperty = "SelectedIndex", DataObject = person, ObjectProperty = "Gender" });
            ControlMappings.Add(new ControlMapping { Control = rComboBoxDegree, ControlProperty = "SelectedIndex", DataObject = person, ObjectProperty = "LastEducationalDegree" });
            ControlMappings.Add(new ControlMapping { Control = rComboBoxMarriage, ControlProperty = "SelectedIndex", DataObject = person, ObjectProperty = "MarriageStatus" });
            ControlMappings.Add(new ControlMapping { Control = rCmbIntroduceMethod, ControlProperty = "SelectedIndex", DataObject = person, ObjectProperty = "IntroduceMethod" });

            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = person, ObjectProperty = "BirthDate" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox10, ControlProperty = "Text", DataObject = person, ObjectProperty = "NationalCode" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox9, ControlProperty = "Text", DataObject = person, ObjectProperty = "IdNumber" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox8, ControlProperty = "Text", DataObject = person, ObjectProperty = "BirthPlace" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox12, ControlProperty = "Text", DataObject = person, ObjectProperty = "Job" });

            ControlMappings.Add(new ControlMapping { Control = rTextBox15, ControlProperty = "Text", DataObject = person, ObjectProperty = "ContactInfo.Phone" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox16, ControlProperty = "Text", DataObject = person, ObjectProperty = "ContactInfo.Mobile" });
            ControlMappings.Add(new ControlMapping { Control = rCmbProvince, ControlProperty = "SelectedValue", DataObject = person, ObjectProperty = "ContactInfo.Province" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox14, ControlProperty = "Text", DataObject = person, ObjectProperty = "ContactInfo.City" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox11, ControlProperty = "Text", DataObject = person, ObjectProperty = "ContactInfo.Address" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox17, ControlProperty = "Text", DataObject = person, ObjectProperty = "ContactInfo.Email" });

            ControlMappings.Add(new ControlMapping { Control = pictureBox1, ControlProperty = "Image", DataObject = person, ObjectProperty = "Photo.Picture" });

            ControlMappings.Add(new ControlMapping { Control = rTextBox13, ControlProperty = "Text", DataObject = person, ObjectProperty = "SpecialDisease" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox18, ControlProperty = "Text", DataObject = person, ObjectProperty = "Notes" });
            ControlMappings.Add(new ControlMapping { Control = rCheckBox3, ControlProperty = "Checked", DataObject = person, ObjectProperty = "IsIncomplete" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox23, ControlProperty = "Text", DataObject = person, ObjectProperty = "IncompleteNotes" });
            rCheckBox3.Checked = rTextBox23.Enabled = person.IsIncomplete;

            ControlMappings.Add(new ControlMapping { Control = rTxtBanReason, ControlProperty = "Text", DataObject = person, ObjectProperty = "UserInfo.BanReason" });
            ControlMappings.Add(new ControlMapping { Control = radChkAppLogin, ControlProperty = "Checked", DataObject = person, ObjectProperty = "UserInfo.AppLogin" });
            ControlMappings.Add(new ControlMapping { Control = radChkWebLogin, ControlProperty = "Checked", DataObject = person, ObjectProperty = "UserInfo.WebLogin" });
            ControlMappings.Add(new ControlMapping { Control = rDatePicker2, ControlProperty = "Date", DataObject = person, ObjectProperty = "UserInfo.ExpireDate" });
            ControlMappings.Add(new ControlMapping { Control = rTxtBankCartNo, ControlProperty = "Text", DataObject = person, ObjectProperty = "BankCartNo" });
            ControlMappings.Add(new ControlMapping { Control = rTxtShaba, ControlProperty = "Text", DataObject = person, ObjectProperty = "BankShabaNo" });


            rTxtUsername.Text = person.UserInfo.GetRawUsername();
            rTxtPassword.Text = person.UserInfo.GetRawPassword();
            rTxtEmail.Text = person.UserInfo.GetRawEmail();
            rRadioButton1.IsChecked = person.UserInfo.LoginStatus == LoginStatus.Disabled;
            rRadioButton2.IsChecked = person.UserInfo.LoginStatus == LoginStatus.Enabled;

            ControlMappings.Add(new ControlMapping { Control = rTextBox21, ControlProperty = "Text", DataObject = person, ObjectProperty = "Code", ConvertNeeded = true });
            ControlMappings.Add(new ControlMapping { Control = rTextBox24, ControlProperty = "Text", DataObject = person, ObjectProperty = "ArchivePlace" });





            UpdateSystemControlEnabled();

            if (IsStudent())
            {
                rLabel26.Visible = true;
                rTextBox7.Visible = true;
                ControlMappings.Add(new ControlMapping { Control = rTextBox7, ControlProperty = "Value", DataObject = person, ObjectProperty = "EntranceMark" });

                radPageView2.Pages.Remove(radPageViewPage8);
                radPageView2.Pages.Remove(radPageViewPage9);
            }
            else
            {
                rLabel26.Visible = false;
                rTextBox7.Visible = false;
                rGridView3.Mappings.Add(new ColumnMapping { Caption = "متن", ObjectProperty = "Group.Text", Width = 500 });
                rGridView3.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "SendDate" });
                rGridView3.Mappings.Add(new ColumnMapping { Caption = "ساعت", ObjectProperty = "SendHour" });
                rGridView3.Mappings.Add(new ColumnMapping { Caption = "دقیقه", ObjectProperty = "SendMinute" });
                var mobile = long.Parse(person.ContactInfo.Mobile);
                var smsList = DbContext.GetAll<Sms>().Where(m => m.Number.Trim() == "0" + mobile.ToString()).OrderByDescending(m => m.SendDate);
                rGridView3.DataBind(smsList);
            }

            if (IsEmployee())
            {
                ControlMappings.Add(new ControlMapping { Control = rTextBox22, ControlProperty = "Text", DataObject = person, ObjectProperty = "Position" });
            }
            else
            {
                radPageView1.Pages.Remove(radPageViewPage6);
            }

            if (IsTeacher())
            {
                ControlMappings.Add(new ControlMapping { Control = rCheckBox1, ControlProperty = "Checked", DataObject = person, ObjectProperty = "HasToefle" });
                ControlMappings.Add(new ControlMapping { Control = rCheckBox2, ControlProperty = "Checked", DataObject = person, ObjectProperty = "HasIelts" });
            }
            else
            {
                radPageView1.Pages.Remove(radPageViewPage7);
            }

            rGridComboBoxAccessGroup.Columns.Add("نام گروه کاربری", "نام گروه کاربری", "Name");
            rGridComboBoxAccessGroup.DataSource = DbContext.GetAllEntities<AccessGroup>();

            ControlMappings.Add(new ControlMapping { Control = rGridComboBoxAccessGroup, ControlProperty = "Value", DataObject = person, ObjectProperty = "UserInfo.AccessGroup" });

            rGridViewAccessTags.Mappings.Add(new ColumnMapping { Caption = "نــوع", ObjectProperty = "TypeText" });
            rGridViewAccessTags.DataBind(person.UserInfo.AccessTags);
        }

        private void lnkSelectFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Picture Files|*.jpg;*.bmp";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;
            pictureBox1.Image = new Bitmap(dialog.FileName);
        }

        private void lnkWebcam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCapture frm = new frmCapture();
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            pictureBox1.Image = frm.CapturedImage;
        }

        private void lnkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void frmPersonDetail_Load(object sender, EventArgs e)
        {
            radPageView1.SelectedPage = radPageViewPage1;
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            frmSelect frm = new frmSelect(DbContext.GetAllEntities<Department>(), new ColumnMapping { Caption = "نام دپارتمان", ObjectProperty = "Name" });
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            Department department = frm.GetSelectedObject<Department>();
            if (rGridView1.DataSource.Contains(department))
            {
                rMessageBox.ShowError("این دپارتمان قبلا اضافه شده است.");
                return;
            }
            rGridView1.Insert(department);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            //            Department department = rGridView1.GetSelectedObject<Department>();
            rGridView1.RemoveSelectedRow();
        }

        protected override void AfterValidate()
        {

        }

        protected override void AfterBindToObject()
        {
            try
            {
                Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();

                if (IsPersonRepeated(person.FarsiFirstName, person.FarsiLastName, person.FarsiFatherName, person.BirthDate.ToShortDateString()))
                {
                    CancelClosing();
                    return;
                }

                //            person.AllowedDepartments.SyncWith(rGridView1.DataSource);
                person.AllowedDepartments.SyncPreciseWith(rGridView1.DataSource);

                person.EnglishFirstName = Services.NormalizeEnglishString(person.EnglishFirstName);
                person.EnglishLastName = Services.NormalizeEnglishString(person.EnglishLastName);
                person.EnglishFatherName = Services.NormalizeEnglishString(person.EnglishFatherName);

                if (pictureBox1.Image != null)
                {
                    Bitmap convertType = TwainImageConverter.ConvertType(new Bitmap(pictureBox1.Image), ImageFormat.Jpeg);
                    person.Photo.Picture = new Bitmap(convertType);
                    convertType.Dispose();
                }


                //Check for OTHER PERSON use this username or not (using encrypted username)
                if (rRadioButton2.IsChecked
                    && (radChkWebLogin.IsChecked || radChkAppLogin.IsChecked))
                {
                    Core.DomainModel.Person p = Core.DomainModel.Person.FromUsername(UserInfo.Encrypt(rTxtUsername.Text.Trim()), LoginStatus.Enabled, true);
                    if (p != null && p.Id != person.Id)
                    {
                        rMessageBox.ShowError("شناسه کاربری قبلا استفاده شده است");
                        CancelClosing();
                        return;
                    }
                }


                if (rRadioButton1.IsChecked)
                    person.UserInfo.LoginStatus = LoginStatus.Disabled;
                if (rRadioButton2.IsChecked)
                    person.UserInfo.LoginStatus = LoginStatus.Enabled;

                if (radChkWebLogin.IsChecked || radChkAppLogin.IsChecked)
                {
                    Regex regex =
                        new Regex(
                            @"^([a-zA-Z0-9_\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                    if (!regex.IsMatch(rTxtEmail.Text.Trim()))
                    {
                        if (rMessageBox.ShowQuestion("مشکل امنیتی: آدرس ایمیل ورود به سیستم صحیح نیست. آیا واقعا مطمئن هستید؟") != DialogResult.Yes)
                        {
                            CancelClosing();
                            return;
                        }
                    }
                }

                //            if ((radChkWebLogin.IsChecked || radChkAppLogin.IsChecked))
                {
                    person.UserInfo.SetUsername(rTxtUsername.Text.Trim());
                    person.UserInfo.SetPassword(rTxtPassword.Text);
                    person.UserInfo.SetEmail(rTxtEmail.Text.Trim());
                }

                if (rRadioButton1.IsChecked)
                    person.UserInfo.Deactivate();

                if (radChkWebLogin.IsChecked)
                    person.UserInfo.ActivateWeb();
                else
                    person.UserInfo.DeactivateWeb();

                if (radChkAppLogin.IsChecked)
                    person.UserInfo.ActivateApp();
                else
                    person.UserInfo.DeactivateApp();

                person.UserInfo.AccessTags.SyncWith(rGridViewAccessTags.DataSource);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void UpdateSystemControlEnabled()
        {
            rGridComboBoxAccessGroup.Enabled = radChkAppLogin.Enabled = radChkWebLogin.Enabled = rRadioButton2.IsChecked;
            rGridComboBoxAccessGroup.Enabled = radChkAppLogin.IsChecked;
            rTxtBanReason.Enabled = rRadioButton1.IsChecked;
            rTxtUsername.Enabled = rTxtPassword.Enabled = rTxtEmail.Enabled = radChkWebLogin.IsChecked || radChkAppLogin.IsChecked;
            if (radChkWebLogin.IsChecked)
            {
                rDatePicker2.Enabled = true;
                if (rDatePicker2.Date == null)
                    rDatePicker2.Date = Program.CurrentPeriod.EndDate.AddDays(1);
            }
        }

        private void rCheckBox3_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rTextBox23.Enabled = rCheckBox3.Checked;
        }

        private bool IsStudent()
        {
            return Tag is Student;
        }

        private bool IsEmployee()
        {
            return Tag is Employee;
        }

        private bool IsTeacher()
        {
            return Tag is Teacher;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string firstName = (e.Argument as string[])[0];
            string lastName = (e.Argument as string[])[1];
            string fatherName = (e.Argument as string[])[2];
            string birthDate = (e.Argument as string[])[3];

            IsPersonRepeated(firstName, lastName, fatherName, birthDate);
        }

        private bool IsPersonRepeated(string firstName, string lastName, string fatherName, string birthDate)
        {
            Core.DomainModel.Person currentPerson = GetProcessingObject<Core.DomainModel.Person>();
            Core.DomainModel.Person person;
            try
            {
                //                File.AppendAllText("D:\\log2.txt", string.Format("started {0} \r\n", firstName));
                //                person = Core.DomainModel.Person.FromName(firstName, lastName, fatherName);
                person = Core.DomainModel.Person.FromInfo(firstName, lastName, fatherName, birthDate);
                //                File.AppendAllText("D:\\log2.txt", "Finished \r\n");
            }
            catch (Exception e)
            {
                //                File.AppendAllText("D:\\log2.txt", "ex - {0} \r\n" + e);
                rMessageBox.ShowError(e.Message);
                return false;
            }

            if (person != null && person.Id != currentPerson.Id)
            {
                rMessageBox.ShowError(string.Format("این فرد قبلا با همین مشخصات با شماره پرونده [{0}] ثبت شده است.",
                                                    person.Code));
                return true;
            }
            return false;
        }

        private void rTextBox5_Leave(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            string firstName = rTextBox1.Text;
            string lastName = rTextBox3.Text;
            string fatherName = rTextBox5.Text;
            //            string birthdate = rDatePicker1.Date.ToShortDateString();

            while (backgroundWorkerTranslate.IsBusy)
            {
                backgroundWorkerTranslate.CancelAsync();
                Thread.Sleep(100);
            }

            if (string.IsNullOrEmpty(rTextBox6.Text))
                backgroundWorkerTranslate.RunWorkerAsync(new object[] { fatherName, rTextBox6 });

            //            while (backgroundWorkerTranslate.IsBusy)
            //            {
            //                backgroundWorkerTranslate.CancelAsync();
            //                Thread.Sleep(100);
            //            }

            //            while (backgroundWorker1.IsBusy)
            //            {
            //                backgroundWorker1.CancelAsync();
            //                Thread.Sleep(100);
            //            }
            //            backgroundWorker1.RunWorkerAsync(new string[] {firstName, lastName, fatherName, birthdate});
        }

        private void rTextBox1_Leave(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            string firstName = rTextBox1.Text;

            while (backgroundWorkerTranslate.IsBusy)
            {
                backgroundWorkerTranslate.CancelAsync();
                Thread.Sleep(100);
            }

            if (string.IsNullOrEmpty(rTextBox2.Text))
                backgroundWorkerTranslate.RunWorkerAsync(new object[] { firstName, rTextBox2 });
        }

        private void rTextBox3_Leave(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            string lastName = rTextBox3.Text;

            while (backgroundWorkerTranslate.IsBusy)
            {
                backgroundWorkerTranslate.CancelAsync();
                Thread.Sleep(100);
            }

            if (string.IsNullOrEmpty(rTextBox4.Text))
                backgroundWorkerTranslate.RunWorkerAsync(new object[] { lastName, rTextBox4 });
        }

        private void backgroundWorkerTranslate_DoWork(object sender, DoWorkEventArgs e)
        {
            string name = (e.Argument as object[])[0] as string;
            rTextBox resultTxt = (e.Argument as object[])[1] as rTextBox;
            string result;
            try
            {
                if (backgroundWorkerTranslate.CancellationPending)
                    return;
                //                File.AppendAllText("D:\\log.txt", string.Format("started {0} \r\n", name));
                result = Core.DomainModel.Person.FindEnglishName(name);
                //                File.AppendAllText("D:\\log.txt", "finished \r\n");

                if (backgroundWorkerTranslate.CancellationPending)
                    return;

            }
            catch (Exception ex)
            {
                //                File.AppendAllText("D:\\log.txt", "Canceled \r\n");
                e.Cancel = true;
                rMessageBox.ShowError(ex.Message);
                return;
            }
            e.Result = new object[] { resultTxt, result };
        }

        private void backgroundWorkerTranslate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (backgroundWorkerTranslate.CancellationPending)
                return;

            rTextBox resultTxt = (e.Result as object[])[0] as rTextBox;
            string name = (e.Result as object[])[1] as string;
            resultTxt.Text = name;
        }

        private void radChkAppLogin_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            UpdateSystemControlEnabled();
        }

        private void rRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            UpdateSystemControlEnabled();
        }

        private void rRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            UpdateSystemControlEnabled();
        }

        private void radChkWebLogin_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            UpdateSystemControlEnabled();
        }

        private void rGridViewAccessTags_Add(object sender, EventArgs e)
        {
            AccessTag accessTag = new AccessTag();
            frmAccessTagDetail frm = new frmAccessTagDetail(accessTag);
            if (!frm.ProcessObject())
                return;

            foreach (AccessTag tag in rGridViewAccessTags.DataSource)
            {
                if (tag.Type == accessTag.Type)
                {
                    rMessageBox.ShowError("این مجوز قبلا اضافه شده است.");
                    return;
                }
            }

            rGridViewAccessTags.Insert(accessTag);
        }

        private void rGridViewAccessTags_Edit(object sender, EventArgs e)
        {
            AccessTag accessTag = rGridViewAccessTags.GetSelectedObject<AccessTag>();
            frmAccessTagDetail frm = new frmAccessTagDetail(accessTag);
            if (!frm.ProcessObject())
                return;
            rGridViewAccessTags.UpdateGridView();
        }

        private void rGridViewAccessTags_Delete(object sender, EventArgs e)
        {
            AccessTag accessTag = rGridViewAccessTags.GetSelectedObject<AccessTag>();
            rGridViewAccessTags.RemoveSelectedRow();
        }

        private void rTxtUsername_TextChanged(object sender, EventArgs e)
        {
            if (IsShowed)
                rTxtEmail.Text = rTxtUsername.Text;
        }

        private void lnkPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rTxtPassword.PasswordChar = '\0';
        }

        private void rGridView2_Add(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            Notes note = new Notes() { Person = person };
            frmNoteDetail frm = new frmNoteDetail(note);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            note.Save();
            rGridView2.Insert(note);
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Notes note = rGridView2.GetSelectedObject<Notes>();
            note.RefreshEntity();

            frmNoteDetail frm = new frmNoteDetail(note);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            note.Save();
            rGridView2.UpdateGridView();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            try
            {
                var note = rGridView2.GetSelectedObject<Notes>();
                note.Delete();
                rGridView2.RemoveSelectedRow();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void rGridView3_Add(object sender, EventArgs e)
        {
            frmSmsDetail frm = new frmSmsDetail(selectedperson.ContactInfo.Mobile);
            frm.ShowDialog(this);
        }

        private void radPageViewPage13_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnIDCard_Click(object sender, EventArgs e)
        {
            if (selectedperson == null)
                return;
            
            frmReportParameters frmReportParameters = new frmReportParameters("چاپ کارت پرسنلی");
            frmReportParameters.ShowStructure = false;
            frmReportParameters.ShowDate = false;
            frmReportParameters.ShowBothLanguages = true;
            if (frmReportParameters.ShowDialog(this) != DialogResult.OK)
                return;

            Telerik.Reporting.Report rpt = null;
            if (frmReportParameters.ReportLanguage == ReportLanguages.Farsi)
                rpt = new rptFaIdCardStaff();
            if (frmReportParameters.ReportLanguage == ReportLanguages.English)
                rpt = new rptEnIdCardStaff();
            rpt.DataSource = new[] { selectedperson };
            frmReportViewer frmReport = new frmReportViewer(rpt);
            frmReport.ShowDialog(this);

        }
    }
}
