using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.Website;
using Fakher.Core.DomainModel;
using rComponents;

public partial class pageMellatHandler : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentRegister == null 
            || WebsiteHandler.CurrentPayTransaction == null)
        {
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, "Entities is Null in Fill(Redirect)");
            Response.Redirect("~/Student/Enrollment/Default.aspx", true);
            return;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;

            if(WebsiteHandler.CurrentRegister.Participates.Count == 0)
            {
                WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentRegister.Student, string.Format("No Participate !!!"));
                throw new Exception("درس/سطح های شما از سیستم حذف شده اند. مبلغ موردنظر به صورت خودکار به حساب شما برمی گردد.");
            }

//            Label1.Text = Request["RefId"] + "," + Request["ResCode"] + "," + Request["saleOrderId"] + "," + Request["SaleReferenceId"] + ".";

            string refId = Request["RefId"];
            string resCode = Request["ResCode"];
            long orderId = Convert.ToInt64(Request["saleOrderId"]);
            long saleReferenceId = 0;
            if (!String.IsNullOrEmpty(Request["SaleReferenceId"]))
            {
                saleReferenceId = Convert.ToInt64(Request["SaleReferenceId"]);
                lblSaleReferenceId.Text = "شمـاره پیگیری بانک: " + saleReferenceId;
                lblSaleReferenceId.Visible = true;
            }

            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentRegister.Student, string.Format("Backed From Payment Register #{0}", WebsiteHandler.CurrentRegister.Id));
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentRegister.Student,
                                   string.Format("Payment #{0} (refId={1}, resCode={2}, orderId={3}, referenceId={4})",
                                                 WebsiteHandler.CurrentPayTransaction.Id
                                                 , refId, resCode, orderId, saleReferenceId));


            lblOrderId.Text = "شماره پرداخت: " + WebsiteHandler.CurrentPayTransaction.Id;

            if (WebsiteHandler.CurrentPayTransaction.Status != PayRequestStatus.Completed)
            {
                WebsiteHandler.CurrentPayTransaction.Prepare(refId, resCode, orderId, saleReferenceId);
                WebsiteHandler.CurrentPayTransaction.Save();
                WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentRegister.Student, string.Format("Payment #{0} Prepared", WebsiteHandler.CurrentPayTransaction.Id));

                if (WebsiteHandler.CurrentPayTransaction.Status != PayRequestStatus.Verified)
                {
                    WebsiteHandler.CurrentPayTransaction.PostTransfer();
                    WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentRegister.Student, string.Format("Payment #{0} PostTransfered", WebsiteHandler.CurrentPayTransaction.Id));
                }
                if (WebsiteHandler.CurrentPayTransaction.Status != PayRequestStatus.Completed)
                {
                    WebsiteHandler.CurrentPayTransaction.Complete();
                    WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentRegister.Student, string.Format("Payment #{0} Completed", WebsiteHandler.CurrentPayTransaction.Id));
                }
                WebsiteHandler.CurrentPayTransaction.Save();
            }

            WebsiteHandler.CurrentRegister.ConfirmEnrollment();
            WebsiteHandler.CurrentRegister.UpdateParticipateEnrollments();
            WebsiteHandler.CurrentRegister.Save();
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentRegister.Student, string.Format("Confirmed Register #{0}", WebsiteHandler.CurrentRegister.Id));


            rowOk.Visible = true;
            HyperLinkDefaultPage.Visible = false;
            HyperLinkContinue.Visible = true;
            
            if (!string.IsNullOrEmpty(WebsiteHandler.ReturnPageUrl))
            {
                string url = WebsiteHandler.ReturnPageUrl;
                WebsiteHandler.ReturnPageUrl = null;
                HyperLinkContinue.NavigateUrl = url;
                return;
            }


            WebsiteHandler.CurrentPayTransaction = null;
        }
        catch(PayException ex)
        {
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, "PayException #" + ex.RawCode);
            WebsiteManager.SaveException(this, ex);
            string text = ex.ResultCode.ToDescription() + "<br /><br />" + "دقت کنید؛ تراکنش شما لغو گردیده است، بنابراین اگر از سوی بانک مبلغی کسر شده باشد، به صورت خودکار به حساب شما باز خواهد گشت.";
            rSimpleMessageBox1.ShowInformation(text);
            return;
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, "Exception");
            WebsiteManager.SaveException(this, ex);
            rSimpleMessageBox1.ShowInformation(ex.Message);
            return;
        }
    }
}
