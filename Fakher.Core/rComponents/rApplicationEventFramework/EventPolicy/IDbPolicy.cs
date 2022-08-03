using System.ComponentModel;
using rComponents;

namespace rApplicationEventFramework
{
    public interface IDbPolicy : IPolicy
    {
        string TypeName { get; set; }
        string FullTypeName { get; set; }
        EntityEventAction Action { get; set; }
        string FieldName { get; set; }
        string FullFieldName { get; set; }
    }

    public enum EntityEventAction
    {
        [EnumDescription("درج شی")]
        InsertObject,
        [EnumDescription("درج فیلد")]
        InsertFieldValue,
        [EnumDescription("ویرایش شی")]
        EditObject,
        [EnumDescription("ویرایش فیلد")]
        EditFieldValue,
        [EnumDescription("حذف شی")]
        DeleteObject
    }
}