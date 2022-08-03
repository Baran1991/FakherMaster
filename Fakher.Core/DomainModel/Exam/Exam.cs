using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataAccessLayer;
using Fakher.Core.Website;
using NHibernate;
using NHibernate.Mapping.ByCode;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Exam : DbObject
    {
        private Dictionary<ExamParticipate, float> mParticipateTotalMarks;
        private Dictionary<ExamItem, Dictionary<ExamParticipate, float>> mItemParticipatePercents;
        private Dictionary<ExamParticipate, float> mParticipateTotalStdScores;
        private Rank mParticipateTotalMarkRank;
        private Dictionary<ExamItem, Rank> mItemRank;
        private Rank mTotalSrdScoreRank;
        private bool mParticipatesCache { get; set; }
        private List<ExamParticipate> mParticipates { get; set; }
        private List<ExerciseParticipate> mExParticipates { get; set; }
        public virtual string Name { get; set; }
        public virtual PersianDate Date { get; set; }
        public virtual int NegativeScore { get; set; }
        public virtual int Capacity { get; set; }
//        public virtual long TuitionFee { get; set; }
        public virtual string Notes { get; set; }
        [NoCascade]
        public virtual Lesson Lesson { get; set; }
        [NoCascade]
        public virtual EducationalPeriod Period { get; set; }
        [NoCascade]
        public virtual EvaluationItem EvaluationItem { get; set; }
        public virtual ExamType Type { get; set; }
        public virtual ExamResultType ResultType { get; set; }
        public virtual RankCalculation RankCalculation { get; set; }
        public virtual IList<ExamItem> Items { get; set; }
        public virtual IList<ExamForm> Forms { get; set; }
        public virtual IList<ExamSection> ExamSections { get; set; }
//        public virtual IList<ExamParticipate> Participates { get; set; }
        [NoCascade]
        public virtual ExamTrainingItem ExamTrainingItem { get; set; }
        [NoCascade]
        public virtual ExerciseTrainingItem ExerciseTrainingItem { get; set; }
        [NoCascade]
        public virtual LessonTrainingItem LessonTrainingItem { get; set; }
        [MaximumLength]
        public virtual string CardNote { get; set; }
        [NoProxy]
        public virtual ExamHolding ExamHolding { get; set; }
        public virtual PersianDate WebReportCardStartDate { get; set; }
        public virtual int WebReportCardStartHour { get; set; }
        public virtual int WebReportCardStartMinute { get; set; }
        public virtual bool CanViewWebReportCard { get; set; }
        public virtual bool InternetRegisterable { get; set; }
        public virtual PersianDate InternetRegisterStartDate { get; set; }
        public virtual int InternetRegisterStartHoure { get; set; }
        public virtual int InternetRegisterStartMinute { get; set; }
        public virtual PersianDate InternetRegisterFinishDate { get; set; }
        public virtual int InternetRegisterFinishHoure { get; set; }
        public virtual int InternetRegisterFinishMinute { get; set; }
        public virtual int AnsweringDeadline { get; set; }
        public virtual IList<WebMedia> Attachments { get; set; }
        public virtual bool HasPoll { get; set; }
        [NoCascade]
        public virtual Poll.Poll Poll { get; set; }
        public virtual bool isFarsi { get; set; } = true;
        public Exam()
        {
            Type = ExamType.PaperBasedExam;
            ResultType = ExamResultType.ItemsSum;
            RankCalculation = RankCalculation.TotalMark;
            Date = PersianDate.Today;
            Items = new List<ExamItem>();
            Forms = new List<ExamForm>();
            ExamSections = new List<ExamSection>();
            Attachments = new List<WebMedia>();
//            Participates = new List<ExamParticipate>();
            CardNote = "حداکثر نیم ساعت قبل از آزمون در محل حضور داشته باشید. \r\n به همراه داشتن یک کارت شناسایی معتبر، الزامی است.";

            mParticipateTotalMarks = new Dictionary<ExamParticipate, float>();
            mItemParticipatePercents = new Dictionary<ExamItem, Dictionary<ExamParticipate, float>>();
            mParticipateTotalStdScores = new Dictionary<ExamParticipate, float>();
            
            mParticipateTotalMarkRank = new Rank();
            mItemRank = new Dictionary<ExamItem, Rank>();
            mTotalSrdScoreRank = new Rank();
        }

        #region Properties

        [NonPersistent]
        public virtual string FarsiText
        {
            get { return Name + " " + FarsiExamSectionsText; }
        }

        [NonPersistent]
        public virtual string FarsiVerboseText
        {
            get { return Name + " " + FarsiExamSectionsVerboseText; }
        }

        [NonPersistent]
        public virtual string EnglishText
        {
            get { return Name + " " + EnglishExamSectionsText; }
        }

        [NonPersistent]
        public virtual string EnglishVerboseText
        {
            get { return Name + " " + EnglishExamSectionsVerboseText; }
        }

        [NonPersistent]
        public virtual string FarsiTypeText
        {
            get { return Type.ToDescription(); }
        }

        [NonPersistent]
        public virtual string EnglishTypeText
        {
            get { return Type + ""; }
        }

        [NonPersistent]
        public virtual int RemainderCount
        {
            get
            {
//                return Capacity - Participates.Count;
                return Capacity - GetParticipates().Count();
            }
        }

        [NonPersistent]
        public virtual string FarsiExamSectionsText
        {
            get 
            { 
                string txt = "";
                if (ExamSections.Count > 0)
                {
                    foreach (ExamSection examSection in ExamSections)
                    {
                        txt += examSection.SectionItem.Section.FarsiName;
                        if (ExamSections.IndexOf(examSection) != ExamSections.Count - 1)
                            txt += "، ";
                    }
                }
                else
                    txt = "ندارد";
                return txt;
            }
        }

        [NonPersistent]
        public virtual string FarsiExamSectionsVerboseText
        {
            get 
            { 
                string txt = "";
                if (ExamSections.Count > 0)
                {
                    foreach (ExamSection examSection in ExamSections)
                    {
                        txt += examSection.SectionItem.Section.FarsiName + " [" +
                               examSection.SectionItem.Section.Teacher.FarsiFullname + "]";
                        if (ExamSections.IndexOf(examSection) != ExamSections.Count - 1)
                            txt += "، ";
                    }
                }
                else
                    txt = "ندارد";
                return txt;
            }
        }

        [NonPersistent]
        public virtual string EnglishExamSectionsText
        {
            get 
            { 
                string txt = "";
                foreach (ExamSection examSection in ExamSections)
                {
                    txt += examSection.SectionItem.Section.EnglishName;
                    if (ExamSections.IndexOf(examSection) != ExamSections.Count - 1)
                        txt += ", ";
                }
                return txt;
            }
        }

        [NonPersistent]
        public virtual string EnglishExamSectionsVerboseText
        {
            get 
            { 
                string txt = "";
                foreach (ExamSection examSection in ExamSections)
                {
                    txt += examSection.SectionItem.Section.EnglishName + " [" + examSection.SectionItem.Section.Teacher.EnglishFullname + "]";
                    if (ExamSections.IndexOf(examSection) != ExamSections.Count - 1)
                        txt += ", ";
                }
                return txt;
            }
        }

        [NonPersistent]
        public virtual int QuestionCount
        {
            get
            {
                var q = from item in Items
                        select item.QuestionCount;
                return q.Sum();
            }
        }

        [NonPersistent]
        public virtual ResultProtocol ResultProtocol
        {
            get
            {
//                if (Items.Count > 0)
//                    return Items[0].Lesson.GetResultProtocol(Period);
                if (ExamTrainingItem != null)
                    return ExamTrainingItem.Lesson.GetResultProtocol(Period);
                return null;
            }
        }

        [NonPersistent]
        public virtual bool IsGeneral
        {
            get
            {
                if(ExamTrainingItem == null)
                    return false;
                return ExamTrainingItem.IsGeneral;
            }
        }

        [NonPersistent]
        public virtual bool IsEntranceExam
        {
            get
            {
                if(ExamTrainingItem == null)
                    return false;
                return ExamTrainingItem.IsEntranceExam;
            }
        }

        [NonPersistent]
        public virtual bool IsMandatory
        {
            get
            {
                if(ExamTrainingItem == null)
                    return false;
                return ExamTrainingItem.IsMandatory;
            }
        }

        [NonPersistent]
        public virtual bool HasHolding
        {
            get { return ExamHolding != null; }
        }

        [NonPersistent]
        public virtual char WhiteChar
        {
            get { return '0'; }
        }
        [NonPersistent]
        public virtual DateTime InternetRegisterStartDateTime
        {
            get
            {
                if (InternetRegisterStartDate == null)
                    return new DateTime();
                DateTime systemDateTime = InternetRegisterStartDate.ToSystemDateTime();
                return new DateTime(systemDateTime.Year, systemDateTime.Month, systemDateTime.Day, InternetRegisterStartHoure, InternetRegisterStartMinute, 0);
            }
        }
        [NonPersistent]
        public virtual DateTime InternetRegisterFinishDateTime
        {
            get
            {
                if (InternetRegisterFinishDate == null)
                    return new DateTime();
                DateTime systemDateTime = InternetRegisterFinishDate.ToSystemDateTime();
                return new DateTime(systemDateTime.Year, systemDateTime.Month, systemDateTime.Day, InternetRegisterFinishHoure, InternetRegisterFinishMinute, 0);
            }
        }
        [NonPersistent]
        public virtual string InternetRegisterStartTime
        {
            get { return InternetRegisterStartHoure.ToString("D2") + ":" + InternetRegisterStartMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                InternetRegisterStartHoure = Convert.ToInt32(timeItems[0]);
                InternetRegisterStartMinute = Convert.ToInt32(timeItems[1]);
            }
        }
        [NonPersistent]
        public virtual string InternetRegisterFinishTime
        {
            get { return InternetRegisterFinishHoure.ToString("D2") + ":" + InternetRegisterFinishMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                InternetRegisterFinishHoure = Convert.ToInt32(timeItems[0]);
                InternetRegisterFinishMinute = Convert.ToInt32(timeItems[1]);
            }
        }
        [NonPersistent]
        public virtual string WebReportCardStartTime
        {
            get { return WebReportCardStartHour.ToString("D2") + ":" + WebReportCardStartMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                WebReportCardStartHour = Convert.ToInt32(timeItems[0]);
                WebReportCardStartMinute = Convert.ToInt32(timeItems[1]);
            }
        }

        [NonPersistent]
        public virtual DateTime WebReportCardStartDateTime
        {
            get
            {
                DateTime systemDateTime = WebReportCardStartDate.ToSystemDateTime();
                return new DateTime(systemDateTime.Year, systemDateTime.Month, systemDateTime.Day, WebReportCardStartHour, WebReportCardStartMinute, 0);
            }
        }

//        [NonPersistent]
//        public virtual char RemovedAmortaziedChar
//        {
//            get { return '5'; }
//        }

        [NonPersistent]
        public virtual IEnumerable<ExamParticipate> PeresentParticipates
        {
            get
            {
//                return Participates.Where(x => x.IsPeresent);
                return GetParticipates().ToList().Where(x => x.IsPeresent);
            }
        }

        #endregion

        #region Static Members

        public static List<Exam> GetExams(EducationalPeriod period)
        {
            var query = from exam in DbContext.Entity<Exam>()
                        where exam.Period.Id == period.Id
                        select exam;
            return query.ToList();
        }

        public static List<Exam> GetExams(EducationalPeriod period, ExamType type)
        {
            var query = from exam in DbContext.Entity<Exam>()
                        where exam.Type == type
                        && exam.Period.Id == period.Id
                        select exam;
            return query.ToList();
        }

        public static List<Exam> GetExams(EducationalPeriod period, Major major)
        {
            var query = from exam in DbContext.Entity<Exam>()
                        where exam.Period.Id == period.Id
                              && exam.Lesson.Major.Id == major.Id
                        select exam;
            return query.ToList();
        }

        public static List<Exam> GetExams(EducationalPeriod period, Major major, ExamType type)
        {
            var query = from exam in DbContext.Entity<Exam>()
                        where exam.Type == type
                              && exam.Period.Id == period.Id
                              && exam.Lesson.Major.Id == major.Id
                        select exam;
            return query.ToList();
        }

        public static List<Exam> GetExams(EducationalPeriod period, ExamTrainingItem item)
        {
            var query = from exam in DbContext.Entity<Exam>()
                        where exam.Period.Id == period.Id
                              && exam.ExamTrainingItem.Id == item.Id
                        select exam;
            return query.ToList();
        }        
        
        public static List<Exam> GetExams(EducationalPeriod period, ExamTrainingItem item, SectionItem sectionItem)
        {
            var query = from Exam exam in GetExams(period, item)
                        from section in exam.ExamSections
                        where section.SectionItem.Id == sectionItem.Id
                        select exam;
            return query.ToList();
        }

        public static Exam FromTrainingItem(ExamTrainingItem item)
        {
            Exam exam = new Exam();
            exam.ExamTrainingItem = item;
            exam.Capacity = item.Capacity;
            exam.Type = item.Type;
            exam.NegativeScore = item.NegativeScore;
            exam.ResultType = item.ResultType;
            exam.RankCalculation = item.RankCalculation;
            if(item.EvaluationItem == null)
                throw new Exception("آیتم ارزشیابی این آزمون در برنامه آموزشی آن مشخص نشده است.");
            if(item.Forms.Count == 0)
                throw new Exception("فرم های این آزمون در برنامه آموزشی آن تعریف نشده است.");
            if(item.Items.Count == 0)
                throw new Exception("مواد این آزمون در برنامه آموزشی آن تعریف نشده است.");

            exam.EvaluationItem = item.EvaluationItem;
            foreach (ExamForm form in item.Forms)
            {
                ExamForm examForm = form.Clone();
                examForm.ExamTrainingItem = null;
                examForm.Exam = exam;
                exam.Forms.Add(examForm);
            }
            foreach (ExamItem examItem in item.Items)
            {
                ExamItem clone = examItem.Clone();
                clone.ExamTrainingItem = null;
                clone.Exam = exam;
                exam.Items.Add(clone);
            }

            exam.Lesson = item.Lesson;
            exam.Name = item.Name;
            
//            TuitionFee tuitionFee = item.GetTuitionFee(item.Lesson.Major, RegisterParticipation.ClassAndGeneralExams);
//            if(tuitionFee == null)
//                throw new Exception(string.Format("شهریه این آزمون برای رشته {0} مشخص نشده است.", item.Lesson.Major));
//            exam.TuitionFee = tuitionFee.Fee;

            return exam;
        }
        public static Exam FromExerciseTrainingItem(ExerciseTrainingItem item)
        {
            Exam exam = new Exam();
            exam.ExerciseTrainingItem = item;
            exam.Capacity = item.Capacity;
            exam.Type = item.Type;
            exam.NegativeScore = item.NegativeScore;
            exam.ResultType = item.ResultType;
            exam.RankCalculation = item.RankCalculation;
            if (item.EvaluationItem == null)
                throw new Exception("آیتم ارزشیابی این تمرین در برنامه آموزشی آن مشخص نشده است.");
            if (item.Forms.Count == 0)
                throw new Exception("فرم های این تمرین در برنامه آموزشی آن تعریف نشده است.");
            if (item.Items.Count == 0)
                throw new Exception("مواد این تمرین در برنامه آموزشی آن تعریف نشده است.");

            exam.EvaluationItem = item.EvaluationItem;
            foreach (ExamForm form in item.Forms)
            {
                ExamForm examForm = form.Clone();
                examForm.ExerciseTrainingItem = null;
                examForm.Exam = exam;
                exam.Forms.Add(examForm);
            }
            foreach (ExamItem examItem in item.Items)
            {
                ExamItem clone = examItem.Clone();
                clone.ExerciseTrainingItem = null;
                clone.Exam = exam;
                exam.Items.Add(clone);
            }

            exam.Lesson = item.Lesson;
            exam.Name = item.Name;

            //            TuitionFee tuitionFee = item.GetTuitionFee(item.Lesson.Major, RegisterParticipation.ClassAndGeneralExams);
            //            if(tuitionFee == null)
            //                throw new Exception(string.Format("شهریه این آزمون برای رشته {0} مشخص نشده است.", item.Lesson.Major));
            //            exam.TuitionFee = tuitionFee.Fee;

            return exam;
        }
        public static Exam FromLessonTrainingItem(LessonTrainingItem item)
        {
            Exam exam = new Exam();
            exam.LessonTrainingItem = item;
            exam.Capacity = item.Capacity;
            exam.Type = item.Type;

            foreach (ExamForm form in item.Forms)
            {
                ExamForm examForm = form.Clone();
                examForm.LessonTrainingItem = null;
                examForm.Exam = exam;
                exam.Forms.Add(examForm);
            }
            exam.Lesson = item.Lesson;
            exam.Name = item.Name;

            return exam;
        }
        public static Exam FromId(int id)
        {
            return DbContext.FromId<Exam>(id);
        }

        #endregion

        #region Methods

        public virtual void UseParticipatesCache()
        {
            mParticipatesCache = true;
        }

        public virtual IQueryable<ExamParticipate> GetAbsentParticipates()
        {
            var query = from participate in GetParticipates().ToList()
                        where participate.IsAbsent
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<ExamParticipate> GetAbsentParticipates(ExamSection examSection)
        {
            var query = from participate in GetParticipates(examSection).ToList()
                        where participate.IsAbsent
                        select participate;
            return query.AsQueryable();
        }
        public virtual IQueryable<ExerciseParticipate> GetExerciseParticipates()
        {
           
                var query = from participate in DbContext.Entity<ExerciseParticipate>()
                            where participate.Exam != null
                                && participate.Exam.Id == Id
                            select participate;

                if (mParticipatesCache)
                {
                    if (mExParticipates == null)
                        mExParticipates = query.ToList();

                    return mExParticipates.AsQueryable();
                }

                return query;
          
        }
        public virtual List<ExerciseParticipate> GetExerciseNotParticipates()
        {
            var query = Participate.GetParticipates(this.Period, this.Lesson);
            //select new ExamParticipate() {Register= participate.Register,Code=0,ExamForm=null,SeatNumber=0};
            var thisParticipate = GetParticipates().Select(m => m.Participate);
            var lstExamPart = new List<ExerciseParticipate>();
            foreach (var item in query)
            {
                if (!thisParticipate.Where(m => m.Id == item.Id).Any())
                    lstExamPart.Add(new ExerciseParticipate() { Register = item.Register, Code = 0, Participate = item, ExamForm = new ExamForm(), Status = ExamParticipateStatus.NotParticipate, ExamFormation = new Formation(), SeatNumber = 0, CardStatusText = "ندارد", ExamTimeText = "" });
            }
            return lstExamPart;
        }
        public virtual IQueryable<ExamParticipate> GetParticipates()
        {
           
            
                var query = from participate in DbContext.Entity<ExamParticipate>()
                            where participate.Exam != null
                                && participate.Exam.Id == Id
                            select participate;

                if (mParticipatesCache)
                {
                    if (mParticipates == null)
                        mParticipates = query.ToList();

                    return mParticipates.AsQueryable();
                }

                return query;
            
        }
        public virtual List<ExamParticipate> GetNotParticipates()
        {
            var query = Participate.GetParticipates(this.Period, this.Lesson);
            //select new ExamParticipate() {Register= participate.Register,Code=0,ExamForm=null,SeatNumber=0};
           var thisParticipate= GetParticipates().Select(m=>m.Participate);
            var lstExamPart = new List<ExamParticipate>();
            foreach(var item in query)
            {
                if (!thisParticipate.Where(m => m.Id == item.Id).Any())
                    lstExamPart.Add(new ExamParticipate() { Register = item.Register, Code = 0, Participate = item, ExamForm = new ExamForm(), Status= ExamParticipateStatus.NotParticipate, ExamFormation = new Formation(),SeatNumber=0,CardStatusText="ندارد",ExamTimeText="" }) ;
            }
            return lstExamPart;
        }
        public virtual ExamParticipate CreateExamParticipate()
        {
            ExamParticipate examParticipate = null;

            if (Type == ExamType.PaperBasedExam)
                examParticipate = new PaperBasedExamParticipate();
            if(Type == ExamType.OralExam)
                examParticipate = new OralExamParticipate();
            if(Type == ExamType.OnlineExam)
                examParticipate = new OnlineExamParticipate();
            if (Type == ExamType.Exercise )
                examParticipate = new ExerciseParticipate();
            //if (Type == ExamType.Lesson)
            //    examParticipate = new BlackboardLessonParticipate();
            examParticipate.Exam = this;
            return examParticipate;
        }

        public virtual ExamForm GetRandomExamForm()
        {
            Random random = new Random();
            int idx = random.Next(0, Forms.Count);
            ExamForm form = Forms[idx];
            return form;
        }

        public virtual IQueryable<ExamForm> GetFreeExamForms()
        {
            var query = from form in Forms
                        where !form.GetParticipates().Any()
                        select form;
            return query.AsQueryable();
        }

        public virtual ExamForm GetNextFreeExamForm()
        {
//            var query = from form in Forms
//                        where form.Participates.Count == 0
//                        select form;
            var query = from form in Forms
                        where !form.GetParticipates().Any()
                        select form;
            return query.FirstOrDefault();
        }

        public virtual IQueryable<ExamItem> GetItems(Lesson lesson)
        {
            var query = from item in Items
                        where item.Lesson != null 
                        && item.Lesson.Id == lesson.Id
                        select item;
            return query.AsQueryable();
        }

        public virtual bool ContainsLesson(Lesson lesson)
        {
            return GetItems(lesson).Count() > 0;
        }

        public virtual IQueryable<ExamParticipate> GetFarsiOrderedParticipates()
        {
//            var query = from participate in Participates 
//                        orderby participate.Register.Student.FarsiLastName 
//                        select participate;
            var query = from participate in GetParticipates()
                        orderby participate.Register.Student.FarsiLastName 
                        select participate;
            return query.AsQueryable();
        }
        public virtual IQueryable<ExerciseParticipate> GetFarsiOrderedExerciseParticipates(ExamSection examSection)
        {
            var query = from participate in GetExerciseParticipates(examSection)
                        orderby participate.Register.Student.FarsiLastName
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<ExamParticipate> GetFarsiOrderedParticipates(ExamSection examSection)
        {
            var query = from participate in GetParticipates(examSection) 
                        orderby participate.Register.Student.FarsiLastName 
                        select participate;
            return query.AsQueryable();
        }
        public virtual IQueryable<ExerciseParticipate> GetEnglishOrderedExerciseParticipates(ExamSection examSection)
        {
            var query = from participate in GetExerciseParticipates(examSection)
                        orderby participate.Register.Student.EnglishLastName
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<ExamParticipate> GetEnglishOrderedParticipates()
        {
//            var query = from participate in Participates 
//                        orderby participate.Register.Student.EnglishLastName 
//                        select participate;
            var query = from participate in GetParticipates()
                        orderby participate.Register.Student.EnglishLastName 
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<ExamParticipate> GetEnglishOrderedParticipates(ExamSection examSection)
        {
            var query = from participate in GetParticipates(examSection) 
                        orderby participate.Register.Student.EnglishLastName 
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<ExamParticipate> GetParticipates(Formation formation)
        {
            IEnumerable<ExamParticipate> query;
//            if (!HasHolding)

//            query = from participate in Participates
//                    where participate.Formation != null
//                          && participate.Formation.Id == formation.Id
//                    select participate;
            query = from participate in GetParticipates()
                    where participate.Formation != null
                          && participate.Formation.Id == formation.Id
                    select participate;

//            else
//                query = from participate in Participates
//                        where participate.CustomFormation != null
//                              && participate.CustomFormation.Id == formation.Id
//                        select participate;

            return query.AsQueryable();
        }
        public virtual IQueryable<ExerciseParticipate> GetExerciseParticipates(ExamSection examSection)
        {
         
            var query = from participate in GetExerciseParticipates().ToList()
                        where participate.GetSection() != null
                        && participate.GetSection().Id == examSection.Id
                        select participate;
            return query.AsQueryable();
        }
        public virtual IQueryable<ExamParticipate> GetParticipates(ExamSection examSection)
        {
//            foreach (ExamParticipate examParticipate in Participates)
//            {
//                ExamSection section = examParticipate.GetSection();
//                if(section == null)
//                {
//                    
//                }
//            }
//            var query = from participate in Participates
//                        where participate.GetSection() != null
//                        && participate.GetSection().Id == examSection.Id
//                        select participate;
            var query = from participate in GetParticipates().ToList()
                        where participate.GetSection() != null
                        && participate.GetSection().Id == examSection.Id
                        select participate;
            return query.AsQueryable();
        }

        public virtual ExamSection AddSection(SectionItem item)
        {
            ExamSection examSection = new ExamSection {Exam = this, SectionItem = item};
            ExamSections.Add(examSection);
            return examSection;
        }

        public virtual void CheckAllMarks()
        {
//            var query = from examParticipate in Participates
//                        where examParticipate.Status == ExamParticipateStatus.UnKnown
//                        select examParticipate;
            var query = from examParticipate in GetParticipates().ToList()
                        where examParticipate.Status == ExamParticipateStatus.UnKnown
                        select examParticipate;
            if (query.Count() > 0)
                throw new Exception(string.Format("برای {0} نفر از دانشجویان نمره وارد نشده است.", query.Count()));
        }

        public virtual void CheckMarks(ExamSection section)
        {
            var query = from examParticipate in GetParticipates(section)
                        where examParticipate.Status == ExamParticipateStatus.UnKnown
                        select examParticipate;
            if (query.Count() > 0)
                throw new Exception(string.Format("برای {0} نفر از دانشجویان نمره وارد نشده است.", query.Count()));
        }
        public virtual void CheckAllExerciseMarks()
        {
            //            var query = from examParticipate in Participates
            //                        where examParticipate.Status == ExamParticipateStatus.UnKnown
            //                        select examParticipate;
            var query = from examParticipate in GetExerciseParticipates().ToList()
                        where examParticipate.Status == ExamParticipateStatus.UnKnown
                        select examParticipate;
            if (query.Count() > 0)
                throw new Exception(string.Format("برای {0} نفر از دانشجویان نمره وارد نشده است.", query.Count()));
        }

        public virtual void CheckExerciseMarks(ExamSection section)
        {
            var query = from examParticipate in GetExerciseParticipates(section)
                        where examParticipate.Status == ExamParticipateStatus.UnKnown
                        select examParticipate;
            if (query.Count() > 0)
                throw new Exception(string.Format("برای {0} نفر از دانشجویان نمره وارد نشده است.", query.Count()));
        }
        public virtual void CheckKey()
        {
            foreach (ExamForm examForm in Forms)
                if (!examForm.HasKey)
                    throw new Exception(string.Format("کلید فرم {0} وارد نشده است.", examForm.Name));
        }

        public virtual void AddExamForm(ExamForm examForm)
        {
            examForm.Exam = this;
            Forms.Add(examForm);
        }

        public virtual ExamItem GetExamItem(int questionNumber)
        {
            var query = from item in Items
                        where questionNumber >= item.StartIndex && questionNumber <= item.EndIndex
                        select item;
            return query.FirstOrDefault();
        }

        public virtual void EnsurePreCalculation()
        {
            if (mParticipateTotalMarks.Count == 0)
            {
                List<ExamParticipate> participates = GetParticipates().ToList();
                EnsurePreCalculation(participates);
            }
        }

        public virtual void EnsurePreCalculation(IList<ExamParticipate> participates)
        {
            mParticipateTotalMarks.Clear();
            mParticipateTotalMarkRank = new Rank();
            foreach (ExamParticipate participate in participates)
            {
                float mark = participate.CalculateMark();
                mParticipateTotalMarks.Add(participate, mark);
                mParticipateTotalMarkRank.AddPoint(mark);
            }
            mParticipateTotalMarkRank.Calculate();
        }

        public virtual void EnsurePreCalculation(ExamItem item)
        {
            if (!mItemParticipatePercents.ContainsKey(item))
            {
                EnsurePreCalculation();

                Rank rank = new Rank();
                Dictionary<ExamParticipate, float> itemPercents = new Dictionary<ExamParticipate, float>();
                
                List<ExamParticipate> examParticipates = GetParticipates().ToList();
                foreach (ExamParticipate participate in examParticipates)
                {
                    float percent = participate.CalculatePercent(item);
                    itemPercents.Add(participate, percent);
                    rank.AddPoint(percent);
                }

                rank.Calculate();
                mItemRank.Add(item, rank);
                mItemParticipatePercents.Add(item, itemPercents);
            }
        }

        public virtual void EnsureTotalScorePreCalculation()
        {
            if (mParticipateTotalStdScores.Count == 0)
            {
                mParticipateTotalStdScores.Clear();
                mTotalSrdScoreRank = new Rank();
                List<ExamParticipate> examParticipates = GetParticipates().ToList();
                foreach (ExamParticipate participate in examParticipates)
                {
                    double scoreSum = 0;
                    double coeffiecientSum = 0;
                    foreach (ExamItem examItem in Items)
                    {
                        float score = CalculateStandardScore(participate, examItem);
                        scoreSum += score * examItem.Coefficient;
                        coeffiecientSum += examItem.Coefficient;
                    }
                    float totalScore = (float) (scoreSum / coeffiecientSum);
                    mParticipateTotalStdScores.Add(participate, totalScore);
                    mTotalSrdScoreRank.AddPoint(totalScore);
                }
                mTotalSrdScoreRank.Calculate();
            }
        }

        /// <summary>
        /// Old injori bood: Calculate rank base on TotalMark
        /// </summary>
        /// <param name="unRankedParticipate"></param>
        /// <returns></returns>
        public virtual int CalculateRank(ExamParticipate unRankedParticipate)
        {
            EnsurePreCalculation();

            if (RankCalculation == RankCalculation.TotalMark)
            {
                float totalMark = mParticipateTotalMarks[unRankedParticipate];
                return mParticipateTotalMarkRank.GetRank(totalMark);
            }
            if(RankCalculation == RankCalculation.StandardScore)
            {
                return CalculateStandardScoreRank(unRankedParticipate);
            }

            throw new Exception("نحوه رتبه بندی مشخص نیست.");
        }

        /// <summary>
        /// Calculate Rank base on ExamItem Mark
        /// </summary>
        /// <param name="unRankedParticipate"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual int CalculateRank(ExamParticipate unRankedParticipate, ExamItem item)
        {
            EnsurePreCalculation(item);

            double itemPercent = mItemParticipatePercents[item][unRankedParticipate];
            return mItemRank[item].GetRank(itemPercent);
        }

        /// <summary>
        /// Calculate rank base on Std Score 
        /// </summary>
        /// <param name="unRankedParticipate"></param>
        /// <returns></returns>
        public virtual int CalculateStandardScoreRank(ExamParticipate unRankedParticipate)
        {
            EnsureTotalScorePreCalculation();

            double totalScore = mParticipateTotalStdScores[unRankedParticipate];
            return mTotalSrdScoreRank.GetRank(totalScore);
        }

        /// <summary>
        /// تراز کل
        /// </summary>
        /// <param name="examParticipate"></param>
        /// <returns></returns>
        public virtual float CalculateStandardScore(ExamParticipate examParticipate)
        {
            EnsureTotalScorePreCalculation();
            return mParticipateTotalStdScores[examParticipate];
        }

        public virtual float CalculateStandardScore(ExamParticipate examParticipate, ExamItem item)
        {
            EnsurePreCalculation(item);

            double zScore = CalculatePercentZScore(examParticipate, item);
            return CalculateStandardScore(zScore);
        }

        private float CalculateStandardScore(double zScore)
        {
            return (float) ((zScore * 2250) + 5000);
        }

        private float CalculateZScore(double x, double avg, double stdd)
        {
            if (stdd == 0)
                return 0;
            return (float) ((x - avg) / stdd);
        }

        public virtual float CalculatePercentsAverage(ExamItem item)
        {
            EnsurePreCalculation(item);

            return mItemParticipatePercents[item].Select(x => x.Value).Average();
        }

        public virtual float CalculatePercentZScore(ExamParticipate examParticipate, ExamItem item)
        {
            EnsurePreCalculation(item);

            double percent = mItemParticipatePercents[item][examParticipate];
            double avgPercent = CalculatePercentsAverage(item);
            double standardDeviation = CalculatePercentsStandardDeviation(item);

            return CalculateZScore(percent, avgPercent, standardDeviation);
        }

        public virtual float CalculatePercentsStandardDeviation(ExamItem item)
        {
            EnsurePreCalculation(item);

            double avgPercent = CalculatePercentsAverage(item);
            double sum = 0;
            int participateCount = GetParticipates().Count();
            List<ExamParticipate> examParticipates = GetParticipates().ToList();

            foreach (ExamParticipate examParticipate in examParticipates)
            {
                double percent = mItemParticipatePercents[item][examParticipate];
                sum += Math.Pow(percent - avgPercent, 2);
            }
            return (float)Math.Sqrt(sum / participateCount);
        }

        public virtual float GetMinimumPercent(ExamItem item)
        {
            EnsurePreCalculation(item);
            double min = mItemParticipatePercents[item].Select(x => x.Value).Min();
            return (float) Math.Round(min, 2);
        }

        public virtual float GetMaximumPercent(ExamItem item)
        {
            EnsurePreCalculation(item);
            double max = mItemParticipatePercents[item].Select(x => x.Value).Max();
            return (float) Math.Round(max, 2);
        }

        public virtual float GetRankPercent(int rank, int count)
        {
            float percent = 100;
            if (count > 1)
                percent = (100f - (rank - 1f) * 100f / (count - 1f));
            if (rank == 0)
                percent = 0;
            return percent;
        }

        public virtual string GetStatus(int rank , int count)
        {
            float rankPercent = 100 - GetRankPercent(rank, count);
            if (rankPercent <= 4)
                return "بسیار عالی";
            if (rankPercent <= 11)
                return "عالی";
            if (rankPercent <= 23)
                return "خیلی خوب";
            if (rankPercent <= 40)
                return "خوب";
            if (rankPercent <= 60)
                return "متوسط";
            if (rankPercent <= 77)
                return "نسبتا ضعیف";
            if (rankPercent <= 89)
                return "ضعیف";
            if (rankPercent <= 96)
                return "خیلی ضعیف";
            return "بیش از حد ضعیف";
        }

        public virtual string CalculateStatusText(ExamParticipate examParticipate)
        {
            if (examParticipate.IsAbsent)
                return "غائب";
            int rank = CalculateStandardScoreRank(examParticipate);
            int count = GetParticipates().Count();
            return GetStatus(rank, count);
        }

        public virtual string CalculateStatusText(ExamParticipate examParticipate, ExamItem item)
        {
            int rank = CalculateRank(examParticipate, item);
            int count = GetParticipates().Count();
            return GetStatus(rank, count);
        }

        public virtual bool IsSignedUp(Register register)
        {
//            var query = from form in Forms
//                        from participate in form.Participates
//                        where participate.Register.Id == register.Id
//                        select participate.Register;
            IEnumerable<ExamParticipate> examParticipates = GetParticipate(register);
            return examParticipates.Count() > 0;
        }

        public virtual bool IsSignedUp(SectionItem sectionItem)
        {
            var query = from examSection in ExamSections
                        where examSection.SectionItem.Id == sectionItem.Id
                        select examSection;
            return query.Count() > 0;
        }

        public virtual IEnumerable<ExamParticipate> GetParticipate(Register register)
        {
            var query = from form in Forms
                        from participate in form.GetParticipates()
                        where participate.Register != null
                        && participate.Register.Id == register.Id
                        select participate;
            return query;
        }

        public virtual ExamParticipate GetParticipate(Formation formation, int examNumber)
        {
            IEnumerable<ExamParticipate> query;
//            if (HasHolding)
//                query = from participate in Participates
//                        where participate.CustomFormation != null
//                              && participate.CustomFormation.Id == formation.Id
//                              && participate.SeatNumber == seatNumber
//                        select participate;
//            else
            query = from participate in GetParticipates()
                    where participate.Formation != null
                          && participate.Formation.Id == formation.Id
                          && participate.SeatNumber == examNumber
                    select participate;
            return query.FirstOrDefault();
        }

        public virtual void CheckExamHolding()
        {
            if(!HasHolding)
                throw new Exception("برای این آزمون، اطلاعات برگزاری تعریف نشده است، بنابراین امکان انجام امور مربوط به برگزاری آن وجود ندارد.");
        }

        public virtual void AddExamItem(ExamItem item)
        {
            item.Exam = this;
            Items.Add(item);
        }

        public virtual bool IsAbsent(Register register)
        {
            IEnumerable<ExamParticipate> examParticipates = GetParticipate(register);
            if (examParticipates.Count() == 0)
                return true;
            foreach (ExamParticipate examParticipate in examParticipates)
            {
                bool absent = examParticipate.IsAbsent;
                if (absent)
                    return true;
            }
            return false;
        }

        public virtual bool CanViewReportCard(PersianDate date, int hour, int minute)
        {
            if (!CanViewWebReportCard)
                return false;

            DateTime nowDateTime = date.ToSystemDateTime();
            DateTime now = new DateTime(nowDateTime.Year, nowDateTime.Month, nowDateTime.Day, hour, minute, 0);

            return now >= WebReportCardStartDateTime;

//            return CanViewWebReportCard && date >= WebReportCardStartDate
//                   && (hour > WebReportCardStartHour
//                       || (hour == WebReportCardStartHour && minute >= WebReportCardStartMinute));
        }

        public virtual long GetTuitionFee(Major major, RegisterParticipation participation)
        {
            TuitionFee tuitionFee = ExamTrainingItem.GetTuitionFee(major, participation);
            if (tuitionFee != null)
                return tuitionFee.Fee;
            return 0;
        }

        #endregion

    }

    public enum ExamType
    {
        [EnumDescription("کـتـبـی")]
        PaperBasedExam,
        [EnumDescription("آنلـایـن")]
        OnlineExam,
        [EnumDescription("مصـاحبـه")]
        OralExam,
        [EnumDescription("تمرین")]
        Exercise,
        [EnumDescription("درس")]
        Lesson
    }

    public enum ExamResultType
    {
        [EnumDescription("مجموع مواد آزمون")]
        ItemsSum,
        [EnumDescription("میانگین مواد آزمون")]
        ItemsAverage
    }

    public enum RankCalculation
    {
        [EnumDescription("نمــره کــل")]
        TotalMark,
        [EnumDescription("نمــره تــراز")]
        StandardScore,
    }
}