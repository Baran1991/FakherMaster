using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.Website;

public partial class Student_OnlineExam_KeepSessionAlive : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // check to see if it is valid to keep session alive or not, if not do nothing
//        if (WebsiteHandler.CurrentExamParticipate == null)
//        {
//            return;
//        }
//        if (WebsiteHandler.CurrentOnlineExamParticipate == null)
//        {
//            return;
//        }

        WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "Defibrillate Raw(" + WebsiteHandler.CurrentOnlineExamParticipate.RawAnswers + ")");

        Response.AddHeader("Refresh", "600");
//        Response.AddHeader("Refresh", "30");
    }
}
