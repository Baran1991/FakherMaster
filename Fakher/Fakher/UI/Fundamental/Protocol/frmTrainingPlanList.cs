using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.UI.Fundamental.Protocol;
using rComponents;

namespace Fakher.UI.Struture.Protocol
{
    public partial class frmTrainingPlanList : rRadForm
    {
        public frmTrainingPlanList()
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;
            radPageView1.Pages.Remove(radPageViewPage3);

            rGridComboBox1.Columns.Add("نام", "نام", "Name");

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Id" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Id" });

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام برنامه آموزشی", ObjectProperty = "Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد آیتم آموزشی", ObjectProperty = "Items.Count" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام برنامه آموزشی", ObjectProperty = "Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تعداد آیتم آموزشی", ObjectProperty = "Items.Count" });

            rGridView3.Mappings.Add(new ColumnMapping { Caption = "نام برنامه آموزشی", ObjectProperty = "Name" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "تعداد آیتم آموزشی", ObjectProperty = "Items.Count" });

            rGridComboBox1.DataSource = Program.CurrentDepartment.Majors;
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Major major = rGridComboBox1.GetValue<Major>();
            if(major == null)
                return;
            
            rGridView1.DataBind(TrainingPlan.GetPlans(Program.CurrentPeriod, major, false).ToList());
            rGridView2.DataBind(TrainingPlan.GetPlans(Program.CurrentPeriod, major, true).ToList());
            rGridView3.DataBind(TrainingPlan.GetPlans(Program.CurrentPeriod, major, TrainingPlanType.PostalTrainingPlan).ToList());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Major major = rGridComboBox1.GetValue<Major>();
            if (major == null)
                return;
            TrainingPlan plan = new TrainingPlan() { Major = major, Period = Program.CurrentPeriod };
            frmTrainingPlanDesigner frm = new frmTrainingPlanDesigner(plan);
            if (!frm.ProcessObject())
                return;
            plan.Save();
            rGridView1.Insert(plan);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            TrainingPlan plan = rGridView1.GetSelectedObject<TrainingPlan>();
            frmTrainingPlanDesigner frm = new frmTrainingPlanDesigner(plan);
            if (!frm.ProcessObject())
                return;
            plan.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            TrainingPlan plan = rGridView1.GetSelectedObject<TrainingPlan>();
            plan.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView2_Add(object sender, EventArgs e)
        {
            if(rGridView2.DataSource.Count > 0)
            {
                rMessageBox.ShowError("برای این رشته قبلا یک برنامه آموزشی تعریف شده است.");
                return;
            }

            Major major = rGridComboBox1.GetValue<Major>();
            if (major == null)
                return;
            TrainingPlan plan = new TrainingPlan {Major = major, Period = Program.CurrentPeriod, IsGeneral = true, Type = TrainingPlanType.ExamTrainingPlan};
            frmTrainingPlanDesigner frm = new frmTrainingPlanDesigner(plan);
            if (!frm.ProcessObject())
                return;
            plan.Save();
            rGridView2.Insert(plan);
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            TrainingPlan plan = rGridView2.GetSelectedObject<TrainingPlan>();
            frmTrainingPlanDesigner frm = new frmTrainingPlanDesigner(plan);
            if (!frm.ProcessObject())
                return;
            plan.Save();
            rGridView2.UpdateGridView();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            TrainingPlan plan = rGridView2.GetSelectedObject<TrainingPlan>();
            plan.Delete();
            rGridView2.RemoveSelectedRow();
        }

        private void rGridView3_Add(object sender, EventArgs e)
        {
            if(rGridView3.DataSource.Count > 0)
            {
                rMessageBox.ShowError("برای این رشته قبلا یک برنامه آموزشی تعریف شده است.");
                return;
            }

            Major major = rGridComboBox1.GetValue<Major>();
            if (major == null)
                return;
            TrainingPlan plan = new TrainingPlan {Major = major, Period = Program.CurrentPeriod, IsGeneral = true, Type = TrainingPlanType.PostalTrainingPlan};
            frmTrainingPlanDesigner frm = new frmTrainingPlanDesigner(plan);
            if (!frm.ProcessObject())
                return;
            plan.Save();
            rGridView3.Insert(plan);
        }

        private void rGridView3_Edit(object sender, EventArgs e)
        {
            TrainingPlan plan = rGridView3.GetSelectedObject<TrainingPlan>();
            frmTrainingPlanDesigner frm = new frmTrainingPlanDesigner(plan);
            if (!frm.ProcessObject())
                return;
            plan.Save();
            rGridView3.UpdateGridView();
        }

        private void rGridView3_Delete(object sender, EventArgs e)
        {
            TrainingPlan plan = rGridView3.GetSelectedObject<TrainingPlan>();
            plan.Delete();
            rGridView3.RemoveSelectedRow();
        }
    }
}
