using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Reports.Ministerial_Reports;
using Fakher.UI.Report;
using rComponents;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using SortOrder = rComponents.SortOrder;

namespace Fakher.UI.Ministerial
{
    public partial class frmCalculatePayroll : rRadDetailForm
    {
        private Payroll mPayroll;
        private bool mCustomChangeTabs;

        public frmCalculatePayroll(bool forTeacher, bool forEmployee)
        {
            InitializeComponent();

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage1;
            mCustomChangeTabs = false;

            rGridComboBox1.Columns.Add("نام", "نام", "FarsiFullname");

            if (forTeacher)
                rGridComboBox2.Columns.Add("رشته", "رشته", "Major.Name");
            rGridComboBox2.Columns.Add("تاریخ شروع", "تاریخ شروع", "StartDate");
            rGridComboBox2.Columns.Add("تاریخ پایان", "تاریخ پایان", "EndDate");

            if (forTeacher)
                rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Contract.Major.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ شروع", ObjectProperty = "StartDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ پایان", ObjectProperty = "EndDate" });

            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "سرفصل", ObjectProperty = "HeadingText" });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FinancialTypeText" });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "نوع پرداخت", ObjectProperty = "PayrollContract.Contract.PaymentSystemText" });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "Description" });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "تعداد", ObjectProperty = "Count" });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "واحد", ObjectProperty = "Unit" });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "نرخ", ObjectProperty = "Fee", Type = ColumnType.Money });
            rGridViewItems.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "Amount", Type = ColumnType.Money, AggregateSummary = AggregateSummary.Sum });

            if (forTeacher)
            {
                rGridView2.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Section.Major.Name" });
                rGridView2.Mappings.Add(new ColumnMapping { Caption = "گروه", ObjectProperty = "Section.FarsiName" });
            }
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "آیتم", ObjectProperty = "ConditionText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "مقدار", ObjectProperty = "RateElement.Value" });

            if (forTeacher)
                rGridComboBox1.DataSource = Teacher.GetActiveTeachers();
            if (forEmployee)
                rGridComboBox1.DataSource = Employee.GetActiveEmployees();
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

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Staff staff = rGridComboBox1.GetValue<Staff>();
            if (staff == null)
                return;
            rGridComboBox2.DataSource = staff.Contracts;
        }

        private void rGridViewItems_Add(object sender, EventArgs e)
        {
            if (mPayroll.PayrollContracts.Count == 0)
                return;
            PayrollItem item = new PayrollItem();
            frmPayrollItemDetail frm = new frmPayrollItemDetail(item, mPayroll.PayrollContracts.ToArray());
            if (!frm.ProcessObject())
                return;
            //            PayrollContract payrollContract = mPayroll.PayrollContracts[0];
            //            payrollContract.AddItem(item);
            item.PayrollContract.AddItem(item);
            rGridViewItems.Insert(item);
        }

        private void rGridViewItems_Delete(object sender, EventArgs e)
        {
            PayrollItem item = rGridViewItems.GetSelectedObject<PayrollItem>();
            if (mPayroll.PayrollContracts.Count == 0)
                return;
            rGridViewItems.RemoveSelectedRow();
            PayrollContract payrollContract = mPayroll.PayrollContracts[0];
            payrollContract.Items.Remove(item);
        }

        private void rGridViewItems_Edit(object sender, EventArgs e)
        {
            PayrollItem item = rGridViewItems.GetSelectedObject<PayrollItem>();
            frmPayrollItemDetail frm = new frmPayrollItemDetail(item, mPayroll.PayrollContracts.ToArray());
            if (!frm.ProcessObject())
                return;
            rGridViewItems.UpdateGridView();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Staff staff = rGridComboBox1.GetValue<Staff>();
            Contract contract = rGridComboBox2.GetValue<Contract>();

//            PersianDate startDate = rDatePicker1.Date;
//            PersianDate endDate = rDatePicker2.Date;

            if (staff == null)
            {
                rMessageBox.ShowError("شخص را انتخاب کنید.");
                return;
            }
            if (contract == null)
            {
                rMessageBox.ShowError("حداقل یک قرارداد را اضافه کنید.");
                return;
            }

            contract.Progress += new EventHandler(teachingContract_Progress);

            if (StepIndex == 0) //Start
            {
                try
                {
                    //                    if (teachingContract.HasPayroll(startDate, endDate))
                    //                        if (rMessageBox.ShowQuestion("برای این بازه تاریخ، قبلا یک فیش حقوقی محاسبه و صادر شده است. از محاسبه و صدور مجدد آن اطمینان دارید؟") != DialogResult.Yes)
                    //                            return;
                    if (rGridView1.DataSource.Count == 0)
                    {
                        rMessageBox.ShowError("حداقل یک قرارداد را اضافه کنید.");
                        return;
                    }
                    //                    if (!(startDate >= teachingContract.StartDate && startDate <= teachingContract.EndDate))
                    //                        if (rMessageBox.ShowQuestion("تاریخ شروع محاسبه، خارج از بازه تاریخ قرارداد است. آیا مطمئن هستید؟") != DialogResult.Yes)
                    //                            return;
                    //                    if (!(endDate >= teachingContract.StartDate && endDate <= teachingContract.EndDate))
                    //                        if (rMessageBox.ShowQuestion("تاریخ پایان محاسبه، خارج از بازه تاریخ قرارداد است. آیا مطمئن هستید؟") != DialogResult.Yes)
                    //                            return;

                    radProgressBar1.Visible = true;
                    radProgressBar1.Value1 = 0;
                    Cursor = Cursors.WaitCursor;
                    Application.DoEvents();

                    mPayroll = new Payroll { Staff = staff };
                    mPayroll.PayrollContracts.SyncWith(rGridView1.DataSource);
                    mPayroll.PreCalculate();

                    var query = from payrollContract in mPayroll.PayrollContracts
                                from conditionValue in payrollContract.Contract.ConditionValues
                                select conditionValue;
                    rGridView2.DataBind(query);
                    //                    GroupDescriptor descriptor1 = new GroupDescriptor();
                    //                    descriptor1.GroupNames.Add("گروه", ListSortDirection.Ascending);
                    //                    rGridView2.RadGridView.GroupDescriptors.Add(descriptor1);
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
                finally
                {
                    radProgressBar1.Value1 = radProgressBar1.Maximum;
                    radProgressBar1.Visible = false;
                    Cursor = Cursors.Default;
                    Application.DoEvents();
                }
            }

            if (StepIndex == 1)
            {
                try
                {
                    radProgressBar1.Visible = true;
                    radProgressBar1.Value1 = 0;
                    Cursor = Cursors.WaitCursor;
                    Application.DoEvents();


                    //Sync conditionValues back from gridview
                    mPayroll.Calculate();
                    rGridViewItems.DataBind(mPayroll.AllItems);
                    PayrollContract payrollContract = rGridView1.GetSelectedObject<PayrollContract>();
                    var selectedContract = payrollContract.Contract;
                    if (selectedContract.KharBar>0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.KharBar;
                        item.Heading = PayrollItemHeading.Kharbar;
                        item.Unit = selectedContract.KharBarUnit;
                        item.FinancialType = FinancialType.Credit;
                        
                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.Maskan > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.Maskan;
                        item.Heading = PayrollItemHeading.Maskan;
                        item.Unit = selectedContract.MaskanUnit;
                        item.FinancialType = FinancialType.Credit;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.AyabZahab > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.AyabZahab;
                        item.Heading = PayrollItemHeading.Transportation;
                        item.Unit = selectedContract.AyabZahabUnit;
                        item.FinancialType = FinancialType.Credit;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.Sanavat > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.Sanavat;
                        item.Heading = PayrollItemHeading.Sanavat;
                        item.Unit = selectedContract.SanavatUnit;
                        item.FinancialType = FinancialType.Credit;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.Taahol > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.Taahol;
                        item.Heading = PayrollItemHeading.Taahol;
                        item.Unit = selectedContract.TaaholUnit;
                        item.FinancialType = FinancialType.Credit;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.Nahar > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.Nahar;
                        item.Heading = PayrollItemHeading.Food;
                        item.Unit = selectedContract.NaharUnit;
                        item.FinancialType = FinancialType.Credit;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.ExamMin > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.ExamMin;
                        item.Heading = PayrollItemHeading.ExamMin;
                        item.Unit = selectedContract.ExamMinUnit;
                        item.FinancialType = FinancialType.Credit;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.ExamFinal > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.ExamFinal;
                        item.Heading = PayrollItemHeading.ExamFinal;
                        item.Unit = selectedContract.ExamFinalUnit;
                        item.FinancialType = FinancialType.Credit;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.ExamOther > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.ExamOther;
                        item.Heading = PayrollItemHeading.ExamSayer;
                        item.Unit = selectedContract.ExamOtherUnit;
                        item.FinancialType = FinancialType.Credit;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.Mosahebe > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.Mosahebe;
                        item.Heading = PayrollItemHeading.Mosahebe;
                        item.Unit = selectedContract.MosahebeUnit;
                        item.FinancialType = FinancialType.Credit;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.SoratJalase > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.SoratJalase;
                        item.Heading = PayrollItemHeading.SoratJalase;
                        item.Unit = selectedContract.SoratJalaseUnit;
                        item.FinancialType = FinancialType.Credit;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.Pazirayee > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.Pazirayee;
                        item.Heading = PayrollItemHeading.Pazirayee;
                        item.Unit = selectedContract.PazirayeeUnit;
                        item.FinancialType = FinancialType.Credit;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.Marker > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.Marker;
                        item.Heading = PayrollItemHeading.Marker;
                        item.Unit = selectedContract.MarkerUnit;
                        item.FinancialType = FinancialType.Credit;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.KharidEntesharat > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.KharidEntesharat;
                        item.Heading = PayrollItemHeading.Entesharat;
                        item.Unit = selectedContract.KharidEntesharatUnit;
                        item.FinancialType = FinancialType.Debt;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.Taakhirat > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.Taakhirat;
                        item.Heading = PayrollItemHeading.Taakirat;
                        item.Unit = selectedContract.TaakhiratUnit;
                        item.FinancialType = FinancialType.Debt;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.Sab > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.Sab;
                        item.Heading = PayrollItemHeading.Sab;
                        item.Unit = selectedContract.SabUnit;
                        item.FinancialType = FinancialType.Debt;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                    if (selectedContract.Sayer > 0)
                    {
                        PayrollItem item = new PayrollItem();
                        item.Fee = selectedContract.Sayer;
                        item.Heading = PayrollItemHeading.SayerKosorat;
                        item.Unit = selectedContract.SayerUnit;
                        item.FinancialType = FinancialType.Debt;

                        item.Count = 1;
                        item.PayrollContract = payrollContract;
                        payrollContract.AddItem(item);
                        rGridViewItems.Insert(item);
                    }
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
                finally
                {
                    radProgressBar1.Value1 = radProgressBar1.Maximum;
                    radProgressBar1.Visible = false;
                    Cursor = Cursors.Default;
                    Application.DoEvents();
                }
            }

            if (StepIndex == 2) //Preview
            {
                btnNext.Text = "صدور فیش";
            }

            if (StepIndex == 3) //Finish
            {
                mPayroll.Save();
                Close();
            }

            GotoNextStep();
        }

        void teachingContract_Progress(object sender, EventArgs e)
        {
            if (radProgressBar1.Value1 < radProgressBar1.Maximum)
                radProgressBar1.Value1++;
            Application.DoEvents();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            GotoPrevStep();
        }

        private void lnkPayrollReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (mPayroll == null)
                return;

            rptPayrollReceipt rpt = new rptPayrollReceipt();
            rpt.Fill(mPayroll);
            rpt.DataSource = new[] { mPayroll };
            frmReportViewer frmViewer = new frmReportViewer(rpt);
            frmViewer.ShowDialog(this);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Staff staff = rGridComboBox1.GetValue<Staff>();
            Contract contract = rGridComboBox2.GetValue<Contract>();
            PersianDate startDate = rDatePicker1.Date;
            PersianDate endDate = rDatePicker2.Date;

            if (staff == null)
            {
                rMessageBox.ShowError("شخص را انتخاب کنید.");
                return;
            }

            if (contract == null)
            {
                rMessageBox.ShowError("قرارداد را انتخاب کنید.");
                return;
            }

            if (startDate == null)
            {
                rMessageBox.ShowError("تاریخ شروع محاسبه را وارد کنید.");
                return;
            }

            if (endDate == null)
            {
                rMessageBox.ShowError("تاریخ پایان محاسبه را وارد کنید.");
                return;
            }

            foreach (PayrollContract pContract in rGridView1.DataSource)
            {
                if (pContract.Contract.Id == contract.Id)
                {
                    rMessageBox.ShowError("این قرارداد قبلا اضافه شده است.");
                    return;
                }
            }

            PayrollContract payrollContract = new PayrollContract();
            payrollContract.Contract = contract;
            payrollContract.StartDate = startDate;
            payrollContract.EndDate = endDate;

            rGridView1.Insert(payrollContract);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            PayrollContract payrollContract = rGridView1.GetSelectedObject<PayrollContract>();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            ConditionValue conditionValue = rGridView2.GetSelectedObject<ConditionValue>();
            frmConditionValueDetail frm = new frmConditionValueDetail(conditionValue);
            if (!frm.ProcessObject())
                return;
            rGridView2.UpdateGridView();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            ConditionValue conditionValue = rGridView2.GetSelectedObject<ConditionValue>();
            conditionValue.TeachingContract.ConditionValues.Remove(conditionValue);
            rGridView2.RemoveSelectedRow();
        }
    }
}
