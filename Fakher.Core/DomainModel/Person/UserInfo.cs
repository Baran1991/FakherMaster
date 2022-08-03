using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class UserInfo : DbObject
    {
        public virtual LoginStatus LoginStatus { get; set; }
        public virtual bool AppLogin { get; set; }
        public virtual bool WebLogin { get; set; }
        public virtual PersianDate ExpireDate { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual string BanReason { get; set; }
        public virtual PersianDate AppActivateDate { get; set; }
        public virtual PersianDate WebActivateDate { get; set; }
        public virtual PersianDate LastSigninDate { get; set; }
        public virtual string LastSigninIp { get; set; }
        [Attendant]
        public virtual AccessGroup AccessGroup { get; set; }
        [Attendant]
        [NoCascade]
        public virtual EducationalPeriod WorkingPeriod { get; set; }
        public virtual IList<AccessTag> AccessTags { get; set; } 

        public UserInfo()
        {
            LoginStatus = LoginStatus.Enabled;
            AppLogin = false;
            WebLogin = false;
            AccessTags = new List<AccessTag>();
        }

        [NonPersistent]
        public virtual string WebLoginText
        {
            get
            {
                if (WebLogin)
                    return "فعـال";
                return "غیـر فعـال";
            }
        }

        [NonPersistent]
        public virtual bool CanLogin
        {
            get { return WebLogin || AppLogin; }
        }

        public virtual bool IsAllowed(string text)
        {
            return AccessGroup.IsAllowed(text);
        }

        public virtual AccessTag GetAccessTag(AccessTagType tagType)
        {
            foreach (AccessTag accessTag in AccessTags)
                if (accessTag.Type == tagType)
                    return accessTag;

            if(AccessGroup != null)
                foreach (AccessTag accessTag in AccessGroup.AccessTags)
                    if (accessTag.Type == tagType)
                        return accessTag;

            return null;
        }

        public virtual void Deactivate()
        {
            LoginStatus = LoginStatus.Disabled;
        }

        public virtual void DeactivateWeb()
        {
            WebLogin = false;
        }

        public virtual void DeactivateApp()
        {
            AppLogin = false;
        }

        public virtual void ActivateWeb()
        {
            LoginStatus = LoginStatus.Enabled;
            WebLogin = true;
            WebActivateDate = PersianDate.Today;
        }

        public virtual void ActivateApp()
        {
            LoginStatus = LoginStatus.Enabled;
            AppLogin = true;
            AppActivateDate = PersianDate.Today;
        }

        public virtual void Signin(string ip)
        {
            LastSigninDate = PersianDate.Today;
            LastSigninIp = ip;
        }

        public virtual void Signout()
        {

        }

        public virtual void SetEmail(string rawEmail)
        {
            Email = rawEmail;
        }

        public virtual void SetUsername(string rawUsername)
        {
            Username = Encrypt(rawUsername);
        }

        public virtual void SetPassword(string rawPassword)
        {
            Password = Encrypt(rawPassword);
        }

        public virtual string GetRawEmail()
        {
            if (string.IsNullOrEmpty(Email))
                return Email;
            return Email;
        }

        public virtual string GetRawUsername()
        {
            if (string.IsNullOrEmpty(Username))
                return Username;
            return Decrypt(Username);
        }

        public virtual string GetRawPassword()
        {
            if (string.IsNullOrEmpty(Password))
                return Password;
            return Decrypt(Password);
        }

        public virtual string GetLoginSmsText()
        {
            return "شناسه سیستم آموزش شما فعال گردید.به ایمیل خود مراجعه کنید.\nموسسه فاخر";
        }

        public virtual string GetLoginHtmlText()
        {
            string html = "";
            html += "<div style=\"font-family:Tahoma; text-align: right; direction: rtl\">";
            html += "<p>دانشجوی گرامی،</p>";
            html += "<p>مشخصات شما برای ورود به وب سایت عبارتست از؛</p>";
            html += "<br />";
            html += string.Format("<span style=\"font-weight: bold; font-family: Tahoma\">شناسه کاربری: {0} </span>",
                             GetRawUsername()) + "\r\n";
            html += "<br />" + "\r\n";
            html += string.Format("<span style=\"font-weight: bold; font-family: Tahoma\">رمز عبور: {0} </span>",
                             GetRawPassword()) + "\r\n";
            html += "<br /><br /><span style=\"font-family: Tahoma\">";
            html += "راهنما؛<br />" + "\r\n";
            html += "برای انجام امور آموزشی خود، ابتدا باید به بخش <a href=\"http://www.fakher.ac.ir/Student\">سیستم آموزش دانشجویان</a> وارد شوید.<br />" + "\r\n";
            html += "برای ورود به این بخش کافیست از منوی <em>دانشجویان</em>، برروی منوی <em>ورود به سیستم آموزش </em>کلیک کنید. <br />";
            html += "پس از ورود ابتدا رشته تحصیلی و ترم جاری موردنظر را انتخاب کنید و امور آموزشی موردنظر خود را از منوی سمت راست صفحه انتخاب کنید.";
            html += "</span>";
            html += "<p></p><hr style=\"width: 50%; text-align: center;\" /><p></p>";
            html += "<p style=\"text-align: center; font-size: 8pt;\">این ایمیل به صورت خودکار ارسال گردیده، لطفا به آن پاسخ ندهید.</p>";
            html += "</div>";
            return html;
        }

        #region Static Methods

//        public static bool IsAvailable(string username)
//        {
//            var query = from user in DbContext.Entity<UserInfo>()
//                        where user.LoginStatus == LoginStatus.Enabled
//                            && user.Username == username
//                            && (user.WebLogin || user.AppLogin)
//                        select user;
//            return query.Count() == 0;
//        }

        public static UserInfo FromId(int id)
        {
            return DbContext.FromId<UserInfo>(id);
        }

        public static string Encrypt(string text)
        {
            return EncryptDecrypt.Encrypt(text);
        }

        public static string Decrypt(string text)
        {
            return EncryptDecrypt.Decrypt(text);
        }

        #endregion
    }

    public enum LoginStatus
    {
        Enabled,
        Disabled,
    }
}