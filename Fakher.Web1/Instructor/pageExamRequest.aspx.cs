using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

public partial class Instructor_pageExamRequest : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RadBtnSubmit_Click(object sender, EventArgs e)
    {
        ExamRequest examRequest = new ExamRequest();
        examRequest.Teacher = WebsiteHandler.CurrentTeacher;
        examRequest.ExamDate = PersianDate.FromString(rTxtExamDate.TextWithLiterals.Trim());
        examRequest.Major = RadTxtMajor.Text.Trim();
        examRequest.Lesson = RadTxtLesson.Text.Trim();
        examRequest.Section = RadTxtSection.Text.Trim();
        examRequest.ParticipateCount = Convert.ToInt32(RadTxtCount.Text.Trim());
        examRequest.Name = RadTxtExamName.Text.Trim();
        examRequest.StartTime = RadMaskedTxtFrom.TextWithLiterals.Trim();
        examRequest.EndTime = RadMaskedTxtTo.TextWithLiterals.Trim();

        examRequest.Save();

        rMessageBox1.ShowInformation("درخواست آزمون با موفقیت ثبت و ارسال گردید. لطفا منتظر تایید/رد آن باشید.", true);
    }

    protected void rMessageBox1_DialogResult(object sender, DialogResultEventArgs e)
    {
        Response.Redirect("~/Instructor/", true);
    }
}