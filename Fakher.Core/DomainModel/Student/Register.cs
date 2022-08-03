using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    [EventClass("ثبت نام")]
    public class Register : FinancialEntity
    {
        private bool mExamParticipatesCache { get; set; }
        private List<ExamParticipate> mExamParticipates { get; set; }

        public Register()
        {
            RegisterDate = PersianDate.Today;
            RegisterHour = DateTime.Now.Hour;
            RegisterMinute = DateTime.Now.Minute;
            Type = RegisterType.Participation;
//            RegisterParticipation = RegisterParticipation.ClassAndGeneralExams;
            FinancialDocument = new FinancialDocument();
            Participates = new List<Participate>();
//            ExamParticipates = new List<ExamParticipate>();
            Enrollments = new List<Enrollment>();
            FinancialCommitments = new List<FinancialCommitment>();

            AnnouncementStartDate = PersianDate.Today;
            AnnouncementStartHour = DateTime.Now.Hour;
            AnnouncementStartMinute = DateTime.Now.Minute;
            AnnouncementEndDate = PersianDate.Today;
            AnnouncementEndHour = 23;
            AnnouncementEndMinute = 59;
        }

        public virtual EducationalCode EducationalCode { get; set; }
//        public virtual string Code { get; set; }
        public virtual PersianDate StartDate { get; set; }
        public virtual PersianDate EndDate { get; set; }
        public virtual RegisterType Type { get; set; }
//        public virtual RegisterParticipation RegisterParticipation { get; set; }
        public virtual bool InternetRegisteration { get; set; }
        public virtual bool EnrollmentConfirmed { get; set; }
        public virtual bool NextEnrollmentBanned { get; set; }
        public virtual string NextEnrollmentBanReason { get; set; }
        [EventClassProperty("تاریخ ثبت نام", null)]
        public virtual PersianDate RegisterDate { get; set; }
        public virtual int RegisterHour { get; set; }
        public virtual int RegisterMinute { get; set; }
        public virtual string Registrar { get; set; }
        [EventClassProperty("رشته ثبت نامی", null)]
        [NoCascade]
        public virtual Major Major { get; set; }
        [EventClassProperty("دوره ثبت نامی", null)]
        [NoCascade]
        public virtual EducationalPeriod Period { get; set; }
        [EventClassProperty("نام دانشجو", null)]
        [NoCascade]
       // public int Student_id { get; set; }
        public virtual Student Student { get; set; }
        [EventClassProperty("انصراف", null)]
        public virtual Quit Quit { get; set; }
        [EventClassProperty("انتقال", null)]
        public virtual Transition Transition { get; set; }
        public virtual IList<Participate> Participates { get; set; }
//        public virtual IList<ExamParticipate> ExamParticipates { get; set; }
        public virtual IList<Enrollment> Enrollments { get; set; }
        [MaximumLength]
        public virtual string Announcement { get; set; }
        public virtual PersianDate AnnouncementStartDate { get; set; }
        public virtual int AnnouncementStartHour { get; set; }
        public virtual int AnnouncementStartMinute { get; set; }
        public virtual PersianDate AnnouncementEndDate { get; set; }
        public virtual int AnnouncementEndHour { get; set; }
        public virtual int AnnouncementEndMinute { get; set; }
        public virtual IList<FinancialCommitment> FinancialCommitments { get; set; }


        [NonPersistent]
        public virtual string AnnouncementStartTime
        {
            get { return AnnouncementStartHour.ToString("D2") + ":" + AnnouncementStartMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                AnnouncementStartHour = Convert.ToInt32(timeItems[0]);
                AnnouncementStartMinute = Convert.ToInt32(timeItems[1]);
            }
        }
        [NonPersistent]
        public virtual string AnnouncementEndTime
        {
            get { return AnnouncementEndHour.ToString("D2") + ":" + AnnouncementEndMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                AnnouncementEndHour = Convert.ToInt32(timeItems[0]);
                AnnouncementEndMinute = Convert.ToInt32(timeItems[1]);
            }
        }

        [NonPersistent]
        public virtual DateTime AnnouncementStartDateTime
        {
            get
            {
                //if (AnnouncementStartDate == null)
                //    return false;
                    DateTime systemDateTime = AnnouncementStartDate.ToSystemDateTime();
                    return new DateTime(systemDateTime.Year, systemDateTime.Month, systemDateTime.Day, AnnouncementStartHour, AnnouncementStartMinute, 0);             
            }
        }
        [NonPersistent]
        public virtual DateTime AnnouncementEndDateTime
        {
            get
            {
                DateTime systemDateTime = AnnouncementEndDate.ToSystemDateTime();
                return new DateTime(systemDateTime.Year, systemDateTime.Month, systemDateTime.Day, AnnouncementEndHour, AnnouncementEndMinute, 0);
            }
        }
        public virtual bool CanViewAnnouncement()
        {


            DateTime now = DateTime.Now;
            if(DateTime.TryParse(AnnouncementStartDateTime.ToString(),out var date))
            //if(!=null)
            return now >= AnnouncementStartDateTime && now <= AnnouncementEndDateTime;
            return false;


        }
        [NonPersistent]
        public virtual string Code
        {
            get
            {
                if (EducationalCode != null)
                    return EducationalCode.Code;
                return "";
            }
        }

        [NonPersistent]
        public virtual Participate MasterParticipate
        {
            get
            {
                if(Participates.Count == 1)
                    return Participates[0];
                return null;
            }
        }

//        [NonPersistent]
//        public virtual RegisterParticipation RegisterParticipation
//        {
//            get
//            {
//                if (Participates.Count > 0)
//                    return RegisterParticipation.ClassAndGeneralExams;
//                if (Participates.Count == 0 && GetGeneralExamEnrollments().Count() > 0)
//                    return RegisterParticipation.GeneralExamsOnly;
//                return RegisterParticipation.ClassAndGeneralExams;
//            }
//        }

        [NonPersistent]
        public virtual string TypeText
        {
            get { return Type.ToDescription(); }
        }

        [EventClassProperty("نوع ثبت نام")]
        [NonPersistent]
        public virtual string StatusText
        {
            get
            {
                if(Type == RegisterType.Participation)
                {
                    return Major.Department.BuildRegisterExpression(this);
//                    Participate lastParticipate = GetLastParticipate();
//                    if(lastParticipate != null)
//                    {
//                        string lessonText = GetParticipatedLessons().Count() == 1 ? lastParticipate.SectionItem.Item.Lesson.Name : "";
//                        return Major.Name + " - " + lessonText + lastParticipate.SectionItem.Section.FarsiName;
//                    }
//                    return Major.Name;
                }
                if(Type == RegisterType.TermVacation)
                    return "مرخصی ترم " + Period.Name;
                if (Type == RegisterType.PartialVacation)
                    return string.Format("مرخصی مقطعی از تاریخ {0} تا تاریخ {1} ", StartDate, EndDate);
                if (Type == RegisterType.FullQuited)
                    return "انصراف کامل";
                if (Type == RegisterType.Transmition)
                    return "انتقال به شعبه "+Transition.BranchName;
                return "نا مشخص";
            }
        }

        [NonPersistent]
        public virtual string EnrollmentTypeText
        {
            get
            {
                if (InternetRegisteration)
                    return "اینترنتی";
                return "حضوری";
            }
        }

        [NonPersistent]
        public virtual string MasterParticipateEnrollmentTypeText
        {
            get
            {
                if (MasterParticipate != null && InternetRegisteration)
                    return "اینترنتی";
                return "حضوری";
            }
        }

        [NonPersistent]
        public virtual int FullQuitedSign
        {
            get
            {
                if (Type == RegisterType.FullQuited)
                    return 1;
                return 0;
            }
        }

        [NonPersistent]
        public virtual long QuitPenaltyFee
        {
            get
            {
                if (Type == RegisterType.FullQuited && Quit != null)
                    return Quit.PenaltyFee;
                return 0;
            }
        }

        [NonPersistent]
        public virtual long QuitPaidAmount
        {
            get
            {
                if (Type == RegisterType.FullQuited && Quit != null)
                    return Quit.FinancialItem.Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual int TransitionSign
        {
            get
            {
                if (Type == RegisterType.Transmition)
                    return 1;
                return 0;
            }
        }

        [NonPersistent]
        public virtual long TransitionPenaltyFee
        {
            get
            {
                if (Type == RegisterType.Transmition && Transition != null)
                    return Transition.PenaltyFee;
                return 0;
            }
        }

        [NonPersistent]
        public virtual long TransitionPaidAmount
        {
            get
            {
                if (Type == RegisterType.Transmition && Transition != null)
                    return Transition.FinancialItem.Amount;
                return 0;
            }
        }
        [NonPersistent]
        public virtual int ParticipationSign
        {
            get
            {
                if (Type == RegisterType.Participation)
                    return 1;
                return 0;
            }
        }

        [NonPersistent]
        public virtual string RegisterParticipationText
        {
            get
            {
                return GetRegisterParticipation(false, false).ToDescription();
//                return RegisterParticipation.ToDescription();
            }
        }

        [NonPersistent]
        public virtual string ParticipationText
        {
            get
            {
                string txt = "";
                if (!string.IsNullOrEmpty(ParticipatesText))
                    txt += ParticipatesText;
                if (!string.IsNullOrEmpty(ParticipatesText) && !string.IsNullOrEmpty(GeneralExamsText))
                    txt += "\r\n";
                if (!string.IsNullOrEmpty(GeneralExamsText))
                    txt += GeneralExamsText;
                return txt;
            }
        }

        [NonPersistent]
        public virtual string ParticipatesText
        {
            get
            {
                string txt = "";
                foreach (Participate participate in Participates)
                {
                    txt += participate.SectionItem.Item.Lesson.Name + " (" + participate.SectionItem.Section.FarsiName +
                           ")";
                    if (Participates.IndexOf(participate) != Participates.Count - 1)
                        txt += "، ";
                }
                return txt;
            }
        }

        [NonPersistent]
        public virtual string GeneralExamsText
        {
            get
            {
                IList<Enrollment> generalExamEnrollments = GetGeneralExamEnrollments().ToList();
                string txt = "";
                if (generalExamEnrollments.Count > 0)
                {
                    txt = generalExamEnrollments.Count + " آزمون";
                    txt += "(";
                    foreach (Enrollment examEnrollment in generalExamEnrollments)
                    {
                        txt += (examEnrollment.TrainingItem as ExamTrainingItem).Name;
                        if (generalExamEnrollments.IndexOf(examEnrollment) != generalExamEnrollments.Count - 1)
                            txt += "، ";
                    }
                    txt += ")";
                }
                return txt;
            }
        }

        [NonPersistent]
        public virtual string FinancialCommitmentText
        {
            get
            {
                string txt = "";
                foreach (FinancialCommitment commitment in FinancialCommitments)
                    txt += commitment.Text + " ";
                return txt;
            }
        }

        #region Overrides of FinancialEntity

        [NonPersistent]
        public override long PayableTuition
        {
            get
            {
                if(Type == RegisterType.Participation)
                {
                    try
                    {
                        return Tuition;
//                        long sum = 0;
//                    
//                        IQueryable<Section> participatedSections = GetParticipatedSections();
//                        sum += participatedSections.Where(x => x != null).Sum(x => x.GetTuitionFee(Major));
//
//                        IQueryable<Enrollment> examEnrollments = GetGeneralExamEnrollments();
//                        sum += examEnrollments.Where(x => x != null).Sum(x => x.GetTuitionFee());
//                        return sum;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                if (Type == RegisterType.TermVacation)
                    return Period.VacationFee;
                if(Type == RegisterType.PartialVacation)
                    return Period.VacationFee;
                if (Type == RegisterType.FullQuited||Type==RegisterType.Transmition)
                    return 0;
                throw new Exception("مقدار شهریه پرداختی مشخص نیست.");
            }
        }

        [NonPersistent]
        public override FinancialHeading Heading
        {
            get { return FinancialHeading.Signup; }
        }

        #endregion

        #region Static Members

//        public static string GetCode2(Major major, EducationalPeriod period)
//        {
//            string preCode = period.Code.Substring(0, 2) + major.Department.Code + "" + major.Code;
//
//            var query1 = from Register reg in DbContext.Entity<Register>()
//                        where reg.Code.StartsWith(preCode)
//                        orderby reg.Code descending
//                        select reg.Code;
//
//            var query2 = from Reserve reserve in DbContext.Entity<Reserve>()
//                         where reserve.Code.StartsWith(preCode)
//                         orderby reserve.Code descending
//                         select reserve.Code;
//
//            List<string> list1 = query1.ToList();
//            List<string> list2 = query2.ToList();
//            List<string> allCodes = list1.Union(list2).ToList();
//
//            var query3 = from code in allCodes
//                         where code.Length == preCode.Length + 3
//                         orderby code descending
//                         select code;
//            var query3 = from Register reg in allCodes
//                         where reg.Code.Length == preCode.Length + 3
//                         orderby reg.Code descending
//                         select reg;
//
//            string num = "101";
//            int count = query3.Count();
//            if(count > 0)
//            {
//                Register first = query3.First();
//                string firstCode = query3.First();
//                num = first.Code.Substring(preCode.Length);
//                num = firstCode.Substring(preCode.Length);
//                num = int.Parse(num) + 1 + "";
//            }
//            return preCode + num;
//        }

        public static List<Register> GetRegisters(Department department, PersianDate registerStartDate, PersianDate registerEndDate)
        {
            var query = from register in DbContext.Entity<Register>()
                        where register.Student != null
                        && register.Major.Department.Id == department.Id 
                        && register.RegisterDate >= registerStartDate 
                        && register.RegisterDate <= registerEndDate
                        select register;
            return query.ToList();
        }

        public static List<Register> FromCode(string code)
        {
            var query = from register in DbContext.Entity<Register>()
                        where register.Student != null
                        && register.EducationalCode.Code == code
                        select register;
            return query.ToList();
        }

        public static IList<Register> GetRegisters(PersianDate registerStartDate, PersianDate registerEndDate)
        {
            var query = from register in DbContext.Entity<Register>()
                        where register.Student != null
                        && register.RegisterDate >= registerStartDate 
                        && register.RegisterDate <= registerEndDate
                        select register;
            return query.ToList();
        }

        public static IList<Register> GetRegisters(Major major, PersianDate registerStartDate, PersianDate registerEndDate)
        {
            var query = from register in DbContext.Entity<Register>()
                        where register.Student != null
                        && register.Major.Id == major.Id
                        && register.RegisterDate >= registerStartDate 
                        && register.RegisterDate <= registerEndDate
                        select register;
            return query.ToList();
        }

        public static IList<Register> GetRegisters(EducationalPeriod period, Major major)
        {
            var query = GetRegistersQuery(period, major);
            return query.ToList();
        }
        public static IList<Register> GetRegisters()
        {
            var query = GetRegistersQuery();
            return query.ToList();
        }

        public static IQueryable<Register> GetRegistersQuery(EducationalPeriod period, Major major)
        {
            var query = from register in DbContext.Entity<Register>()
                        where register.Student != null
                              && register.Period.Id == period.Id
                              && register.Major.Id == major.Id
                        select register;
            return query;
        }
        public static IQueryable<Register> GetRegistersQuery()
        {
            var query = from register in DbContext.Entity<Register>()
                        where register.Student != null
                        select register;
            return query;
        }

        public static IList<Register> GetRegisters(EducationalPeriod period)
        {
            var query = from register in DbContext.Entity<Register>()
                        where register.Student != null
                              && register.Period.Id == period.Id
                        select register;
            return query.ToList();
        }

        public static List<Register> Search(string firstName, string lastName)
        {
            List<Register> result = new List<Register>();

            var query = from register in DbContext.Entity<Register>()
                        where register.Student != null
                        && register.Student.FarsiFirstName == firstName 
                        && register.Student.FarsiLastName == lastName
                        select register;
            result.UniqueAddRange(query.ToList());

            query = from register in DbContext.Entity<Register>()
                    where register.Student != null
                    && register.Student.FarsiFirstName.StartsWith(firstName) 
                    && register.Student.FarsiLastName.StartsWith(lastName)
                    select register;
            result.UniqueAddRange(query.ToList());

            query = from register in DbContext.Entity<Register>()
                    where register.Student != null
                    && register.Student.FarsiFirstName.Contains(firstName) 
                    && register.Student.FarsiLastName.Contains(lastName)
                    select register;
            result.UniqueAddRange(query.ToList());

            return result;
        }

        public static List<Register> SearchByFirstname(string firstName)
        {
            List<Register> result = new List<Register>();
            if(string.IsNullOrEmpty(firstName))
                return result;

            var query = from register in DbContext.Entity<Register>()
                        where register.Student != null
                        && register.Student.FarsiFirstName == firstName
                        select register;
            result.UniqueAddRange(query.ToList());

            query = from register in DbContext.Entity<Register>()
                    where register.Student != null
                    && register.Student.FarsiFirstName.StartsWith(firstName)
                    select register;
            result.UniqueAddRange(query.ToList());

            return result;
        }

        public static List<Register> SearchByLastname(string lastName)
        {
            List<Register> result = new List<Register>();
            if (string.IsNullOrEmpty(lastName))
                return result;

            var query = from register in DbContext.Entity<Register>()
                        where register.Student != null
                        && register.Student.FarsiLastName == lastName
                        select register;
            result.UniqueAddRange(query.ToList());

            query = from register in DbContext.Entity<Register>()
                    where register.Student != null
                    && register.Student.FarsiLastName.StartsWith(lastName)
                    select register;
            result.UniqueAddRange(query.ToList());

            return result;
        }

        public static IQueryable<Register> GetEntryRegisters(PersianDate startDate, PersianDate endDate)
        {
            IList<Register> registers = GetRegisters(startDate, endDate);
            var query2 = from register in registers
                         where register.Participates.Count == 1 && register.Student.Registers.Count == 1
                         select register;
            return query2.AsQueryable();
        }

        public static IQueryable<Register> GetEntryRegisters(PersianDate startDate, PersianDate endDate, Major major)
        {
            var query2 = from register in GetEntryRegisters(startDate, endDate)
                         where register.Major != null && register.Major.Id == major.Id
                         select register;
            return query2.AsQueryable();
        }

        public static IQueryable<Register> GetFullQuitedRegisters(PersianDate startDate, PersianDate endDate)
        {
            IList<Register> registers = GetRegisters(startDate, endDate);
            var query = from register in registers
                         where register.Type == RegisterType.FullQuited
                         orderby register.Major.Name
                         select register;
            return query.AsQueryable();
        }

        public static IQueryable<Register> GetFullQuitedRegisters(Major major, PersianDate startDate, PersianDate endDate)
        {
            IList<Register> registers = GetRegisters(major, startDate, endDate);
            var query = from register in registers
                         where register.Type == RegisterType.FullQuited
                         orderby register.Major.Name
                         select register;
            return query.AsQueryable();
        }
        public static IQueryable<Register> GetTransmitionedRegisters(PersianDate startDate, PersianDate endDate)
        {
            var registers = from register in DbContext.Entity<Register>()
                            where register.Student != null
                            select register;
            var query = from register in registers
                        where register.Type == RegisterType.Transmition 
                        && register.Transition.Date <= endDate && register.Transition.Date >= startDate
                        orderby register.Major.Name
                        select register;
            return query.AsQueryable();
        }
        public static IQueryable<Register> GetTransmitionedRegisters(Branch branch, PersianDate startDate, PersianDate endDate)
        {
            var registers = from register in DbContext.Entity<Register>()
                                        where register.Student != null 
                                        select register;
            var query = from register in registers
                        where register.Type == RegisterType.Transmition && register.Transition.Branch==branch
                        && register.Transition.Date<=endDate && register.Transition.Date>=startDate
                        orderby register.Major.Name
                        select register;
            return query.AsQueryable();
        }
        public static IQueryable<Register> GetTransmitionedRegisters(Major major, PersianDate startDate, PersianDate endDate)
        {
            var registers = from register in DbContext.Entity<Register>()
                            where register.Student != null && register.Major.Id==major.Id
                            select register;
            var query = from register in registers
                        where register.Type == RegisterType.Transmition
                         && register.Transition.Date <= endDate && register.Transition.Date >= startDate
                        orderby register.Major.Name
                        select register;
            return query.AsQueryable();
        }


        public static IQueryable<Register> GetVacationedRegisters(EducationalPeriod period, Major major)
        {
            IList<Register> registers = GetRegisters(period, major);
            var query = from register in registers
                         where register.Type == RegisterType.TermVacation
                         || register.Type == RegisterType.PartialVacation 
                         select register;
            return query.AsQueryable();
        }

        public static IQueryable<Register> GetDebtorRegisters(IList<Register> registers)
        {
            var query = from register in registers
                        where register.DebtAmount > 0
                        select register;
            return query.AsQueryable();
        }

        public static IQueryable<Register> GetCreditorRegisters(IList<Register> registers)
        {
            var query = from register in registers
                        where register.FinancialDocument.PayedBalance > register.PayableTuition
                        select register;
            return query.AsQueryable();
        }

        public static IList<Register> GetIncompletedRegisters(EducationalPeriod period, Major major)
        {
            var query = from register in DbContext.Entity<Register>()
                        where register.Period.Id == period.Id
                        && register.Major.Id == major.Id
                        && register.Student.IsIncomplete
                        select register;
            return query.ToList();
        }

        public static IList<Register> GetImageLessRegisters(EducationalPeriod period, Major major)
        {
            var query = from register in DbContext.Entity<Register>()
                        where register.Period.Id == period.Id
                        && register.Major.Id == major.Id
                        && register.Quit == null
                        &&register.Transition==null
                        && register.Student.Photo.PictureBytes == null
                        select register;
            return query.ToList();
        }
        public static IList<Register> GetIDImageLessRegisters(EducationalPeriod period, Major major)
        {
            var query = from register in DbContext.Entity<Register>()
                        where register.Period.Id == period.Id
                        && register.Major.Id == major.Id
                        && register.Quit == null
                        && register.Transition == null
                        && register.Student.Photo.IDPictureBytes == null
                        select register;
            return query.ToList();
        }

        public static IList<Register> GetNCImageLessRegisters(EducationalPeriod period, Major major)
        {
            var query = from register in DbContext.Entity<Register>()
                        where register.Period.Id == period.Id
                        && register.Major.Id == major.Id
                        && register.Quit == null
                        && register.Transition == null
                        && (register.Student.Photo.NCPictureBytes1 == null || register.Student.Photo.NCPictureBytes1 == null)
                        select register;
            return query.ToList();
        }
        public static IList<Register> GetImageLessRegisters(EducationalPeriod period, Lesson lesson)
        {
            
            var query = from participate in Participate.GetParticipates(period, lesson)
                        where participate.Register.Student.Photo.PictureBytes == null
                        select participate.Register;
            return query.ToList();
        }
        public static IList<Register> GetIDImageLessRegisters(EducationalPeriod period, Lesson lesson)
        {

            var query = from participate in Participate.GetParticipates(period, lesson)
                        where participate.Register.Student.Photo.IDPictureBytes == null
                        select participate.Register;
            return query.ToList();
        }
        public static IList<Register> GetNCImageLessRegisters(EducationalPeriod period, Lesson lesson)
        {

            var query = from participate in Participate.GetParticipates(period, lesson)
                        where participate.Register.Student.Photo.NCPictureBytes1 == null || participate.Register.Student.Photo.NCPictureBytes2 == null
                        select participate.Register;
            return query.ToList();
        }

        #endregion

        [NonPersistent]
        public virtual long Tuition
        {
            get
            {
                long sum = 0;

                IQueryable<Section> participatedSections = GetParticipatedSections();
                sum += participatedSections.Where(x => x != null).Sum(x => x.GetTuitionFee(Major));

                IQueryable<Enrollment> examEnrollments = GetGeneralExamEnrollments();
                sum += examEnrollments.Where(x => x != null).Sum(x => x.GetTuitionFee());
                return sum;
            }
        }

        public virtual IQueryable<Participate> GetParticipatesQuery()
        {
            var query = from participate in DbContext.Entity<Participate>()
                        where participate.Register != null
                              && participate.Register.Id == Id
                        select participate;
            return query;
        }

        public virtual void AddParticipate(Participate participate)
        {
            Participates.Add(participate);
            FinancialDocument.Items.Add(participate.FinancialItem);
        }        
        
        public virtual void RemoveParticipate(Participate participate)
        {
            participate.Register = null;
            Participates.Remove(participate);
            FinancialDocument.Items.Remove(participate.FinancialItem);
        }

        public virtual void RemoveExamParticipate(ExamParticipate examParticipate)
        {
            examParticipate.Register = null;
//            ExamParticipates.Remove(examParticipate);
        }

        public virtual void AddEnrollment(Enrollment enrollment)
        {
            enrollment.Register = this;
            Enrollments.Add(enrollment);
        }

        public virtual IQueryable<Section> GetParticipatedSections()
        {
            var query = from participate in Participates
                        group participate by participate.SectionItem.Section
                        into section
                        select section.Key;
            return query.AsQueryable();
        }

        public virtual IQueryable<SectionItem> GetParticipatedSectionItems()
        {
            var query = from participate in Participates
                        group participate by participate.SectionItem
                        into sectionItem
                        select sectionItem.Key;
            return query.AsQueryable();
        }

        public virtual IEnumerable<Lesson> GetParticipatedLessons()
        {
            var query = from participate in Participates
                        group participate by participate.SectionItem.Item.Lesson
                        into g
                        select g.Key;
            return query.AsQueryable();
        }

        public virtual IQueryable<Enrollment> GetGeneralExamEnrollments()
        {
            var query = from enrollment in Enrollments
                        where enrollment.TrainingItem is ExamTrainingItem
                              && (enrollment.TrainingItem as ExamTrainingItem).IsGeneral
                        select enrollment;
            return query.AsQueryable();
        }

        public virtual IQueryable<Enrollment> GetPostalEnrollments()
        {
            var query = from enrollment in Enrollments
                        where enrollment.TrainingItem is PostalTrainingItem
                        select enrollment;
            return query.AsQueryable();
        }

        public virtual KeyValuePair<PersianDate, object>? GetLastActivity()
        {
            List<KeyValuePair<PersianDate, object>> activities = new List<KeyValuePair<PersianDate, object>>();

            activities.Add(new KeyValuePair<PersianDate, object>(RegisterDate, this));
            if (FullQuitedSign > 0)
                activities.Add(new KeyValuePair<PersianDate, object>(Quit.Date, Quit));
            if(TransitionSign>0)
                activities.Add(new KeyValuePair<PersianDate, object>(Transition.Date, Transition));
            Participate lastParticipate = GetLastParticipate();
            if (lastParticipate != null)
                activities.Add(new KeyValuePair<PersianDate, object>(lastParticipate.Date, lastParticipate));
            ExamParticipate lastExamParticipate = GetLastExamParticipate();
            if (lastExamParticipate != null)
                activities.Add(new KeyValuePair<PersianDate, object>(lastExamParticipate.RegisterDate, lastExamParticipate));

            var query = from pair in activities
                        orderby pair.Key descending
                        select pair;
            if (query.Count() > 0)
                return query.First();
            return null;
        }

        public virtual PersianDate GetLastActivityDate()
        {
            KeyValuePair<PersianDate, object>? lastActivity = GetLastActivity();
            if (lastActivity == null)
                return null;
            return lastActivity.Value.Key;
        }

        public virtual Participate GetLastParticipate()
        {
            var query = from participate in Participates
                        orderby participate.Date descending
                        select participate;
            return query.FirstOrDefault();
        }

        public virtual Participate GetLastParticipate(Lesson lesson)
        {
            return GetParticipates(lesson).LastOrDefault();
        }

        public virtual Participate GetFirstParticipate(Lesson lesson)
        {
            return GetParticipates(lesson).FirstOrDefault();
        }        
        
        public virtual IQueryable<Participate> GetParticipates(Lesson lesson)
        {
            var query = from participate in Participates
                        where participate.SectionItem.Item.Lesson.Id == lesson.Id
                        select participate;
            return query.AsQueryable();
        }

        public virtual Participate CreateParticipate()
        {
            Participate participate = new Participate { Register = this };
            return participate;
        }

        public virtual Enrollment CreateEnrollment()
        {
            Enrollment enrollment = new Enrollment { Register = this };
            return enrollment;
        }

        public virtual List<Participate> GetParticipates(ParticipateStatus status)
        {
            var query = from participate in Participates
                        from formation in participate.SectionItem.Section.Formations
                        where participate.Status == status
                        orderby formation.Day , formation.Time
                        group participate by participate into g
                        select g.Key;
            return query.ToList();
        }

        public virtual Enrollment Enroll(TrainingItem item)
        {
            Enrollment enrollment = CreateEnrollment();
            enrollment.TrainingItem = item;
            return enrollment;
        }

        public virtual Enrollment GetEnrollment(TrainingItem item)
        {
            var query = from enrollment in Enrollments
                        where enrollment.TrainingItem != null 
                            && enrollment.TrainingItem.Id == item.Id
                        select enrollment;
            return query.FirstOrDefault();
        }

        public virtual bool IsEnrolled(TrainingItem item)
        {
            return GetEnrollment(item) != null;

//            var query = from enrollment in Enrollments
//                        where enrollment.TrainingItem.Id == item.Id
//                        select enrollment;
//            return query.Count() > 0;
        }

        public virtual void UpdateGeneralEnrollments()
        {
            var query = from enrollment in Enrollments
                        where enrollment.TrainingItem == null
                        select enrollment;
            Enrollments = Enrollments.Except(query).ToList();
        }

        public virtual void UpdateParticipateEnrollments()
        {
            UpdateGeneralEnrollments();

            var query = from enrollment in Enrollments
                        where enrollment.TrainingItem is SectionTrainingItem
                        select enrollment;
            var query2 = from participate in Participates
                         select participate.Enrollment;
            
            Enrollments = Enrollments.Except(query).ToList();

            foreach (Participate participate in Participates)
            {
                if (participate.Enrollment == null)
                {
                    Enrollment enrollment = participate.Register.Enroll(participate.SectionItem.Item);
                    enrollment.Date = participate.Date;
                    participate.Enrollment = enrollment;
                }
                if (!Enrollments.Contains(participate.Enrollment))
                    AddEnrollment(participate.Enrollment);
            }


//            IEnumerable<Enrollment> removingEnrollments = query.Except(query2);
//            var q = from enrollment in Enrollments
//                    from removingEnrollment in removingEnrollments
//                    where enrollment != removingEnrollment
//                    select enrollment;
//
//            List<Enrollment> enrollments = q.ToList();
//            Enrollments = enrollments.Union(Enrollments.Where(x=>x.TrainingItem is ExamTrainingItem).Select(x=>x)).ToList();
        }

        public virtual void UpdateExamEnrollments(IList<Exam> exams)
        {
            List<ExamTrainingItem> items = new List<ExamTrainingItem>();
            foreach (Exam exam in exams)
                items.Add(exam.ExamTrainingItem);
            UpdateExamEnrollments(items);
        }

        public virtual void UpdateExamEnrollments(IList<ExamTrainingItem> items)
        {
            UpdateGeneralEnrollments();

            foreach (ExamTrainingItem trainingItem in items)
            {
                if (!IsEnrolled(trainingItem))
                {
                    Enrollment enrollment = Enroll(trainingItem);
                    AddEnrollment(enrollment);
                }
            }

            for (int i = Enrollments.Count - 1; i >= 0; i--)
            {
                Enrollment enrollment = Enrollments[i];
                if(!(enrollment.TrainingItem is ExamTrainingItem))
                    continue;
                bool found = false;
                foreach (ExamTrainingItem examTrainingItem in items)
                    if (enrollment.TrainingItem == examTrainingItem)
                        found = true;
                if (!found)
                    Enrollments.Remove(enrollment);
            }

            List<Enrollment> enrollments = new List<Enrollment>();
            foreach (Enrollment enrollment in Enrollments)
            {
                if (!(enrollment.TrainingItem is ExamTrainingItem))
                    continue;
                if (enrollment.TrainingItem.Lesson.Major.Id != Major.Id)
                    enrollments.Add(enrollment);
            }
            Enrollments = Enrollments.Except(enrollments).ToList();
        }

//        public virtual void SyncParticipation()
//        {
//            if (Participates.Count > 0)
//                RegisterParticipation = RegisterParticipation.ClassAndGeneralExams;
//            else if (Participates.Count == 0 && GetGeneralExamEnrollments().Count() > 0)
//                RegisterParticipation = RegisterParticipation.GeneralExamsOnly;
//            else
//                RegisterParticipation = RegisterParticipation.ClassAndGeneralExams;
//        }

        /// <summary>
        /// Only 1 Parameter allowed to be TRUE !
        /// </summary>
        /// <param name="forParticipate"></param>
        /// <param name="forExamParticipate"></param>
        /// <returns></returns>
        public virtual RegisterParticipation GetRegisterParticipation(bool forParticipate, bool forExamParticipate/*, bool forPostal*/)
        {
            if(Participates.Count == 0)
            {
                if (forParticipate)
                    return RegisterParticipation.ClassAndGeneralExams;
                if (forExamParticipate)
                    return RegisterParticipation.GeneralExamsOnly;

                
//                if(forPostal)
//                    return RegisterParticipation.Postal;
//                if(GetPostalEnrollments().Any())
//                    return RegisterParticipation.Postal;


                if (GetGeneralExamEnrollments().Any())
                    return RegisterParticipation.GeneralExamsOnly;
            }
            return RegisterParticipation.ClassAndGeneralExams;
        }

        public virtual Participate Signup(SectionItem signupItem, bool isSpecialCase)
        {
            if(!isSpecialCase)
                Student.SignupCheck(Period, signupItem.Lesson);

            if (Student.SignedUpIn(signupItem))
                throw new Exception(string.Format("{0} قبلا در {1} و در درس/سطح {2} ثبت نام شده است.", Student.FarsiFullname, signupItem.Section.FarsiName, signupItem.Lesson.Name));

            string specialCaseText = isSpecialCase ? " موارد خاص" : "";
            FinancialItem item = new FinancialItem(FinancialType.Debt)
            {
//                Amount = signupItem.GetTuitionFee(Major, RegisterParticipation),
                Amount = signupItem.GetTuitionFee(Major, GetRegisterParticipation(true, false)),
                Text = string.Format("گروه بندی {0} {1} در {2} درس/سطح {3}", specialCaseText, Student.FarsiFullname, signupItem.Section.Name, signupItem.Lesson.Name),
                Heading =  FinancialHeading.Signup
            };

            Participate participate = CreateParticipate();
            participate.SectionItem = signupItem;
            participate.FinancialItem = item;
            participate.IsSpecialCase = isSpecialCase;

            Enrollment enrollment = Enroll(signupItem.Item);
            participate.Enrollment = enrollment;

            return participate;
        }

        public override string ToString()
        {
            //return Student.FarsiFullname + " (" + Period.Name + ")";
            return  " " + Period.Name;
        }

        public override void BeforeSave()
        {
            if (EducationalCode == null)
            {
                EducationalCode = Student.GenerateCode(Period, Major, false);
                EducationalCode.SavePartially();
            }

//            if (string.IsNullOrEmpty(Code) || Code == "0")
//                Code = Student.GenerateCode(Period, Major, false);
        }

        public virtual float CalculateMark(Lesson lesson)
        {
            if(lesson.HoldingType == HoldingType.Lesson)
            {
                Participate participate = GetLastParticipate(lesson);
                if (participate != null)
                    return participate.CalculateMark();
            }

            if(lesson.HoldingType == HoldingType.Exam)
            {
                ExamParticipate participate = GetExamParticipates(lesson).LastOrDefault();
                if(participate != null)
                    return participate.CalculateMark();
            }
            throw new Exception("Cannot Find correct participate");
        }

        public virtual ExamParticipate GetLastExamParticipate()
        {
            var query = from participate in GetExamParticipates()
                        orderby participate.RegisterDate descending
                        select participate;
            return query.FirstOrDefault();
        }

        public virtual void UseExamParticipatesCache()
        {
            mExamParticipatesCache = true;
        }

        public virtual IQueryable<ExamParticipate> GetExamParticipates()
        {
            var query = from examParticipate in DbContext.Entity<ExamParticipate>()
                        where examParticipate.Register != null
                              && examParticipate.Register.Id == Id
                        select examParticipate;

            if (mExamParticipatesCache)
            {
                if (mExamParticipates == null)
                    mExamParticipates = query.ToList();

                return mExamParticipates.AsQueryable();
            }

            return query;
        }

        public virtual IQueryable<ExamParticipate> GetExamParticipates(Lesson lesson)
        {
            var query = from participate in GetExamParticipates()
                        where participate.ExamForm.Exam.Lesson.Id == lesson.Id
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<ExamParticipate> GetExamParticipates(Enrollment enrollment)
        {
            var query = from participate in GetExamParticipates()
                        where participate.Enrollment != null
                        && participate.Enrollment.Id == enrollment.Id
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<ExamParticipate> GetAbsentExamParticipates()
        {
            List<ExamParticipate> examParticipates = GetExamParticipates().ToList();
            var query = from examParticipate in examParticipates
                        where examParticipate.IsAbsent
                        select examParticipate;
            return query.AsQueryable();
        }

        public virtual Lesson GetEnrollableLessonsTest()
        {
            return Student.GetEnrollableLessons(Major, Period, true, true).FirstOrDefault();
        }

        public virtual Register GetPrevRegister()
        {
            List<Register> majorRegisters = Student.GetRegisters(Major);

            return majorRegisters.OrderByDescending(x => x.RegisterDate)
                .Except(majorRegisters.Where(x => x.RegisterDate >= RegisterDate))
                .FirstOrDefault();

//            return Student.GetRegisters(Major).Except(new[] {this})
//                    .OrderByDescending(x => x.RegisterDate)
//                        .FirstOrDefault();
        }

        public virtual void ConfirmEnrollment()
        {
            foreach (Participate participate in Participates)
                participate.ConfirmEnrollment();
            EnrollmentConfirmed = true;
        }

        public static Register FromId(int id)
        {
            return DbContext.FromId<Register>(id);
        }

        public virtual IQueryable<Exam> GetRegisteredExams()
        {
            var query = from particiapte in GetExamParticipates()
                        select particiapte.ExamForm.Exam;
            return query.AsQueryable();
        }

        public virtual IList<Exam> GetEnrollableExams(ExamType type, bool isGeneral, bool excludeRegisteredExams,
            PersianDate date)
        {
            List<Exam> exams = Exam.GetExams(Period, Major, type);
            var query = from exam in exams
                        where exam.InternetRegisterable
                            && exam.IsGeneral == isGeneral
                            && date >= exam.InternetRegisterStartDate
                            && date <= exam.InternetRegisterFinishDate
                        select exam;
            if(excludeRegisteredExams)
                return query.Except(GetRegisteredExams()).ToList();

            return query.ToList();
        }
        public virtual IList<Exam> GetEnrollableExams(ExamType type, bool isGeneral, bool excludeRegisteredExams,
          PersianDate date,int hour,int minute)
        {
            DateTime nowDateTime = date.ToSystemDateTime();
            DateTime now = new DateTime(nowDateTime.Year, nowDateTime.Month, nowDateTime.Day, hour, minute, 0);
            List<Exam> exams = Exam.GetExams(Period, Major, type);
            var query = from exam in exams
                        where exam.InternetRegisterable
                            && exam.IsGeneral == isGeneral
                            && now >= exam.InternetRegisterStartDateTime
                            && now <= exam.InternetRegisterFinishDateTime

                        select exam;
            if (excludeRegisteredExams)
                return query.Except(GetRegisteredExams()).ToList();

            return query.ToList();
        }
        public virtual IList<PreEnrollmentList> GetEnrollableList(
       PersianDate date, int hour, int minute)
        {
            DateTime nowDateTime = date.ToSystemDateTime();
            DateTime now = new DateTime(nowDateTime.Year, nowDateTime.Month, nowDateTime.Day, hour, minute, 0);
            var list = PreEnrollmentList.GetLists(Major);
            var query = from exam in list
                        where exam.InternetRegisterable

                            && now >= exam.InternetRegisterStartDateTime
                            && now <= exam.InternetRegisterFinishDateTime

                        select exam;


            return query.ToList();
        }
    }

    public enum RegisterType
    {
        [EnumDescription("مجـاز بـه تحصیـل")]
        Participation,
        [EnumDescription("انصراف کامل")]
        FullQuited,
       
        [EnumDescription("مرخصی ترم")]
        TermVacation,
        [EnumDescription("مرخصی مقطعی")]
        PartialVacation,
             [EnumDescription("انتقال")]
        Transmition,
        [EnumDescription("ثبت نام مجدد")]
        RegisterAgain
    }

    public enum RegisterParticipation
    {
        [EnumDescription("کلاس و آزمون")]
        ClassAndGeneralExams,
        [EnumDescription("فقط آزمون")]
        GeneralExamsOnly,
//        [EnumDescription("آموزش مکاتبه ای")]
//        Postal,
    }
}