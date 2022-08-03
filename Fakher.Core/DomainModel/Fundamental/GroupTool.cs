using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class GroupTool : DbObject
    {
        public GroupTool()
        {
            AllowedToUseCount = 1;
        }

        [NoCascade]
        public virtual EducationalToolGroup Group { get; set; }
        [NoCascade]
        public virtual EducationalTool EducationalTool { get; set; }
        public virtual bool AllowSell { get; set; }
        public virtual bool AllowBorrow { get; set; }
        public virtual int AllowedToUseCount { get; set; }

        public static GroupTool FromId(int id)
        {
            return DbContext.FromId<GroupTool>(id);
        }

        public static GroupTool FromEducationalTool(EducationalTool tool, EducationalToolGroup toolGroup)
        {
            GroupTool groupTool = new GroupTool();
            groupTool.EducationalTool = tool;
            groupTool.Group = toolGroup;

            return groupTool;
        }
    }
}