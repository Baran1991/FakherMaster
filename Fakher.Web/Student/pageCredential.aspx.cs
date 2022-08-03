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
        RadTextBox1.Focus();
    }
    protected void RadBtnCredential_Click(object sender, EventArgs e)
    {
        string code = RadTextBox1.Text.Trim();
        string email = RadTextBox2.Text.Trim().ToLower();
        string date = rTxtBirthDate.TextWithLiterals.Trim();

        Register register = Register.FromCode(code).FirstOrDefault();
        if (register == null)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('شماره دانشجویی معتبر نیست.');", true);

            //rMessageBox1.ShowInformation("شماره دانشجویی معتبر نیست.", false);
            return;
        }

        if (register.Student.UserInfo.LoginStatus == LoginStatus.Enabled)
        {
            PersianDate birthDate = PersianDate.FromString(date);
            if (register.Student.BirthDate != birthDate)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('تاریخ تولد معتبر نیست.');", true);

                //rMessageBox1.ShowInformation("تاریخ تولد معتبر نیست.", false);
                return;
            }

            Person person = Person.FromUsername(UserInfo.Encrypt(email), LoginStatus.Enabled, true);
            if (person != null && person.Id != register.Student.Id)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ایمیل "+email+" قبلا در سیستم استفاده شده است.');", true);

                //rMessageBox1.ShowInformation("ایمیل {0} قبلا در سیستم استفاده شده است.", false, email);
                return;
            }

//            if (!UserInfo.IsAvailable(UserInfo.Encrypt(email)))
//            {
//                rMessageBox1.ShowInformation("ایمیل {0} قبلا در سیستم استفاده شده است.", false, email);
//                return;
//            }

            if (register.Student.UserInfo.WebLogin)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('شناسه کاربری شما قبلا به ایمیل " + register.Student.UserInfo.GetRawEmail() + " ارسال شده است.');", true);

                //rMessageBox1.ShowInformation("شناسه کاربری شما قبلا به ایمیل {0} ارسال شده است.", false, register.Student.UserInfo.GetRawEmail());
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
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('شناسه و رمزعبور، به ایمیل " + email + "ارسال گردید. کمی صبر کنید، اگر ایمیل را دریافت نکردید پوشه SPAM خود را نیز چک کنید.');", true);

                //rMessageBox1.ShowInformation("شناسه و رمزعبور، به ایمیل {0} ارسال گردید. کمی صبر کنید، اگر ایمیل را دریافت نکردید پوشه SPAM خود را نیز چک کنید.", false, email);
            }
            catch (Exception ex)
            {
                WebsiteManager.SaveLog(this, register.Student, "خطا در دریافت شناسه کاربری");
                WebsiteManager.SaveException(this, ex);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('متاسفانه در ارسال شناسه کاربری شما خطایی رخ داده است.');", true);

                //rMessageBox1.ShowInformation("متاسفانه در ارسال شناسه کاربری شما خطایی رخ داده است.", false, email);
                return;
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('دریافت شناسه کاربری برای شما امکان پذیر نیست.');", true);

            //rMessageBox1.ShowInformation("دریافت شناسه کاربری برای شما امکان پذیر نیست.", false);
            return;
        }
    }
}
