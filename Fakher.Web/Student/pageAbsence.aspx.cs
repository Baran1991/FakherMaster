using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;
using rComponents;

public partial class Student_pageAbsence: Page
{
    private int mCurrentRequestId
    {
        get
        {
            if (ViewState["CurrentRequest"] != null)
                return (int)ViewState["CurrentRequest"];
            return 0;
        }
        set { ViewState["CurrentRequest"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (WebsiteHandler.CurrentStudent == null)
        {
            Response.Redirect("Default.aspx", true);
            return;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        FillGrid();
    }

    private void FillGrid()
    {
        RadGrid1.DataSource = WebsiteHandler.CurrentStudent.Absences.OrderByDescending(x => x.Date);
        RadGrid1.DataBind();
    }



 

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";
        }
    }

   
}
