using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

public partial class Instructor_MessageBox_pageMessage : Page
{
    private Message mMessage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString.Count == 0)
        {
            Response.Redirect("~/Instructor/Default.aspx", true);
            return;
        }

        string input = Request.QueryString[0];
        string idText = WebsiteHandler.Decrypt(WebsiteHandler.UrlDecode(input));
        int id = Convert.ToInt32(idText);
        mMessage = Message.FromId(id);

        IQueryable<MessageReceiver> personReceivers = mMessage.GetReceiver(WebsiteHandler.CurrentPerson);
        foreach (MessageReceiver receiver in personReceivers)
        {
            if (receiver.Status == MessageStatus.Read)
                continue;

            receiver.ReadDate = PersianDate.Today.ToShortDateString();
            receiver.ReadTime = Time.Now.ToShortTimeString();
            receiver.Status = MessageStatus.Read;
            receiver.Save();
        }

        Fill();
        Title = mMessage.Subject;
    }

    private void Fill()
    {
        lblSender.Text = mMessage.Sender + "";
        lblReciever.Text = mMessage.GetReceiverText(WebsiteHandler.CurrentPerson);
        lblSubject.Text = mMessage.Subject;
        TextBox1.Text = mMessage.Body;

        if(mMessage.HasAttachment)
        {
            AttachmentView1.DataBind(mMessage);
        }
    }

    protected void btnReply_Click(object sender, EventArgs e)
    {
        Response.Redirect("pageCompose.aspx?" + WebsiteHandler.UrlEncode(WebsiteHandler.Encrypt(mMessage.Id + "")));
    }
}
