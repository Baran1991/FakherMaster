using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Consult;
using Fakher.Core.Website;
using Fakher.Reports;
using rComponents;

public partial class Student_ConsultationSession_rptApplicantCard : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string idText = WebsiteHandler.UrlDecode(Request.QueryString[0]);
        idText = EncryptDecrypt.Decrypt(idText);
        int id = Convert.ToInt32(idText);
        ConsultationSession session = ConsultationSession.FromId(id);
        ConsultationApplicant applicant = WebsiteHandler.CurrentStudent.ConsultationApplicants.FirstOrDefault(x => x.Session.Id == session.Id);

        rptFaConsultationApplicantCard rpt = new rptFaConsultationApplicantCard();
        rpt.DataSource = new[] { applicant };
        ReportViewer1.DataBind(rpt);
    }
}