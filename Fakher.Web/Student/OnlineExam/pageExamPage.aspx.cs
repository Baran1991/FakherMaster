using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

public partial class Student_OnlineExam_pageExamPage : Page
{
    private OnlineExamParticipate examParticipate;
    private Exam exam;
    private OnlineExamHolding examHolding;
    private ExamForm examForm;
    private int pageNum;
    private Dictionary<int, int> mTestAnswers;
    private Dictionary<int, string> mEssayAnswers;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentOnlineExamParticipate == null)
        {
            WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "Redirect(OEP is null)");
            Response.Redirect("~/Student/OnlineExam/Default.aspx", true);
            return;
        }

        if (!WebsiteHandler.IsInOnlineExamPhase)
        {
            WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "Redirect(is not in OE Phase)");
            Response.Redirect("~/Student/OnlineExam/Default.aspx", true);
            return;
        }

        if (WebsiteHandler.CurrentOnlineExamParticipate.Confirmed)
        {
            WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "Redirect(confirmed)");
            Response.Redirect("~/Student/OnlineExam/Default.aspx", true);
            return;
        }

        if (!WebsiteHandler.CurrentOnlineExamParticipate.IsStarted)
        {
            WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "Redirect(is not started)");
            Response.Redirect("~/Student/OnlineExam/Default.aspx", true);
            return;
        }

        examParticipate = WebsiteHandler.CurrentOnlineExamParticipate;
        examForm = WebsiteHandler.CurrentOnlineExamParticipate.ExamForm;
        exam = examForm.Exam;
        examHolding = (exam.ExamHolding as OnlineExamHolding);
        mTestAnswers = examParticipate.GetTestAnswersDictionary();
        mEssayAnswers = examParticipate.GetEssayAnswersDictionary();

        pageNum = 1;
        if (!string.IsNullOrEmpty(Request["pageNum"]))
            pageNum = Convert.ToInt32(Request["pageNum"]);

        WebsiteManager.SaveExamLog(this, examParticipate, string.Format("Initialized Page #{0} Raw({1})", pageNum, examParticipate.RawAnswers));

        if (pageNum < 1)
        {
            GotoPage(1);
            return;
        }
        if (pageNum > examForm.Pages.Count)
        {
            GotoPage(examForm.Pages.Count);
            return;
        }

        ExamPage examPage = examForm.Pages[pageNum - 1];
        ExamPage1.DataBind(examPage);
    }

//    protected void Page_Load(object sender, EventArgs e)
//    {
//    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        // First Job: Save Answered Choices
        ExamPage1.SetTestAnswers(mTestAnswers);
        ExamPage1.SetEssayAnswers(mEssayAnswers);

        DateTime now = DateTime.Now;

        btnPrevPage.Enabled = pageNum > 1;
        if (pageNum == examForm.Pages.Count)
            btnNextPage.Text = "پایان آزمــون";

        string examText = exam.Name + " (صفحه " + pageNum + " از " + examForm.Pages.Count + ")";
        lblTopExamText.Text = examText;
        Title = examText;

        if (examHolding.HasDuration)
        {
            if (!WebsiteHandler.CurrentOnlineExamParticipate.HasRemainingDuration())
            {
                WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "Redirect(has not remaining duration)");
                GotoFinishPage();
                return;
            }

            TimeSpan remainingDuration = examParticipate.RemainingDuration;
            lblDuration.Text = "زمان باقیمانده: " + remainingDuration.ToShortTimeString();
            lblDuration.Visible = examHolding.HasDuration;

            Page.ClientScript.RegisterStartupScript(GetType(), "setDurationLabel", string.Format("lblDuration = document.getElementById('{0}');", lblDuration.ClientID), true);
            Page.ClientScript.RegisterStartupScript(GetType(), "setRemainingVariables", string.Format("remainingTimeHour={0}; remainingTimeMinute={1}; remainingTimeSecond={2};", examParticipate.RemainingDuration.Hours, examParticipate.RemainingDuration.Minutes, examParticipate.RemainingDuration.Seconds), true);
            Page.ClientScript.RegisterStartupScript(GetType(), "updateRemainingTime", "setInterval(updateRemainingTime, 1000);", true);
        }

        if (!examParticipate.CanParticipation(PersianDate.Today, now.Hour, now.Minute))
        {
            WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, string.Format("Redirect(can not participate in {0}:{1})", now.Hour, now.Minute));
            GotoFinishPage();
            return;
        }
    }

    private void GotoPage(int page)
    {
        WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "Go to page #" + page);
        Response.Redirect("~/Student/OnlineExam/pageExamPage.aspx?pageNum=" + page, true);
    }

    private void SaveAnswers()
    {
        Dictionary<int, int> testAnswers = ExamPage1.GetTestAnswers();
        foreach (KeyValuePair<int, int> answer in testAnswers)
        {
            if (mTestAnswers.ContainsKey(answer.Key))
                mTestAnswers[answer.Key] = answer.Value;
            else
                mTestAnswers.Add(answer.Key, answer.Value);
        }


        Dictionary<int, string> essayAnswers = ExamPage1.GetEssayAnswers();
        foreach (KeyValuePair<int, string> answer in essayAnswers)
        {
            if (mEssayAnswers.ContainsKey(answer.Key))
                mEssayAnswers[answer.Key] = answer.Value;
            else
                mEssayAnswers.Add(answer.Key, answer.Value);
        }

        examParticipate.SetAnswers(mTestAnswers, mEssayAnswers);
        examParticipate.Save();

        string testAnswersText = ExamPage1.GetTestAnswersLogText();
        WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, string.Format("Saved Page #{0}({1}) Raw({2})", pageNum, testAnswersText, examParticipate.RawAnswers));
    }

    protected void btnPrevPage_Click(object sender, EventArgs e)
    {
        SaveAnswers();
        GotoPage(pageNum - 1);
    }

    protected void btnNextPage_Click(object sender, EventArgs e)
    {
        SaveAnswers();
        int nextPage = pageNum + 1;
        if (nextPage <= examForm.Pages.Count)
        {
            GotoPage(nextPage);
        }
        else
        {
            GotoFinishPage();
        }
    }

    private void GotoFinishPage()
    {
        WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "go to finish page");

        WebsiteHandler.CurrentOnlineExamParticipate.EndExam();
        WebsiteHandler.CurrentOnlineExamParticipate.Save();
        Response.Redirect("~/Student/OnlineExam/pageExamFinish.aspx", true);
    }
}
