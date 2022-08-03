using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.Website;

public partial class Articles : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Webpage> articles = Webpage.GetWebpages(WebpageType.Article).ToList();
        Repeater1.DataSource = articles;
        Repeater1.DataBind();
    }
}
