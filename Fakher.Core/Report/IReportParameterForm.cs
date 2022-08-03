using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.Core.Report
{
    public interface IReportParameterForm
    {
        bool ShowBothLanguages { get; set; }
        bool ShowDate { get; set; }
        bool ShowStructure { get; set; }
        bool ShowExams { get; set; }
        bool ShowTeacherStructure { get; set; }
        bool ShowPayrolls { get; set; }
        PersianDate StartDate { get; }
        PersianDate EndDate { get; }
        EducationalPeriod Period { get; }
        Major Major { get; }
        Major ExamMajor { get; }
        Exam Exam { get; }
        ExamSection ExamSection { get; }
        Lesson Lesson { get; }
        SectionItem SectionItem { get; }
        Teacher Teacher { get; }
        Payroll Payroll { get; }
        bool OptionalExamSection { get; set; }
        bool ShowMajor { get; set; }
        bool OptionalMajor { get; set; }
        bool OptionalDepartment { get; set; }
        bool ShowLesson { get; set; }
        bool OptionalLesson { get; set; }
        bool ShowSection { get; set; }
        bool OptionalSection { get; set; }
        object Param1DataSource { get; set; }
        string Param1Text { get; set; }
        int Param1SelectedIndex { get; }
        string Param1SelectedText { get; }
        object Param1SelectedValue { get; }
        bool ShowParam1 { get; set; }
        
        bool ShowParam2 { get; set; }
        object Param2DataSource { get; set; }
        string Param2Text { get; set; }

        // Custom Structure
        bool ShowCustomStructure { get; set; }
        
        bool ShowCustomGrid1 { get; set; }
        string CustomText1 { get; set; }
        Dictionary<string, string> CustomGridColumns1 { get; set; }
        IEnumerable CustomGridDataSource1 { get; set; }
        object CustomGridValue1 { get; }
        event EventHandler CustomGrid1SelectedIndexChanged;

        bool ShowCustomGrid2 { get; set; }
        string CustomText2 { get; set; }
        Dictionary<string, string> CustomGridColumns2 { get; set; }
        IEnumerable CustomGridDataSource2 { get; set; }
        object CustomGridValue2 { get; }
        event EventHandler CustomGrid2SelectedIndexChanged;
        
        bool ShowCustomGridView { get; set; }
        Dictionary<string, string> CustomGridViewColumns { get; set; }
        IEnumerable CustomGridViewDataSource { get; set; }
        bool CustomGridViewCheckBoxes { get; set; }
        object[] CustomGridViewSelectedItems { get; }
        //


        ReportLanguages ReportLanguage { get; }
        bool IsRightToLeft { get; set; }
        event EventHandler SelectedMajorChanged;
        event EventHandler SelectedLessonChanged;
        event EventHandler SelectedSectionItemChanged;
        event EventHandler Param1SelectedChanged;
        void Configure();
    }

    public enum ReportLanguages
    {
        [EnumDescription("فـارســی")]
        Farsi,
        [EnumDescription("انـگلیســی")]
        English
    }
}