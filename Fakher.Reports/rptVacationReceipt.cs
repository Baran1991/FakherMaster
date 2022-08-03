using System.Collections;
using System.Collections.Generic;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;

namespace Fakher.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rptSignupReciept.
    /// </summary>
    public partial class rptVacationReceipt : Report, IConfigurableReport
    {
        public rptVacationReceipt()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public static List<FinancialItem> GetItems(Register register)
        {
            List<FinancialItem> result = new List<FinancialItem>();
            foreach (FinancialItem item in register.FinancialDocument.Items)
            {
                if(item.Payment != null || item is Discount)
                    result.Add(item);
            }
            return result;
        }

        public static string GetVacationReceiptNote(Register register)
        {
            return register.Period.VacationReceiptNote;
        }

        public static string rptVacationReceipt_GetRegistrarName(Register register)
        {
            Person registrar = register.GetRegistrar();
            if (registrar != null)
                return registrar.FarsiFormalName;
            return register.Registrar;
        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return false; }
        }

        public string ReportName
        {
            get { return "گزارش رسید مرخصی"; }
        }

        public List<List<object>> ColumnMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable DataSet { get; set; }

        public void Configure(IReportParameterForm frm)
        {
            throw new NotImplementedException();
        }

        public void PrepareDataset(IReportParameterForm frm)
        {
            throw new NotImplementedException();
        }

        public void Apply(IReportParameterForm frm)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}