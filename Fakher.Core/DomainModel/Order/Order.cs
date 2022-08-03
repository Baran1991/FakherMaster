using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel.Order
{
    public class Order : DbObject
    {
        public virtual long Code { get; set; }
        public virtual PersianDate Date { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        public virtual int Second { get; set; }
        public virtual PersianDate PayDate { get; set; }
        public virtual int PayHour { get; set; }
        public virtual int PayMinute { get; set; }
        public virtual int PaySecond { get; set; }
        public virtual PersianDate CompleteDate { get; set; }
        public virtual int CompleteHour { get; set; }
        public virtual int CompleteMinute { get; set; }
        public virtual int CompleteSecond { get; set; }
        public virtual PersianDate SendDate { get; set; }
        public virtual int SendHour { get; set; }
        public virtual int SendMinute { get; set; }
        public virtual int SendSecond { get; set; }
        [NoCascade]
        public virtual Person Person { get; set; }
        [NoCascade]
        public virtual FinancialDocument FinancialDocument { get; set; }
        [NoCascade]
        public virtual PayTransaction PayTransaction { get; set; }
        public virtual OrderStatus Status { get; set; }
        public virtual IList<OrderItem> Items { get; set; }

        public Order()
        {
            Date = PersianDate.Today;
            Hour = Time.Now.Hour;
            Minute = Time.Now.Minute;
            Second = Time.Now.Second;
            Status = OrderStatus.Pending;
            Items = new List<OrderItem>();
        }

        [NonPersistent]
        public virtual long Price
        {
            get
            {
                if (Items.Count > 0)
                    return Items.Sum(x => x.Price);
                return 0;
            }
        }

        [NonPersistent]
        public virtual long PayableAmount
        {
            get { return Price; }
        }

        [NonPersistent]
        public virtual string StatusText
        {
            get { return Status.ToDescription(); }
        }

        [NonPersistent]
        public virtual string PayTransactionText
        {
            get
            {
                if (PayTransaction != null)
                    return PayTransaction.StatusText;
                return "پرداخت نشده";
            }
        }

        [NonPersistent]
        public virtual string FinancialStatusText
        {
            get
            {
                if (FinancialDocument != null)
                    return FinancialDocument.FarsiFinancialStatusVerboseText;
                return "پرداخت نشده";
            }
        }

        [NonPersistent]
        public virtual string DateTimeText
        {
            get { return Date + " " + Hour + ":" + Minute + ":" + Second; }
        }

        public virtual void Pay()
        {
            PayDate = PersianDate.Today;
            PayHour = Time.Now.Hour;
            PayMinute = Time.Now.Minute;
            PaySecond = Time.Now.Second;
            Status = OrderStatus.Payed;
        }

        public virtual void Complete()
        {
            if(Status != OrderStatus.Payed)
            {
                throw new MessageException("ثبت سفارش امکانپذیر نیست.");
            }

            int batchNumber = Use.GetNextBatchNumber();
            foreach (OrderItem item in Items)
            {
                Use use = item.EducationalTool.CreateUse(Person, UseType.Buy, false);

                foreach (FinancialItem paymentItem in FinancialDocument.PaymentItems)
                {
                    FinancialItem clone = paymentItem.Clone();
                    clone.Heading = FinancialHeading.ToolSell;
                    use.FinancialDocument.Items.Add(clone);
                }
                
                use.BatchNumber = batchNumber;
                Person.SubmitUseAndSave(use);
            }

            CompleteDate = PersianDate.Today;
            CompleteHour = Time.Now.Hour;
            CompleteMinute = Time.Now.Minute;
            CompleteSecond = Time.Now.Second;
            Status = OrderStatus.Completed;
        }

        public virtual void Sent()
        {
            SendDate = PersianDate.Today;
            SendHour = Time.Now.Hour;
            SendMinute = Time.Now.Minute;
            SendSecond = Time.Now.Second;
            Status = OrderStatus.Sent;
        }

        public virtual void GenerateCode()
        {
            DateTime now = DateTime.Now;
            long preNum = now.Ticks % 10000;
            string prefix = preNum.ToString();
            while (prefix.Length < 4)
            {
                int random = new Random().Next(1, 9);
                prefix = random + prefix;
            }

            string number = prefix.Substring(0, 2) + Id + prefix.Substring(2, 2);
            Code = Convert.ToInt64(number);
        }

        public virtual void AddItem(EducationalTool tool)
        {
            OrderItem item = new OrderItem {EducationalTool = tool, Order = this};
            Items.Add(item);
        }

        public static IQueryable<Order> GetOrdersQuery()
        {
            var query = from order in DbContext.Entity<Order>()
                        orderby order.Id descending 
                        select order;
            return query;
        }
    }

    public enum OrderStatus
    {
        [EnumDescription("در انتظار پرداخت")]
        Pending,
        [EnumDescription("پرداخت شده")]
        Payed,
        [EnumDescription("ثبت شده")]
        Completed,
        [EnumDescription("ارسال شده")]
        Sent,
    }
}