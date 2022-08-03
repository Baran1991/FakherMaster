using System.Linq;
using DataAccessLayer;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Mark : DbObject
    {
        public virtual int BatchNumber { get; set; }
        public virtual PersianDate Date { get; set; }
        [NoCascade]
        public virtual Lesson Lesson { get; set; }
        [NoCascade]
        public virtual EvaluationItem EvaluationItem { get; set; }
        [NoCascade]
        public virtual Participate Participate { get; set; }
        public virtual float Value { get; set; }
        [NoCascade]
        public virtual MarkEntryLicense MarkEntryLicense { get; set; }

        public Mark()
        {
            Date = PersianDate.Today;
            Value = 0;
        }

        public static int GetNextBatchNumber()
        {
            var query = from mark in DbContext.Entity<Mark>()
                        orderby mark.BatchNumber descending
                        select mark.BatchNumber;
            int lastNumber = query.FirstOrDefault();
            return lastNumber + 1;
        }
    }
}