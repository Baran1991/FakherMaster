using System;
using System.Collections.Generic;
using DataAccessLayer;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ExamPageItem : DbObject
    {
        [MaximumLength]
        public virtual string Text { get; set; }
        [NoCascade]
        public virtual ExamPageGroup Group { get; set; }
        public virtual bool IsRightToLeft { get; set; }
        public virtual int Position { get; set; }
        public virtual bool CanViewAnswerDescription { get; set; }
        public virtual WebMedia Attachment { get; set; }
        public virtual int DisplayNo { get; set; }
        public virtual string DrawHtml()
        {
            throw new NotImplementedException();
        }

        public virtual ExamPageItem Clone()
        {
            ExamPageItem newItem = Services.Clone(this);
            return newItem;
        }
    }
}