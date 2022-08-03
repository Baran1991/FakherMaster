using System;
using System.ComponentModel;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Branch : DbObject
    {
        public Branch()
        {
            Name = "";
           
        }

        public virtual string Name { get; set; }

        public virtual string Address { get; set; }
        #region Overrides of Object

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }

   
}