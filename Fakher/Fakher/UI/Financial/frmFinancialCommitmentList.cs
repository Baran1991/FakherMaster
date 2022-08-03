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
using rComponents;

namespace Fakher.UI.Financial
{
    public partial class frmFinancialCommitmentList : rRadForm
    {
        public frmFinancialCommitmentList()
        {
            InitializeComponent();

            rGridViewCommitments.Mappings.Add(new ColumnMapping { Caption = "سررسید تعهد", ObjectProperty = "Date" });
            rGridViewCommitments.Mappings.Add(new ColumnMapping { Caption = "نوع", ObjectProperty = "TypeText" });
            rGridViewCommitments.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Register.Student.FarsiFullname" });
            rGridViewCommitments.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Register.Major.Name" });
            rGridViewCommitments.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "AmountText" });

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "سررسید تعهد", ObjectProperty = "Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نوع", ObjectProperty = "TypeText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Register.Student.FarsiFullname" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Register.Major.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "AmountText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ انجام تعهد", ObjectProperty = "PayOffDate" });

            rGridViewCommitments.DataBind(FinancialCommitment.GetCommitments(FinancialCommitmentStatus.InProgress));
            rGridView1.DataBind(DbContext.GetAllEntities<FinancialCommitment>());
        }

        private void rGridViewCommitments_Edit(object sender, EventArgs e)
        {
            FinancialCommitment commitment = rGridViewCommitments.GetSelectedObject<FinancialCommitment>();
            frmFinancialCommitmentDetail frm = new frmFinancialCommitmentDetail(commitment);
            if (!frm.ProcessObject())
                return;

            commitment.Save();
            rGridViewCommitments.UpdateGridView();
        }

        private void rGridViewCommitments_Delete(object sender, EventArgs e)
        {
            FinancialCommitment commitment = rGridViewCommitments.GetSelectedObject<FinancialCommitment>();

            commitment.Register.FinancialCommitments.Remove(commitment);
            commitment.Register = null;
            commitment.Delete();
            rGridViewCommitments.RemoveSelectedRow();
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            FinancialCommitment commitment = rGridView1.GetSelectedObject<FinancialCommitment>();
            frmFinancialCommitmentDetail frm = new frmFinancialCommitmentDetail(commitment);
            if (!frm.ProcessObject())
                return;

            commitment.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            FinancialCommitment commitment = rGridView1.GetSelectedObject<FinancialCommitment>();

            commitment.Register.FinancialCommitments.Remove(commitment);
            commitment.Register = null;
            commitment.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
