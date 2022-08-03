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

public partial class Student_pageRequest : Page
{
    private int mCurrentRequestId
    {
        get
        {
            if (ViewState["CurrentRequest"] != null)
                return (int)ViewState["CurrentRequest"];
            return 0;
        }
        set { ViewState["CurrentRequest"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RadWindow1.Visible = false;

        if (WebsiteHandler.CurrentStudent == null)
        {
            Response.Redirect("Default.aspx", true);
            return;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        FillGrid();
    }

    private void FillGrid()
    {
        RadGrid1.DataSource = WebsiteHandler.CurrentStudent.Requests.OrderByDescending(x => x.Date);
        RadGrid1.DataBind();
    }

    private void BindToForm(Request request, bool isReadonly, bool showResult)
    {
        mCurrentRequestId = request.Id;

        RadTxtTitle.Text = request.Title;
        RadTxtText.Text = request.Text;
        lblResult.Text = Services.NormalizeWebString(request.Result);

        RadTxtTitle.ReadOnly = isReadonly;
        RadTxtText.ReadOnly = isReadonly;
        resultTable.Visible = showResult;
        if (showResult)
            RadWindow1.Height = new Unit("480px");
        else
            RadWindow1.Height = new Unit("420px");
    }

    private void BindToObject(Request request)
    {
        request.Title = Services.NormalizeFarsiString(Services.SecureHtml(RadTxtTitle.Text.Trim()));
        request.Text = Services.NormalizeFarsiString(Services.SecureHtml(RadTxtText.Text.Trim()));
    }

    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(RadGrid1.SelectedValue);
        Request request = Fakher.Core.DomainModel.Request.FromId(id);

        BindToForm(request, true, request.IsReplied);
        RadWindow1.Visible = true;
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";
        }
    }

    protected void btnNewRequest_Click(object sender, EventArgs e)
    {
        Request request = new Request { Student = WebsiteHandler.CurrentStudent };
        BindToForm(request, false, false);
        RadWindow1.Visible = true;
    }

    protected void radBtnOk_Click(object sender, EventArgs e)
    {
        if(mCurrentRequestId == 0)
        {
            Request request = new Request { Student = WebsiteHandler.CurrentStudent };
            request.InternetRegisteration = true;

            BindToObject(request);
            request.Save();

            FillGrid();
        }
    }
}
