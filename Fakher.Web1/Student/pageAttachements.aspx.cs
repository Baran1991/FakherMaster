using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Fakher.Reports;
using Telerik.Reporting.Processing;
using rComponents;
using Telerik.Web.UI;
using System.Web.UI.WebControls.WebParts;

public partial class Student_pageAttachements : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (WebsiteHandler.CurrentStudent == null 
        //    || WebsiteHandler.CurrentRegister == null
        //        || WebsiteHandler.CurrentParticipate == null)
        //{
        //    Response.Redirect("Default.aspx", true);
        //    return;
        //}

        //if(!IsPostBack)
        //{
        //}

        RadGrid1.DataSource = WebsiteHandler.CurrentRegister.Participates.OrderBy(x => x.SectionItem.Lesson.Name);
        RadGrid1.DataBind();
    }



    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool setting = WebsiteManager.GetAppSetting<bool>(WebsiteHandler.SectionAttachmentKey);
        if (setting)
        {
            int id = Convert.ToInt32(RadGrid1.SelectedValue);
            var participate = WebsiteHandler.CurrentRegister.Participates.FirstOrDefault(m => m.Id == id);
            if(participate!=null)
            AttachmentView1.DataBind(participate.SectionItem.Section);
        }
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
