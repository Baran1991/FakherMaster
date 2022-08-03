using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Message : DbObject
    {
        public Message()
        {
            Receivers = new List<MessageReceiver>();
            SendDate = PersianDate.Today;
            SendTime = Time.Now.ToShortTimeString();
            Attachments = new List<WebMedia>();
        }

        public virtual PersianDate SendDate { get; set; }
        public virtual string SendTime { get; set; }
        [MaximumLength]
        public virtual string Subject { get; set; }
        [MaximumLength]
        public virtual string Body { get; set; }
        [NoCascade]
        public virtual Person Sender { get; set; }
        [NoCascade]
        public virtual Message Parent { get; set; }
        [Attendant]
        public virtual IList<MessageReceiver> Receivers { get; set; }
        [Attendant]
        public virtual IList<WebMedia> Attachments { get; set; }

        [NonPersistent]
        public virtual string ReceiverText
        {
            get 
            { 
                string txt = "";
                foreach (MessageReceiver receiver in Receivers)
                {
                    txt += receiver.Person.MessageAddress;
                    if (Receivers.IndexOf(receiver) != Receivers.Count - 1)
                        txt += " ";
                }
                return txt;
            }
        }

        [NonPersistent]
        public virtual string SendDateTime
        {
            get { return SendTime + " - " + SendDate.ToShortDateString(); }
        }

        [NonPersistent]
        public virtual int[] ReceiverIds
        {
            get { return Receivers.Select(x => x.Person.Id).ToArray(); }
        }

        [NonPersistent]
        public virtual bool HasAttachment
        {
            get { return Attachments.Count > 0; }
        }

        [NonPersistent]
        public virtual string GridSubject
        {
            get
            {
                if (HasAttachment)
                    return Subject + " [پیوست دارد]";
                return Subject;
            }
        }

        public virtual void AddReceiver(Person person)
        {
            MessageReceiver receiver = new MessageReceiver {Message = this, Person = person};
            Receivers.Add(receiver);
        }

        public virtual void AddReceiver(Department department)
        {
            foreach (ResponsiblePerson person in department.ResponsiblePersons)
                if(person.ReceiveEmails)
                    AddReceiver(person.Person);
        }

        public virtual Message CreateReply()
        {
            Message message = new Message();
            message.Parent = this;
            message.Subject = "پاسخ: " + Subject;
            message.Body = Sender.FarsiFullname + " نوشته: " + "\r\n" + Body;

            foreach (WebMedia attachment in Attachments)
            {
                message.Attachments.Add(attachment.Clone());
            }

            return message;
        }

        public  virtual IQueryable<MessageReceiver> GetReceiver(Person person)
        {
            var query = from receiver in Receivers
                        where receiver.Person.Id == person.Id
                        select receiver;
            return query.AsQueryable();
        }

        public virtual IList<Message> GetRepliedMessaged()
        {
            var query = from message in DbContext.Entity<Message>()
                        where message.Parent.Id == Id
                        select message;
            return query.ToList();
        }

        public virtual IQueryable<Message> GetThreadMessages()
        {
            List<Message> messages = new List<Message>();
            Message parent = Parent;
            while (parent != null)
            {
                messages.Add(parent);
                parent = parent.Parent;
            }

            messages.Add(this);
            IList<Message> repliedMessages = GetRepliedMessaged();
            foreach (Message repliedMessage in repliedMessages)
                messages.Add(repliedMessage);

            var query = from message in messages
                        orderby message.SendDateTime descending
                        select message;
            return query.AsQueryable();
        }

//        public virtual IQueryable<WebMedia> GetAttachments()
//        {
//            var query = from media in DbContext.Entity<WebMedia>()
//                        where media.Message != null
//                              && media.Message.Id == this.Id
//                        select media;
//            return query;
//        }

        public static Message FromId(int id)
        {
            return DbContext.FromId<Message>(id);
        }

        public virtual string GetReceiverText(Person person)
        {
            IEnumerable<MessageReceiver> personReceivers = Receivers.Where(x => x.Person.Id == person.Id);
            if (personReceivers.Any())
            {
                int count = Receivers.Except(personReceivers).Distinct().Count();
                if(count == 0)
                    return person.MessageAddress;
                return person.MessageAddress + " و " + count + " نفر دیگر";
            }

            return "نامشخص";
        }
    }
}