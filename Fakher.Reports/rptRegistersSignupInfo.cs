using System.Collections;
using System.Collections.Generic;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using rComponents;
using System.Linq;

namespace Fakher.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptDiscountedRegisters.
    /// </summary>
    public partial class rptRegistersSignupInfo : Report, IConfigurableReport
    {
        public rptRegistersSignupInfo()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public static string TodayDate()
        {
            return PersianDate.Today.ToShortDateString();
        }

        private void txtReportName_ItemDataBinding(object sender, EventArgs e)
        {
            
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش اطلاعات ثبت نام دانشجویان"; }
        }

        public List<List<object>> ColumnMappings
        {
            get 
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Student.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Student.FarsiLastName"},
                               new List<object> {"نوع ثبت نام", "RegisterParticipationText"},
                               new List<object> {"نحوه ثبت نام", "MasterParticipateEnrollmentTypeText"},
                               new List<object> {"وضعیت", "TypeText"},
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = true;
            frm.ShowMajor = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            DataSet = Register.GetRegisters(frm.Period, frm.Major);
        }

        public void Apply(IReportParameterForm frm)
        {
            txtReportName.Value = ReportName + " رشته " + frm.Major.Name;

            DataSource = DataSet;
        }

        #endregion
    }
}