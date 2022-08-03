using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class EducationalToolGroup : DbObject
    {
        public virtual string Name { get; set; }
        [NoCascade]
        public virtual Major Major { get; set; }
        [NoCascade]
        public virtual Lesson Lesson { get; set; }
        public virtual IList<GroupTool> GroupTools { get; set; }

        public EducationalToolGroup()
        {
            GroupTools = new List<GroupTool>();
        }

        public virtual IQueryable<GroupTool> GetSellGroupTools()
        {
            return GroupTools.Where(x => x.AllowSell).AsQueryable();
        }

        public virtual IQueryable<GroupTool> GetBorrowGroupTools()
        {
            return GroupTools.Where(x => x.AllowBorrow).AsQueryable();
        }
    }
}