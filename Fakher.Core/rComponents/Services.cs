using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace rComponents
{
    public static class Services
    {
        public static string ToShortTimeString(this TimeSpan timeSpan)
        {
            return timeSpan.Hours.ToString("D2") + ":" + timeSpan.Minutes.ToString("D2") + ":" + timeSpan.Seconds.ToString("D2");
        }

        public static void RemoveAll<T>(this IList<T> collection)
        {
            for (int index = collection.Count - 1; index >= 0; index--)
            {
                object item = collection[index];
                collection.Remove((T) item);
            }

        }

        public static void RemoveAll(this IList collection)
        {
            for (int index = collection.Count - 1; index >= 0; index--)
            {
                object item = collection[index];
                collection.Remove(item);
            }
        }

        public static void CopyTo<T>(this IList<T> thisCollection, IList<T> collection)
        {
            foreach (object obj in thisCollection)
                collection.Add((T) obj);
        }

        public static void CopyTo(this IList thisCollection, IList collection)
        {
            foreach (object obj in thisCollection)
                collection.Add(obj);
        }

        public static void CopyTo(this IEnumerable thisCollection, IList collection)
        {
            foreach (object obj in thisCollection)
                collection.Add(obj);
        }

        public static void CopyTo<T>(this IEnumerable thisCollection, IList<T> collection)
        {
            foreach (object obj in thisCollection)
                collection.Add((T) obj);
        }

        public static int GetCount(this IEnumerable collection)
        {
            int count = 0;
            foreach (object obj in collection)
                count++;
            return count;
        }

        public static void SyncWith<T>(this IList<T> thisCollection, IList<T> refCollection)
        {
//            foreach (T refItem in refCollection)
//                if (!thisCollection.Contains(refItem))
//                    thisCollection.Add(refItem);
//            for (int i = thisCollection.Count; i >= 0; i--)
//            {
//                T thisItem = thisCollection[i];
//                if(!refCollection.Contains(thisItem))
//                    thisCollection.RemoveAt(i);
//            }

            thisCollection.RemoveAll();
            refCollection.CopyTo(thisCollection);
        }

        public static void SyncWith<T>(this IList<T> thisCollection, IEnumerable refCollection)
        {
//            foreach (T refItem in refCollection)
//                if (!thisCollection.Contains(refItem))
//                    thisCollection.Add(refItem);
//            for (int i = thisCollection.Count; i >= 0; i--)
//            {
//                T thisItem = thisCollection[i];
//                if (!refCollection.Contains(thisItem))
//                    thisCollection.RemoveAt(i);
//            }

            thisCollection.RemoveAll();
            refCollection.CopyTo(thisCollection);
        }

        public static void SyncPreciseWith<T>(this IList<T> thisCollection, IEnumerable refCollection)
        {
            foreach (T refItem in refCollection)
                if (!thisCollection.Contains(refItem))
                    thisCollection.Add(refItem);
            for (int i = thisCollection.Count - 1; i >= 0; i--)
            {
                T thisItem = thisCollection[i];
                if (!refCollection.Contains(thisItem))
                    thisCollection.RemoveAt(i);
            }
        }

        public static bool Contains(this IEnumerable collection, object item)
        {
            foreach (object obj in collection)
                if (obj == item)
                    return true;
            return false;
        }

        public static void SyncWith(this IList thisCollection, IList refCollection)
        {
            thisCollection.RemoveAll();
            refCollection.CopyTo(thisCollection);
        }

        public static void UniqueAddRange(this IList collection, IEnumerable enumerable)
        {
            foreach (object obj in enumerable)
                UniqueAdd(collection, obj);
        }

        public static void UniqueAdd(this IList collection, object obj)
        {
            if (!collection.Contains(obj))
                collection.Add(obj);
        }

        public static void UniqueAdd<T>(this IList<T> collection, T obj)
        {
            if (!collection.Contains(obj))
                collection.Add(obj);
        }

        private static MemberInfo GetMember(object dataObject, Type type, string memberName)
        {
//            Type type = dataObject.GetType();
            MemberInfo[] info = type.GetMember(memberName);
            if (info.Length == 0)
            {
                if (type.BaseType == typeof(Object))
                    return null;
                else
                    return GetMember(dataObject, type.BaseType, memberName);
            }
            return info[0];
        }

        private static object GetData(object dataObject, MemberInfo memberInfo)
        {
            if (memberInfo == null)
                return null;
            if (memberInfo.MemberType == MemberTypes.Method)
                return (memberInfo as MethodInfo).Invoke(dataObject, null);
            else if (memberInfo.MemberType == MemberTypes.Property)
                return (memberInfo as PropertyInfo).GetValue(dataObject, null);
            return null;
        }

        private static void SetData(object dataObject, MemberInfo memberInfo, object value)
        {
            if (memberInfo == null)
                return;
            if (memberInfo.MemberType == MemberTypes.Property)
                (memberInfo as PropertyInfo).SetValue(dataObject, value, null);
            if(memberInfo.MemberType == MemberTypes.Field)
                (memberInfo as FieldInfo).SetValue(dataObject, value);
        }

        public static object GetValue(object dataObject, List<string> items)
        {
            MemberInfo memberInfo = GetMember(dataObject, dataObject.GetType(), items[0]);
            object result = GetData(dataObject, memberInfo);
            if (result != null)
            {
                if (items.Count == 1)
                    return result;
                else
                {
                    items.RemoveAt(0);
                    return GetValue(result, items);
                }
            }
            return null;
        }

        public static void SetValue(object dataObject, string propertyName, object value)
        {
            List<string> items = new List<string>(propertyName.Split('.'));
            MemberInfo memberInfo = GetMember(dataObject, dataObject.GetType(), items[0]);
            if(items.Count == 1)
                SetData(dataObject, memberInfo, value);
            else
            {
                items.RemoveAt(0);
                SetValue(dataObject, propertyName, items);
            }
        }

        public static void SetLanguageFarsi()
        {
            foreach (InputLanguage il in InputLanguage.InstalledInputLanguages)
            {
                if (il.LayoutName == "Farsi" || il.LayoutName == "Persian")
                {
                    InputLanguage.CurrentInputLanguage = il;
                    return;
                }
            }
        }

        public static void SetLanguageEnglish()
        {
            foreach (InputLanguage il in InputLanguage.InstalledInputLanguages)
            {
                if (il.LayoutName == "US")
                {
                    InputLanguage.CurrentInputLanguage = il;
                    return;
                }
            }
        }

        public static string NormalizeFarsiString(string txt)
        {
            if (string.IsNullOrEmpty(txt))
                return txt;

            return txt.Replace("ك", "ک").Replace("ي", "ی");
        }

        public static string NormalizeEnglishString(string txt)
        {
            if (string.IsNullOrEmpty(txt))
                return txt;
            bool upper = true;
            StringBuilder builder = new StringBuilder(txt.Trim());
            for (int i = 0; i < builder.Length; i++)
            {
                if (upper)
                    builder[i] = Char.ToUpper(builder[i]);
                else
                    builder[i] = Char.ToLower(builder[i]);
                upper = builder[i] == ' ';
            }
            return builder.ToString();
        }

        public static string NormalizeWebString(string txt)
        {
            if (string.IsNullOrEmpty(txt))
                return txt;

            return txt.Replace("\n", "<br />");
        }

        public static string[] NormalizeMobileString(string txt)
        {
            List<string> result = new List<string>();

            if (!string.IsNullOrEmpty(txt))
            {
                string[] phones = txt.Split('-', '/', ',', ' ');
                for (int i = 0; i < phones.Length; i++)
                {
                    string phone = phones[i];
                    if (!phone.StartsWith("0"))
                        phone = "0" + phone;
                    if (!phone.StartsWith("09"))
                        continue;
                    if (phone.Length != 11)
                        continue;
                    result.Add(phone);
                }
            }
            return result.ToArray();
        }

        public static string[] NormalizeMobileString(string[] txts)
        {
            List<string> result = new List<string>();
            foreach (string txt in txts)
            {
                string[] mobileString = NormalizeMobileString(txt);
                result.AddRange(mobileString);
            }

            return result.ToArray();
        }

        public static string ToFarsiFormat(string txt)
        {
            if (string.IsNullOrEmpty(txt))
                return txt;
            return
                txt.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace(
                    "5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
        }

        public static string ToEnglishFormat(string txt)
        {
            if (string.IsNullOrEmpty(txt))
                return txt;
            return
                txt.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace(
                    "۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
        }

        public static CultureInfo GetPersianCulture()
        {
            CultureInfo persianCulture = new CultureInfo("fa-IR");
            DateTimeFormatInfo formatInfo = new DateTimeFormatInfo();
            PersianCalendar persianCalendar = new PersianCalendar();

            formatInfo.AbbreviatedDayNames = new string[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
            formatInfo.DayNames = new string[] { "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه", "شنبه" };
//            formatInfo.AbbreviatedMonthNames = new string[] {"فرو", "ارد", "خرد", "تیر", "مرد", "شهر", "مهر", "آبا", "آذر", "دی", "بهم", "اسف", ""};
            formatInfo.AbbreviatedMonthNames = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
            formatInfo.MonthNames = new string[] {"فروردین" , "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", ""};
            formatInfo.MonthGenitiveNames = new string[] {"فروردین" , "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", ""};
            formatInfo.AMDesignator = "ق.ظ";
            formatInfo.PMDesignator = "ب.ظ";
            formatInfo.FirstDayOfWeek = DayOfWeek.Saturday;
            formatInfo.ShortDatePattern = "yyyy/MM/dd";

            persianCulture.DateTimeFormat = formatInfo;

            //DateTimeFormat
            formatInfo.GetType().GetField("calendar",
                                          BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).SetValue
                (formatInfo, persianCalendar);

            //UseCurrentCalendar(Int32)
            object persianCalendarID =
                persianCalendar.GetType().GetProperty("ID", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(
                    persianCalendar, null);

            object cultureTableRecord = formatInfo.GetType().GetField("m_cultureTableRecord", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetValue(formatInfo);

            MethodInfo methodInfo = cultureTableRecord.GetType().GetMethod("UseCurrentCalendar", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(cultureTableRecord, new object[] { persianCalendarID });


            // CultureInfo
            persianCulture.GetType().GetField("calendar",
                                              BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).
                SetValue(persianCulture, persianCalendar);

            return persianCulture;
        }

        public static void InitializePersianNumberFormat()
        {
            CultureInfo culture = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
            culture.NumberFormat.CurrencyPositivePattern = 3;
            
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        public static string PluralOf(string text)
        {
            var pluralString = text;
            var lastCharacter = pluralString.Substring(pluralString.Length - 1).ToLower();

            // y’s become ies (such as Category to Categories)
            if (string.Equals(lastCharacter, "y", StringComparison.InvariantCultureIgnoreCase))
            {
                pluralString = pluralString.Remove(pluralString.Length - 1);
                pluralString += "ie";
            }

            // ch’s become ches (such as Pirch to Pirches)
            if (string.Equals(pluralString.Substring(pluralString.Length - 2), "ch", StringComparison.InvariantCultureIgnoreCase))
            {
                pluralString += "e";
            }

            switch (lastCharacter)
            {
                case "s":
                    return pluralString + "es";
                default:
                    return pluralString + "s";
            }
        }
        
        public static T Clone<T>(T obj) where T : new()
        {
            T newObj = new T();
            PropertyInfo[] properties = obj.GetType().GetProperties();
            List<PropertyInfo> workingProperties = new List<PropertyInfo>();
            foreach (PropertyInfo property in properties)
                if (
                    
                    //property.PropertyType == typeof (T) 
                    (property.PropertyType.IsPrimitive || property.PropertyType.IsEnum || property.PropertyType == typeof(Decimal) || property.PropertyType == typeof(String))
                    && property.CanWrite 
                    && !property.PropertyType.IsSubclassOf(typeof (IList)) 
                    && property.Name != "Id" 
                    )
                    workingProperties.Add(property);
            
            foreach (PropertyInfo property in workingProperties)
            {
                object value = property.GetValue(obj, null);
                property.SetValue(newObj, value, null);
            }
            return newObj;
        }

        public static byte[] ConvertToByteArray(Bitmap bitmap)
        {
            if (bitmap == null)
                return null;
            Image image = new Bitmap(bitmap);
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            byte[] bytes = memoryStream.ToArray();
            image.Dispose();
            memoryStream.Close();
            memoryStream.Dispose();
            return bytes;
        }

        public static Bitmap ConvertToBitmap(byte[] bytes)
        {
            if (bytes != null)
            {
                MemoryStream stream = new MemoryStream(bytes);
                try
                {
                    Image image = Bitmap.FromStream(stream, true, true);
                    Bitmap bitmap = new Bitmap(image);
                    image.Dispose();
                    return bitmap;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    stream.Close();
                    stream.Dispose();
                }
            }
            return null;
        }

        public static string SecureHtml(string html)
        {
            if (string.IsNullOrEmpty(html))
                return html;
            return html.Replace("<", "&&lt;").Replace(">", "&&gt;");
        }

        public static string[] GetAllProvinces()
        {
            string[] provinces = new string[]
                                     {
                                         "آذربایجان شرقی", "آذربایجان غربی", "اردبیل", "اصفهان",
                                         "البرز", "ایلام", "بوشهر", "تهران", "چهارمحال و بختیاری", "خراسان جنوبی",
                                         "خراسان رضوی", "خراسان شمالی", "خوزستان", "زنجان", "سمنان", "سیستان و بلوچستان", "فارس",
                                         "قزوین", "قم", "کردستان", "کرمان", "کرمانشاه", "کهکیلویه و بویراحمد", "گلستان", "گیلان",
                                         "لرستان", "مازندران", "مرکزی", "هرمزگان", "همدان", "یزد"
                                     };
            return provinces;
        }
    }
}
