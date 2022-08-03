using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.Core.Website;
using Telerik.Reporting.Processing;

public partial class Student_pageSignupReceipt : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentStudent == null)
        {
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, "Entities is Null (Redirect)");
            Response.Redirect("~/Student/Enrollment/Default.aspx", true);
            return;
        }

        if (!IsPostBack)
        {
//            FillCombo();

            Register register;
            if (WebsiteHandler.CurrentRegister == null)
                register = WebsiteHandler.CurrentStudent.GetLastRegister();
            else
                register = WebsiteHandler.CurrentRegister;

            rptSignupReceipt rpt = new rptSignupReceipt();
            rpt.DataSource = new object[] { register };

            ReportViewer1.DataBind(rpt);
        }
    }

//    private void FillCombo()
//    {
//        IQueryable<Major> majors = WebsiteHandler.CurrentStudent.GetRegisteredMajors();
//        cmbMajor.DataSource = majors;
//        cmbMajor.DataBind();
//
//        IQueryable<EducationalPeriod> periods = WebsiteHandler.CurrentStudent.GetRegisteredPeriods();
//        cmbPeriod.DataSource = periods;
//        cmbPeriod.DataBind();
//    }
}
