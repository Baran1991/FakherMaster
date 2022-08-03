using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;
using rComponents;
public partial class Student_pagePreEnroll : Page
{
    private int mSelectedId
    {
        get { return Convert.ToInt32(ViewState["SelectedId"]); }
        set { ViewState["SelectedId"] = value; }
    }

    private int mSelectedExamFormId
    {
        get { return Convert.ToInt32(ViewState["SelectedExamFormId"]); }
        set { ViewState["SelectedExamFormId"] = value; }
    }

    private int mSelectedFormationId
    {
        get { return Convert.ToInt32(ViewState["SelectedFormationId"]); }
        set { ViewState["SelectedFormationId"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Fill();
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        //bool setting = WebsiteManager.GetAppSetting<bool>(WebsiteHandler.pre);
        //if (!setting)
        //{
        //    rMessageBox1.ShowInformation("امکان ثبت نام اینترنتی آزمون های مصاحبه توسط مدیر سیستم غیرفعال است.", true);
        //    return;
        //}
    }

    protected void rMessageBox1_DialogResult(object sender, EventArgs e)
    {
        Response.Redirect("~/Student/Default.aspx", true);
    }

    private void Fill()
    {
        IList<PreEnrollmentList> enrollableList = WebsiteHandler.CurrentRegister.GetEnrollableList( PersianDate.Today, DateTime.Now.Hour, DateTime.Now.Minute);
        RadGrid1.DataSource = enrollableList;
        RadGrid1.DataBind();
        
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";

            RadButton button = e.Item.FindControl("btnSelect") as RadButton;
            button.CommandArgument = HttpServerUtility.UrlTokenEncode(Encoding.UTF8.GetBytes((e.Item.DataItem as PreEnrollmentList).Id + ""));
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        RadButton button = sender as RadButton;
        string idText = Encoding.UTF8.GetString(HttpServerUtility.UrlTokenDecode(button.CommandArgument));
        PreEnrollmentList pre = PreEnrollmentList.FromId(Convert.ToInt32(idText));
        if(pre.PreEnrollments.Where(m=>m.Student== WebsiteHandler.CurrentPerson).Count()>0)
        {
            rMessageBox1.ShowInformation("شما قبلا در همین رویداد ثبت نام شده اید.", true);
            return;
        }
        if (pre.ClassCa < PreEnrollment.GetPreEnrollmentsCount(pre))
        {
            rMessageBox1.ShowInformation("ظرفیت تکمیل است.", true);
            return;
        }
        try
        {
            var person = new PreEnrollment();
            person.FirstName = WebsiteHandler.CurrentPerson.FarsiFirstName;
            person.LastName = WebsiteHandler.CurrentPerson.FarsiLastName;
            
            person.PreEnrollmentList = pre;
            person.LastUpdateDate = PersianDate.Today;
            person.InternetRegisteration = true;
            person.City = WebsiteHandler.CurrentPerson.ContactInfo.City;
            person.Province = WebsiteHandler.CurrentPerson.ContactInfo.Province;
            person.Email = WebsiteHandler.CurrentPerson.ContactInfo.Email;
            person.Phone = WebsiteHandler.CurrentPerson.ContactInfo.Mobile;
            person.Student = WebsiteHandler.CurrentPerson;
            person.Save();
            rMessageBox1.ShowInformation("ثبت نام شما با موفقیت انجام شد.");
        }
        catch (Exception ex)
        {
            rMessageBox1.ShowInformation(ex.Message);
            return;
        }
    }

    protected void radBtnOk_Click(object sender, EventArgs e)
    {
        if(mSelectedId == 0)
        {
            rMessageBox1.ShowInformation("خطا");
            return;
        }
       
       
    }

    protected void radBtnCancel_Click(object sender, EventArgs e)
    {
         
    }

   
}
