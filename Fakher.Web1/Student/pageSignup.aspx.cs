using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;
using LoginStatus = Fakher.Core.DomainModel.LoginStatus;

public partial class Student_pageSignup : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            Fill();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        IList<EnrollmentLicense> enrollmentLicenses = EnrollmentLicense.GetEnrollmentLicenses(EnrollmentLicenseType.NewStudentEnrollment, PersianDate.Today, DateTime.Now.Hour, DateTime.Now.Minute);
        if (enrollmentLicenses.Count == 0)
        {
            rMessageBox1.ShowInformation("در حال حاضر امکان ثبت نام دانشجو جدید وجود ندارد. جهت اطلاعات بیشتر با موسسه تماس بگیرید.", true);
        }

        Panel1.Visible = enrollmentLicenses.Count != 0;
    }

    private void Fill()
    {
        IList<EnrollmentLicense> enrollmentLicenses =
            EnrollmentLicense.GetEnrollmentLicenses(EnrollmentLicenseType.NewStudentEnrollment, PersianDate.Today,
                                                    DateTime.Now.Hour, DateTime.Now.Minute);
        RadCmbMajor.DataSource = enrollmentLicenses;
        RadCmbMajor.DataBind();
    }

    protected void RadBtnSignup_Click(object sender, EventArgs e)
    {
        
    }

    protected void RadBtnEmailConfirm_Click(object sender, EventArgs e)
    {
        string email = RadTxtEmail.Text.Trim().ToLower();

        if (string.IsNullOrEmpty(email))
        {
            rMessageBox1.ShowInformation("ایمیل را وارد کنید.");
            return;
        }
        if (RadCmbMajor.SelectedIndex == -1)
        {
            rMessageBox1.ShowInformation("رشته ثبت نامی را انتخاب کنید.");
            return;
        }
        if(!RadCaptcha1.IsValid)
        {
            rMessageBox1.ShowInformation("شناسه تصویری را به صورت صحیح وارد کنید.");
            return;
        }

        Person person = Person.FromUsername(UserInfo.Encrypt(email), LoginStatus.Enabled, true);
        if (person != null && person.Id > 0)
        {
            rMessageBox1.ShowInformation("ایمیل {0} قبلا در سیستم استفاده شده است.", false, email);
            return;
        }

        WebRegister webRegister = new WebRegister();
        webRegister.ContactInfo.Email = email;

        int licenseId = Convert.ToInt32(RadCmbMajor.SelectedValue);
        EnrollmentLicense license = EnrollmentLicense.FromId(licenseId);
        webRegister.Period = license.EducationalPeriod;
        webRegister.Major = license.Major;

        webRegister.Save();
        webRegister.GenerateCode();
        webRegister.Save();

        InternetPostMaster.Send(InternetPostMaster.NoReply, new[] { new MailAddress(email) }, "تایید و تکمیل ثبت نام", webRegister.GetEmailConfirmHtmlText(), true, true);
        WebsiteManager.SaveLog(this, null, "ارسال تایید ایمیل");
        rMessageBox1.ShowInformation("ایمیل تایید، به آدرس {0} ارسال گردید. کمی صبر کنید، اگر ایمیل را دریافت نکردید پوشه SPAM خود را نیز چک کنید.", false, email);
    }

    protected void rMessageBox1_DialogResult(object sender, EventArgs e)
    {
        Response.Redirect("~", true);
    }
}
