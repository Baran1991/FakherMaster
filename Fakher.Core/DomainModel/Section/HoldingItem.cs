using System;
using DataAccessLayer;
using DevExpress.Xpo;

namespace Fakher.Core.DomainModel
{
    public class HoldingItem : XPObject
    {
        public HoldingItem(Session session) : base(session)
        {
            Coefficient = 1;
        }

        public HoldingItem()
        {
            Coefficient = 1;
        }

        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int Coefficient { get; set; }
        public int TuitionFee { get; set; }
        [Association]
        public Lesson Lesson { get; set; }
        [Association]
        public Holding Holding { get; set; }

        public bool HasIntersect(HoldingItem item)
        {
            if(StartIndex >= item.StartIndex && StartIndex <= item.EndIndex)
                return true;
            if(EndIndex <= item.EndIndex && EndIndex >= item.StartIndex)
                return true;
            return false;
        }
    }
}