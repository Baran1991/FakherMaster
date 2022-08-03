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
    public partial class LessonSelector : UserControl
    {
        public MajorSelector MajorSelector { get; set; }
        public bool ShowExamHoldingLessons { get; set; }
        public bool ShowAllLessons { get; set; }
        public event EventHandler SelectedChanged;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EducationalPeriod Period { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Lesson Lesson
        {
            get { return rGridComboBox1.GetValue<Lesson>(); }
            set { rGridComboBox1.Value = value; }
        }
        public bool ShowNullButton
        {
            get { return rGridComboBox1.ShowNullButton; }
            set { rGridComboBox1.ShowNullButton = value; }
        }

        public LessonSelector()
        {
            InitializeComponent();

//            rGridComboBox1.Columns.Add("کد", "کد", "Code");
            rGridComboBox1.Columns.Add("نام درس", "نام درس", "Name");

            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        }

        private void LessonSelector_Load(object sender, EventArgs e)
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

        private void OnMajorChanged()
        {
            rGridComboBox1.Clear();
            EducationalPeriod period = Period == null ? Program.CurrentPeriod : Period;

            if (MajorSelector.Major != null)
            {
                IEnumerable<Lesson> lessons;
                if (ShowAllLessons)
                    lessons = MajorSelector.Major.Lessons;
                else
                {
                    lessons = MajorSelector.Major.GetLessons(period, HoldingType.Lesson);
                    if (ShowExamHoldingLessons)
                        lessons = lessons.Union(MajorSelector.Major.GetLessons(period, HoldingType.Exam));
                }
                rGridComboBox1.DataSource = lessons.OrderBy(x=>x.Name);
            }

            OnSelectedChanged();
        }

        protected void OnSelectedChanged()
        {
            if (SelectedChanged != null)
                SelectedChanged(this, EventArgs.Empty);
        }

        private void MajorSelector_SelectedChanged(object sender, EventArgs e)
        {
            OnMajorChanged();
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedChanged();
//            if (SelectedChanged != null)
//                SelectedChanged(this, e);
        }

        public void Databind(IEnumerable data)
        {
            rGridComboBox1.DataSource = data;
        }
    }
}
