using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Students
{
    public partial class frmCertificateList : rRadForm
    {
        public frmCertificateList(Register register)
        {
            InitializeComponent();
            SetProcessingObject(register);

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ درخواست", ObjectProperty = "RequestDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });

            rGridView1.CustomButtons.Add(new rGridViewButton {Text = "چاپ رسید", VisibleOnSelect = true, Position = rGridViewButtonPosition.After});

            rGridView1.DataBind(register.Student.GetCertificates());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Register register = GetProcessingObject<Register>();
            Certificate certificate = new Certificate()
                                          {Student = register.Student, Fee = register.Period.CertificateFee};
            frmCertificateDetail frm = new frmCertificateDetail(certificate);
            if (!frm.ProcessObject())
                return;
            certificate.Save();
            rGridView1.Insert(certificate);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Certificate certificate = rGridView1.GetSelectedObject<Certificate>();
            frmCertificateDetail frm = new frmCertificateDetail(certificate);
            if (!frm.ProcessObject())
                return;
            certificate.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Certificate certificate = rGridView1.GetSelectedObject<Certificate>();
            certificate.Delete();

            rGridView1.RemoveSelectedRow();
        }

        private void rGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            Certificate certificate = rGridView1.GetSelectedObject<Certificate>();
            if(e.ButtonIndex == 0) //Receipt
            {
                rptCertificateReceipt rpt = new rptCertificateReceipt();
                rpt.DataSource = new[] {certificate};
                frmReportViewer frm = new frmReportViewer(rpt) {AutoPrint = true};
                frm.ShowDialog();
            }
        }
    }
}
