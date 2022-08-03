using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer;
using System.Linq;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class EvaluationProtocol : Protocol
    {
        public EvaluationProtocol()
        {
            EvaluationGroups = new List<EvaluationGroup>();
            Operator = EvaluationOperator.Sum;
        }

        public virtual EvaluationOperator Operator { get; set; }

        public virtual IList<EvaluationGroup> EvaluationGroups { get; set;  }
        public virtual bool CanDelete()
        {
            if (DbContext.GetAll<EvaluationGroup>().Where(m => m.EvaluationProtocol.Id == this.Id).Count() > 0)
                return false;
            if (DbContext.GetAll<TrainingPlan>().Where(m => m.Id == this.Id).Count() > 0)
                return false;
            return true;
        }
        [NonPersistent]
        public virtual double TotalValue
        {
            get
            {
                if (Operator == EvaluationOperator.Sum)
                    return EvaluationGroups.Sum(x => x.TotalValue);
                if (Operator == EvaluationOperator.Average)
                    return EvaluationGroups.Average(x => x.TotalValue);
                throw new Exception("TotalValue قابل محاسبه نیست.");
            }
        }

        public virtual IQueryable<EvaluationItem> GetAllItems()
        {
            var query = from evalGroup in EvaluationGroups
                        from item in evalGroup.Items
                        select item;
            return query.AsQueryable();
        }

        public virtual float CalculateMark(Dictionary<EvaluationItem, float> marks)
        {
            if(Operator == EvaluationOperator.Sum)
                return (from mark in marks select mark.Value).Sum();
            if(Operator == EvaluationOperator.Average)
                return (from mark in marks select mark.Value).Average();

            throw new Exception("اپراتور نمره نهایی مشخص نیست.");
        }

        public virtual EvaluationProtocol Clone()
        {
            EvaluationProtocol protocol = Services.Clone(this);
            foreach (EvaluationGroup @group in EvaluationGroups)
            {
                EvaluationGroup clone = @group.Clone();
                clone.EvaluationProtocol = protocol;
                protocol.EvaluationGroups.Add(clone);
            }
            return protocol;
        }

        public static IList<EvaluationProtocol> GetProtocols(EducationalPeriod period)
        {
            var query = from protocol in DbContext.Entity<EvaluationProtocol>()
                        where protocol.Period.Id == period.Id
                        select protocol;
            return query.ToList();
        }

        public virtual EvaluationItem FindItem(string groupName, string itemName)
        {
            var query = from @group in EvaluationGroups
                        from item in @group.Items
                        where @group.Name == groupName
                              && item.Name == itemName
                        select item;
            return query.FirstOrDefault();
        }
    }

    public enum EvaluationOperator
    {
        [EnumDescription("میانگین")]
        Average,
        [EnumDescription("مجموع")]
        Sum
    }
}