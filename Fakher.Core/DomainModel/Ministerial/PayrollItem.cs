using System;
using System.Collections.Generic;
using DataAccessLayer;
using rComponents;
using System.Linq;

namespace Fakher.Core.DomainModel
{
    public class PayrollItem : DbObject
    {
        public PayrollItem()
        {
            RateElements = new List<RateElement>();
//            Infos = new List<PayrollItemInfo>();
        }

        public virtual PayrollItemHeading Heading { get; set; }
        public virtual FinancialType FinancialType { get; set; }
        public virtual string Text { get; set; }
        public virtual string Description { get; set; }
        public virtual float Count { get; set; }
        public virtual string Unit { get; set; }
        public virtual float Fee { get; set; }
        public virtual IList<RateElement> RateElements { get; set; }
//        public virtual IList<PayrollItemInfo> Infos { get; set; }
        [NoCascade]
        public virtual PayrollContract PayrollContract { get; set; }
        
        [NonPersistent]
        public virtual float Amount 
        { 
            get
            {
                float amount = Count * Fee;
                if (FinancialType == FinancialType.Debt)
                    return -amount;
                return amount;
            }
        }

        [NonPersistent]
        public virtual string HeadingText
        {
            get { return Heading.ToDescription(); }
        }

        [NonPersistent]
        public virtual string FinancialTypeText
        {
            get { return FinancialType.ToDescription(); }
        }

        public virtual void AddRateElements(RateElement[] elements)
        {
            foreach (RateElement element in elements)
            {
                element.PayrollItem = this;
                RateElements.Add(element);
            }
        }

        public virtual string GetConditionValue(SalaryCondition condition)
        {
            List<RateElement> elements = RateElements.Where(x => x.Condition == condition).ToList();
            if (elements.Count == 0)
                return "- -";
            if (elements.Count == 1)
                return elements[0].Value + "\r\n" + " (" + elements[0].Amount.ToString("C0") + ")";
            
            double sumValue = 0;
            double sumAmount = 0;
            foreach (RateElement element in elements)
            {
                try
                {
                    double d = Convert.ToDouble(element.Value);
                    sumValue += d;
                    sumAmount += element.Amount;
                }
                catch (Exception)
                {
                }
            }
            return Math.Round(sumValue, 2) + "\r\n" + " (" + sumAmount.ToString("C0") + ")";
        }

        public virtual PayrollItemInfo AddInfo(string key, string value)
        {
            PayrollItemInfo info = new PayrollItemInfo {Key = key, Value = value};
            info.PayrollItem = this;
//            Infos.Add(info);
            return info;
        }
    }

    public enum PayrollItemHeading
    {
        [EnumDescription("دستمزد")]
        Working,
        [EnumDescription("اضافه کاری")]
        OverTime,
        [EnumDescription("اضافه کاری روزهای تعطیل")]
        HolidayOverTime,
        [EnumDescription("سایر")]
        Other,
        [EnumDescription("بیمه")]
        Insurance,
        [EnumDescription("مالیات")]
        Tax,
        [EnumDescription("ایاب و ذهاب")]
        Transportation,
        [EnumDescription("غذا")]
        Food,
        [EnumDescription("لباس")]
        Uniform,
        [EnumDescription("خوار و بار")]
        Kharbar,
        [EnumDescription("مسکن")]
        Maskan,
        [EnumDescription("سنوات")]
        Sanavat,
        [EnumDescription("حق تاهل")]
        Taahol,
        [EnumDescription("آزمون میان ترم")]
        ExamMin,
        [EnumDescription("آزمون پایان ترم")]
        ExamFinal,
        [EnumDescription("سایر آزمونها")]
        ExamSayer,
        [EnumDescription("مصاحبه")]
        Mosahebe,
        [EnumDescription("صورت جلسه")]
        SoratJalase,
        [EnumDescription("پذیرایی")]
        Pazirayee,
        [EnumDescription("مارکر")]
        Marker,
        [EnumDescription("خرید انتشارات")]
        Entesharat,
        [EnumDescription("ساب")]
        Sab,
        [EnumDescription("سایر کسورات")]
        SayerKosorat,
        [EnumDescription("تاخیرات")]
        Taakirat,
    }
}