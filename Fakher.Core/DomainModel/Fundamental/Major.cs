using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Fakher.Core.Website;
using rApplicationEventFramework;

namespace Fakher.Core.DomainModel
{
    [EventClass("رشته")]
    public class Major : DbObject
    {
        public Major()
        {
            Code = 1;
            Lessons = new List<Lesson>();
            ToolGroups = new List<EducationalToolGroup>();
        }

        [EventClassProperty("کد رشته", null)]
        public virtual int Code { get; set; }
        [EventClassProperty("نام رشته", null)]
        public virtual string Name { get; set; }
        public virtual bool InternetRegisterable { get; set; }
        public virtual IList<Lesson> Lessons { get; set; }
        public virtual IList<EducationalToolGroup> ToolGroups { get; set; }
        [NoCascade]
        public virtual Department Department { get; set; }

        public virtual bool CanDelete()
        {
           
            if (DbContext.GetAll<Certificate>().Where(m => m.Major.Id == this.Id).Any())
                return false;
            if (DbContext.GetAll<EducationalCode>().Where(m => m.Major.Id == this.Id).Any())
                return false;
            if (DbContext.GetAll<EducationalToolGroup>().Where(m => m.Major.Id == this.Id).Any())
                return false;
            if (DbContext.GetAll<EnrollmentLicense>().Where(m => m.Major.Id == this.Id).Any())
                return false;
            if (DbContext.GetAll<Lesson>().Where(m => m.Major.Id == this.Id).Any())
                return false;
            if(DbContext.GetAll<MarkEntryLicense>().Where(m => m.Major.Id == this.Id).Any())
                return false;
            if (DbContext.GetAll<PreEnrollmentList>().Where(m => m.Major.Id == this.Id).Any())
                return false;
            if (DbContext.GetAll<Register>().Where(m => m.Major.Id == this.Id).Any())
                return false;
            if (DbContext.GetAll<ReserveList>().Where(m => m.Major.Id == this.Id).Any())
                return false;
            if (DbContext.GetAll<StudentConfiguration>().Where(m => m.Major.Id == this.Id).Any())
                return false;
            if (DbContext.GetAll<TuitionFee>().Where(m => m.Major.Id == this.Id).Any())
                return false;
            if (DbContext.GetAll<WebRegister>().Where(m => m.Major.Id == this.Id).Any())
                return false;
            return true;
        }
        public static int GetNextCode()
        {
            var query = from major in DbContext.Entity<Major>() orderby major.Code descending select major;
            Major majorResult = query.FirstOrDefault();
            if (majorResult == null)
                return 1;
            return majorResult.Code + 1;
        }

        public virtual IQueryable<Exam> GetExams(ExamType type)
        {
            var query = from exam in DbContext.Entity<Exam>()
                        where exam.Type == type && exam.Lesson.Major.Id == Id
                        select exam;
            return query;
        }

        public virtual IList<Exam> GetExams(EducationalPeriod period)
        {
            var query = from exam in DbContext.Entity<Exam>()
                        where exam.Period.Id == period.Id
                        && exam.Lesson.Major.Id == Id
                        select exam;
            return query.ToList();
        }

        public virtual IList<Exam> GetExams(EducationalPeriod period, EvaluationItem item)
        {
            var query = from exam in DbContext.Entity<Exam>()
                        where exam.Period.Id == period.Id
                        && exam.Lesson.Major.Id == Id
                        && exam.EvaluationItem.Id == item.Id
                        select exam;
            return query.ToList();
        }

        public virtual IList<Exam> GetExams(EducationalPeriod period, EvaluationItem item, ExamType type)
        {
            var query = from exam in GetExams(period, item)
                        where exam.Type == type
                        select exam;
            return query.ToList();
        }

        public virtual IList<EvaluationItem> GetExamEvaluationItems(EducationalPeriod period)
        {
            var query = from exam in GetExams(period)
                        group exam by exam.EvaluationItem into g
                        select g.Key;
            return query.Where(m=>m!=null).ToList();
        }

        public virtual IList<EvaluationItem> GetExamEvaluationItems(EducationalPeriod period, ExamType type)
        {
            var query = from exam in GetExams(period)
                        where exam.Type == type
                        group exam by exam.EvaluationItem into g
                        select g.Key;
            return query.ToList();
        }

        public virtual IQueryable<Exam> GetExams(EducationalPeriod period, Lesson lesson)
        {
            var query = from exam in GetExams(period)
                        from examItem in exam.Items
                        where examItem.Lesson.Id == lesson.Id
                        select exam;
            return query.AsQueryable();
        }        
        
        public virtual IQueryable<ExamTrainingItem> GetGeneralExamItems(EducationalPeriod period)
        {
            TrainingPlan trainingPlan = GetTrainingPlan(period);
            if (trainingPlan != null)
            {
                var query = from exam in trainingPlan.GetExamItems()
                            where exam.IsGeneral
                            select exam;
                return query.AsQueryable();
            }
            return null;
        }

        public virtual IQueryable<Lesson> GetLessons(EducationalPeriod period)
        {
            var query = from lessonHolding in period.LessonHoldings
                        from major in lessonHolding.AllowedMajors
                        where lessonHolding.Lesson.Major != null &&
                              lessonHolding.Lesson.Major.Id == Id
                              || major.Id == Id
                        select lessonHolding.Lesson;
            IQueryable<Lesson> query2 = query.Union(Lessons).AsQueryable();
            return query2;
        }
        public virtual IQueryable<Lesson> GetLessons(HoldingType lessonHoldingType)
        {
            var query = from lessonHolding in DbContext.Entity<LessonHolding>()
                        from major in lessonHolding.AllowedMajors
                        where lessonHolding.Lesson.Major != null &&
                              lessonHolding.Lesson.Major.Id == Id
                              || major.Id == Id
                        select lessonHolding.Lesson;
            IQueryable<Lesson> query2 = query.Union(Lessons).AsQueryable();
            return query.Where(x => x.HoldingType == lessonHoldingType);
        }

        public virtual IQueryable<Lesson> GetLessons(EducationalPeriod period, HoldingType lessonHoldingType)
        {
            var query2 = GetLessons(period);
//            var query = from lessonHolding in period.LessonHoldings
//                        from major in lessonHolding.AllowedMajors
//                        where lessonHolding.Lesson.Major != null &&
//                              lessonHolding.Lesson.Major.Id == Id
//                              || major.Id == Id
//                        select lessonHolding.Lesson;
//            IQueryable<Lesson> query2 = query.Union(Lessons).AsQueryable();
            return query2.Where(x=>x.HoldingType == lessonHoldingType);
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual TrainingPlan GetTrainingPlan(EducationalPeriod period)
        {
            IList<TrainingPlan> trainingPlans = TrainingPlan.GetPlans(period, this, true);
            if(trainingPlans.Count > 0)
                return trainingPlans[0];
            return null;
        }

        public static Major FromId(int id)
        {
            return DbContext.FromId<Major>(id);
        }

        public static IList<Major> GetInternetRegisterableMajors()
        {
            var query = from major in DbContext.Entity<Major>()
                        where major.InternetRegisterable
                        select major;
            return query.ToList();
        }

        public static IList<Major> GetAllMajors()
        {
            return DbContext.GetAllEntities<Major>();
        }
    }
}