using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rComponents;

namespace rComponents
{
    public partial class frmCriteriaDetail : rRadDetailForm
    {
        private Dictionary<string, string> mData;
        public frmCriteriaDetail(Criteria criteria, Dictionary<string, string> data)
        {
            InitializeComponent();
            SetProcessingObject(criteria);
            mData = data;
            rComboBox1.DataSource = data.Keys;

//            rComboBox1.SelectedValue = criteria.Key;
//            rComboBox2.SelectedIndex = (int) criteria.Operator;
//            rTextBox1.Text = criteria.Value;
        }

        protected override void AfterBindToObject()
        {
            Criteria criteria = GetProcessingObject<Criteria>();
            criteria.FieldName = rComboBox1.SelectedValue as string;
            criteria.Field = mData[rComboBox1.SelectedValue as string];
            criteria.Value = rTextBox1.Text;
        }
    }
}
