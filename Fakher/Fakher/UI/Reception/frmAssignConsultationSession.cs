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
using Fakher.Core.DomainModel.Consult;
using rComponents;

namespace Fakher.UI.Reception
{
    public partial class frmAssignConsultationSession : rRadDetailForm
    {
        public frmAssignConsultationSession(ConsultationApplicant applicant)
        {
            InitializeComponent();
            SetProcessingObject(applicant);

            rGridComboBox1.Columns.Add("نام", "نام", "Name");
            rGridComboBox1.Columns.Add("تاریخ برگزاری", "تاریخ برگزاری", "HoldingDate");

            rGridComboBox2.Columns.Add("زمان شروع", "زمان شروع", "StartTime");
            rGridComboBox2.Columns.Add("زمان پایان", "زمان پایان", "FinishTime");


            rGridComboBox1.DataSource = DbContext.GetAllEntities<ConsultationSession>();
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultationSession session = rGridComboBox1.GetValue<ConsultationSession>();
            rGridComboBox2.DataSource = session.GetFreeFormations();
        }

        protected override void AfterBindToObject()
        {
            ConsultationApplicant applicant = GetProcessingObject<ConsultationApplicant>();
            ConsultationSession session = rGridComboBox1.GetValue<ConsultationSession>();
            Formation formation = rGridComboBox2.GetValue<Formation>();
            applicant.Session = session;
            applicant.Formation = formation;
        }
    }
}
