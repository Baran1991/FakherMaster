using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class TrainingPlan : Protocol
    {
        public TrainingPlan()
        {
            Items = new List<TrainingItem>();
            IsGeneral = false;
            Type = TrainingPlanType.SectionTrainingPlan;
        }

        public virtual int Capacity { get; set; }
        public virtual bool IsGeneral { get; set; }
        public virtual TrainingPlanType Type { get; set; }
        [NoCascade]
        public virtual Major Major { get; set; }
        public virtual IList<TrainingItem> Items { get; set; }

        public virtual IList<TrainingItem> GetOrderedItems()
        {
            return Items.OrderBy(x => x.Position).ToList();
        }

        public virtual T CreateTrainingItem<T>() where T : TrainingItem, new()
        {
            T item = new T { Plan = this, Position = Items.Count };
            return item;
        }

//        public virtual SectionTrainingItem CreateSectionTrainingItem()
//        {
//            SectionTrainingItem item = new SectionTrainingItem { Plan = this, Position = Items.Count};
//            return item;
//        }
//
//        public virtual ExamTrainingItem CreateExamTrainingItem()
//        {
//            ExamTrainingItem item = new ExamTrainingItem { Plan = this, Position = Items.Count };
//            return item;
//        }
//
//        public virtual PostalTrainingItem CreatePostalTrainingItem()
//        {
//            PostalTrainingItem item = new PostalTrainingItem { Plan = this, Position = Items.Count };
//            return item;
//        }

        public virtual IQueryable<SectionTrainingItem> GetSectionItems()
        {
            var query = from item in Items
                        where item is SectionTrainingItem
                        select item as SectionTrainingItem;
            return query.AsQueryable();
        }
        public virtual IQueryable<LessonTrainingItem> GetLessonItems()
        {
            var query = from item in Items
                        where item is LessonTrainingItem
                        orderby item.Position
                        select item as LessonTrainingItem;
            return query.AsQueryable();
        }
        public virtual IQueryable<ExerciseTrainingItem> GetExerciseItems()
        {
            var query = from item in Items
                        where item is ExerciseTrainingItem
                        orderby item.Position
                        select item as ExerciseTrainingItem;
            return query.AsQueryable();
        }
        public virtual IQueryable<ExamTrainingItem> GetExamItems()
        {
            var query = from item in Items
                        where item is ExamTrainingItem
                        orderby item.Position
                        select item as ExamTrainingItem;
            return query.AsQueryable();
        }

        #region Static Methods

        public static IList<TrainingPlan> GetPlans(EducationalPeriod period)
        {
            var query = from plan in DbContext.Entity<TrainingPlan>()
                        where plan.Period.Id == period.Id 
                        select plan;
            return query.ToList();
        }

        public static IList<TrainingPlan> GetPlans(EducationalPeriod period, Major major, bool isGeneral)
        {
            var query = from plan in DbContext.Entity<TrainingPlan>()
                        where plan.Major.Id == major.Id
                              && plan.Period.Id == period.Id
                              && plan.IsGeneral == isGeneral
                        select plan;
            return query.ToList();
        }

        public static IList<TrainingPlan> GetPlans(EducationalPeriod period, Major major)
        {
            var query = from plan in DbContext.Entity<TrainingPlan>()
                        where plan.Major.Id == major.Id
                              && plan.Period.Id == period.Id
                        select plan;
            return query.ToList();
        } 
        
        public static IList<TrainingPlan> GetPlans(EducationalPeriod period, Major major, TrainingPlanType type)
        {
            var query = from plan in DbContext.Entity<TrainingPlan>()
                        where plan.Major.Id == major.Id
                              && plan.Period.Id == period.Id
                              && plan.Type == type
                        select plan;
            return query.ToList();
        }

        #endregion

        public virtual TrainingPlan Clone()
        {
            TrainingPlan plan = Services.Clone(this);
            plan.Major = Major;
            foreach (TrainingItem item in Items)
            {
                TrainingItem clone = item.Clone();
                clone.Plan = plan;
                plan.Items.Add(clone);
            }
            return plan;
        }

        public virtual ExamTrainingItem GetExamItem(Lesson lesson, EvaluationItem evaluationItem)
        {
            var query = from item in GetExamItems()
                        where item.Lesson.Id == lesson.Id
                              && item.EvaluationItem.Id == evaluationItem.Id
                        orderby item.Position
                        select item;
            return query.FirstOrDefault();
        }

    }

    public enum TrainingPlanType
    {
        [EnumDescription("برنامه آموزش کلاسی")]
        SectionTrainingPlan,
        [EnumDescription("برنامه آموزش آزمونها")]
        ExamTrainingPlan,
        [EnumDescription("برنامه آموزش مکاتبه ای")]
        PostalTrainingPlan,
    }
}