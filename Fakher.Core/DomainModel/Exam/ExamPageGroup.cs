using System.Collections.Generic;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ExamPageGroup : DbObject
    {
        public ExamPageGroup()
        {
            Items = new List<ExamPageItem>();
        }

        [MaximumLength]
        public virtual string Text { get; set; }
        [NoCascade]
        public virtual ExamItem ExamItem { get; set; }
        [NoCascade]
        public virtual ExamPage ExamPage { get; set; }
        public virtual int Position { get; set; }
        public virtual IList<ExamPageItem> Items { get; set; }

        [NonPersistent]
        public virtual ExamItem CloneExamItem { get; set; }

        public virtual ExamPageGroup Clone()
        {
            ExamPageGroup newGroup = Services.Clone(this);
            newGroup.CloneExamItem = ExamItem;
            foreach (ExamPageItem item in Items)
            {
                ExamPageItem newItem = item.Clone();
                newItem.Group = newGroup;
                newGroup.Items.Add(newItem);
            }
            return newGroup;
        }
    }
}