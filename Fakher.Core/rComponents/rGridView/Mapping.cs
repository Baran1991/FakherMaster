using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace rComponents
{
    [Serializable]
    public abstract class Mapping
    {
        public string ObjectProperty { get; set; }
        public string Caption { get; set; }
        public HorizontalAlignment TextAlign { get; set; }
        public bool Searchable { get; set; }
        public int Width { get; set; }

        public Mapping()
        {
            TextAlign = HorizontalAlignment.Left;
            Caption = "";
            Searchable = true;
            Width = 100;
        }

        public string GetValue(object DataObject)
        {
            List<string> items = ObjectProperty.Split('.').ToList<string>();
            return GetValue(DataObject, items);
        }
        private MemberInfo GetMember(object dataObject, string memberName)
        {
            MemberInfo[] info = dataObject.GetType().GetMember(memberName);
            if (info.Length == 0)
                return null;
            return info[0];
        }
        private object GetValue(object dataObject, MemberInfo memberInfo)
        {
            if (memberInfo.MemberType == MemberTypes.Method)
                return (memberInfo as MethodInfo).Invoke(dataObject, null);
            else if (memberInfo.MemberType == MemberTypes.Property)
                return (memberInfo as PropertyInfo).GetValue(dataObject, null);
            return null;
        }
        private string GetValue(object DataObject, List<string> items)
        {
            MemberInfo memberInfo = GetMember(DataObject, items[0]);
            object result = GetValue(DataObject, memberInfo);
            if (result != null)
            {
                if (items.Count == 1)
                    return result.ToString();
                else
                {
                    items.RemoveAt(0);
                    return GetValue(result, items);
                }
            }
            return "بدون مقدار";
        }

//        public Type GetType(object DataObject)
//        {
//            List<string> items = ObjectProperty.Split('.').ToList<string>();
//            return GetType(DataObject, items);
//        }
//
//        private Type GetType(object DataObject, List<string> items)
//        {
//            MemberInfo memberInfo = GetMember(DataObject, items[0]);
//            object result = GetValue(DataObject, memberInfo);
//            if (result != null)
//            {
//                if (items.Count == 1)
//                    return (memberInfo as PropertyInfo).PropertyType;
//                else
//                {
//                    items.RemoveAt(0);
//                    return GetType(result, items);
//                }
//            }
//            return null;
//        }
    }

    public enum ColumnType
    {
        Text,
        Image
    }

    public class ColumnMapping : Mapping
    {
        public ColumnType Type { get; set; }
        public string Format { get; set; }

        public ColumnMapping()
        {
            Type = ColumnType.Text;
        }
    }

    public class InfoMapping : Mapping
    {
        
    }
}