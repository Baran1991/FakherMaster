using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Holding;
using Telerik.WinControls.UI;
using rComponents;

namespace Fakher.UI.Exam
{
    public partial class frmExamHoldingDetail : rRadDetailForm
    {
        public frmExamHoldingDetail(ExamHolding examHolding)
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;

            rGridViewFormations.Mappings.Add(new ColumnMapping { Caption = "روز", ObjectProperty = "DayText" });
            rGridViewFormations.Mappings.Add(new ColumnMapping { Caption = "از ساعت", ObjectProperty = "StartTime" });
            rGridViewFormations.Mappings.Add(new ColumnMapping { Caption = "تا ساعت", ObjectProperty = "FinishTime" });
            rGridViewFormations.Mappings.Add(new ColumnMapping { Caption = "مکان", ObjectProperty = "Place.Name" });
            rGridViewFormations.Mappings.Add(new ColumnMapping { Caption = "ظرفیت", ObjectProperty = "Capacity" });

            rGridViewFormations.DataBind(examHolding.Formations);

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker1,
                ControlProperty = "Date",
                DataObject = examHolding,
                ObjectProperty = "StartDate"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Value",
                DataObject = examHolding,
                ObjectProperty = "FirstSeatNumber"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox2,
                ControlProperty = "Value",
                DataObject = examHolding,
                ObjectProperty = "LastSeatNumber"
            });
        }

//        protected override void AfterValidate()
//        {
//            ExamHolding examHolding = GetProcessingObject<ExamHolding>();
//            if (examHolding is OnlineExamHolding)
//            {
//                OnlineExamHolding mHolding = examHolding as OnlineExamHolding;
//                if (rDatePickerStart.Date == null)
//                {
//                    rMessageBox.ShowError("تاریخ شروع را مشخص کنید.");
//                    CancelClosing();
//                    return;
//                }
//                if (rCheckBox1.IsChecked && rDatePickerFinish.Date == null)
//                {
//                    rMessageBox.ShowError("تاریخ پایان را مشخص کنید.");
//                    CancelClosing();
//                    return;
//                }
//
//                int duration = rTextBoxDuration.GetValue<int>();
//
//                if (rCheckBox2.IsChecked && duration == 0)
//                {
//                    rMessageBox.ShowError("مدت زمان آزمون را تعیین کنید.");
//                    CancelClosing();
//                    return;
//                }
//            }
//            else
//            {
//                if (rDatePicker1.Date == null)
//                {
//                    rMessageBox.ShowError("تاریخ برگزاری را مشخص کنید.");
//                    CancelClosing();
//                    return;
//                }
//                if (rTextBox1.GetValue<int>() == 0)
//                {
//                    rMessageBox.ShowError("اولین شماره صندلی را تعیین کنید.");
//                    CancelClosing();
//                    return;
//                }
//                if (rTextBox2.GetValue<int>() == 0)
//                {
//                    rMessageBox.ShowError("آخرین شماره صندلی را تعیین کنید.");
//                    CancelClosing();
//                    return;
//                }
//                if (rGridViewFormations.DataSource.Count == 0)
//                {
//                    rMessageBox.ShowError("شیفت های برگزاری را مشخص کنید.");
//                    CancelClosing();
//                    return;
//                }
//            }
//        }

        protected override void AfterBindToObject()
        {
            ExamHolding examHolding = GetProcessingObject<ExamHolding>();
            examHolding.Formations.SyncWith(rGridViewFormations.DataSource);
        }

        private void rGridViewFormations_Add(object sender, EventArgs e)
        {
            Formation formation = new Formation();
            formation.Day = rDatePicker1.Date.GetDayOfWeek();
            formation.CapacityPolicy = FormationCapacityPolicy.Specific;
            frmFormationDetail frm = new frmFormationDetail(formation);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            if (formation.CapacityPolicy != FormationCapacityPolicy.Specific)
            {
                rMessageBox.ShowError("ظرفیت اتاق حتما باید مشخص باشد.");
                return;
            }
            rGridViewFormations.Insert(formation);
        }

        private void rGridViewFormations_Edit(object sender, EventArgs e)
        {
            Formation formation = rGridViewFormations.GetSelectedObject<Formation>();
            frmFormationDetail frm = new frmFormationDetail(formation);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            if (formation.CapacityPolicy != FormationCapacityPolicy.Specific)
            {
                rMessageBox.ShowError("ظرفیت اتاق حتما باید مشخص باشد.");
                return;
            }
            rGridViewFormations.UpdateGridView();
        }

        private void rGridViewFormations_Delete(object sender, EventArgs e)
        {
            rGridViewFormations.RemoveSelectedRow();
        }
    }
}
