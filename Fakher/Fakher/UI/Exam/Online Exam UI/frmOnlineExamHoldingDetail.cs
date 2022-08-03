using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Telerik.WinControls.UI;
using rComponents;

namespace Fakher.UI.Exam.Online_Exam_UI
{
    public partial class frmOnlineExamHoldingDetail : rRadDetailForm
    {
        public frmOnlineExamHoldingDetail(OnlineExamHolding mHolding)
        {
            InitializeComponent();
            SetProcessingObject(mHolding);

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePickerStart,
                ControlProperty = "Date",
                DataObject = mHolding,
                ObjectProperty = "StartDate"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtStartTime,
                ControlProperty = "Text",
                DataObject = mHolding,
                ObjectProperty = "StartTime"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rCheckBox1,
                ControlProperty = "IsChecked",
                DataObject = mHolding,
                ObjectProperty = "HasEnd"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePickerFinish,
                ControlProperty = "Date",
                DataObject = mHolding,
                ObjectProperty = "EndDate"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtFinishTime,
                ControlProperty = "Text",
                DataObject = mHolding,
                ObjectProperty = "EndTime"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rCheckBox2,
                ControlProperty = "IsChecked",
                DataObject = mHolding,
                ObjectProperty = "HasDuration"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxDuration,
                ControlProperty = "Value",
                DataObject = mHolding,
                ObjectProperty = "Duration"
            });

//            rDatePickerStart.Date = mHolding.StartDate;
//            rTxtStartTime.Text = mHolding.StartTime;
//            rCheckBox1.IsChecked = mHolding.HasEnd;
//            rDatePickerFinish.Date = mHolding.EndDate;
//            rTxtFinishTime.Text = mHolding.EndTime;
//            rCheckBox2.IsChecked = mHolding.HasDuration;
//            rTextBoxDuration.Value = mHolding.Duration;

            rDatePickerFinish.Enabled = rTxtFinishTime.Enabled = rCheckBox1.IsChecked;
            rTextBoxDuration.Enabled = rCheckBox2.IsChecked;
        }

        private void rCheckBox1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rDatePickerFinish.Enabled = rTxtFinishTime.Enabled = rCheckBox1.IsChecked;
        }

        private void rCheckBox2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rTextBoxDuration.Enabled = rCheckBox2.IsChecked;
        }

        protected override void AfterValidate()
        {
            OnlineExamHolding mHolding = GetProcessingObject<OnlineExamHolding>();
            if (rDatePickerStart.Date == null)
            {
                rMessageBox.ShowError("تاریخ شروع را مشخص کنید.");
                CancelClosing();
                return;
            }
            if (rCheckBox1.IsChecked && rDatePickerFinish.Date == null)
            {
                rMessageBox.ShowError("تاریخ پایان را مشخص کنید.");
                CancelClosing();
                return;
            }

            int duration = rTextBoxDuration.GetValue<int>();

            if (rCheckBox2.IsChecked && duration == 0)
            {
                rMessageBox.ShowError("مدت زمان آزمون را تعیین کنید.");
                CancelClosing();
                return;
            }
        }

        protected override void AfterBindToObject()
        {
            OnlineExamHolding mHolding = GetProcessingObject<OnlineExamHolding>();

//            mHolding.StartDate = rDatePickerStart.Date;
//            mHolding.StartTime = rTxtStartTime.Text;
//            mHolding.HasEnd = rCheckBox1.IsChecked;
//            mHolding.EndDate = rDatePickerFinish.Date;
//            mHolding.EndTime = rTxtFinishTime.Text;
//            mHolding.HasDuration = rCheckBox2.IsChecked;
//            mHolding.Duration = rTextBoxDuration.GetValue<int>();
        }

    }
}
