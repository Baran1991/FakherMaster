using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;

public partial class Student_MessageBox_Default : Page
{
    protected  void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid();
        }
    }

    private  void FillGrid()
    {
        IList<Message> receivedMessages = WebsiteHandler.CurrentPerson.GetReceivedMessages();
        RadGrid1.DataSource = receivedMessages;
        RadGrid1.DataBind();
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";

            Message message = (e.Item as GridDataItem).DataItem as Message;
            MessageReceiver receiver = message.GetReceiver(WebsiteHandler.CurrentPerson).FirstOrDefault();
            if (receiver != null && receiver.Status == MessageStatus.UnRead)
                (e.Item as GridDataItem).Font.Bold = true;
        }
    }

    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(RadGrid1.SelectedValue);
        Message message = Message.FromId(id);
        string idCode = HttpServerUtility.UrlTokenEncode(Encoding.UTF8.GetBytes(message.Id + ""));
        Response.Redirect("~/Student/MessageBox/pageMessage.aspx?" + idCode, true);
    }

    protected void btnNewMessage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Student/MessageBox/pageCompose.aspx", true);
    }
}
