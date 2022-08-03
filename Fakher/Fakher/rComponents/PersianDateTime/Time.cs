using System;

namespace rComponents
{
    public partial class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        static Time()
        {
            rSentinel.Check();
        }

        public Time()
        {
            Hour = 0;
            Minute = 0;
            Second = 0;
        }

        public override string ToString()
        {
            string result = Hour.ToString("D2") + ":" + Minute.ToString("D2");
            if(Second != 0)
               result += ":" + Second.ToString("D2");
            return result;
        }

        public static Time FromString(string timeString)
        {
            if(string.IsNullOrEmpty(timeString))
                return null;
            try
            {
                string[] items = timeString.Split(' ');
                string[] timeItems = items[0].Split(':');

                if(timeItems.Length < 2)
                    return null;
                int hour = Convert.ToInt32(timeItems[0]);
                int minute = Convert.ToInt32(timeItems[1]);
                int second = 0;
                if(timeItems.Length > 2)
                    second = Convert.ToInt32(timeItems[2]);

                Time time = new Time();
                time.Hour = hour;
                time.Minute = minute;
                time.Second = second;

                return time;
            }
            catch (Exception ex)
            {
                throw new FormatException("", ex);
            }
        }

        public static Time FromTimeSpan(TimeSpan span)
        {
            return new Time { Hour = span.Hours, Minute = span.Minutes, Second = span.Seconds };
        }

        public static bool IsValid(string time)
        {
            try
            {
                Time time1 = FromString(time);
                if(time1 == null)
                    throw new Exception();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static Time Now
        {
            get
            {
                return FromTimeSpan(DateTime.Now.TimeOfDay);
            }
        }
    }
}