using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using DataAccessLayer;
using Fakher.Core.DomainModel.Poll;
using Fakher.Core.Website;
    
using rApplicationEventFramework;
using rComponents;
using NHibernate.Criterion;
using System.Threading.Tasks;

namespace Fakher.Core.DomainModel
{
    public abstract class Person : DbObject, IMessageReceiver
    {
        public Person()
        {
            ContactInfo = new ContactInfo();
            UserInfo = new UserInfo();
            IsIncomplete = false;
            Gender = Gender.Male;
            MarriageStatus = MarriageStatus.Single;
            LastEducationalDegree = EducationalDegree.Diploma;
            Uses = new List<Use>();
            FinancialDocuments = new List<FinancialDocument>();
            AllowedDepartments = new List<Department>();
            Absences = new List<Absence>();
            Delays = new List<Delay>();
            Presences = new List<Presence>();
            Photo = new Photo();
            Orders = new List<Order.Order>();
        }

        [EventClassProperty("شماره پرونده", null)]
        public virtual string Code { get; set; }
        public virtual bool InternetRegisteration { get; set; }
        [EventClassProperty("نام فارسی", null)]
        public virtual string FarsiFirstName { get; set; }
        [EventClassProperty("نام خانوادگی فارسی", null)]
        public virtual string FarsiLastName { get; set; }
        [EventClassProperty("نام پدر فارسی", null)]
        public virtual string FarsiFatherName { get; set; }
        [EventClassProperty("نام انگلیسی", null)]
        public virtual string EnglishFirstName { get; set; }
        [EventClassProperty("نام خانوادگی انگلیسی", null)]
        public virtual string EnglishLastName { get; set; }
        [EventClassProperty("نام پدر انگلیسی", null)]
        public virtual string EnglishFatherName { get; set; }
        public virtual PersianDate BirthDate { get; set; }
        public virtual string BirthPlace { get; set; }
        public virtual string IdNumber { get; set; }
        public virtual IntroduceMethod IntroduceMethod { get; set; }
        public virtual string NationalCode { get; set; }
        public virtual string Job { get; set; }
        public virtual string SpecialDisease { get; set; }
        public virtual MarriageStatus MarriageStatus { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual EducationalDegree LastEducationalDegree { get; set; }
        public virtual bool IsIncomplete { get; set; }
        public virtual string IncompleteNotes { get; set; }
        public virtual Photo Photo { get; set; }
        [MaximumLength]
        public virtual string Notes { get; set; }
        public virtual IList<Notes> NoteList { get; set; }

        public virtual string ArchivePlace { get; set; }
        public virtual string BankCartNo { get; set; }
        public virtual string BankShabaNo { get; set; }
        public virtual FinancialDocument DefaultDocument { get; set; }
        public virtual long FinancialBalance { get; set; }
        [Attendant]
        public virtual ContactInfo ContactInfo { get; set; }
        [Attendant]
        public virtual UserInfo UserInfo { get; set; }
        public virtual IList<Use> Uses { get; set; }
        public virtual IList<FinancialDocument> FinancialDocuments { get; set; }
        [Attendant]
        public virtual IList<Department> AllowedDepartments { get; set; }
        public virtual IList<Absence> Absences { get; set; }
        public virtual IList<Delay> Delays { get; set; }
        public virtual IList<Presence> Presences { get; set; }
        public virtual IList<Order.Order> Orders { get; set; }
        
        [NonPersistent]
        public virtual string FarsiFullname
        {
            get { return FarsiFirstName + " " + FarsiLastName; }
        }

        [NonPersistent]
        public virtual string Title
        {
            get
            {
                if (Gender == Gender.Male)
                    return "آقای";
                return "خانم";
            }
        }

        [NonPersistent]
        public virtual string FarsiFormalName
        {
            get { return Title + " " + FarsiLastName; }
        }

        [NonPersistent]
        public virtual string EnglishFullname
        {
            get { return EnglishFirstName + " " + EnglishLastName; }
        }

        [NonPersistent]
        public virtual string GenderAndMarriageText
        {
            get { return Gender.ToDescription() + "/" + MarriageStatus.ToDescription(); }
        }

        [NonPersistent]
        public virtual string LastEducationalDegreeText
        {
            get { return LastEducationalDegree.ToDescription(); }
        }

        [NonPersistent]
        public virtual FinancialStatus FinancialStatus
        {
            get
            {
                if (IsDebtor())
                    return FinancialStatus.Debtor;
                if (IsChequePromisor())
                    return FinancialStatus.ChequePromised;
                if (FinancialBalance > 0)
                    return FinancialStatus.Creditor;
                return FinancialStatus.Balanced;
            }
        }

        [NonPersistent]
        public virtual string FinancialStatusFarsiText
        {
            get
            {
                return FinancialStatus.ToDescription();
            }
        }        
        
        [NonPersistent]
        public virtual string FinancialStatusEnglishText
        {
            get
            {
                return FinancialStatus + "";
            }
        }

        [NonPersistent]
        public virtual string FinancialStatusVerboseText
        {
            get
            {
                if (FinancialStatus != FinancialStatus.Balanced && FinancialStatus != FinancialStatus.ChequePromised)
                    return FinancialStatus.ToDescription() + " (" + Math.Abs(GetDebtAmount()).ToString("C0") + " )";
                return FinancialStatus.ToDescription();
            }
        }

        [NonPersistent]
        public virtual string MessageAddress
        {
            get { return "[" + FarsiFirstName.Trim() + "." + FarsiLastName.Trim() + "]"; }
        }

        public virtual IQueryable<FinancialDocument> GetDebtorDocuments()
        {
            var query = from document in FinancialDocuments
                        where document.FinancialStatus == FinancialStatus.Debtor
                        select document;
            return query.AsQueryable();
        }

        public virtual bool IsDebtor()
        {
            return GetDebtorDocuments().Count() > 0;
        }

        public virtual long GetDebtAmount()
        {
            return GetDebtorDocuments().Sum(x => x.DebtBalance);
        }

        public virtual bool IsChequePromisor()
        {
            var query = from document in FinancialDocuments
                    where document.FinancialStatus == FinancialStatus.ChequePromised
                    select document;
            return query.Count() > 0;

//            var query = from Cheque c in DbContext.Entity<Cheque>()
//                        where c.Item.Document.Person.Id == Id && c.Status != ChequeStatus.Passed
//                        select c;
//            return query.Count() > 0;
        }

        //        [Obsolete]
        //        public virtual void RegisterDocument(FinancialDocument document)
        //        {
        //            if (!FinancialDocuments.Contains(document))
        //            {
        //                FinancialDocuments.Add(document);
        //                FinancialBalance += document.Balance;
        //                Save();
        //            }
        //        }
        public virtual IQueryable<FinancialItem> GetAlalHesabFinancialItems()
        {
            var query = from item in DbContext.GetAll<FinancialItem>()
                        where item.Person.Id == Id && item.Heading==FinancialHeading.AlalHesab
                        select item;
                        
            return query.AsQueryable();
       
        }
        public virtual IQueryable<FinancialItem> GetAllFinancialItems()
        {
            var query = from document in FinancialDocuments
                        from item in document.Items
                        where item.Person.Id==Id////این خط را خودم اضافه کردم
                        select item;
            return query.AsQueryable();
//            List<FinancialItem> items = new List<FinancialItem>();
//            foreach (FinancialDocument document in FinancialDocuments)
//                document.Items.CopyTo(items);
//            return items;
        }

        #region Static Members

        public static Person GetPerson(int id)
        {
            return DbContext.FromId<Person>(id);
        }

        /// <summary>
        /// From Encrypted Username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static Person FromUsername(string encryptedUsername, LoginStatus status, bool filterOnCanLogin)
        {
            var query = from p in DbContext.Entity<Person>()
                        select p;
            IQueryable<Person> query2 = query.Where(p => p.UserInfo.LoginStatus == status
                                                         && p.UserInfo.Username == encryptedUsername);

            Person person = query2.FirstOrDefault();
            if (filterOnCanLogin)
                if (person != null && !person.UserInfo.CanLogin)
                    return null;
            return person;
        }

//        public static Person FromLogin(string username)
//        {
//            var query = from p in DbContext.Entity<Person>()
//                        where p.UserInfo.AllowedToLogin
//                        select p;
//            IQueryable<Person> query2 = query.Where(p => p.UserInfo.Username == username);
//            return query2.First();
//        }

        public static Person FromLogin(string username, string password)
        {
//            var query = from Person p in DbContext.Entity<Person>()
//                        where p.UserInfo.AllowedToLogin 
//                        select p;
            IQueryable<Person> query = DbContext.Entity<Person>().Where(p => p.UserInfo.Username == username && p.UserInfo.Password == password);
            var query2 = from person in query.ToList()
                         where person.UserInfo.LoginStatus == LoginStatus.Enabled
                         select person;
            return query2.FirstOrDefault();
        }

        public static string GetNextCode<T>() where T : Person
        {
            string year = PersianDate.Today.Year.ToString().Substring(2);

            var query1 = from obj in DbContext.Entity<T>()
                        where obj.Code.StartsWith(year) 
                        orderby obj.Code descending
                        select obj.Code;
            List<string> codes = query1.ToList();

            var query2 = from code in codes
                         orderby code.Length descending, code descending
                         select code;

            int count = query2.Count();
            int number = 1001;
            if (count > 0)
            {
                string lastCode = query2.First();
                number = int.Parse(lastCode.Substring(2)) + 1;
            }

            return year + (number + "");
        }

        public static Person FromName(string firstName, string lastName, string fatherName)
        {
            var query = from person in DbContext.Entity<Person>()
                        where person.FarsiFirstName == firstName 
                            && person.FarsiLastName == lastName 
                            && person.FarsiFatherName == fatherName
                        select person;
            return query.FirstOrDefault();
        }

        public static Person FromName(string firstName, string lastName)
        {
            var query = from person in DbContext.Entity<Person>()
                        where person.FarsiFirstName == firstName && person.FarsiLastName == lastName
                        select person;
            return query.FirstOrDefault();
        }

        public static Person FromInfo(string firstName, string lastName, string fatherName, string birthDate)
        {
            var query = from person in DbContext.Entity<Person>()
                        where person.FarsiFirstName == firstName && person.FarsiLastName == lastName &&
                              person.FarsiFatherName == fatherName
                        select person;
            var query2 = from person in query.ToList()
                         where person.BirthDate.ToShortDateString() == birthDate
                         select person;
            return query2.FirstOrDefault();
        }

        public static string FindEnglishName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return "";

            var query = from person in DbContext.Entity<Person>()
                        where person.FarsiFirstName == name
                        orderby person.Id descending 
                        select person.EnglishFirstName;
            string result = query.FirstOrDefault();
            if(result != null)
                return Services.NormalizeEnglishString(result);

            query = from person in DbContext.Entity<Person>()
                    where person.FarsiFatherName == name
                    orderby person.Id descending
                    select person.EnglishFatherName;
            result = query.FirstOrDefault();
            if (result != null)
                return Services.NormalizeEnglishString(result);

            query = from person in DbContext.Entity<Person>()
                    where person.FarsiLastName == name
                    orderby person.Id descending
                    select person.EnglishLastName;
            result = query.FirstOrDefault();
            if (result != null)
                return Services.NormalizeEnglishString(result);

            return "";
        }

        public static IList<Person> Search(string firstName, string lastName)
        {
            List<Person> result = new List<Person>();

            var query = from person in DbContext.Entity<Person>()
                        where person.FarsiFirstName == firstName
                        && person.FarsiLastName == lastName
                        select person;
            result.UniqueAddRange(query.ToList());

            query = from person in DbContext.Entity<Person>()
                    where person.FarsiFirstName.StartsWith(firstName)
                    && person.FarsiLastName.StartsWith(lastName)
                    select person;
            result.UniqueAddRange(query.ToList());

            query = from person in DbContext.Entity<Person>()
                    where person.FarsiFirstName.Contains(firstName)
                    && person.FarsiLastName.Contains(lastName)
                    select person;
            result.UniqueAddRange(query.ToList());

            return result;
        }

        #endregion

        public virtual bool CanUse(GroupTool groupTool, UseType type)
        {
            groupTool.EducationalTool.RefreshEntity();

            if (groupTool.EducationalTool.Disabled)
                throw new MessageException("این درس افزار غیر فعال است و امکان فروش/امانت ندارد.");

            if (groupTool.EducationalTool.Remainder <= 0)
                throw new MessageException("موجودی این درس افزار به پایان رسیده است.");

            var query = from use in Uses
                        where use.EducationalTool.Id == groupTool.EducationalTool.Id && use.Type == type
                        select use;
            if (query.Count() >= groupTool.AllowedToUseCount)
                return false;
            return true;
        }

        public virtual bool CanUse(EducationalTool tool, UseType type, int allowedToUseCount)
        {
            tool.RefreshEntity();

            if (tool.Disabled)
                throw new MessageException("این درس افزار غیر فعال است و امکان فروش/امانت ندارد.");

            if (tool.Remainder <= 0)
                throw new MessageException("موجودی این کتاب به پایان رسیده است.");

            var query = from use in Uses
                        where use.EducationalTool.Id == tool.Id && use.Type == type
                        select use;
            if (query.Count() >= allowedToUseCount)
                return false;
            return true;
        }

        public virtual IList<EducationalTool> GetUsedTools(UseType type)
        {
            var query = from use in Uses
                        where use.Type == type
                        select use.EducationalTool;
            return query.ToList();
        }

        public virtual Use SubmitUseAndSave(Use use)
        {
            EducationalTool tool = use.EducationalTool;
            use.UseProfit = tool.Decrease(1);
            tool.Save();

            if(!Uses.Contains(use))
                Uses.Add(use);

            Save();
            return use;
        }

        public virtual Use SubmitReturnAndSave(Use use)
        {
            EducationalTool tool = use.EducationalTool;
            tool.Increase(1);
            tool.Save();

            use.ReturnDate = PersianDate.Today;

            Save();
            return use;
        }

        public virtual List<Message> GetReceivedMessages()
        {
            var query = from receiver in DbContext.Entity<MessageReceiver>()
                        where receiver.Person.Id == Id
                        orderby receiver.Message.SendDate descending, receiver.Message.SendTime descending 
                        select receiver.Message;
            return  query.ToList();
        }

        public virtual IQueryable<Message> GetReceivedMessages(MessageStatus status)
        {
            var query = from message in  GetReceivedMessages()
                        from receiver in message.Receivers
                        where receiver.Person.Id == Id
                        && receiver.Status == status
                        select receiver.Message;
            return query.AsQueryable();
        }

        public virtual IList<Message> GetSentMessages()
        {
            var query = from message in DbContext.Entity<Message>()
                        where message.Sender.Id == Id
                        orderby message.SendDate descending, message.SendTime descending 
                        select message;
            return query.ToList();
        }

        public virtual IQueryable<Absence> GetAbsences(SectionItem item)
        {
            var query = from absence in Absences
                        where absence.SectionItem.Id == item.Id
                        select absence;
            return query.AsQueryable();
        }
        public virtual IQueryable<Delay> GetDelays(SectionItem item)
        {
            var query = from delay in Delays
                        where delay.SectionItem.Id == item.Id
                        select delay;
            return query.AsQueryable();
        }
        public virtual IQueryable<Presence> GetPresences(SectionItem item)
        {
            var query = from presence in Presences
                        where presence.SectionItem.Id == item.Id
                        select presence;
            return query.AsQueryable();
        }
        public virtual IQueryable<Notes> GetNotesByType(NotesType type)
        {
            var query1 = from notes in DbContext.Entity<Notes>()
                         where notes.NotesType == type
                         select notes;

            return query1.AsQueryable();
        }

        public virtual IQueryable<Presence> GetPresences(PersianDate startDate, PersianDate endDate)
        {
            var query = from presence in Presences
                        where presence.Date >= startDate
                        && presence.Date <= endDate
                        select presence;
            return query.AsQueryable();
        }

        public override string ToString()
        {
            return FarsiFullname;
        }

        public virtual IEnumerable<Use> GetUses(UseType type)
        {
            return Uses.Where(x => x.Type == type);
        }

        public virtual IQueryable<EntityEvent> GetRegisteredEntityEventsQuery<T>(EntityEventAction action) where T : DbObject
        {
            var query = from entityEvent in DbContext.Entity<EntityEvent>()
                        where entityEvent.Registrar.Id == Id
                              && entityEvent.EntityTypeText == typeof (T).FullName
                              && entityEvent.Action == action
                        select entityEvent;

            return query;
        }
        public virtual IQueryable<FinancialItem> GetRegisteredFinancialItemsQuery<T>(IQueryable<EntityEvent> entityEventsQuery) where T : DbObject
        {
            var query = from obj in entityEventsQuery
                        join entity in DbContext.Entity<FinancialItem>() on obj.EntityId equals entity.Id
                        select new FinancialItem()
                        {
                            CreateDate = obj.Date,
                            Amount = entity.Amount,
                            BankAccount = entity.BankAccount,

                            Date = entity.Date,

                            Document = entity.Document,
                            Heading = entity.Heading,
                            Id = entity.Id,
                            IsClone = entity.IsClone,
                            IsDeleted = entity.IsDeleted,
                            Mode = entity.Mode,
                            Payment = entity.Payment,
                            Person = entity.Person,
                            Text = entity.Text,
                            Type = entity.Type

                        };
            return query;
        }
        public virtual IQueryable<T> GetRegisteredEntitiesQuery<T>(IQueryable<EntityEvent> entityEventsQuery) where T : DbObject
        {
//            IList<int> ids = entityEvents.Select(x => x.EntityId).ToList();
//            var query = from obj in DbContext.Entity<T>()
//                    where ids.Contains(obj.Id)
//                    select obj;
//            return query;

//            var query1 = from entityEvent in DbContext.Entity<EntityEvent>()
//                        where entityEvent.Registrar.Id == Id
//                              && entityEvent.EntityTypeText == typeof(T).FullName
//                              && entityEvent.Action == EntityEventAction.InsertObject
//                        select entityEvent;

                var query = from obj in entityEventsQuery
                            join entity in DbContext.Entity<T>() on obj.EntityId equals entity.Id
                            select entity;
                return query;

          
//            IEnumerable<T> q = entityEventsQuery.Join(DbContext.Entity<T>(), x => x.EntityId, x => x.Id,
//                                                      (entityEvent, entity) => entity);
//            return q;


//            var query = from obj in DbContext.Entity<T>()
//                        join entityEvent in entityEvents on obj.Id equals entityEvent.EntityId
//                        select obj;
//
//            return query;
        }

//        public virtual IList<T> GetRegisteredEntities<T>(EntityEventAction action) where T : DbObject
//        {
//            var query = GetRegisteredEntitiesQuery<T>(action);
//            List<T> list = query.ToList();
//            return list;
//        }

        public virtual void EnsureDefaultDocumentActivation()
        {
            if (DefaultDocument == null)
                DefaultDocument = new FinancialDocument { Description = string.Format("سند مالی پیش فرض [{0}]", FarsiFullname), Person = this};
        }

        public virtual bool IsParticipate(Poll.Poll poll)
        {
            var query = from participate in DbContext.Entity<PollParticipate>()
                        where participate.Person != null
                              && participate.PollItem != null
                              && participate.Person.Id == Id
                              && participate.PollItem.Poll.Id == poll.Id
                        select participate;
            return query.Any();
        }

        public virtual PollParticipate CreatePollParticipate(PollItem pollItem)
        {
            PollParticipate participate = new PollParticipate
            {
                Person = this,
                PollItem = pollItem
            };
            return participate;
        }
    }

    public enum Gender
    {
        [EnumDescription("مـذکـر")]
        Male = 0,
        [EnumDescription("مـونـث")]
        Female = 1
    }

    public enum MarriageStatus
    {
        [EnumDescription("مجرد")]
        Single,
        [EnumDescription("متاهل")]
        Married
    }

    public enum EducationalDegree
    {
        [EnumDescription("زیر دیپلم")]
        UnderDiploma,
        [EnumDescription("دیپلم")]
        Diploma,
        [EnumDescription("پیش دانشگاهی")]
        PreUniversity,
        [EnumDescription("کاردانی")]
        Associate,
        [EnumDescription("کارشناسی")]
        Bachelor,
        [EnumDescription("کارشناسی ارشد")]
        Master,
        [EnumDescription("دکترا")]
        Phd,
    }

    public enum IntroduceMethod
    {
        [EnumDescription("دوستان")]
        Friends,
        [EnumDescription("روزنامه")]
        Newspaper,
        [EnumDescription("تراکت")]
        Paper,
        [EnumDescription("پیامک")]
        Sms,
        [EnumDescription("تلویزیون")]
        Tv,
        [EnumDescription("سایر موارد")]
        Other
    }

}