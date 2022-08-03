using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;
using Telerik.Web.UI;

public partial class UserControls_AttachmentView : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";
        }
    }

    private void Fill(IList<WebMedia> collection)
    {
        RadGridAttachments.DataSource = collection;
        RadGridAttachments.DataBind();

        pnlAttachments.Visible = collection.Count > 0;
    }

    public void DataBind(Message message)
    {
        Fill(message.Attachments);
    }

    public void DataBind(Webpage webPage)
    {
        Fill(webPage.Attachments);
    }

    public void DataBind(Section section)
    {
        List<WebMedia> list = WebMedia.FromSection(section).ToList();
        List<WebMedia> listNew = new List<WebMedia>();
        foreach (var item in list)
        {
            if(item.CanViewAttachment())
            {
                listNew.Add(item);
            }
            
        }
        Fill(listNew);
    }

    public void DataBind(Exam exam)
    {
        List<WebMedia> list = WebMedia.FromExam(exam).ToList();
        List<WebMedia> listNew = new List<WebMedia>();
        foreach (var item in list)
        {
            if (item.CanViewAttachment())
            {
                listNew.Add(item);
            }

        }
        Fill(listNew);
    }
}
