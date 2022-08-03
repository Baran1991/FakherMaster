using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;

public partial class Instructor_InstructorMasterPage : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentTeacher == null)
        {
            string[] freePages = new string[] { "pageSignin.aspx" };
            bool found = false;
            foreach (string page in freePages)
                if (Request.AppRelativeCurrentExecutionFilePath.EndsWith(page))
                    found = true;
            if (!found)
                Response.Redirect("~/Instructor/pageSignin.aspx", true);
        }
    }

    protected  void Page_PreRender(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentTeacher != null)
        {
            IQueryable<Message> receivedMessages = WebsiteHandler.CurrentTeacher.GetReceivedMessages(MessageStatus.UnRead);
            int count = receivedMessages.Count();

            if (count > 0)
            {
                RadPanelBar1.Items[1].Items[0].Text = "صندوق پیام های دریافتی (" + count + ")";
            }
            else
            {
                RadPanelBar1.Items[1].Items[0].Text = "صندوق پیام های دریافتی";
            }
        }
    }

    protected void RadPanelBar1_ItemClick(object sender, RadPanelBarEventArgs e)
    {

    }
}
