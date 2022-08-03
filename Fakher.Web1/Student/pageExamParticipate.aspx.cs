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
using Fakher.Core.Website;
using Fakher.Reports;
using Telerik.Reporting.Processing;
using Telerik.Web.UI;
using rComponents;

public partial class Student_pageExamParticipate : Page
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
        }

        lblLesson.Text = WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.Name;

        cellExamReportCard.Visible = WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.Type == ExamType.OnlineExam ||
                                     WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.Type == ExamType.PaperBasedExam;
        cellExamResult.Visible = WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.Type == ExamType.OralExam;
//        cellOnlineExam.Visible = WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.Type == ExamType.OnlineExam;
        cellExamCard.Visible = WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.Type == ExamType.OralExam ||
                               WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.Type == ExamType.PaperBasedExam;
        tblOralExamResult.Visible = false;
        Title = "امــور آزمـــون - " + WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.Name;
        cellAttachments.Visible = WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.Attachments.Count > 0;
        cellPoll.Visible = WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.HasPoll;
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(WebsiteHandler.CallbackMessage))
        {
            string message = WebsiteHandler.CallbackMessage;
            WebsiteHandler.CallbackMessage = null;
            rMessageBox1.ShowInformation(message);
        }
    }

    private void ShowExamResult()
    {
        if (WebsiteHandler.CurrentExamParticipate.Status == ExamParticipateStatus.UnKnown)
        {
            rMessageBox1.ShowInformation("امکان مشاهده نتیجه این آزمون در حال حاضر وجود ندارد. لطفا بعدا مراجعه کنید");
            return;
        }
        if (!WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.CanViewReportCard(PersianDate.Today, DateTime.Now.Hour, DateTime.Now.Minute))
        {
            if (WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.CanViewWebReportCard)
                rMessageBox1.ShowInformation(
                    "نتیجه این آزمون از ساعت {0} تاریخ {1} قابل مشاهده است. لطفا در زمانبندی تعیین شده مراجعه کنید.",
                    false, WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.WebReportCardStartTime,
                    WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.WebReportCardStartDate.ToShortDateString());
            else
                rMessageBox1.ShowInformation("مشاهده نتیجه این آزمون هنوز ممکن نیست. لطفا بعدا مراجعه کنید.");
            return;
        }

        if(WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.Type == ExamType.OralExam)
        {
            OralExamParticipate oralExamParticipate = (WebsiteHandler.CurrentExamParticipate as OralExamParticipate);
            if (oralExamParticipate.OralMarks.Count > 0)
                lblOralExamMark.Text = "نـمـــره: " + oralExamParticipate.CalculateMark();
            else
                lblOralExamMark.Text = "";
            lblOralExamResult.Text = oralExamParticipate.Comment;
            tblOralExamResult.Visible = true;
        }
        else
        {
            ShowExamReportCard();
        }
    }

    private void ShowExamReportCard()
    {
        Language language = WebsiteHandler.CurrentRegister.Period.Department.ReportLanguage;
        //if (WebsiteHandler.CurrentExamParticipate.Status == ExamParticipateStatus.UnKnown)
        //{
        //    rMessageBox1.ShowInformation("امکان مشاهده نتیجه این آزمون در حال حاضر وجود ندارد. لطفا بعدا مراجعه کنید");
        //    return;
        //}
        //if (!WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.CanViewReportCard(PersianDate.Today, DateTime.Now.Hour, DateTime.Now.Minute))
        //{
        //    if (WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.CanViewWebReportCard)
        //        rMessageBox1.ShowInformation(
        //            "نتیجه این آزمون از ساعت {0} تاریخ {1} قابل مشاهده است. لطفا در زمانبندی تعیین شده مراجعه کنید.",
        //            false, WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.WebReportCardStartTime,
        //            WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.WebReportCardStartDate.ToShortDateString());
        //    else
        //        rMessageBox1.ShowInformation("مشاهده نتیجه این آزمون هنوز ممکن نیست. لطفا بعدا مراجعه کنید.");
        //    return;
        //}

        try
        {
            WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.CheckKey();
            WebsiteHandler.CurrentExamParticipate.ExamForm.Exam.UseParticipatesCache();

            if (language == Language.English)
            {
                rptEnExamReportCard rpt = new rptEnExamReportCard();
                rptEnExamReportCard.Period = WebsiteHandler.CurrentRegister.Period;
                rpt.DataSource = new[] { WebsiteHandler.CurrentExamParticipate };
//            ReportViewer1.Report = rpt;

                ReportProcessor reportProcessor = new ReportProcessor();
                RenderingResult result = reportProcessor.RenderReport("IMAGE", rpt, null);

                MemoryStream jpegMemory = new MemoryStream();
                MemoryStream tiffMemory = new MemoryStream(result.DocumentBytes);
                Bitmap bmp = new Bitmap(tiffMemory);
                bmp.Save(jpegMemory, ImageFormat.Png);
                byte[] bytes = jpegMemory.ToArray();
                jpegMemory.Dispose();
                tiffMemory.Dispose();
                bmp.Dispose();
                RadBinaryImage1.DataValue = bytes;
            }
            if (language == Language.Farsi)
            {
                rptFaExamReportCard rpt = new rptFaExamReportCard();
                rptFaExamReportCard.Period = WebsiteHandler.CurrentRegister.Period;
                rpt.DataSource = new[] { WebsiteHandler.CurrentExamParticipate };
//                            ReportViewer1.Report = rpt;

                ReportProcessor reportProcessor = new ReportProcessor();
                RenderingResult result = reportProcessor.RenderReport("IMAGE", rpt, null);
                MemoryStream jpegMemory = new MemoryStream();
                MemoryStream tiffMemory = new MemoryStream(result.DocumentBytes);
                Bitmap bmp = new Bitmap(tiffMemory);
                bmp.Save(jpegMemory, ImageFormat.Png);
                byte[] bytes = jpegMemory.ToArray();
                jpegMemory.Dispose();
                tiffMemory.Dispose();
                bmp.Dispose();
                RadBinaryImage1.DataValue = bytes;
            }

            RadBinaryImage1.Visible = true;
        }
        catch (Exception e)
        {
            rMessageBox1.ShowInformation("مشاهده نتیجه این آزمون متاسفانه ممکن نیست. لطفا مجددا مراجعه کنید.");
            return;
        }
    }

    protected void RadPanelBar1_ItemClick(object sender, RadPanelBarEventArgs e)
    {

    }

    private void GotoOnlineExam()
    {
        if (WebsiteHandler.CurrentOnlineExamParticipate == null)
        {
            rMessageBox1.ShowInformation("شرکت در این آزمون به صورت حضوری است. امکان آزمون آنلاین وجود ندارد.");
            return;
        }

        Response.Redirect("~/Student/OnlineExam/Default.aspx", true);
    }

    protected void lnkOnlineExam_Click(object sender, EventArgs e)
    {
        GotoOnlineExam();
    }

    protected void lnkExamReportCard_Click(object sender, EventArgs e)
    {
        ShowExamResult();
    }

    protected void lnkExamResult_Click(object sender, EventArgs e)
    {
        ShowExamResult();
    }

    protected void lnkMedia_Click(object sender, EventArgs e)
    {
        bool setting = WebsiteManager.GetAppSetting<bool>(WebsiteHandler.ExamAttachmentKey);
        if(setting)
            AttachmentView1.DataBind(WebsiteHandler.CurrentExamParticipate.ExamForm.Exam);
    }

    protected void lnkPoll_Click(object sender, EventArgs e)
    {
        bool setting = WebsiteManager.GetAppSetting<bool>(WebsiteHandler.ExamPollKey);
        Exam exam = WebsiteHandler.CurrentExamParticipate.ExamForm.Exam;
        if (setting && exam.HasPoll && exam.Poll != null)
        {
            if (WebsiteHandler.CurrentPerson.IsParticipate(exam.Poll))
            {
                rMessageBox1.ShowInformation("شرکت مجدد در این نظرسنجی امکانپذیر نیست.");
                return;
            }

            PollControl1.DataBind(exam.Poll);
        }
    }

    protected void lnkExamCard_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Student/rptExamCard.aspx", true);
    }
}
