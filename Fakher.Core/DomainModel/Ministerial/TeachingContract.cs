using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class TeachingContract : Contract
    {
        public virtual int TermHistory { get; set; }
        public virtual int YearHistory { get; set; }
        public virtual int TeachingHoursHistory { get; set; }
        [NoCascade]
        public virtual Major Major { get; set; }
//        [NoCascade]
//        public virtual EducationalPeriod Period { get; set; }
//        public virtual event EventHandler Progress;


        public TeachingContract()
        {
        }

        [NonPersistent]
        public override string Text
        {
            get { return Major.Name; }
        }

        public static IList<TeachingContract> GetContracts(Major major)
        {
            var query = from contract in DbContext.Entity<TeachingContract>()
                        where contract.Major.Id == major.Id
                        select contract;
            return query.ToList();
        }

//        public static IList<TeachingContract> GetContracts(SalaryRateProtocol salaryRateProtocol)
//        {
//            var query = from contract in DbContext.Entity<TeachingContract>()
//                        where contract.RateProtocol != null
//                        && contract.RateProtocol.Id == salaryRateProtocol.Id
//                        select contract;
//            return query.ToList();
//        }

        private IQueryable<ConditionValue> GetConditionValues(Section section)
        {
            var query1 = from conditionValue in ConditionValues
                         where conditionValue.Section == section
                         select conditionValue;
            return query1.AsQueryable();
        }

        public virtual RateElement[] GetRateElements(Section section, ElementCalculationType calculationType, PersianDate calculationStartDate, PersianDate calculationEndDate)
        {
            IQueryable<ConditionValue> conditionValues = GetConditionValues(section);
            if (conditionValues.Count() == 0)
            {
                PreCalculate(section, calculationType, calculationStartDate, calculationEndDate);
                conditionValues = GetConditionValues(section);
            }
            var query = from conditionValue in conditionValues
                         where conditionValue.CalculationType == calculationType
                               && conditionValue.TeachingContract == this
                         select conditionValue.RateElement;
                        
            return query.ToArray();
        }

        public virtual RateElement[] CalculateRateElements(Section section, ElementCalculationType calculationType, PersianDate calculationStartDate, PersianDate calculationEndDate)
        {
            if (RateType == RateType.Fixed)
                return new[] { new RateElement { Text = "نرخ ثابت", Amount = BaseAmount } };
            if (RateType == RateType.ByProtocol)
                return RateProtocol.CalculateRate(this, section, calculationType, calculationStartDate, calculationEndDate);
            throw new Exception("مقدار دستمزد قابل محاسبه نیست.");
        }

        public override void PreCalculate(PayrollContract payrollContract)
        {
            Teacher teacher = Staff as Teacher;
//            IList<Section> teachingSections = teacher.GetPresenceSections(StartDate, EndDate);
            IList<Section> teachingSections = teacher.GetPresenceSections(payrollContract.StartDate, payrollContract.EndDate);
            foreach (Section section in teachingSections)
            {
                if (section.Major.Id != Major.Id)
                    continue;

                PreCalculate(section, ElementCalculationType.SectionCalculation, payrollContract.StartDate, payrollContract.EndDate);
            }
        }

        private void PreCalculate(Section section, ElementCalculationType calculationType, PersianDate calculationStartDate, PersianDate calculationEndDate)
        {
            RateElement[] rateElements = CalculateRateElements(section, calculationType, calculationStartDate, calculationEndDate);
            foreach (RateElement element in rateElements)
            {
                ConditionValue conditionValue = new ConditionValue();
                conditionValue.CalculationType = element.CalculationType;
                conditionValue.Condition = element.Condition;
                conditionValue.Section = element.Section;
                conditionValue.RateElement = element;
                conditionValue.TeachingContract = this;
                ConditionValues.Add(conditionValue);
            }
        }

        public override void Calculate(PayrollContract payrollContract)
        {
            //                            OnProgress();
            Teacher teacher = Staff as Teacher;
//            IList<Replacement> replacements = teacher.GetPresenceReplacements(StartDate, EndDate);
//            IList<Section> teachingSections = teacher.GetPresenceSections(StartDate, EndDate);
            IList<Replacement> replacements = teacher.GetPresenceReplacements(payrollContract.StartDate, payrollContract.EndDate);
            IList<Section> teachingSections = teacher.GetPresenceSections(payrollContract.StartDate, payrollContract.EndDate);
            //                OnProgress();

            if (PaymentSystem == PaymentSystem.Fixed)
            {
                foreach (Section section in teachingSections)
                {
                    if (section.Major.Id != Major.Id)
                        continue;
//                    if (!section.WageCalculation)
//                        continue;

                    //                    OnProgress();

                    PayrollItem payrollItem = new PayrollItem();
                    payrollItem.FinancialType = FinancialType.Credit;
                    payrollItem.Heading = PayrollItemHeading.Working;
                    payrollItem.Text = section.MasterItemText + " " + section.FarsiName;
                    payrollItem.Description = section.MasterItemText + " " + section.FarsiName + " رشته " + section.Major.Name;
                    payrollItem.Unit = "دوره";
                    payrollItem.Count = 1;
                    RateElement[] rateElements = GetRateElements(section, ElementCalculationType.SectionCalculation, payrollContract.StartDate, payrollContract.EndDate);
                    if (BaseAmount > 0)
                        payrollItem.AddRateElements(new[]
                                                            {
                                                                new RateElement
                                                                    {
                                                                        Condition = SalaryCondition.BasePayment,
                                                                        Amount = BaseAmount,
                                                                        Section = section,
                                                                        Text = "نرخ پایه",
                                                                        Value = BaseAmount.ToString("C0")
                                                                    }
                                                            });
                    payrollItem.AddRateElements(rateElements);
                    payrollItem.Fee = payrollItem.RateElements.Sum(x => x.Amount);

                    payrollContract.AddItem(payrollItem);
                }
            }

            if (PaymentSystem == PaymentSystem.Hourly)
            {
                foreach (Section section in teachingSections)
                {
                    if (section.Major.Id != Major.Id)
                        continue;
//                    if (!section.WageCalculation)
//                        continue;
                    IQueryable<Presence> presences = GetPresences(section, payrollContract.StartDate, payrollContract.EndDate);
                    float presencesHours = (float)Math.Round(GetPresencesHours(section, payrollContract.StartDate, payrollContract.EndDate), 1);

                    //                    OnProgress();

                    PayrollItem payrollItem = new PayrollItem();
                    payrollItem.FinancialType = FinancialType.Credit;
                    payrollItem.Heading = PayrollItemHeading.Working;
                    payrollItem.Text = section.MasterItemText + " " + section.FarsiName;
                    payrollItem.Description = section.MasterItemText + " " + section.FarsiName + " رشته " + section.Major.Name + " از " +
                                              presences.First().Date.ToShortDateString() + " تا " +
                                              presences.Last().Date.ToShortDateString();
                    payrollItem.Unit = "ساعت";
                    RateElement[] rateElements = GetRateElements(section, ElementCalculationType.SectionCalculation, payrollContract.StartDate, payrollContract.EndDate);
                    if (BaseAmount > 0)
                        payrollItem.AddRateElements(new[]
                                                            {
                                                                new RateElement
                                                                    {
                                                                        Condition = SalaryCondition.BasePayment,
                                                                        Amount = BaseAmount,
                                                                        Section = section,
                                                                        Text = "نرخ پایه",
                                                                        Value = BaseAmount.ToString("C0")
                                                                    }
                                                            });
                    payrollItem.AddRateElements(rateElements);
                    payrollItem.Fee = payrollItem.RateElements.Sum(x => x.Amount);
                    payrollItem.Count = presencesHours;

                    payrollContract.AddItem(payrollItem);
                }

                foreach (Replacement replacement in replacements)
                {
                    if (replacement.SectionItem.Section.Major.Id != Major.Id)
                        continue;

                    //                    OnProgress();

                    PayrollItem payrollItem = new PayrollItem();
                    payrollItem.FinancialType = FinancialType.Credit;
                    payrollItem.Heading = PayrollItemHeading.Working;
                    payrollItem.Text = "جانشینی در " + replacement.SectionItem.Lesson.Name + "، " + replacement.SectionItem.Section.FarsiName;
                    payrollItem.Description = "جانشینی " + replacement.Date.ToShortDateString() + " در " +
                                              replacement.SectionItem.Lesson.Name + "، " + replacement.SectionItem.Section.FarsiName + " رشته " +
                                              replacement.SectionItem.Section.Major.Name + " به جای " +
                                              replacement.SectionItem.Section.Teacher.FarsiFullname;
                    payrollItem.Unit = "ساعت";
                    RateElement[] rateElements = GetRateElements(replacement.SectionItem.Section, ElementCalculationType.ReplacementCalculation, payrollContract.StartDate, payrollContract.EndDate);
                    if (BaseAmount > 0)
                        payrollItem.AddRateElements(new[]
                                                            {
                                                                new RateElement
                                                                    {
                                                                        Condition = SalaryCondition.BasePayment,
                                                                        Amount = BaseAmount,
                                                                        Section = replacement.SectionItem.Section,
                                                                        Text = "نرخ پایه",
                                                                        Value = BaseAmount.ToString("C0")
                                                                    }
                                                            });
                    payrollItem.AddRateElements(rateElements);
                    payrollItem.Fee = payrollItem.RateElements.Sum(x => x.Amount);
                    payrollItem.Count = replacement.ReplacementHours;

                    payrollContract.AddItem(payrollItem);
                }
            }

            if (PaymentSystem == PaymentSystem.Sessional)
            {
                foreach (Section section in teachingSections)
                {
                    if (section.Major.Id != Major.Id)
                        continue;
//                    if (!section.WageCalculation)
//                        continue;

                    //                    OnProgress();

                    PayrollItem payrollItem = new PayrollItem();
                    payrollItem.FinancialType = FinancialType.Credit;
                    payrollItem.Heading = PayrollItemHeading.Working;
                    payrollItem.Text = section.FarsiName;
                    payrollItem.Description = section.MasterItemText + " " + section.FarsiName + " رشته " + section.Major.Name;
                    payrollItem.Unit = "جلسه";
                    RateElement[] rateElements = GetRateElements(section, ElementCalculationType.SectionCalculation, payrollContract.StartDate, payrollContract.EndDate);
                    if (BaseAmount > 0)
                        payrollItem.AddRateElements(new[]
                                                            {
                                                                new RateElement
                                                                    {
                                                                        Condition = SalaryCondition.BasePayment,
                                                                        Amount = BaseAmount,
                                                                        Section = section,
                                                                        Text = "نرخ پایه",
                                                                        Value = BaseAmount.ToString("C0")
                                                                    }
                                                            });
                    payrollItem.AddRateElements(rateElements);
                    payrollItem.Fee = payrollItem.RateElements.Sum(x => x.Amount);
                    payrollItem.Count = GetPresencesSessions(section, payrollContract.StartDate, payrollContract.EndDate);

                    payrollContract.AddItem(payrollItem);
                }
            }



            // اضافه کاری
            // بیمه و مالیات
            //            OnProgress();
            if (InsuranceCalculationType != CalculationType.NoCalculation)
            {
                PayrollItem payrollItem = new PayrollItem();
                payrollItem.FinancialType = FinancialType.Debt;
                payrollItem.Heading = PayrollItemHeading.Insurance;
                payrollItem.Text = "بیمه";
                payrollItem.Description = "بیمه";
                payrollItem.Unit = "دوره";
                payrollItem.Count = 1;
                float fee = 0;
                if (InsuranceCalculationType == CalculationType.ByFixedAmount)
                {
                    fee = ((float)InsuranceBase * InsurancePercent) / 100;
                }
                else if (InsuranceCalculationType == CalculationType.BySalary)
                {
                    var query = from item in payrollContract.Items
                                where item.Heading == PayrollItemHeading.Working
                                      && item.FinancialType == FinancialType.Credit
                                select item.Amount;
                    float salary = query.Sum();
                    fee = (salary * InsurancePercent) / 100;
                }
                else if (InsuranceCalculationType != CalculationType.ExactAmount)
                {
                    fee = InsuranceBase;
                }
                payrollItem.Fee = fee;
                payrollContract.AddItem(payrollItem);
            }

            //            OnProgress();
            if (TaxCalculationType != CalculationType.NoCalculation)
            {
                PayrollItem payrollItem = new PayrollItem();
                payrollItem.FinancialType = FinancialType.Debt;
                payrollItem.Heading = PayrollItemHeading.Tax;
                payrollItem.Text = "مالیات";
                payrollItem.Description = "مالیات";
                payrollItem.Unit = "دوره";
                payrollItem.Count = 1;
                float fee = 0;
                if (TaxCalculationType == CalculationType.ByFixedAmount)
                {
                    fee = ((float)TaxBase * TaxPercent) / 100;
                }
                else if (TaxCalculationType == CalculationType.BySalary)
                {
                    var query = from item in payrollContract.Items
                                where item.Heading == PayrollItemHeading.Working
                                      && item.FinancialType == FinancialType.Credit
                                select item.Amount;
                    float salary = query.Sum();
                    fee = (salary * TaxPercent) / 100;
                }
                else if (TaxCalculationType == CalculationType.ExactAmount)
                {
                    fee = TaxBase;
                }
                payrollItem.Fee = fee;
                payrollContract.AddItem(payrollItem);
            }


            // سایر کسورات
            // سایر پرداختی ها
        }

//        public virtual RateElement[] GetRateElements(Section section)
//        {
//            if (RateType == RateType.Fixed)
//                return new [] {new RateElement {Text = "نرخ ثابت", Amount = BaseAmount}};
//            if (RateType == RateType.ByProtocol)
//                return RateProtocol.CalculateRate(this, section);
//            throw new Exception("مقدار دستمزد قابل محاسبه نیست.");
//        }

//        public virtual Payroll CalculatePayroll(PersianDate startDate, PersianDate endDate)
//        {
//            OnProgress();
//            Teacher teacher = Staff as Teacher;
//            IList<Replacement> replacements = teacher.GetPresenceReplacements(startDate, endDate);
//            IList<Section> teachingSections = teacher.GetPresenceSections(startDate, endDate);
//            OnProgress();
//
//            Payroll payroll = new Payroll();
//            payroll.StartDate = startDate;
//            payroll.EndDate = endDate;
//            payroll.Contract = this;
//
//            if(PaymentSystem == PaymentSystem.Fixed)
//            {
//                foreach (Section section in teachingSections)
//                {
//                    if(section.Major.Id != Major.Id)
//                        continue;
//                    if(!section.WageCalculation)
//                        continue;
//
//                    OnProgress();
//
//                    PayrollItem payrollItem = new PayrollItem();
//                    payrollItem.FinancialType = FinancialType.Credit;
//                    payrollItem.Heading = PayrollItemHeading.Working;
//                    payrollItem.Text = section.FarsiName;
//                    payrollItem.Description = section.FarsiName + " رشته " + section.Major.Name;
//                    payrollItem.Unit = "دوره";
//                    payrollItem.Count = 1;
//                    RateElement[] rateElements = GetRateElements(section);
//                    if (BaseAmount > 0)
//                        payrollItem.AddRateElements(new[]
//                                                        {
//                                                            new RateElement
//                                                                {
//                                                                    Condition = SalaryCondition.BasePayment,
//                                                                    Amount = BaseAmount,
//                                                                    Section = section,
//                                                                    Text = "نرخ پایه",
//                                                                    Value = BaseAmount.ToString("C0")
//                                                                }
//                                                        });
//                    payrollItem.AddRateElements(rateElements);
//                    payrollItem.Fee = payrollItem.RateElements.Sum(x => x.Amount);
//
//                    payroll.AddItem(payrollItem);
//                }
//            }
//
//            if(PaymentSystem == PaymentSystem.Hourly)
//            {
//                foreach (Section section in teachingSections)
//                {
//                    if (section.Major.Id != Major.Id)
//                        continue;
//                    if (!section.WageCalculation)
//                        continue;
//                    IQueryable<Presence> presences = GetPresences(section, startDate, endDate);
//                    float presencesHours = (float) Math.Round(GetPresencesHours(section, startDate, endDate), 1);
//                    if(presencesHours == 0)
//                        continue;
//
//                    OnProgress();
//
//                    PayrollItem payrollItem = new PayrollItem();
//                    payrollItem.FinancialType = FinancialType.Credit;
//                    payrollItem.Heading = PayrollItemHeading.Working;
//                    payrollItem.Text = section.FarsiName;
//                    payrollItem.Description = section.FarsiName + " رشته " + section.Major.Name + " از " +
//                                              presences.First().Date.ToShortDateString() + " تا " +
//                                              presences.Last().Date.ToShortDateString();
//                    payrollItem.Unit = "ساعت";
//                    RateElement[] rateElements = GetRateElements(section);
//                    if(BaseAmount > 0)
//                        payrollItem.AddRateElements(new []
//                                                        {
//                                                            new RateElement
//                                                                {
//                                                                    Condition = SalaryCondition.BasePayment,
//                                                                    Amount = BaseAmount,
//                                                                    Section = section,
//                                                                    Text = "نرخ پایه",
//                                                                    Value = BaseAmount.ToString("C0")
//                                                                }
//                                                        });
//                    payrollItem.AddRateElements(rateElements);
//                    payrollItem.Fee = payrollItem.RateElements.Sum(x => x.Amount);
//                    payrollItem.Count = presencesHours;
//
//                    payroll.AddItem(payrollItem);
//                }
//
//                foreach (Replacement replacement in replacements)
//                {
//                    if (replacement.SectionItem.Section.Major.Id != Major.Id)
//                        continue;
//
//                    OnProgress();
//
//                    PayrollItem payrollItem = new PayrollItem();
//                    payrollItem.FinancialType = FinancialType.Credit;
//                    payrollItem.Heading = PayrollItemHeading.Working;
//                    payrollItem.Text = "جانشینی در " + replacement.SectionItem.Section.FarsiName;
//                    payrollItem.Description = "جانشینی " + replacement.Date.ToShortDateString() + " در " + replacement.SectionItem.Section.FarsiName + " رشته " + replacement.SectionItem.Section.Major.Name + " به جای " + replacement.SectionItem.Section.Teacher.FarsiFullname;
//                    payrollItem.Unit = "ساعت";
//                    RateElement[] rateElements = GetRateElements(replacement.SectionItem.Section);
//                    if (BaseAmount > 0)
//                        payrollItem.AddRateElements(new[]
//                                                        {
//                                                            new RateElement
//                                                                {
//                                                                    Condition = SalaryCondition.BasePayment,
//                                                                    Amount = BaseAmount,
//                                                                    Section = replacement.SectionItem.Section,
//                                                                    Text = "نرخ پایه",
//                                                                    Value = BaseAmount.ToString("C0")
//                                                                }
//                                                        });
//                    payrollItem.AddRateElements(rateElements);
//                    payrollItem.Fee = payrollItem.RateElements.Sum(x => x.Amount);
//                    payrollItem.Count = replacement.ReplacementHours;
//
//                    payroll.AddItem(payrollItem);
//                }
//            }
//
//            if(PaymentSystem == PaymentSystem.Sessional)
//            {
//                foreach (Section section in teachingSections)
//                {
//                    if (section.Major.Id != Major.Id)
//                        continue;
//                    if (!section.WageCalculation)
//                        continue;
//
//                    OnProgress();
//
//                    throw new Exception(string.Format("برای گروه {0} پایان رسمی اعلام نشده است.", section.GroupNumber));
//                    PayrollItem payrollItem = new PayrollItem();
//                    payrollItem.FinancialType = FinancialType.Credit;
//                    payrollItem.Heading = PayrollItemHeading.Working;
//                    payrollItem.Text = section.FarsiName;
//                    payrollItem.Description = section.FarsiName + " رشته " + section.Major.Name;
//                    payrollItem.Unit = "جلسه";
//                    RateElement[] rateElements = GetRateElements(section);
//                    if (BaseAmount > 0)
//                        payrollItem.AddRateElements(new[]
//                                                        {
//                                                            new RateElement
//                                                                {
//                                                                    Condition = SalaryCondition.BasePayment,
//                                                                    Amount = BaseAmount,
//                                                                    Section = section,
//                                                                    Text = "نرخ پایه",
//                                                                    Value = BaseAmount.ToString("C0")
//                                                                }
//                                                        });
//                    payrollItem.AddRateElements(rateElements);
//                    payrollItem.Fee = payrollItem.RateElements.Sum(x => x.Amount);
//                    payrollItem.Count = section.GetHoldedSessions(startDate, endDate);
//                    payrollItem.Count = GetPresencesSessions(section, startDate, endDate);
//
//                    payroll.AddItem(payrollItem);
//                }
//            }
//
//
//
            // اضافه کاری
            // بیمه و مالیات
//            OnProgress();
//            if(InsurancePercent != 0)
//            {
//                PayrollItem payrollItem = new PayrollItem();
//                payrollItem.FinancialType = FinancialType.Debt;
//                payrollItem.Heading = PayrollItemHeading.Insurance;
//                payrollItem.Text = "بیمه";
//                payrollItem.Description = "بیمه";
//                payrollItem.Unit = "دوره";
//                payrollItem.Count = 1;
//                float fee = 0;
//                if (InsuranceCalculationType == CalculationType.ByFixedAmount)
//                {
//                    fee = ((float)InsuranceBase*InsurancePercent)/100;
//                }
//                else if(InsuranceCalculationType == CalculationType.BySalary)
//                {
//                    var query = from item in payroll.Items
//                                where item.Heading == PayrollItemHeading.Working
//                                      && item.FinancialType == FinancialType.Credit
//                                select item.Amount;
//                    float salary = query.Sum();
//                    fee = (salary * InsurancePercent) / 100;
//                }
//                payrollItem.Fee = fee;
//                payroll.AddItem(payrollItem);
//            }
//
//            OnProgress();
//            if (TaxPercent != 0)
//            {
//                PayrollItem payrollItem = new PayrollItem();
//                payrollItem.FinancialType = FinancialType.Debt;
//                payrollItem.Heading = PayrollItemHeading.Tax;
//                payrollItem.Text = "مالیات";
//                payrollItem.Description = "مالیات";
//                payrollItem.Unit = "دوره";
//                payrollItem.Count = 1;
//                float fee = 0;
//                if (TaxCalculationType == CalculationType.ByFixedAmount)
//                {
//                    fee = ((float)TaxBase*TaxPercent)/100;
//                }
//                else if (TaxCalculationType == CalculationType.BySalary)
//                {
//                    var query = from item in payroll.Items
//                                where item.Heading == PayrollItemHeading.Working
//                                      && item.FinancialType == FinancialType.Credit
//                                select item.Amount;
//                    float salary = query.Sum();
//                    fee = (salary * TaxPercent) / 100;
//                }
//                payrollItem.Fee = fee;
//                payroll.AddItem(payrollItem);
//            }
//
//
            // سایر کسورات
            // سایر پرداختی ها
//
//            return payroll;
//        }

        public virtual IQueryable<Presence> GetPresences(Section section, PersianDate startDate, PersianDate endDate)
        {
            Teacher teacher = Staff as Teacher;
            IQueryable<Presence> presences = teacher.GetPresences(startDate, endDate);
//            List<Presence> list1 = presences.ToList();
            IQueryable<Presence> presences2 = presences.Where(x => x.SectionItem.Section.Id == section.Id).OrderBy(x => x.Date);
//            List<Presence> list2 = presences2.ToList();
            return presences2.AsQueryable();
        }

        public virtual float GetPresencesHours(Section section, PersianDate startDate, PersianDate endDate)
        {
//            Teacher teacher = Staff as Teacher;
//            IQueryable<Presence> presences = teacher.GetPresences(startDate, endDate);
//            IQueryable<Presence> presences2 = presences.Where(x => x.SectionItem.Section.Id == section.Id);
            IQueryable<Presence> presences = GetPresences(section, startDate, endDate);
            return (float) presences.Sum(x => x.Duration.TotalHours);
        }

        public virtual float GetPresencesSessions(Section section, PersianDate startDate, PersianDate endDate)
        {
//            Teacher teacher = Staff as Teacher;
//            IQueryable<Presence> presences = teacher.GetPresences(startDate, endDate);
//            IQueryable<Presence> presences2 = presences.Where(x => x.SectionItem.Section.Id == section.Id);
            IQueryable<Presence> presences = GetPresences(section, startDate, endDate);
            return presences.Count();
        }

//        public virtual IQueryable<Payroll> GetPayroll(PersianDate startDate, PersianDate endDate)
//        {
//            var query = from payroll in Payrolls
//                        where (payroll.StartDate >= startDate && payroll.StartDate <= endDate)
//                              || (payroll.StartDate <= startDate && payroll.StartDate >= endDate)
//                              || (payroll.EndDate >= startDate && payroll.EndDate <= endDate)
//                              || (payroll.EndDate <= startDate && payroll.EndDate >= endDate)
//                        select payroll;
//            return query.AsQueryable();
//        }
//
//        public virtual bool HasPayroll(PersianDate startDate, PersianDate endDate)
//        {
//            return GetPayroll(startDate, endDate).Count() > 0;
//        }
    }

    public class ConditionValue
    {
        public Section Section { get; set; }
        public SalaryCondition Condition { get; set; }
        public RateElement RateElement { get; set; }
        public ElementCalculationType CalculationType { get; set; }
        public TeachingContract TeachingContract { get; set; }

        public string ConditionText
        {
            get { return Condition.ToDescription(); }
        }
    }
}