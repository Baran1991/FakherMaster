using DataAccessLayer;

namespace Fakher.Core.DomainModel.Poll
{
    public class PollItem : DbObject
    {
        public virtual string Text { get; set; }
        public virtual int Hits_1 { get; set; }
        public virtual int Hits_2 { get; set; }
        public virtual int Hits_3 { get; set; }
        public virtual int Hits_4 { get; set; }
        [NoCascade]
        public virtual Poll Poll { get; set; }

        public static PollItem FromId(int id)
        {
            return DbContext.FromId<PollItem>(id);
        }

        public virtual void IncrementHits_1()
        {
            Hits_1++;
        }
        public virtual void IncrementHits_2()
        {
            Hits_2++;
        }
        public virtual void IncrementHits_3()
        {
            Hits_3++;
        }
        public virtual void IncrementHits_4()
        {
            Hits_4++;
        }
    }
}