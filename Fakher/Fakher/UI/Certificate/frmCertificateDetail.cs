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

namespace Fakher.UI.Students
{
    public partial class frmCertificateDetail : rRadDetailForm
    {
        public frmCertificateDetail(Certificate certificate)
        {
            InitializeComponent();
            SetProcessingObject(certificate);
            rPageView1.SelectedPage = radPageViewPage1;

            rComboBox1.DataSource = typeof (CertificateStatus).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Text", DataObject = certificate, ObjectProperty = "Code" });
            ControlMappings.Add(new ControlMapping { Control = majorSelector1, ControlProperty = "Major", DataObject = certificate, ObjectProperty = "Major" });
            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = certificate, ObjectProperty = "RequestDate" });
            ControlMappings.Add(new ControlMapping { Control = rDatePicker2, ControlProperty = "Date", DataObject = certificate, ObjectProperty = "IssueDate" });
            ControlMappings.Add(new ControlMapping { Control = rDatePicker3, ControlProperty = "Date", DataObject = certificate, ObjectProperty = "DeliverDate" });
            ControlMappings.Add(new ControlMapping { Control = rComboBox1, ControlProperty = "SelectedIndex", DataObject = certificate, ObjectProperty = "Status" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Value", DataObject = certificate, ObjectProperty = "Fee" });

            paymentControl1.Databind(certificate.FinancialDocument, FinancialHeading.Certificate);

            IQueryable<Major> majors = certificate.Student.GetRegisteredMajors();
            majorSelector1.Databind(majors);
        }

        protected override void AfterBindToObject()
        {
            Certificate certificate = GetProcessingObject<Certificate>();
            paymentControl1.BindToObject();

            foreach (FinancialItem item in certificate.FinancialDocument.Items)
                Program.CurrentEmployee.RegisterItem(item);
        }
    }
}
