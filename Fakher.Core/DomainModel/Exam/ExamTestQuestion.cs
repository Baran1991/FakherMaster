using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ExamTestQuestion : ExamPageItem
    {
        public virtual byte CorrectAnswer { get; set; } = 1;
        [MaximumLength]
        public virtual string Choice1 { get; set; }
        public virtual bool Choice1RightToLeft { get; set; }
       
        [MaximumLength]
        public virtual string Choice1Desc { get; set; }
        [MaximumLength]
        public virtual string Choice2 { get; set; }
        public virtual bool Choice2RightToLeft { get; set; }
        [MaximumLength]
        public virtual string Choice2Desc { get; set; }
        [MaximumLength]
        public virtual string Choice3 { get; set; }
        public virtual bool Choice3RightToLeft { get; set; }
        [MaximumLength]
        public virtual string Choice3Desc { get; set; }
        [MaximumLength]
        public virtual string Choice4 { get; set; }
        public virtual bool Choice4RightToLeft { get; set; }
        [MaximumLength]
        public virtual string Choice4Desc { get; set; }
        
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
                                if(item.Id == Id)
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
            string html = "";
            if(IsRightToLeft)
                html += "<table style=\"width: 100%; direction: rtl; text-align:right \">";
            else
                html += "<table style=\"width: 100%; direction: ltr; text-align:left \">";
            html += "<tr>";
            html += "<td colspan=\"4\">";
            html += Text;
            html += "</td>";
            html += "</tr>";
            html += "<tr>";
            html += "<td>";
            html += "1) ";
            html += "</td>";
            html += "<td>";
            html += Choice1;
            html += "</td>";
            html += "<td>";
            html += "2) ";
            html += "</td>";
            html += "<td>";
            html += Choice2;
            html += "</td>";
            html += "</tr>";
            html += "<tr>";
            html += "<td>";
            html += "3) ";
            html += "</td>";
            html += "<td>";
            html += Choice3;
            html += "</td>";
            html += "<td>";
            html += "4) ";
            html += "</td>";
            html += "<td>";
            html += Choice4;
            html += "</td>";
            html += "</tr>";
            html += "</table>";

            return html;
        }

        public override ExamPageItem Clone()
        {
            ExamTestQuestion newItem = Services.Clone(this);
            return newItem;
        }
    }
}