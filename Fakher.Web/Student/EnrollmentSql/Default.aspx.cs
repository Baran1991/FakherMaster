using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

public partial class Student_Enrollment_Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Clear();
            SetCaptcha();
            TextBox1.Focus();
        }
    }

    private void SetCaptcha()
    {
        Random oRandom = new Random();
        int iNumber = oRandom.Next(100000, 999999);
        Session[WebsiteHandler.CaptchaSessionKey] = iNumber.ToString();
        txtCaptcha.Text = "";
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = Services.SecureHtml(TextBox1.Text.Trim().ToLower());
        string password = Services.SecureHtml(TextBox2.Text.Trim());
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            rSimpleMessageBox1.ShowInformation("شناسه کاربری/رمز عبور را به صورت کامل و معتبر وارد کنید");
            return;
        }

        if (Session[WebsiteHandler.CaptchaSessionKey] + "" != Services.SecureHtml(txtCaptcha.Text.Trim()))
        {
            SetCaptcha();
            rSimpleMessageBox1.ShowInformation("شناسه تصویری را به صورت کامل و صحیح وارد کنید");
            return;
        }

        try
        {
            string encUsername = UserInfo.Encrypt(username);
            string encPassword = UserInfo.Encrypt(password);

            DbOperations dbOperations = new DbOperations(DbContext.GetConnectionString());
            object id = dbOperations.ExecuteScalar(
                string.Format("select top 1 [Id] from [UserInfos] where [Username]='{0}' and [Password]='{1}'", encUsername,
                              encPassword));
            if (id == null)
            {
                throw new MessageException("شناسه کاربری/رمز عبور صحیح نیست");
            }
            else
            {
                object studentId = dbOperations.ExecuteScalar(string.Format("select top 1 [Id] from [Persons] where [UserInfo_id] = {0}", id));
                if(studentId == null)
                    throw new MessageException("شناسه کاربری/رمز عبور صحیح نیست");

                Session.Clear();
                Session[WebsiteHandler.CurrentPersonKey] = studentId;
//                WebsiteHandler.Signin(student);
                WebsiteManager.SaveEnrollmentLog(this, null, string.Format("ورود به سیستم آموزش [{0}] [{1}]", Request.UserHostAddress, Request.UserAgent));
                Response.Redirect("~/Student/Enrollment/pageSectionEnrollment1.aspx", false);
            }
        }
        catch (MessageException ex)
        {
            WebsiteManager.SaveException(this, ex);
            rSimpleMessageBox1.ShowInformation(ex.Message);
            SetCaptcha();
            return;
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            rSimpleMessageBox1.ShowInformation("خطا در ورود به سیستم");
            SetCaptcha();
            return;
        }
    }

    protected void BtnCredential_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Student/Enrollment/pageCredential.aspx", true);
    }

    protected void lnkNewCaptcha_Click(object sender, EventArgs e)
    {
        SetCaptcha();
    }
}
