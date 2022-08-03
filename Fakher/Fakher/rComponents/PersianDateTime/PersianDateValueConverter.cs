using System;
using DevExpress.Xpo.Metadata;

namespace rComponents
{
    public class PersianDateValueConverter : ValueConverter
    {
        public override object ConvertToStorageType(object value)
        {
            return value + "";
        }

        public override object ConvertFromStorageType(object value)
        {
            return PersianDate.FromString(value + "");
        }

        public override Type StorageType
        {
            get { return typeof (string); }
        }
    }
}