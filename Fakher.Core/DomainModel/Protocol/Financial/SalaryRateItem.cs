using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class SalaryRateItem : DbObject
    {
        public SalaryRateItem()
        {
            Operator = SalaryRateItemOperator.Value;
            SalaryCondition = SalaryCondition.Observer;
            IsInSectionWage = true;
        }

        public virtual EducationalDegree EducationalDegree { get; set; }
        public virtual SalaryRateItemOperator Operator { get; set; }
        public virtual SalaryCondition SalaryCondition { get; set; }
        public virtual double Minimum { get; set; }
        public virtual double Maximum { get; set; }
        public virtual long Amount { get; set; }
        public virtual SalaryRateProtocol Protocol { get; set; }
        public virtual bool IsInSectionWage { get; set; }
        public virtual bool IsInReplacementWage { get; set; }

        [NonPersistent]
        public virtual string ConditionText
        {
            get
            {
                if (SalaryCondition == SalaryCondition.LastDegree)
                    return "مدرک تحصیلی " + EducationalDegree.ToDescription();
                if (SalaryCondition == SalaryCondition.BasePayment)
                    return SalaryCondition.ToDescription();
                if(SalaryCondition == SalaryCondition.IeltsToefleDegree)
                    return SalaryCondition.ToDescription();
//                if(SalaryCondition == SalaryCondition.ToefleDegree)
//                    return SalaryCondition.ToDescription();

                else
                {
                    if (Operator == SalaryRateItemOperator.ForEach)
                        return SalaryCondition.ToDescription() + " به ازای هر " + Minimum;
                    if (Operator == SalaryRateItemOperator.Value)
                        return SalaryCondition.ToDescription() + " از " + Minimum + " تا " + Maximum;
                    return SalaryCondition.ToDescription() + " " + Operator.ToDescription() + " " + Minimum;
                }
            }
        }

        public virtual SalaryRateItem Clone()
        {
            SalaryRateItem clone = Services.Clone(this);
            return clone;
        }
    }

    public enum SalaryRateItemOperator
    {
        [EnumDescription("در بـــازه")]
        Value,
        [EnumDescription("به ازای هر")]
        ForEach,
        [EnumDescription("بـرابـــر")]
        Equal,
    }

    public enum SalaryCondition
    {
        [EnumDescription("پرداخت پــایه")]
        BasePayment,
        [EnumDescription("نمره آبزرو")]
        Observer,
        [EnumDescription("مدرک تافل/آیلتس")]
        IeltsToefleDegree,
//        [EnumDescription("مدرک آیلتس")]
//        IeltsDegree,
        [EnumDescription("درصد قبولی کلاس")]
        PassedPercent,
        [EnumDescription("کل تعداد ترمهای تدریس")]
        TeachingTermHistory,
        [EnumDescription("تعداد ترم تدریس در سال قبل")]
        LastYearTeachingTerms,
        [EnumDescription("ساعات تدریس")]
        TeachingHours,
        [EnumDescription("تعداد کلاس در ترم جاری")]
        CurrentSectionCount,
        [EnumDescription("آخرین مدرک تحصیلی")]
        LastDegree,
        [EnumDescription("تعداد کلاس در جمعه")]
        FridaySectionCount,
        [EnumDescription("اضافه کاری عادی")]
        EzafeKariAdi,
        [EnumDescription("اضافه کاری روز تعطیل")]
        EzafeKariTaatil,
        [EnumDescription("ایاب و ذهاب")]
        AyabZahab,
        [EnumDescription("بن خوار و بار")]
        Bon,
        [EnumDescription("حق مسکن")]
        Maskan,
        [EnumDescription("سنوات")]
        Sanavat,
        [EnumDescription("حق تاهل")]
        Taahol,
        [EnumDescription("هزینه ناهار")]
        Nahar,
        [EnumDescription("آزمون میان ترم")]
        AzmoonMianTerm,
        [EnumDescription("آزمون پایان ترم")]
        AzmoonPayanTerm,
        [EnumDescription("سایر آزمون ها")]
        SayerAzmoon,
        [EnumDescription("مصاحبه ها")]
        Mosahebeha
    }
}