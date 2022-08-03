using System.Collections.Generic;

namespace Fakher.Core.DomainModel
{
    public class PostalTrainingItem : TrainingItem
    {
        public virtual string Name { get; set; }
        public virtual IList<PostalTool> PostalTools { get; set; }

        public PostalTrainingItem()
        {
            PostalTools = new List<PostalTool>();
        }

        public virtual void AddPostalTool(PostalTool postalTool)
        {
            postalTool.Item = this;
            PostalTools.Add(postalTool);
        }
    }
}