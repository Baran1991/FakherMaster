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

namespace Fakher.UI.Educational.Sections
{
    public partial class frmReplacementDetail : rRadDetailForm
    {
        public frmReplacementDetail(Replacement replacement)
        {
            InitializeComponent();

            rGridComboBox1.Columns.Add("نام", "نام", "FarsiFullname");
            rGridComboBox1.DataSource = DbContext.GetAllEntities<Teacher>();

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker1,
                ControlProperty = "Date",
                DataObject = replacement,
                ObjectProperty = "Date"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Value",
                DataObject = replacement,
                ObjectProperty = "ReplacementHours"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox4,
                ControlProperty = "Text",
                DataObject = replacement,
                ObjectProperty = "Reason"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rGridComboBox1,
                ControlProperty = "Value",
                DataObject = replacement,
                ObjectProperty = "Teacher"
            });

            if (replacement.SectionItem != null)
                rLblTeacher.Text = replacement.SectionItem.Section.Teacher.FarsiFullname;
        }
    }
}
