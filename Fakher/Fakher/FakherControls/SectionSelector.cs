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
    public partial class SectionSelector : UserControl
    {
//        public LessonSelector LessonSelector { get; set; }
        public MajorSelector MajorSelector { get; set; }
        public event EventHandler SelectedChanged;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EducationalPeriod Period { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section
        {
            get { return rGridComboBox1.GetValue<Section>(); }
            set { rGridComboBox1.Value = value; }
        }
        public bool ShowNullButton
        {
            get { return rGridComboBox1.ShowNullButton; }
            set { rGridComboBox1.ShowNullButton = value; }
        }

        public SectionSelector()
        {
            InitializeComponent();

            rGridComboBox1.Columns.Add("نام کلاس", "نام کلاس", "FarsiName");
            rGridComboBox1.Columns.Add("درس/سطح", "درس/سطح", "MasterItemText");
            rGridComboBox1.Columns.Add("زمان تشکیل", "زمان تشکیل", "FarsiFormationText");

            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        }

        private void OnMajorChanged()
        {
            rGridComboBox1.Clear();
            EducationalPeriod period = Period == null ? Program.CurrentPeriod : Period;

            if (MajorSelector != null && MajorSelector.Major != null)
                rGridComboBox1.DataSource = Section.GetSections(period, MajorSelector.Major);

            OnSelectedChanged();
        }

        protected void OnSelectedChanged()
        {
            if (SelectedChanged != null)
                SelectedChanged(this, EventArgs.Empty);
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedChanged();
        }

        public void Databind(IEnumerable data)
        {
            rGridComboBox1.DataSource = data;
        }

        private void SectionSelector_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (MajorSelector != null)
                {
                    MajorSelector.SelectedChanged += new EventHandler(MajorSelector_SelectedChanged);
                    OnMajorChanged();
                }
            }
        }

        private void MajorSelector_SelectedChanged(object sender, EventArgs e)
        {
            OnMajorChanged();
        }

    }
}
