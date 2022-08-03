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
using System.Web.Configuration;

public partial class _DefaultBranch : Page
{
//    protected void Page_PreInit(object sender, EventArgs e)
//    {
//        MasterPageFile = "~/SimpleMasterPage.master";
//    }

    protected void Page_Load(object sender, EventArgs e)
    {
        String isMainSite = WebConfigurationManager.AppSettings["mainSite"];
        if (isMainSite == "true")
        {
            Response.Redirect("Default.aspx");
        }
        String branchName = WebConfigurationManager.AppSettings["branchName"];
        title.InnerText = branchName;
    }

   
}
