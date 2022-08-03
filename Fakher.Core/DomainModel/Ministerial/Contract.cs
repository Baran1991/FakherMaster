using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Contract : DbObject
    {
        public virtual PersianDate StartDate { get; set; }
        public virtual PersianDate EndDate { get; set; }
        public virtual int DailyHours { get; set; }
        public virtual PaymentSystem PaymentSystem { get; set; }
        public virtual RateType RateType { get; set; }
        public virtual long BaseAmount { get; set; }
        public virtual SalaryRateProtocol RateProtocol { get; set; }
        public virtual long OverTimeFee { get; set; }
        public virtual int OverTimeRewardPercent { get; set; }
        public virtual long HolidayOverTimeFee { get; set; }
        public virtual int HolidayOverTimeRewardPercent { get; set; }
        public virtual CalculationType InsuranceCalculationType { get; set; }
        public virtual int InsurancePercent { get; set; }
        public virtual long InsuranceBase { get; set; }
        public virtual CalculationType TaxCalculationType { get; set; }
        public virtual int TaxPercent { get; set; }
        public virtual long TaxBase { get; set; }
        public virtual long AyabZahab { get; set; }
        public virtual string AyabZahabUnit { get; set; }

        public virtual long KharBar { get; set; }
        public virtual string KharBarUnit { get; set; }

        public virtual long Maskan { get; set; }
        public virtual string MaskanUnit { get; set; }

        public virtual long Sanavat { get; set; }
        public virtual string SanavatUnit { get; set; }

        public virtual long Taahol { get; set; }
        public virtual string TaaholUnit { get; set; }

        public virtual long Nahar { get; set; }
        public virtual string NaharUnit { get; set; }

        public virtual long ExamMin { get; set; }
        public virtual string ExamMinUnit { get; set; }

        public virtual long ExamFinal { get; set; }
        public virtual string ExamFinalUnit { get; set; }

        public virtual long ExamOther { get; set; }
        public virtual string ExamOtherUnit { get; set; }

        public virtual long Mosahebe { get; set; }
        public virtual string MosahebeUnit { get; set; }

        public virtual long SoratJalase { get; set; }
        public virtual string SoratJalaseUnit { get; set; }

        public virtual long Pazirayee { get; set; }
        public virtual string PazirayeeUnit { get; set; }

        public virtual long Marker { get; set; }
        public virtual string MarkerUnit { get; set; }

        public virtual long KharidEntesharat { get; set; }
        public virtual string KharidEntesharatUnit { get; set; }
        public virtual long Taakhirat { get; set; }
        public virtual string TaakhiratUnit { get; set; }
        public virtual long Sab { get; set; }
        public virtual string SabUnit { get; set; }
        public virtual long Sayer { get; set; }
        public virtual string SayerUnit { get; set; }

        [MaximumLength]
        public virtual string Notes { get; set; }
        [NoCascade]
        public virtual Staff Staff { get; set; }

        public virtual event EventHandler Progress;

        public Contract()
        {
//            Payrolls = new List<Payroll>();
            DailyHours = 8;
            PaymentSystem = PaymentSystem.Fixed;
            RateType = RateType.Fixed;
            InsuranceCalculationType = CalculationType.ByFixedAmount;
            TaxCalculationType = CalculationType.BySalary;

            ConditionValues = new List<ConditionValue>();
        }

        [NonPersistent]
        public virtual List<ConditionValue> ConditionValues { get; set; }

        [NonPersistent]
        public virtual string PaymentSystemText
        {
            get { return PaymentSystem.ToDescription(); }
        }

        [NonPersistent]
        public virtual string RateTypeText
        {
            get { return RateType.ToDescription(); }
        }

        [NonPersistent]
        public virtual string Text
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private void OnProgress()
        {
            if (Progress != null)
                Progress(this, EventArgs.Empty);
        }

        public virtual void PreCalculate(PayrollContract payrollContract)
        {
            
        }

        public virtual void Calculate(PayrollContract payrollContract)
        {
            
        }

        public static IList<Contract> GetContracts(SalaryRateProtocol salaryRateProtocol)
        {
            var query = from contract in DbContext.Entity<Contract>()
                        where contract.RateProtocol != null
                        && contract.RateProtocol.Id == salaryRateProtocol.Id
                        select contract;
            return query.ToList();
        }
    }

    public enum RateType
    {
        [EnumDescription("مقدار ثابت")]
        Fixed,
        [EnumDescription("بر اساس آیین نامه")]
        ByProtocol
    }

    public enum PaymentSystem
    {
        [EnumDescription("دستمـزد ثابت")]
        Fixed,
        [EnumDescription("دستمـزد ساعتی")]
        Hourly,
        [EnumDescription("دستمـزد جلسه ای")]
        Sessional
    }

    public enum CalculationType
    {
        [EnumDescription("درصد از کل حقوق")]
        BySalary,
        [EnumDescription("درصد از مقدار ثابت")]
        ByFixedAmount,
        [EnumDescription("مقدار ثابت")]
        ExactAmount,
        [EnumDescription("عدم محاسبه")]
        NoCalculation,
    }

}