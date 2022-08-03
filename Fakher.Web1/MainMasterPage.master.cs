using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;
using rComponents;
using MenuItem = Fakher.Core.Website.MenuItem;
using System.Web.Configuration;

public partial class MainMasterPage : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //        int websiteStatus = WebsiteManager.GetAppSetting<int>(WebsiteHandler.WebsiteStatus);
        WebsiteStatus status = WebsiteManager.GetAppSetting<int, WebsiteStatus>(WebsiteHandler.WebsiteStatus);
        if (status == WebsiteStatus.SectionEnrollment)
        {
            Response.Redirect("~/Student/Enrollment/", true);
            return;
        }
        if (status == WebsiteStatus.OnlineExam)
        {
            Response.Redirect("~/Student/OnlineExam/", true);
            return;
        }


        WebsiteHandler.MasterPageMenu = false;
        string persianDateText = PersianDate.Today.GetDayOfWeek().ToDescription() + "، " + PersianDate.Today.Day + " " +
                                 PersianDate.Today.MonthName + " " + PersianDate.Today.Year;
        DateTime now = DateTime.Now;
        string gregDateText = now.ToString("ddd, d MMM yyyy", CultureInfo.CreateSpecificCulture("en-US"));
        lblDate.Text = persianDateText + " (" + gregDateText + ")";

        bool setting = WebsiteManager.GetAppSetting<bool>(WebsiteHandler.WebgozarSettingKey);
        pnlWebgozar.Visible = setting;

        Page.ClientScript.RegisterStartupScript(GetType(), "setTimeLabel",
                                                string.Format("lblTime = document.getElementById('{0}');", lblTime.ClientID), true);
        Page.ClientScript.RegisterStartupScript(GetType(), "setServerVariables",
                                        string.Format("serverTimeHour={0}; serverTimeMinute={1}; serverTimeSecond={2};",
                                            now.Hour, now.Minute, now.Second), true);
        Page.ClientScript.RegisterStartupScript(GetType(), "updateServerTime",
                                                "setInterval(updateServerTime, 1000);", true);
        lblTime.Text = now.ToString("HH:mm:ss");
        String isMainSite = WebConfigurationManager.AppSettings["mainSite"];
        if (isMainSite == "true")
        {
            FillTopMenuNodes();
        }
        else
        {
            branchMenu.Visible = true;
            menuBar.Visible = false;
            String branchName = WebConfigurationManager.AppSettings["branchName"];
            branchTitle.InnerText = branchName;
            branchTitle.Visible = true;
        }

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        IList<WebNews> tickerNews = WebNews.GetLastTickerNews(10);
        for (int i = 0; i < tickerNews.Count; i++)
        {
            WebNews news = tickerNews[i];
            Page.ClientScript.RegisterStartupScript(GetType(), "TickerContents" + i, string.Format(" tickerContents[{0}] = '{1}'; ", i, news.Title), true);
            Page.ClientScript.RegisterStartupScript(GetType(), "TickerLinks" + i, string.Format(" tickerLinks[{0}] = '{1}'; ", i, WebsiteManager.AppUrl +"/News.aspx?Id=" + news.Id), true);
        }

        if(tickerNews.Count > 0)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "typeTicker", " setInterval(typeTicker, 35); ", true);
        }

//        WebsiteManager.SaveLog(Page, WebsiteHandler.CurrentPerson, Request.RawUrl);
    }

    protected void Page_Unload(object sender, EventArgs e)
    {

    }

    private void FillTopMenuNodes()
    {
        IList<MenuItem> menuItems = MenuItem.GetTopMenuItems();
        RadMenu1.Items.Clear();
       
        //var b1 = new MenuItem() { Name = "ارم",Url="http://eram.fakher.ac.ir", Type = MenuItemType.Url };
        //var b2 = new MenuItem() { Name = "فرهنگشهر", Url = "http://farhangshahr.fakher.ac.ir", Type = MenuItemType.Url };
        //var b3 = new MenuItem() { Name = "مدرس", Url = "http://modares.fakher.ac.ir", Type = MenuItemType.Url };
        //var b4 = new MenuItem() { Name = "مرودشت", Url = "http://marvdasht.fakher.ac.ir", Type = MenuItemType.Url };
        //var bList = new List<MenuItem>();
        //bList.Add(b1);
        //bList.Add(b2);
        //bList.Add(b3);
        //bList.Add(b4);
        //menuItems.Add(new MenuItem() { Name = "لیست شعب", Childs = bList });
        foreach (MenuItem menuItem in menuItems)
        {
            AddNode(RadMenu1.Items, menuItem);
        }
    }
//    private System.Web.UI.WebControls.MenuItem AddNode(MenuItemCollection collection, MenuItem item)
//    {
//        //MenuItem radMenu = new MenuItem();
//        var mItem = new System.Web.UI.WebControls.MenuItem(item.Name);
//mItem.NavigateUrl=WebsiteManager.GetNavigateUrl(item);
      
//        collection.Add(mItem);
//        foreach (MenuItem child in item.OrderedChilds)
//        {
//            var node = AddNode(mItem.ChildItems, child);
//        }
//        return mItem;
//    }

    private RadMenuItem AddNode(RadMenuItemCollection collection, MenuItem item)
    {
        RadMenuItem radMenu = new RadMenuItem(item.Name);
        radMenu.Style.Add("font-family", "Tahoma");
        radMenu.NavigateUrl = WebsiteManager.GetNavigateUrl(item);
        radMenu.CssClass = "UseHand";
        collection.Add(radMenu);
        foreach (MenuItem child in item.OrderedChilds)
        {
            RadMenuItem node = AddNode(radMenu.Items, child);
        }
        return radMenu;
    }

}
