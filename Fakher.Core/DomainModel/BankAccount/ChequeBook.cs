using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class ChequeBook : DbObject
    {
        public virtual long StartNumber { get; set; }
        public virtual long EndNumber { get; set; }
        [NoCascade]
        public virtual BankAccount BankAccount { get; set; }
    }
}
