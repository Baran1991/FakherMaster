using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DataAccessLayer;
using rComponents;
using Fakher.Core.Website;

namespace Fakher.Core.DomainModel
{
    public class EducationalPeriod : DbObject, IProgressive
    {
        public EducationalPeriod()
        {
            Code = PersianDate.Today.Year.ToString().Substring(2, 2) + (PersianDate.Today.Month / 4 + 1);
            Name = "";
            StartDate = PersianDate.Today;
            FinancialPolicy = FinancialPolicy.StraightForward;
            EnrollmentLicenses = new List<EnrollmentLicense>();
            MarkEntryLicenses = new List<MarkEntryLicense>();
//            ReportCardLicenses = new List<ReportCardLicense>();
        }

        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual PersianDate StartDate { get; set; }
        public virtual PersianDate EndDate { get; set; }
        [NoCascade]
        public virtual Department Department { get; set; }
        public virtual FinancialPolicy FinancialPolicy { get; set; }
        public virtual long VacationFee { get; set; }
        public virtual long CertificateFee { get; set; }
        [MaximumLength]
        public virtual string VacationReceiptNote { get; set; }
        [MaximumLength]
        public virtual string SignupReceiptNote { get; set; }
        [MaximumLength]
        public virtual string QuitReceiptNote { get; set; }
        [MaximumLength]
        public virtual string RegistrationNote { get; set; }
        [MaximumLength]
        public virtual string TransitionReceiptNote { get; set; }
        //        public virtual string ReceiptBankName { get; set; }
        [NoCascade]
        public virtual BankAccount ReceiptBankAccount { get; set; }
        [MaximumLength]
        public virtual string PayrollNote { get; set; }
        public virtual IList<LessonHolding> LessonHoldings { get; set; }
        public virtual IList<EnrollmentLicense> EnrollmentLicenses { get; set; }
        public virtual IList<MarkEntryLicense> MarkEntryLicenses { get; set; }
        public virtual PersianDate WebReportCardStartDate { get; set; }
        public virtual int WebReportCardStartHour { get; set; }
        public virtual int WebReportCardStartMinute { get; set; }
        public virtual bool CanViewWebReportCard { get; set; }

        [NonPersistent]
        public virtual int Year
        {
            get { return StartDate.Year; }
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

        public virtual List<Register> GetRegisters(Major major)
        {
            var query = from register in DbContext.Entity<Register>()
                        where register.Period.Id == Id && register.Major.Id == major.Id
                        select register;
            return query.ToList();
        }

        public virtual IQueryable<LessonHolding> GetLessonHoldings(Major major)
        {
            var query = from lessonHolding in LessonHoldings
                        where lessonHolding.Lesson.Major != null 
                        && lessonHolding.Lesson.Major.Id == major.Id
                        select lessonHolding;
            return query.AsQueryable();
        }

        public virtual LessonHolding GetLessonHolding(Lesson lesson)
        {
            var query = from lessonHolding in LessonHoldings
                        where lessonHolding.Lesson != null
                        && lessonHolding.Lesson.Id == lesson.Id
                        select lessonHolding;
            return query.FirstOrDefault();
        }

        public virtual void PrepareFrom(EducationalPeriod refPeriod)
        {
            OnProgress("دریافت داده ها", 1, 2);
            IList<EvaluationProtocol> evaluationProtocols = EvaluationProtocol.GetProtocols(refPeriod);
            IList<EducationalRule> educationalRules = EducationalRule.GetRules(refPeriod);
            IList<ResultProtocol> resultProtocols = ResultProtocol.GetProtocols(refPeriod);
            IList<TrainingPlan> trainingPlans = TrainingPlan.GetPlans(refPeriod);
            IList<PlacementProtocol> placementProtocols = PlacementProtocol.GetProtocols(refPeriod);
//            IList<SalaryRateProtocol> salaryRateProtocols = SalaryRateProtocol.GetProtocols(refPeriod);

            foreach (LessonHolding lessonHolding in refPeriod.LessonHoldings)
            {
                int idx = refPeriod.LessonHoldings.IndexOf(lessonHolding);
                OnProgress("انتقال برگزاریهای درس/سطح", idx, refPeriod.LessonHoldings.Count);

                //1. Eval Protocol
                if (lessonHolding.EvaluationProtocol != null)
                {
                    EvaluationProtocol protocol =
                        Protocol.GetProtocol<EvaluationProtocol>(lessonHolding.EvaluationProtocol, this);
                    if (protocol == null)
                    {
                        EvaluationProtocol clone = lessonHolding.EvaluationProtocol.Clone();
                        clone.Parent = lessonHolding.EvaluationProtocol;
                        clone.Period = this;
                        clone.Save();
                    }
                }

                //2. result protocol
                if (lessonHolding.ResultProtocol != null)
                {
                    ResultProtocol resultProtocol = Protocol.GetProtocol<ResultProtocol>(lessonHolding.ResultProtocol,
                                                                                         this);
                    if (resultProtocol == null)
                    {
                        ResultProtocol clone = lessonHolding.ResultProtocol.Clone();
                        clone.Parent = lessonHolding.ResultProtocol;
                        clone.Period = this;
                        clone.Save();
                    }
                }

                //3. placement Protocol
                if (lessonHolding.PlacementProtocol != null)
                {
                    PlacementProtocol placementProtocol =
                        Protocol.GetProtocol<PlacementProtocol>(lessonHolding.PlacementProtocol, this);
                    if (placementProtocol == null)
                    {
                        PlacementProtocol clone = lessonHolding.PlacementProtocol.Clone();
                        clone.Parent = lessonHolding.PlacementProtocol;
                        clone.Period = this;
                        clone.Save();
                    }
                }

                LessonHolding currentHolding = GetLessonHolding(lessonHolding.Lesson);
                if (currentHolding != null)
                    continue;
                else
                {
                    currentHolding = lessonHolding.Clone();
                    currentHolding.Period = this;
                    if (lessonHolding.EvaluationProtocol != null)
                        currentHolding.EvaluationProtocol =
                            Protocol.GetProtocol<EvaluationProtocol>(lessonHolding.EvaluationProtocol, this);
                    if (lessonHolding.ResultProtocol != null)
                        currentHolding.ResultProtocol = Protocol.GetProtocol<ResultProtocol>(lessonHolding.ResultProtocol,
                                                                                       this);
                    if (lessonHolding.PlacementProtocol != null)
                        currentHolding.PlacementProtocol =
                            Protocol.GetProtocol<PlacementProtocol>(lessonHolding.PlacementProtocol, this);
                    AddLessonHolding(currentHolding);
//                    currentHolding.Save();
                }
            }

            foreach (EducationalRule rule in educationalRules)
            {
                int idx = educationalRules.IndexOf(rule);
                OnProgress("انتقال قوانین آموزشی", idx, educationalRules.Count);

                if(rule.ResultLabel.ResultProtocol == null)
                    continue;

                ResultProtocol resultProtocol = Protocol.GetProtocol<ResultProtocol>(rule.ResultLabel.ResultProtocol, this);
                if(resultProtocol == null)
                {
                    ResultProtocol clone = rule.ResultLabel.ResultProtocol.Clone();
                    clone.Parent = rule.ResultLabel.ResultProtocol;
                    clone.Period = this;
                    clone.Save();
                }

                
                resultProtocol = Protocol.GetProtocol<ResultProtocol>(rule.ResultLabel.ResultProtocol, this);

                EducationalRule educationalRuleClone = rule.Clone();
                educationalRuleClone.Period = this;
                educationalRuleClone.Parent = rule;
                educationalRuleClone.ResultLabel = resultProtocol.GetItem(rule.ResultLabel.Name);
                educationalRuleClone.Save();
            }

            foreach (TrainingPlan trainingPlan in trainingPlans)
            {
                int idx = trainingPlans.IndexOf(trainingPlan);
                OnProgress("انتقال برنامه های آموزشی", idx, trainingPlans.Count);

                if(!Department.Majors.Contains(trainingPlan.Major))
                    continue;
                
                TrainingPlan clone = trainingPlan.Clone();
                clone.Parent = trainingPlan;
                clone.Period = this;

                foreach (ExamTrainingItem examTrainingItem in clone.GetExamItems())
                {
                    if(examTrainingItem.EvaluationItem == null)
                    {
                        ExamTrainingItem parentItem = examTrainingItem.CloneParent;
                        EvaluationProtocol evaluationProtocol = Protocol.GetProtocol<EvaluationProtocol>(parentItem.EvaluationItem.EvaluationGroup.EvaluationProtocol, this);
                        if(evaluationProtocol == null)
                            throw new Exception("آیین نامه ارزشیابی برنامه آموزشی تعریف نشده است.");
                        
                        EvaluationItem item = evaluationProtocol.FindItem(
                            parentItem.EvaluationItem.EvaluationGroup.Name,
                            parentItem.EvaluationItem.Name);

                        examTrainingItem.EvaluationItem = item;
                    }
                }
                clone.Save();
            }

//            foreach (SalaryRateProtocol rateProtocol in salaryRateProtocols)
//            {
//                SalaryRateProtocol protocol = Protocol.GetProtocol<SalaryRateProtocol>(rateProtocol, this);
//                if(protocol == null)
//                {
//                    SalaryRateProtocol clone = rateProtocol.Clone();
//                    clone.Parent = rateProtocol;
//                    clone.Period = this;
//                    clone.Save();
//                }
//            }

            Save();
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual void AddLessonHolding(LessonHolding lessonHolding)
        {
            lessonHolding.Period = this;
            LessonHoldings.Add(lessonHolding);
        }

        #region Implementation of IProgressive

        public virtual event EventHandler<ProgressEventArgs> Progress;
        public virtual void OnProgress(string text, int value, int maximum)
        {
            if(Progress != null)
            {
                ProgressEventArgs eventArgs = new ProgressEventArgs();
                eventArgs.Text = text;
                eventArgs.Maximum = maximum;
                eventArgs.Value = value;
                Progress(this, eventArgs);
            }
        }

        #endregion

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

        public static string GenerateCode(Department department)
        {
            string year = PersianDate.Today.Year.ToString().Substring(2, 2);
            return year + (department.EducationalPeriods.Where(x => x.Code.StartsWith(year)).Count() + 1);
        }

        public static EducationalPeriod FromId(int id)
        {
            return DbContext.FromId<EducationalPeriod>(id);
        }

        public virtual IQueryable<T> GetProtocols<T>() where T : Protocol
        {
            var query = from protocol in DbContext.Entity<T>()
                        where protocol.Period != null
                        && protocol.Period.Id == Id
                        select protocol;
            return query;
        }

        public virtual ResultLabel[] GetDefaultResultLabels()
        {
            List<ResultProtocol> protocols = GetProtocols<ResultProtocol>().ToList();
            if(protocols.Count == 0)
                throw new MessageException("آیین نامه نتیجه آموزشی تعریف نشده است.");
            return protocols[0].Labels.ToArray();
        }
        public static IList<EducationalPeriod> GetPeriods()
        {
            return DbContext.GetAllEntities<EducationalPeriod>();
        }
    }
}