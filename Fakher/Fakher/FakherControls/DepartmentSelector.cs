using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;

namespace Fakher.Controls
{
    public partial class DepartmentSelector : UserControl
    {
        public event EventHandler SelectedChanged;
        
        public DepartmentSelector()
        {
            InitializeComponent();

//            rGridComboBox1.Columns.Add("کد", "کد", "Code");
            rGridComboBox1.Columns.Add("نام", "نام", "Name");

            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Department Department
        {
            get { return rGridComboBox1.GetValue<Department>(); }
            set { rGridComboBox1.Value = value; }
        }

        public bool ShowNullButton
        {
            get { return rGridComboBox1.ShowNullButton; }
            set { rGridComboBox1.ShowNullButton = value; }
        }


        private bool mCustomDataBind;

        private void DepartmentSelector_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (!mCustomDataBind)
                    rGridComboBox1.DataSource = Department.GetDepartments();
            }
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedChanged != null)
                SelectedChanged(this, e);
        }

        public void Databind(IEnumerable data)
        {
            rGridComboBox1.DataSource = data;
            mCustomDataBind = true;
        }
    }
}
