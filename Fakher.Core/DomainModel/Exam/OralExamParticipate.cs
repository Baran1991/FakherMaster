using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class OralExamParticipate : ExamParticipate
    {
        /// <summary>
        /// Manual Entered Mark like oral exam marks
        /// </summary>
        public virtual IList<OralMark> OralMarks { get; set; }

        public OralExamParticipate()
        {
            OralMarks = new List<OralMark>();
        }

        [NonPersistent]
        public override ExamParticipateStatus Status
        {
            get
            {
                if (OralMarks.Count > 0)
                    return ExamParticipateStatus.HasResult;
                if(!string.IsNullOrEmpty(Comment))
                    return ExamParticipateStatus.HasResult;
                return ExamParticipateStatus.UnKnown;
            }
        }

        [NonPersistent]
        public override string StatusText
        {
            get
            {
                if (Status == ExamParticipateStatus.HasResult)
                    return "شرکت کرده";
                return Status.ToDescription();
            }
        }

        [NonPersistent]
        public override bool IsPeresent
        {
            get
            {
                for (int i = 0; i < ExamForm.Exam.QuestionCount; i++)
                    if (IsAnswered(i))
                        return true;
                return false;
            }
        }

        [NonPersistent]
        public override bool IsAbsent
        {
            get
            {
                for (int i = 0; i < ExamForm.Exam.QuestionCount; i++)
                    if (IsAnswered(i))
                        return false;
                return true;
            }
        }

        public virtual OralMark CreateOralMark()
        {
            OralMark mark = new OralMark { Participate = this };
            return mark;
        }

        public virtual void AddOralMark(OralMark mark)
        {
            mark.Participate = this;
            OralMarks.Add(mark);
        }

        public override float CalculateMark()
        {
            if (OralMarks.Count == 0)
                return 0;
            return (OralMarks.Select(x => x.Value).Average()) + AdditiveMark;
        }

        public override float CalculateMark(ExamItem examItem)
        {
            throw new Exception("Oral Exam Not Supported!");
        }

        public override float CalculateMarkOf20(ExamItem examItem)
        {
            throw new Exception("Oral Exam Not Supported!");
        }

        public override float CalculatePercent(ExamItem examItem)
        {
            throw new Exception("Oral Exam Not Supported!");
        }

        public static OralExamParticipate GetExamParticipate(long code)
        {
            var query = from participate in DbContext.Entity<OralExamParticipate>()
                        where participate.Code == code
                        select participate;
            return query.FirstOrDefault();
        }

    }
}