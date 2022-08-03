using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class EvaluationGroup : DbObject
    {
        public EvaluationGroup()
        {
            Items = new List<EvaluationItem>();
        }

        public virtual string Name { get; set; }
        [NoCascade]
        public virtual EvaluationProtocol EvaluationProtocol { get; set; }
        public virtual IList<EvaluationItem> Items { get; set; }

        [NonPersistent]
        public virtual double TotalValue
        {
            get { return (from item in Items select item.Value).Sum(); }
        }

        public virtual EvaluationGroup Clone()
        {
            EvaluationGroup @group = Services.Clone(this);
            foreach (EvaluationItem item in Items)
            {
                EvaluationItem clone = item.Clone();
                clone.EvaluationGroup = @group;
                @group.Items.Add(clone);
            }
            return @group;
        }

        #region Overrides of Object

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}