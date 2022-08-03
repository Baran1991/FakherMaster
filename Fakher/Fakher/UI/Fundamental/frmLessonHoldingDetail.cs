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
using rComponents;

namespace Fakher.UI.Fundamental
{
    public partial class frmLessonHoldingDetail : rRadDetailForm
    {
        public frmLessonHoldingDetail(Major major, LessonHolding lessonHolding)
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;

            rGridComboBoxEvalProtocol.Columns.Add("نام", "نام", "Name");
            rGridComboBoxEvalProtocol.DataSource = EvaluationProtocol.GetProtocols(Program.CurrentPeriod);
            rGridComboBoxEvalProtocol.Value = null;

            rGridComboBoxResultProtocol.Columns.Add("نام", "نام", "Name");
            rGridComboBoxResultProtocol.DataSource = ResultProtocol.GetProtocols(Program.CurrentPeriod);
            rGridComboBoxResultProtocol.Value = null;

            rGridComboBoxPlacementProtocol.Columns.Add("نام", "نام", "Name");
            rGridComboBoxPlacementProtocol.DataSource = PlacementProtocol.GetProtocols(Program.CurrentPeriod);
            rGridComboBoxPlacementProtocol.Value = null;

            lessonSelector1.Databind(major.Lessons);

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            rGridView1.DataBind(lessonHolding.AllowedMajors);

            rGridViewEquivalences.Mappings.Add(new ColumnMapping {Caption = "دپارتمان", ObjectProperty = "EquivalentLesson.Major.Department.Name"});
            rGridViewEquivalences.Mappings.Add(new ColumnMapping {Caption = "رشته", ObjectProperty = "EquivalentLesson.Major.Name"});
            rGridViewEquivalences.Mappings.Add(new ColumnMapping {Caption = "درس/سطح معادل", ObjectProperty = "EquivalentLesson.Name"});
            rGridViewEquivalences.DataBind(lessonHolding.LessonEquivalences);

            ControlMappings.Add(new ControlMapping
            {
                Control = lessonSelector1,
                ControlProperty = "Lesson",
                DataObject = lessonHolding,
                ObjectProperty = "Lesson"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rGridComboBoxEvalProtocol,
                ControlProperty = "Value",
                DataObject = lessonHolding,
                ObjectProperty = "EvaluationProtocol"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rGridComboBoxResultProtocol,
                ControlProperty = "Value",
                DataObject = lessonHolding,
                ObjectProperty = "ResultProtocol"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rGridComboBoxPlacementProtocol,
                ControlProperty = "Value",
                DataObject = lessonHolding,
                ObjectProperty = "PlacementProtocol"
            });

        }

        protected override void AfterBindToObject()
        {
            LessonHolding lessonHolding = GetProcessingObject<LessonHolding>();

            if (rGridView1.DataSource.Count == 0)
            {
                rMessageBox.ShowError("رشته های مجاز برای این ارائه را مشخص کنید.");
                CancelClosing();
                return;
            }

//            lessonHolding.AllowedMajors.SyncWith(rGridView1.DataSource);
            lessonHolding.AllowedMajors.SyncPreciseWith(rGridView1.DataSource);
            lessonHolding.LessonEquivalences.SyncWith(rGridViewEquivalences.DataSource);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            frmSelect frm = new frmSelect(Program.CurrentDepartment.Majors, new ColumnMapping {Caption = "نام", ObjectProperty = "Name"});
            frm.MultiSelect = true;
            if(frm.ShowDialog(this) != DialogResult.OK)
                return;

            List<Major> majors = frm.GetSelectedObjects<Major>();
            foreach (Major selectedMajor in majors)
            {
                foreach (Major major in rGridView1.DataSource)
                {
                    if (major.Id == selectedMajor.Id)
                    {
                        rMessageBox.ShowError(string.Format("رشته {0} قبلا اضافه شده است.", selectedMajor.Name));
                        return;
                    }
                }
            }

            foreach (Major selectedMajor in majors)
                rGridView1.Insert(selectedMajor);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            rGridView1.RemoveSelectedRow();
        }

        private void rGridViewEquivalences_Add(object sender, EventArgs e)
        {
            LessonEquivalence equivalence = new LessonEquivalence();
            frmLessonEquivalenceDetail frm = new frmLessonEquivalenceDetail(equivalence);
            if(!frm.ProcessObject())
                return;
            rGridViewEquivalences.Insert(equivalence);
        }

        private void rGridViewEquivalences_Delete(object sender, EventArgs e)
        {
            LessonEquivalence equivalence = rGridViewEquivalences.GetSelectedObject<LessonEquivalence>();
            rGridViewEquivalences.RemoveSelectedRow();
        }
    }
}
