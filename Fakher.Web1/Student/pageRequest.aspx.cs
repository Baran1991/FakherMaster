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
using Telerik.Web.UI.com.hisoftware.api2;

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
        RadTxtText.Text = "";
        lblPreResponse.Text = "";
        lblPreText.Text = "";
        lblResult.Text = "";
        mCurrentRequestId = request.Id;
        lblResDate1.Text = "";
        lblResDate2.Text = "";
        if (request.Id == 0)
        {
            RadTxtText.ReadOnly = false;
            prevText.Visible = false;
        }
        else
        {
            ListItem listItem = RadTxtTitle.Items.FindByValue(request.Title);

            if (listItem != null)
            {
                RadTxtTitle.ClearSelection();
                listItem.Selected = true;
            }

            if (!string.IsNullOrEmpty(request.Text))
            {
                prevText.Visible = true;
                lblPreText.Text = request.Text;

            }

            if (!string.IsNullOrEmpty(request.Result))
            {
                prevText.Visible = true;
                lblPreResponse.Text = request.Result;
                lblResDate1.Text = request.resDate1 + " " + request.resHour1 + ":" + request.resMinute1;
            }
            if (!string.IsNullOrEmpty(request.Text2))
            {
                RadTxtText.ReadOnly = true;
                RadTxtText.Text = request.Text2;
               
               
            }

            if (!string.IsNullOrEmpty(request.Result2))
            {
                lblResult.Text = request.Result2;
                prevText.Visible = true;
                lblResDate2.Text = request.resDate2 + " " + request.resHour2 + ":" + request.resMinute2;
            }
            RadWindow1.Height = new Unit("400px");
        }
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

        BindToForm(request, true, (request.Status==RequestStatus.Replied||request.Status==RequestStatus.InRevise)?true:false);
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
            Request request = new Request { Student = WebsiteHandler.CurrentStudent};
            request.InternetRegisteration = true;

            BindToObject(request);
            request.Save();

            FillGrid();
        }
        else
        {
            var request = Fakher.Core.DomainModel.Request.FromId(mCurrentRequestId);
            request.LastUpdateDate = PersianDate.Today;
            request.LastUpdateHour = DateTime.Now.Hour;
            request.LastUpdateMinute = DateTime.Now.Minute;
            request.Status = RequestStatus.Waiting;
            request.Text2 =RadTxtText.Text;
            //request.reqDate2 = PersianDate.Today;
            //request.reqHour2 = DateTime.Now.Hour;
            //request.reqMinute2 = DateTime.Now.Minute;
            request.Save();
            FillGrid();
        }
    }
}
