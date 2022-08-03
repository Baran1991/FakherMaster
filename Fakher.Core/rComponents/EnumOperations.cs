using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace rComponents
{
    public static class EnumOperations
    {
        static EnumOperations()
        {
//            rSentinel.Check();
        }

        public static string ToDescription(this Enum value)
        {
//            object[] attr = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            object[] attr = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(EnumDescription), false);
            if (attr.Length > 0)
//                return (attr[0] as DescriptionAttribute).Description;
                return (attr[0] as EnumDescription).Description;
            else
                return value.ToString();
        }

        public static string[] GetEnumDescriptions(this Type enumType)
        {
            string[] names = Enum.GetNames(enumType);
            List<string> items = new List<string>();

            foreach (string name in names)
            {
                Enum @enum = Enum.Parse(enumType, name) as Enum;
                items.Add(@enum.ToDescription());

//                object[] attr = enumType.GetField(name).GetCustomAttributes(typeof(DescriptionAttribute), false);
//                if (attr.Length > 0)
//                    items.Add((attr[0] as DescriptionAttribute).Description);
//                else
//                    items.Add(name);
            }
            return items.ToArray();
        }

        public static EnumItem[] GetEnumItems(this Type enumType)
        {
            List<EnumItem> items = new List<EnumItem>();
            Array values = Enum.GetValues(enumType);
            foreach (Enum value in values)
            {
                EnumItem item = new EnumItem();
                item.Name = value + "";
                item.Value = Convert.ToInt32(value);
                item.Description = value.ToDescription();

                items.Add(item);
            }
            return items.ToArray();
        }
    }

    public class EnumItem
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }

    public class EnumDescription : Attribute
    {
        public string Description { get; set; }

        public EnumDescription(string description)
        {
            Description = description;
        }
    }
}