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
            object[] attr = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attr.Length > 0)
                return (attr[0] as DescriptionAttribute).Description;
            else
                return value.ToString();
        }
        public static string[] GetEnumDescriptions(this Type enumType)
        {
            string[] names = Enum.GetNames(enumType);
            List<string> items = new List<string>();

            foreach (string name in names)
            {
                object[] attr = enumType.GetField(name).GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attr.Length > 0)
                    items.Add((attr[0] as DescriptionAttribute).Description);
                else
                    items.Add(name);
            }
            return items.ToArray();
        }
    }
}