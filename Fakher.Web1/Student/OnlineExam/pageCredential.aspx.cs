using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using rComponents;
using LoginStatus = Fakher.Core.DomainModel.LoginStatus;

public partial class Student_pageCredential : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Focus();
    }
    protected void RadBtnCredential_Click(object sender, EventArgs e)
    {
        string code = Services.SecureHtml(TextBox1.Text.Trim());
        string email = Services.SecureHtml(RadTextBox2.Text.Trim().ToLower());
        string date = Services.SecureHtml(rTxtBirthDate.Text.Trim());

        PersianDate persianDate;
        try
        {
            persianDate = PersianDate.FromString(date);
        }
        catch (Exception ex)
        {
            rSimpleMessageBox1.ShowInformation("تاریخ تولد معتبر نیست. تاریخ را از چپ به راست به ترتیب سال و ماه و روز بنویسید و آنها را با '/' جدا نمایید.");
            return;
        }

        Register register = Register.FromCode(code).FirstOrDefault();
        if (register == null)
        {
            rSimpleMessageBox1.ShowInformation("شماره دانشجویی معتبر نیست.");
            return;
        }

        if (register.Student.UserInfo.LoginStatus == LoginStatus.Enabled)
        {
            PersianDate birthDate = persianDate;
            if (register.Student.BirthDate != birthDate)
            {
                rSimpleMessageBox1.ShowInformation("تاریخ تولد معتبر نیست.");
                return;
            }

            Person person = Person.FromUsername(UserInfo.Encrypt(email), LoginStatus.Enabled, true);
            if (person != null && person.Id != register.Student.Id)
            {
                rSimpleMessageBox1.ShowInformation("ایمیل {0} قبلا در سیستم استفاده شده است.", email);
                return;
            }

//            if (!UserInfo.IsAvailable(UserInfo.Encrypt(email)))
//            {
//                rMessageBox1.ShowInformation("ایمیل {0} قبلا در سیستم استفاده شده است.", false, email);
//                return;
//            }

            if (register.Student.UserInfo.WebLogin)
            {
                rSimpleMessageBox1.ShowInformation("شناسه کاربری شما قبلا به ایمیل {0} ارسال شده است.", register.Student.UserInfo.GetRawEmail());
                return;
            }

            try
            {
                register.Student.UserInfo.SetEmail(email);
                register.Student.UserInfo.SetUsername(email);
                register.Student.UserInfo.SetPassword(register.Student.Code);
                register.Student.UserInfo.ActivateWeb();
                register.Student.UserInfo.Save();

                InternetPostMaster.Send(InternetPostMaster.NoReply, new[] { new MailAddress(email) }, "شناسه کاربری", register.Student.UserInfo.GetLoginHtmlText(), true, true);
                WebsiteManager.SaveLog(this, register.Student, "دریافت شناسه کاربری");
                rSimpleMessageBox1.ShowInformation("شناسه و رمزعبور، به ایمیل {0} ارسال گردید. کمی صبر کنید، اگر ایمیل را دریافت نکردید پوشه SPAM خود را نیز چک کنید.", email);
            }
            catch (Exception ex)
            {
                WebsiteManager.SaveLog(this, register.Student, "خطا در دریافت شناسه کاربری");
                WebsiteManager.SaveException(this, ex);
                rSimpleMessageBox1.ShowInformation("متاسفانه در ارسال شناسه کاربری شما خطایی رخ داده است.", email);
                return;
            }
        }
        else
        {
            rSimpleMessageBox1.ShowInformation("دریافت شناسه کاربری برای شما امکان پذیر نیست.");
            return;
        }
    }
}
