using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;
using SortOrder = rComponents.SortOrder;

namespace Fakher.UI.Exam
{
    public partial class frmExamEnrollmentsList : rRadForm
    {
        public frmExamEnrollmentsList()
        {
            InitializeComponent();

            rGridCmbTrainingPlan.Columns.Add("نام", "نام", "Name");

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نـــام", ObjectProperty = "Name", SortOrder = SortOrder.Ascending});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "Lesson.Name", SortOrder = SortOrder.Ascending});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "آیتم ارزشیابی", ObjectProperty = "EvaluationItem.Name", SortOrder = SortOrder.Ascending });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ظرفیت", ObjectProperty = "Capacity", AggregateSummary = AggregateSummary.Sum, TextAlign = HorizontalAlignment.Center});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "پرشده", ObjectProperty = "EnrollmentCount", AggregateSummary = AggregateSummary.Sum, TextAlign = HorizontalAlignment.Center });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "باقیمانده", ObjectProperty = "RemainderCount", AggregateSummary = AggregateSummary.Sum, TextAlign = HorizontalAlignment.Center });
        }

        private void majorSelector1_SelectedChanged(object sender, EventArgs e)
        {
            rGridCmbTrainingPlan.Clear();
            if (majorSelector1.Major == null)
                return;
            IList<TrainingPlan> plans = TrainingPlan.GetPlans(Program.CurrentPeriod, majorSelector1.Major);
            rGridCmbTrainingPlan.DataSource = plans;
        }

        private void rGridCmbTrainingPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrainingPlan plan = rGridCmbTrainingPlan.GetValue<TrainingPlan>();
            if (plan == null)
                return;

            IQueryable<ExamTrainingItem> examTrainingItems = plan.GetExamItems();
            rGridView1.DataBind(examTrainingItems);
        }
    }
}
