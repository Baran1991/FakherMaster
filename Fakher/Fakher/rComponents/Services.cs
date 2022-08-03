using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using rComponents;

namespace rComponents
{
    public static class Services
    {
        public static void Clear(this IList collection)
        {
            for (int index = collection.Count - 1; index >= 0; index--)
            {
                object item = collection[index];
                collection.Remove(item);
            }

        }

        public static void CopyTo(this IList thisCollection, IList collection)
        {
            foreach (object obj in thisCollection)
                collection.Add(obj);
        }

        public static void SyncWith(this IList thisCollection, IList refCollection)
        {
            thisCollection.Clear();
            refCollection.CopyTo(thisCollection);
        }

        public static void UniqueAddRange(this IList collection, IEnumerable enumerable)
        {
            foreach (object obj in enumerable)
                if (!collection.Contains(obj))
                    collection.Add(obj);
        }

        private static MemberInfo GetMember(object dataObject, string memberName)
        {
            MemberInfo[] info = dataObject.GetType().GetMember(memberName);
            if (info.Length == 0)
                return null;
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

        public static object GetValue(object dataObject, List<string> items)
        {
            MemberInfo memberInfo = GetMember(dataObject, items[0]);
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

        public static void SetLanguageFarsi()
        {
            foreach (InputLanguage il in InputLanguage.InstalledInputLanguages)
            {
                if (il.LayoutName == "Farsi")
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
    }
}
