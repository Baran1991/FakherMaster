using System.Collections;
using System.Collections.Generic;
using FluentNHibernate.MappingModel;

namespace Fakher.Core.Report
{
    public interface IConfigurableReport
    {
        IReportParameterForm ParamForm { get; set; }
        bool CustomDataset { get; }
        string ReportName { get; }
        List<List<object>> ColumnMappings { get; }
        IEnumerable DataSet { get; set; }

        void Configure(IReportParameterForm frm);
        void PrepareDataset(IReportParameterForm frm);
        void Apply(IReportParameterForm frm);
    }
}