using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.Website;

public partial class Signout : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebsiteHandler.SignOut();
        Response.Redirect("~", true);
    }
}
