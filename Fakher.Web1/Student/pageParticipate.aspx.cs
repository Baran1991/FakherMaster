using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Fakher.Reports;
using Telerik.Reporting.Processing;
using rComponents;

public partial class Student_pageParticipate : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentStudent == null 
            || WebsiteHandler.CurrentRegister == null
                || WebsiteHandler.CurrentParticipate == null)
        {
            Response.Redirect("Default.aspx", true);
            return;
        }

        if(!IsPostBack)
        {
        }

        lblLesson.Text = WebsiteHandler.CurrentParticipate.SectionItem.Lesson.Name + " " + WebsiteHandler.CurrentParticipate.SectionItem.Section.FarsiName;
        lblFormation.Text = WebsiteHandler.CurrentParticipate.SectionItem.Section.FarsiVerboseFormationText;
        lblEvents.Text = WebsiteHandler.CurrentParticipate.SectionItem.Section.EducationalEventsText;
        Title = "امــور کلـاســی - " + WebsiteHandler.CurrentParticipate.SectionItem.Section.FarsiName;

        cellAttachments.Visible = WebsiteHandler.CurrentParticipate.SectionItem.Section.Attachments.Count > 0;
        cellPoll.Visible = WebsiteHandler.CurrentParticipate.SectionItem.Section.HasPoll;
    }

    private void ShowReportCard()
    {
        Language language = WebsiteHandler.CurrentRegister.Period.Department.ReportLanguage;
        HttpContext.Current.Items["IsInReportMode"] = true;

        try
        {
            if (language == Language.English)
            {
                rptEnReportCard rpt = new rptEnReportCard();
                rptEnReportCard.Period = WebsiteHandler.CurrentRegister.Period;
                rpt.DataSource = new[] {WebsiteHandler.CurrentParticipate};
//                ReportViewer1.Report = rpt;

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
                rptFaReportCard rpt = new rptFaReportCard();
                rptFaReportCard.Period = WebsiteHandler.CurrentRegister.Period;
                rpt.DataSource = new[] {WebsiteHandler.CurrentParticipate};
//                ReportViewer1.Report = rpt;

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
            rMessageBox1.ShowInformation("مشاهده نتیجه این گـروه متاسفانه ممکن نیست. لطفا مجددا مراجعه کنید.");
            return;
        }
    }

    protected void lnkReportCard_Click(object sender, EventArgs e)
    {
        if (!WebsiteHandler.CurrentParticipate.Register.Period.CanViewReportCard(PersianDate.Today, DateTime.Now.Hour, DateTime.Now.Minute))
        {
            if (WebsiteHandler.CurrentParticipate.Register.Period.CanViewWebReportCard)
                rMessageBox1.ShowInformation(
                    "نتیجه این گـروه از ساعت {0} تاریخ {1} قابل مشاهده است. لطفا در زمانبندی تعیین شده مراجعه کنید.",
                    false, WebsiteHandler.CurrentParticipate.Register.Period.WebReportCardStartTime,
                    WebsiteHandler.CurrentParticipate.Register.Period.WebReportCardStartDate.ToShortDateString());
            else
                rMessageBox1.ShowInformation("مشاهده نتیجه این گـروه هنوز ممکن نیست. لطفا بعدا مراجعه کنید.");
            return;
        }

        ShowReportCard();
    }

    protected void lnkMedia_Click(object sender, EventArgs e)
    {
        bool setting = WebsiteManager.GetAppSetting<bool>(WebsiteHandler.SectionAttachmentKey);
        if(setting)
            AttachmentView1.DataBind(WebsiteHandler.CurrentParticipate.SectionItem.Section);
    }

    protected void lnkPoll_Click(object sender, EventArgs e)
    {
        bool setting = WebsiteManager.GetAppSetting<bool>(WebsiteHandler.SectionPollKey);
        Section section = WebsiteHandler.CurrentParticipate.SectionItem.Section;
        if (setting && section.HasPoll && section.Poll != null)
        {
            if (WebsiteHandler.CurrentPerson.IsParticipate(section.Poll))
            {
                rMessageBox1.ShowInformation("شرکت مجدد در این نظرسنجی امکانپذیر نیست.");
                return;
            }

            PollControl1.DataBind(section.Poll);
        }
    }
}
