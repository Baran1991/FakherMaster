using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.Website;
using Fakher.Core.DomainModel;

public partial class ChangePassword : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(WebsiteHandler.CurrentPerson == null)
        {
            Response.Redirect("~", true);
            return;
        }
        rTxtOldPassword.Focus();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string oldPassword = rTxtOldPassword.Text;
        string newPassword = rTxtNewPassword.Text;
        string newPassword2 = rTxtNewPassword2.Text;

        if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(newPassword2))
        {
            rMessageBox1.ShowInformation("رمز عبور را به صورت کامل و معتبر وارد کنید");
            return;
        }
        if (newPassword != newPassword2)
        {
            rMessageBox1.ShowInformation("رمزعبور جدید و تکرار آن یکسان نیست.");
            return;
        }
        if (UserInfo.Encrypt(oldPassword) != WebsiteHandler.CurrentPerson.UserInfo.Password)
        {
            rMessageBox1.ShowInformation("رمزعبور فعلی صحیح نیست.");
            return;
        }
        if(oldPassword == newPassword)
        {
            rMessageBox1.ShowInformation("رمزعبور فعلی و جدید نمی توانند یکسان باشند.");
            return;
        }
        if(newPassword.Length < 6)
        {
            rMessageBox1.ShowInformation("رمز باید حداقل شش حرف باشد.");
            return;
        }

        try
        {
            WebsiteHandler.CurrentPerson.UserInfo.SetPassword(newPassword);
//            WebsiteHandler.CurrentPerson.UserInfo.Password = newPassword;
            WebsiteHandler.CurrentPerson.UserInfo.Save();
            rMessageBox1.ShowInformation("رمزعبور با موفقیت تغییر یافت. لطفا مجددا وارد شوید.", true);
        }
        catch (Exception ex)
        {
            rMessageBox1.ShowInformation("خطا");
            return;
        }
    }

    protected void rMessageBox1_DialogResult(object sender, DialogResultEventArgs e)
    {
        if(e.Result == DialogResult.Ok)
        {
            Response.Redirect("~/Signout.aspx", true);
            return;
        }
    }
}
