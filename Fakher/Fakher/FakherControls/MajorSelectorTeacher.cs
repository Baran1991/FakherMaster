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
using DataAccessLayer;

namespace Fakher.Controls
{
    public partial class MajorSelectorTeacher : UserControl
    {
        //private Teacher mCurrentteacher;
        public DepartmentSelector DepartmentSelector { get; set; }
        public event EventHandler SelectedChanged;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EducationalPeriod Period { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Major Major
        {
            get { return rGridComboBox1.GetValue<Major>(); }
            set { rGridComboBox1.Value = value; }
        }
        public bool ShowNullButton
        {
            get { return rGridComboBox1.ShowNullButton; }
            set { rGridComboBox1.ShowNullButton = value; }
        }

        public MajorSelectorTeacher()
        {
            InitializeComponent();

//            rGridComboBox1.Columns.Add("کد", "کد", "Code");
            rGridComboBox1.Columns.Add("نام رشته", "نام رشته", "Name");
            
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private bool mCustomDataBind;

        private void MajorSelector_Load(object sender, EventArgs e)
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
            EducationalPeriod period = Period == null ? Program.CurrentPeriod : Period;

            if (period == null)
                return;

            if (DepartmentSelector != null && DepartmentSelector.Department != null)
                rGridComboBox1.DataSource = DbContext.GetAll<Section>().Where(m => m.Teacher == Program.CurrentTeacher & m.Major.Department == DepartmentSelector.Department).Select(m => m.Major);
            //rGridComboBox1.DataSource = DepartmentSelector.Department.Majors;
            else
                rGridComboBox1.DataSource = DbContext.GetAll<Section>().Where(m => m.Teacher == Program.CurrentTeacher & m.Period == period).Select(m => m.Major);

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
