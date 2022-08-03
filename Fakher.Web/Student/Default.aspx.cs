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

public partial class Student_Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentStudent != null && !IsPostBack)
        {
            StudentTopPanel1.DataBind();
            if (WebsiteHandler.CurrentRegister == null)
            {
                StudentTopPanel1.UpdateRegister();
            }
            else
            {
                WebsiteHandler.CurrentRegister.RefreshEntity();
                //sooren
                if (!String.IsNullOrEmpty(WebsiteHandler.CurrentRegister.Announcement))
                {
                    lblAnnouncement.Text = WebsiteHandler.CurrentRegister.Announcement;
                    pnlAnnouncement.Visible = true;
                }
                else
                {
                    pnlAnnouncement.Visible = false;
                }
            }
            StudentTopPanel1.FillPanel();
            FillGrid();
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {

    }

    private void FillGrid()
    {
        if (WebsiteHandler.CurrentRegister != null)
        {
            RadGrid1.DataSource = WebsiteHandler.CurrentRegister.Participates.OrderBy(x => x.SectionItem.Lesson.Name);
            RadGrid1.DataBind();

            RadGrid2.DataSource = WebsiteHandler.CurrentRegister.GetExamParticipates().OrderBy(x => x.ExamForm.Exam.Type);
            RadGrid2.DataBind();
        }
    }

    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(RadGrid1.SelectedValue);
        foreach (Participate participate in WebsiteHandler.CurrentRegister.Participates)
        {
            if (participate.Id == id)
            {
                WebsiteHandler.CurrentParticipate = participate;
                Response.Redirect("~/Student/pageParticipate.aspx", true);
                return;
            }
        }
    }
    
    protected void StudentTopPanel1_OnRegisterChanged(object sender, EventArgs e)
    {
        FillGrid();
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";
        }

        e.Item.Font.Name = "Tahoma";
    }

    protected void RadGrid2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(RadGrid2.SelectedValue);
        foreach (ExamParticipate participate in WebsiteHandler.CurrentRegister.GetExamParticipates())
        {
            if (participate.Id == id)
            {
                WebsiteHandler.CurrentExamParticipate = participate;
                Response.Redirect("~/Student/pageExamParticipate.aspx", true);
                return;
            }
        }
    }

    protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";
        }

        e.Item.Font.Name = "Tahoma";
    }
}
