using System;
using System.ComponentModel;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class RequestDefaultAns : DbObject
    {
        public RequestDefaultAns()
        {
            Title = "";
        }
        public virtual string Title { get; set; }
        public virtual string Desc { get; set; }
        //public static IQueryable<RequestDefaultAns> GetAllAns()
        //{
        //    var query = from RequestDefaultAns in DbContext.Entity<RequestDefaultAns>()
        //                select RequestDefaultAns;
        //    return query;
        //}
        #region Overrides of Object

        public override string ToString()
        {
            return Title;
        }

        #endregion
    }
}



