using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fakher.UI.Persons
{
    public partial class frmBayganiDetails : rRadForm
    {
        private Student selectedStudent;
        public frmBayganiDetails(Student student)
        {
            InitializeComponent();
            selectedStudent = student;
            rTextBoxEmployee.Text = student.BayganiCreatedByName;
            rTextBoxDate.Text = student.BayganiDate.ToString();
            rLabelBayganiNo.Text = student.BayganiNo.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            rptBayganiCodeStudent rpt = new rptBayganiCodeStudent();
            rpt.DataSource = new object[] { selectedStudent };
            frmReportViewer frmReport = new frmReportViewer(rpt);
            frmReport.ShowDialog(this);
        }
    }
}
