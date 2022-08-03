using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Reports.Career;
using Fakher.UI.Report;
using rComponents;
using SortOrder = rComponents.SortOrder;

namespace Fakher.UI.Career
{
    public partial class frmCareerList : rRadForm
    {
        public frmCareerList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ شروع", ObjectProperty = "StartDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ پایان", ObjectProperty = "EndDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "SubmitDateText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "زمان", ObjectProperty = "SubmitTimeText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نــام", ObjectProperty = "PersonalInfo.FarsiFirstName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "PersonalInfo.FarsiLastName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره پیگیری", ObjectProperty = "Code" });

            rGridView1.DataBind(DbContext.GetAllEntities<Fakher.Core.DomainModel.Career>());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Fakher.Core.DomainModel.Career career = new Core.DomainModel.Career();
            frmCareerDetail frm = new frmCareerDetail(career);
            if (!frm.ProcessObject())
                return;
            career.Save();
            rGridView1.Insert(career);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Fakher.Core.DomainModel.Career career = rGridView1.GetSelectedObject<Fakher.Core.DomainModel.Career>();
            career.RefreshEntity();
            frmCareerDetail frm = new frmCareerDetail(career);
            if (!frm.ProcessObject())
                return;
            career.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Fakher.Core.DomainModel.Career career = rGridView1.GetSelectedObject<Fakher.Core.DomainModel.Career>();
            career.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            Core.DomainModel.Career career = rGridView1.GetSelectedObject<Fakher.Core.DomainModel.Career>();
            if(career != null)
                rGridView2.DataBind(career.GetApplicants());
        }

        private void rGridView2_Add(object sender, EventArgs e)
        {
            Core.DomainModel.Career career = rGridView1.GetSelectedObject<Fakher.Core.DomainModel.Career>();
            rptCareerApplicants rpt = new rptCareerApplicants();
            rpt.Career = career;
            rpt.Applicants = rGridView2.GetVisibleObjects<CareerApplicant>();
            rpt.PrepareDataset(null);
            rpt.Apply(null);

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog(this);
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            CareerApplicant applicant = rGridView2.GetSelectedObject<CareerApplicant>();
            applicant.Delete();
            rGridView2.RemoveSelectedRow();
        }
    }
}
