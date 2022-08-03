using System;
using System.Collections.Generic;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    [EventClass("ارائه درس در ترم")]
    public class LessonHolding : DbObject
    {
        [NoCascade]
        public virtual Lesson Lesson { get; set; }
        [NoCascade]
        public virtual EducationalPeriod Period { get; set; }
        [NoCascade]
        public virtual EvaluationProtocol EvaluationProtocol { get; set; }
        [NoCascade]
        public virtual ResultProtocol ResultProtocol { get; set; }
        [NoCascade]
        public virtual PlacementProtocol PlacementProtocol { get; set; }
        public virtual IList<Major> AllowedMajors { get; set; }
        public virtual IList<LessonEquivalence> LessonEquivalences { get; set; }

        public LessonHolding()
        {
            AllowedMajors = new List<Major>();
            LessonEquivalences = new List<LessonEquivalence>();
        }

        public virtual LessonHolding Clone()
        {
            LessonHolding clone = Services.Clone(this);
            clone.Lesson = Lesson;
            foreach (Major allowedMajor in AllowedMajors)
                clone.AllowedMajors.Add(allowedMajor);
            return clone;
        }
    }
}