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
using Fakher.UI.Person;
using Fakher.UI.Report;
using rComponents;
using Telerik.WinControls.Enumerations;

namespace Fakher.UI.Reception
{
    public partial class frmReserveLevelDeterminationWizard : rRadForm
    {
        private static string mLastActionText;
        private bool mCustomChangeTabs;
        private ReserveLevelDeterminationWizardAction mAction;
        private Reserve mReserve;

        private int StepIndex
        {
            get
            {
                return radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            }
        }

        public frmReserveLevelDeterminationWizard()
        {
            InitializeComponent();

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage1;
            mCustomChangeTabs = false;

            rGridComboBoxReserveLst.Columns.Add("نام لیست", "نام لیست", "Name");
            rGridComboBoxReserveLst.Columns.Add("ظرفیت", "ظرفیت", "Capacity");
            rGridComboBoxReserveLst.Columns.Add("باقیمانده", "باقیمانده", "Remainder");
            rGridComboBoxReserveLst.Columns.Add("شهریه", "شهریه", "TuitionFee");

            //            rGridViewSectionReserves.Mappings.Add(new ColumnMapping { Caption = "تاریخ رزرو", ObjectProperty = "ReserveDate" });
            //            rGridViewSectionReserves.Mappings.Add(new ColumnMapping { Caption = "لیست رزرو", ObjectProperty = "ReserveList.Name" });
            //            rGridViewSectionReserves.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "Status" });

            rGridViewReserves2.Mappings.Add(new ColumnMapping { Caption = "تاریخ رزرو", ObjectProperty = "ReserveDate" });
            rGridViewReserves2.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "ReserveList.Major.Name" });
            rGridViewReserves2.Mappings.Add(new ColumnMapping { Caption = "لیست رزرو", ObjectProperty = "ReserveList.Name" });
            rGridViewReserves2.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
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
                if (rRadioButton1.ToggleState == ToggleState.On)
                {
                    mAction = ReserveLevelDeterminationWizardAction.SectionReserve;
                    mLastActionText = rRadioButton1.Text;
                }
                if (rRadioButton2.ToggleState == ToggleState.On)
                {
                    mAction = ReserveLevelDeterminationWizardAction.ListReserve;
                    mLastActionText = rRadioButton2.Text;
                }

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

                financialDocumentControl1.Databind(new FinancialDocument(), FinancialHeading.LevelDeterminationSignup);
                GotoNextStep();
                return;
            }


            if (StepIndex == 2) // Reserve List
            {
                if (rGridViewReserves2.DataSource.Count == 0)
                {
                    rMessageBox.ShowError("دانشجو در هیچ لیستی رزرو نشده است.");
                    return;
                }
                mReserve.Registrar = Program.CurrentEmployee.FarsiFormalName;

                GotoNextStep();
                return;
            }
            if (StepIndex == 3) //Financial
            {
                if (financialDocumentControl1.DataSource.Count == 0)
                {
                    if (rMessageBox.ShowQuestion("اطلاعات مالی این دانشجو وارد نشده است. آیا مایل به ذخیره بدون اطلاعات مالی هستید ؟") != DialogResult.Yes)
                        return;
                }
                foreach (FinancialItem item in financialDocumentControl1.DataSource)
                    
                    mReserve.FinancialDocument.Items.Add(item);

                GotoFinalStep();
                return;
            }

            if (StepIndex == 4) // Final
            {
                try
                {
                    student.Reserves.Add(mReserve);
                    student.Save();
                    Program.CurrentEmployee.RegisterTransactionFor(mReserve);

                    //// show the Reserve Reciept
                    rptLevelDeterminationReceipt rpt = new rptLevelDeterminationReceipt();
                    rpt.DataSource = mReserve;
                    frmReportViewer frmReport = new frmReportViewer(rpt) { AutoPrint = true };
                    frmReport.ShowDialog(this);

                    Close();
                    return;
                }
                catch (Exception ex)
                {
                }

            }
        }

        private void majorSelector2_SelectedChanged(object sender, EventArgs e)
        {
            rGridComboBoxReserveLst.Clear();
            Major major = majorSelector2.Major;
            if (major == null)
                return;
            if (mAction == ReserveLevelDeterminationWizardAction.ListReserve)
                rGridComboBoxReserveLst.DataSource = ReserveList.GetReserveListByType(Program.CurrentPeriod, major, ReserveList.ReserveType.LevelDetermination);
            if (mAction == ReserveLevelDeterminationWizardAction.SectionReserve)
                rGridComboBoxReserveLst.DataSource = ReserveList.GetSectionLevelDeterminationList(Program.CurrentPeriod, major);
        }

        private void radBtnReserve_Click(object sender, EventArgs e)
        {
            Student student = studentSearchBox1.SelectedStudent;
            ReserveList reserveList = rGridComboBoxReserveLst.GetValue<ReserveList>();
            if (reserveList == null)
            {
                rMessageBox.ShowError("لیست رزرو را انتخاب کنید.");
                return;
            }
            if (rGridViewReserves2.DataSource.Count > 0)
            {
                rMessageBox.ShowError("امکان ثبت نام رزرو بیش از یک بار وجود ندارد.");
                return;
            }

            foreach (Reserve rGridViewReserve in rGridViewReserves2.DataSource)
            {
                if (rGridViewReserve.ReserveList.Id == reserveList.Id)
                {
                    rMessageBox.ShowError("دانشجو قبلا در این لیست ثبت نام شده است.");
                    return;
                }
            }

            try
            {
                mReserve = student.Reserve(reserveList);
                //foreach (FinancialItem item in financialDocumentControl1.DataSource)
                //    mReserve.FinancialDocument.Items.Add(item);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }

            rGridViewReserves2.Insert(mReserve);
        }

        private void frmReserveWizard_Load(object sender, EventArgs e)
        {
            if (mLastActionText != null)
            {
                rRadioButton1.IsChecked = rRadioButton1.Text == mLastActionText;
                rRadioButton2.IsChecked = rRadioButton2.Text == mLastActionText;
            }
        }

        private void rGridViewReserves2_Delete(object sender, EventArgs e)
        {
            rGridViewReserves2.RemoveSelectedRow();
            mReserve = null;
        }
    }

    public enum ReserveLevelDeterminationWizardAction
    {
        SectionReserve,
        ListReserve
        //        ReserveCancel
    }

}


