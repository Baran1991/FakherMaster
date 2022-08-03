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
using Telerik.WinControls.UI;

namespace Fakher.UI.Struture
{
    public partial class frmDepartmentDetail : rRadDetailForm
    {
        private Department selectedDepartment;
        public frmDepartmentDetail(Department department)
        {
            InitializeComponent();
            selectedDepartment = department;
            radPageView1.SelectedPage = radPageViewPage1;
            rCmbReportLanguages.DataSource = typeof (Language).GetEnumDescriptions();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Person.FarsiFullname" });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox1,
                                        ControlProperty = "Text",
                                        DataObject = department,
                                        ObjectProperty = "Code",
                                        ConvertNeeded = true
                                    });

            ControlMappings.Add(new ControlMapping
                                         {
                                             Control = radTextBox1,
                                             ControlProperty = "Text",
                                             DataObject = department,
                                             ObjectProperty = "Name"
                                         });

            ControlMappings.Add(new ControlMapping
                                         {
                                             Control = rCmbRegisterExpression,
                                             ControlProperty = "Text",
                                             DataObject = department,
                                             ObjectProperty = "RegisterExpression"
                                         });

            ControlMappings.Add(new ControlMapping
                                         {
                                             Control = rCmbReportLanguages,
                                             ControlProperty = "SelectedIndex",
                                             DataObject = department,
                                             ObjectProperty = "ReportLanguage"
                                         });

            ControlMappings.Add(new ControlMapping
                                         {
                                             Control = rChkSignupReceiptEducationalEvents,
                                             ControlProperty = "Checked",
                                             DataObject = department,
                                             ObjectProperty = "ShowSignupReceiptEducationalEvents"
                                         });

            foreach (RadListDataItem item in rCmbRegisterExpression.Items)
                if (!string.IsNullOrEmpty(department.RegisterExpression) && item.Text == department.RegisterExpression)
                {
                    rCmbRegisterExpression.SelectedItem = item;
                    break;
                }

            rGridView1.DataBind(department.ResponsiblePersons);
        }

        protected override void AfterBindToObject()
        {
            Department department = GetProcessingObject<Department>();
            department.ResponsiblePersons.SyncWith(rGridView1.DataSource);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            //Department department = GetProcessingObject<Department>();
            
            frmSelect frm = new frmSelect(Employee.GetAllEmployees(), new ColumnMapping {Caption = "نام", ObjectProperty = "FarsiFullname"});
            frm.MultiSelect = true;
            if(frm.ShowDialog(this) != DialogResult.OK)
                return;
            foreach (Employee employee in frm.GetSelectedObjects<Employee>())
            {
                ResponsiblePerson person = new ResponsiblePerson() { Person = employee, Department = selectedDepartment, ReceiveEmails = true};
                rGridView1.Insert(person);
            }
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            rGridView1.RemoveSelectedRow();
        }
    }
}
