using System;
using Fakher.Core.DomainModel;
using Fakher.UI.Fundamental.Protocol;
using rComponents;

namespace Fakher.UI.Educational
{
    public partial class frmSectionTrainingItemDetail : rRadDetailForm
    {
        public frmSectionTrainingItemDetail(SectionTrainingItem item)
        {
            InitializeComponent();
            rGridComboBox1.Columns.Add("نام درس", "نام درس", "Name");

            rGridView1.Mappings.Add(new ColumnMapping {Caption = "رشته", ObjectProperty = "Major.Name"});
            rGridView1.Mappings.Add(new ColumnMapping {Caption = "شهریه", ObjectProperty = "Fee", Type = ColumnType.Money});

            if(item.Plan.Major != null)
                rGridComboBox1.DataSource = item.Plan.Major.GetLessons(item.Plan.Period, HoldingType.Lesson);
//                rGridComboBox1.DataSource = item.Plan.Major.Lessons;

            rGridView1.DataBind(item.TuitionFees);

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rGridComboBox1,
                                        ControlProperty = "Value",
                                        DataObject = item,
                                        ObjectProperty = "Lesson"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox1,
                                        ControlProperty = "Value",
                                        DataObject = item,
                                        ObjectProperty = "StartSession"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox2,
                                        ControlProperty = "Value",
                                        DataObject = item,
                                        ObjectProperty = "EndSession"
                                    });
        }

        protected override void AfterBindToObject()
        {
            SectionTrainingItem item = GetProcessingObject<SectionTrainingItem>();
            item.TuitionFees.SyncWith(rGridView1.DataSource);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Lesson lesson = rGridComboBox1.GetValue<Lesson>();
            LessonHolding lessonHolding = lesson.GetLessonHolding(Program.CurrentPeriod);
            if(lessonHolding == null)
            {
                rMessageBox.ShowError("برای این درس در این ترم هیچ ارائه ای تعریف نشده است.");
                return;
            }
            if(lessonHolding.AllowedMajors.Count == 0)
            {
                rMessageBox.ShowError("برای ارائه این درس هیچ رشته مجازی تعریف نشده است.");
                return;
            }

            TuitionFee tuitionFee = new TuitionFee();
            frmTuitionFeeDetail frm = new frmTuitionFeeDetail(tuitionFee, lessonHolding.AllowedMajors);
            if(!frm.ProcessObject())
                return;
            foreach (TuitionFee fee in rGridView1.DataSource)
                if (fee.Major.Id == tuitionFee.Major.Id)
                {
                    rMessageBox.ShowError("برای این رشته قبلا شهریه ثبت شده است.");
                    return;
                }
            rGridView1.Insert(tuitionFee);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Lesson lesson = rGridComboBox1.GetValue<Lesson>();
            LessonHolding lessonHolding = lesson.GetLessonHolding(Program.CurrentPeriod);
            if (lessonHolding == null)
            {
                rMessageBox.ShowError("برای این درس در این ترم هیچ ارائه ای تعریف نشده است.");
                return;
            }
            TuitionFee tuitionFee = rGridView1.GetSelectedObject<TuitionFee>();
            frmTuitionFeeDetail frm = new frmTuitionFeeDetail(tuitionFee, lessonHolding.AllowedMajors);
            if (!frm.ProcessObject())
                return;

            foreach (TuitionFee fee in rGridView1.DataSource)
                if (fee.Major.Id == tuitionFee.Major.Id && tuitionFee.Id != fee.Id)
                {
                    rMessageBox.ShowError("برای این رشته قبلا شهریه ثبت شده است.");
                    return;
                }
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            TuitionFee tuitionFee = rGridView1.GetSelectedObject<TuitionFee>();
            rGridView1.RemoveSelectedRow();
        }
    }
}
