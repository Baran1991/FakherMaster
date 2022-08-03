using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.Website;
using Fakher.Core.DomainModel;

public partial class Components_UserBar : UserControl
{
    public bool EducationalPanelLink { get; set; }
    public bool SignoutLink { get; set; }

    public Components_UserBar()
    {
        EducationalPanelLink = true;
        SignoutLink = true;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        UpdateUserBar();
    }

    private void UpdateUserBar()
    {
        if (WebsiteHandler.CurrentPerson != null)
        {
            Label2.Text = WebsiteHandler.CurrentPerson.FarsiFullname;
            
            lnkBtnEducationalPanel.Visible = Label4.Visible = EducationalPanelLink;
            lnkBtnSignout.Visible = Label1.Visible = Label3.Visible = SignoutLink;
            PlaceHolder1.Visible = true;
        }
        else
            PlaceHolder1.Visible = false;
    }

    protected void lnkBtnSignout_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Signout.aspx", true);
    }

    protected void lnkBtnEducationalPanel_OnClick(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentPerson.UnProxy() is Student)
            Response.Redirect("~/Student/Default.aspx", true);
        if (WebsiteHandler.CurrentPerson.UnProxy() is Teacher)
            Response.Redirect("~/Instructor/Default.aspx", true);
        Response.Redirect("~/Default.aspx", true);
    }
}
