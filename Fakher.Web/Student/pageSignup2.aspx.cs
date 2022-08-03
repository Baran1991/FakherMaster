using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

public partial class Student_pageSignup2 : Page
{
    WebRegister mRegister;

    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request["c"];
        if(string.IsNullOrEmpty(code))
        {
            Response.Redirect("~", true);
            return;
        }

        mRegister = WebRegister.FromCode(Convert.ToInt64(code));

        if(mRegister.Status != WebRegisterStatus.Started)
        {
            Response.Redirect("~/Student", true);
            return;
        }

        if(!IsPostBack)
        {
            Fill();
        }
    }

    private void Fill()
    {
        RadioButtonListGender.DataSource = typeof(Gender).GetEnumDescriptions();
        RadioButtonListGender.DataBind();
        RadioButtonListGender.SelectedIndex = 0;

        lblEmail.Text = mRegister.ContactInfo.Email;
        lblMajor.Text = mRegister.Major.Name + " - " + mRegister.Period.Name;
    }

    protected void RadBtnSignup_Click(object sender, EventArgs e)
    {
        if(!chkPolicy.Checked)
        {
            rMessageBox1.ShowInformation("شرایط و مفاد ثبت نام را تایید کنید.");
            return;
        }

        string firstname = Services.SecureHtml(RadTxtFirstname.Text.Trim());
        string lastname = Services.SecureHtml(RadTxtLastname.Text.Trim());
        string fathername = Services.SecureHtml(RadTxtFathername.Text.Trim());
        Gender gender = (Gender) RadioButtonListGender.SelectedIndex;
        PersianDate birthDate = PersianDate.FromString(rTxtBirthDate.TextWithLiterals);
        string idNumber = Services.SecureHtml(RadTxtIdNumber.Text.Trim());
        string nationalCode = Services.SecureHtml(RadTxtNationalCode.Text.Trim());
        string province = Services.SecureHtml(RadCmbProvince.Text);
        string city = Services.SecureHtml(RadTxtCity.Text.Trim());
        string address = Services.SecureHtml(RadTxtAddress.Text.Trim());
        string postalCode = Services.SecureHtml(RadTxtPostalCode.Text.Trim());
        string phone = Services.SecureHtml(RadTxtPhone.Text.Trim());
        string mobile = Services.SecureHtml(RadTxtMobile.Text.Trim());

        mRegister.PersonalInfo.FarsiFirstName = firstname;
        mRegister.PersonalInfo.EnglishFirstName = Person.FindEnglishName(firstname);
        mRegister.PersonalInfo.FarsiLastName = lastname;
        mRegister.PersonalInfo.EnglishLastName = Person.FindEnglishName(lastname);
        mRegister.PersonalInfo.FarsiFatherName = fathername;
        mRegister.PersonalInfo.EnglishFatherName = Person.FindEnglishName(fathername);
        mRegister.PersonalInfo.Gender = gender;
        mRegister.PersonalInfo.BirthDate = birthDate;
        mRegister.PersonalInfo.IdNumber = idNumber;
        mRegister.PersonalInfo.NationalCode = nationalCode;
        mRegister.ContactInfo.Province = province;
        mRegister.ContactInfo.City = city;
        mRegister.ContactInfo.Address = address;
        mRegister.ContactInfo.PostalCode = postalCode;
        mRegister.ContactInfo.Phone = phone;
        mRegister.ContactInfo.Mobile = mobile;

        mRegister.Complete();
        mRegister.Save();
        rMessageBox1.ShowInformation("درخواست ثبت نام شما با موفقیت ثبت شد. <br/> نام کاربری/رمز عبور از سوی واحد آموزش در چند ساعت آینده برای شما ارسال خواهد گردید.", true);
    }

    protected void rMessageBox1_DialogResult(object sender, EventArgs e)
    {
        Response.Redirect("~", true);
    }
}
