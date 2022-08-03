using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class PostalTool : DbObject
    {
        public virtual EducationalTool EducationalTool { get; set; }
        public virtual PostalTrainingItem Item { get; set; }
    }
}