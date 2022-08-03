using DataAccessLayer;
using rComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakher.Core.DomainModel
{
   public class FinancialHeading : DbObject
    {
        public virtual string Text { get; set; }
        public virtual PersianDate Date { get; set; }
    }
}
