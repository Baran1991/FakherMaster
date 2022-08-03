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
    public partial class rptFaIdCardStaff : Report, IConfigurableReport
    {
        public rptFaIdCardStaff()
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
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش کارت پرسنلی"; }
        }
        

        public List<List<object>> ColumnMappings
        {
            get
            {
                return new List<List<object>>
                           {
                               new List<object> {"نام", "Person.FarsiFirstName"},
                               new List<object> {"نام خانوادگی", "Person.FarsiLastName" }
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
            IList<Register> registers = frm.SectionItem.GetFarsiOrderedParticipates().Select(x => x.Register).ToList();
            DataSet = registers;
        }

        public void Apply(IReportParameterForm frm)
        {
            DataSource = DataSet;
            return;

            IList<Participate> participates = frm.SectionItem.GetParticipates();
            var query = from participate in participates
                        select participate.Register;
            DataSource = query.ToList();
        }

        #endregion
    }
}