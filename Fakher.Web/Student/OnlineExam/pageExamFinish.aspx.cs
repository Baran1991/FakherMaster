using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

public partial class Student_OnlineExam_pageExamFinish : Page
{
    private OnlineExamParticipate examParticipate;
    private Exam exam;
    private ExamForm examForm;
    private OnlineExamHolding examHolding;
    private Dictionary<int, int> mTestAnswers;
    private Dictionary<int, string> mEssayAnswers;

    protected void Page_Load(object sender, EventArgs e)
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

        if (!WebsiteHandler.CurrentOnlineExamParticipate.IsStarted)
        {
            WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "Redirect(is not started)");
            Response.Redirect("~/Student/OnlineExam/Default.aspx", true);
            return;
        }

        examParticipate = WebsiteHandler.CurrentOnlineExamParticipate;
        examForm = examParticipate.ExamForm;
        exam = examForm.Exam;
        examHolding = (exam.ExamHolding as OnlineExamHolding);
        mTestAnswers = examParticipate.GetTestAnswersDictionary();
        mEssayAnswers = examParticipate.GetEssayAnswersDictionary();

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;

        lblQuestionCount.Text = exam.QuestionCount + "";
        lblAnsweredCount.Text = GetAnsweredCount() + "";
        lblNotAnsweredCount.Text = GetNotAnsweredCount() + "";
        lblTotalDuration.Text = examParticipate.Duration + "";
        Title = "پایان آزمون اینترنتی " + exam.Name;

        if (examHolding.HasDuration && !examParticipate.HasRemainingDuration())
        {
            WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "has not remaining duration");
            rSimpleMessageBox1.ShowInformation("زمان آزمون به پایان رسیده است. اکنون فقط می توانید پاسخهای خود را ثبت نهایی کنید.");
            return;
        }
        if (!examParticipate.CanParticipation(PersianDate.Today, now.Hour, now.Minute))
        {
            WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "can not participate by now");
            rSimpleMessageBox1.ShowInformation(string.Format("پایان آزمون فرا رسیده است. پایان این آزمون در تاریخ {0} ساعت {1} بوده است. اکنون فقط می توانید پاسخهای خود را ثبت نهایی کنید.",
                                  examHolding.EndDate.ToShortDateString(), examHolding.EndTime));
            return;
        }
    }

    private int GetAnsweredCount()
    {
        int sum = 0;
        foreach (KeyValuePair<int, int> answer in mTestAnswers)
        {
            if (answer.Value != 0)
                sum++;
        }
        return sum;
    }

    private int GetNotAnsweredCount()
    {
        int sum = 0;
        foreach (KeyValuePair<int, int> answer in mTestAnswers)
        {
            if (answer.Value == 0)
                sum++;
        }
        return sum;
    }

    private void GotoPage(int page)
    {
        WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "Go to page #" + page);
        Response.Redirect("~/Student/OnlineExam/pageExamPage.aspx?pageNum=" + page, true);
    }

    protected void btnSubmitExam_Click(object sender, EventArgs e)
    {
        examParticipate.SetAnswers(mTestAnswers, mEssayAnswers);
        examParticipate.Confirm();
        examParticipate.Save();

        WebsiteHandler.IsInOnlineExamPhase = false;
//        WebsiteHandler.OnlineExamParticipateTestAnswers = null;
//        WebsiteHandler.OnlineExamParticipateEssayAnswers = null;
        WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "Confirmed Exam");

        string webReportCardText = "زمان مشاهده نتیجه این آزمون متعاقبا اعلام خواهد شد.";
        if (exam.CanViewWebReportCard)
            webReportCardText = string.Format("نتیجه این آزمون از ساعت {0} تاریخ {1} قابل مشاهده است. جهت مشاهده نتیجه آزمون، لطفا در زمانبندی تعیین شده مراجعه کنید.", exam.WebReportCardStartTime,
                                              exam.WebReportCardStartDate.ToShortDateString());
        WebsiteHandler.CallbackMessage = "پاسخهای شما با موفقیت ثبت گردید. <br />  " + webReportCardText;


        Response.Redirect("~/Student/pageExamParticipate.aspx", true);
    }

    protected void btnPrevPage_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;

        if (examHolding.HasDuration && !examParticipate.HasRemainingDuration())
        {
            rSimpleMessageBox1.ShowInformation("زمان آزمون به پایان رسیده است. اکنون فقط می توانید پاسخهای خود را ثبت نهایی کنید.");
            return;
        }
        if (!examParticipate.CanParticipation(PersianDate.Today, now.Hour, now.Minute))
        {
            rSimpleMessageBox1.ShowInformation(string.Format("پایان آزمون فرا رسیده است. پایان این آزمون در تاریخ {0} ساعت {1} بوده است. اکنون فقط می توانید پاسخهای خود را ثبت نهایی کنید.",
                                  examHolding.EndDate.ToShortDateString(), examHolding.EndTime));
            return;
        }

        WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "Backed To Exam");

        WebsiteHandler.CurrentOnlineExamParticipate.PrepareForStart();
        WebsiteHandler.CurrentOnlineExamParticipate.Save();
        GotoPage(examForm.Pages.Count);
    }
}
