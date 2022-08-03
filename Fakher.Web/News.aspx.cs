using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.Website;

public partial class News : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request["id"];
        if (!string.IsNullOrEmpty(id))
        {
            pnlAllNews.Visible = false;
            pnlNewsDetail.Visible = true;

            WebNews webNews = WebNews.FromId(Convert.ToInt32(id));
            webNews.IncrementHits();
            webNews.Save();

            lblTitle.Text = webNews.Title;
            Title = webNews.Title;
            lblDate.Text = "تاریخ انتشار: " + webNews.Date.ToShortDateString();
            lblHits.Text = "تعداد بازدید: " + webNews.Hits;
            Literal2.Text = WebsiteManager.PrepareHtml(webNews.TextHtml);

            tblAbstract.Visible = !string.IsNullOrEmpty(webNews.AbstractHtml);
            lblAbstract.Text = WebsiteManager.PrepareHtml(webNews.AbstractHtml);
        }
        else
        {
            pnlAllNews.Visible = true;
            pnlNewsDetail.Visible = false;

            IList<WebNews> news = WebNews.GetWebNews();
            Repeater1.DataSource = news;
            Repeater1.DataBind();
        }
    }
}
