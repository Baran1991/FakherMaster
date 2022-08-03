using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Fakher.Reports;
using Telerik.Web.UI;

public partial class Student_StudentMasterPage : MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentStudent == null)
        {
            string[] freePages = new string[] { "pageSignin.aspx", "pageCredential.aspx" };
            bool found = false;
            foreach (string page in freePages)
            {
                if (Request.AppRelativeCurrentExecutionFilePath.EndsWith(page))
                    found = true;
            }
            if (!found)
                Response.Redirect("~/Student/pageSignin.aspx", true);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void RadPanelBar1_ItemClick(object sender, RadPanelBarEventArgs e)
    {
        if (e.Item.Value == "rptSignupReceipt")
        {
            Response.Redirect("~/Student/rptSignupReceipt.aspx", true);
            return;
            rptSignupReceipt rpt = new rptSignupReceipt();
            rpt.DataSource = new object[] {WebsiteHandler.CurrentRegister};
            //ReportViewer1.Report = rpt;
            
            RadWindow1.Visible = true;
        }

        if (e.Item.Value == "rptIdCard")
        {
            Response.Redirect("~/Student/rptIdCard.aspx", true);
            return;
            Language language = WebsiteHandler.CurrentRegister.Period.Department.ReportLanguage;
            if (language == Language.English)
            {
                rptEnIdCard rpt = new rptEnIdCard();
                rpt.DataSource = new object[] { WebsiteHandler.CurrentRegister };
                //ReportViewer1.Report = rpt;
            }
            if (language == Language.Farsi)
            {
                rptFaIdCard rpt = new rptFaIdCard();
                rpt.DataSource = new object[] { WebsiteHandler.CurrentRegister };
                //ReportViewer1.Report = rpt;
            }
            RadWindow1.Visible = true;
        }
    }
}
