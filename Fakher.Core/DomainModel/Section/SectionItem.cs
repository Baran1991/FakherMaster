using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls.WebParts;
using DataAccessLayer;
using NHibernate;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class SectionItem : DbObject
    {
        private Dictionary<Participate, float> mParticipateTotalMarks;
        private Rank mRank;

        [NoCascade]
        public virtual SectionTrainingItem Item { get; set; }
        [NoCascade]
        public virtual Section Section { get; set; }
        public virtual IList<Absence> Absences { get; set; }
        public virtual IList<Replacement> Replacements { get; set; }
        public virtual IList<Makeup> Makeups { get; set; }

        public SectionItem()
        {
            mParticipateTotalMarks = new Dictionary<Participate, float>();
            mRank = new Rank();
            Absences = new List<Absence>();
            Replacements = new List<Replacement>();
            Makeups = new List<Makeup>();
        }

        [NonPersistent]
        public virtual int StartSession
        {
            get { return Item.StartSession; }
            //            set { Item.StartIndex = value; }
        }
        [NonPersistent]
        public virtual int EndSession
        {
            get { return Item.EndSession; }
        }
        [NonPersistent]
        public virtual Lesson Lesson
        {
            get { return Item.Lesson; }
        }
        [NonPersistent]
        public virtual int SessionCount
        {
            get { return EndSession - StartSession + 1; }
        }
        [NonPersistent]
        public virtual int RemainderCount
        {
            get
            {
                return Section.Capacity - ParticipateCount;
            }
        }
        [NonPersistent]
        public virtual int ParticipateCount
        {
            get
            {
                try
                {
                    return GetParticipates().Count();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return 0;
            }
        }
        [NonPersistent]
        public virtual int BannedParticipateCount
        {
            get
            {
                return GetBannedParticipates().Count();
            }
        }

        #region Static Members

        public static IList<SectionItem> GetSectionItems(EducationalPeriod period)
        {
            var query = from item in DbContext.Entity<SectionItem>()
                        where item.Section.Period.Id == period.Id
                        orderby item.Section.GroupNumber descending
                        select item;
            List<SectionItem> sectionItems = query.ToList();
            return sectionItems;
        }

        public static IList<SectionItem> GetSectionItems(EducationalPeriod period, Major major)
        {
            List<SectionItem> sectionItems = new List<SectionItem>();
            foreach (Lesson lesson in major.GetLessons(period, HoldingType.Lesson))
            {
                LessonHolding lessonHolding = lesson.GetLessonHolding(period);
                if (lessonHolding == null || !lessonHolding.AllowedMajors.Contains(major))
                {
                    continue;
                    //                    return new List<SectionItem>();
                }
                List<SectionItem> items = GetSectionItems(period, lesson);
                sectionItems.AddRange(items);
            }

            return sectionItems;
        }

        public static IList<SectionItem> GetSectionItems(EducationalPeriod period, Major major, Lesson lesson)
        {
            LessonHolding lessonHolding = lesson.GetLessonHolding(period);
            if (lessonHolding == null || !lessonHolding.AllowedMajors.Contains(major))
                return new List<SectionItem>();

            return GetSectionItems(period, lesson);
        }

        public static List<SectionItem> GetSectionItems(EducationalPeriod period, Lesson lesson)
        {
            var query = from item in DbContext.Entity<SectionItem>()
                        where item.Item.Lesson.Id == lesson.Id
                              && item.Section.Period.Id == period.Id
                        orderby item.Section.GroupNumber descending
                        select item;
            List<SectionItem> sectionItems = query.ToList();
            return sectionItems;
            //            try
            //            {
            //            }
            //            catch (Exception e)
            //            {
            //                Console.WriteLine(e);
            //            }
            //            throw new Exception();
        }
   

        #endregion

        public virtual long GetTuitionFee(Major major, RegisterParticipation participation)
        {
            TuitionFee tuitionFee = Item.GetTuitionFee(major, participation);
            if (tuitionFee != null)
                return tuitionFee.Fee;
            return 0;
        }

        public virtual bool HasIntersect(SectionItem item)
        {
            if (StartSession >= item.StartSession && StartSession <= item.EndSession)
                return true;
            if (EndSession <= item.EndSession && EndSession >= item.StartSession)
                return true;
            return false;
        }

        public virtual SectionItem Clone()
        {
            return Services.Clone<SectionItem>(this);
        }

        public override string ToString()
        {
            return Lesson.Name + " - " + Section.FarsiName;
        }

        public virtual IList<Participate> GetAllParticipates()
        {
            IQueryable<Participate> query = GetAllParticipatesQuery();
            return query.ToList();
        }
        public virtual IList<Participate> GetAllParticipatesWithAllStatus()
        {
          
            var query = from participate in DbContext.Entity<Participate>() // Participates //DbContext.Entity<Participate>()
                        where participate.SectionItem != null
                              && participate.SectionItem.Id == Id
                             
                              && participate.Register != null
                              
                        select participate;
            return query.ToList();
        }
        private IQueryable<Participate> GetAllParticipatesQuery()
        {
            //            IQuery pQuery = DbContext.CurrentSession.CreateFilter(Participates, string.Empty);

            //DbContext.Entity<Participate> ro be Participates taghir dadam vase performance
            var query = from participate in DbContext.Entity<Participate>() // Participates //DbContext.Entity<Participate>()
                        where participate.SectionItem != null
                              && participate.SectionItem.Id == Id
                              && participate.Quit == null
                              && participate.Transition==null
                              && participate.Register != null
                              && participate.Register.Type == RegisterType.Participation
                        select participate;
            return query.AsQueryable();
        }

        public virtual IList<Participate> GetParticipates()
        {
            return GetAllParticipates().Except(GetBannedParticipates()).ToList();
            //            return GetAllParticipatesQuery().Except(GetBannedParticipates()).ToList();
        }

        public virtual IQueryable<Participate> GetParticipates(ResultLabel label)
        {
            var query = from participate in GetParticipates()
                        where participate.GetResultLabel().Id == label.Id
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<Participate> GetBannedParticipates()
        {
            var query = from ban in GetBans(BanStatus.Active)
                        select ban.Participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<Participate> GetDebtorParticipates()
        {
            var query = from participate in GetAllParticipates()
                        where participate.Register.DebtorSign == 1
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<Participate> GetQuitedParticipates()
        {
            var query = from participate in GetAllParticipates()
                        where participate.Register.FullQuitedSign == 1
                        select participate;
            return query.AsQueryable();
        }
      
        public virtual IQueryable<Ban> GetBans(BanStatus status)
        {
            // Changed GetAllParticipatesQuery() to GetAllParticipates()
            // because of DbContext.Entity<Participate>() in GetAllParticipatesQuery()
            var query = from participate in GetAllParticipates()
                        from ban in participate.GetBans(status)
                        select ban;
            return query.AsQueryable();
        }

        public virtual IQueryable<Participate> GetNextEnrollmentBannedParticipates()
        {
            var query = from participate in GetAllParticipates()
                        where participate.Register.NextEnrollmentBanned 
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<Participate> GetFarsiOrderedParticipates()
        {
            IList<Participate> participates = GetParticipates();
            var query = from participate in participates
                        orderby participate.Register.Student.FarsiLastName
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<Participate> GetEnglishOrderedParticipates()
        {
            IList<Participate> participates = GetParticipates();
            var query = from participate in participates
                        orderby participate.Register.Student.EnglishLastName
                        select participate;
            return query.AsQueryable();
        }

        public virtual List<Absence> GetAbsences()
        {
            var query = from absence in DbContext.Entity<Absence>()
                        where absence.SectionItem.Id == Id && absence.SectionItem.Item.Lesson.Id == Lesson.Id
                        select absence;
            return query.ToList();
        }

        public virtual List<Absence> GetAbsences(PersianDate date)
        {
            var query = from absence in DbContext.Entity<Absence>()
                        where absence.SectionItem.Id == Id
                              && absence.Date == date
                        select absence;
            return query.ToList();
        }

        public virtual void CheckCapacity()
        {
            if (RemainderCount <= 0)
                throw new Exception(string.Format("ظرفیت گروه {0} در درس/سطح {1} پر شده است. بنابراین ثبت نام در این کلاس امکان پذیر نیست.", Section.GroupNumber, Lesson.Name));

            int count = GetParticipates().Count();

            foreach (Formation formation in Section.Formations)
            {
                if (formation.Place.CapacityType == CapacityType.Determined)
                {
                    if (count >= formation.Place.Capacity)
                        throw new Exception(string.Format("ظرفیت اتاق [{0}] تکمیل شده است. بنابراین ثبت نام در این کلاس امکان پذیر نیست.", formation.Place.Name));
                }
            }
        }

        public virtual void AddMakeup(Makeup makeup)
        {
            makeup.SectionItem = this;
            Makeups.Add(makeup);
        }

        public virtual void AddReplacement(Replacement replacement)
        {
            replacement.SectionItem = this;
            Replacements.Add(replacement);
        }

        public virtual void EnsurePreCalculation()
        {
            if (mParticipateTotalMarks.Count == 0)
            {
                mRank = new Rank();
                mParticipateTotalMarks.Clear();
                foreach (Participate participate in GetAllParticipates())
                {
                    float mark = participate.CalculateMark();
                    mParticipateTotalMarks.Add(participate, mark);
                    mRank.AddPoint(mark);
                }
                mRank.Calculate();
            }
        }

        public virtual int CalculateRank(Participate unRankedParticipate)
        {
            EnsurePreCalculation();
            //            if (mParticipateTotalMarks.Count == 0)
            //            {
            //                foreach (Participate participate in GetParticipates())
            //                    mParticipateTotalMarks.Add(participate, participate.CalculateMark());
            //            }

            float totalMark = mParticipateTotalMarks[unRankedParticipate];
            return mRank.GetRank(totalMark);

            //            int count = mRankQuery.Count();
            //            for (int i = 0; i < count; i++)
            //            {
            //                float mark = mRankQuery.ElementAt(i);
            //                if (mark == totalMark)
            //                    return i + 1;
            //            }
            //            return -1;
        }

        public virtual float CalculatePassPercent()
        {
            IList<Participate> participates = GetParticipates();

            var query1 = from participate in participates
                         where participate.CanCalculateMark()
                         select participate;
            var query2 = from participate in query1
                         where participate.IsPassed()
                         select participate;
            return ((float)query2.Count() / query1.Count()) * 100;
        }

        public static SectionItem FromId(int id)
        {
            return DbContext.FromId<SectionItem>(id);
        }
    }
}