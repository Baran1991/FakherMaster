using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;

public partial class Section_Default : Page
{
    private WebsiteSection mWebsiteSection;
    private Webpage mCurrentPage;

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request["id"];
        if (string.IsNullOrEmpty(id))
        {
            Response.Redirect("~/Default.aspx", true);
            return;
        }

        mWebsiteSection = WebsiteSection.FromId(Convert.ToInt32(id));
        FillContent();
    }

    private void FillContent()
    {
        if (mWebsiteSection.Pages.Count > 0)
            mCurrentPage = mWebsiteSection.Pages[0];

        if (mCurrentPage != null)
        {
            Title = mCurrentPage.Title;

            //            lblTitle.Text = mCurrentPage.Title;
            //            string html = WebsiteManager.PrepareHtml(mCurrentPage.Html);
            //            pnlCenter.Controls.Add(new Literal { Text = html });
            WebPageView1.DataBind(mCurrentPage);
        }
    }
}
