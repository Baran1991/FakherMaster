using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ExamPage : DbObject
    {
        public virtual string Name { get; set; }
        public virtual IList<ExamPageGroup> Groups { get; set; }
        [NoCascade]
        public virtual ExamForm ExamForm { get; set; }

        public ExamPage()
        {
            Groups = new List<ExamPageGroup>(); 
        }

        [NonPersistent]
        public virtual int QuestionCount
        {
            get
            {
                int count = 0;
                foreach (ExamPageGroup pageGroup in Groups)
                {
                    foreach (ExamPageItem item in pageGroup.Items)
                    {
                        if (item is ExamTestQuestion)
                            count++;
                    }
                }
                return count;
            }
        }

        [NonPersistent]
        public virtual List<ExamItem> ExamItems
        {
            get
            {
                var query = from ExamPageGroup @group in Groups
                            group @group by @group.ExamItem
                            into g
                            select g.Key;
                return query.ToList();
            }
        }

        [NonPersistent]
        public virtual string ExamItemsText
        {
            get
            {
                string txt = "";
                foreach (ExamItem examItem in ExamItems)
                {
                    if(examItem == null)
                        continue;
                    txt += examItem.Name;
                    if(ExamItems.IndexOf(examItem) != ExamItems.Count - 1)
                        txt += " - ";
                }
                return txt;
            }
        }

        public static ExamPage FromId(int id)
        {
            return DbContext.FromId<ExamPage>(id);
        }

        private ExamItem FindExamItem(string examItemName)
        {
            foreach (ExamItem item in ExamForm.Exam.Items)
                if (item.Name == examItemName)
                    return item;
            return null;
        }

        public virtual ExamPage Clone()
        {
            ExamPage newPage = Services.Clone(this);
            foreach (ExamPageGroup pageGroup in Groups)
            {
                ExamPageGroup newGroup = pageGroup.Clone();
                newGroup.ExamItem = FindExamItem(newGroup.CloneExamItem.Name);
                newGroup.ExamPage = newPage;
                newPage.Groups.Add(newGroup);
            }
            return newPage;
        }
    }
}