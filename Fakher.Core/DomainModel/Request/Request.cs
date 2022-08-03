using System;
using System.Collections.Generic;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;
using System.Linq;
using NHibernate.Linq;
using System.Threading.Tasks;

namespace Fakher.Core.DomainModel
{
    [EventClass("درخواست")]
    public class Request : DbObject
    {
        public Request()
        {
            Date = PersianDate.Today;
            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;
        }

        public virtual RequestStatus Status { get; set; }
        public virtual PersianDate Date { get; set; }
        public virtual PersianDate LastUpdateDate { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        public virtual int LastUpdateHour { get; set; }
        public virtual int LastUpdateMinute { get; set; }
        public virtual PersianDate resDate1 { get; set; }
        public virtual int resHour1 { get; set; }
        public virtual int resMinute1 { get; set; }
        public virtual PersianDate resDate2 { get; set; }
        public virtual int resHour2 { get; set; }
        public virtual int resMinute2 { get; set; }
        public virtual PersianDate reqDate2 { get; set; }
        public virtual int reqHour2 { get; set; }
        public virtual int reqMinute2 { get; set; }
        [EventClassProperty("عنوان درخواست", null)]
        public virtual string Title { get; set; }
        public virtual RequestType Type { get; set; }
        [MaximumLength]
        public virtual string Text { get; set; }
        [MaximumLength]
        public virtual string Result { get; set; }
        [MaximumLength]
        public virtual string Text2 { get; set; }
        [MaximumLength]
        public virtual string Result2 { get; set; }
        [NoCascade]
        public virtual Student Student { get; set; }
        [NoCascade]
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee2 { get; set; }

        public virtual bool InternetRegisteration { get; set; }
        [NonPersistent]
        public virtual string CreateDateTime
        {
            get
            {
                return Date.ToString() +" "+Hour.ToString()+ ":" + Minute.ToString();
            }
        }
        [NonPersistent]
        public virtual string LastUpdateTime
        {
            get
            {
                return LastUpdateHour + ":" + LastUpdateMinute;
            }
        }
        [NonPersistent]
        public virtual string LastUpdate
        {
            get
            {
                return LastUpdateDate + " " + LastUpdateHour + ":" + LastUpdateMinute;
            }
        }
      
        [NonPersistent]
        public virtual bool IsReplied
        {
            get
            {
                //return !string.IsNullOrEmpty(Result);
                return Status == RequestStatus.Replied;
            }
        }
        [NonPersistent]
        public virtual bool MustRevise
        {
            get
            {
                return Status == RequestStatus.InRevise;
            }
        }
        [NonPersistent]
        public virtual string StatusText
        {
            get
            {
                //if (IsReplied)
                //    return "جواب داده شده";
                //return "در حال بررسی";
                return Status.ToDescription();
            }
        }
        [NonPersistent]
        public virtual string SubmitTypeText
        {
            get
            {
                if (InternetRegisteration)
                    return "اینترنتی";
                return "حضوری";
            }
        }

        public virtual string GetReplyHtmlText()
        {
            string html = "";
            html += "<div style=\"font-family:Tahoma; text-align: right; direction: rtl\">";
            html += "<p>دانشجوی گرامی،</p>";
            html += string.Format("<p>به درخواست شما با عنوان ({0}) پاسخ داده شده است.</p>", Title);
            html += "<p>جهت مشاهده، به وب سایت موسسه، بخش سیستم آموزش دانشجویان مراجعه کنید.</p>";
            html += "<br />";
            html += "<p></p><hr style=\"width: 50%; text-align: center;\" /><p></p>";
            html += "<p style=\"text-align: center; font-size: 8pt;\">این ایمیل به صورت خودکار ارسال گردیده، لطفا به آن پاسخ ندهید.</p>";
            html += "</div>";
            return html;
        }

        public static IQueryable<Request> GetRepliedRequests()
        {
            var query1 = from request in DbContext.Entity<Request>()
                         select request;
            var query2 = from request in query1.ToList()
                         where request.IsReplied
                         select request;
            return query2.AsQueryable();
        }
       
        public static IQueryable<Request> GetRequestsByStatus(RequestStatus status)
        {
            var query1 = from request in DbContext.Entity<Request>()
                         where request.Status == status
                         select request;
          
            return query1.AsQueryable();
        }
        public static long GetRequestsByStatusCount(RequestStatus status)
        {
            var query1 = from request in DbContext.Entity<Request>()
                         where request.Status == status
                         select request;
        
            return  query1.Count();
        }
        //public static IQueryable<Request> GetNotRepliedRequests()
        //{
        //    var query1 = from request in DbContext.Entity<Request>()
        //                 select request;
        //    var query2 = from request in query1.ToList()
        //                 where !request.IsReplied
        //                 select request;
        //    return query2.AsQueryable();
        //}

        public static Request FromId(int id)
        {
            return DbContext.FromId<Request>(id);
        }
    }

    public enum RequestStatus
    {
        [EnumDescription("در انتظار پاسخ")]
        Waiting,
        [EnumDescription("پـاسخ داده شده")]
        Replied,
        [EnumDescription("در حال بازبینی")]
        InRevise,
        [EnumDescription("ارجاع به آموزش")]
        ReferrToTraining,
        [EnumDescription("ارجاع به مرخصی")]
        ReferrToLeave,
        [EnumDescription("ارجاع به آزمون")]
        ReferrToExam,
        [EnumDescription("ارجاع به مصاحبه")]
        ReferrToInterview,
        [EnumDescription("ارجاع به انتقال")]
        ReferrToTr,
        [EnumDescription("ارجاع به مالی و انصراف")]
        ReferrToFinansial,
        [EnumDescription("ارجاع به صدور مدرک و گواهی")]
        ReferrToCertificate,
        [EnumDescription("ارجاع به انتشارات")]
        ReferrToPublishing,
        [EnumDescription("ارجاع به مدرسین")]
        ReferrToTeachers,
        [EnumDescription("ارجاع به پرسنل")]
        ReferrToStaff,
        [EnumDescription("ارجاع به مشاوره")]
        ReferrToConsultant,
    }

    public enum RequestType
    {
        [EnumDescription("صدور گواهی")]
        Testimony,
        [EnumDescription("صدور مدرک")]
        Certification,
        [EnumDescription("استرداد چک")]
        ChequeReturn,
        [EnumDescription("درخواست تخفیف")]
        DiscountRequest,
        [EnumDescription("عدم ارسال چک به بانک")]
        ChequeDelay,
        [EnumDescription("درخواست ملاقات")]
        Meeting,
        [EnumDescription("مشاوره")]
        Consultation,
        [EnumDescription("درخواست مرخصی")]
        Vacation,
        [EnumDescription("آزمون مجدد")]
        ExamRepeat,
        [EnumDescription("مصاحبه مجدد")]
        OralExamRepeat,
        [EnumDescription("پیشنهادات/انتقادات")]
        Suggestion,
        [EnumDescription("سایر")]
        Other
    }
}