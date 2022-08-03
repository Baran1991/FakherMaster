using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;
using MenuItem = Fakher.Core.Website.MenuItem;

public partial class SectionMasterPage : MasterPage
{
    private WebsiteSection mWebsiteSection;

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request["id"];
        if (string.IsNullOrEmpty(id))
        {
            Response.Redirect("~/Default.aspx", true);
            return;
        }

        mWebsiteSection = WebsiteSection.FromId(Convert.ToInt32(id));
        FillMenu();
    }

    private void FillMenu()
    {
        IList<MenuItem> menuItems = MenuItem.GetTopMenuItems(mWebsiteSection);

        RadPanelBar1.Items.Clear();
        RadPanelItem menuItem = new RadPanelItem("منـــوی دپـارتمان");
        menuItem.Expanded = true;
        menuItem.PreventCollapse = true;
        foreach (MenuItem item in menuItems)
            AddNode(menuItem.Items, item);
        RadPanelBar1.Items.Add(menuItem);

        if (mWebsiteSection.ShowCalendar)
        {
            RadPanelItem menuItem2 = new RadPanelItem("منـــوی آمــوزش");
            menuItem2.Expanded = true;
            menuItem2.PreventCollapse = true;
            AddNode(menuItem2.Items, "تقویم آمــوزشـی", string.Format("pageCalendar.aspx?id={0}", mWebsiteSection.Id));
            RadPanelBar1.Items.Add(menuItem2);
        }
    }

    private void AddNode(RadPanelItemCollection collection, MenuItem item)
    {
        // Request.CurrentExecutionFilePath
//        string url = string.Format("Default.aspx?id={0}&&pageid={1}", mWebsiteSection.Id, webpage.Id);

        string url = WebsiteManager.GetNavigateUrl(item);;
        RadPanelItem panelItem = AddNode(collection, item.Name, url);
        foreach (MenuItem child in item.Childs)
            AddNode(panelItem.Items, child);
    }

    private RadPanelItem AddNode(RadPanelItemCollection collection, string title, string url)
    {
        RadPanelItem radMenu = new RadPanelItem(title);
        //radMenu.Style.Add("font-family", "Tahoma");
        radMenu.NavigateUrl = url;
        radMenu.Expanded = true;
        radMenu.CssClass = "CustomStyle";
        collection.Add(radMenu);

        return radMenu;
    }
}
