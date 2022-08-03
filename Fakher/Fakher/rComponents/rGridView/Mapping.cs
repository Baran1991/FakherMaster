using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            return Services.GetValue(DataObject, items) + "";
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

    }

    public class ColumnMapping : Mapping
    {
        public ColumnType Type { get; set; }
        public string Format
        {
            get
            {
                if (Type == ColumnType.Money)
                    return "{0:C0}";
                if (Type == ColumnType.GroupedNumber)
                    return "{0:N0}";
                return "{0}";
            }
        }

        public AggregateSummary AggregateSummary { get; set; }
        public bool NestedUpdate { get; set; }
        public SortOrder SortOrder { get; set; }
        public SortOrder GroupOrder { get; set; }

        public ColumnMapping()
        {
            Type = ColumnType.Text;
            AggregateSummary = AggregateSummary.None;
            SortOrder = SortOrder.None;
            GroupOrder = SortOrder.None;
            NestedUpdate = false;
        }
    }

    public class InfoMapping : Mapping
    {
        
    }

    public enum ColumnType
    {
        Text,
        Image,
        Number,
        Decimal,
        Money,
        GroupedNumber
    }

    public enum SortOrder
    {
        [EnumDescription("صعودی")]
        Ascending,
        [EnumDescription("نزولی")]
        Descending,
        [EnumDescription("بدون مرتب سازی")]
        None
    }

    public enum AggregateSummary
    {
        None,
        [EnumDescription("جــمــع")]
        Sum,
        [EnumDescription("حداقل")]
        Min,
        [EnumDescription("حداکثر")]
        Max,
        [EnumDescription("آخرین مقدار")]
        Last,
        [EnumDescription("اولین مقدار")]
        First,
        [EnumDescription("تـعـداد")]
        Count,
        [EnumDescription("میـانگیـن")]
        Avg,
        [EnumDescription("انحراف معیار")]
        StDev,
        [EnumDescription("واریانس")]
        Var
    }
}