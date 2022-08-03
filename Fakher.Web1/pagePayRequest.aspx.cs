using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.Website;
using Fakher.Core.DomainModel;
using rComponents;

public partial class pagePayRequest : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentPayTransaction == null)
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

            if (WebsiteHandler.IsInEnrollmentPhase)
            {
                WebsiteHandler.CurrentRegister.RefreshEntity();
                if (WebsiteHandler.CurrentRegister.Participates.Count == 0)
                    throw new Exception("درس/سطوح انتخابی شما از سیستم حذف گردیده اند. درس/سطح ها را مجددا انتخاب کنید.");

                WebsiteManager.IsInEnrollmentPhase();
            }

            if(WebsiteHandler.IsInExamEnrollmentPhase)
            {
                if (!WebsiteHandler.CurrentRegister.GetExamParticipates().Any())
                    throw new Exception("آزمون های انتخابی شما از سیستم حذف گردیده اند. آزمون ها را مجددا انتخاب کنید.");

                WebsiteManager.IsInExamEnrollmentPhase();
            }

            WebsiteHandler.CurrentPayTransaction.PreTransfer();
            WebsiteHandler.CurrentPayTransaction.Save();

            WebsiteManager.SaveLog(this, WebsiteHandler.CurrentRegister.Student, "Go For Pay");

            ClientScript.RegisterStartupScript(typeof(Page), "ClientScript",
                                               string.Format(
                                                   "<script language='javascript' type='text/javascript'> postRefId('{0}');</script> ",
                                                   WebsiteHandler.CurrentPayTransaction.ReferenceId), false);
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            if (ex is PayException)
            {
                PayException payException = ex as PayException;
                rMessageBox1.ShowInformation(payException.ResultCode.ToDescription(), true);
            }
            else
            {
                rMessageBox1.ShowInformation(ex.Message, true);
            }
            return;
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
