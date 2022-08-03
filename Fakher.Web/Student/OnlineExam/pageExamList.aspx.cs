using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;

public partial class Student_OnlineExam_pageExamList : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(WebsiteHandler.CurrentStudent == null)
        {
            Response.Redirect("~/Student/OnlineExam/Default.aspx", true);
            return;
        }

        if(!IsPostBack)
            Fill();
    }

    private void Fill()
    {
        GridView1.DataSource = WebsiteHandler.CurrentStudent.GetExamParticipates().ToList().Where(x => x is OnlineExamParticipate);
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        OnlineExamParticipate onlineExamParticipate = e.Row.DataItem as OnlineExamParticipate;
        if (onlineExamParticipate != null)
        {
            Button button = e.Row.FindControl("btnParticipate") as Button;
            if (button != null)
            {
                button.CommandArgument = onlineExamParticipate.Id + "";
            }
        }
    }

    protected void btnParticipate_Click(object sender, EventArgs e)
    {
        Button btnParticipate = sender as Button;
        int id = Convert.ToInt32(btnParticipate.CommandArgument);
        ExamParticipate examParticipate = ExamParticipate.FromId(id);

        WebsiteHandler.CurrentRegister = examParticipate.Register;
        WebsiteHandler.CurrentExamParticipate = examParticipate;

        Response.Redirect("~/Student/OnlineExam/pageExamStart.aspx", true);
    }
}
