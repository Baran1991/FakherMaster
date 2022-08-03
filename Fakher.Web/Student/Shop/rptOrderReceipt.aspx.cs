using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.Website;
using Fakher.Reports;
using Telerik.Reporting.Processing;

public partial class Student_Shop_rptOrderReceipt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentStudent == null 
            || WebsiteHandler.CurrentRegister == null
                || WebsiteHandler.CurrentOrder == null)
        {
            Response.Redirect("Default.aspx", true);
            return;
        }

        if (!IsPostBack)
        {
            rptOrderReceipt rpt = new rptOrderReceipt();
            rpt.DataSource = WebsiteHandler.CurrentOrder;

            ReportViewer1.DataBind(rpt);
        }
    }
}
