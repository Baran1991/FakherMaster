using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

public partial class Student_OnlineExam_ExamMasterPage : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebsiteStatus status = WebsiteManager.GetAppSetting<int, WebsiteStatus>(WebsiteHandler.WebsiteStatus);

        if (status != WebsiteStatus.OnlineExam)
        {
            Response.Redirect("~", true);
            return;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        string persianDateText = PersianDate.Today.GetDayOfWeek().ToDescription() + "، " + PersianDate.Today.Day + " " +
                                 PersianDate.Today.MonthName + " " + PersianDate.Today.Year;
        DateTime now = DateTime.Now;
        string gregDateText = now.ToString("ddd, d MMM yyyy", CultureInfo.CreateSpecificCulture("en-US"));
        lblDate.Text = persianDateText + " (" + gregDateText + ")";

        bool setting = WebsiteManager.GetAppSetting<bool>(WebsiteHandler.WebgozarSettingKey);
        pnlWebgozar.Visible = setting;

        Page.ClientScript.RegisterStartupScript(GetType(), "setTimeLabel",
                                        string.Format("lblTime = document.getElementById('{0}');", lblTime.ClientID), true);
        Page.ClientScript.RegisterStartupScript(GetType(), "setServerVariables",
                                                string.Format("serverTimeHour={0}; serverTimeMinute={1}; serverTimeSecond={2};",
                                                    now.Hour, now.Minute, now.Second), true);
        Page.ClientScript.RegisterStartupScript(GetType(), "updateServerTime",
                                                "setInterval(updateServerTime, 1000);", true);

        lblTime.Text = now.ToString("HH:mm:ss");


        if (WebsiteHandler.CurrentStudent != null)
        {
            string studentName = WebsiteHandler.CurrentStudent.FarsiFullname;
            StudentName.Text = studentName;

            string name;
            if (WebsiteHandler.CurrentRegister != null)
                name = studentName + " (" + WebsiteHandler.CurrentRegister.Code + ")";
            else
                name = studentName + " (" + WebsiteHandler.CurrentStudent.GetCurrentCode() + ")";

//            lblName.Text = name;
//            pnlStudent.Visible = true;
            pnlUserBar.Visible = true;
//            HyperLink1.Visible = HyperLink3.Visible = true;
        }
        else
        {
//            pnlStudent.Visible = false;
            pnlUserBar.Visible = false;
//            HyperLink1.Visible = HyperLink3.Visible = false;
        }
    }

    protected void lnkBtnSignout_OnClick(object sender, EventArgs e)
    {
        WebsiteHandler.SignOut();
        Session.Clear();
        Response.Redirect("~/Student/Enrollment/Default.aspx", true);
    }
}
