using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ExamEssayQuestion : ExamPageItem
    {
        public virtual string AnswerDescription { get; set; }
        [NonPersistent]
        public virtual int QuestionIndex
        {
            get
            {
                int index = 1;
                foreach (ExamPage page in Group.ExamPage.ExamForm.Pages)
                {
                    foreach (ExamPageGroup pageGroup in page.Groups)
                    {
                        foreach (ExamPageItem item in pageGroup.Items)
                        {
                            if (item is ExamTestQuestion || item is ExamEssayQuestion)
                                if (item.Id == Id)
                                    return index;
                                else
                                    index++;
                        }
                    }
                }
                return index;
            }
        }

        public override string DrawHtml()
        {
            return Text;
        }

        public override ExamPageItem Clone()
        {
            ExamEssayQuestion newItem = Services.Clone(this);
            return newItem;
        }
    }
}