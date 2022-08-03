using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using rComponents;
using Fakher.Core.DomainModel;

namespace Fakher.UI.PreEnrollment
{
    public partial class frmPreEnrollmentDetail : rRadDetailForm
    {
        public frmPreEnrollmentDetail(Fakher.Core.DomainModel.PreEnrollment preEnrollment)
        {
            InitializeComponent();

            ControlMappings.Add(new ControlMapping { Control = rTxtFirstname, ControlProperty = "Text", DataObject = preEnrollment, ObjectProperty = "FirstName" });
            ControlMappings.Add(new ControlMapping { Control = rTxtLastname, ControlProperty = "Text", DataObject = preEnrollment, ObjectProperty = "LastName" });
            ControlMappings.Add(new ControlMapping { Control = rTxtProvince, ControlProperty = "Text", DataObject = preEnrollment, ObjectProperty = "Province" });
            ControlMappings.Add(new ControlMapping { Control = rTxtCity, ControlProperty = "Text", DataObject = preEnrollment, ObjectProperty = "City" });
            ControlMappings.Add(new ControlMapping { Control = rTxtEmail, ControlProperty = "Text", DataObject = preEnrollment, ObjectProperty = "Email" });
            ControlMappings.Add(new ControlMapping { Control = rTxtPhone, ControlProperty = "Text", DataObject = preEnrollment, ObjectProperty = "Phone" });
            ControlMappings.Add(new ControlMapping { Control = rComboBox1, ControlProperty = "SelectedIndex", DataObject = preEnrollment, ObjectProperty = "Status" });

            lblDateTime.Text = preEnrollment.RegisterDateTime;
            lblEmployee.Text = preEnrollment.Employee != null ? preEnrollment.Employee.FarsiFullname : "نامشخص";
            rComboBox1.DataSource = typeof(Fakher.Core.DomainModel.PreEnrollment.ContactStatus).GetEnumDescriptions();
        }

        private void frmPreEnrollmentDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
