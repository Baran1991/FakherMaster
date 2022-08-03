using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Consult;
using Fakher.Core.Website;
using Telerik.Web.UI;
using rComponents;

public partial class Student_ConsultationSession_Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid();
        }
    }

    private void FillGrid()
    {
        List<ConsultationSession> sessions = DbContext.GetAllEntities<ConsultationSession>();
        RadGrid1.DataSource = sessions;
        RadGrid1.DataBind();
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";

            ConsultationSession session = (e.Item as GridDataItem).DataItem as ConsultationSession;
            bool any = WebsiteHandler.CurrentStudent.ConsultationApplicants.Where(x => x.Session.Id == session.Id).Any();

            Button btn = e.Item.FindControl("btnCommand") as Button;
            btn.CommandArgument = EncryptDecrypt.Encrypt(session.Id + "");
            if (any)
                btn.Text = "چاپ کارت";
            else
                btn.Text = "تعیین وقت";
        }
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        int id = Convert.ToInt32(EncryptDecrypt.Decrypt(btn.CommandArgument));
        ConsultationSession session = DbContext.FromId<ConsultationSession>(id);
        bool any = WebsiteHandler.CurrentStudent.ConsultationApplicants.Where(x => x.Session.Id == session.Id).Any();
        if(any)
        {
            Response.Redirect("~/Student/ConsultationSession/rptApplicantCard.aspx?" + WebsiteHandler.UrlEncode(btn.CommandArgument));
            return;
        }
        else
        {
            hfSession.Value = btn.CommandArgument;
            RadCmbFormation.DataSource = session.GetFreeFormations();
            RadWindow1.Visible = true;
        }
    }

    protected void radBtnOk_Click(object sender, EventArgs e)
    {
        if(RadCmbFormation.SelectedIndex == -1)
        {
            rMessageBox1.ShowInformation("زمان مشاوره را مشخص کنید.");
            return;
        }

        int id = Convert.ToInt32(RadCmbFormation.SelectedValue);
        Formation formation = Formation.FromId(id);
        id = Convert.ToInt32(EncryptDecrypt.Decrypt(hfSession.Value));
        ConsultationSession session = ConsultationSession.FromId(id);
        ConsultationApplicant applicant = WebsiteHandler.CurrentStudent.CreateConsultationApplicant();
        applicant.InternetRegisteration = true;
        applicant.Session = session;
        applicant.Formation = formation;
        applicant.Save();

        
        Response.Redirect("~/Student/ConsultationSession/rptApplicantCard.aspx?" + WebsiteHandler.UrlEncode(hfSession.Value));
    }

    protected void radBtnCancel_Click(object sender, EventArgs e)
    {
        RadWindow1.Visible = false;
    }
}