using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class PaperBasedExamParticipate : ExamParticipate
    {
        [MaximumLength]
        public virtual string RawAnswers { get; set; }
        public virtual PersianDate CorrectionDate { get; set; }
        public virtual int CorrectionHour { get; set; }
        public virtual int CorrectionMinute { get; set; }

        [NonPersistent]
        public override ExamParticipateStatus Status
        {
            get
            {
                if (!string.IsNullOrEmpty(RawAnswers))
                    return ExamParticipateStatus.HasResult;
                return ExamParticipateStatus.UnKnown;
            }
        }

        [NonPersistent]
        public override string StatusText
        {
            get
            {
                if (RawAnswers != null && RawAnswers.Length < Exam.QuestionCount)
                    return "نقص تصحیح (نیاز به تصحیح مجدد)";
                if (Status == ExamParticipateStatus.HasResult && IsAbsent)
                    return "غائب";
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

        public virtual void SetAnswers(string answers)
        {
            RawAnswers = answers;
            CorrectionDate = PersianDate.Today;
            CorrectionHour = DateTime.Now.Hour;
            CorrectionMinute = DateTime.Now.Minute;
        }

        public override Bitmap GetAnswersheetView()
        {
            if (string.IsNullOrEmpty(RawAnswers))
                return null;
            Bitmap bitmap = null;
            AnswerSheetView view = new AnswerSheetView(true, false, 4, 120, 6);
            bitmap = view.GetBitmap(RawAnswers, ExamForm.Key);
            return bitmap;
        }

        public override bool IsAnswered(int questionNumber)
        {
            return Status == ExamParticipateStatus.HasResult && RawAnswers[questionNumber] != ExamForm.Exam.WhiteChar;
        }

        public override bool IsCorrect(int questionNumber)
        {
            return Status == ExamParticipateStatus.HasResult && RawAnswers[questionNumber] == ExamForm.Key[questionNumber];
        }

        public override bool IsWrong(int questionNumber)
        {
            return Status == ExamParticipateStatus.HasResult && RawAnswers[questionNumber] != ExamForm.Key[questionNumber];
        }

        public override float CalculateMark()
        {
//            if (RawAnswers.Length < Exam.QuestionCount)
//                return -99999;
            return ExamForm.CalculateMark(RawAnswers) + AdditiveMark;
        }

        public override float CalculateMarkOf20()
        {
            return ExamForm.CalculateMarkOf20(RawAnswers) + AdditiveMark;
        }

        public override void EnsureExamItemMarkPreCalculation()
        {
            if (mExamItemMarks == null)
            {
                mExamItemMarks = new Dictionary<ExamItem, float>();
                foreach (ExamItem examItem in ExamForm.Exam.Items)
                {
                    float mark = ExamForm.CalculateMark(examItem, RawAnswers);
                    mExamItemMarks.Add(examItem, mark);
                }
            }
        }

        public override float CalculateMark(ExamItem examItem)
        {
            if (AdditiveMark == 0)
            {
                return ExamForm.CalculateMark(examItem, RawAnswers);
            }
            else
            {
                EnsureExamItemMarkPreCalculation();
                List<ExamItem> lowerExamItems = new List<ExamItem>();
                foreach (KeyValuePair<ExamItem, float> examItemMark in mExamItemMarks)
                    if (examItemMark.Value < examItemMark.Key.Mark)
                        lowerExamItems.Add(examItemMark.Key);


                float mark = mExamItemMarks[examItem];
                if (lowerExamItems.Contains(examItem))
                {
                    mark += (AdditiveMark / lowerExamItems.Count);
                }

                return mark;
            }
        }

        public override float CalculateMarkOf20(ExamItem examItem)
        {
            float mark = ExamForm.CalculateMarkOf20(examItem, RawAnswers);
            return mark;
        }

        public override float CalculatePercent(ExamItem examItem)
        {
            return ExamForm.CalculatePercent(examItem, RawAnswers);
        }

        public new static PaperBasedExamParticipate GetExamParticipate(long code)
        {
            var query = from participate in DbContext.Entity<PaperBasedExamParticipate>()
                        where participate.Code == code
                        select participate;
            return query.FirstOrDefault();
        }
    }
}