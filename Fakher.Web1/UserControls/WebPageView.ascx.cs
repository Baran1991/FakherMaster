using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;
using rComponents;

public partial class UserControls_WebPageView : UserControl
{
    private Webpage mWebPage;

    protected void Page_Load(object sender, EventArgs e)
    {
        //RadWindow1.Visible = false;
    }

    public void DataBind(Webpage webPage)
    {
        mWebPage = webPage;

        lblTitle.Text = webPage.Title;
        Literal1.Text = WebsiteManager.PrepareHtml(webPage.Html);

        AttachmentView1.DataBind(webPage);

//        RadGridAttachments.DataSource = webPage.Attachments;
//        RadGridAttachments.DataBind();
//        pnlAttachments.Visible = webPage.Attachments.Count > 0;

        pnlPreEnrollment.Visible = webPage.PreEnrollmentListBinding;

        RadCmbProvince.SelectedIndex = 16;
    }

    protected void lnkBtnPreEnrollment_Click(object sender, EventArgs e)
    {
        rTxtFirstName.Text = "";
        rTxtLastName.Text = "";
        rTxtEmail.Text = "";
        rTxtPhone.Text = "";

        //RadWindow1.Visible = true;
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";
        }
    }

    protected void rBtnPreEnrollment_Click(object sender, EventArgs e)
    {
        if (mWebPage == null || mWebPage.PreEnrollmentList == null)
            return;

        string firstName = rTxtFirstName.Text.Trim();
        string lastName = rTxtLastName.Text.Trim();
        string province = RadCmbProvince.Text.Trim();
        string city = RadTxtCity.Text.Trim();
        string email = rTxtEmail.Text.Trim();
        string phone = rTxtPhone.Text.Trim();

        if (string.IsNullOrEmpty(firstName))
        {
            
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('نام را به صورت کامل و معتبر وارد کنید');", true);
            //rMessageBox1.ShowInformation("نام را به صورت کامل و معتبر وارد کنید.");
            //RadWindow1.Visible = true;
            return;
        }
        if (string.IsNullOrEmpty(lastName))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('نام خانوادگی را به صورت کامل و معتبر وارد کنید');", true);

            //rMessageBox1.ShowInformation("نام خانوادگی را به صورت کامل و معتبر وارد کنید.");
            //RadWindow1.Visible = true;
            return;
        }
//        if (string.IsNullOrEmpty(email))
//            return;
        if (string.IsNullOrEmpty(phone))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('شماره تلفن را به صورت کامل و معتبر وارد کنید');", true);

            //rMessageBox1.ShowInformation("شماره تلفن را به صورت کامل و معتبر وارد کنید.");
            //RadWindow1.Visible = true;
            return;
        }

        PreEnrollment enrollment = new PreEnrollment { PreEnrollmentList = mWebPage.PreEnrollmentList, InternetRegisteration = true};
        enrollment.FirstName = Services.SecureHtml(firstName);
        enrollment.LastName = Services.SecureHtml(lastName);
        enrollment.Province = Services.SecureHtml(province);
        enrollment.City = Services.SecureHtml(city);
        enrollment.Email = Services.SecureHtml(email);
        enrollment.Phone = Services.SecureHtml(phone);

        enrollment.Save();

        //        try
        //        {
        //            SmsPostMaster.Send(enrollment.GetPreEnrollmentSmsText(), Services.NormalizeMobileString(enrollment.Phone));
        //        }
        //        catch (Exception ex)
        //        {
        //
        //        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('پیش ثبت نام شما، با موفقیت ثبت گردید. از سوی موسسه با شما تماس گرفته خواهد شد');", true);

        //rMessageBox1.ShowInformation("پیش ثبت نام شما، با موفقیت ثبت گردید. <br /> از سوی موسسه با شما تماس گرفته خواهد شد.");
    }
}
