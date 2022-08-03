using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class Protocol : DbObject
    {
        public Protocol()
        {
        }

        public virtual string Name { get; set; }
        [NoCascade]
        public virtual EducationalPeriod Period { get; set; }
        [NoCascade]
        public virtual Protocol Parent { get; set; }

        public static T GetProtocol<T>(Protocol parentProtocol, EducationalPeriod period) where T : Protocol
        {
            var query = from protocol in DbContext.Entity<T>()
                        where
                            protocol.Period.Id == period.Id 
                            && protocol.Period != null 
                            && protocol.Parent.Id == parentProtocol.Id
                        select protocol;
            return query.FirstOrDefault();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}