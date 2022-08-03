using System;
using System.Collections.Generic;
using System.Globalization;

namespace rComponents
{
    public partial class PersianDate : IConvertible
    {
        static PersianDate()
        {
//            rSentinel.Check();
        }

        public Calendar Calendar { get; set; }
        
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public PersianDate()
        {
            Calendar = new PersianCalendar();
        }

        public string MonthName
        {
            get
            {
                string[] names = new string[] {"فروردین" , "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"};
                return names[Month - 1];
            }
        }

        public PersianDate AddDays(int days)
        {
            return FromSystemDate(Calendar.AddDays(ToSystemDateTime(), days));
        }
        public PersianDate AddMonths(int months)
        {
            return FromSystemDate(Calendar.AddMonths(ToSystemDateTime(), months));
        }
        public PersianDate AddYears(int years)
        {
            return FromSystemDate(Calendar.AddYears(ToSystemDateTime(), years));
        }
        public PersianDate AddHours(int hours)
        {
            return FromSystemDate(Calendar.AddHours(ToSystemDateTime(), hours));
        }
        public PersianDate AddMinutes(int minutes)
        {
            return FromSystemDate(Calendar.AddMinutes(ToSystemDateTime(), minutes));
        }
        public PersianDate AddSeconds(int seconds)
        {
            return FromSystemDate(Calendar.AddSeconds(ToSystemDateTime(), seconds));
        }
        public PersianDate AddMilliSeconds(int milliSeconds)
        {
            return FromSystemDate(Calendar.AddMilliseconds(ToSystemDateTime(), milliSeconds));
        }
        public PersianDate AddWeeks(int weeks)
        {
            return FromSystemDate(Calendar.AddWeeks(ToSystemDateTime(), weeks));
        }
        public PersianDate AddTimeZone(double timeZone)
        {
            int hours = (int)Math.Truncate(timeZone);
            double mins = timeZone - hours;
            int minutes = (int)(mins * 60);

            return AddHours(hours).AddMinutes(minutes);
        }
        
        public override string ToString()
        {
            return ToShortDateString();
        }

        public override bool Equals(object obj)
        {
            return this == (obj as PersianDate);
        }

        public string ToShortDateString()
        {
            return Year + "/" + Month.ToString("D2") + "/" + Day.ToString("D2");
        }

        public DateTime ToSystemDateTime()
        {
            DateTime dateTime = Calendar.ToDateTime(Year, Month, Day, 0, 0, 0, 0);
            return dateTime;
        }

        public DateTime ToSystemDateTime(int hour, int minute, int second)
        {
            DateTime dateTime = Calendar.ToDateTime(Year, Month, Day, hour, minute, second, 0);
            return dateTime;
        }

        #region Static Members

        public static PersianDate Today
        {
            get
            {
                return FromSystemDate(DateTime.Now);
            }
        }
        public static PersianDate[] GetDatesBetween(PersianDate startDate, PersianDate endDate)
        {
            PersianDate tmpDate = startDate.Clone();
            List<PersianDate> dates = new List<PersianDate>();
            while (tmpDate != endDate)
            {
                tmpDate = tmpDate.AddDays(1);
                dates.Add(tmpDate);
            }
            if(dates.Count > 0)
                dates.RemoveAt(dates.Count - 1);
            return dates.ToArray();
        }

        public static PersianDate[] GetFridaysBetween(PersianDate startDate, PersianDate endDate)
        {
            PersianDate tmpDate = startDate.Clone();
            List<PersianDate> dates = new List<PersianDate>();
            while (tmpDate != endDate)
            {
                tmpDate = tmpDate.AddDays(1);
                if(tmpDate.Calendar.GetDayOfWeek(tmpDate.ToSystemDateTime()) == DayOfWeek.Friday)
                    dates.Add(tmpDate);
            }
            return dates.ToArray();
        }

        public PersianDate Clone()
        {
            return FromString(ToString());
        }

        public static bool operator >(PersianDate dateTime1, PersianDate dateTime2)
        {
            return dateTime1.ToSystemDateTime() > dateTime2.ToSystemDateTime();
        }
        public static bool operator <(PersianDate dateTime1, PersianDate dateTime2)
        {
            return dateTime1.ToSystemDateTime() < dateTime2.ToSystemDateTime();
        }
        public static bool operator >=(PersianDate dateTime1, PersianDate dateTime2)
        {
            return dateTime1.ToSystemDateTime() >= dateTime2.ToSystemDateTime();
        }
        public static bool operator <=(PersianDate dateTime1, PersianDate dateTime2)
        {
            return dateTime1.ToSystemDateTime() <= dateTime2.ToSystemDateTime();
        }
        public static bool operator ==(PersianDate dateTime1, PersianDate dateTime2)
        {
            if (IsNull(dateTime1) && IsNull(dateTime2))
                return true;
            if (IsNull(dateTime1) ^ IsNull(dateTime2))
                return false;

            return dateTime1.ToSystemDateTime() == dateTime2.ToSystemDateTime();
        }
        public static bool operator !=(PersianDate dateTime1, PersianDate dateTime2)
        {
            if(IsNull(dateTime1) && IsNull(dateTime2))
                return false;

            if (IsNull(dateTime1) ^ IsNull(dateTime2))
                return true;

            return dateTime1.ToSystemDateTime() != dateTime2.ToSystemDateTime();
        }
        public static TimeSpan operator -(PersianDate dateTime1, PersianDate dateTime2)
        {
            return dateTime1.ToSystemDateTime() - dateTime2.ToSystemDateTime();
        }
        public static explicit operator PersianDate(string date)
        {
            return FromString(date);
        }
        public static PersianDate FromSystemDate(DateTime dateTime)
        {
            PersianDate persianDate = new PersianDate();

            persianDate.Year = persianDate.Calendar.GetYear(dateTime);
            persianDate.Month = persianDate.Calendar.GetMonth(dateTime);
            persianDate.Day = persianDate.Calendar.GetDayOfMonth(dateTime);

            return persianDate;
        }
        public static PersianDate FromString(string dateString)
        {
            try
            {
                if(string.IsNullOrEmpty(dateString))
                    return null;
                string[] items = dateString.Split(' ');
                string[] dateItems = items[0].Split('/');

                int year = Convert.ToInt32(dateItems[0]);
                int month = Convert.ToInt32(dateItems[1]);
                int day = Convert.ToInt32(dateItems[2]);

                PersianDate persianDate = new PersianDate();
                persianDate.Year = year;
                persianDate.Month = month;
                persianDate.Day = day;

                return persianDate;
            }
            catch (Exception ex)
            {
                throw new FormatException("", ex);
            }
        }
        public static PersianDate ByCast(object o)
        {
            return FromString(o + "");
        }
        public static bool IsNull(PersianDate date)
        {
            try
            {
                DateTime time = date.ToSystemDateTime();
            }
            catch (NullReferenceException)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Implementation of IConvertible

        public TypeCode GetTypeCode()
        {
            return TypeCode.String;
//            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            if(conversionType == GetType())
                return this;
            return this;
        }

        #endregion
    }
}