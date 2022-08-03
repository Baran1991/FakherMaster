using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class SalaryRateProtocol : Protocol
    {
        public virtual IList<SalaryRateItem> Items { get; set; }

        public SalaryRateProtocol()
        {
            Items = new List<SalaryRateItem>();
        }

        public static IList<SalaryRateProtocol> GetAllProtocols()
        {
            return DbContext.GetAllEntities<SalaryRateProtocol>();
        }

        public static IList<SalaryRateProtocol> GetProtocols(EducationalPeriod period)
        {
            var query = from protocol in DbContext.Entity<SalaryRateProtocol>()
                        where protocol.Period.Id == period.Id
                        select protocol;
            return query.ToList();
        }

        private bool CanApply(SalaryRateItem item, float value)
        {
            if (item.Operator == SalaryRateItemOperator.Value)
                if (value >= item.Minimum && value < item.Maximum)
                    return true;
            if(item.Operator == SalaryRateItemOperator.ForEach)
                return true;
            if (item.Operator == SalaryRateItemOperator.Equal)
                if (value == item.Minimum)
                    return true;
            return false;
        }

        private float CalculateAmount(SalaryRateItem item, float value)
        {
            if (item.Operator == SalaryRateItemOperator.Value)
                if (value >= item.Minimum && value < item.Maximum)
                    return item.Amount;
            if(item.Operator == SalaryRateItemOperator.ForEach)
            {
                if(item.Minimum != item.Maximum)
                    throw new Exception(string.Format("مقدار حداقل و حداکثر در آیتم {0} با هم برابر نیستند.", item.SalaryCondition.ToDescription()));
                int count = (int)(value / item.Minimum);
                return count*item.Amount;
            }
            if (item.Operator == SalaryRateItemOperator.Equal)
                if (value == item.Minimum)
                    return item.Amount;
            throw new Exception("مقدار مبلغ المان دستمزد قابل محاسبه نیست");
        }

        public virtual RateElement CreateElement(SalaryCondition condition, string value, string text, float amount, Section section, ElementCalculationType calculationType)
        {
            RateElement element = new RateElement();
            element.Condition = condition;
            element.Value = value;
            element.Text = text;
            element.Amount = amount;
            element.Section = section;
            element.CalculationType = calculationType;
            return element;
        }

        public virtual RateElement[] CalculateRate(TeachingContract contract, Section section, ElementCalculationType calculationType, PersianDate calculationStartDate, PersianDate calculationEndDate)
        {
            Teacher teacher = contract.Staff as Teacher;
            IList<RateElement> elements = new List<RateElement>();
            bool canCalculatePassPercent = true;
            float passPercent = 0;
            try
            {
                passPercent = section.CalculatePassPercent();
            }
            catch (Exception e)
            {
                canCalculatePassPercent = false;
            }

            ObserveMark observeMark1 = section.GetLastObserveMark(ObserveMarkType.Observe);
            ObserveMark observeMark2 = section.GetLastObserveMark(ObserveMarkType.ClassObserve);
            ObserveMark observeMark3 = section.GetLastObserveMark(ObserveMarkType.InstituteObserve);


//            IList<Section> teachingSections = teacher.GetTeachingSections(contract.Major, calculationStartDate, calculationEndDate);
            IList<Section> teachingSections = teacher.GetPresenceSections(contract.Major, calculationStartDate, calculationEndDate);
            IList<Section> fridaySections = new List<Section>();
            int fridayCount = 0;
            foreach (Section teachingSection in teachingSections)
                foreach (Formation formation in teachingSection.Formations)
                    if (formation.Day == WeekDay.Friday)
                    {
                        fridayCount++;
                        fridaySections.Add(teachingSection);
                        break;
                    }



            foreach (SalaryRateItem item in contract.RateProtocol.Items)
            {
                if (calculationType == ElementCalculationType.SectionCalculation && !item.IsInSectionWage)
                    continue;
                if(calculationType == ElementCalculationType.ReplacementCalculation && !item.IsInReplacementWage)
                    continue;

                if (item.SalaryCondition == SalaryCondition.BasePayment)
                {
                    elements.Add(CreateElement(item.SalaryCondition, item.SalaryCondition.ToDescription(), item.ConditionText, item.Amount, section, calculationType));
                }
                if (item.SalaryCondition == SalaryCondition.IeltsToefleDegree)
                    if (teacher.HasIelts || teacher.HasToefle)
                    {
                        elements.Add(CreateElement(item.SalaryCondition, "دارد", item.ConditionText, item.Amount, section, calculationType));
                    }
                if (item.SalaryCondition == SalaryCondition.LastDegree)
                    if (teacher.LastEducationalDegree == item.EducationalDegree)
                    {
                        elements.Add(CreateElement(item.SalaryCondition, teacher.LastEducationalDegree.ToDescription(), item.ConditionText, item.Amount, section, calculationType));
                    }
                if(item.SalaryCondition == SalaryCondition.Observer)
                {
                    if(observeMark1 == null && observeMark2 == null && observeMark3 == null)
                        continue;

                    int count = 0;
                    float mark = 0;
                    if(observeMark1 != null)
                    {
                        mark += observeMark1.Mark;
                        count++;
                    }
                    if (observeMark2 != null)
                    {
                        mark += observeMark2.Mark;
                        count++;
                    }
                    if (observeMark3 != null)
                    {
                        mark += observeMark3.Mark;
                        count++;
                    }

                    mark = mark/count;
                    
                    if (CanApply(item, mark))
                    {
                        float amount = CalculateAmount(item, mark);
                        elements.Add(CreateElement(item.SalaryCondition, mark.ToString("F2"), item.ConditionText, amount, section, calculationType));
                    }
                }
                if(item.SalaryCondition == SalaryCondition.TeachingTermHistory)
                {
                    int teachingHistory = teacher.GetPresenceTeachingPeriods(contract.Major).Count();
                    teachingHistory += contract.TermHistory;
                    if (CanApply(item, teachingHistory))
                    {
                        float amount = CalculateAmount(item, teachingHistory);
                        elements.Add(CreateElement(item.SalaryCondition, teachingHistory + "", item.ConditionText,
                                                   amount, section, calculationType));
                    }
                }
                if (item.SalaryCondition == SalaryCondition.LastYearTeachingTerms)
                {
//                    int teachingHistory = teacher.GetPresenceTeachingPeriods(contract.Period.Year - 1, contract.Major).Count();
                    int teachingHistory = teacher.GetPresenceTeachingPeriods(calculationStartDate.Year - 1, contract.Major).Count();
                    if (CanApply(item, teachingHistory))
                    {
                        float amount = CalculateAmount(item, teachingHistory);
                        elements.Add(CreateElement(item.SalaryCondition, teachingHistory + "", item.ConditionText,
                                                   amount, section, calculationType));
                    }
                }
                if(item.SalaryCondition == SalaryCondition.PassedPercent)
                {
                    if (canCalculatePassPercent && CanApply(item, passPercent))
                    {
                        float amount = CalculateAmount(item, passPercent);
                        elements.Add(CreateElement(item.SalaryCondition, passPercent.ToString("F2"), item.ConditionText, amount, section, calculationType));
                    }
                }
                if(item.SalaryCondition == SalaryCondition.TeachingHours)
                {
//                    int count = teacher.GetFinishedSections(contract.Major).Count();
                    int count = teacher.GetPresenceSections(contract.Major).Count();
                    float value = teacher.GetPresenceTeachingHours(contract.Major);
                    value += contract.TeachingHoursHistory;
                    if (CanApply(item, value))
                    {
                        float amount = CalculateAmount(item, value);
                        if (amount != 0)
                        {
                            elements.Add(CreateElement(item.SalaryCondition, count + " گروه، " + value,
                                                       item.ConditionText, amount, section, calculationType));
                        }
                    }
                }
                if (item.SalaryCondition == SalaryCondition.CurrentSectionCount)
                {
//                    IList<Section> teachingSections = teacher.GetTeachingSections(contract.Period);
//                    IList<Section> sections = teacher.GetPresenceSections(calculationStartDate, calculationEndDate);
//                    IList<Section> teachingSections = teacher.GetTeachingSections(contract.Major, calculationStartDate, calculationEndDate);
                    if (CanApply(item, teachingSections.Count))
                    {
                        float amount = CalculateAmount(item, teachingSections.Count);
                        elements.Add(CreateElement(item.SalaryCondition, teachingSections.Count + "", item.ConditionText,
                                                   amount, section, calculationType));
                    }
                }
                if(item.SalaryCondition == SalaryCondition.FridaySectionCount)
                {
                    if (fridaySections.Contains(section) && CanApply(item, fridayCount))
                    {
                        elements.Add(CreateElement(item.SalaryCondition, fridayCount + "", item.ConditionText, item.Amount,
                                                   section, calculationType));
                    }
                }
            }
            return elements.ToArray();
        }

        public virtual RateElement[] CalculateRate(EmploymentContract contract, ElementCalculationType calculationType, PersianDate calculationStartDate, PersianDate calculationEndDate)
        {
            return new RateElement[0];
        }

        public virtual SalaryRateProtocol Clone()
        {
            SalaryRateProtocol protocol = Services.Clone(this);
            foreach (SalaryRateItem item in Items)
            {
                SalaryRateItem clone = item.Clone();
                clone.Protocol = protocol;
                protocol.Items.Add(clone);
            }
            return protocol;
        }

        public override void Delete()
        {
            var query = from protocol in DbContext.Entity<SalaryRateProtocol>()
                        where protocol.Parent.Id == Id
                        select protocol;
            foreach (SalaryRateProtocol protocol in query)
            {
                protocol.Parent = null;
                protocol.Save();
            }
            base.Delete();
        }
    }

    public enum FinancialProtocolItemBehavior
    {
        [EnumDescription("پرداخت ثابت")]
        Fixed,
        [EnumDescription("پرداخت ساعتی")]
        Hourly,
        [EnumDescription("پرداخت جلسه ای")]
        Sessional,
        [EnumDescription("پرداخت اضافه کاری")]
        OverTime,
        [EnumDescription("پرداخت اضافه کاری روزتعطیل")]
        HolidayOverTime,
        [EnumDescription("پرداخت درصدی")]
        Percent
    }

    public enum ElementCalculationType
    {
        SectionCalculation,
        ReplacementCalculation,
    }
}