using System.Collections;
using System.Collections.Generic;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using System.Linq;
using rComponents;

namespace Fakher.Reports.Ministerial_Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    public partial class rptPayrollReceipt : Report, IConfigurableReport
    {
        private static IReportParameterForm mFrm;
        public Payroll Payroll { get; set; }
        public bool forTeacher { get; set; }
        public bool forEmployee { get; set; }

        public rptPayrollReceipt()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش فیش حقوق"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowCustomStructure = true;
            frm.CustomText1 = "شخص:";
            frm.CustomGridColumns1 = new Dictionary<string, string> { { "نام", "FarsiFullname" } };
            frm.CustomGrid1SelectedIndexChanged += OnCustomGrid1SelectedIndexChanged;
            frm.ShowCustomGrid1 = true;

            frm.CustomText2 = "فیش حقوق:";
            Dictionary<string, string> dictionary = new Dictionary<string, string> ();
            if(forTeacher)
                dictionary.Add("قرارداد", "MajorText");
            dictionary.Add("تاریخ شروع", "StartDate");
            dictionary.Add("تاریخ پایان", "EndDate");
            frm.CustomGridColumns2 = dictionary;
            frm.ShowCustomGrid2 = true;
            frm.CustomGrid2SelectedIndexChanged += OnCustomGrid2SelectedIndexChanged;

            if (forTeacher)
                frm.CustomGridDataSource1 = Teacher.GetActiveTeachers();
            if (forEmployee)
                frm.CustomGridDataSource1 = Employee.GetActiveEmployees();

//            frm.ShowTeacherStructure = true;
//            frm.ShowPayrolls = true;
        }

        private void OnCustomGrid1SelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            Staff staff = ParamForm.CustomGridValue1 as Staff;
            if (staff == null)
                return;
            ParamForm.CustomGridDataSource2 = staff.Payrolls;
        }

        private void OnCustomGrid2SelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            Staff staff = ParamForm.CustomGridValue1 as Staff;
            Payroll payroll = ParamForm.CustomGridValue2 as Payroll;
            if (payroll == null)
                return;

//            ParamForm.CustomGridViewDataSource = major.GetExams(ParamForm.Period, evaluationItem);
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            mFrm = ParamForm;
            Payroll payroll = ParamForm.CustomGridValue2 as Payroll;

            if (payroll == null)
                throw new MessageException("فیش حقوق را انتخاب کنید.");

            Fill(payroll);
            DataSet = new[] { payroll };
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion

        public void Fill(Payroll payroll)
        {
            Payroll = payroll;
            var query = from payrollContract in Payroll.PayrollContracts
                        from item in payrollContract.Items
                        from element in item.RateElements
                        group element by element.Condition
                            into g
                            select g.Key;
            List<SalaryCondition> conditions = query.ToList();
            double left = 0;
            double width = panel1.Width.Value / (conditions.Count + 1);
            double height = panel1.Height.Value;
            panel1.Items.Clear();
            panel2.Items.Clear();
            for (int index = conditions.Count - 1; index >= 0; index--)
            {
                SalaryCondition condition = conditions[index];

                Telerik.Reporting.TextBox txtCondition = new Telerik.Reporting.TextBox();
                txtCondition.Style.TextAlign = HorizontalAlign.Center;
                txtCondition.Style.VerticalAlign = VerticalAlign.Middle;
                txtCondition.Style.BorderStyle.Default = BorderType.Solid;
                txtCondition.Style.Font.Name = "B Nazanin";
                txtCondition.Style.Font.Bold = true;
                txtCondition.Style.Font.Size = new Unit(11, UnitType.Point);
                txtCondition.Style.BackgroundColor = Color.DarkCyan;
                txtCondition.Width = new Unit(width, UnitType.Cm);
                txtCondition.Height = new Unit(height, UnitType.Cm);
                txtCondition.Left = new Unit(left, UnitType.Cm);
                txtCondition.Top = new Unit(0, UnitType.Cm);
                txtCondition.Value = condition.ToDescription();
                panel1.Items.Add(txtCondition);

                Telerik.Reporting.TextBox txtValue = new Telerik.Reporting.TextBox();
                txtValue.Style.TextAlign = HorizontalAlign.Center;
                txtValue.Style.VerticalAlign = VerticalAlign.Middle;
                txtValue.Style.BorderStyle.Default = BorderType.Solid;
                txtValue.Style.Font.Name = "B Nazanin";
                txtValue.Style.Font.Size = new Unit(11, UnitType.Point);
                txtValue.Width = new Unit(width, UnitType.Cm);
                txtValue.Height = new Unit(height, UnitType.Cm);
                txtValue.Left = new Unit(left, UnitType.Cm);
                txtValue.Top = new Unit(0, UnitType.Cm);
                txtValue.Value = string.Format("=rptPayrollReceipt_GetElementValue(ReportItem.DataObject.RawData, '{0}')", condition.ToString());
                panel2.Items.Add(txtValue);

                left += width;
            }
            Telerik.Reporting.TextBox txtSection = new Telerik.Reporting.TextBox();
            txtSection.Style.TextAlign = HorizontalAlign.Center;
            txtSection.Style.VerticalAlign = VerticalAlign.Middle;
            txtSection.Style.BorderStyle.Default = BorderType.Solid;
            txtSection.Style.Font.Name = "B Nazanin";
            txtSection.Style.Font.Bold = true;
            txtSection.Style.Font.Size = new Unit(11, UnitType.Point);
            txtSection.Style.BackgroundColor = Color.DarkCyan;
            txtSection.Width = new Unit(width, UnitType.Cm);
            txtSection.Height = new Unit(height, UnitType.Cm);
            txtSection.Left = new Unit(left, UnitType.Cm);
            txtSection.Top = new Unit(0, UnitType.Cm);
            txtSection.Value = "آیتم";
            panel1.Items.Add(txtSection);

            Telerik.Reporting.TextBox txtSectionName = new Telerik.Reporting.TextBox();
            txtSectionName.Style.TextAlign = HorizontalAlign.Center;
            txtSectionName.Style.VerticalAlign = VerticalAlign.Middle;
            txtSectionName.Style.BorderStyle.Default = BorderType.Solid;
            txtSectionName.Style.Font.Name = "B Nazanin";
            txtSectionName.Style.Font.Size = new Unit(11, UnitType.Point);
            txtSectionName.Width = new Unit(width, UnitType.Cm);
            txtSectionName.Height = new Unit(height, UnitType.Cm);
            txtSectionName.Left = new Unit(left, UnitType.Cm);
            txtSectionName.Top = new Unit(0, UnitType.Cm);
            txtSectionName.Value = "=Fields.Text";
            panel2.Items.Add(txtSectionName);
        }

        public static IList<PayrollItem> rptPayrollReceipt_GetCreditItems(Payroll payroll)
        {
            return payroll.CreditItems.ToList();
        }

        public static IList<PayrollItem> rptPayrollReceipt_GetElementItems(Payroll payroll)
        {
            var query = from payrollcontract in payroll.PayrollContracts
                        from item in payrollcontract.Items
                        where item.RateElements.Count > 0
                        select item;
            return query.ToList();
        }

        public static IList<PayrollItem> rptPayrollReceipt_GetDebtItems(Payroll payroll)
        {
            return payroll.DebtItems.ToList();
        }

        public static string rptPayrollReceipt_GetNote(Payroll payroll)
        {
            //            TeachingContract teachingContract = payroll.PayrollContracts[0].Contract as TeachingContract;
            //            if(teachingContract != null)
            //                return teachingContract.Period.PayrollNote;
            if (mFrm != null)
                return mFrm.Period.PayrollNote;
            return "بدیهی است که هرگونه اشتباه قابل برگشت می باشد.";
        }

        public static string rptPayrollReceipt_GetElementValue(PayrollItem item, string conditionText)
        {
            SalaryCondition condition = SalaryCondition.BasePayment;
            EnumItem[] enumItems = typeof(SalaryCondition).GetEnumItems();
            foreach (EnumItem enumItem in enumItems)
                if (enumItem.Name == conditionText)
                {
                    condition = (SalaryCondition)enumItem.Value;
                    break;
                }

            return item.GetConditionValue(condition);
        }
    }
}