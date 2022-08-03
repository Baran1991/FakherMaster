using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    [EventClass("رزرو")]
    public class Reserve : FinancialEntity
    {
        public Reserve()
        {
            FinancialDocument = new FinancialDocument();
            ReserveDate = PersianDate.Today;
        }

        [EventClassProperty("کد رزرو", null)]
        public virtual EducationalCode EducationalCode { get; set; }
//        public virtual string Code { get; set; }
        public virtual PersianDate ReserveDate { get; set; }
        [EventClassProperty("لیست رزرو", null)]
        [NoCascade]
        public virtual ReserveList ReserveList { get; set; }
        [EventClassProperty("انصراف", null)]
        public virtual Quit Quit { get; set; }
        [EventClassProperty("انتقال", null)]
        public virtual Transition Transition { get; set; }
        [EventClassProperty("نام دانشجو", null)]
        [NoCascade]
        public virtual Student Student { get; set; }
        /// <summary>
        /// شی ثبت نامی هست که از ثبت نام حاصل از این رزرو بعدا ساخته می شود
        /// </summary>
        [NoCascade]
        public virtual Register Register { get; set; }
        public virtual string Registrar { get; set; }
        


        //        public virtual Person Registrar { get; set; }
        //        public virtual string RegistrarText { get; set; }

        [NonPersistent]
        public virtual string Code
        {
            get
            {
                if (EducationalCode != null)
                    return EducationalCode.Code;
                return "";
            }
        }

        [NonPersistent]
        public virtual string StatusText
        {
            get
            {
                if (Quit != null)
                    return "انصراف از " + ReserveList.Name;
                if (Register != null)
                    return "ثبت نام شده در " + Register.ToString();
                return "رزرو، " + ReserveList.Name;
            }
        }

        [NonPersistent]
        public virtual int QuitedSign
        {
            get
            {
                if (Quit != null)
                    return 1;
                return 0;
            }
        }

        public virtual KeyValuePair<PersianDate, object>? GetLastActivity()
        {
            List<KeyValuePair<PersianDate, object>> activities = new List<KeyValuePair<PersianDate, object>>();

            activities.Add(new KeyValuePair<PersianDate, object>(ReserveDate, this));
            if (QuitedSign > 0)
                activities.Add(new KeyValuePair<PersianDate, object>(Quit.Date, Quit));

            var query = from pair in activities
                        orderby pair.Key descending
                        select pair;
            if (query.Count() > 0)
                return query.First();
            return null;
        }

        public virtual PersianDate GetLastActivityDate()
        {
            KeyValuePair<PersianDate, object>? lastActivity = GetLastActivity();
            if(lastActivity == null)
                return null;
            return lastActivity.Value.Key;
        }

        public override void BeforeSave()
        {
            if(EducationalCode == null)
                EducationalCode = Student.GenerateCode(ReserveList.Period, ReserveList.Major, false);

//            if (Id == 0 && string.IsNullOrEmpty(Code))
//                Code = Student.GenerateCode(ReserveList.Period, ReserveList.Major, false);
        }

        #region Overrides of FinancialEntity

        [NonPersistent]
        public override long PayableTuition
        {
            get
            {
                return ReserveList.TuitionFee;
            }
        }

        [NonPersistent]
        public override FinancialHeading Heading
        {
            get { return FinancialHeading.ReserveSignup; }
        }

        #endregion

        public static List<Reserve> FromCode(string code)
        {
            var query = from reserve in DbContext.Entity<Reserve>()
                        where reserve.Student != null
                        && reserve.EducationalCode.Code == code
                        select reserve;
            return query.ToList();

        }

        public static IList<Reserve> GetReserves()
        {
            return DbContext.GetAllEntities<Reserve>();
        }

        public override string ToString()
        {
            return Student.FarsiFullname + " (" + ReserveList.Name + ")";
        }
     

    }
}