using rComponents;

namespace Fakher.Core.DomainModel
{
    public class TextPageItem : ExamPageItem
    {
        public override string DrawHtml()
        {
            return Text;
        }

        public override ExamPageItem Clone()
        {
            TextPageItem newItem = Services.Clone(this);
            return newItem;
        }
    }
}