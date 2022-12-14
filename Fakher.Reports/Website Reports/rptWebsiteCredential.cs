using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using rComponents;

namespace Fakher.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptIdCard.
    /// </summary>
    public partial class rptWebsiteCredential : Report, IConfigurableReport
    {
        public rptWebsiteCredential()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public static string GetUsername(Person person)
        {
            if (!person.UserInfo.WebLogin)
                return "غیرفعال";

            string username = person.UserInfo.GetRawUsername();
            if (string.IsNullOrEmpty(username))
                return "غیرفعال";
            return username;
        }

        public static string GetPassword(Person person)
        {
            if (!person.UserInfo.WebLogin)
                return "غیرفعال";

            string password = person.UserInfo.GetRawPassword();
            if (string.IsNullOrEmpty(password))
                return "غیرفعال";
            return password;
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش شناسه وب سایت"; }
        }

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Student.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Student.FarsiLastName"}
                           };
            }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            frm.ShowStructure = true;
            frm.ShowMajor = true;
            frm.ShowLesson = frm.ShowSection = true;
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
//            IList<Register> registers = frm.SectionItem.GetFarsiOrderedParticipates().Select(x => x.Register).ToList();
//            DataSet = registers;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
        }

        #endregion
    }
}