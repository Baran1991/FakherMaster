using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace rComponents
{
    public partial class rScheduler : UserControl
    {
        public rScheduler()
        {
            InitializeComponent();
            Configure();
        }

        public SchedulerAppointmentCollection Items
        {
            get
            {
                return radScheduler1.Appointments;
            }
        }

        public bool ShowNavigator
        {
            get
            {
                return radSchedulerNavigator1.Visible;
            }
            set
            {
                radSchedulerNavigator1.Visible = value;
            }
        }

        public SchedulerView ActiveView
        {
            get
            {
                return radScheduler1.ActiveView;
            }
        }

        public SchedulerViewType ActiveViewType
        {
            get
            {
                return radScheduler1.ActiveViewType;
            }
            set
            {
                radScheduler1.ActiveViewType = value;
            }
        }

        public bool CanPrint
        {
            get
            {
                return lnkPrint.Visible;
            }
            set
            {
                lnkPrint.Visible = value;
            }
        }

        private void Configure()
        {
            SchedulerNavigatorLocalizationProvider.CurrentProvider = new FarsiSchedulerNavigatorLocalizationProvider();
            RadSchedulerLocalizationProvider.CurrentProvider = new FarsiRadSchedulerLocalizationProvider();
            radScheduler1.Culture = Services.GetPersianCulture();

            SchedulerWeekView schedulerWeekView = radScheduler1.GetWeekView();
            schedulerWeekView.WorkTime.Start = new TimeSpan(7, 0, 0);
            schedulerWeekView.WorkTime.End = new TimeSpan(24, 0, 0);
            schedulerWeekView.RulerStartScale = 7;
            schedulerWeekView.RulerEndScale = 24;

            radSchedulerNavigator1.ShowWeekendCheckBox.Visibility = ElementVisibility.Hidden;
            radSchedulerNavigator1.DateLabelElement.Visibility = ElementVisibility.Hidden;
        }

        private void radScheduler1_ActiveViewChanging(object sender, SchedulerViewChangingEventArgs e)
        {
            if (e.NewView.ViewType == SchedulerViewType.Day)
            {
                SchedulerDayView view = e.NewView as SchedulerDayView;
                view.WorkTime.Start = new TimeSpan(7, 0, 0);
                view.WorkTime.End = new TimeSpan(24, 0, 0);
                view.RulerStartScale = 7;
                view.RulerEndScale = 24;
                view.DayCount = 1;
            }
            if (e.NewView.ViewType == SchedulerViewType.Week)
            {
                SchedulerWeekView view = e.NewView as SchedulerWeekView;
                view.WorkTime.Start = new TimeSpan(7, 0, 0);
                view.WorkTime.End = new TimeSpan(24, 0, 0);
                view.RulerStartScale = 7;
                view.RulerEndScale = 24;
            }

            if (e.NewView.ViewType == SchedulerViewType.Month)
            {
                SchedulerMonthView view = e.NewView as SchedulerMonthView;
            }

            e.NewView.CurrentCulture = radScheduler1.Culture;
            e.NewView.AllowAppointmentMove = false;
            e.NewView.AllowAppointmentResize = false;
            e.NewView.AllowToolTips = true;
            e.NewView.AllowResourcesScrolling = false;
        }

        private void lnkPrint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;
            printDocument1.PrinterSettings = dialog.PrinterSettings;
            printDocument1.Print();
        }

        private void radScheduler1_ContextMenuShowing(object sender, SchedulerContextMenuShowingEventArgs e)
        {
            e.Cancel = true;
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(radScheduler1.Width, radScheduler1.Height);
            radScheduler1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            e.Graphics.DrawImage(bmp, e.PageBounds);
            e.HasMorePages = false;
            bmp.Dispose();
        }

        private void UpdateControl()
        {
            if (!ShowNavigator)
            {
                tableLayoutPanel1.RowStyles[0].Height = 0;
            }
        }

        private void rScheduler_Load(object sender, EventArgs e)
        {
            UpdateControl();
        }

        public void Fill(List<Section> sections)
        {
            foreach (Section section in sections)
            {
                foreach (Formation formation in section.Formations)
                {
                    DateTime startDateTime = section.StartDate.ToSystemDateTime(formation.StartHour, formation.StartMinute, 0);
                    DateTime startDateEndTime = section.StartDate.ToSystemDateTime(formation.FinishHour, formation.FinishMinute, 0);
                    DateTime endDateTime = section.FinishDate.ToSystemDateTime(formation.StartHour, formation.StartMinute, 0);

                    string place = formation.Place != null ? "اتاق " + formation.Place.Name : "";
                    string location = section.Teacher.FarsiFullname + " - " + place;
                    string summary = section.Major.Name + " - " + section;
                    string description = "";

                    Appointment appointment = new Appointment(startDateTime, startDateEndTime, summary, description, location);
//                    appointment.Background = AppointmentBackground.Important;
//                    appointment.Status = AppointmentStatus.Unavailable;
                    appointment.AllowDelete = false;
                    appointment.AllowEdit = false;
                    appointment.ToolTipText = summary + "\r\n" + location;

                    WeekDays day;
                    switch (formation.Day)
                    {
                        case WeekDay.Saturday:
                            day = WeekDays.Saturday;
                            break;
                        case WeekDay.Sunday:
                            day = WeekDays.Sunday;
                            break;
                        case WeekDay.Monday:
                            day = WeekDays.Monday;
                            break;
                        case WeekDay.Tuesday:
                            day = WeekDays.Tuesday;
                            break;
                        case WeekDay.Wednesday:
                            day = WeekDays.Wednesday;
                            break;
                        case WeekDay.Thursday:
                            day = WeekDays.Thursday;
                            break;
                        default:
                            day = WeekDays.Friday;
                            break;
                    }
                    WeeklyRecurrenceRule rule = new WeeklyRecurrenceRule(startDateTime, endDateTime, day, 1);
                    appointment.RecurrenceRule = rule;
                    radScheduler1.Appointments.Add(appointment);
                }
            }
        }
    }
}
