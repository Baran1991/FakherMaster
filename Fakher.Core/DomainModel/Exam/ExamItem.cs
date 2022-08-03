using System;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ExamItem : DbObject
    {
        public ExamItem()
        {
            Coefficient = 1;
            MarkType = ExamItemMarkType.Automatic;
        }

        public virtual string Name { get; set; }
        public virtual int StartIndex { get; set; }
        public virtual int EndIndex { get; set; }
        public virtual int Coefficient { get; set; }
        public virtual int StartFarakhanNo { get; set; }
        public virtual ExamItemMarkType MarkType { get; set; }
        public virtual float FixedMark { get; set; }
        [NoCascade]
        public virtual Lesson Lesson { get; set; }
        [NoCascade]
        public virtual ExamTrainingItem ExamTrainingItem { get; set; }
        [NoCascade]
        public virtual ExerciseTrainingItem ExerciseTrainingItem { get; set; }
        [NoCascade]
        public virtual LessonTrainingItem LessonTrainingItem { get; set; }
        [NoCascade]
        public virtual Exam Exam { get; set; }

        [NonPersistent]
        public virtual int QuestionCount
        {
            get { return EndIndex - StartIndex + 1; }
        }

        [NonPersistent]
        public virtual float Mark
        {
            get
            {
                if (MarkType == ExamItemMarkType.Fixed)
                    return FixedMark;

                float mark = (float)((QuestionCount * Exam.EvaluationItem.Value) / Exam.QuestionCount);
                return (float)Math.Round(mark, 2);
            }
        }

        public virtual ExamItem Clone()
        {
            ExamItem clone = Services.Clone<ExamItem>(this);
            clone.Lesson = Lesson;
            return clone;
        }

        #region Overrides of Object

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }

    public enum ExamItemMarkType
    {
        [EnumDescription("محاسبه خودکار")]
        Automatic,
        [EnumDescription("نمـره ثابت")]
        Fixed
    }
}