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
    public partial class rptFaIdCard : Report, IConfigurableReport
    {
        public rptFaIdCard()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public static string MajorLessonLabel(Register register)
        {
            string txt = register.Major.Name;
            if (register.Participates.Count == 1 && register.MasterParticipate.SectionItem.Section.Items.Count == 1)
                txt += " - " + register.MasterParticipate.SectionItem.Lesson.Name;
            return txt;
        }

//        public static string LessonTermLabel(Register register)
//        {
//            string txt = "";
//            if (register.Participates.Count == 1)
//                txt = register.MasterParticipate.Lesson.Name + " - ";
//            txt += register.Period.Name;
//            return txt;
//        }

//        public static IList GetParticipates(Register register, int periodId)
//        {
//            EducationalPeriod period = DbContext.FromId<EducationalPeriod>(periodId);
//            return register.GetParticipates(period);
//        }

        public static IList GetFormations(Register register)
        {
            List<Formation> formations = new List<Formation>();
            foreach (Participate participate in register.Participates)
            {
                foreach (Formation formation in participate.SectionItem.Section.Formations)
                {
                    if(!formations.Contains(formation))
                        formations.Add(formation);
                }
            }
            var query = from f in formations orderby f.Day , f.Time select f;
            formations = query.ToList();
            return formations;
        }

//        public static PersianDate GetValidationDate(Register register)
//        {
//            var query = from r in register
//                        orderby r.EndDate descending
//                        select p.EndDate;
//            return query.FirstOrDefault();
//        }

        #region Implementation of IConfigurableReport

        public IReportParameterForm ParamForm { get; set; }

        public bool CustomDataset
        {
            get { return true; }
        }

        public string ReportName
        {
            get { return "گزارش کارت دانشجویی"; }
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