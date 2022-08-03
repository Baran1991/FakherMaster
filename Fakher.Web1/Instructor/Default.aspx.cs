using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;

public partial class Instructor_Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cmbMajor.DataTextField = "Name";
            cmbMajor.DataValueField = "Id";
            cmbMajor.DataSource = WebsiteHandler.CurrentTeacher.GetTeachingMajors();
            cmbMajor.DataBind();
        }
    }

    public void FillGrid()
    {
        IList<Section> sections = WebsiteHandler.CurrentTeacher.GetTeachingSections(WebsiteHandler.CurrentEducationalPeriod, WebsiteHandler.CurrentMajor);
        RadGrid1.DataSource = sections;
        RadGrid1.DataBind();
    }

    private void FillCmbPeriod()
    {
        Major major = Major.FromId(Convert.ToInt32(cmbMajor.SelectedItem.Value));
        if (major == null)
            return;

        cmbPeriod.DataTextField = "Name";
        cmbPeriod.DataValueField = "Id";
        cmbPeriod.DataSource = WebsiteHandler.CurrentTeacher.GetTeachingPeriods(major).OrderByDescending(x => x.StartDate);
        cmbPeriod.DataBind();
    }

    public   void UpdateTopPanel()
    {
        Major major = Major.FromId(Convert.ToInt32(cmbMajor.SelectedItem.Value));
        EducationalPeriod period = EducationalPeriod.FromId(Convert.ToInt32(cmbPeriod.SelectedItem.Value));
        if (period == null || major == null)
            return;

        lblName.Text = WebsiteHandler.CurrentTeacher.FarsiFullname;
        lblStudentCode.Text = WebsiteHandler.CurrentTeacher.Code;

        WebsiteHandler.CurrentMajor = major;
        WebsiteHandler.CurrentEducationalPeriod = period;

        IQueryable<Message> receivedMessages = WebsiteHandler.CurrentTeacher.GetReceivedMessages(MessageStatus.UnRead);
        int count = receivedMessages.Count();

        if (count > 0)
        {
            lblUnread.Text = string.Format("شما ({0} پیام جدید) دارید.", count);
            pnlUnread.Visible = true;
        }
        else
        {
            pnlUnread.Visible = false;
        }
    }

    protected void cmbMajor_DataBound(object sender, EventArgs e)
    {
        FillCmbPeriod();
    }

    protected void cmbMajor_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillCmbPeriod();
    }

    protected void cmbPeriod_DataBound(object sender, EventArgs e)
    {
        UpdateTopPanel();
        FillGrid();
    }

    protected void cmbPeriod_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        UpdateTopPanel();
        FillGrid();
    }

    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(RadGrid1.SelectedValue);
        WebsiteHandler.CurrentSection = Section.FromId(id);
        Response.Redirect("~/Instructor/pageMarkEntry.aspx", true);
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
