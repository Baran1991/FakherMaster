using System;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;
using Telerik.WinControls.UI;

namespace Fakher.UI.Reception
{
    public partial class frmPreEnrollmentWizard : rRadDetailForm
    {
        private bool mCustomChangeTabs;

        public frmPreEnrollmentWizard()
        {
            InitializeComponent();

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage6;
            mCustomChangeTabs = false;

            rGridViewPreEnrollmentList.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            rGridViewPreEnrollmentList.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });

            rGridViewPreEnrollmentList.DataBind(PreEnrollmentList.GetLists(Program.CurrentDepartment));
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
            Core.DomainModel.PreEnrollment selectedPreEnrollment = preEnrollmentSearchBox1.SelectedPreEnrollment;
            PreEnrollmentList selectedPreEnrollmentList = rGridViewPreEnrollmentList.GetSelectedObject<PreEnrollmentList>();

            if (StepIndex == 0) //Start
            {

            }

            if (StepIndex == 1) //Search
            {
                if (preEnrollmentSearchBox1.SelectedPreEnrollment == null)
                {
                    rMessageBox.ShowError("یک دانشجو را انتخاب کنید.");
                    return;
                }
            }

            if (StepIndex == 2) //PreEnrollment List
            {
                if (selectedPreEnrollmentList == null)
                {
                    rMessageBox.ShowError("لیست پیش ثبت نام را انتخاب کنید.");
                    return;
                }

                try
                {
                    selectedPreEnrollment.PreEnrollmentList = selectedPreEnrollmentList;
                    selectedPreEnrollment.LastUpdateDate = PersianDate.Today;
                    selectedPreEnrollment.Employee = Program.CurrentEmployee;
                    selectedPreEnrollment.Save();
                }
                catch (Exception ex)
                {
                    Program.SaveLog("خطا - " + ex.Message);
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
                btnNext.Text = "تـــایــیــد";
                btnPrev.Enabled = false;
            }

            if (StepIndex == 3) // End
            {
                Program.SaveLog(string.Format("پیش ثبت نام ({0}) در ({1})",
                              selectedPreEnrollment.Fullname,
                              selectedPreEnrollmentList.Name));

                if (rCheckBox1.Checked)
                {
                    rptPreEnrollmentReceipt rpt = new rptPreEnrollmentReceipt();
                    rpt.DataSource = new[] {selectedPreEnrollment};
                    frmReportViewer frm = new frmReportViewer(rpt) {AutoPrint = true};
                    frm.ShowDialog(this);
                }

                Close();
            }
            GotoNextStep();
        }
    }
}
