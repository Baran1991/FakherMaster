using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class TrainingItem : DbObject
    {
        public TrainingItem()
        {
            TuitionFees = new List<TuitionFee>();
            Enrollments = new List<Enrollment>();
        }
        public virtual int Capacity { get; set; }
        public virtual int Position { get; set; }
        [NoCascade]
        public virtual Lesson Lesson { get; set; }
        [NoCascade]
        public virtual TrainingPlan Plan { get; set; }
        public virtual IList<TuitionFee> TuitionFees { get; set; }
        public virtual IList<Enrollment> Enrollments { get; set; }

        [NonPersistent]
        public virtual string Text
        {
            get
            {
                if (this is SectionTrainingItem)
                    return (this as SectionTrainingItem).Lesson.Name;
                if (this is ExamTrainingItem)
                    return (this as ExamTrainingItem).Name;
                if (this is ExerciseTrainingItem)
                    return (this as ExerciseTrainingItem).Name;
                if (this is LessonTrainingItem)
                    return (this as LessonTrainingItem).Name;
                return "نامشخص";
            }
        }

        [NonPersistent]
        public virtual int RemainderCount
        {
            get { return Capacity - EnrollmentCount; }
        }

        [NonPersistent]
        public virtual int EnrollmentCount
        {
            get { return GetEnrollments().Count(); }
        }

        public virtual TrainingItem Clone()
        {
            throw new NotImplementedException();
        }

        public virtual TuitionFee GetTuitionFee(Major major, RegisterParticipation participation)
        {
            if (TuitionFees.Count == 0)
                return null;
            var query = from tuition in TuitionFees
                        where tuition.Major.Id == major.Id
                        && tuition.RegisterParticipation == participation
                        select tuition;
            return query.FirstOrDefault();
        }

        public override string ToString()
        {
            return Text;
        }

        public virtual IEnumerable<Enrollment> GetEnrollments()
        {
            return Enrollments.Where(x => x.Register != null && x.Register.Type != RegisterType.FullQuited);
        }

        public virtual IQueryable<Register> GetEnrolledRegisters()
        {
            var query = from enrollment in DbContext.Entity<Enrollment>()
                        where enrollment.TrainingItem != null
                              && enrollment.Register != null
                              && enrollment.TrainingItem.Id == Id
                              && enrollment.Register.Type != RegisterType.FullQuited
                        group enrollment by enrollment.Register
                        into g
                        select g.Key;
            return query;
        }
    }
}