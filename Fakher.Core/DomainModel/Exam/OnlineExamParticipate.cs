using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;
using System.Drawing;

namespace Fakher.Core.DomainModel
{
    public class OnlineExamParticipate : ExamParticipate
    {
        [MaximumLength]
        public virtual string RawAnswers { get; set; }
        public virtual PersianDate StartDate { get; set; }
        public virtual PersianDate EndDate { get; set; }
        public virtual PersianDate ConfirmDate { get; set; }
        public virtual bool Confirmed { get; set; }
        public virtual int StartHour { get; set; }
        public virtual int StartMinute { get; set; }
        public virtual int StartSecond { get; set; }
        public virtual int EndHour { get; set; }
        public virtual int EndMinute { get; set; }
        public virtual int EndSecond { get; set; }
        public virtual int ConfirmHour { get; set; }
        public virtual int ConfirmMinute { get; set; }
        public virtual int ConfirmSecond { get; set; }
        public virtual IList<ExamParticipateAnswer> Answers { get; set; }
        public virtual string IP { get; set; }
        [MaximumLength]
        public virtual string UserAgent { get; set; }

        public OnlineExamParticipate()
        {
            Answers = new List<ExamParticipateAnswer>();
            Confirmed = false;
        }

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
                if(Confirmed)
                    return "ثبت آزمـون";
                if (IsFinished)
                    return "پایان آزمـون";
                if (IsStarted)
                    return "شروع آزمـون";
                return Status.ToDescription();
            }
        }

        [NonPersistent]
        public override bool IsPeresent
        {
            get
            {
                return !string.IsNullOrEmpty(RawAnswers);
            }
        }

        [NonPersistent]
        public override bool IsAbsent
        {
            get
            {
                return string.IsNullOrEmpty(RawAnswers);
            }
        }

        [NonPersistent]
        public virtual OnlineExamHolding OnlineExamHolding
        {
            get { return ExamForm.Exam.ExamHolding as OnlineExamHolding; }
        }

        /// <summary>
        /// مدت زمان پاسخگویی به سئوالات توسط داوطلب - زمان پایان آزمون داوطلب باید ثبت شده باشد
        /// </summary>
        [NonPersistent]
        public virtual TimeSpan Duration
        {
            get
            {
                DateTime startDateTime = StartDate.ToSystemDateTime();
                DateTime endDateTime = EndDate.ToSystemDateTime();

                TimeSpan elapsedTimeSpan = new DateTime(endDateTime.Year, endDateTime.Month, endDateTime.Day, EndHour, EndMinute, EndSecond)
                    - new DateTime(startDateTime.Year, startDateTime.Month, startDateTime.Day, StartHour, StartMinute, StartSecond);
                return elapsedTimeSpan;
            }
        }

        /// <summary>
        /// مدت زمان باقیمانده تا پایان زمان آزمون یا پایان برگزاری آزمون
        /// </summary>
        [NonPersistent]
        public virtual TimeSpan RemainingDuration
        {
            get
            {
//                DateTime dateTime = StartDate.ToSystemDateTime();
//                TimeSpan elapsedTimeSpan = DateTime.Now - new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, StartHour, StartMinute, StartSecond);

                TimeSpan elapsedTimeSpan = DateTime.Now - StartDateTime;
                TimeSpan endDurationTimeSpan = TimeSpan.FromMinutes(OnlineExamHolding.Duration) - elapsedTimeSpan;

                if (OnlineExamHolding.HasEnd)
                {
                    TimeSpan endHoldingTimeSpan = OnlineExamHolding.EndDateTime - DateTime.Now;
                    if (endHoldingTimeSpan <= endDurationTimeSpan)
                        return endHoldingTimeSpan;
                    else
                        return endDurationTimeSpan;
                }
                return endDurationTimeSpan;
            }
        }

        [NonPersistent]
        public virtual bool IsStarted
        {
            get { return StartDate != null; }
        }

        [NonPersistent]
        public virtual bool IsFinished
        {
            get { return EndDate != null; }
        }

        [NonPersistent]
        public virtual DateTime StartDateTime
        {
            get
            {
                DateTime systemDateTime = StartDate.ToSystemDateTime();
                return new DateTime(systemDateTime.Year, systemDateTime.Month, systemDateTime.Day, StartHour, StartMinute, StartSecond);
            }
        }

        public virtual void PrepareForStart()
        {
            EndDate = null;
            EndHour = 0;
            EndMinute = 0;
            EndSecond = 0;
        }

        public virtual bool HasRemainingDuration()
        {
            if (OnlineExamHolding.HasDuration)
            {
                if (RemainingDuration <= TimeSpan.FromMinutes(0))
                    return false;
            }
            return true;
        }

        public virtual void StartExam(string ip, string userAgent)
        {
            DateTime now = DateTime.Now;

            StartDate = PersianDate.Today;
            StartHour = now.Hour;
            StartMinute = now.Minute;
            StartSecond = now.Second;

            IP = ip;
            UserAgent = userAgent;
        }

        public virtual void EndExam()
        {
            DateTime now = DateTime.Now;

            EndDate = PersianDate.Today;
            EndHour = now.Hour;
            EndMinute = now.Minute;
            EndSecond = now.Second;
        }

        public virtual void Confirm()
        {
            Confirmed = true;

            DateTime now = DateTime.Now;
            ConfirmDate = PersianDate.Today;
            ConfirmHour = now.Hour;
            ConfirmMinute = now.Minute;
            ConfirmSecond = now.Second;
        }

        public virtual void SetAnswers(Dictionary<int, int> testAnswers, Dictionary<int, string> essayAnswers)
        {
            string answers = "";
            for (int i = 0; i < ExamForm.Exam.QuestionCount; i++)
            {
                if (testAnswers.ContainsKey(i + 1))
                    answers += testAnswers[i + 1];
                else
                    answers += ExamForm.Exam.WhiteChar;
            }

            RawAnswers = answers;

//            foreach (KeyValuePair<int, string> essayAnswer in essayAnswers)
//            {
//            }
        }

        public virtual Dictionary<int, int> GetTestAnswersDictionary()
        {
            Dictionary<int, int> testAnswers = new Dictionary<int, int>();

            if(!string.IsNullOrEmpty(RawAnswers))
                for (int i = 0; i < RawAnswers.Length; i++)
                    testAnswers.Add(i + 1, int.Parse(RawAnswers[i] + ""));

            return testAnswers;
        }
        
        public virtual Dictionary<int, string> GetEssayAnswersDictionary()
        {
            Dictionary<int, string> essayAnswers = new Dictionary<int, string>();
            return essayAnswers;
        }

        public override bool IsAnswered(int questionNumber)
        {
            return Status == ExamParticipateStatus.HasResult 
                && RawAnswers[questionNumber] != ExamForm.Exam.WhiteChar;
        }

        public override bool IsCorrect(int questionNumber)
        {
            return Status == ExamParticipateStatus.HasResult 
                && RawAnswers[questionNumber] == ExamForm.Key[questionNumber];
        }

        public override bool IsWrong(int questionNumber)
        {
            return Status == ExamParticipateStatus.HasResult 
                && RawAnswers[questionNumber] != ExamForm.Key[questionNumber];
        }

        public override float CalculateMark()
        {
            return ExamForm.CalculateMark(RawAnswers) + AdditiveMark;
        }

        public override float CalculateMark(ExamItem examItem)
        {
            return ExamForm.CalculateMark(examItem, RawAnswers);
        }

        public override float CalculateMarkOf20(ExamItem examItem)
        {
            return ExamForm.CalculateMarkOf20(examItem, RawAnswers);
        }

        public override float CalculatePercent(ExamItem examItem)
        {
            return ExamForm.CalculatePercent(examItem, RawAnswers);
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

        public virtual bool CanParticipation(PersianDate date, int hour, int minute)
        {
            if (ExclusiveParticipation && !Confirmed)
                return true;

            OnlineExamHolding examHolding = ExamForm.Exam.ExamHolding as OnlineExamHolding;

            DateTime nowSystemDateTime = date.ToSystemDateTime();
            DateTime startSystemDateTime = examHolding.StartDate.ToSystemDateTime();
            DateTime endSystemDateTime = examHolding.EndDate.ToSystemDateTime();

            DateTime now = new DateTime(nowSystemDateTime.Year, nowSystemDateTime.Month, nowSystemDateTime.Day, hour, minute, 0);
            DateTime startDateTime = new DateTime(startSystemDateTime.Year, startSystemDateTime.Month, startSystemDateTime.Day, examHolding.StartHour, examHolding.StartMinute, 0);
            DateTime endDateTime = new DateTime(endSystemDateTime.Year, endSystemDateTime.Month, endSystemDateTime.Day, examHolding.EndHour, examHolding.EndMinute, 0);

            if (examHolding.HasEnd)
                return now >= startDateTime && now <= endDateTime;

            return now >= startDateTime;
        }

        public static OnlineExamParticipate GetExamParticipate(long code)
        {
            var query = from participate in DbContext.Entity<OnlineExamParticipate>()
                        where participate.Code == code
                        select participate;
            return query.FirstOrDefault();
        }
    }
}