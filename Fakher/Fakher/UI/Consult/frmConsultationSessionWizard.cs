using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Consult;
using rComponents;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using Time = rComponents.Time;

namespace Fakher.UI.Exam
{
    public partial class frmConsultationSessionWizard : rRadDetailForm
    {
        private bool mCustomChangeTabs;
        private ConsultationSession mConsultationSession;

        public frmConsultationSessionWizard()
        {
            InitializeComponent();

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage1;
            mCustomChangeTabs = false;

            rGridComboBoxPlace.Columns.Add("نام", "نام", "Name");
            rGridComboBoxPlace.DataSource = DbContext.GetAllEntities<Place>();

            rTxtFormationCapacity.Text = "1";
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (StepIndex == 0)
            {
                try
                {
                    rTxtName.Validate();
                    rDatePicker1.Validate();
                    rTxtStartTime.Validate();
                    rtxtEndTime.Validate();
                    rtxtInterval.Validate();
                    rTxtRestInterval.Validate();
                    if (rGridComboBoxPlace.Value == null)
                        throw new MessageException("مکان برگزاری آزمون را انتخاب کنید.");
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }

                int intervalMinutes;
                int restMinutes;
                Time startTime;
                Time endTime;
                try
                {
                    intervalMinutes = rtxtInterval.GetValue<int>();
                    restMinutes = rTxtRestInterval.GetValue<int>();
                    startTime = Time.FromString(rTxtStartTime.Text);
                    endTime = Time.FromString(rtxtEndTime.Text);

                    if(intervalMinutes == 0)
                        throw new MessageException("زمان هر مشاوره را مشخص کنید.");
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    return;
                }

                mConsultationSession = new ConsultationSession();
                mConsultationSession.Name = rTxtName.Text;
                mConsultationSession.StartDate = rDatePicker2.Date;
                mConsultationSession.EndDate = rDatePicker3.Date;
                mConsultationSession.ConsultationDuration = intervalMinutes;
                mConsultationSession.HoldingDate = rDatePicker1.Date;
                mConsultationSession.HoldingStartTime = rTxtStartTime.Text;
                mConsultationSession.HoldingEndTime = rtxtEndTime.Text;
                DateTime startDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                      startTime.Hour, startTime.Minute, 0);
                DateTime endDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                    endTime.Hour, endTime.Minute, 0);
                DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startDateTime.Hour,
                                             startDateTime.Minute, startDateTime.Second);
                while (time < endDateTime)
                {
                    Formation formation = new Formation();
                    formation.StartHour = time.Hour;
                    formation.StartMinute = time.Minute;
                    DateTime formationEndDateTime = time.AddMinutes(intervalMinutes);
                    formation.FinishHour = formationEndDateTime.Hour;
                    formation.FinishMinute = formationEndDateTime.Minute;
                    formation.Day = rDatePicker1.Date.GetDayOfWeek();
                    formation.CapacityPolicy = FormationCapacityPolicy.Specific;
                    formation.Capacity = rTxtFormationCapacity.GetValue<int>();
                    formation.Place = rGridComboBoxPlace.GetValue<Place>();

                    mConsultationSession.AddFormation(formation);

                    formationEndDateTime = formationEndDateTime.AddMinutes(restMinutes);
                    time = new DateTime(formationEndDateTime.Year, formationEndDateTime.Month, formationEndDateTime.Day,
                                        formationEndDateTime.Hour, formationEndDateTime.Minute,
                                        formationEndDateTime.Second);
                }
                btnNext.Text = "تـــایــیــد";
            }
            if (StepIndex == 1)
            {
                mConsultationSession.Save();
                Close();
                return;
            }
            
            GotoNextStep();
        }
    }
}
