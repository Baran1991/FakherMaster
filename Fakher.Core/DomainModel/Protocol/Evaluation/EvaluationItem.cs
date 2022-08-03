using System;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class EvaluationItem : DbObject
    {
        public EvaluationItem()
        {
        }

        public virtual string Name { get; set; }
        public virtual double Value { get; set; }
        [NoCascade]
        public virtual EvaluationGroup EvaluationGroup { get; set; }

        public virtual EvaluationItem Clone()
        {
            EvaluationItem item = Services.Clone(this);
            return item;
        }

        #region Overrides of Object

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}