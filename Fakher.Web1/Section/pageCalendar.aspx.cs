using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Fakher.Core.Website;
using Fakher.Core.DomainModel;

public partial class Department_pageCalendar : Page
{
    private WebsiteSection mWebsiteSection;

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request["id"];
        if (string.IsNullOrEmpty(id))
            return;

        mWebsiteSection = WebsiteSection.FromId(Convert.ToInt32(id));
        if(!IsPostBack)
            FillCmbPeriod();
    }


    protected void cmbPeriod_DataBound(object sender, EventArgs e)
    {
        FillPanel();
    }

    protected void cmbPeriod_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillPanel();
    }

    public void FillPanel()
    {
        EducationalPeriod period = EducationalPeriod.FromId(Convert.ToInt32(cmbPeriod.SelectedItem.Value));
        if (period == null)
            return;

        Table1.Rows.Clear();
        foreach (Major major in period.Department.Majors)
        {
            Components_MajorSections control = LoadControl("~/UserControls/MajorSections.ascx") as Components_MajorSections;
            control.Databind(period, major);
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Controls.Add(control);
            row.Cells.Add(cell);
            Table1.Rows.Add(row);
        }
    }

    private void FillCmbPeriod()
    {
        if (mWebsiteSection == null)
            return;

        cmbPeriod.DataTextField = "Name";
        cmbPeriod.DataValueField = "Id";
        cmbPeriod.DataSource = mWebsiteSection.Department.EducationalPeriods;
        cmbPeriod.DataBind();
    }
}
