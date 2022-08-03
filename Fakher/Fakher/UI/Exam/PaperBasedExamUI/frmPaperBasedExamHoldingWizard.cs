using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Holding;
using rComponents;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace Fakher.UI.Exam
{
    public partial class frmPaperBasedExamHoldingWizard : rRadDetailForm
    {
        private bool mCustomChangeTabs;
        private PaperBasedExamHolding mHolding;

        public frmPaperBasedExamHoldingWizard()
        {
            InitializeComponent();

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage5;
            mCustomChangeTabs = false;

            rGridViewExams.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            rGridViewExams.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Lesson.Major.Name" });

            rGridViewFormations.Mappings.Add(new ColumnMapping { Caption = "روز", ObjectProperty = "DayText" });
            rGridViewFormations.Mappings.Add(new ColumnMapping { Caption = "از ساعت", ObjectProperty = "StartTime" });
            rGridViewFormations.Mappings.Add(new ColumnMapping { Caption = "تا ساعت", ObjectProperty = "FinishTime" });
            rGridViewFormations.Mappings.Add(new ColumnMapping { Caption = "مکان", ObjectProperty = "Place.Name" });
            rGridViewFormations.Mappings.Add(new ColumnMapping { Caption = "ظرفیت", ObjectProperty = "Capacity", AggregateSummary = AggregateSummary.Sum});
        }

        private int StepIndex
        {
            get
            {
                return radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            }
        }

        private void GotoNextStep()
        {
            mCustomChangeTabs = true;
            int index = radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            if (index + 1 < radPageView1.Pages.Count)
                radPageView1.SelectedPage = radPageView1.Pages[index + 1];
            mCustomChangeTabs = false;
        }

        private void GotoPrevStep()
        {
            mCustomChangeTabs = true;
            int index = radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            if (index - 1 >= 0)
                radPageView1.SelectedPage = radPageView1.Pages[index - 1];
            mCustomChangeTabs = false;
        }

        private void radPageView1_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {
            e.Cancel = !mCustomChangeTabs;
        }

        private void rGridViewExams_Add(object sender, EventArgs e)
        {
            if(examSelector1.Exam == null)
                return;
            foreach (Core.DomainModel.Exam exam in rGridViewExams.DataSource)
            {
                if(exam.Id == examSelector1.Exam.Id)
                {
                    rMessageBox.ShowError("این آزمون قبلا اضافه شده است.");
                    return;
                }
            }
            rGridViewExams.Insert(examSelector1.Exam);
        }

        private void rGridViewExams_Delete(object sender, EventArgs e)
        {
            rGridViewExams.RemoveSelectedRow();
        }

        private void rGridViewFormations_Add(object sender, EventArgs e)
        {
            if(rDatePicker1.Date == null)
            {
                rMessageBox.ShowError("ابتدا تاریخ برگزاری آزمون را مشخص کنید.");
                return;
            }
            Formation formation = new Formation();
            formation.Day = rDatePicker1.Date.GetDayOfWeek();
            formation.CapacityPolicy = FormationCapacityPolicy.Specific;
            frmFormationDetail frm = new frmFormationDetail(formation);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
//            if(formation.CapacityPolicy != FormationCapacityPolicy.Specific)
//            {
//                rMessageBox.ShowError("ظرفیت اتاق حتما باید مشخص باشد.");
//                return;
//            }
            rGridViewFormations.Insert(formation);
        }

        private void rGridViewFormations_Edit(object sender, EventArgs e)
        {
            Formation formation = rGridViewFormations.GetSelectedObject<Formation>();
            frmFormationDetail frm = new frmFormationDetail(formation);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

//            if (formation.CapacityPolicy != FormationCapacityPolicy.Specific)
//            {
//                rMessageBox.ShowError("ظرفیت اتاق حتما باید مشخص باشد.");
//                return;
//            }
            rGridViewFormations.UpdateGridView();
        }

        private void rGridViewFormations_Delete(object sender, EventArgs e)
        {
            rGridViewFormations.RemoveSelectedRow();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            GotoPrevStep();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int startNumber = rTextBox1.GetValue<int>();
            int endNumber = rTextBox2.GetValue<int>();
            IList exams = rGridViewExams.DataSource;
            IList formations = rGridViewFormations.DataSource;

            if (StepIndex == 0) //Start
            {

            }

            if (StepIndex == 1) //Exam
            {
                if(rGridViewExams.DataSource.Count == 0)
                {
                    rMessageBox.ShowError("حداقل یک آزمون را به لیست اضافه کنید.");
                    return;
                }

                foreach (Core.DomainModel.Exam exam in exams)
                {
                    if(exam.HasHolding)
                    {
                        if (rMessageBox.ShowQuestion("برای آزمون {0} قبلا برگزاری تعریف شده است. از حذف برگزاری قبل و انتساب برگزاری جدید مطمئن هستید؟", exam.Name) != DialogResult.Yes)
                            return;
                    }
                }
            }

            if (StepIndex == 2) //Shifts
            {
                if(rDatePicker1.Date == null)
                {
                    rMessageBox.ShowError("تاریخ برگزاری آزمونها را وارد کنید.");
                    return;
                }
                if (formations.Count == 0)
                {
                    rMessageBox.ShowError("حداقل یک شیفت برای آزمون به لیست اضافه کنید.");
                    return;
                }

                int formationCapacity = (from Formation formation in formations select formation.Capacity).Sum();
                int participateCount = (from Core.DomainModel.Exam exam in exams select exam.GetParticipates().Count()).Sum();

                if(participateCount > formationCapacity)
                {
                    if(rMessageBox.ShowQuestion("تعداد شرکت کنندگان آزمون بیش از ظرفیت کلاس های تعریف شده است. تعداد شرکت کنندگان {0} نفر و ظرفیت کلاسهای تعریف شده {1} است. آیا مطمئن هستید؟", participateCount, formationCapacity) != DialogResult.Yes)
                        return;
                }

                int maxSize = Math.Max(participateCount, formationCapacity);
                rTextBox1.Text = 101 + "";
                rTextBox2.Text = (101 + maxSize + 5) + "";
            }

            if (StepIndex == 3) //Policies
            {

                if (startNumber <= 0)
                {
                    rMessageBox.ShowError("اولین شماره صندلی باید بزرگتر یا مساوی یک باشد.");
                    return;
                }
                if (endNumber <= 0)
                {
                    rMessageBox.ShowError("آخرین شماره صندلی باید بزرگتر یا مساوی یک باشد.");
                    return;
                }

                btnNext.Text = "تـــایــیــد";
            }

            if (StepIndex == 4) // End
            {
                mHolding = new PaperBasedExamHolding();

                foreach (Core.DomainModel.Exam exam in exams)
                    mHolding.AddExam(exam);
                foreach (Formation formation in formations)
                    mHolding.AddFormation(formation);

                mHolding.StartDate = rDatePicker1.Date;
                mHolding.FirstSeatNumber = startNumber;
                mHolding.LastSeatNumber = endNumber;

                if (rRadioButton1.ToggleState == ToggleState.On)
                    mHolding.SeatNumberPolicy = SeatNumberPolicy.Sequential;
                if (rRadioButton3.ToggleState == ToggleState.On)
                    mHolding.SeatNumberPolicy = SeatNumberPolicy.Random;

                if (rRadioButton4.ToggleState == ToggleState.On)
                    mHolding.SeatAssignPolicy = SeatAssignPolicy.OnCardDelivery;
                if (rRadioButton5.ToggleState == ToggleState.On)
                    mHolding.SeatAssignPolicy = SeatAssignPolicy.Now;

                if(mHolding.SeatAssignPolicy == SeatAssignPolicy.Now)
                {
                    foreach (Core.DomainModel.Exam exam in mHolding.Exams)
                    {
                        foreach (ExamParticipate participate in exam.GetParticipates())
                        {
                            bool random = mHolding.SeatNumberPolicy == SeatNumberPolicy.Random;
                            participate.Prepare(random);
                        }
                    }
                }

                mHolding.Save();
                Close();
            }
            GotoNextStep();
        }

        private void rDatePicker1_Leave(object sender, EventArgs e)
        {
            rLblDay.Text = rDatePicker1.Date.GetDayOfWeek().ToDescription();
        }
    }
}
