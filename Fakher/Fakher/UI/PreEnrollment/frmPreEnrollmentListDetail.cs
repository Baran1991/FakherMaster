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

namespace Fakher.UI.PreEnrollment
{
    public partial class frmPreEnrollmentListDetail : rRadDetailForm
    {
        public frmPreEnrollmentListDetail(PreEnrollmentList enrollmentList)
        {
            InitializeComponent();

            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = enrollmentList, ObjectProperty = "Name" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox4, ControlProperty = "Text", DataObject = enrollmentList, ObjectProperty = "RecieptNote" });
            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePickerDate,
                ControlProperty = "Date",
                DataObject = enrollmentList,
                ObjectProperty = "Date"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxTime,
                ControlProperty = "Text",
                DataObject = enrollmentList,
                ObjectProperty = "Time"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxClassNo,
                ControlProperty = "Value",
                DataObject = enrollmentList,
                ObjectProperty = "ClassNo"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxClassCa,
                ControlProperty = "Value",
                DataObject = enrollmentList,
                ObjectProperty = "ClassCa"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtRegStartTime,
                ControlProperty = "Text",
                DataObject = enrollmentList,
                ObjectProperty = "InternetRegisterStartTime"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtRegEndTime,
                ControlProperty = "Text",
                DataObject = enrollmentList,
                ObjectProperty = "InternetRegisterFinishTime"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rCheckBox4,
                ControlProperty = "IsChecked",
                DataObject = enrollmentList,
                ObjectProperty = "InternetRegisterable"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePickerStDate,
                ControlProperty = "Date",
                DataObject = enrollmentList,
                ObjectProperty = "InternetRegisterStartDate"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePickerEndDate,
                ControlProperty = "Date",
                DataObject = enrollmentList,
                ObjectProperty = "InternetRegisterFinishDate"
            });
            rDatePickerEndDate.Enabled = rDatePickerStDate.Enabled = rTxtRegEndTime.Enabled = rTxtRegStartTime.Enabled = enrollmentList.InternetRegisterable;

        }
        private void rCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rDatePickerEndDate.Enabled = rDatePickerStDate.Enabled = rTxtRegEndTime.Enabled = rTxtRegStartTime.Enabled = rCheckBox4.Checked;

        }
    }
}
