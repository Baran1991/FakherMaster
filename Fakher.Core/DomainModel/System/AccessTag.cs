using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class AccessTag : DbObject
    {
        public virtual AccessTagType Type { get; set; }
        public virtual bool HasPassword { get; set; }
        public virtual string Password { get; set; }

        public AccessTag()
        {
            
        }

        [NonPersistent]
        public virtual string TypeText
        {
            get { return Type.ToDescription(); }
        }
    }

    public enum AccessTagType
    {
        [EnumDescription("تسویه حساب پرسنل")]
        EmployeePayOff,
        [EnumDescription("ساخت تنظیمات آمــوزشــی")]
        StudentConfiguration,
        [EnumDescription("ویرایش گروه های آمــوزشــی")]
        EducationalSectionEdit,
        [EnumDescription("ویرایش ظرفیت گروه های آمــوزشــی")]
        EducationalSectionCapacityEdit,
        [EnumDescription("تغیر وضعیت چک")]
        ChequeChangeStatus,
        [EnumDescription("عملیات فیش بانکی")]
        RecieptChangeStatus,

        [EnumDescription("ویرایش درخواست های بدون پاسخ")]
        notRepliedRequests,
        [EnumDescription("ویرایش درخواست های در حال بازبینی")]
        InRevise,
        [EnumDescription("ویرایش درخواست های ارجاع شده به امور مرخصی")]
        ReferrToLeave,
        [EnumDescription("ویرایش درخواست های ارجاع شده به امور مصاحبه")]
        ReferrToInterview,
        [EnumDescription("ویرایش درخواست های ارجاع شده به امور مشاوره")]
        ReferrToConsultant,
        [EnumDescription("ویرایش درخواست های ارجاع شده به امور صدور مدرک و گواهی")]
        ReferrToCertificate, 
        [EnumDescription("ویرایش درخواست های ارجاع شده به امور آزمون")]
        ReferrToExam,
        [EnumDescription("ویرایش درخواست های ارجاع شده به امور پرسنل")]
        ReferrToStaff,
        [EnumDescription("ویرایش درخواست های ارجاع شده به امور مالی و انصراف")]
        ReferrToFinansial,
        [EnumDescription("ویرایش درخواست های ارجاع شده به امور انتشارات")]
        ReferrToPublishing,
        [EnumDescription("ویرایش درخواست های ارجاع شده به امور مدرسین")]
        ReferrToTeachers,
        [EnumDescription("ویرایش درخواست های ارجاع شده به امور آموزش")]
        ReferrToTraining,
        [EnumDescription("ویرایش درخواست های ارجاع شده به امور انتقال")]
        ReferrToTr,
      

    }
}