using System;
using System.Linq;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Consult;
using rComponents;

namespace Fakher.Core.Website
{
    public class WebRegister : DbObject
    {
        public virtual long Code { get; set; }
        public virtual WebRegisterStatus Status { get; set; }
        [Attendant]
        public virtual PersonalInfo PersonalInfo { get; set; }
        [Attendant]
        public virtual EducationalInfo EducationalInfo { get; set; }
        [Attendant]
        public virtual ContactInfo ContactInfo { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual PersianDate Date { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        public virtual int Second { get; set; }
        [NoCascade]
        public virtual EducationalPeriod Period { get; set; }
        [NoCascade]
        public virtual Major Major { get; set; }
        /// <summary>
        /// Created Register after confirm
        /// </summary>
        [NoCascade]
        public virtual Register Register { get; set; }

        public WebRegister()
        {
            Status = WebRegisterStatus.Started;
            PersonalInfo = new PersonalInfo();
            EducationalInfo = new EducationalInfo();
            ContactInfo = new ContactInfo();
            Date = PersianDate.Today;
            Hour = Time.Now.Hour;
            Minute = Time.Now.Minute;
            Second = Time.Now.Second;
        }

        [NonPersistent]
        public virtual string Text
        {
            get { return Major.Name + " - تــرم " + Period.Name; }
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

            string number = prefix.Substring(0, 2) + Id.ToString() + prefix.Substring(2, 2);
            long code = Convert.ToInt64(number);
            Code = code;
        }

        public virtual string GetEmailConfirmHtmlText()
        {
            string link = string.Format("http://www.fakher.ac.ir/Student/pageSignup2.aspx?c={0}", Code);

            string html = "";
            html += "<div style=\"font-family:Tahoma; text-align: right; direction: rtl\">";
            html += "<p>کاربر گرامی،</p>";
            html += "<p>جهت تکمیل ثبت نام و ورود اطلاعات تکمیلی بر روی لینک زیر کلیک کنید؛</p>";
            html += "<br />";
            html += string.Format("<a href=\"{0}\">{0}</a>", link);
            html += "<br />";
            html += "<p></p><hr style=\"width: 50%; text-align: center;\" /><p></p>";
            html += "<p style=\"text-align: center; font-size: 8pt;\">این ایمیل به صورت خودکار ارسال گردیده، لطفا به آن پاسخ ندهید.</p>";
            html += "</div>";
            return html;
        }

        public virtual void Complete()
        {
            Status = WebRegisterStatus.Completed;
        }

        public virtual void Confirm()
        {
            Status = WebRegisterStatus.Confirmed;
        }

        public virtual Register GenerateRegister()
        {
            Student student = Student.FromWebRegister(this);
            Register register = student.CreateRegister(Period, Major, RegisterType.Participation, true);
            register.InternetRegisteration = true;
            student.Registers.Add(register);

            return register;
        }

        #region Static Members

        public static WebRegister FromCode(long code)
        {
            var query = from webRegister in DbContext.Entity<WebRegister>()
                        where webRegister.Code == code
                        select webRegister;
            return query.FirstOrDefault();
        }

        #endregion

        public static IQueryable<WebRegister> GetWebRegistersQuery(WebRegisterStatus status)
        {
            var query = from webRegister in DbContext.Entity<WebRegister>()
                        where webRegister.Status == status
                        select webRegister;
            return query;
        }
    }

    public enum WebRegisterStatus
    {
        [EnumDescription("شروع شده")]
        Started,
        [EnumDescription("تکمیل شده")]
        Completed,
        [EnumDescription("تایید شده")]
        Confirmed,
    }
}