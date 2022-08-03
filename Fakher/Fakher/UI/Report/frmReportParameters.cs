using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Report;
using rComponents;
using Telerik.WinControls.UI;

namespace Fakher.UI.Report
{
    public partial class frmReportParameters : rRadDetailForm, IReportParameterForm
    {
        private IConfigurableReport mReport1;
        private IConfigurableReport mReport2;

        #region IReportParameterForm Properties

        public bool ShowBothLanguages { get; set; }
        public bool OptionalDepartment { get; set; }
        public bool OptionalMajor { get; set; }
        public bool OptionalLesson { get; set; }
        public bool OptionalSection { get; set; }
        public bool OptionalExamSection { get; set; }
        public bool ShowDate
        {
            get { return rGroupBox1.Enabled; }
            set { rGroupBox1.Enabled = value; }
        }
        public bool ShowStructure { get; set; }
        public bool ShowExams { get; set; }
        public bool ShowTeacherStructure { get; set; }
        public bool ShowPayrolls { get; set; }
        public bool ShowCustomStructure { get; set; }
        public bool IsRightToLeft { get; set; }
        public Dictionary<string, string> CustomGridColumns1
        {
            get
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                foreach (GridViewDataColumn column in rGridCmbCustom1.Columns)
                {
                    result.Add(column.Name, column.FieldName);
                }

                return result;
            }
            set
            {
                rGridCmbCustom1.Columns.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    rGridCmbCustom1.Columns.Add(pair.Key, pair.Key, pair.Value);
                }
            }
        }
        public Dictionary<string, string> CustomGridColumns2
        {
            get
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                foreach (GridViewDataColumn column in rGridCmbCustom2.Columns)
                {
                    result.Add(column.Name, column.FieldName);
                }

                return result;
            }
            set
            {
                rGridCmbCustom2.Columns.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    rGridCmbCustom2.Columns.Add(pair.Key, pair.Key, pair.Value);
                }
            }
        }

        public Dictionary<string, string> CustomGridViewColumns
        {
            get
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                foreach (ColumnMapping mapping in rGridView1.Mappings)
                {
                    result.Add(mapping.Caption, mapping.ObjectProperty);
                }
                return result;
            }
            set
            {
                rGridView1.Mappings.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    rGridView1.Mappings.Add(new ColumnMapping() {Caption = pair.Key, ObjectProperty = pair.Value});
                }
            }
        }

        public IEnumerable CustomGridDataSource1
        {
            get { return rGridCmbCustom1.DataSource; }
            set { rGridCmbCustom1.DataSource = value; }
        }
        public IEnumerable CustomGridDataSource2
        {
            get { return rGridCmbCustom2.DataSource; }
            set { rGridCmbCustom2.DataSource = value; }
        }

        public IEnumerable CustomGridViewDataSource
        {
            get { return rGridView1.DataSource; }
            set { rGridView1.DataBind(value); }
        }

        public object[] CustomGridViewSelectedItems
        {
            get
            {
                return rGridView1.GetCheckedObjects<object>().ToArray();
            }
        }

        public PersianDate StartDate
        {
            get { return rDatePicker1.Date; }
        }

        public PersianDate EndDate
        {
            get { return rDatePicker2.Date; }
        }

        public EducationalPeriod Period
        {
            get { return Program.CurrentPeriod; }
        }

        public Major Major
        {
            get { return majorSelector1.Major; }
        }

        public Major ExamMajor
        {
            get { return rGridComboBoxExamMajor.GetValue<Major>(); }
        }

        public Core.DomainModel.Exam Exam
        {
            get { return rGridComboBoxExam.GetValue<Core.DomainModel.Exam>(); }
        }

        public ExamSection ExamSection
        {
            get { return rGridComboBoxExamSections.GetValue<ExamSection>(); }
        }

        public Teacher Teacher
        {
            get { return rGridCmbPayrollTeacher.GetValue<Teacher>(); }
        }

        public Payroll Payroll
        {
            get { return rGridCmbPayroll.GetValue<Payroll>(); }
        }

        public bool ShowMajor
        {
            get { return majorSelector1.Enabled; }
            set { majorSelector1.Enabled = value; }
        }

        public Lesson Lesson
        {
            get { return lessonSelector1.Lesson; }
        }

        public bool ShowLesson
        {
            get { return lessonSelector1.Enabled; }
            set { lessonSelector1.Enabled = value; }
        }

        public SectionItem SectionItem
        {
            get
            {
                return sectionItemSelector1.SectionItem;
            }
        }

        public bool ShowSection
        {
            get { return sectionItemSelector1.Enabled; }
            set { sectionItemSelector1.Enabled = value; }
        }

        public object Param1DataSource
        {
            get { return rComboBoxParam1.DataSource; }
            set { rComboBoxParam1.DataSource = value; }
        }

        public string Param1Text
        {
            get { return lblParam1.Text; }
            set { lblParam1.Text = value; }
        }

        public int Param1SelectedIndex
        {
            get { return rComboBoxParam1.SelectedIndex; }
        }

        public string Param1SelectedText
        {
            get { return rComboBoxParam1.SelectedItem.Text; }
        }

        public object Param1SelectedValue
        {
            get { return rComboBoxParam1.SelectedValue; }
        }

        public bool ShowParam1
        {
            get { return rComboBoxParam1.Visible; }
            set { rComboBoxParam1.Visible = lblParam1.Visible = value; }
        }

        public bool ShowParam2
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public object Param2DataSource
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Param2Text
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ReportLanguages ReportLanguage
        {
            get { return (ReportLanguages)rComboBoxLanguage.SelectedIndex; }
        }

        public bool ShowCustomGrid1
        {
            get { return rGridCmbCustom1.Visible; }
            set { rGridCmbCustom1.Visible = rLblCustomText1.Visible = value; }
        }

        public bool ShowCustomGrid2
        {
            get { return rGridCmbCustom2.Visible; }
            set { rGridCmbCustom2.Visible = rLblCustomText2.Visible = value; }
        }

        public string CustomText1
        {
            get { return rLblCustomText1.Text; }
            set { rLblCustomText1.Text = value; }
        }

        public string CustomText2
        {
            get { return rLblCustomText2.Text; }
            set { rLblCustomText2.Text = value; }
        }

        public object CustomGridValue1
        {
            get { return rGridCmbCustom1.GetValue<object>(); }
        }

        public object CustomGridValue2
        {
            get { return rGridCmbCustom2.GetValue<object>(); }
        }

        public bool ShowCustomGridView
        {
            get { return rGridView1.Visible; }
            set { rGridView1.Visible = value; }
        }

        public bool CustomGridViewCheckBoxes
        {
            get { return rGridView1.CheckBoxes; }
            set { rGridView1.CheckBoxes = value; }
        }

        public event EventHandler SelectedMajorChanged;
        public event EventHandler SelectedLessonChanged;
        public event EventHandler SelectedSectionItemChanged;
        public event EventHandler Param1SelectedChanged;

        public event EventHandler CustomGrid1SelectedIndexChanged;
        public event EventHandler CustomGrid2SelectedIndexChanged;

        public void Configure()
        {
            if (rComboBoxLanguage.SelectedIndex == 0)
            {
                if (mReport1 != null)
                {
                    mReport1.Configure(this);
                    rChkSubSet.Enabled = mReport1.CustomDataset;
                }
            }
            else
            {
                if (mReport2 != null)
                {
                    mReport2.Configure(this);
                    rChkSubSet.Enabled = mReport2.CustomDataset;
                }
            }

            if (ShowBothLanguages)
                rComboBoxLanguage.DataSource = typeof(ReportLanguages).GetEnumDescriptions();
            else
                rComboBoxLanguage.DataSource = new string[] { "فارسی" };

            if (ShowStructure)
            {
                radPageView1.Enabled = true;
                for (int i = radPageView1.Pages.Count - 1; i >= 0; i--)
                {
                    RadPageViewPage page = radPageView1.Pages[i];
                    if (page != radPageViewPage1)
                        radPageView1.Pages.Remove(page);
                }
            }

            if (ShowExams)
            {
                radPageView1.Enabled = true;
                for (int i = radPageView1.Pages.Count - 1; i >= 0; i--)
                {
                    RadPageViewPage page = radPageView1.Pages[i];
                    if (page != radPageViewPage2)
                        radPageView1.Pages.Remove(page);
                }

                rGridComboBoxExamMajor.DataSource = Program.CurrentDepartment.Majors;
            }

            if (ShowTeacherStructure)
            {
                radPageView1.Enabled = true;
                for (int i = radPageView1.Pages.Count - 1; i >= 0; i--)
                {
                    RadPageViewPage page = radPageView1.Pages[i];
                    if (page != radPageViewPage3)
                        radPageView1.Pages.Remove(page);
                }

                rGridCmbPayrollTeacher.DataSource = Teacher.GetActiveTeachers();
                rGridCmbPayroll.Visible = rLblPayrolls.Visible = ShowPayrolls;
            }

            if (ShowCustomStructure)
            {
                radPageView1.Enabled = true;
                for (int i = radPageView1.Pages.Count - 1; i >= 0; i--)
                {
                    RadPageViewPage page = radPageView1.Pages[i];
                    if (page != radPageViewPage4)
                        radPageView1.Pages.Remove(page);
                }

                if (CustomGridColumns1 != null)
                {
                    //                    rGridCmbCustom1.Columns.Clear();
                    //                    foreach (KeyValuePair<string, string> pair in CustomGridColumns1)
                    //                    {
                    //                        rGridCmbCustom1.Columns.Add(pair.Key, pair.Key, pair.Value);
                    //                    }
                    //                    rGridCmbCustom1.DataSource = CustomGridDataSource1;
                }

                if (CustomGridColumns2 != null)
                {
                    //                    rGridCmbCustom2.Columns.Clear();
                    //                    foreach (KeyValuePair<string, string> pair in CustomGridColumns2)
                    //                    {
                    //                        rGridCmbCustom2.Columns.Add(pair.Key, pair.Key, pair.Value);
                    //                    }
                    //                    rGridCmbCustom2.DataSource = CustomGridDataSource2;
                }
            }

            if (OptionalMajor)
                majorSelector1.ShowNullButton = true;
            if (OptionalLesson)
                lessonSelector1.ShowNullButton = true;
            if (OptionalSection)
                sectionItemSelector1.ShowNullButton = true;
            if (OptionalExamSection)
                rGridComboBoxExamSections.ShowNullButton = true;

            OnSelectedMajorChanged();
            OnSelectedLessonChanged();
            OnSelectedSectionItemChanged();
        }

        #endregion

        public void OnSelectedMajorChanged()
        {
            if (SelectedMajorChanged != null)
                SelectedMajorChanged(this, EventArgs.Empty);
        }

        public void OnSelectedLessonChanged()
        {
            if (SelectedLessonChanged != null)
                SelectedLessonChanged(this, EventArgs.Empty);
        }

        public void OnSelectedSectionItemChanged()
        {
            if (SelectedSectionItemChanged != null)
                SelectedSectionItemChanged(this, EventArgs.Empty);
        }

        public void OnParam1SelectedChanged()
        {
            if (Param1SelectedChanged != null)
                Param1SelectedChanged(this, EventArgs.Empty);
        }

        public void OnCustomGrid1SelectedIndexChanged()
        {
            if (CustomGrid1SelectedIndexChanged != null)
                CustomGrid1SelectedIndexChanged(rGridCmbCustom1, EventArgs.Empty);
        }

        public void OnCustomGrid2SelectedIndexChanged()
        {
            if (CustomGrid2SelectedIndexChanged != null)
                CustomGrid2SelectedIndexChanged(rGridCmbCustom2, EventArgs.Empty);
        }

        public frmReportParameters()
        {
            InitializeComponent();
            radPageView1.SelectedPage = radPageViewPage1;
        }

        public frmReportParameters(string title)
            : this()
        {
            rLblReportName.Text = title;
        }

        public frmReportParameters(IConfigurableReport report)
            : this()
        {
            mReport1 = report;
            Fill();
        }

        public frmReportParameters(IConfigurableReport farsiReport, IConfigurableReport englishReport)
            : this()
        {
            mReport1 = farsiReport;
            mReport2 = englishReport;
            ShowBothLanguages = true;
            Fill();
        }

        public void Fill()
        {
            if (mReport1 != null)
                rLblReportName.Text = mReport1.ReportName;

            if (Program.CurrentPeriod.StartDate > PersianDate.Today)
                rDatePicker1.Date = PersianDate.Today;
            else
                rDatePicker1.Date = Program.CurrentPeriod.StartDate;
            rDatePicker2.Date = PersianDate.Today;

            #region Mappings

            rGridComboBoxExamMajor.Columns.Add("نام", "نام", "Name");
            rGridComboBoxEvalItem.Columns.Add("نام آیتم", "نام آیتم", "Name");
            rGridComboBoxExam.Columns.Add("نام آزمون", "نام آزمون", "Name");
            rGridComboBoxExam.Columns.Add("نــوع", "نــوع", "FarsiTypeText");
            rGridComboBoxExam.Columns.Add("کلاس/گروه", "کلاس/گروه", "FarsiExamSectionsText");
            rGridComboBoxExamSections.Columns.Add("نام کلاس", "نام کلاس", "SectionItem.Section.FarsiName");
            rGridComboBoxExamSections.Columns.Add("مدرس", "مدرس", "SectionItem.Section.Teacher.FarsiFullname");

            rGridCmbPayrollTeacher.Columns.Add("نام", "نام", "FarsiFullname");

            rGridCmbPayroll.Columns.Add("قرارداد", "قرارداد", "MajorText");
            rGridCmbPayroll.Columns.Add("تاریخ شروع", "تاریخ شروع", "StartDate");
            rGridCmbPayroll.Columns.Add("تاریخ پایان", "تاریخ پایان", "EndDate");
            rGridCmbPayroll.Columns.Add("PayableAmount", "PayableAmount", "PayableAmount");

            #endregion

            ShowMajor = ShowLesson = ShowSection = false;
            IsRightToLeft = true;
        }

        private void frmReportParameters_Load(object sender, EventArgs e)
        {
            Configure();

            //            if(mReport1 != null)
            //                mReport1.Configure(this);

            //            if(ShowBothLanguages)
            //                rComboBoxLanguage.DataSource = typeof (ReportLanguages).GetEnumDescriptions();
            //            else
            //                rComboBoxLanguage.DataSource = new string[] { "فارسی"};
            //
            //            if(ShowStructure)
            //            {
            //                radPageView1.Enabled = true;
            //            }
            //            else
            //            {
            //                radPageView1.Pages.Remove(radPageViewPage1);
            //            }
            //
            //            if(ShowExams)
            //            {
            //                radPageView1.Enabled = true;
            //                rGridComboBoxExamMajor.DataSource = Program.CurrentDepartment.Majors;
            //            }
            //            else
            //            {
            //                radPageView1.Pages.Remove(radPageViewPage2);
            //            }
            //
            //            if(OptionalMajor)
            //                majorSelector1.ShowNullButton = true;
            //            if(OptionalLesson)
            //                lessonSelector1.ShowNullButton = true;
            //            if(OptionalSection)
            //                sectionItemSelector1.ShowNullButton = true;
            //            if (OptionalExamSection)
            //                rGridComboBoxExamSections.ShowNullButton = true;
            //
            //            OnSelectedMajorChanged();
            //            OnSelectedLessonChanged();
            //            OnSelectedSectionItemChanged();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = rGridComboBoxExam.GetValue<Core.DomainModel.Exam>();

            #region Validation

            if (ShowDate)
            {
                rDatePicker1.ValidationType = ValidationType.NotEmpty;
                rDatePicker2.ValidationType = ValidationType.NotEmpty;
                try
                {
                    rDatePicker1.Validate();
                    rDatePicker2.Validate();
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
            }

            if (ShowStructure)
            {
                if (ShowMajor && !OptionalMajor && Major == null)
                {
                    rMessageBox.ShowError("رشته را انتخاب کنید.");
                    CancelClosing();
                    return;
                }
                if (ShowLesson && !OptionalLesson && Lesson == null)
                {
                    rMessageBox.ShowError("درس/سطح را انتخاب کنید.");
                    CancelClosing();
                    return;
                }
                if (ShowSection && !OptionalSection && SectionItem == null)
                {
                    rMessageBox.ShowError("کلاس/گروه را انتخاب کنید.");
                    CancelClosing();
                    return;
                }
            }

            if (ShowExams)
            {
                if (Exam == null)
                {
                    rMessageBox.ShowError("آزمون را انتخاب کنید.");
                    CancelClosing();
                    return;
                }
            }

            if (ShowExams && !OptionalExamSection)
            {
                if (exam.ExamSections.Count > 0 && ExamSection == null)
                {
                    rMessageBox.ShowError("گروه شرکت کننده در آزمون را انتخاب کنید.");
                    CancelClosing();
                    return;
                }
            }

            #endregion

            if (mReport1 != null)
            {
                frmReportViewer viewer;
                try
                {

                    if (rComboBoxLanguage.SelectedIndex == 0)
                    {
                        Program.StartWaiting();
                        mReport1.PrepareDataset(this);
                        Program.EndWaiting();

                        if (rChkSubSet.Checked)
                        {
                            frmSelect frm = new frmSelect(mReport1.DataSet, GetColumnMappings(mReport1)) { MultiSelect = true };
                            if (frm.ShowDialog(this) == DialogResult.OK)
                                mReport1.DataSet = frm.GetSelectedObjects<object>();
                            else
                            {
                                CancelClosing();
                                return;
                            }
                        }

                        Program.StartWaiting();
                        mReport1.Apply(this); 
                        Program.EndWaiting();

                        viewer = new frmReportViewer(mReport1 as Telerik.Reporting.Report);
                    }
                    else
                    {
                        Program.StartWaiting();
                        mReport2.PrepareDataset(this);
                        Program.EndWaiting();

                        if (rChkSubSet.Checked)
                        {
                            frmSelect frm = new frmSelect(mReport2.DataSet, GetColumnMappings(mReport2)) { MultiSelect = true };
                            if (frm.ShowDialog(this) == DialogResult.OK)
                                mReport2.DataSet = frm.GetSelectedObjects<object>();
                            else
                            {
                                CancelClosing();
                                return;
                            }
                        }

                        Program.StartWaiting();
                        mReport2.Apply(this);
                        Program.EndWaiting();

                        viewer = new frmReportViewer(mReport2 as Telerik.Reporting.Report);
                    }
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }
                finally
                {
                    Program.EndWaiting();
                }

                if (IsRightToLeft)
                    viewer.RightToLeft = RightToLeft.Yes;
                else
                    viewer.RightToLeft = RightToLeft.No;

                viewer.ShowDialog(this);
            }

            if (mReport1 == null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private ColumnMapping[] GetColumnMappings(IConfigurableReport report)
        {
            List<ColumnMapping> mappings = new List<ColumnMapping>();
            foreach (List<object> objects in report.ColumnMappings)
            {
                ColumnMapping columnMapping = new ColumnMapping { Caption = objects[0] + "", ObjectProperty = objects[1] + "" };
                if (objects.Count > 2)
                    if (objects[2] == typeof(float))
                        columnMapping.Type = ColumnType.Decimal;
                mappings.Add(columnMapping);
            }
            return mappings.ToArray();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Program.EndWaiting();
            Close();
        }

        private void rComboBoxLanguage_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (rComboBoxLanguage.SelectedIndex == 0)
            {
                if (mReport1 != null)
                {
                    mReport1.ParamForm = this;
                    mReport1.Configure(this);
                    rChkSubSet.Enabled = mReport1.CustomDataset;
                }
            }
            else
            {
                if (mReport2 != null)
                {
                    mReport2.ParamForm = this;
                    mReport2.Configure(this);
                    rChkSubSet.Enabled = mReport2.CustomDataset;
                }
            }
        }

        private void rGridComboBoxExamMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Major major = rGridComboBoxExamMajor.GetValue<Major>();
            rGridComboBoxEvalItem.Clear();
            if (major == null)
                return;
            OnSelectedMajorChanged();
            rGridComboBoxEvalItem.DataSource = major.GetExamEvaluationItems(Program.CurrentPeriod);
        }

        private void rGridComboBoxEvalItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Major major = rGridComboBoxExamMajor.GetValue<Major>();
            EvaluationItem item = rGridComboBoxEvalItem.GetValue<EvaluationItem>();
            rGridComboBoxExam.Clear();
            if (item == null)
                return;
            rGridComboBoxExam.DataSource = major.GetExams(Program.CurrentPeriod, item);
        }

        private void rGridComboBoxExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = rGridComboBoxExam.GetValue<Core.DomainModel.Exam>();
            rGridComboBoxExamSections.Clear();
            if (exam == null)
                return;
            rGridComboBoxExamSections.DataSource = exam.ExamSections;
        }

        private void majorSelector1_SelectedChanged(object sender, EventArgs e)
        {
            OnSelectedMajorChanged();
        }

        private void lessonSelector1_SelectedChanged(object sender, EventArgs e)
        {
            OnSelectedLessonChanged();
        }

        private void sectionItemSelector1_SelectedChanged(object sender, EventArgs e)
        {
            OnSelectedSectionItemChanged();
        }

        private void rComboBoxParam1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            OnParam1SelectedChanged();
        }

        private void rGridCmbPayrollTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            Teacher teacher = rGridCmbPayrollTeacher.GetValue<Teacher>();
            if (teacher == null)
                return;
            rGridCmbPayroll.DataSource = teacher.Payrolls;
            //            rGridCmbPayrollContract.DataSource = teacher.Contracts;
        }

        private void rGridCmbPayrollContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            //            TeachingContract contract = rGridCmbPayrollContract.GetValue<TeachingContract>();
            //            rGridCmbPayroll.Clear();
            //            if (contract == null)
            //                return;
            //            rGridCmbPayroll.DataSource = contract.Payrolls;
        }

        private void rGridCmbCustom1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnCustomGrid1SelectedIndexChanged();
        }

        private void rGridCmbCustom2_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnCustomGrid2SelectedIndexChanged();
        }
    }
}
