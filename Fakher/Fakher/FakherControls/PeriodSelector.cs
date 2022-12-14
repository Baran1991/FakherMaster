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
    public partial class PeriodSelector : UserControl
    {
        public DepartmentSelector DepartmentSelector { get; set; }
        public event EventHandler SelectedChanged;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EducationalPeriod Period
        {
            get { return rGridComboBox1.GetValue<EducationalPeriod>(); }
            set { rGridComboBox1.Value = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public bool ShowNullButton
        {
            get { return rGridComboBox1.ShowNullButton; }
            set { rGridComboBox1.ShowNullButton = value; }
        }

        public PeriodSelector()
        {
            InitializeComponent();

            //            rGridComboBox1.Columns.Add("کد", "کد", "Code");
            rGridComboBox1.Columns.Add("نام ترم", "نام ترم", "Name");

            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private bool mCustomDataBind;

        private void PeriodSelector_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (DepartmentSelector != null)
                {
                    DepartmentSelector.SelectedChanged += new EventHandler(DepartmentSelector_SelectedChanged);                    
                }
                OnDepartmentChanged();
            }
        }

        private void OnDepartmentChanged()
        {
            if (DesignMode)
                return;

            if (mCustomDataBind)
                return;

            rGridComboBox1.Clear();
            if (DepartmentSelector != null && DepartmentSelector.Department != null)
                rGridComboBox1.DataSource = DepartmentSelector.Department.EducationalPeriods.OrderByDescending(x => x.Id);
            
            OnSelectedChanged();
        }

        private void OnSelectedChanged()
        {
            if (DesignMode)
                return;

            if (SelectedChanged != null)
                SelectedChanged(this, EventArgs.Empty);
        }

        void DepartmentSelector_SelectedChanged(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            OnDepartmentChanged();
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            if (SelectedChanged != null)
                SelectedChanged(this, e);
        }

        public void Databind(IEnumerable data)
        {
            if (DesignMode)
                return;

            rGridComboBox1.DataSource = data;
            mCustomDataBind = true;
        }
    }
}
