using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

public partial class Student_Signin : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            WebsiteHandler.CurrentRegister = null;
            WebsiteHandler.CurrentPerson = null;
            RadTextBox3.Focus();
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = RadTextBox1.Text.Trim().ToLower();
        string password = RadTextBox2.Text.Trim();
        string code = RadTextBox3.Text.Trim();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(code))
        {
            rMessageBox1.ShowInformation("مشخصات ورود را به صورت کامل و معتبر وارد کنید");
            return;
        }

        if(!RadCaptcha2.IsValid)
        {
            rMessageBox1.ShowInformation("فرم ورود را به صورت معتبر وارد کنید");
            return;
        }

        if(!RadCaptcha1.IsValid)
        {
            rMessageBox1.ShowInformation("شناسه تصویری را به صورت کامل و معتبر وارد کنید");
            return;
        }

        try
        {
            string encUsername = UserInfo.Encrypt(username);
            string encPassword = UserInfo.Encrypt(password);

            Teacher teacher = Teacher.FromLogin(code, encUsername, encPassword);
            if (teacher == null)
            {
                rMessageBox1.ShowInformation("شناسه کاربری/رمز عبور صحیح نیست");
            }
//            else if (teacher.UserInfo.ExpireDate != null && PersianDate.Today > teacher.UserInfo.ExpireDate)
//            {
//                rMessageBox1.ShowInformation("تاریخ اعتبار ورود شما به سیستم منقضی شده است.");
//            }
            else
            {
                if (teacher.UserInfo.Username.Length < 6 || teacher.UserInfo.Password.Length < 6)
                {
                    rMessageBox1.ShowInformation("نام کاربری/رمز عبور کوتاه و غیر امن است. لطفا جهت تغییر به مسئول آموزش مراجعه کنید.");
                    return;
                }

                WebsiteHandler.Signin(teacher);
                WebsiteManager.SaveLog(this, teacher, "ورود به سیستم آموزش اساتید");
                Response.Redirect("~/Instructor/Default.aspx", false);
            }
        }
        catch(MessageException ex)
        {
            rMessageBox1.ShowInformation(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            rMessageBox1.ShowInformation("خطا در ورود به سیستم");
            return;
        }
    }
}
