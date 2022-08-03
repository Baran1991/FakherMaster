using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DataAccessLayer;
using Fakher.Core.Website;
using NHibernate.Linq;
using rApplicationEventFramework;
using rComponents;
using Fakher.Core.DomainModel.Consult;
using System.Data;
using System.Data.SqlClient;

namespace Fakher.Core.DomainModel
{
    [EventClass("پرونده دانشجویی")]
    public class Student : Person
    {
        public virtual int EntranceMark { get; set; }
        public virtual long BayganiNo { get; set; } = 0;
        public virtual PersianDate BayganiDate { get; set; } = PersianDate.Today;
        public virtual Person BayganiCreatedBy { get; set; }
        public virtual IList<StudentConfiguration> Configurations { get; set; }
        /// <summary>
        /// ثبت نام در فرآیند آموزشی جاری موسسه در یک ترم در یک رشته
        /// </summary>
        public virtual IList<Register> Registers { get; set; }
        /// <summary>
        /// ثبت نام در یک آزمون که کاملا خارج از فرآیند آموزشی موسسه است. اگر آزمون قرار است درون یک فرآیند باشد
        /// باید برای آن Lesson از نوع آزمون ساخته شود.
        /// </summary>
        public virtual IList<Reserve> Reserves { get; set; }
        public virtual IList<Request> Requests { get; set; }
        public virtual IList<Consultation> Consultations { get; set; }
        public virtual IList<ConsultationApplicant> ConsultationApplicants { get; set; }

        public Student()
        {
            Configurations = new List<StudentConfiguration>();
            Registers = new List<Register>();
            Reserves = new List<Reserve>();
            Requests = new List<Request>();
            Consultations = new List<Consultation>();
            ConsultationApplicants = new List<ConsultationApplicant>();
            BayganiDate = PersianDate.Today;
        }
        [NonPersistent]
        public virtual string BayganiCreatedByName
        {
            get
            {
                return BayganiCreatedBy.FarsiFullname;
            }
        }
        [NonPersistent]
        public override FinancialStatus FinancialStatus
        {
            get
            {
                if (IsDebtor())
                    return FinancialStatus.Debtor;
                if (IsChequePromisor())
                    return FinancialStatus.ChequePromised;
                return FinancialStatus.Balanced;
            }
        }
        public static IList<Major> GetRegisteredMajorsName(Student stu)
        {
            var query = from register in DbContext.Entity<Register>()
                        //where register.Student=stu
                        select register.Major;
           
            return query.ToList();
        }
        public static IList<EducationalPeriod> GetRegisteredPeriodsName()
        {
            var query = from register in DbContext.Entity<Register>()
                        select register.Period;
            return query.ToList();
        }

        public virtual long NextBayganiNo()
        {
            var bayganiNo = DbContext.Entity<Student>().Max(m => m.BayganiNo) + 1;
            return bayganiNo;
        }
        public virtual string GetCurrentCode()
        {
            Register lastRegister = GetLastRegister();
            if (lastRegister != null)
                return lastRegister.EducationalCode + "";
            Reserve lastReserve = GetLastReserve();
            if (lastReserve != null)
                return lastReserve.EducationalCode + "";
            return "";
        }

        public virtual string GetCurrentEducationalStatus()
        {
            try
            {
                Register lastRegister = GetLastRegister();
                Reserve lastReserve = GetLastReserve();

                PersianDate lastRegisterActivityDate = null;
                PersianDate lastReserveActivityDate = null;
                if (lastRegister != null)
                    lastRegisterActivityDate = lastRegister.GetLastActivityDate();
                if (lastReserve != null)
                    lastReserveActivityDate = lastReserve.GetLastActivityDate();

                if (lastRegisterActivityDate != null && lastReserveActivityDate != null)
                {
                    if (lastRegisterActivityDate >= lastReserveActivityDate)
                        return lastRegister.StatusText;
                    return lastReserve.StatusText;
                }


                if (lastRegister != null)
                    return lastRegister.StatusText;
                if (lastReserve != null)
                    return lastReserve.StatusText;
            }
            catch (Exception ex)
            {
                return "خطا";
            }
            return "نامشخص";
        }

        public virtual string GetCurrentFinancialStatus()
        {
            Register lastRegister = GetLastRegister();
            if (lastRegister != null)
            {
                if (lastRegister.Quit != null)
                    if (lastRegister.Quit.FinancialItem != null)
                        if (lastRegister.Quit.FinancialItem.Amount > 0)
                            return "تسویه ";
                return lastRegister.FarsiFinancialStatusVerboseText;
            }
            Reserve lastReserve = GetLastReserve();
            if (lastReserve != null)
                return lastReserve.FarsiFinancialStatusVerboseText;
            return FinancialStatusVerboseText;
        }

        public virtual FinancialDocument GetGeneralDocument()
        {
            FinancialDocument allDocument = new FinancialDocument { Person = this };
            foreach (Register reg in Registers)
            {
                foreach (FinancialItem item in reg.FinancialDocument.Items)
                    allDocument.AddItem(item.Clone());
                if (reg.Quit != null)
                    allDocument.AddItem(reg.Quit.FinancialItem.Clone());
            }

            foreach (Certificate certificate in GetCertificates())
                foreach (FinancialItem item in certificate.FinancialDocument.Items)
                    allDocument.AddItem(item.Clone());

            return allDocument;
        }

        public override IQueryable<FinancialDocument> GetDebtorDocuments()
        {
            IQueryable<Register> registers = GetDebtorRegisters();
            if (registers.Count() > 0)
                return registers.Select(x => x.FinancialDocument);
            return base.GetDebtorDocuments();
        }

        public virtual IQueryable<Request> GetRequests(bool isReplied)
        {
            var query = from request in Requests
                        where request.IsReplied == isReplied
                        select request;
            return query.AsQueryable();
        }

        public override long GetDebtAmount()
        {
            IQueryable<Register> registers = GetDebtorRegisters();

            long amount = 0;
            foreach (Register register in registers)
                amount += register.DebtAmount;

            return amount;
        }

        public virtual List<Register> GetRegisters(EducationalPeriod period)
        {
            var query = from Register register in Registers
                        where register.Period.Id == period.Id
                        select register;
            return query.ToList();
        }

        
        public virtual Register GetRegister(EducationalPeriod period, Major major, RegisterType type)
        {

            var query = from Register register in Registers
                        where register.Period.Id == period.Id && register.Major.Id == major.Id && register.Type == type
                        select register;
            Register result = query.LastOrDefault();
            return result;
        }
        public virtual Register GetRegister(EducationalPeriod period, Major major)
        {
            var query = from Register register in Registers
                        where register.Period.Id == period.Id && register.Major.Id == major.Id
                        select register;
            Register result = query.LastOrDefault();
            return result;
        }

        public virtual IQueryable<Register> GetRegisters(EducationalPeriod period, Major major)
        {
            var query = from Register register in Registers
                        where register.Period.Id == period.Id && register.Major.Id == major.Id
                        select register;
            return query.AsQueryable();
        }

        public virtual IQueryable<Participate> GetParticipates()
        {
            var query = from register in Registers
                        from participate in register.Participates
                        where participate.Quit == null
                        && participate.Register != null
                        orderby participate.Id
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<Participate> GetParticipates(Lesson lesson)
        {
            var query = from register in Registers
                        from participate in register.Participates
                        where participate.Quit == null
                        && participate.Register != null
                        && participate.SectionItem.Lesson.Id == lesson.Id
                        orderby participate.Id
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<Participate> GetParticipates(Major major)
        {
            var query = from register in Registers
                        from participate in register.Participates
                        where register != null
                        && participate.Quit == null
                        && register.Major.Id == major.Id
                        orderby participate.Id
                        select participate;
            return query.AsQueryable();
        }

        /// <summary>
        /// Get Last Lesson Participate Union with equivalent lesson participates order by Date descending
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns></returns>
        public virtual IQueryable<Participate> GetAllParticipates(Lesson lesson)
        {
            IQueryable<Register> registers = GetRegisters(lesson);

            var query = from register in registers
                        from participate in register.GetParticipates(lesson)
                        select participate;

            // Participateha dar lesson'e moadele lesson'e feli
            var query2 = from register in Registers
                         from participate in register.Participates
                         from equivalence in
                             participate.SectionItem.Lesson.GetLessonHolding(participate.Register.Period).
                             LessonEquivalences
                         where participate.SectionItem.Lesson.Id == equivalence.EquivalentLesson.Id
                         select participate;

            var result = from participate in query.Union(query2)
                         orderby participate.Date
                         select participate;
            return result.AsQueryable();
        }

        public virtual bool SignedUpIn(SectionItem sectionItem)
        {
            var query = from register in Registers
                        from participate in register.Participates
                        where participate.SectionItem.Id == sectionItem.Id
                        select participate;
            return query.Count() > 0;
        }

        public virtual bool SignedUpIn(Lesson lesson, EducationalPeriod period)
        {
            var query = from participate in GetParticipates(lesson)
                        where participate.Register.Period.Id == period.Id
                        select participate;
            return query.Count() > 0;
        }

        public virtual bool SignedUpIn(Exam exam)
        {
            var query = from participate in exam.GetParticipates()
                        where participate.Register != null
                           && participate.Register.Student.Id == Id
                        select participate;
            return query.Count() > 0;
        }

        public virtual IQueryable<EducationalPeriod> GetRegisteredPeriods()
        {
            var query = from register in Registers
                        group register by register.Period
                        into g
                        select g.Key;

            return query.AsQueryable();
        }
        public virtual List<Register> GetRegisters(Major major)
        {
            var query = from Register register in Registers
                        where register.Major.Id == major.Id
                        select register;
            return query.ToList();
        }
        public virtual IEnumerable<EducationalPeriod> GetRegisteredPeriods(Major major)
        {
            var query = from register in Registers
                        where register.Major.Id == major.Id
                        group register by register.Period
                        into g
                        orderby g.Key.Id descending
                        select g.Key;

            return query;
        }

        public virtual IQueryable<Department> GetRegisteredDepartments()
        {
            var query = from register in Registers
                        group register by register.Major.Department into g
                        select g.Key;
            return query.AsQueryable();
        }

        public virtual IQueryable<Major> GetRegisteredMajors()
        {
            var query = from register in Registers
                        group register by register.Major into g
                        select g.Key;
            return query.AsQueryable();
        }
        public virtual IQueryable<Major> GetRegisteredMajors(EducationalPeriod period)
        {
            var query = from register in Registers
                        where register.Period.Id == period.Id
                        group register by register.Major into g
                        select g.Key;
            return query.AsQueryable();
        }

        public virtual IList<Register> GetRegisters(RegisterType type)
        {
            return Registers.Where(x => x.Type == type).OrderByDescending(x => x.RegisterDate).ToList();
        }

        public virtual IQueryable<Register> GetRegisters(Lesson lesson)
        {
            var query = from register in Registers
                        from participate in register.Participates
                        where participate.SectionItem.Item.Lesson.Id == lesson.Id
                        select register;
            return query.AsQueryable();
        }

        public virtual Register GetLastRegister()
        {
            //            var query = from register in Registers orderby register.RegisterDate descending, register.Id descending select register;
            var query = from register in Registers orderby register.Id descending select register;
            return query.FirstOrDefault();
        }
        public virtual Register GetLastRegister(RegisterType type)
        {
            var query = from register in Registers where register.Type == type orderby register.Id descending select register;
            return query.FirstOrDefault();
        }
        public virtual Register GetLastRegister(Major major)
        {
            //            var query = from register in Registers 
            //                        where register.Major.Id == major.Id
            //                        orderby register.RegisterDate descending, register.Id descending 
            //                        select register;
            var query = from register in Registers
                        where register.Major.Id == major.Id
                        orderby register.Id descending
                        select register;
            return query.FirstOrDefault();
        }

        public virtual Reserve GetLastReserve()
        {
            var query = from reserve in Reserves orderby reserve.ReserveDate descending select reserve;
            return query.FirstOrDefault();
        }

        public virtual string GetPrevEducationalStatus(Major major, EducationalPeriod currentPeriod)
        {
            EducationalPeriod prevPeriod = GetRegisteredPeriods(major).Except(new[] { currentPeriod }).OrderByDescending(x => x.Id).FirstOrDefault();
            if (prevPeriod != null)
            {
                Register register = GetRegister(prevPeriod, major);
                if (register != null)
                    return register.StatusText;
            }
            return "نامشخص";
        }

        public virtual bool CanSignup(EducationalPeriod period, Lesson lesson, bool specialCasecheck)
        {
            try
            {
                if (specialCasecheck)
                {
                    Participate participate = GetParticipates(lesson).LastOrDefault();
                    if (participate != null && participate.IsSpecialCase)
                        return true;
                }
                SignupCheck(period, lesson);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual void SignupCheck(EducationalPeriod period, Lesson lesson)
        {
            foreach (Lesson sectionLesson in lesson.Prerequisites)
            {
                PassedCheck(period, sectionLesson);
            }
        }

        public virtual void PassedCheck(EducationalPeriod period, Lesson lesson)
        {
            if (lesson.HoldingType == HoldingType.Lesson)
            {
                if (lesson.GetEvaluationProtocol(period) == null)
                    throw new Exception(string.Format("آیین نامه ارزشیابی درس {0} تعریف نشده است.", lesson.Name));
                if (lesson.GetResultProtocol(period) == null)
                    throw new Exception(string.Format("آیین نامه نمره دهی درس {0} تعریف نشده است.", lesson.Name));

                IQueryable<Participate> participates = GetParticipates(lesson);
                if (participates.Count() == 0)
                    throw new Exception(string.Format("دانشجو، پیشنیاز [{0}] برای ثبت نام در این درس/سطح را پاس نکرده است.", lesson.Name));

                EducationalRule educationalRule = EducationalRule.Apply(period, participates.ToArray());
                //                if (educationalRule.Result == EducationalRuleResult.Fail)
                if (educationalRule.NextIndex <= 0)
                    throw new Exception(string.Format(
                        "دانشجو، پیشنیاز [{0}] برای ثبت نام در این درس/سطح را پاس نکرده است.", lesson.Name));
            }

            if (lesson.HoldingType == HoldingType.Exam)
            {
                IQueryable<ExamParticipate> examParticipates = GetExamParticipates(lesson);
                EducationalRule rule = EducationalRule.Apply(period, examParticipates.ToArray());

                //                if (rule.Result == EducationalRuleResult.Fail)
                if (rule.NextIndex <= 0)
                    throw new Exception(string.Format(
                        "دانشجو، پیشنیاز [{0}] برای ثبت نام در این درس/سطح را پاس نکرده است.", lesson.Name));

                //1. get exam participates
                //2. foreach
                //3. get each examparticipate's mark and it's ResultLabel
                //4. get corresponding Rule
                //5. check rule if it is Passed or Fail or jump
            }
        }

        public virtual IQueryable<ExamParticipate> GetExamParticipates()
        {
            var query = from register in Registers
                        from examParticipate in register.GetExamParticipates()
                        where examParticipate.ExamForm != null
                        && examParticipate.ExamForm.Exam != null
                        && examParticipate.ExamForm.Exam.ExamTrainingItem != null
                        select examParticipate;

            return query.AsQueryable();
        }
        public virtual IQueryable<ExamParticipate> GetExerciseParticipates()
        {
            var query = from register in Registers
                        from examParticipate in register.GetExamParticipates()
                        where examParticipate.ExamForm != null
                        && examParticipate.ExamForm.Exam != null
                        && examParticipate.ExamForm.Exam.ExerciseTrainingItem != null
                        select examParticipate;

            return query.AsQueryable();
        }
        //public virtual IQueryable<ExamParticipate> GetBlackBoardLessonParticipates()
        //{
        //    var query = from register in Registers
        //                from examParticipate in register.GetExamParticipates()

        //                select examParticipate;

        //    return query.AsQueryable();
        //}
        public virtual IQueryable<ExamParticipate> GetExamParticipates(Lesson lesson)
        {
            var query = from examParticipate in GetExamParticipates()
                        where examParticipate.ExamForm.Exam.ExamTrainingItem.Lesson.Id == lesson.Id
                        select examParticipate;

            //ContainsLesson(lesson)
            List<ExamParticipate> examParticipates = query.ToList();
            return query.AsQueryable();
        }
        public virtual IQueryable<ExamParticipate> GetExerciseParticipates(Lesson lesson)
        {
            var query = from examParticipate in GetExamParticipates()
                        where examParticipate.ExamForm.Exam.ExerciseTrainingItem.Lesson.Id == lesson.Id
                        select examParticipate;

            //ContainsLesson(lesson)
            List<ExamParticipate> examParticipates = query.ToList();
            return query.AsQueryable();
        }
        public virtual Register CreateRegister(EducationalPeriod period, Major major, RegisterType type, bool useLastMajorRegisterCode)
        {
            Register register = new Register
            {
                Student = this,
                Period = period,
                Major = major,
                StartDate = period.StartDate,
                EndDate = period.EndDate,
                Type = type,
                FinancialDocument =
                                            {
                                                Person = this,
                                                Description =
                                                    "ثبت نام [" + FarsiFullname + "] در رشته [" + major.Name +
                                                    "] ترم [" + period.Name + "]"
                                            }
            };

            Register lastRegister = GetLastRegister(major);
            if (lastRegister != null)
                register.EducationalCode = lastRegister.EducationalCode;

            //            FinancialDocuments.Add(register.FinancialDocument);
            return register;
        }

        public virtual Reserve CreateReserve()
        {
            return new Reserve
            {
                Student = this,
                FinancialDocument = { Person = this }
            };
        }

        public virtual ConsultationApplicant CreateConsultationApplicant()
        {
            return new ConsultationApplicant
            {
                Student = this,
            };
        }

        public virtual Reserve Reserve(ReserveList reserveList)
        {
            if (reserveList.Remainder <= 0)
                throw new Exception("ظرفیت این لیست رزرو به پایان رسیده است.");

            Reserve reserve = CreateReserve();
            reserve.ReserveList = reserveList;

            FinancialItem item = new FinancialItem(FinancialType.Debt)
            {
                Amount = reserve.ReserveList.TuitionFee,
                Text = string.Format("رزرو در {0}", reserve.ReserveList.Name)
            };

            reserve.FinancialDocument.Items.Add(item);
            return reserve;
        }

        public virtual IQueryable<Reserve> GetReserves(EducationalPeriod period)
        {
            var query = from reserve in Reserves
                        where reserve.ReserveList.Period.Id == period.Id
                        select reserve;
            return query.AsQueryable();
        }

        public virtual IQueryable<Reserve> GetReserves(EducationalPeriod period, Major major)
        {
            var query = from reserve in Reserves
                        where reserve.ReserveList.Period.Id == period.Id
                        && reserve.ReserveList.Major.Id == major.Id
                        select reserve;
            return query.AsQueryable();
        }

        public virtual IQueryable<Reserve> GetNotRegisteredReserves()
        {
            var query = from reserve in Reserves
                        where reserve.Register == null && reserve.ReserveList.reserveType != ReserveList.ReserveType.LevelDetermination
                        select reserve;
            return query.AsQueryable();
        }
        public virtual IQueryable<Reserve> GetNotRegisteredLevelDeteminationReserves()
        {
            var query = from reserve in Reserves
                        where reserve.Register == null && reserve.ReserveList.reserveType == ReserveList.ReserveType.LevelDetermination
                        select reserve;
            return query.AsQueryable();
        }

        public virtual string GetDebtorReasonText()
        {
            foreach (Register register in Registers)
                if (register.FinancialDocument.FinancialStatus == FinancialStatus.Debtor)
                    return "رشته " + register.Major.Name;
            foreach (Reserve reserve in Reserves)
                if (reserve.FinancialDocument.FinancialStatus == FinancialStatus.Debtor)
                    return "رزرو در " + reserve.ReserveList.Name;

            //            foreach (ExamParticipate examParticipate in ExamParticipates)
            //                if (examParticipate.FinancialDocument.FinancialStatus == FinancialStatus.Debtor)
            //                    return "آزمون " + examParticipate.ExamForm.Exam.Name;
            return "نا مشخص";
        }

        public virtual IQueryable<Register> GetDebtorRegisters()
        {
            var query = from register in Registers
                        where register.DebtAmount > 0
                        select register;
            return query.AsQueryable();
        }

        public virtual Participate GetParticipate(SectionItem item)
        {
            var query = from participate in GetParticipates(item.Lesson)
                        where participate.SectionItem.Id == item.Id
                        select participate;

            return query.FirstOrDefault();
        }

        public virtual Participate GetParticipate(EducationalPeriod period, Lesson lesson)
        {
            var query = from participate in GetParticipates(lesson)
                        where participate.SectionItem.Section.Period.Id == period.Id
                        select participate;

            return query.FirstOrDefault();
        }

        public override void BeforeSave()
        {
            if (string.IsNullOrEmpty(Code) || Code == "0")
                Code = GetNextCode<Student>();
        }

        public virtual IQueryable<Ban> GetBans()
        {
            var query = from register in Registers
                        from participate in register.Participates
                        from ban in participate.Bans
                        select ban;
            return query.AsQueryable();
        }

        public virtual EducationalCode GenerateCode(EducationalPeriod period, Major major, bool forceRenewCode)
        {
            List<Reserve> reserves = GetReserves(period, major).ToList();
            Register register = GetRegister(period, major);
            if (!forceRenewCode && register != null && register.EducationalCode != null)
                return register.EducationalCode;
            if (!forceRenewCode && reserves.Count > 0 && reserves[0].EducationalCode != null)
                return reserves[0].EducationalCode;

            //            string preCode = period.Code.Substring(0, 2) + major.Department.Code + "" + major.Code;
            string preCode = period.Code + major.Department.Code + "" + major.Code;

            var query = from code in DbContext.Entity<EducationalCode>()
                        where code.Code.StartsWith(preCode)
                              && code.Major.Id == major.Id
                        orderby code.Code descending
                        select code.Code;

            //            var query1 = from reg in DbContext.Entity<Register>()
            //                         where reg.Code.StartsWith(preCode)
            //                         && reg.Student != null
            //                         && reg.Major != null
            //                         && reg.Period != null
            //                         && reg.Major.Id == major.Id
            //                         && reg.Period.Id == period.Id
            //                         orderby reg.Code descending
            //                         select reg.Code;
            //
            //            var query2 = from reserve in DbContext.Entity<Reserve>()
            //                         where reserve.Code.StartsWith(preCode)
            //                         && reserve.Student != null
            //                         && reserve.ReserveList != null
            //                         && reserve.ReserveList.Major.Id == major.Id
            //                         && reserve.ReserveList.Period.Id == period.Id
            //                         orderby reserve.Code descending
            //                         select reserve.Code;
            //
            //            List<string> list1 = query1.ToList();
            //            List<string> list2 = query2.ToList();
            //            List<string> allCodes = list1.Union(list2).ToList();
            List<string> allCodes = query.ToList();

            var query3 = from code in allCodes
                         orderby code.Length descending, code descending
                         select code;

            string num = "1001";
            int count = query3.Count();
            if (count > 0)
            {
                string firstCode = query3.First();
                num = firstCode.Substring(preCode.Length);
                num = (int.Parse(num) + 1) + "";
            }

            if (num.Length < 4)
                num = "1001";

            string generatedCode = preCode + num;

            EducationalCode educationalCode = EducationalCode.FromCode(generatedCode, major);
            if (educationalCode == null)
                educationalCode = new EducationalCode { Code = generatedCode, Major = major };

            return educationalCode;
        }

        public virtual void ConfirmEnrollment()
        {
            foreach (Register register in Registers)
                register.ConfirmEnrollment();
        }

        public virtual Register GetRegister(FinancialItem item)
        {
            var query = from register in Registers
                        from documentItem in register.FinancialDocument.Items
                        where documentItem.Id == item.Id
                        select register;
            return query.FirstOrDefault();
        }

        public virtual IQueryable<Lesson> GetParticipatedLessons()
        {
            var query = from register in Registers
                        from participate in register.Participates
                        group participate by participate.SectionItem.Lesson
                        into g
                        select g.Key;
            return query.AsQueryable();
        }

        public virtual IQueryable<EducationalTool> GetUsableGroupToolsForWebsite()
        {
            List<Lesson> lessons = GetParticipatedLessons().ToList();
            List<EducationalTool> tools = EducationalTool.GetWebsiteSellingTools().ToList();
            var query = from tool in tools
                        from groupTool in tool.GroupTools
                        from lesson in lessons
                        where groupTool.Group.Lesson != null && groupTool.Group.Lesson.Id == lesson.Id
                        group groupTool by groupTool.EducationalTool into g
                        select g.Key;
            return query.AsQueryable();
        }

        //        public virtual string GenerateCode(EducationalPeriod period, Major major, bool forceRenewCode)
        //        {
        //            List<Reserve> reserves = GetReserves(period, major).ToList();
        //            Register register = GetRegister(period, major);
        //            if (!forceRenewCode && register != null && !string.IsNullOrEmpty(register.Code))
        //                return register.Code;
        //            if (!forceRenewCode && reserves.Count > 0 && !string.IsNullOrEmpty(reserves[0].Code))
        //                return reserves[0].Code;
        //
        ////            string preCode = period.Code.Substring(0, 2) + major.Department.Code + "" + major.Code;
        //            string preCode = period.Code + major.Department.Code + "" + major.Code;
        //
        //            var query1 = from reg in DbContext.Entity<Register>()
        //                         where reg.Code.StartsWith(preCode)
        //                         && reg.Student != null
        //                         && reg.Major != null
        //                         && reg.Period != null
        //                         && reg.Major.Id == major.Id
        //                         && reg.Period.Id == period.Id
        //                         orderby reg.Code descending
        //                         select reg.Code;
        //
        //            var query2 = from reserve in DbContext.Entity<Reserve>()
        //                         where reserve.Code.StartsWith(preCode)
        //                         && reserve.Student != null
        //                         && reserve.ReserveList != null
        //                         && reserve.ReserveList.Major.Id == major.Id
        //                         && reserve.ReserveList.Period.Id == period.Id
        //                         orderby reserve.Code descending
        //                         select reserve.Code;
        //
        //            List<string> list1 = query1.ToList();
        //            List<string> list2 = query2.ToList();
        //            List<string> allCodes = list1.Union(list2).ToList();
        //
        //            var query3 = from code in allCodes
        //                         orderby code.Length descending, code descending 
        //                         select code;
        //
        //            string num = "1001";
        //            int count = query3.Count();
        //            if (count > 0)
        //            {
        //                string firstCode = query3.First();
        //                num = firstCode.Substring(preCode.Length);
        //                num = (int.Parse(num) + 1) + "";
        //            }
        //            return preCode + num; 
        //        }

        public virtual StudentConfiguration GetConfiguration(Major major, EducationalPeriod period)
        {
            return Configurations.FirstOrDefault(x => x.Major.Id == major.Id && x.EducationalPeriod.Id == period.Id);
        }

        #region Static Members
        public new static List<Student> Search(string firstName, string lastName)
        {
            List<Student> result = new List<Student>();

            var query = from student in DbContext.Entity<Student>()
                        where student.FarsiFirstName == firstName
                        && student.FarsiLastName == lastName
                        select student;
            result.UniqueAddRange(query.ToList());

            query = from student in DbContext.Entity<Student>()
                    where student.FarsiFirstName.StartsWith(firstName)
                    && student.FarsiLastName.StartsWith(lastName)
                    select student;
            result.UniqueAddRange(query.ToList());

            query = from student in DbContext.Entity<Student>()
                    where student.FarsiFirstName.Contains(firstName)
                    && student.FarsiLastName.Contains(lastName)
                    select student;
            result.UniqueAddRange(query.ToList());

            return result;
        }

        public static List<Student> SearchByFirstname(string firstName)
        {
            List<Student> result = new List<Student>();
            if (string.IsNullOrEmpty(firstName))
                return result;

            var query = from student in DbContext.Entity<Student>()
                        where student.FarsiFirstName == firstName
                        select student;
            result.UniqueAddRange(query.ToList());

            query = from student in DbContext.Entity<Student>()
                    where student.FarsiFirstName.StartsWith(firstName)
                    select student;
            result.UniqueAddRange(query.ToList());

            return result;
        }

        public static List<Student> SearchByLastname(string lastName)
        {
            List<Student> result = new List<Student>();
            if (string.IsNullOrEmpty(lastName))
                return result;

            var query = from student in DbContext.Entity<Student>()
                        where student.FarsiLastName == lastName
                        select student;
            result.UniqueAddRange(query.ToList());

            query = from student in DbContext.Entity<Student>()
                    where student.FarsiLastName.StartsWith(lastName)
                    select student;
            result.UniqueAddRange(query.ToList());

            return result;
        }

        public static List<Student> Search(params KeyValuePair<string, string>[] pair)
        {
            //            var query = DbContext.Entity<Student>().OrderBy()
            throw new NotImplementedException();
        }

        public static IQueryable<Student> GetDebtorStudents(IQueryable<Student> students)
        {
            var query = from student in students
                        where student.IsDebtor()
                        select student;
            return query;
        }

        public static IList<Student> GetStudents()
        {
            var query = from student in DbContext.Entity<Student>()
                        select student;
            return query.ToList();
        }

        public static IList<Student> GetWebsiteStudents()
        {
            var query = from student in DbContext.Entity<Student>()
                        where student.UserInfo.LoginStatus == LoginStatus.Enabled
                        && student.UserInfo.WebLogin
                        select student;
            return query.ToList();
        }

        public new static Student FromLogin(string username, string password)
        {
            IQueryable<Student> query = DbContext.Entity<Student>().Where(p => p.UserInfo.Username == username && p.UserInfo.Password == password);
            var query2 = from student in query.ToList()
                         where student.UserInfo.LoginStatus == LoginStatus.Enabled
                         select student;
            return query2.FirstOrDefault();
        }

        public static Student FromWebRegister(WebRegister register)
        {
            Student student = new Student();

            student.InternetRegisteration = true;

            student.FarsiFirstName = register.PersonalInfo.FarsiFirstName;
            student.EnglishFirstName = register.PersonalInfo.EnglishFirstName;
            student.FarsiLastName = register.PersonalInfo.FarsiLastName;
            student.EnglishLastName = register.PersonalInfo.EnglishLastName;
            student.FarsiFatherName = register.PersonalInfo.FarsiFatherName;
            student.EnglishFatherName = register.PersonalInfo.EnglishFatherName;
            student.Gender = register.PersonalInfo.Gender;
            student.BirthDate = register.PersonalInfo.BirthDate;
            student.IdNumber = register.PersonalInfo.IdNumber;
            student.NationalCode = register.PersonalInfo.NationalCode;
            student.ContactInfo.Province = register.ContactInfo.Province;
            student.ContactInfo.City = register.ContactInfo.City;
            student.ContactInfo.Address = register.ContactInfo.Address;
            student.ContactInfo.PostalCode = register.ContactInfo.PostalCode;
            student.ContactInfo.Phone = register.ContactInfo.Phone;
            student.ContactInfo.Mobile = register.ContactInfo.Mobile;
            student.ContactInfo.Email = register.ContactInfo.Email;

            return student;
        }

        #endregion

        public static Student FromId(int id)
        {
            return DbContext.FromId<Student>(id);
        }

        public virtual IQueryable<Lesson> GetEnrollableLessons(Major major, EducationalPeriod period, bool removePrerequisites, bool specialCasecheck)
        {
            var query = from lesson in major.Lessons
                        where lesson.InternetRegisterable && CanSignup(period, lesson, specialCasecheck)
                        select lesson;
            if (!removePrerequisites)
                return query.AsQueryable();

            List<Lesson> firstResult = query.ToList();
            List<Lesson> result = new List<Lesson>();
            foreach (Lesson lesson in firstResult)
            {
                RemovePrerequisites(result, lesson);
                result.Add(lesson);
            }
            return result.AsQueryable();
        }

        private void RemovePrerequisites(List<Lesson> lessons, Lesson lesson)
        {
            foreach (Lesson prerequisite in lesson.Prerequisites)
            {
                if (lessons.Contains(prerequisite))
                    lessons.Remove(prerequisite);
                RemovePrerequisites(lessons, prerequisite);
            }
        }

        public virtual StudentConfiguration CreateConfiguration(Major major, EducationalPeriod period)
        {
            StudentConfiguration configuration = new StudentConfiguration
            {
                Student = this,
                Major = major,
                EducationalPeriod = period,
            };
            configuration.CalculateEnrollableLessons();
            return configuration;
        }

        public virtual void AddConfiguration(StudentConfiguration configuration)
        {
            configuration.Student = this;
            Configurations.Add(configuration);
        }

        public virtual IQueryable<Certificate> GetCertificates()
        {
            var query = from certificate in DbContext.Entity<Certificate>()
                        where certificate.Student.Id == Id
                        select certificate;
            return query;
        }

    }
}