using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;

public partial class Career_Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            FillGrid();
    }

    private void FillGrid()
    {
        RadGrid1.DataSource = Career.GetActiveCareers();
        RadGrid1.DataBind();
    }

    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(RadGrid1.SelectedValue);
        Career career = Career.FromId(id);
        Response.Redirect(string.Format("~/Career/Career.aspx?id={0}", career.Id), true);
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";
        }
        //if (e.Item is GridDataItem)
        //{
        //    HyperLink lnk = e.Item.FindControl("lblIDLink") as HyperLink;
        //    lnk.NavigateUrl = string.Format("~/Career/Career.aspx?id={0}", e.Item.va);
        //}
    }
}
