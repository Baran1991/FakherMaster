using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.Website;

public partial class Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request["pageid"];
        if (string.IsNullOrEmpty(id))
            return;

        Webpage webpage = Webpage.FromId(Convert.ToInt32(id));
        webpage.IncrementHits();
        webpage.Save();

        Title = webpage.Title;
        WebPageView1.DataBind(webpage);
    }
}
