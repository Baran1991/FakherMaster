using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel.Consult;
using NHibernate;
using rComponents;

namespace Fakher.UI.Consult
{
    public partial class frmConsultationSessionList : rRadForm
    {
        public frmConsultationSessionList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نــــام", ObjectProperty = "Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "HoldingDate.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان شروع", ObjectProperty = "HoldingStartTime" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان پایان", ObjectProperty = "HoldingEndTime" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نــــام", ObjectProperty = "Student.FarsiFullname" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "زمان", ObjectProperty = "Formation.Time" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت نام", ObjectProperty = "RegisterationTypeText" });

            rGridView1.DataBind(DbContext.GetAllEntities<ConsultationSession>());
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            ConsultationSession consultationSession = rGridView1.GetSelectedObject<ConsultationSession>();
            int count = consultationSession.GetApplicants().Count();
            if(count > 0)
            {
                rMessageBox.ShowError("ابتدا همه شرکت کنندگان مشاوره را حذف کنید.");
                return;
            }
            consultationSession.Formations.Clear();
            consultationSession.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            ConsultationSession consultationSession = rGridView1.GetSelectedObject<ConsultationSession>();
            if (consultationSession == null)
                return;
            rGridView2.DataBind(consultationSession.GetApplicants());
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            ConsultationApplicant applicant = rGridView2.GetSelectedObject<ConsultationApplicant>();
            applicant.Delete();
            rGridView2.RemoveSelectedRow();
        }
    }
}
