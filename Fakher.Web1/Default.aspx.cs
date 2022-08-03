using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using Fakher.Core.DomainModel.Poll;
using Fakher.Core.Website;
using Telerik.Web.UI;
using Fakher.Core.DomainModel;
using Image = System.Drawing.Image;
using System.Configuration;
using System.Web.Configuration;

public partial class _Default : Page
{
//    protected void Page_PreInit(object sender, EventArgs e)
//    {
//        MasterPageFile = "~/SimpleMasterPage.master";
//    }

    protected void Page_Load(object sender, EventArgs e)
    {
        String isMainSite = WebConfigurationManager.AppSettings["mainSite"];
        if(isMainSite=="false")
        {
            Response.Redirect("DefaultBranch.aspx");
        }
        if (!IsPostBack)
        {
            FillWidgets();
            FillInstituteNews();
            FillEducationalNews();
            FillArticles();
            FillBooks();
            FillPoll();
            FillSlideshow();
        }
    }

    private void FillWidgets()
    {
        IList<WebsiteWidget> widgets = WebsiteWidget.GetActiveWidgets();
        Repeater3.DataSource = widgets;
        Repeater3.DataBind();
    }

    private void FillArticles()
    {
        List<Webpage> articles = Webpage.GetWebpages(WebpageType.Article).Take(7).ToList();
        Repeater2.DataSource = articles;
        Repeater2.DataBind();
    }

    private void FillInstituteNews()
    {
        IList<WebNews> news = WebNews.GetLastNews(WebNewsCategory.InstituteNews, 19);
        Repeater1.DataSource = news;
        Repeater1.DataBind();
    }

    private void FillEducationalNews()
    {
        IList<WebNews> news = WebNews.GetLastNews(WebNewsCategory.EducationalNews, 10);
        Repeater4.DataSource = news;
        Repeater4.DataBind();
    }

    private void FillBooks()
    {
        int count = WebsiteManager.GetAppSetting<int>(WebsiteHandler.BookShowCount);
        if (count <= 0)
            count = 8;

        List<EducationalTool> educationalTools = EducationalTool.GetWebsiteShowingTools().Take(count).ToList();

        ListViewBooks.DataSource = educationalTools;
        ListViewBooks.DataBind();

        

//        UserControls_BookControl[] controls = new UserControls_BookControl[] { BookControl1, BookControl2, BookControl3, BookControl4
//        , BookControl5, BookControl6, BookControl7, BookControl8};
//        for (int i = 0; i < controls.Length; i++)
//        {
//            if (i < educationalTools.Count)
//            {
//                controls[i].DataBind(educationalTools[i]);
//            }
//        }

        pnlBooks.Visible = educationalTools.Count > 0;
    }

    private void FillPoll()
    {
        bool showPoll = WebsiteManager.GetAppSetting<bool>(WebsiteHandler.ShowFrontpagePollKey);
        if(showPoll)
        {
            int id = WebsiteManager.GetAppSetting<int>(WebsiteHandler.FrontpagePollIdKey);
            if (id != 0)
            {
                Poll poll = Poll.FromId(id);
                PollControl1.DataBind(poll);
            }
        }
    }

    private void FillSlideshow()
    {
        string images = WebsiteManager.GetAppSetting<string>(WebsiteHandler.SlideshowImages);
        string[] strings = images.Split(new[] {WebsiteHandler.SlideshowSeparator}, StringSplitOptions.RemoveEmptyEntries);
        //RepeaterSlider.DataSource = strings;
        //RepeaterSlider.DataBind();
        RadRotator1.DataSource = strings;
        RadRotator1.DataBind();
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        WebNews news = e.Item.DataItem as WebNews;
        if(news.IsRed)
        {
            Label lblNewsDate = e.Item.FindControl("lblNewsDate") as Label;
            Label lblNewsTitle = e.Item.FindControl("lblNewsTitle") as Label;
            //ColorTranslator.FromHtml("#690D36")
            lblNewsTitle.ForeColor = lblNewsDate.ForeColor = Color.Red;
//            lblNewsTitle.Font.Bold = lblNewsDate.Font.Bold = true;
        }
    }

    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Webpage page = e.Item.DataItem as Webpage;
        if (page.IsRed)
        {
            Label lblNewsDate = e.Item.FindControl("Label2") as Label;
            lblNewsDate.ForeColor = Color.Red;
        }
    }

    protected void ListViewBooks_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if(e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;

            UserControls_BookControl control = e.Item.FindControl("BookControl1") as UserControls_BookControl;

            control.DataBind((EducationalTool) dataItem.DataItem);
        }
    }

    protected void SliderRotator_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.DataItem != null)
        {
            string s = e.Item.DataItem as string;
            byte[] bytes = Convert.FromBase64String(s);
            
            //RadBinaryImage image = e.Item.FindControl("radBinaryImage1") as RadBinaryImage;
           System.Web.UI.WebControls.Image image= e.Item.FindControl("Image1") as System.Web.UI.WebControls.Image;
            image.ImageUrl = "data:image/png;base64," + bytes;
            //image.DataValue = bytes;
            image.DataBind();
        }
    }
    protected void RadRotator1_ItemDataBound(object sender, RadRotatorEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            string s = e.Item.DataItem as string;
            byte[] bytes = Convert.FromBase64String(s);
            RadBinaryImage image = e.Item.FindControl("radBinaryImage1") as RadBinaryImage;
            image.DataValue = bytes;
            image.DataBind();
        }
    }
    protected void btnNewsletterSubmit_Click(object sender, EventArgs e)
    {
        string mobile = RadTxtNewsletterPhone.Text.Trim();
        if (!mobile.StartsWith("0"))
        {
            //rMessageBox1.ShowInformation("شماره تلفن همراه معتبر نیست");
            return;
        }
        if (mobile.Length != 11)
        {
            //rMessageBox1.ShowInformation("شماره تلفن همراه معتبر نیست");
            return;
        }
        foreach (char ch in mobile)
        {
            if(!Char.IsNumber(ch))
            {
                //rMessageBox1.ShowInformation("شماره تلفن همراه معتبر نیست");
                return;
            }
        }

        bool any = NewsletterSubscriber.GetNewsletterSubscriber(mobile).Any();
        if(any)
        {
            //rMessageBox1.ShowInformation("شماره تلفن همراه تکراری است");
            return;
        }

        NewsletterSubscriber subscriber = new NewsletterSubscriber();
        subscriber.Mobile = mobile;
        subscriber.Save();
        pnlNewsletter.Visible = false;
        pnlNewsletterThanks.Visible = true;
    }
}
