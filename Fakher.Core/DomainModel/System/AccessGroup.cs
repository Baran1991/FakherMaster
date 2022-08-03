using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class AccessGroup : DbObject
    {
        public AccessGroup()
        {
            AccessString = "";
            AccessTags = new List<AccessTag>();
        }

        public virtual string Name { get; set; }
        [MaximumLength]
        public virtual string AccessString { get; set; }
        public virtual AccessPanel AccessPanel { get; set; }
        public virtual IList<AccessTag> AccessTags { get; set; } 

        public virtual bool IsAllowed(string text)
        {
            return AccessString.Contains(text);
        }
        public virtual bool CanDelete()
        {
            if (this.AccessTags.Any())
                return false;
            if (DbContext.GetAll<UserInfo>().Where(m => m.AccessGroup.Id == this.Id).Any() )
                return false;
            return true;
        }
    }

    public enum AccessPanel
    {
        [EnumDescription("پنل پرسنل اداری")]
        EmployeePanel,
        [EnumDescription("پنل اساتید")]
        TeacherPanel,
        [EnumDescription("پنل مشـاوره")]
        ConsultationPanel,
        [EnumDescription("پنل فروشگاه")]
        BuffetPanel,
    }
}