using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Fakher.Reports;

public partial class Student_rptExamCard : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentStudent == null
            || WebsiteHandler.CurrentRegister == null
            || WebsiteHandler.CurrentExamParticipate == null)
        {
            Response.Redirect("Default.aspx", true);
            return;
        }

        if (!IsPostBack)
        {
            //return;

            Language language = WebsiteHandler.CurrentRegister.Period.Department.ReportLanguage;

            WebsiteHandler.CurrentExamParticipate.PrepareExamCardForDelivery();
            WebsiteHandler.CurrentExamParticipate.Save();

            if (language == Language.English)
            {
                rptEnExamCard rpt = new rptEnExamCard();
                rpt.DataSource = new[] { WebsiteHandler.CurrentExamParticipate };
                ReportViewer1.DataBind(rpt);
            }
            if (language == Language.Farsi)
            {
                rptFaExamCard rpt = new rptFaExamCard();
                rpt.DataSource = new object[] { WebsiteHandler.CurrentExamParticipate };
                ReportViewer1.DataBind(rpt);
            }

            WebsiteManager.SaveLog(this, WebsiteHandler.CurrentStudent, "دریافت کارت ورود به آزمون " + WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.Name);
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        //rMessageBox1.ShowInformation("کارت ورود به جلسه فعلا فقط به صورت حضوری قابل تحویل است.", true);
        //return;
    }

    protected void rMessageBox1_DialogResult(object sender, EventArgs e)
    {
        Response.Redirect("~/Student/", true);
    }
}
