using System;
using System.ComponentModel;
using DataAccessLayer;
using rComponents;
using System.Linq;

namespace Fakher.Core.DomainModel
{
    public class ResultLabel : DbObject
    {
        public ResultLabel()
        {
            HasMarkRule = true;
            HasAbsenceRule = false;
        }

        public virtual string Name { get; set; }
        public virtual bool HasMarkRule { get; set; }
        public virtual bool HasAbsenceRule { get; set; }
        public virtual bool HasMandatoryExamRule { get; set; }
        public virtual CountOperator CountOperator { get; set; }
        public virtual int AbsenceCount { get; set; }
        public virtual double MinimumValue { get; set; }
        public virtual double MaximumValue { get; set; }
        [NoCascade]
        public virtual ResultProtocol ResultProtocol { get; set; }

        [NonPersistent]
        public virtual string Text
        {
            get
            {
                string txt = "";
                if (HasMarkRule)
                    txt += string.Format("از نمره {0} تا {1}", MinimumValue, MaximumValue);
                if (HasAbsenceRule)
                    txt += " " + CountOperator.ToDescription() + " " + AbsenceCount + " جلسه غیبت ";
                if (HasMandatoryExamRule)
                    txt += " غیبت در آزمون های اجباری ";
                return txt;
            }
        }

        public virtual bool HasIntersect(ResultLabel label)
        {
            if (MinimumValue > label.MinimumValue && MinimumValue < label.MaximumValue)
                return true;
            if (MaximumValue < label.MaximumValue && MaximumValue > label.MinimumValue)
                return true;
            return false;
        }

        public virtual bool CanApply(float mark, int absenceCount, bool mandatoryLack)
        {
//            float mark = participate.CalculateMark();
//            int absenceCount = participate.GetAbsences().Count();

            bool condition1 = true, condition2 = true;

            if(HasMarkRule)
            {
                if (MinimumValue == MaximumValue)
                    condition1 = mark == MinimumValue;
                else
                    condition1 = (mark >= MinimumValue && mark < MaximumValue);
            }
            if(HasAbsenceRule)
            {
                if (CountOperator == CountOperator.Maximum)
                    condition2 = absenceCount <= AbsenceCount;
                if (CountOperator == CountOperator.Only)
                    condition2 = absenceCount == AbsenceCount;
                if (CountOperator == CountOperator.Minimum)
                    condition2 = absenceCount >= AbsenceCount;
            }
            
            if (HasMandatoryExamRule)
                if (mandatoryLack)
                    return true;

            return condition1 && condition2;
        }

        public virtual ResultLabel Clone()
        {
            ResultLabel label = Services.Clone(this);
            return label;
        }

        #region Overrides of Object

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
    public enum CountOperator
    {
        [EnumDescription("حداقل")]
        Minimum,
        [EnumDescription("فقط")]
        Only,
        [EnumDescription("حداکثر")]
        Maximum
    }
//    public enum ResultLabelType
//    {
//        [Description("بر اساس نمره کسب شده")]
//        ByMark,
//        [Description("بر اساس تعداد جلسه غیبت")]
//        ByAbsence
//    }
}