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
    public partial class ExamSelector : UserControl
    {
        public event EventHandler SelectedChanged;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Exam Exam
        {
            get { return rGridComboBoxExam.GetValue<Exam>(); }
            set { rGridComboBoxExam.Value = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExamSection ExamSection
        {
            get { return rGridComboBoxExamSections.GetValue<ExamSection>(); }
            set { rGridComboBoxExamSections.Value = value; }
        }

        public bool ShowNullButton
        {
            get { return rGridComboBoxExamSections.ShowNullButton; }
            set { rGridComboBoxExamSections.ShowNullButton = value; }
        }

        public bool ShowExamSections
        {
            get { return rLabel4.Visible; }
            set { rLabel4.Visible = rGridComboBoxExamSections.Visible = value; }
        }

        public bool FilterExamType { get; set; }
        public ExamType ExamType { get; set; }

        public ExamSelector()
        {
            InitializeComponent();

            if (DesignMode)
                return;

            rGridComboBoxEvalItem.Columns.Add("نام آیتم", "نام آیتم", "Name");

            rGridComboBoxExam.Columns.Add("نام آزمون", "نام آزمون", "Name");
            rGridComboBoxExam.Columns.Add("نوع آزمون", "نوع آزمون", "FarsiTypeText");
            rGridComboBoxExam.Columns.Add("کلاس/گروه", "کلاس/گروه", "FarsiExamSectionsText");
//            rGridComboBoxExam.Columns.Add("آیتم نتیجه", "آیتم نتیجه", "EvaluationItem.Name");
//            rGridComboBoxExam.Columns.Add("نوع آزمون", "نوع آزمون", "FarsiTypeText");

            rGridComboBoxExamSections.Columns.Add("نام کلاس", "نام کلاس", "SectionItem.Section.FarsiName");
            rGridComboBoxExamSections.Columns.Add("مدرس", "مدرس", "SectionItem.Section.Teacher.FarsiFullname");

            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            ShowExamSections = true;
        }

        protected void OnSelectedChanged()
        {
            if (SelectedChanged != null)
                SelectedChanged(this, EventArgs.Empty);
        }

        private void ExamSelector_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {

            }
        }

        private void rGridComboBoxEvalItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            EvaluationItem item = rGridComboBoxEvalItem.GetValue<EvaluationItem>();
            rGridComboBoxExam.Clear();
            if (item == null)
                return;
            if (!FilterExamType)
                rGridComboBoxExam.DataSource = majorSelector1.Major.GetExams(Program.CurrentPeriod, item);
            else
                rGridComboBoxExam.DataSource = majorSelector1.Major.GetExams(Program.CurrentPeriod, item, ExamType);
        }

        private void rGridComboBoxExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            Exam exam = rGridComboBoxExam.GetValue<Exam>();
            rGridComboBoxExamSections.Clear();
            if (exam == null)
                return;
            OnSelectedChanged();
            rGridComboBoxExamSections.DataSource = exam.ExamSections;
        }

        private void rGridComboBoxExamSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedChanged();
        }

        private void majorSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if(DesignMode)
                return;
            rGridComboBoxEvalItem.Clear();
            if(majorSelector1.Major == null)
                return;
            if(!FilterExamType)
                rGridComboBoxEvalItem.DataSource = majorSelector1.Major.GetExamEvaluationItems(Program.CurrentPeriod);
            else
                rGridComboBoxEvalItem.DataSource = majorSelector1.Major.GetExamEvaluationItems(Program.CurrentPeriod, ExamType);
        }
    }
}
