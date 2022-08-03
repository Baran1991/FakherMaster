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
using Fakher.Reports;
using Fakher.Reports.Ministerial_Reports;
using Fakher.UI.Educational;
using Fakher.UI.Exam;
using Fakher.UI.Report;
using Fakher.UI.SystemFeatures;
using Fakher.UI.Teachers;
using rComponents;

namespace Fakher.UI
{
    public partial class frmTeacherDesktop : rRadForm
    {
        private List<LinkLabel> mAccessLinks;

        public frmTeacherDesktop()
        {
            InitializeComponent();
            if (Program.CurrentTeacher == null)
                return;

            rGridComboBoxDepartment.Columns.Add("نام دپارتمان", "نام دپارتمان", "Name");

            rGridComboBoxPeriod.Columns.Add("نام", "نام", "Name");
            rGridComboBoxPeriod.Columns.Add("تاریخ شروع", "تاریخ شروع", "StartDate");
            rGridComboBoxPeriod.Columns.Add("تاریخ پایان", "تاریخ پایان", "EndDate");

            Fill();
        }

        private void UpdateAccessLinks()
        {
            List<LinkLabel> linkLabels = GetAllLinkLabels();
            foreach (LinkLabel label in linkLabels)
                if (!Program.CurrentTeacher.UserInfo.IsAllowed(label.Text))
                    label.Enabled = false;
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

        private void Fill()
        {
            //pictureBox1.Image = Program.CurrentTeacher.Photo.Picture;
            //lblCode.Text = Program.CurrentTeacher.Code;
            //lblName.Text = Program.CurrentTeacher.FarsiFullname;
            //var lst = Program.CurrentTeacher.TeachingSections.ToList().Select(m => m.Period).Select(m=>m.Department);

            //rGridComboBoxDepartment.DataSource =DbContext.GetAll<Section>().Where(m=>m.Teacher.Id==Program.CurrentTeacher.Id).Select(m=>m.Period.Department).Distinct();
            pictureBox1.Image = Program.CurrentTeacher.Photo.Picture;
            lblCode.Text = Program.CurrentTeacher.Code;
            lblName.Text = Program.CurrentTeacher.FarsiFullname;
            rGridComboBoxDepartment.DataSource = Program.CurrentTeacher.GetTeachingDepartments();
        }

        private void lnkMessageBox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmMessageBox(Program.CurrentTeacher));
        }

        private void frmTeacherDesktop_Load(object sender, EventArgs e)
        {
//            WindowState = FormWindowState.Maximized;
            UpdateAccessLinks();
        }

        private void lnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowDialogForm(new frmPersonPassword(Program.CurrentPerson.UserInfo));
            DbContext.CloseUnitOfWork();
        }

        private void lnkExamRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExamRequest request = new ExamRequest() { Teacher = Program.CurrentTeacher };
            frmExamRequestDetail frm = new frmExamRequestDetail(request);
            if (!frm.ProcessObject())
                return;

            request.Save();
//            frm.Message.Save();

            rMessageBox.ShowInformation("درخواست آزمون با موفقیت ثبت و ارسال گردید. لطفا منتظر تایید/رد آن باشید.");
        }

        private void lnkOralExamPanel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmOralExamHoldingPanel());
            DbContext.CloseUnitOfWork();
        }

        private void lnkTeacherPresence_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EducationalPeriod period = rGridComboBoxPeriod.GetValue<EducationalPeriod>();

            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmPresenceList(Program.CurrentTeacher, period));
            DbContext.CloseUnitOfWork();
        }
        private void lnkActivityListReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { DbContext.OpenUnitOfWork();
            Department department = rGridComboBoxDepartment.GetValue<Department>();
            EducationalPeriod period = rGridComboBoxPeriod.GetValue<EducationalPeriod>();
           
            ShowChildForm(new frmTeacherStudentList(Program.CurrentTeacher, period, department));
            DbContext.CloseUnitOfWork();
        }
        private void lnkClassListReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //DbContext.OpenUnitOfWork(true);
            Department department = rGridComboBoxDepartment.GetValue<Department>();
            EducationalPeriod period = rGridComboBoxPeriod.GetValue<EducationalPeriod>();
            frmClassList frm = new frmClassList(Program.CurrentTeacher,period,department);
            frm.ShowDialog();
            //DbContext.CloseUnitOfWork();
        }
        private void lnkPayrollReceiptReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Department department = rGridComboBoxDepartment.GetValue<Department>();
            EducationalPeriod period = rGridComboBoxPeriod.GetValue<EducationalPeriod>();

//            IQueryable<TeachingContract> teachingContracts = Program.CurrentTeacher.GetContract(period, department);
//            var query = from contract in teachingContracts
//                        from payroll in contract.Payrolls
//                        select payroll;
            frmSelect frm = new frmSelect(Program.CurrentTeacher.Payrolls.OrderByDescending(x => x.Id),
                                          new ColumnMapping {Caption = "رشته", ObjectProperty = "MajorText"},
                                          new ColumnMapping
                                              {Caption = "تاریخ شروع", ObjectProperty = "StartDate.ToShortDateString()"},
                                          new ColumnMapping
                                              {Caption = "تاریخ پایان", ObjectProperty = "EndDate.ToShortDateString()"});

            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            Payroll selectedPayroll = frm.GetSelectedObject<Payroll>();

            rptPayrollReceipt rpt = new rptPayrollReceipt();
            rpt.Fill(selectedPayroll);
            rpt.DataSource = new[] {selectedPayroll};
            frmReportViewer frmViewer = new frmReportViewer(rpt);
            frmViewer.CanPrint = false;
            frmViewer.CanExport = false;
            frmViewer.ShowDialog(this);
        }

        private void rGridComboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Department department = rGridComboBoxDepartment.GetValue<Department>();
            //rGridComboBoxPeriod.Clear();
            //if (department == null)
            //    return;
            //rGridComboBoxPeriod.DataSource = DbContext.GetAll<Section>().Where(m => m.Teacher.Id == Program.CurrentTeacher.Id).Select(m => m.Period).Where(p=>p.Department==department);
            Department department = rGridComboBoxDepartment.GetValue<Department>();
            rGridComboBoxPeriod.Clear();
            if (department == null)
                return;
            rGridComboBoxPeriod.DataSource = Program.CurrentTeacher.GetTeachingPeriods(department);
            
        }
    }
}
