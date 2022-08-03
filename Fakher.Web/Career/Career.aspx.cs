using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using rComponents;

public partial class Career_Career : Page
{
    private Career mCareer;

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request["id"];
        if (string.IsNullOrEmpty(id))
        {
            Response.Redirect("~/Career/", true);
            return;
        }

        mCareer = Career.FromId(Convert.ToInt32(id));
        Literal1.Text = mCareer.DescriptionHtml;

        if (!IsPostBack)
        {
            RadCmbEducationalDegree.DataSource = typeof (EducationalDegree).GetEnumItems();
            RadCmbEducationalDegree.DataBind();
        }
    }

    protected void RadBtnOk_Click(object sender, EventArgs e)
    {
        if (mCareer == null)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('سیستم قادر به ذخیره درخواست شما نیست');", true);
            //rMessageBox1.ShowInformation("سیستم قادر به ذخیره درخواست شما نیست.");
            return;
        }
        if(!chkPolicy.Checked)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('اطلاعات را پس از تکمیل، با زدن تیک تایید کنید');", true);

            //rMessageBox1.ShowInformation("اطلاعات را پس از تکمیل، با زدن تیک تایید کنید.");
            return;
        }

        CareerApplicant applicant = new CareerApplicant { Career = mCareer };
        try
        {
            BindToObject(applicant);
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('"+ex.Message+"');", true);

            //rMessageBox1.ShowInformation("همه فیلدها الزامی هستند. همه را به صورت کامل و معتبر پر کنید.");
            return;
        }

        applicant.Save();
        applicant.GenerateCode();
        applicant.Save();

        lblMessage.Text = string.Format("درخواست همکاری شما با شماره پیگیری {0} در سیستم ثبت گردید.",
                            applicant.Code);
        pnlDetails.Visible = false;
        pnlOk.Visible = true;
    }

    private void BindToObject(CareerApplicant applicant)
    {
        applicant.PersonalInfo.FarsiFirstName = RadTxtFirstname.Text.Trim();
        applicant.PersonalInfo.FarsiLastName = RadTxtLastname.Text.Trim();
        applicant.PersonalInfo.FarsiFatherName = RadTxtFathername.Text.Trim();

        applicant.PersonalInfo.Gender = rBtnGenderType.SelectedIndex == 0 ? Gender.Male : Gender.Female;
        applicant.PersonalInfo.MarriageStatus = rBtnMarriageStatus.SelectedIndex == 0
                                                    ? MarriageStatus.Single
                                                    : MarriageStatus.Married;
        applicant.PersonalInfo.NationalCode = rTxtNationalCode.Text.Trim();
        applicant.PersonalInfo.IdNumber = rTxtIdNumber.Text.Trim();
        applicant.PersonalInfo.BirthDate = PersianDate.FromString(rTxtBirthDate.Text.Trim());
        applicant.PersonalInfo.BirthPlace = rTxtBirthPlace.Text.Trim();

        applicant.EducationalInfo.EducationalDegree = (EducationalDegree) Convert.ToInt32(RadCmbEducationalDegree.SelectedValue);
        applicant.EducationalInfo.EducationalMajor = RadTxtEducationalMajor.Text.Trim();
        applicant.EducationalInfo.EducationalUniversity = RadTxtEcuationalUniversity.Text.Trim();
        applicant.EducationalInfo.EducationalDegreeMark = float.Parse(RadTxtEducationalDegreeMark.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);

        applicant.ContactInfo.Phone = RadTxtPhone.Text.Trim();
        applicant.ContactInfo.Mobile = RadTxtMobile.Text.Trim();
        applicant.ContactInfo.Email = RadTxtEmail.Text.Trim();
        applicant.ContactInfo.Address = RadTxtAddress.Text.Trim();

        applicant.Experiences = RadTxtExperiences.Text.Trim();
    }
}
