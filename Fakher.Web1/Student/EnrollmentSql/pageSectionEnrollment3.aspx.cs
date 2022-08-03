using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

public partial class Student_Enrollment_pageSectionEnrollment3 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentStudent == null
            || WebsiteHandler.CurrentRegister == null
                || WebsiteHandler.CurrentStudentConfiguration == null
                    || WebsiteHandler.CurrentEnrollmentLicense == null)
        {
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, "Entities is Null (Redirect)");
            Response.Redirect("~/Student/Enrollment/pageSectionEnrollment1.aspx", true);
            return;
        }

        if (WebsiteHandler.CurrentRegister.EnrollmentConfirmed)
        {
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, "Confirmed Register in Load(Redirect)");
            Response.Redirect("~/Student/Enrollment/pageSectionEnrollment1.aspx", true);
            return;
        }


        if (WebsiteHandler.CurrentPayTransaction == null)
        {
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, "PayTransaction is Null (Redirect)");
            Response.Redirect("~/Student/Enrollment/pageSectionEnrollment1.aspx", true);
            return;
        }

        try
        {
            WebsiteHandler.CurrentPayTransaction.PreTransfer();
            WebsiteHandler.CurrentPayTransaction.Save();

            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, string.Format("Payment #{0} PreTransfer", WebsiteHandler.CurrentPayTransaction.Id));

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
                rSimpleMessageBox1.ShowInformation(payException.ResultCode.ToDescription());
            }
            else
            {
                rSimpleMessageBox1.ShowInformation(ex.Message);
            }
            return;
        }
    }
}
