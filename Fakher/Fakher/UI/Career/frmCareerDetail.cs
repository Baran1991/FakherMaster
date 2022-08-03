using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.UI.Career
{
    public partial class frmCareerDetail : rRadDetailForm
    {
        public frmCareerDetail(Fakher.Core.DomainModel.Career career)
        {
            InitializeComponent();

            SetProcessingObject(career);
            radPageView1.SelectedPage = radPageViewPage1;
            rTextBox1.Focus();

            rComboBoxGender.DataSource = typeof(CareerGenderType).GetEnumDescriptions();
            rComboBoxDegree.DataSource = typeof(EducationalDegree).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox1,
                                        ControlProperty = "Text",
                                        DataObject = career,
                                        ObjectProperty = "Name"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rComboBoxGender,
                                        ControlProperty = "SelectedIndex",
                                        DataObject = career,
                                        ObjectProperty = "GenderType"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rComboBoxDegree,
                                        ControlProperty = "SelectedIndex",
                                        DataObject = career,
                                        ObjectProperty = "EducationalDegree"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox2,
                                        ControlProperty = "Text",
                                        DataObject = career,
                                        ObjectProperty = "Qualifications"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rDatePicker1,
                                        ControlProperty = "Date",
                                        DataObject = career,
                                        ObjectProperty = "StartDate"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rDatePicker2,
                                        ControlProperty = "Date",
                                        DataObject = career,
                                        ObjectProperty = "EndDate"
                                    });

            rHtmlEditor1.DocumentText = career.DescriptionHtml;
        }

        protected override void AfterBindToObject()
        {
            Fakher.Core.DomainModel.Career career = GetProcessingObject<Fakher.Core.DomainModel.Career>();
            
            career.DescriptionHtml = Services.NormalizeFarsiString(rHtmlEditor1.BodyHtml);
        }
    }
}
