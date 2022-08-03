using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel.Consult
{
    public class Consultation : DbObject
    {
        public virtual long Code { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        [MaximumLength]
        public virtual string Title { get; set; }
        [MaximumLength]
        public virtual string Question { get; set; }
        [MaximumLength]
        public virtual string Answer { get; set; }
        public virtual ConsultationViewPolicy ViewPolicy { get; set; }
        public virtual ConsultationCategory Category { get; set; }
        public virtual PersianDate SubmitDate { get; set; }
        public virtual int SubmitHour { get; set; }
        public virtual int SubmitMinute { get; set; }
        public virtual int SubmitSecond { get; set; }
        public virtual string SubmitIP { get; set; }
        [MaximumLength]
        public virtual string SubmitUserAgent { get; set; }
        public virtual PersianDate AnswerDate { get; set; }
        public virtual int AnswerHour { get; set; }
        public virtual int AnswerMinute { get; set; }
        public virtual int AnswerSecond { get; set; }
        [NoCascade]
        public virtual Student Student { get; set; }
        public virtual string ConsultantText { get; set; }
        [NoCascade]
        public virtual Person ConsultantPerson { get; set; }
        public virtual int Hits { get; set; }
        public virtual bool InternetRegisteration { get; set; }

        public Consultation()
        {
            ViewPolicy = ConsultationViewPolicy.Public;
            Hits = 0;
            SubmitDate = PersianDate.Today;
            SubmitHour = DateTime.Now.Hour;
            SubmitMinute = DateTime.Now.Minute;
            SubmitSecond = DateTime.Now.Second;
        }

        [NonPersistent]
        public virtual string Fullname
        {
            get { return Firstname + " " + Lastname; }
        }

        [NonPersistent]
        public virtual bool IsReplied
        {
            get
            {
                return !string.IsNullOrEmpty(Answer);
            }
        }

        [NonPersistent]
        public virtual string ViewPolicyText
        {
            get { return ViewPolicy.ToDescription(); }
        }

        [NonPersistent]
        public virtual string CategoryText
        {
            get { return Category.ToDescription(); }
        }

        [NonPersistent]
        public virtual string StatusText
        {
            get
            {
                if (IsReplied)
                    return "جواب داده شده";
                return "در حال بررسی";
            }
        }

        [NonPersistent]
        public virtual string SubmitTypeText
        {
            get
            {
                if (InternetRegisteration)
                    return "اینترنتی";
                return "حضوری";
            }
        }

        [NonPersistent]
        public virtual string SubmitTime
        {
            get { return SubmitHour + ":" + SubmitMinute + ":" + SubmitSecond; }
        }

        [NonPersistent]
        public virtual string SubmitDateTimeText
        {
            get { return SubmitDate + " " + SubmitTime; }
        }

        [NonPersistent]
        public virtual string AnswerTime
        {
            get { return AnswerHour + ":" + AnswerMinute + ":" + AnswerSecond; }
        }

        #region Static Members

        public static Consultation FromCode(int code)
        {
            var query = from consultation in DbContext.Entity<Consultation>()
                        where consultation.Code == code
                        select consultation;
            return query.FirstOrDefault();
        }

        public static IQueryable<Consultation> GetConsultations(ConsultationCategory category)
        {
            var query = from consultation in DbContext.Entity<Consultation>()
                        where consultation.Category == category
                              orderby consultation.Id descending 
                        select consultation;
            return query;
        }

        public static IQueryable<Consultation> GetConsultations(ConsultationCategory category, ConsultationViewPolicy policy)
        {
            var query = from consultation in DbContext.Entity<Consultation>()
                        where consultation.Category == category
                              && consultation.ViewPolicy == policy
                              orderby consultation.Id descending 
                        select consultation;
            return query;
        }

        public static List<Consultation> GetRepliedConsultations(ConsultationCategory category, ConsultationViewPolicy policy)
        {
            var query = GetConsultations(category, policy);
            return query.ToList().Where(x => x.IsReplied).ToList();
        }

        public static IEnumerable GetNotRepliedConsultations(ConsultationCategory category)
        {
            var query = GetConsultations(category);
            return query.ToList().Where(x => !x.IsReplied).ToList();
        }

        public static long GenerateCode(int id)
        {
            DateTime now = DateTime.Now;
            long preNum = now.Ticks % 10000;
            string prefix = preNum.ToString();
            while (prefix.Length < 4)
            {
                int random = new Random().Next(1, 9);
                prefix = random + prefix;
            }

            string number = prefix.Substring(0, 2) + id.ToString() + prefix.Substring(2, 2);
            long code = Convert.ToInt64(number);
            return code;
        }

        #endregion

        public virtual void IncrementHits()
        {
            Hits++;
        }

        public virtual void SetConsultant(Person person)
        {
            ConsultantText = person.FarsiFullname;
            ConsultantPerson = person;
        }

        public virtual void SetAnswer(string answer)
        {
            Answer = answer;
            AnswerDate = PersianDate.Today;
            AnswerHour = DateTime.Now.Hour;
            AnswerMinute = DateTime.Now.Minute;
            AnswerSecond = DateTime.Now.Second;
        }

    }

    public enum ConsultationViewPolicy
    {
        [EnumDescription("عمــومــی")]
        Public,
        [EnumDescription("خصــوصــی")]
        Private,
    }

    public enum ConsultationCategory
    {
        [EnumDescription("مشاوره قضایی")]
        Judicial = 0,
        [EnumDescription("مشاوره درسی")]
        Educational = 1,
    }
}