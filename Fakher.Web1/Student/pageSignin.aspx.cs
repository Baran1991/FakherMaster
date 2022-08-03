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

public partial class Student_Signin : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            WebsiteHandler.CurrentRegister = null;
            WebsiteHandler.CurrentPerson = null;
        }
        RadTextBox1.Focus();
        var branches = DbContext.GetAllEntities<Branch>();
        //cmbBranch.DataSource = branches;
        //cmbBranch.DataBind();
    }
    protected void cmbBranch_DataBound(object sender, EventArgs e)
    {
        //cmbBranch.DataTextField = "Name";
        //cmbBranch.DataValueField = "Id";
    }
    protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = RadTextBox1.Text.Trim().ToLower();
        string password = RadTextBox2.Text.Trim();
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('شناسه کاربری/رمز عبور را به صورت کامل و معتبر وارد کنید.');", true);
            rMessageBox1.ShowInformation("شناسه کاربری/رمز عبور را به صورت کامل و معتبر وارد کنید");
            return;
        }

        if (!RadCaptcha1.IsValid)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('شناسه تصویری را به صورت کامل و صحیح وارد کنید.');", true);

            rMessageBox1.ShowInformation("شناسه تصویری را به صورت کامل و صحیح وارد کنید");
            return;
        }

        try
        {
            string encUsername = UserInfo.Encrypt(username);
            string encPassword = UserInfo.Encrypt(password);

            Student student = Student.FromLogin(encUsername, encPassword);
            if (student == null)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('شناسه کاربری/رمز عبور صحیح نیست.');", true);

                rMessageBox1.ShowInformation("شناسه کاربری/رمز عبور صحیح نیست");
            }
            else if (student.UserInfo.ExpireDate != null && PersianDate.Today > student.UserInfo.ExpireDate)
            {
                rMessageBox1.ShowInformation("تاریخ اعتبار ورود شما به سیستم منقضی شده است.");
            }
            else
            {
                WebsiteHandler.Signin(student);
                WebsiteManager.SaveLog(this, student, "ورود به سیستم آموزش");
                Response.Redirect("~/Student/Default.aspx", false);
            }
        }
        catch (MessageException ex)
        {
            WebsiteManager.SaveException(this, ex);
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('"+ ex.Message + "');", true);

            rMessageBox1.ShowInformation(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('خطا در ورود به سیستم.');", true);
            rMessageBox1.ShowInformation("خطا در ورود به سیستم");
            return;
        }
    }
    protected void RadBtnCredential_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Student/pageCredential.aspx", true);
    }
}
