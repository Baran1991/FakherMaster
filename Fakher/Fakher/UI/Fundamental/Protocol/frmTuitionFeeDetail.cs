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

namespace Fakher.UI.Fundamental.Protocol
{
    public partial class frmTuitionFeeDetail : rRadDetailForm
    {
        public frmTuitionFeeDetail(TuitionFee tuitionFee, IList<Major> majors)
        {
            InitializeComponent();

            rComboBox1.DataSource = typeof (RegisterParticipation).GetEnumDescriptions();

            rGridComboBoxMajor.Columns.Add("نام رشته", "نام رشته", "Name");
            rGridComboBoxMajor.DataSource = majors;

            ControlMappings.Add(new ControlMapping
            {
                Control = rGridComboBoxMajor,
                ControlProperty = "Value",
                DataObject = tuitionFee,
                ObjectProperty = "Major"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rComboBox1,
                ControlProperty = "SelectedIndex",
                DataObject = tuitionFee,
                ObjectProperty = "RegisterParticipation"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Value",
                DataObject = tuitionFee,
                ObjectProperty = "Fee"
            });
        }
    }
}
