using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.Website;
using Fakher.Core.DomainModel;
using Telerik.Web.UI;

public partial class Components_MajorSections : UserControl
{
    private EducationalPeriod mPeriod;
    private Major mMajor;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Databind(EducationalPeriod period, Major major)
    {
        mPeriod = period;
        mMajor = major;

        Label1.Text = major.Name;
        List<Section> sections = Section.GetSections(period, major);

        RadGrid1.DataSource = sections.OrderBy(x => x.ItemsText);
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
