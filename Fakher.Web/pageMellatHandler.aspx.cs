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
        if (WebsiteHandler.CurrentRegister == null || WebsiteHandler.CurrentPayTransaction == null)
        {
            Response.Redirect("~/Default.aspx", true);
            return;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;

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

            lblOrderId.Text = "شماره پرداخت: " + WebsiteHandler.CurrentPayTransaction.Id;

            if (WebsiteHandler.IsInEnrollmentPhase)
            {
                WebsiteHandler.CurrentRegister.RefreshEntity();
                if (WebsiteHandler.CurrentRegister.Participates.Count == 0)
                    throw new Exception("درس/سطوح انتخابی شما از سیستم حذف گردیده اند. درس/سطح ها را مجددا انتخاب کنید.پرداخت شما نیز لغو گردید تا مبلغ موردنظر به حساب شما بازگردد.");

                WebsiteManager.IsInEnrollmentPhase();
            }

            if (WebsiteHandler.IsInExamEnrollmentPhase)
            {
                if (!WebsiteHandler.CurrentRegister.GetExamParticipates().Any())
                    throw new Exception("آزمون های انتخابی شما از سیستم حذف گردیده اند. آزمون ها را مجددا انتخاب کنید.");

                WebsiteManager.IsInExamEnrollmentPhase();
            }

            WebsiteManager.SaveLog(this, WebsiteHandler.CurrentRegister.Student, string.Format("Backed From Payment Register #{0}", WebsiteHandler.CurrentRegister.Id));

            WebsiteHandler.CurrentPayTransaction.Prepare(refId, resCode, orderId, saleReferenceId);
            WebsiteHandler.CurrentPayTransaction.Save();

            WebsiteHandler.CurrentPayTransaction.PostTransfer();
            WebsiteHandler.CurrentPayTransaction.Complete();
            WebsiteHandler.CurrentPayTransaction.Save();

            if (WebsiteHandler.IsInEnrollmentPhase)
            {
                WebsiteManager.SaveLog(this, WebsiteHandler.CurrentRegister.Student, string.Format("Confirmed Register #{0}", WebsiteHandler.CurrentRegister.Id));

                WebsiteHandler.CurrentRegister.ConfirmEnrollment();
                WebsiteHandler.CurrentRegister.UpdateParticipateEnrollments();
                WebsiteHandler.CurrentRegister.Save();
                WebsiteHandler.IsInEnrollmentPhase = false;
            }

            if (WebsiteHandler.IsInExamEnrollmentPhase)
            {
                WebsiteManager.SaveLog(this, WebsiteHandler.CurrentRegister.Student, string.Format("Confirmed Register #{0} For Exams", WebsiteHandler.CurrentRegister.Id));

                foreach (ExamParticipate participate in WebsiteHandler.CurrentRegister.GetExamParticipates())
                    if (!participate.EnrollmentConfirmed && participate.InternetRegisteration)
                        participate.ConfirmEnrollment();

                if (!WebsiteHandler.CurrentRegister.EnrollmentConfirmed)
                    WebsiteHandler.CurrentRegister.ConfirmEnrollment();

                List<Exam> exams = WebsiteHandler.CurrentRegister.GetRegisteredExams().ToList();
                WebsiteHandler.CurrentRegister.UpdateExamEnrollments(exams);
                
                WebsiteHandler.CurrentStudent.Save();
                WebsiteHandler.CurrentRegister.Save();
                WebsiteHandler.IsInExamEnrollmentPhase = false;
            }

            if(WebsiteHandler.CurrentOrder != null)
            {
                WebsiteHandler.CurrentOrder.Pay();
                WebsiteHandler.CurrentOrder.Save();
                WebsiteHandler.CurrentOrder.Complete();
                WebsiteHandler.CurrentOrder.Save();
            }

            rowOk.Visible = true;
            HyperLinkDefaultPage.Visible = false;
            HyperLinkContinue.Visible = true;
            
            if (!string.IsNullOrEmpty(WebsiteHandler.ReturnPageUrl))
            {
                string url = WebsiteHandler.ReturnPageUrl;
                WebsiteHandler.ReturnPageUrl = null;
                HyperLinkContinue.NavigateUrl = url;
//                Response.Redirect(url);
                return;
            }
        }
        catch(PayException ex)
        {
            WebsiteManager.SaveLog(this, WebsiteHandler.CurrentPerson, "PayException #" + ex.RawCode);
            WebsiteManager.SaveException(this, ex);

//            try
//            {
//                WebsiteHandler.CurrentPayTransaction.Reverse();
//                WebsiteManager.SaveLog(this, WebsiteHandler.CurrentPerson, string.Format("Transaction #{0} Reversed", WebsiteHandler.CurrentPayTransaction.Id));
//            }
//            catch (Exception ex2)
//            {
//                WebsiteManager.SaveLog(this, WebsiteHandler.CurrentPerson, string.Format("Transaction #{0} Could not Reverse !!!", WebsiteHandler.CurrentPayTransaction.Id));
//                WebsiteManager.SaveException(this, ex2);
//            }

            string text = ex.ResultCode.ToDescription() + "<br /><br />" + "دقت کنید؛ تراکنش شما لغو گردیده است، بنابراین اگر از سوی بانک مبلغی کسر شده باشد، به صورت خودکار به حساب شما باز خواهد گشت.";
            rSimpleMessageBox1.ShowInformation(text);
            return;
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveLog(this, WebsiteHandler.CurrentPerson, "Exception");
            WebsiteManager.SaveException(this, ex);
            rSimpleMessageBox1.ShowInformation(ex.Message);
            return;
        }
        finally
        {
            WebsiteHandler.CurrentPayTransaction.Save();
            WebsiteHandler.CurrentPayTransaction = null;
        }
    }

    protected void rMessageBox1_DialogResult(object sender, DialogResultEventArgs e)
    {
        string page;
        if (WebsiteHandler.CurrentStudent != null)
            page = "~/Student/Default.aspx";
        else
            page = "~/Default.aspx";

        Response.Redirect(page, true);
        return;
    }
}
