using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    [EventClass("لیست رزرو")]
    public class ReserveList : DbObject
    {
        public ReserveList()
        {
            Capacity = 5;
            Reserves = new List<Reserve>();
        }

        [EventClassProperty("نام لیست رزرو", null)]
        public virtual string Name { get; set; }
        [EventClassProperty("ظرفیت", null)]
        public virtual int Capacity { get; set; }
        [EventClassProperty("شهریه رزرو", null)]
        public virtual long TuitionFee { get; set; }
        [MaximumLength]
        public virtual string RecieptNote { get; set; }
        [NoCascade]
        public virtual EducationalPeriod Period { get; set; }
        [EventClassProperty("رشته", null)]
        [NoCascade]
        public virtual Major Major { get; set; }
        [EventClassProperty("کلاس", null)]
        [NoCascade]
        public virtual Section Section { get; set; }
        public virtual ReserveType reserveType { get; set; }
        public virtual IList<Reserve> Reserves { get; set; }

        //public virtual DateTime Day { get; set; }
        //public virtual Time Time { get; set; }

        [NonPersistent]
        public virtual int Remainder
        {
            get
            {
                return Capacity - Reserves.Count;
            }
        }

        [NonPersistent]
        public virtual IQueryable<Reserve> RegisteredReserves
        {
            get
            {
                var query = from reserve in Reserves
                            where reserve.Register != null
                            select reserve;
                return query.AsQueryable();
            }
        }

        [NonPersistent]
        public virtual int RegisteredReservesCount
        {
            get { return RegisteredReserves.Count(); }
        }

        public static List<ReserveList> GetReserveList(EducationalPeriod period, Major major)
        {
            var query = from reserveList in DbContext.Entity<ReserveList>()
                        where (reserveList.Period.Id == period.Id && reserveList.Major.Id == major.Id && reserveList.reserveType == null) || (reserveList.Period.Id == period.Id && reserveList.Major.Id == major.Id && reserveList.reserveType == ReserveType.ReserveList) 
                        select reserveList;
            return query.ToList();
        }
        public static List<ReserveList> GetReserveListByType(EducationalPeriod period, Major major, ReserveType type)
        {
            var query = from reserveList in DbContext.Entity<ReserveList>()
                        where reserveList.Period.Id == period.Id && reserveList.Major.Id == major.Id && reserveList.reserveType == type
                        select reserveList;
            return query.ToList();
        }

        public static List<ReserveList> GetSectionReserveList(EducationalPeriod period, Major major)
        {
            var query = from reserveList in DbContext.Entity<ReserveList>()
                        where reserveList.Period.Id == period.Id
                        && reserveList.Major.Id == major.Id
                        && reserveList.Section != null
                        && reserveList.reserveType == null || reserveList.reserveType == ReserveType.ReserveList

                        select reserveList;
            return query.ToList();
        }
        public static List<ReserveList> GetSectionLevelDeterminationList(EducationalPeriod period, Major major)
        {
            var query = from reserveList in DbContext.Entity<ReserveList>()
                        where reserveList.Period.Id == period.Id
                        && reserveList.Major.Id == major.Id
                        && reserveList.Section != null
                        && reserveList.reserveType==ReserveType.LevelDetermination
                        select reserveList;
            return query.ToList();
        }

        public override string ToString()
        {
            return Name;
        }
        public enum ReserveType
        {
            [EnumDescription("لیست های رزرو")]
            ReserveList,
            [EnumDescription("لیست های تعیین سطح")]
            LevelDetermination,
        }


        //        public virtual string GetNextCode()
        //        {
        //            return Register.GetCode(Major, Period);
        //        }

        
    }
}