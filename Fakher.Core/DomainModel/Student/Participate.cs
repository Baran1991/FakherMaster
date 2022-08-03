using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    [EventClass("کلاس بندی")]
    public class Participate : DbObject
    {
        public Participate()
        {
            Date = PersianDate.Today;
            EnrollmentHour = DateTime.Now.Hour;
            EnrollmentMinute = DateTime.Now.Minute;
            IsSpecialCase = false;
            Marks = new List<Mark>();
            ActivityMarks = new List<ActivityMark>();
            Bans = new List<Ban>();

        }

        [EventClassProperty("کلاس ثبت نامی", null)]
        [NoCascade]
        public virtual SectionItem SectionItem { get; set; }
        public virtual FinancialItem FinancialItem { get; set; }
        [EventClassProperty("نام دانشجو", "")]
        [NoCascade]
        public virtual Register Register { get; set; }
        [EventClassProperty("انصراف", null)]
        public virtual Quit Quit { get; set; }
        [EventClassProperty("انتقال", null)]
        public virtual Transition Transition { get; set; }
        public virtual Enrollment Enrollment { get; set; }
        public virtual bool IsSpecialCase { get; set; }
        /// <summary>
        /// تاریخ ثبت نام
        /// </summary>
        public virtual PersianDate Date { get; set; }
        public virtual bool InternetRegisteration { get; set; }
        public virtual bool EnrollmentConfirmed { get; set; }
        public virtual int EnrollmentHour { get; set; }
        public virtual int EnrollmentMinute { get; set; }
        public virtual string ResultLabel { get; set; }
        public virtual IList<Mark> Marks { get; set; }
        public virtual IList<ActivityMark> ActivityMarks { get; set; }
        [Attendant]
        public virtual IList<Ban> Bans { get; set; }


        [NonPersistent]
        public virtual string EnrollmentTime
        {
            get { return EnrollmentHour.ToString("D2") + ":" + EnrollmentMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                EnrollmentHour = Convert.ToInt32(timeItems[0]);
                EnrollmentMinute = Convert.ToInt32(timeItems[1]);
            }
        }

        [NonPersistent]
        public virtual string EnrollmentTypeText
        {
            get
            {
                string txt = "حضوری";
                if (InternetRegisteration)
                    txt = "اینترنتی";
                if (IsSpecialCase)
                    txt += " - موارد خاص";
                return txt;
            }
        }

        [NonPersistent]
        public virtual ParticipateStatus Status
        {
            get
            {
                if (Quit != null)
                    return ParticipateStatus.Quited;
                if (GetBans(BanStatus.Active).Count() > 0)
                    return ParticipateStatus.Banned;
                return ParticipateStatus.Participating;
                //                return Quit != null ? ParticipateStatus.Quited : ParticipateStatus.Participating;
            }
        }

        [NonPersistent]
        public virtual string StatusText
        {
            get { return Status.ToDescription(); }
        }

        [NonPersistent]
        public virtual long TuitionFee
        {
            get
            {
                return SectionItem.GetTuitionFee(Register.Major, Register.GetRegisterParticipation(true, false));
                //                return SectionItem.GetTuitionFee(Register.Major, Register.RegisterParticipation);
            }
        }

        [NonPersistent]
        public virtual int AbsencesCount
        {
            get { return GetAbsences().Count(); }
        }
        [NonPersistent]
        public virtual int DelaysCount
        {
            get { return GetDelays().Count(); }
        }

        [NonPersistent]
        public virtual int RejectedAbsencesCount
        {
            get { return GetAbsences().Where(x => x.Status == AbsenceStatus.Rejected).Count(); }
        }

        [NonPersistent]
        public virtual int AcceptedAbsencesCount
        {
            get { return GetAbsences().Where(x => x.Status == AbsenceStatus.Accepted).Count(); }
        }

        [NonPersistent]
        public virtual String BanText
        {
            get
            {
                var ban = GetBans(BanStatus.Active).FirstOrDefault(x => x.Status == BanStatus.Active) as Ban;
                if (ban != null)
                    return ban.Reason;
                return "";
            }
        }

        [NonPersistent]
        public virtual String NextEnrollmentBanText
        {
            get
            {
                var nextEnrollmentBanReason = this.Register.NextEnrollmentBanReason;
                if (nextEnrollmentBanReason != null)
                    return nextEnrollmentBanReason;
                return "";
            }
        }

        public override string ToString()
        {
            string txt = "";
            if (!string.IsNullOrEmpty(SectionItem.Section.MasterItemText))
                txt += SectionItem.Section.MasterItemText + " - ";
            txt += SectionItem.Section.Name;
            return txt;
        }

        public virtual Absence CreateAbsence()
        {
            Absence absence = new Absence
                                  {
                                      SectionItem = SectionItem,
                                      Person = Register.Student,
                                  };
            return absence;
        }

        public virtual Absence CreateAbsence(PersianDate date, string reason)
        {
            Absence absence = CreateAbsence();
            absence.Date = date;
            absence.Reason = reason;
            return absence;
        }
       
        public virtual bool IsAbsent(PersianDate date)
        {
            var query = from Absence absence in Register.Student.Absences
                        where absence.SectionItem != null
                              && absence.SectionItem.Id == SectionItem.Id
                              && absence.Date == date
                        select date;
            return query.Count() > 0;
        }

        public virtual IQueryable<Absence> GetAbsences()
        {
            var query = from Absence absence in Register.Student.Absences
                        where absence.SectionItem.Id == SectionItem.Id
                        select absence;
            return query.AsQueryable();
        }

        public virtual Delay CreateDelay()
        {
            Delay delay = new Delay
            {
                SectionItem = SectionItem,
                Person = Register.Student,
            };
            return delay;
        }

        public virtual Delay CreateDelay(PersianDate date)
        {
            Delay delay = CreateDelay();
            delay.Date = date;
           
            return delay;
        }
        public virtual IQueryable<Delay> GetDelays()
        {
            var query = from Delay delay in Register.Student.Delays
                        where delay.SectionItem.Id == SectionItem.Id
                        select delay;
            return query.AsQueryable();
        }
        public virtual bool CanCalculateMark()
        {
            if (SectionItem.Lesson.GetEvaluationProtocol(Register.Period) == null)
                return false;
            if (SectionItem.Lesson.GetResultProtocol(Register.Period) == null)
                return false;
            foreach (EvaluationItem item in SectionItem.Lesson.GetEvaluationProtocol(Register.Period).GetAllItems())
            {
                if (!CanCalculateMark(item))
                    return false;
            }
            return true;
        }

        public virtual float CalculateMark()
        {
            if (SectionItem.Lesson.GetEvaluationProtocol(Register.Period) == null)
                throw new Exception(string.Format("آیین نامه ارزشیابی درس {0} تعریف نشده است.", SectionItem.Lesson.Name));
            if (SectionItem.Lesson.GetResultProtocol(Register.Period) == null)
                throw new Exception(string.Format("آیین نامه نمره دهی درس {0} تعریف نشده است.", SectionItem.Lesson.Name));

            Dictionary<EvaluationItem, float> marks = new Dictionary<EvaluationItem, float>();

            foreach (EvaluationItem item in SectionItem.Lesson.GetEvaluationProtocol(Register.Period).GetAllItems())
            {
                //                float mark = CalculateManualMark(item);
                //                float examMark = CalculateExamMark(item);
                float mark = CalculateMark(item);
                marks.Add(item, mark);
            }

            return SectionItem.Lesson.GetEvaluationProtocol(Register.Period).CalculateMark(marks);
            //            return (from mark in marks select mark.Value).Sum();
        }

        public virtual bool CanCalculateMark(EvaluationItem item)
        {
            return GetMarks(item).Count() > 0 || GetExamParticipates(item).Count() > 0;
        }

        public virtual float CalculateMark(EvaluationItem item)
        {
            List<float> marks = new List<float>();
            if (GetMarks(item).Count() > 0)
            {
                marks.Add(CalculateManualMark(item));
            }
            if (GetExamParticipates(item).Count() > 0)
            {
                marks.Add(CalculateExamMark(item));
            }

            if (marks.Count > 0)
                return marks.Average();
            return 0;
        }

        public virtual float CalculateMark(EvaluationGroup item)
        {
            List<float> marks = new List<float>();
            foreach (EvaluationItem evaluationItem in item.Items)
            {
                float mark = CalculateMark(evaluationItem);
                marks.Add(mark);
            }
            if (marks.Count > 0)
            {
                if (item.EvaluationProtocol.Operator == EvaluationOperator.Average)
                    return marks.Average();
                if (item.EvaluationProtocol.Operator == EvaluationOperator.Sum)
                    return marks.Sum();
            }
            return 0;
        }

        public virtual IQueryable<Mark> GetMarks(EvaluationItem item)
        {
            return (from mark in Marks
                    where mark.EvaluationItem.Id == item.Id
                    select mark).AsQueryable();
        }

        public virtual IQueryable<Mark> GetMarks(PersianDate date)
        {
            var query = from mark in Marks
                        where mark.Date == date
                        select mark;
            return query.AsQueryable();
        }
        private float CalculateManualMark(EvaluationItem item)
        {
            IQueryable<Mark> marks = GetMarks(item);
            if (marks.Count() > 0)
                return marks.Average(x => x.Value);
            return 0;
        }
        private float CalculateExamMark(EvaluationItem item)
        {
            //            var participateQuery = from examParticipate in DbContext.Entity<ExamParticipate>()
            //                                   where examParticipate.Participate != null &&
            //                                   examParticipate.Participate.Id == Id && 
            //                                   examParticipate.ExamForm.Exam.EvaluationItem.Id == item.Id
            //                                   select examParticipate;

            //            var lessonExams = from examParticipate in participateQuery
            //                              from examItem in examParticipate.ExamForm.Exam.Items
            //                              where examItem.Lesson.Id == SectionItem.Lesson.Id
            //                              select examParticipate;

            List<ExamParticipate> examParticipates = GetExamParticipates(item).ToList();
            var resultMark = from examParticipate in examParticipates
                             where examParticipate.Status == ExamParticipateStatus.HasResult
                             select examParticipate.CalculateMark();
            if (resultMark.Count() > 0)
                return resultMark.Average();
            return 0;
        }

        public virtual IQueryable<ExamParticipate> GetExamParticipates()
        {
            var participateQuery = from examParticipate in DbContext.Entity<ExamParticipate>()
                                   where examParticipate.Register != null
                                         && examParticipate.Participate != null
                                         && examParticipate.Participate.Id == Id
                                   select examParticipate;
            return participateQuery;
        }

        public virtual IQueryable<ExamParticipate> GetExamParticipates(EvaluationItem item)
        {
            var participateQuery = from examParticipate in DbContext.Entity<ExamParticipate>()
                                   where examParticipate.Register != null
                                   && examParticipate.Register.Id == Register.Id
                                   && examParticipate.ExamForm.Exam.Period.Id == Register.Period.Id
                                   && examParticipate.ExamForm.Exam.EvaluationItem.Id == item.Id
                                   select examParticipate;

            List<ExamParticipate> examParticipates = participateQuery.ToList();

            var lessonExams = from examParticipate in examParticipates
                              from examItem in examParticipate.ExamForm.Exam.Items
                              where examItem.Lesson.Id == SectionItem.Item.Lesson.Id
                              group examParticipate by examParticipate into g
                              select g.Key;
            return lessonExams.AsQueryable();
        }

        public virtual ResultLabel GetResultLabel()
        {
            ResultProtocol resultProtocol = SectionItem.Lesson.GetResultProtocol(Register.Period);
            if (resultProtocol == null)
                return null;

            ResultLabel resultLabel;
//            if (!String.IsNullOrEmpty(ResultLabel))
//            {
//                resultLabel = resultProtocol.Labels.FirstOrDefault(x => x.Name.Trim() == ResultLabel);
//            }
//            else
//            {
                resultLabel = resultProtocol.Apply(this);
//                ResultLabel = resultLabel.Name;
//                Save();
//            }
            return resultLabel;
        }

        public virtual Mark GetMark(EvaluationItem item, int batchNumber)
        {
            var query = from mark in Marks
                        where mark.BatchNumber == batchNumber
                        && mark.EvaluationItem.Id == item.Id
                        && mark.Lesson.Id == SectionItem.Lesson.Id
                        select mark;
            return query.FirstOrDefault();
        }

        public virtual Mark CreateMark(Lesson lesson, EvaluationItem item, PersianDate date, int batchNumber)
        {
            Mark mark = new Mark { Date = date, Participate = this, Lesson = lesson, EvaluationItem = item, BatchNumber = batchNumber };
            return mark;
        }
        public virtual ActivityMark CreateActivityMark()
        {
            ActivityMark mark = new ActivityMark
            {
                SectionItem = SectionItem,
                Person = Register.Student,
                
            };
            return mark;
        }
        public virtual List<ActivityMark> GetActivityMark(Person person)
        {
            var marks = from mark in DbContext.Entity<ActivityMark>()
                        where mark.SectionItem == SectionItem && mark.Person==person
                        select mark;
            return marks.ToList();
        }
        public static IQueryable<Participate> GetQuitedParticipates(Department department, PersianDate startDate, PersianDate endDate)
        {
            var query = from participate in DbContext.Entity<Participate>()
                        where
                        participate.Register.Major.Department.Id == department.Id
                        && participate.Quit != null
                        && participate.Quit.Date >= startDate && participate.Quit.Date <= endDate
                        select participate;
            return query.AsQueryable();
        }
        public static IQueryable<Participate> GetTransitionedParticipates(Department department, PersianDate startDate, PersianDate endDate)
        {
            var query = from participate in DbContext.Entity<Participate>()
                        where
                        participate.Register.Major.Department.Id == department.Id
                        && participate.Transition != null
                        && participate.Transition.Date >= startDate && participate.Transition.Date <= endDate
                        select participate;
            return query.AsQueryable();
        }
        public static IList<Participate> GetParticipates(EducationalPeriod period, Lesson lesson)
        {
            var query = from participate in DbContext.Entity<Participate>()
                        where participate.Register != null
                            && participate.SectionItem != null
                            && participate.Register.Period.Id == period.Id
                            && participate.SectionItem.Item.Lesson.Id == lesson.Id
                        select participate;
            return query.ToList();
        }
        public static IList<Participate> GetParticipates(PersianDate startDate, PersianDate endDate)
        {
            var query = from participate in DbContext.Entity<Participate>()
                        where participate.Register != null
                        && participate.Date>=startDate
                        && participate.Date<=endDate
                        select participate;
            return query.ToList();
        }

        public static IList<Participate> GetParticipates(EducationalPeriod period, Major major)
        {
            var query = from participate in DbContext.Entity<Participate>()
                        where participate.Register != null
                            && participate.SectionItem != null
                            && participate.Register.Period.Id == period.Id
                            && participate.SectionItem.Item.Lesson.Major.Id == major.Id
                        select participate;
            return query.ToList();
        }

        public virtual Quit PerformQuit(PersianDate date, long returnedAmount, string reason)
        {
            Quit newQuit = new Quit();
            newQuit.Date = date;
            newQuit.FinancialItem.Amount = returnedAmount;
            newQuit.PenaltyFee = Register.PayableTuition - newQuit.FinancialItem.Amount;
            if (newQuit.PenaltyFee < 0)
                throw new Exception("مقدار جریمه انصراف منفی شده است.");
            Quit = newQuit;

            bool allQuited = true;
            foreach (Participate participate in Register.Participates)
                if (participate.Status != ParticipateStatus.Quited)
                {
                    allQuited = false;
                    break;
                }
            if (allQuited)
                Register.Type = RegisterType.FullQuited;
            return newQuit;
        }

        public virtual void RemoveQuit()
        {
            Quit = null;
            Register.Type = RegisterType.Participation;
        }

        public virtual IQueryable<Ban> GetBans(BanStatus status)
        {
            var query = from ban in Bans
                        where ban.Status == status
                        select ban;
            return query.AsQueryable();
        }

        //mohammad
        public static IQueryable<Participate> GetBannedParticipates(EducationalPeriod period, Lesson lesson)
        {
            var query = from ban in DbContext.Entity<Ban>()
                        where ban.Status == BanStatus.Active
                        && ban.Participate.Register.Period.Id == period.Id
                        && ban.Participate.SectionItem.Item.Lesson.Id == lesson.Id
                        select ban.Participate;
            return query.AsQueryable();
        }
        public static IQueryable<Participate> GetBannedParticipates(EducationalPeriod period)
        {
            var query = from ban in DbContext.Entity<Ban>()
                        where ban.Status == BanStatus.Active
                        && ban.Participate.Register.Period.Id == period.Id
                        select ban.Participate;
            return query.AsQueryable();
        }
        public static IQueryable<Participate> GetNextEnrollmentBannedParticipates(EducationalPeriod period, Lesson lesson)
        {
            var query = from participate in DbContext.Entity<Participate>()
                        where participate.Register.NextEnrollmentBanned
                        && participate.Register.Period.Id == period.Id
                        && participate.SectionItem.Item.Lesson.Id == lesson.Id
                        select participate;
            return query.AsQueryable();
        }
        public static IQueryable<Participate> GetNextEnrollmentBannedParticipates(EducationalPeriod period)
        {
            var query = from participate in DbContext.Entity<Participate>()
                        where participate.Register.NextEnrollmentBanned
                        && participate.Register.Period.Id == period.Id
                        select participate;
            return query.AsQueryable();
        }

        public virtual IList<Exam> GetMandatoryExams()
        {
            List<Exam> mandatoryExams = new List<Exam>();

            TrainingPlan trainingPlan = SectionItem.Item.Plan;
            IQueryable<ExamTrainingItem> examItems = trainingPlan.GetExamItems();
            foreach (ExamTrainingItem examItem in examItems)
            {
                if (!examItem.IsMandatory)
                    continue;
                if (examItem.Lesson.Id != SectionItem.Lesson.Id)
                    continue;
                List<Exam> exams = Exam.GetExams(Register.Period, examItem);
                mandatoryExams.AddRange(exams);
            }
            return mandatoryExams;
        }

        public virtual void CheckMandatoryExamsSignup()
        {
            IList<Exam> mandatoryExams = GetMandatoryExams();
            bool signedUp = true;
            foreach (Exam exam in mandatoryExams)
            {
                if (!exam.IsSignedUp(Register))
                {
                    signedUp = false;
                    break;
                }
            }
            if (mandatoryExams.Count > 0 && !signedUp)
                throw new Exception("");
        }

        public virtual bool IsPassed()
        {
            try
            {
                CheckMandatoryExamsSignup();
                //                TrainingPlan trainingPlan = SectionItem.Item.Plan;
                //                IQueryable<ExamTrainingItem> examItems = trainingPlan.GetExamItems();
                //                foreach (ExamTrainingItem examItem in examItems)
                //                {
                //                    if (!examItem.FailOnAbsence)
                //                        continue;
                //                    if (examItem.Lesson.Id != SectionItem.Lesson.Id)
                //                        continue;
                //                    bool signedUp = false;
                //                    List<Exam> exams = Exam.GetExams(Register.Period, examItem);
                //                    foreach (Exam exam in exams)
                //                        if (exam.IsSignedUp(Register))
                //                        {
                //                            signedUp = true;
                //                            break;
                //                        }
                //                    if (!signedUp)
                //                        return false;
                //                }
                EducationalRule educationalRule = EducationalRule.Apply(Register.Period, new[] { this });
                if (educationalRule.Result != EducationalRuleResult.Fail)
                    return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return false;
        }

        public virtual bool IsFirstSignup()
        {
            IQueryable<Participate> participates = Register.Student.GetParticipates(SectionItem.Item.Lesson);
            return participates.Except(new[] { this }).Count() == 0;
        }

        public virtual bool IsReSignup()
        {
            IQueryable<Participate> participates = Register.Student.GetParticipates(SectionItem.Item.Lesson);
            return participates.Except(new[] { this }).Count() > 0;
        }

        public virtual void ConfirmEnrollment()
        {
            EnrollmentConfirmed = true;
        }

        public static Participate FromId(int id)
        {
            return DbContext.FromId<Participate>(id);
        }
    }

    public enum ParticipateStatus
    {
        [EnumDescription("مجـاز بـه شـرکــت")]
        Participating,
        [EnumDescription("انصــراف")]
        Quited,
        [EnumDescription("مـعلـق")]
        Banned,
        [EnumDescription("انتقال")]
        Transitioned
    }
}