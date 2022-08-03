using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Consult;
using rComponents;

namespace Fakher.UI.Consult
{
    public partial class frmConsultationDetail : rRadDetailForm
    {
        public frmConsultationDetail(Consultation consultation)
        {
            InitializeComponent();
            SetProcessingObject(consultation);

            rComboBox1.DataSource = typeof(ConsultationCategory).GetEnumDescriptions();
            rComboBox2.DataSource = typeof(ConsultationViewPolicy).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = consultation, ObjectProperty = "Title" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Text", DataObject = consultation, ObjectProperty = "Question" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox3, ControlProperty = "Text", DataObject = consultation, ObjectProperty = "Answer" });
            ControlMappings.Add(new ControlMapping { Control = rComboBox1, ControlProperty = "SelectedIndex", DataObject = consultation, ObjectProperty = "Category" });
            ControlMappings.Add(new ControlMapping { Control = rComboBox2, ControlProperty = "SelectedIndex", DataObject = consultation, ObjectProperty = "ViewPolicy" });

            lblName.Text = consultation.Fullname;
            lblSubmitDateTime.Text = consultation.SubmitDate.ToShortDateString() + " " + consultation.SubmitTime;
            lblEmail.Text = consultation.Email;
            lblPhone.Text = consultation.Phone;
        }

        protected override void AfterBindToObject()
        {
            Consultation consultation = GetProcessingObject<Consultation>();
            consultation.SetAnswer(rTextBox3.Text.Trim());
        }
    }
}
