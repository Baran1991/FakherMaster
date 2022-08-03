using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;
using rComponents;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Fakher.UI.Holding
{
    public partial class frmFormationDetail : rRadDetailForm
    {
        public frmFormationDetail(Formation formation)
        {
            InitializeComponent();
            string[] descriptions = typeof(WeekDay).GetEnumDescriptions();
            rComboBox1.DataSource = descriptions;

            rCmbPolicy.DataSource = typeof (FormationCapacityPolicy).GetEnumDescriptions();

            rGridComboBox1.Columns.Add("نام مکان", "نام مکان", "Name");
            rGridComboBox1.Columns.Add("ظرفیت", "ظرفیت", "CapacityText");
            rGridComboBox1.DataSource = DbContext.GetAllEntities<Place>();

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rComboBox1,
                                        ControlProperty = "SelectedIndex",
                                        DataObject = formation,
                                        ObjectProperty = "Day"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox1,
                                        ControlProperty = "Text",
                                        DataObject = formation,
                                        ObjectProperty = "StartTime"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox2,
                                        ControlProperty = "Text",
                                        DataObject = formation,
                                        ObjectProperty = "FinishTime"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rGridComboBox1,
                                        ControlProperty = "Value",
                                        DataObject = formation,
                                        ObjectProperty = "Place"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rCmbPolicy,
                                        ControlProperty = "SelectedIndex",
                                        DataObject = formation,
                                        ObjectProperty = "CapacityPolicy"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTxtCapacity,
                                        ControlProperty = "Value",
                                        DataObject = formation,
                                        ObjectProperty = "Capacity"
                                    });

            rTxtCapacity.Enabled = formation.CapacityPolicy == FormationCapacityPolicy.Specific;
        }

        protected override void AfterBindToObject()
        {
            Formation formation = GetProcessingObject<Formation>();
            if(formation.StartTimeInMinutes >= formation.FinishTimeInMinutes)
            {
                rMessageBox.ShowError("زمان شروع باید کوچکتر از زمان پایان برگزاری باشد.");
                CancelClosing();
                return;
            }
            if(formation.CapacityPolicy == FormationCapacityPolicy.Specific
                && formation.Capacity == 0)
            {
                rMessageBox.ShowError("مقدار ظرفیت باید بزرگتر از صفر باشد.");
                CancelClosing();
                return;
            }
        }

        private void rCmbPolicy_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            FormationCapacityPolicy policy = (FormationCapacityPolicy) rCmbPolicy.SelectedIndex;
            Place place = rGridComboBox1.GetValue<Place>();
            rTxtCapacity.Enabled = policy == FormationCapacityPolicy.Specific;
            if(policy == FormationCapacityPolicy.PlaceBased)
            {
                rTxtCapacity.Type = rTextBoxType.Text;
                if(place != null)
                    rTxtCapacity.Text = place.CapacityText;
            }
            if(policy == FormationCapacityPolicy.Specific)
            {
                rTxtCapacity.Type = rTextBoxType.Numeric;
            }
        }
    }
}
