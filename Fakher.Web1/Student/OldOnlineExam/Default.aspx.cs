using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

public partial class Student_OnlineExam_Default : Page
{
    private OnlineExamParticipate examParticipate;
    private Exam exam;
    private ExamForm examForm;
    private OnlineExamHolding examHolding;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentExamParticipate == null)
        {
            Response.Redirect("~/Student/Default.aspx", true);
            return;
        }

        examParticipate = WebsiteHandler.CurrentOnlineExamParticipate;
        examForm = examParticipate.ExamForm;
        exam = examForm.Exam;
        examHolding = (exam.ExamHolding as OnlineExamHolding);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;

        try
        {
            Fill();
            if (!examParticipate.CanParticipation(PersianDate.Today, now.Hour, now.Minute))
                throw new Exception(
                    string.Format("شروع رسمی این آزمون در تاریخ {0} ساعت {1} و پایان آن در تاریخ {2} ساعت {3} می باشد.",
                                  examHolding.StartDate.ToShortDateString(), examHolding.StartTime,
                                  examHolding.EndDate.ToShortDateString(), examHolding.EndTime));
//            if (examParticipate.IsFinished)
            if (examParticipate.Confirmed)
            {
                throw new Exception("شما قبلا در این آزمون شرکت کرده اید، شرکت مجدد در این آزمون امکان پذیر نیست.");
            }
        }
        catch (Exception ex)
        {
            rSimpleMessageBox1.ShowInformation(ex.Message);
            return;
        }

        Title = "آزمون اینترنتی " + exam.Name;
    }

    private void Fill()
    {
        lblExamName.Text = exam.Name;
        lblExamHolder.Text = exam.Period.Department.Name + " - "
                             + exam.Lesson.Major.Name;

        string startDateText = examHolding.StartDate == null ? "ندارد" : examHolding.StartDate.ToShortDateString();
        string endDateText = examHolding.EndDate == null ? "ندارد" : examHolding.EndDate.ToShortDateString();
        string endTimeText = examHolding.EndDate == null ? "ندارد" : examHolding.EndTime;

        lblFirstname.Text = examParticipate.Register.Student.FarsiFirstName;
        lblLastname.Text = examParticipate.Register.Student.FarsiLastName;
        lblFatherName.Text = examParticipate.Register.Student.FarsiFatherName;
        lblCode.Text = examParticipate.Code + "";
        lblStartDate.Text = startDateText;
        lblStartTime.Text = examHolding.StartTime;
        lblEndDate.Text = endDateText;
        lblEndTime.Text = endTimeText;

        lblQuestionCount.Text = exam.QuestionCount + "";
        lblQuestionPageCount.Text = examForm.Pages.Count + "";
        lblNegativePoint.Text = exam.NegativeScore == 0 ? "ندارد" : "هر " + exam.NegativeScore + " سئوال ";
        lblDuration.Text = examHolding.HasDuration ? examHolding.Duration + " دقیقه " : "نامحدود";

        btnStartExam.Enabled = !examParticipate.Confirmed;
    }

    protected void btnStartExam_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;

        try
        {
            if (!examParticipate.CanParticipation(PersianDate.Today, now.Hour, now.Minute))
            {
                string endText = examHolding.HasEnd ? string.Format(" و پایان آن در تاریخ {0} ساعت {1}", examHolding.EndDate.ToShortDateString(), examHolding.EndTime) : "";
                throw new Exception(
                    string.Format("شروع رسمی این آزمون در تاریخ {0} ساعت {1}{2} می باشد.",
                                  examHolding.StartDate.ToShortDateString(), examHolding.StartTime,
                                  endText));
            }
//            if (examParticipate.IsFinished)
            if (examParticipate.Confirmed)
                throw new Exception("شما قبلا در این آزمون شرکت کرده اید، شرکت مجدد در این آزمون امکان پذیر نیست.");
        }
        catch (Exception ex)
        {
            rSimpleMessageBox1.ShowInformation(ex.Message);
            return;
        }

        WebsiteHandler.IsInOnlineExamPhase = true;

        if (!WebsiteHandler.CurrentOnlineExamParticipate.IsStarted)
        {
//            WebsiteHandler.OnlineExamParticipateTestAnswers = new Dictionary<int, int>();
//            WebsiteHandler.OnlineExamParticipateEssayAnswers = new Dictionary<int, string>();
            WebsiteHandler.CurrentOnlineExamParticipate.StartExam(WebsiteHandler.GetIP(), WebsiteHandler.GetUserAgent());
            WebsiteHandler.CurrentOnlineExamParticipate.Save();
        }
//        if (WebsiteHandler.OnlineExamParticipateTestAnswers == null)
//            WebsiteHandler.OnlineExamParticipateTestAnswers = new Dictionary<int, int>();
//        if (WebsiteHandler.OnlineExamParticipateEssayAnswers == null)
//            WebsiteHandler.OnlineExamParticipateEssayAnswers = new Dictionary<int, string>();

        WebsiteManager.SaveExamLog(this, WebsiteHandler.CurrentOnlineExamParticipate, "Started Exam");
        Response.Redirect("~/Student/OnlineExam/pageExamPage.aspx?pageNum=1", true);
    }
}