using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataAccessLayer;
using DevExpress.Xpo;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Holding : XPObject
    {
        public Holding(Session session) : base(session)
        {
            StartDate = FinishDate = PersianDate.Today;
            Capacity = 22;
        }

        public Holding()
        {
            StartDate = FinishDate = PersianDate.Today;
            Capacity = 22;
        }

        public string Name { get; set; }
        public PersianDate StartDate { get; set; }
        public PersianDate FinishDate { get; set; }
        public int Capacity { get; set; }
        public string Notes { get; set; }
        public Major Major { get; set; }
        public EducationalPeriod Period { get; set; }

        [Association, Aggregated, Delayed]
        public XPCollection<Formation> Formations
        {
            get { return GetCollection<Formation>("Formations"); }
        }
        [Association, Aggregated, Delayed]
        public XPCollection<HoldingItem> Items
        {
            get { return GetCollection<HoldingItem>("Items"); }
        }

        [NonPersistent]
        public string ItemsText
        {
            get
            {
                if (Items.Count == 1)
                    return Items[0].Lesson.Name;
                if(Items.Count > 1)
                    return TypeText;
                return "نا مشخص";
            }
        }

        [NonPersistent]
        public int RemainderCount
        {
            get
            {
                return Capacity - GetParticipates().Count();
            }
        }

        [NonPersistent]
        public string FormationText
        {
            get
            {
                string txt = "";
                foreach (Formation formation in Formations)
                {
                    txt += formation.ToString();
                    if (Formations.IndexOf(formation) != Formations.Count - 1)
                        txt += " ، ";
                }
                return txt;
            }
        }

        [NonPersistent]
        public HoldingType Type
        {
            get
            {
                if(Items.Count > 1)
                    return HoldingType.MultiLevel;
                return HoldingType.SingleLevel;
            }
        }

        [NonPersistent]
        public string TypeText
        {
            get
            {
                return Type.ToDescription();
            }
        }

        [NonPersistent]
        public int TotalFee
        {
            get
            {
                var query = from item in Items select item.TuitionFee;
                return query.Sum();
            }
        }

        [NonPersistent]
        public string HoldingTypeText
        {
            get
            {
                if ((this as Section) != null)
                    return "کلاس";
                return "آزمون";
            }
        }

        public Formation GetConflictingFormation()
        {
            var query = from Formation f in DbContext.Entity<Formation>()
                        where (f.Holding.StartDate < FinishDate || f.Holding.FinishDate > StartDate)
                        select f;

            List<Formation> queryFormations = query.ToList();

            foreach (Formation formation in Formations)
            {
                foreach (Formation queryFormation in queryFormations)
                {
                    if(queryFormation.Place.Oid != formation.Place.Oid)
                        continue;
                    if (queryFormation.StartTimeInMinutes > formation.StartTimeInMinutes && queryFormation.StartTimeInMinutes < formation.FinishTimeInMinutes)
                        return queryFormation;
                    if (queryFormation.FinishTimeInMinutes > formation.StartTimeInMinutes && queryFormation.FinishTimeInMinutes < formation.FinishTimeInMinutes)
                        return queryFormation;
                }
            }
            return null;
        }

        public IQueryable<Participate> GetParticipates()
        {
            return from Participate participate in DbContext.Entity<Participate>()
                   where participate.Holding.Oid == Oid
                   select participate;
        }

        public void CheckCapacity()
        {
            if (RemainderCount <= 0)
                throw new Exception(string.Format("ظرفیت این {0} پر شده است. بنابراین ثبت نام در این {0} امکان پذیر نیست.", HoldingTypeText));
            
            int count = GetParticipates().Count();

            foreach (Formation formation in Formations)
            {
                if(formation.Place.CapacityType == CapacityType.Determined)
                {
                    if(count >= formation.Place.Capacity)
                        throw new Exception(string.Format("ظرفیت اتاق [{0}] تکمیل شده است. بنابراین ثبت نام در این {0} امکان پذیر نیست.", HoldingTypeText));
                }
            }
        }

        public static List<Holding> GetHolding(PersianDate startDate, PersianDate finishDate)
        {
            var query = from Formation f in DbContext.Entity<Formation>()
                        where f.Holding.StartDate <= finishDate && f.Holding.FinishDate > startDate
                        select f.Holding;
            return query.ToList();
        }

        public HoldingItem GetItem(Lesson lesson)
        {
            var query = from item in Items
                        where item.Lesson.Oid == lesson.Oid
                        select item;
            return query.FirstOrDefault();
        }
    }

    public enum HoldingType
    {
        [Description("تک درس")]
        SingleLevel,
        [Description("چند درس")]
        MultiLevel
    }
}