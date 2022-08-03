using System;
using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class RateElement : DbObject
    {
        public RateElement()
        {
            CalculationType = ElementCalculationType.SectionCalculation;
        }

        public virtual SalaryCondition Condition { get; set; }
        public virtual string Value { get; set; }
        public virtual string Text { get; set; }
        public virtual float Amount { get; set; }
        [NoCascade]
        public virtual PayrollItem PayrollItem { get; set; }
        [NoCascade]
        public virtual Section Section { get; set; }
        public virtual ElementCalculationType CalculationType { get; set; }

        [NonPersistent]
        public virtual float FloatValue
        {
            get { return Convert.ToSingle(Value); }
        }
    }
}