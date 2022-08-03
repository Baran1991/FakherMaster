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
using Fakher.Core.Report;
using Fakher.Reports;
using Fakher.UI.Educational;
using Fakher.UI.Educational.Students;
using Fakher.UI.Financial;
using Fakher.UI.Person;
using Fakher.UI.Persons;
using Fakher.UI.Report;
using Fakher.UI.Store;
using Fakher.UI.Students;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using rComponents;

namespace Fakher.UI.Reception
{
    public partial class frmReceptionPanel : rRadForm
    {
        private Student selectedStudent;
        private List<LinkLabel> mAccessLinks;
        public frmReceptionPanel()
        {
            InitializeComponent();
        }
        public frmReceptionPanel(Student student)
        {
            InitializeComponent();
            if (student != null)
            {
                selectedStudent = student;
                studentInfo1.Student = selectedStudent;
                if (student.NoteList != null)
                    if (!student.NoteList.Any())
                    {
                        linkLabel1.Visible = false;

                    }
                if (student.BayganiNo > 0)
                {
                    lblBayganiNo.Text = student.BayganiNo.ToString();
                    lblBayganiNo.Visible = true;
                }

                rGridComboBoxPeriod.Columns.Add("نام", "نام", "Name");

                rGridComboBoxMajor.Columns.Add("نام", "نام", "Name");

                IQueryable<Major> registeredMajors = student.GetRegisteredMajors();
                if (registeredMajors.Count() > 0)
                    rGridComboBoxMajor.DataSource = registeredMajors;

            }
            //            IQueryable<EducationalPeriod> periods = student.GetRegisteredPeriods();
            //            if(periods.Count() > 0)
            //                rGridComboBoxPeriod.DataSource = periods.OrderByDescending(x=>x.Id);
        }
        private void frmReceptionPanel_Load(object sender, EventArgs e)
        {
            UpdateAccessLinks();
            if (selectedStudent.GetLastRegister().Quit != null)
                lnkQuitReciept.Enabled = true;
            else
                lnkQuitReciept.Enabled = false;
            if (selectedStudent.GetLastRegister().Type == RegisterType.PartialVacation || selectedStudent.GetLastRegister().Type == RegisterType.TermVacation)
                lnkVacation.Enabled = true;
            else
                lnkVacation.Enabled = false;
            if (selectedStudent.GetLastRegister().Type == RegisterType.Transmition)
                lnkTransition.Enabled = true;
            else
                lnkTransition.Enabled = false;
        }
        private void UpdateAccessLinks()
        {
            List<LinkLabel> linkLabels = GetAllLinkLabels();
            foreach (LinkLabel label in linkLabels)
            {
                label.Enabled = Program.CurrentEmployee.UserInfo.IsAllowed(label.Text);
            }
        }
        private void UpdatePanel()
        {
            studentInfo1.UpdateStudentPanel();
        }
        public string[] GetAccessEvents()
        {
            List<string> accessEvents = new List<string>();
            List<LinkLabel> linkLabels = GetAllLinkLabels();
            foreach (LinkLabel label in linkLabels)
                accessEvents.Add(label.Text);
            return accessEvents.ToArray();
        }
        private List<LinkLabel> GetAllLinkLabels()
        {
            if (mAccessLinks == null)
            {
                mAccessLinks = new List<LinkLabel>();
                List<LinkLabel> linkLabels = FindLinkLabels(Controls);
                mAccessLinks.AddRange(linkLabels);
            }
            return mAccessLinks;
        }
        private List<LinkLabel> FindLinkLabels(Control.ControlCollection controls)
        {
            List<LinkLabel> list = new List<LinkLabel>();
            foreach (Control control in controls)
            {
                if (control is LinkLabel && control.AccessibleRole != AccessibleRole.None)
                    list.Add(control as LinkLabel);
                list.AddRange(FindLinkLabels(control.Controls));
            }
            return list;
        }
        private void lnkStudentDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectedStudent.RefreshEntity();
            if (new frmPersonDetail(selectedStudent).ProcessObject())
            {
                selectedStudent.Save();
                studentInfo1.UpdateStudentPanel();
            }
        }
        private void lnkHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowChildForm(new frmEducationalHistory(selectedStudent));
        }
        private Register GetRegister(RegisterType? type = null)
        {
            EducationalPeriod period = rGridComboBoxPeriod.GetValue<EducationalPeriod>();
            Major major = rGridComboBoxMajor.GetValue<Major>();

            Register register = new Register();
            if (type == null)
                register = selectedStudent.GetRegister(period, major);
            else
                register = selectedStudent.GetRegister(period, major, (RegisterType)type);
            if (register != null)
                return register;

            List<Register> registers = selectedStudent.GetRegisters(Program.CurrentPeriod);

            if (registers.Count == 0)
            {
                Register lastRegister = new Register();
                if (type == null)
                    lastRegister = selectedStudent.GetLastRegister();
                else
                    lastRegister = selectedStudent.GetLastRegister((RegisterType)type);
                string txt = "";
                if (lastRegister != null)
                    txt = string.Format("آخرین فعالیت این شخص در دپارتمان {0}، ترم {1} می باشد", lastRegister.Period.Department.Name, lastRegister.Period.Name);
                rMessageBox.ShowError(string.Format("این دانشجو در دپارتمان جاری سیستم، در هیچ رشته ای ثبت نام قطعی نشده است. {0}", txt));
                return null;
            }
            if (registers.Count == 1)
                return selectedStudent.Registers[0];

            frmSelect frm = new frmSelect(registers, new ColumnMapping { Caption = "رشته های ثبت نامی در این ترم", ObjectProperty = "Major.Name" });
            if (frm.ShowDialog(this) != DialogResult.OK)
                return null;
            return frm.GetSelectedObject<Register>();
        }
        private void lnkSignupReciept_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister(RegisterType.Participation);
            if (register == null)
                return;

            rptSignupReceipt rpt = new rptSignupReceipt();
            rpt.DataSource = new object[] { register };
            frmReportViewer frmReport = new frmReportViewer(rpt);
            frmReport.ShowDialog(this);
        }
        private void lnkIdCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            if (register == null)
                return;

            frmReportParameters frmReportParameters = new frmReportParameters("چاپ کارت دانشجویی");
            frmReportParameters.ShowStructure = false;
            frmReportParameters.ShowDate = false;
            frmReportParameters.ShowBothLanguages = true;
            if (frmReportParameters.ShowDialog(this) != DialogResult.OK)
                return;

            Telerik.Reporting.Report rpt = null;
            if (frmReportParameters.ReportLanguage == ReportLanguages.Farsi)
                rpt = new rptFaIdCard();
            if (frmReportParameters.ReportLanguage == ReportLanguages.English)
                rpt = new rptEnIdCard();
            rpt.DataSource = new[] { register };
            frmReportViewer frmReport = new frmReportViewer(rpt);
            frmReport.ShowDialog(this);
        }

        //        private void lnkSellBook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //        {
        //            Register register = GetRegister();
        //            if (register == null)
        //                return;
        //
        //            ShowChildForm(new frmSellTool(register));
        //        }

        private void lnkQuit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister(RegisterType.FullQuited);
            if (register == null)
                return;

            ShowChildForm(new frmRegisterQuits(register));
        }
        private void lnkRegisterAbsences_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            if (register == null)
                return;

            ShowChildForm(new frmRegisterAbsences(register.Participates, true));
        }
        private void lnkRequests_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //            Register register = GetRegister();
            //            if (register == null)
            //                return;
            ShowChildForm(new frmStudentRequests(selectedStudent));
        }
        private void lnkVacation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister(RegisterType.TermVacation);
            if (register == null)
                return;
        }
        private void lnkNewRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //            Register register = GetRegister();
            Request request = new Request() { Student = selectedStudent };
            frmRequestDetail frm = new frmRequestDetail(request, false);
            if (!frm.ProcessObject())
                return;
            request.Save();
            rMessageBox.ShowInformation(string.Format("درخواست موردنظر با شماره شناسه {0} ثبت گردید.", request.Id + ""));
            UpdatePanel();
        }
        private void rGridComboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            //            EducationalPeriod period = rGridComboBoxPeriod.GetValue<EducationalPeriod>();
            //            rGridComboBoxMajor.Clear();
            //            if (period == null)
            //                return;
            //            rGridComboBoxMajor.DataSource = selectedStudent.GetRegisteredMajors(period);
        }
        private void lnkRegisterQuits_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister(RegisterType.FullQuited);
            ShowChildForm(new frmRegisterQuits(register));
        }
        private void lnkStudentTools_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            ShowChildForm(new frmPersonUseList(register.Student));
        }
        private void lnkMarks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            ShowChildForm(new frmRegisterMarks(register));
        }
        private void lnkAdvanceFinancial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            ShowChildForm(new frmRegisterFinancialDetail(register));
            UpdatePanel();
        }
        private void lnkFinancialWizard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            frmRegisterFinancialWizard frm = new frmRegisterFinancialWizard(register);
            frm.ShowDialog(this);
            UpdatePanel();
        }
        private void rGridComboBoxMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Major major = rGridComboBoxMajor.GetValue<Major>();
            rGridComboBoxPeriod.Clear();
            if (major == null)
                return;
            rGridComboBoxPeriod.DataSource =
                selectedStudent.GetRegisteredPeriods(major).OrderByDescending(x => x.StartDate);
        }
        private void lnkPhotoCorrection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                selectedStudent.Photo.CorrectPhoto(DbContext.CurrentSession.Connection);
                UpdatePanel();
                rMessageBox.ShowInformation("عکس تصحیح شد.");
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
        private void lnkPayTransactions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            frmPayTransactions frm = new frmPayTransactions(register);
            frm.ShowDialog(this);
        }
        private void lnkNextEnrollmentReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            frmNextEnrollmentView frm = new frmNextEnrollmentView(register.Student, register.Major, register.Period);
            frm.ShowDialog(this);
        }
        private void lnkStudentConfigurations_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            frmStudentConfigurations frm = new frmStudentConfigurations(register.Student);
            frm.ShowDialog(this);
        }
        private void lnkMasterCardReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            rptMasterCard rpt = new rptMasterCard();
            rptMasterCard.mMajor = register.Major;
            rptMasterCard.mPeriod = register.Period;
            rpt.Fill();
            rpt.DataSource = new[] { register };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }
        private void lnkWebsiteCredentialReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();

            rptWebsiteCredential rpt = new rptWebsiteCredential();
            rpt.DataSource = new[] { register.Student };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }
        private void lnkCertificateList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            frmCertificateList frm = new frmCertificateList(register);
            frm.ShowDialog(this);
        }
        private void lnkFinancialCommitments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            frmRegisterFinancialCommitmentList frm = new frmRegisterFinancialCommitmentList(register);
            frm.ShowDialog(this);
        }
        private void lnkConsultationApplicants_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            frmConsultationApplicantList frm = new frmConsultationApplicantList(register.Student);
            frm.ShowDialog(this);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            frmNoteList frm = new frmNoteList(selectedStudent);
            //ShowChildForm();
            frm.ShowDialog(this);
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSmsDetail frm = new frmSmsDetail(selectedStudent.ContactInfo.Mobile);
            frm.ShowDialog(this);
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowChildForm(new frmStudentSMSList(selectedStudent));
        }
        private void lnkDelay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            if (register == null)
                return;
            ShowChildForm(new frmRegisterDelays(register.Participates));
        }
        private void lnkQuitReciept_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister(RegisterType.FullQuited);
            if (register == null)
                return;
            rptQuitReceipt rpt = new rptQuitReceipt();
            rpt.DataSource = new[] { register };
            frmReportViewer frm = new frmReportViewer(rpt) { AutoPrint = true };
            frm.ShowDialog(this);
        }
        private void lnkVacation_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registers = selectedStudent.Registers;
            var query = from regis in registers where regis.Type == RegisterType.PartialVacation | regis.Type == RegisterType.TermVacation orderby regis.Id descending select regis;

            var register = query.FirstOrDefault();
            rptVacationReceipt rpt = new rptVacationReceipt();
            rpt.DataSource = new[] { register };
            frmReportViewer frm = new frmReportViewer(rpt) { AutoPrint = true };
            frm.ShowDialog(this);
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Register register = GetRegister(RegisterType.Transmition);
            if (register == null)
                return;

            rptTransitionReceipt rpt = new rptTransitionReceipt();
            rpt.DataSource = new object[] { register };
            frmReportViewer frmReport = new frmReportViewer(rpt);
            frmReport.ShowDialog(this);
        }
        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister(RegisterType.Participation);
            if (register == null)
                return;

            rptBarCodeStudent rpt = new rptBarCodeStudent();
            rpt.DataSource = new object[] { register };
            frmReportViewer frmReport = new frmReportViewer(rpt);
            frmReport.ShowDialog(this);
        }
        private void lnkBayganyNo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (selectedStudent.BayganiNo > 0)
            {
                frmBayganiDetails frm = new frmBayganiDetails(selectedStudent);
                frm.ShowDialog();
            }
            else
            {
                selectedStudent.BayganiNo = selectedStudent.NextBayganiNo();
                selectedStudent.BayganiCreatedBy = Program.CurrentEmployee;
                selectedStudent.BayganiDate = PersianDate.Today;
                selectedStudent.Save();
                lblBayganiNo.Text = selectedStudent.BayganiNo.ToString();
                lblBayganiNo.Visible = true;
            }
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            ShowChildForm(new frmReciptFinancialItems(register));
        }
        private void lnkIDScan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           frmIDScan frm = new frmIDScan(selectedStudent);
           frm.ShowDialog(this);           
        }
        private void lnkNC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmNCScan frm = new frmNCScan(selectedStudent);
            frm.ShowDialog(this);
        }
        private void lnkDoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDocScan frm = new frmDocScan(selectedStudent);
            frm.ShowDialog(this);
        }
        private void lnkQuitHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            frmOutHistoryList frm = new frmOutHistoryList(register.Student);
            frm.ShowDialog(this);            
        }
        private void lnkDsc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = GetRegister();
            frmNoteList frm = new frmNoteList(selectedStudent);
            frm.ShowDialog(this);
        }
    }
}
