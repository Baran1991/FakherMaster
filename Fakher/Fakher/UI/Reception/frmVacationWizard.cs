using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;
using Telerik.WinControls.Enumerations;

namespace Fakher.UI.Reception
{
    public partial class frmVacationWizard : rRadForm
    {
        private static string mLastActionText;
        private bool mCustomChangeTabs;
        private Register mRegister;

        private int StepIndex
        {
            get
            {
                return radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            }
        }

        public frmVacationWizard()
        {
            InitializeComponent();

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage1;
            mCustomChangeTabs = false;
            rGridComboBoxPeriod.Columns.Add("نام", "نام", "Name");
            rGridComboBoxPeriod.Columns.Add("تاریخ شروع", "تاریخ شروع", "StartDate");
            rGridComboBoxPeriod.Columns.Add("تاریخ پایان", "تاریخ پایان", "EndDate");
           
               
                rGridComboBoxPeriod.DataSource = Program.CurrentDepartment.EducationalPeriods.OrderByDescending(x => x.Id);


        }

        private void radPageView1_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            e.Cancel = !mCustomChangeTabs;
        }

        private void GotoFinalStep()
        {
            btnPrev.Enabled = false;
            btnNext.Text = "تـــایــیــد";
            GotoStep(radPageView1.Pages.Count - 1);
        }

        private void GotoNextStep()
        {
            mCustomChangeTabs = true;
            int index = radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            if (index + 1 < radPageView1.Pages.Count)
                radPageView1.SelectedPage = radPageView1.Pages[index + 1];
            mCustomChangeTabs = false;
        }

        private void GotoStep(int index)
        {
            mCustomChangeTabs = true;
            if (index >= 0)
                radPageView1.SelectedPage = radPageView1.Pages[index];
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

        private void btnPrev_Click(object sender, EventArgs e)
        {
            btnNext.Text = "گـــــام بــعــدی";
            //            if (StepIndex == 1 || StepIndex == 2 || StepIndex == 3)
            //                GotoStep(4);
            //            else
            GotoPrevStep();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Student student = studentSearchBox1.SelectedStudent;

            if (StepIndex == 0)
            {
                GotoNextStep();
                return;
            }

            if (StepIndex == 1)
            {
                if (studentSearchBox1.SelectedStudent == null)
                {
                    rMessageBox.ShowError("یک دانشجو را مشخص کنید.");
                    return;
                }

                financialDocumentControl1.Databind(new FinancialDocument(), FinancialHeading.Signup);
                GotoNextStep();
                return;
            }

            if (StepIndex == 2) //Financial
            {
                if (financialDocumentControl1.DataSource.Count == 0)
                {
                    if (rMessageBox.ShowQuestion("اطلاعات مالی این دانشجو وارد نشده است. آیا مایل به ذخیره بدون اطلاعات مالی هستید ؟") != DialogResult.Yes)
                        return;
                }

                GotoNextStep();
                return;
            }

            if (StepIndex == 3) //Vacation
            {
                var period = rGridComboBoxPeriod.GetValue<EducationalPeriod>();
                List<Register> registers = student.GetRegisters(period, majorSelector1.Major).ToList();
                Register lastMajorRegister = student.GetLastRegister(majorSelector1.Major);
                if(lastMajorRegister==null)
                {
                    rMessageBox.ShowInformation("دانشجو در این درس ثبت نام نکرده است!");
                    return;
                }
                if (lastMajorRegister != null && lastMajorRegister.Period.Id != period.Id)
                    if (
                        rMessageBox.ShowQuestion(
                            string.Format(
                                "آخرین فعالیت این دانشجو در دپارتمان {1} ترم {0} بوده است. از ثبت مرخصی در ترم انتخابی مطمئن هستید؟",
                                lastMajorRegister.Period.Name, lastMajorRegister.Period.Department.Name)) !=
                        DialogResult.Yes)
                        return;

                if (registers.Count > 0)
                {
                    if ((lastMajorRegister.Type != RegisterType.TermVacation || lastMajorRegister.Type != RegisterType.PartialVacation)
                        &&
                        rMessageBox.ShowQuestion(
                            "این دانشجو، قبلا در همین ترم و رشته ثبت نام شده و فعالیت داشته است. ثبت مرخصی منجر به پایان فعالیت قبلی او در این ترم خواهد شد. آیا مطمئن هستید؟") !=
                        DialogResult.Yes)
                        return;
                    if (lastMajorRegister.EndDate > PersianDate.Today)
                        lastMajorRegister.EndDate = PersianDate.Today;
                }

                if (lastMajorRegister.Type == RegisterType.TermVacation || lastMajorRegister.Type == RegisterType.PartialVacation)
                {
                    if (
                        rMessageBox.ShowQuestion(
                            string.Format(
                                "برای این دانشجو قبلا مرخصی ثبت شده است. از ثبت مجدد مرخصی در ترم جاری سیستم مطمئن هستید؟")) !=
                        DialogResult.Yes)
                        return;
                }
                
                mRegister = student.CreateRegister(period, majorSelector1.Major,
                                                   RegisterType.TermVacation, true);
                mRegister.Registrar = Program.CurrentEmployee.FarsiFormalName;
                //                mRegister.RegistrarText = Program.CurrentEmployee.FarsiFormalName;

                if (rRadioButton2.IsChecked)
                {
                    mRegister.Type = RegisterType.TermVacation;
                }
                if (rRadioButton3.IsChecked)
                {
                    try
                    {
                        rDatePicker1.Validate();
                        rDatePicker2.Validate();
                    }
                    catch (Exception ex)
                    {
                        rMessageBox.ShowWarning(ex.Message);
                        return;
                    }

                    mRegister.Type = RegisterType.PartialVacation;
                    mRegister.StartDate = rDatePicker1.Date;
                    mRegister.EndDate = rDatePicker2.Date;
                }

                foreach (FinancialItem item in financialDocumentControl1.DataSource)
                    mRegister.FinancialDocument.Items.Add(item);

                student.Registers.Add(mRegister);
                student.Save();

                GotoFinalStep();
                return;
            }

            if (StepIndex == 4) //Final
            {
                rptVacationReceipt rpt = new rptVacationReceipt();
                rpt.DataSource = mRegister;
                frmReportViewer frmReport = new frmReportViewer(rpt) { AutoPrint = true };
                frmReport.ShowDialog(this);

                Close();
                return;
            }
        }

        private void rRadioButton3_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rGroupBox4.Enabled = rRadioButton3.IsChecked;
        }

        private void rGridComboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var period = rGridComboBoxPeriod.GetValue<EducationalPeriod>();
            //majorSelector1.Databind(period.Department.Majors);
          
        }
    }
}
