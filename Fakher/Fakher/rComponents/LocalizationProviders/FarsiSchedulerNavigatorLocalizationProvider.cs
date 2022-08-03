using System;
using Telerik.WinControls.UI;

namespace rComponents
{
    public class FarsiSchedulerNavigatorLocalizationProvider : SchedulerNavigatorLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case SchedulerNavigatorStringId.DayViewButtonCaption:
                    {
                        return "نـمـای روزانـه";
                    }
                case SchedulerNavigatorStringId.WeekViewButtonCaption:
                    {
                        return "نـمـای هـفـتگـی";
                    }
                case SchedulerNavigatorStringId.MonthViewButtonCaption:
                    {
                        return "نـمـای مـاهـانـه";
                    }
                case SchedulerNavigatorStringId.TimelineViewButtonCaption:
                    {
                        return "نـمـای خــطــی";
                    }
                case SchedulerNavigatorStringId.ShowWeekendCheckboxCaption:
                    {
                        return "نمایش تعطیلات هفته";
                    }
            }

            return String.Empty;
        }
    }
}