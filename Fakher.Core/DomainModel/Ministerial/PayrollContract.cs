using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class PayrollContract : DbObject
    {
        public PayrollContract()
        {
            Items = new List<PayrollItem>();
            PaidList = new List<PayrollPaid>();
        }

        public virtual PersianDate StartDate { get; set; }
        public virtual PersianDate EndDate { get; set; }
        [NoProxy]
        [NoCascade]
        public virtual Contract Contract { get; set; }
        [NoCascade]
        public virtual Payroll Payroll { get; set; }
        public virtual IList<PayrollItem> Items { get; set; }
        public virtual IList<PayrollPaid> PaidList { get; set; }

        [NonPersistent]
        public virtual TeachingContract TeachingContract
        {
            get { return Contract as TeachingContract; }
        }

        [NonPersistent]
        public virtual EmploymentContract EmploymentContract
        {
            get { return Contract as EmploymentContract; }
        }

        [NonPersistent]
        public virtual float PayableAmount
        {
            get { return Items.Sum(x => x.Amount); }
        }
        [NonPersistent]
        public virtual float PaidAmount
        {
            get { return PaidList.Sum(x => x.Amount); }
        }
        public virtual void AddItem(PayrollItem item)
        {
            item.PayrollContract = this;
            Items.Add(item);
        }
        public virtual void AddPayment(PayrollPaid item)
        {
            item.PayrollContract = this;
            PaidList.Add(item);
        }
        //        public virtual RateElement[] GetRateElements(Section section, ElementCalculationType calculationType)
        //        {
        //            if (Contract.RateType == RateType.Fixed)
        //                return new[] { new RateElement { Text = "نرخ ثابت", Amount = Contract.BaseAmount } };
        //            if (Contract.RateType == RateType.ByProtocol)
        //                return Contract.RateProtocol.CalculateRate(TeachingContract, section, calculationType);
        //            throw new Exception("مقدار دستمزد قابل محاسبه نیست.");
        //        }

        public virtual void PreCalculate()
        {
            Contract.PreCalculate(this);
        }

        public virtual void Calculate()
        {
            Items.Clear();
            Contract.Calculate(this);
        }

//        public virtual void Calculate()
//        {
            //                            OnProgress();
//            Teacher teacher = Contract.Staff as Teacher;
//            IList<Replacement> replacements = teacher.GetPresenceReplacements(StartDate, EndDate);
//            IList<Section> teachingSections = teacher.GetPresenceSections(StartDate, EndDate);
            //                OnProgress();
//
//            if (Contract.PaymentSystem == PaymentSystem.Fixed)
//            {
//                foreach (Section section in teachingSections)
//                {
//                    if (section.Major.Id != TeachingContract.Major.Id)
//                        continue;
//                    if (!section.WageCalculation)
//                        continue;
//
//                    OnProgress();
//
//                    PayrollItem payrollItem = new PayrollItem();
//                    payrollItem.FinancialType = FinancialType.Credit;
//                    payrollItem.Heading = PayrollItemHeading.Working;
//                    payrollItem.Text = section.MasterItemText + " " + section.FarsiName;
//                    payrollItem.Description = section.MasterItemText + " " + section.FarsiName + " رشته " + section.Major.Name;
//                    payrollItem.Unit = "دوره";
//                    payrollItem.Count = 1;
//                    RateElement[] rateElements = GetRateElements(section, ElementCalculationType.SectionCalculation);
//                    if (Contract.BaseAmount > 0)
//                        payrollItem.AddRateElements(new[]
//                                                            {
//                                                                new RateElement
//                                                                    {
//                                                                        Condition = SalaryCondition.BasePayment,
//                                                                        Amount = Contract.BaseAmount,
//                                                                        Section = section,
//                                                                        Text = "نرخ پایه",
//                                                                        Value = Contract.BaseAmount.ToString("C0")
//                                                                    }
//                                                            });
//                    payrollItem.AddRateElements(rateElements);
//                    payrollItem.Fee = payrollItem.RateElements.Sum(x => x.Amount);
//
//                    AddItem(payrollItem);
//                }
//            }
//
//            if (Contract.PaymentSystem == PaymentSystem.Hourly)
//            {
//                foreach (Section section in teachingSections)
//                {
//                    if (section.Major.Id != TeachingContract.Major.Id)
//                        continue;
//                    if (!section.WageCalculation)
//                        continue;
//                    IQueryable<Presence> presences = TeachingContract.GetPresences(section, StartDate, EndDate);
//                    float presencesHours = (float)Math.Round(TeachingContract.GetPresencesHours(section, StartDate, EndDate), 1);
//
//                    OnProgress();
//
//                    PayrollItem payrollItem = new PayrollItem();
//                    payrollItem.FinancialType = FinancialType.Credit;
//                    payrollItem.Heading = PayrollItemHeading.Working;
//                    payrollItem.Text = section.MasterItemText + " " + section.FarsiName;
//                    payrollItem.Description = section.MasterItemText + " " + section.FarsiName + " رشته " + section.Major.Name + " از " +
//                                              presences.First().Date.ToShortDateString() + " تا " +
//                                              presences.Last().Date.ToShortDateString();
//                    payrollItem.Unit = "ساعت";
//                    RateElement[] rateElements = GetRateElements(section, ElementCalculationType.SectionCalculation);
//                    if (Contract.BaseAmount > 0)
//                        payrollItem.AddRateElements(new[]
//                                                            {
//                                                                new RateElement
//                                                                    {
//                                                                        Condition = SalaryCondition.BasePayment,
//                                                                        Amount = Contract.BaseAmount,
//                                                                        Section = section,
//                                                                        Text = "نرخ پایه",
//                                                                        Value = Contract.BaseAmount.ToString("C0")
//                                                                    }
//                                                            });
//                    payrollItem.AddRateElements(rateElements);
//                    payrollItem.Fee = payrollItem.RateElements.Sum(x => x.Amount);
//                    payrollItem.Count = presencesHours;
//
//                    AddItem(payrollItem);
//                }
//
//                foreach (Replacement replacement in replacements)
//                {
//                    if (replacement.SectionItem.Section.Major.Id != TeachingContract.Major.Id)
//                        continue;
//
//                    OnProgress();
//
//                    PayrollItem payrollItem = new PayrollItem();
//                    payrollItem.FinancialType = FinancialType.Credit;
//                    payrollItem.Heading = PayrollItemHeading.Working;
//                    payrollItem.Text = "جانشینی در " + replacement.SectionItem.Lesson.Name + "، " + replacement.SectionItem.Section.FarsiName;
//                    payrollItem.Description = "جانشینی " + replacement.Date.ToShortDateString() + " در " +
//                                              replacement.SectionItem.Lesson.Name + "، " + replacement.SectionItem.Section.FarsiName + " رشته " +
//                                              replacement.SectionItem.Section.Major.Name + " به جای " +
//                                              replacement.SectionItem.Section.Teacher.FarsiFullname;
//                    payrollItem.Unit = "ساعت";
//                    RateElement[] rateElements = GetRateElements(replacement.SectionItem.Section, ElementCalculationType.ReplacementCalculation);
//                    if (Contract.BaseAmount > 0)
//                        payrollItem.AddRateElements(new[]
//                                                            {
//                                                                new RateElement
//                                                                    {
//                                                                        Condition = SalaryCondition.BasePayment,
//                                                                        Amount = Contract.BaseAmount,
//                                                                        Section = replacement.SectionItem.Section,
//                                                                        Text = "نرخ پایه",
//                                                                        Value = Contract.BaseAmount.ToString("C0")
//                                                                    }
//                                                            });
//                    payrollItem.AddRateElements(rateElements);
//                    payrollItem.Fee = payrollItem.RateElements.Sum(x => x.Amount);
//                    payrollItem.Count = replacement.ReplacementHours;
//
//                    AddItem(payrollItem);
//                }
//            }
//
//            if (Contract.PaymentSystem == PaymentSystem.Sessional)
//            {
//                foreach (Section section in teachingSections)
//                {
//                    if (section.Major.Id != TeachingContract.Major.Id)
//                        continue;
//                    if (!section.WageCalculation)
//                        continue;
//
//                    OnProgress();
//
//                    PayrollItem payrollItem = new PayrollItem();
//                    payrollItem.FinancialType = FinancialType.Credit;
//                    payrollItem.Heading = PayrollItemHeading.Working;
//                    payrollItem.Text = section.FarsiName;
//                    payrollItem.Description = section.MasterItemText + " " + section.FarsiName + " رشته " + section.Major.Name;
//                    payrollItem.Unit = "جلسه";
//                    RateElement[] rateElements = GetRateElements(section, ElementCalculationType.SectionCalculation);
//                    if (Contract.BaseAmount > 0)
//                        payrollItem.AddRateElements(new[]
//                                                            {
//                                                                new RateElement
//                                                                    {
//                                                                        Condition = SalaryCondition.BasePayment,
//                                                                        Amount = Contract.BaseAmount,
//                                                                        Section = section,
//                                                                        Text = "نرخ پایه",
//                                                                        Value = Contract.BaseAmount.ToString("C0")
//                                                                    }
//                                                            });
//                    payrollItem.AddRateElements(rateElements);
//                    payrollItem.Fee = payrollItem.RateElements.Sum(x => x.Amount);
//                    payrollItem.Count = TeachingContract.GetPresencesSessions(section, StartDate, EndDate);
//
//                    AddItem(payrollItem);
//                }
//            }
//
//
//
            // اضافه کاری
            // بیمه و مالیات
//            OnProgress();
//            if (Contract.InsurancePercent != 0)
//            {
//                PayrollItem payrollItem = new PayrollItem();
//                payrollItem.FinancialType = FinancialType.Debt;
//                payrollItem.Heading = PayrollItemHeading.Insurance;
//                payrollItem.Text = "بیمه";
//                payrollItem.Description = "بیمه";
//                payrollItem.Unit = "دوره";
//                payrollItem.Count = 1;
//                float fee = 0;
//                if (Contract.InsuranceCalculationType == CalculationType.ByFixedAmount)
//                {
//                    fee = ((float)Contract.InsuranceBase * Contract.InsurancePercent) / 100;
//                }
//                else if (Contract.InsuranceCalculationType == CalculationType.BySalary)
//                {
//                    var query = from item in Items
//                                where item.Heading == PayrollItemHeading.Working
//                                      && item.FinancialType == FinancialType.Credit
//                                select item.Amount;
//                    float salary = query.Sum();
//                    fee = (salary * Contract.InsurancePercent) / 100;
//                }
//                payrollItem.Fee = fee;
//                AddItem(payrollItem);
//            }
//
//            OnProgress();
//            if (Contract.TaxPercent != 0)
//            {
//                PayrollItem payrollItem = new PayrollItem();
//                payrollItem.FinancialType = FinancialType.Debt;
//                payrollItem.Heading = PayrollItemHeading.Tax;
//                payrollItem.Text = "مالیات";
//                payrollItem.Description = "مالیات";
//                payrollItem.Unit = "دوره";
//                payrollItem.Count = 1;
//                float fee = 0;
//                if (Contract.TaxCalculationType == CalculationType.ByFixedAmount)
//                {
//                    fee = ((float)Contract.TaxBase * Contract.TaxPercent) / 100;
//                }
//                else if (Contract.TaxCalculationType == CalculationType.BySalary)
//                {
//                    var query = from item in Items
//                                where item.Heading == PayrollItemHeading.Working
//                                      && item.FinancialType == FinancialType.Credit
//                                select item.Amount;
//                    float salary = query.Sum();
//                    fee = (salary * Contract.TaxPercent) / 100;
//                }
//                payrollItem.Fee = fee;
//                AddItem(payrollItem);
//            }
//
//
            // سایر کسورات
            // سایر پرداختی ها
//        }

    }
}