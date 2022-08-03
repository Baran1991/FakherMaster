using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using NHibernate.Linq;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ExamRequest : DbObject
    {
        public ExamRequest()
        {
            Date = PersianDate.Today;
            Status = ExamRequestStatus.Pending;
        }

        public virtual string Name { get; set; }
        public virtual PersianDate Date { get; set; }
        public virtual PersianDate ExamDate { get; set; }
        public virtual string Major { get; set; }
        public virtual string Lesson { get; set; }
        public virtual string Section { get; set; }
        public virtual string StartTime { get; set; }
        public virtual string EndTime { get; set; }
        public virtual int ParticipateCount { get; set; }
        public virtual ExamRequestStatus Status { get; set; }
        [NoCascade]
        public virtual Teacher Teacher { get; set; }

        [NonPersistent]
        public virtual string StatusText
        {
            get { return Status.ToDescription(); }
        }

        public static IList<ExamRequest> GetRequests()
        {
            var query = from request in DbContext.Entity<ExamRequest>()
                        orderby request.ExamDate, request.StartTime
                        select request;
            return query.ToList();
        }

        public static IList<ExamRequest> GetRequests(PersianDate startDate, PersianDate endDate)
        {
            var query = from request in DbContext.Entity<ExamRequest>()
                        where request.ExamDate >= startDate && request.ExamDate <= endDate
                        orderby request.ExamDate, request.StartTime
                        select request;
            return query.ToList();
        }
        
        public static IQueryable<ExamRequest> GetRequests(IList<ExamRequest> requests, ExamRequestStatus status)
        {
            var query = from request in requests
                        where request.Status == status
                        orderby request.ExamDate, request.StartTime
                        select request;
            return query.AsQueryable();
        }
        public static long GetRequestsCount( ExamRequestStatus status)
        {
            var query = from request in DbContext.Entity<ExamRequest>()
                        where request.Status == status
                         select request;
            return  query.Count();
        }
    }

    public enum ExamRequestStatus
    {
        [EnumDescription("در حال بررسی")]
        Pending,
        [EnumDescription("تایید شده")]
        Accepted,
        [EnumDescription("رد شده")]
        Rejected,
        [EnumDescription("اقدام شده")]
        Started,
    }
}