using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class StudentConfiguration : DbObject
    {
        [NoCascade]
        public virtual Student Student { get; set; }
        [NoCascade]
        public virtual Major Major { get; set; }
        [NoCascade]
        public virtual EducationalPeriod EducationalPeriod { get; set; }
        public virtual IList<EnrollableLesson> EnrollableLessons { get; set; }

        public StudentConfiguration()
        {
            EnrollableLessons = new List<EnrollableLesson>();
        }

        public virtual void AddEnrollableLesson(EnrollableLesson enrollableLesson)
        {
            enrollableLesson.Configuration = this;
            EnrollableLessons.Add(enrollableLesson);
        }

        public virtual void CalculateEnrollableLessons()
        {
            List<Lesson> lessons = Student.GetEnrollableLessons(Major, EducationalPeriod, true, true).ToList();
            foreach (Lesson lesson in lessons)
            {
                EnrollableLesson enrollableLesson = new EnrollableLesson();
                enrollableLesson.Lesson = lesson;
                AddEnrollableLesson(enrollableLesson);
            }
        }
    }
}