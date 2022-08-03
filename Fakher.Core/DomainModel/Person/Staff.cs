using System.Collections.Generic;

namespace Fakher.Core.DomainModel
{
    public class Staff : Person
    {
        public Staff()
        {
            Disabled = false;
            Contracts = new List<Contract>();
            Payrolls = new List<Payroll>();
        }
        public virtual bool Disabled { get; set; }
        public virtual IList<Contract> Contracts { get; set; }
        public virtual IList<Payroll> Payrolls { get; set; }
    }
}