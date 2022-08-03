using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;
using Fakher.Core.DomainModel.Consult;
using rComponents;

public partial class Consult_Default : Page
{
    private ConsultationCategory mCategory;

    protected void Page_Load(object sender, EventArgs e)
    {
        string category = Request["Category"];

        if (string.IsNullOrEmpty(category))
        {
            mCategory = ConsultationCategory.Judicial;
        }
        else
        {
            int categoryNum = Convert.ToInt32(category);
            mCategory = (ConsultationCategory)categoryNum;
        }

        RadWindow1.Visible = false;
        Fill();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        Title = "مــرکز مشــاوره فاخــر - " + mCategory.ToDescription();
    }

    private void Fill()
    {
//        string description = WebsiteManager.GetAppSetting<string>(WebsiteHandler.ConsultationStatusDescription);
//        lblDescription.Text = description;
//        pnlDescription.Visible = !string.IsNullOrEmpty(description);

        List<Consultation> consultations = Consultation.GetRepliedConsultations(mCategory, ConsultationViewPolicy.Public);
        RadGrid1.DataSource = consultations;
        RadGrid1.DataBind();
    }

    private void BindToObject(Consultation consultation)
    {
        consultation.Firstname = Services.NormalizeFarsiString(Services.SecureHtml(RadTxtFirstname.Text.Trim()));
        consultation.Lastname = Services.NormalizeFarsiString(Services.SecureHtml(RadTxtLastname.Text.Trim()));
        consultation.Email = Services.NormalizeFarsiString(Services.SecureHtml(RadTxtEmail.Text.Trim()));
        consultation.Phone = Services.NormalizeFarsiString(Services.SecureHtml(rTxtPhone.Text.Trim()));
        consultation.Title = Services.NormalizeFarsiString(Services.SecureHtml(RadTxtTitle.Text.Trim()));
        consultation.Question = Services.NormalizeFarsiString(Services.SecureHtml(RadTxtQuestion.Text.Trim()));
        consultation.ViewPolicy = chkPrivate.Checked ? ConsultationViewPolicy.Private : ConsultationViewPolicy.Public;
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";
        }
    }

    protected void btnNewConsultant_Click(object sender, EventArgs e)
    {
        ConsultationStatus status = ConsultationStatus.Disable;
        string statusDescription = "";
        if (mCategory == ConsultationCategory.Judicial)
        {
            status = WebsiteManager.GetAppSetting<int, ConsultationStatus>(WebsiteHandler.JudicialConsultationStatus);
            statusDescription = WebsiteManager.GetAppSetting<string>(WebsiteHandler.JudicialConsultationStatusDescription).Trim();
        }
        if (mCategory == ConsultationCategory.Educational)
        {
            status = WebsiteManager.GetAppSetting<int, ConsultationStatus>(WebsiteHandler.EducationalConsultationStatus);
            statusDescription = WebsiteManager.GetAppSetting<string>(WebsiteHandler.EducationalConsultationStatusDescription).Trim();
        }

        try
        {
            if (status == ConsultationStatus.Disable)
            {
                if (!string.IsNullOrEmpty(statusDescription))
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('"+ statusDescription + "');", true);

                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('در حال حاضر بخش مشاوره غیرفعال است.');", true);

            }
            if(status==ConsultationStatus.ByPeriod)
            {
                PersianDate startDate = null;
                Time startTime = null;
                PersianDate endDate = null;
                Time endTime = null;
                if (mCategory == ConsultationCategory.Judicial)
                {
                    startDate = PersianDate.FromString(WebsiteManager.GetAppSetting<string>(WebsiteHandler.JudicialConsultationStartDate));
                    startTime = Time.FromString(WebsiteManager.GetAppSetting<string>(WebsiteHandler.JudicialConsultationStartTime));
                    endDate = PersianDate.FromString(WebsiteManager.GetAppSetting<string>(WebsiteHandler.JudicialConsultationEndDate));
                    endTime = Time.FromString(WebsiteManager.GetAppSetting<string>(WebsiteHandler.JudicialConsultationEndTime));
                }
                if (mCategory == ConsultationCategory.Educational)
                {
                    startDate = PersianDate.FromString(WebsiteManager.GetAppSetting<string>(WebsiteHandler.EducationalConsultationStartDate));
                    startTime = Time.FromString(WebsiteManager.GetAppSetting<string>(WebsiteHandler.EducationalConsultationStartTime));
                    endDate = PersianDate.FromString(WebsiteManager.GetAppSetting<string>(WebsiteHandler.EducationalConsultationEndDate));
                    endTime = Time.FromString(WebsiteManager.GetAppSetting<string>(WebsiteHandler.EducationalConsultationEndTime));
                }

                if(PersianDate.Today < startDate || PersianDate.Today > endDate)
                    if (!string.IsNullOrEmpty(statusDescription))
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + statusDescription + "');", true);

                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('در حال حاضر بخش مشاوره غیرفعال است.');", true);


                if ((PersianDate.Today == startDate) && (Time.Now < startTime))
                    if (!string.IsNullOrEmpty(statusDescription))
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + statusDescription + "');", true);

                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('در حال حاضر بخش مشاوره غیرفعال است.');", true);


                if ((PersianDate.Today == endDate) && (Time.Now > endTime))
                    if (!string.IsNullOrEmpty(statusDescription))
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + statusDescription + "');", true);

                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('در حال حاضر بخش مشاوره غیرفعال است.');", true);

            }
            if (status == ConsultationStatus.Enable)
            {
                if (!string.IsNullOrEmpty(statusDescription))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('"+statusDescription+"');", true);

          
//                    throw new MessageException(statusDescription);
                }
            }
        }
        catch (MessageException ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);

            return;
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('در حال حاضر ثبت مشاوره جدید امکانپذیر نیست.');", true);

            return;
        }

        RadWindow1.Visible = true;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string codeText = rTxtConsultantId.Text.Trim();
            int code = Convert.ToInt32(codeText);
            Consultation consultation = Consultation.FromCode(code);
            if (consultation == null)
                throw new Exception();
            Response.Redirect("~/Consult/pageConsultation.aspx?ConsultationCode=" + consultation.Code, true);
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('مشاهده این مشاوره امکان پذیر نیست.');", true);
    return;
        }
    }

    private void Validate(RadTextBox textBox)
    {
        if (string.IsNullOrEmpty(textBox.Text.Trim()))
            throw new Exception("");
    }

    protected void radBtnOk_Click(object sender, EventArgs e)
    {
        try
        {
            Validate(RadTxtFirstname);
            Validate(RadTxtLastname);
            Validate(RadTxtEmail);
            Validate(rTxtPhone);
            Validate(RadTxtTitle);
            Validate(RadTxtQuestion);
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('همه موارد اجباری هستند و باید تکمیل شوند');", true);
     return;
        }

        Consultation consultation = new Consultation { InternetRegisteration = true };
        consultation.Category = mCategory;
        consultation.SubmitIP = WebsiteHandler.GetIP();
        consultation.SubmitUserAgent = WebsiteHandler.GetUserAgent();
        if (WebsiteHandler.CurrentStudent != null)
            consultation.Student = WebsiteHandler.CurrentStudent;

        BindToObject(consultation);
        consultation.Save();
        consultation.Code = Consultation.GenerateCode(consultation.Id);
        consultation.Save();
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('درخواست شما با شماره پیگیری "+ consultation.Code + " ثبت گردید. پس از گذشت 72 ساعت می توانید از قسمت پیگیری، پاسخ خود را مشاهده نمایید');", true);

        //rMessageBox1.ShowInformation("درخواست شما با شماره پیگیری {0} ثبت گردید. پس از گذشت 72 ساعت می توانید از قسمت پیگیری، پاسخ خود را مشاهده نمایید.", false, consultation.Code + "");
    }

    //protected void rMessageBox1_DialogResult(object sender, DialogResultEventArgs e)
    //{

    //}
}
