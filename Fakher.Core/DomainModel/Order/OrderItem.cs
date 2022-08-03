using DataAccessLayer;

namespace Fakher.Core.DomainModel.Order
{
    public class OrderItem : DbObject
    {
        [NoCascade]
        public virtual EducationalTool EducationalTool { get; set; }
        [NoCascade]
        public virtual Order Order { get; set; }
        public virtual int Count { get; set; }

        public OrderItem()
        {
            Count = 1;
        }

        [NonPersistent]
        public virtual string Text
        {
            get { return EducationalTool.Name; }
        }

        [NonPersistent]
        public virtual long Price
        {
            get { return EducationalTool.LastSellPrice; }
        }

        public static OrderItem FromId(int id)
        {
            return DbContext.FromId<OrderItem>(id);
        }
    }
}