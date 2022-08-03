using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Financial
{
    public partial class frmRegisterFinancialCommitmentList : rRadForm
    {
        public frmRegisterFinancialCommitmentList(Register register)
        {
            InitializeComponent();
            SetProcessingObject(register);

            rGridViewCommitments.Mappings.Add(new ColumnMapping { Caption = "سررسید تعهد", ObjectProperty = "Date" });
            rGridViewCommitments.Mappings.Add(new ColumnMapping { Caption = "نوع", ObjectProperty = "TypeText" });
            rGridViewCommitments.Mappings.Add(new ColumnMapping { Caption = "مبلغ", ObjectProperty = "AmountText" });

            rGridViewCommitments.DataBind(register.FinancialCommitments);
        }

        private void rGridViewCommitments_Add(object sender, EventArgs e)
        {
            Register register = GetProcessingObject<Register>();
            FinancialCommitment commitment = new FinancialCommitment {Register = register};
            frmFinancialCommitmentDetail frm = new frmFinancialCommitmentDetail(commitment);
            if (!frm.ProcessObject())
                return;

            register.FinancialCommitments.Add(commitment);
            commitment.Save();
            rGridViewCommitments.Insert(commitment);
        }

        private void rGridViewCommitments_Edit(object sender, EventArgs e)
        {
            Register register = GetProcessingObject<Register>();
            FinancialCommitment commitment = rGridViewCommitments.GetSelectedObject<FinancialCommitment>();
            frmFinancialCommitmentDetail frm = new frmFinancialCommitmentDetail(commitment);
            if (!frm.ProcessObject())
                return;

            commitment.Save();
            rGridViewCommitments.UpdateGridView();
        }

        private void rGridViewCommitments_Delete(object sender, EventArgs e)
        {
            Register register = GetProcessingObject<Register>();
            FinancialCommitment commitment = rGridViewCommitments.GetSelectedObject<FinancialCommitment>();

            commitment.Register = null;
            register.FinancialCommitments.Remove(commitment);
            commitment.Delete();
            rGridViewCommitments.RemoveSelectedRow();
        }
    }
}
