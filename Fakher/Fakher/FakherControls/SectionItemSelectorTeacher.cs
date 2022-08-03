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
    public partial class SectionItemSelectorTeacher : UserControl
    {
        public LessonSelectorTeacher LessonSelector { get; set; }
        public bool ShowCapacity { get; set; }
        public bool ShowFormation { get; set; }
        public bool ShowTeacher { get; set; }
        public event EventHandler SelectedChanged;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EducationalPeriod Period { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SectionItem SectionItem
        {
            get { return rGridComboBox1.GetValue<SectionItem>(); }
            set { rGridComboBox1.Value = value; }
        }
        public bool ShowNullButton
        {
            get { return rGridComboBox1.ShowNullButton; }
            set { rGridComboBox1.ShowNullButton = value; }
        }

        public SectionItemSelectorTeacher()
        {
            InitializeComponent();

            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void FillColumns()
        {
            rGridComboBox1.Columns.Clear();
            rGridComboBox1.Columns.Add("نام کلاس", "نام کلاس", "Section.FarsiName");
            if (ShowCapacity)
                rGridComboBox1.Columns.Add("ظرفیت باقیمانده", "ظرفیت باقیمانده", "RemainderCount");
            if (ShowFormation)
                rGridComboBox1.Columns.Add("زمان تشکیل", "زمان تشکیل", "Section.FarsiFormationText");
            if (ShowTeacher)
                rGridComboBox1.Columns.Add("مدرس", "مدرس", "Section.Teacher.FarsiFullname");
        }

        private void LessonSelector_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (LessonSelector != null)
                {
                    LessonSelector.SelectedChanged += new EventHandler(LessonSelector_SelectedChanged);
                    FillColumns();
                    OnLessonChanged();
                }
            }
        }

        private void OnLessonChanged()
        {
            rGridComboBox1.Clear();
            EducationalPeriod period = Period == null ? Program.CurrentPeriod : Period;

            if (LessonSelector.Lesson != null && LessonSelector.MajorSelector != null)
                rGridComboBox1.DataSource = SectionItem.GetSectionItems(period, LessonSelector.MajorSelector.Major, LessonSelector.Lesson);
            else if (LessonSelector.Lesson != null)
                rGridComboBox1.DataSource = SectionItem.GetSectionItems(period, LessonSelector.Lesson);

            OnSelectedChanged();
        }

        protected void OnSelectedChanged()
        {
            if (SelectedChanged != null)
                SelectedChanged(this, EventArgs.Empty);
        }

        private void LessonSelector_SelectedChanged(object sender, EventArgs e)
        {
            OnLessonChanged();
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedChanged();
        }

        public void Databind(IEnumerable data)
        {
            rGridComboBox1.DataSource = data;
        }
    }
}
