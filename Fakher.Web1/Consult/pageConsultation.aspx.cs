using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Consult;
using rComponents;

public partial class Consult_pageConsultation : Page
{
    private Consultation mConsultation;

    protected void Page_Load(object sender, EventArgs e)
    {
        string consultationId = Request["ConsultationCode"];
        if (!string.IsNullOrEmpty(consultationId))
        {
            int id = Convert.ToInt32(consultationId);

            mConsultation = Consultation.FromCode(id);
            mConsultation.IncrementHits();
            mConsultation.Save();

            BindToForm(mConsultation);
        }
        else
        {
            Response.Redirect("~/Consult", true);
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        Title = mConsultation.Title;
    }

    private void BindToForm(Consultation consultation)
    {
        lblTitle.Text = Services.NormalizeWebString(consultation.Title);
        lblQuestion.Text = Services.NormalizeWebString(consultation.Question);
        lblAnswer.Text = Services.NormalizeWebString(consultation.Answer);
        lblCode.Text = consultation.Code + "";
        lblHits.Text = consultation.Hits + "";
    }

}
