using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    [EventClass("درس/سطح")]
    public class Lesson : DbObject
    {
        public Lesson()
        {
            Code = 1;
            HoldingType = HoldingType.Lesson;
            Prerequisites = new List<Lesson>();
            ToolGroups = new List<EducationalToolGroup>();
        }

        [EventClassProperty("کد درس", "0")]
        public virtual int Code { get; set; }
        [EventClassProperty("نام درس", "0")]
        public virtual string Name { get; set; }
        public virtual HoldingType HoldingType { get; set; }
        public virtual bool InternetRegisterable { get; set; }
        [NoCascade]
        public virtual Major Major { get; set; }
        public virtual IList<Lesson> Prerequisites { get; set; }
        public virtual IList<EducationalToolGroup> ToolGroups { get; set; }
        public virtual IList<LessonHolding> LessonHoldings { get; set; }

        [NonPersistent]
        public virtual string HoldingTypeText
        {
            get
            {
                return HoldingType.ToDescription();
            }
        }

        public static int GetNextCode()
        {
            var query = from lesson in DbContext.Entity<Lesson>() orderby lesson.Code descending select lesson;
            Lesson lessonResult = query.FirstOrDefault();
            if (lessonResult == null)
                return 1;
            return lessonResult.Code + 1;
        }

        public virtual LessonHolding GetLessonHolding(EducationalPeriod period)
        {
            var query = from lessonHolding in LessonHoldings
                        where lessonHolding.Period.Id == period.Id 
                        select lessonHolding;
            return query.FirstOrDefault();
        }

        public virtual EvaluationProtocol GetEvaluationProtocol(EducationalPeriod period)
        {
            var query = from lessonHolding in LessonHoldings
                        where lessonHolding.Period.Id == period.Id
                        select lessonHolding;
            if (query.Count() > 0)
                return query.First().EvaluationProtocol;
            return null;
        }

        public virtual ResultProtocol GetResultProtocol(EducationalPeriod period)
        {
            var query = from lessonHolding in LessonHoldings
                        where lessonHolding.Period.Id == period.Id
                        && lessonHolding.ResultProtocol != null
                        select lessonHolding;
            if (query.Count() > 0)
                return query.First().ResultProtocol;
            return null;
        }

        public virtual PlacementProtocol GetPlacementProtocol(EducationalPeriod period)
        {
            var query = from lessonHolding in LessonHoldings
                        where lessonHolding.Period.Id == period.Id
                        select lessonHolding;
            if (query.Count() > 0)
                return query.First().PlacementProtocol;
            return null;
        }

        public override string ToString()
        {
            return Name;
        }

        public static Lesson FromId(int id)
        {
            return DbContext.FromId<Lesson>(id);
        }
    }

    public enum HoldingType
    {
        [EnumDescription("درس")]
        Lesson,
        [EnumDescription("آزمون")]
        Exam,
        [EnumDescription("بدون برگزاری مشخص")]
        NoHolding
    }

}