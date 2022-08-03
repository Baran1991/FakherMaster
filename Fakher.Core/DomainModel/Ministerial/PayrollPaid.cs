using System;
using System.Collections.Generic;
using DataAccessLayer;
using rComponents;
using System.Linq;

namespace Fakher.Core.DomainModel
{
    public class PayrollPaid : DbObject
    {
        public PayrollPaid()
        {
            Date= PersianDate.Today;
        }


        public virtual string BankName { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual PersianDate Date { get; set; }
        public virtual float Amount { get; set; }

        [NoCascade]
        public virtual PayrollContract PayrollContract { get; set; }

    }
}