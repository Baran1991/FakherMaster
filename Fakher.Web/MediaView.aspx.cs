using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.Website;
using Fakher.Core.DomainModel;

public partial class MediaView : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString.Count == 0)
        {
            Response.Redirect("~", true);
            return;
        }
    }
}
