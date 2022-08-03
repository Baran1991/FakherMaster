using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Fakher.Reports;
using Fakher.Reports.Ministerial_Reports;
using Telerik.Reporting.Processing;

public partial class Instructor_rptPayroll : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RadComboBox1.DataSource = WebsiteHandler.CurrentTeacher.Payrolls.OrderByDescending(x => x.Id);
            RadComboBox1.DataBind();
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(RadComboBox1.SelectedValue);
        Payroll selectedPayroll = Payroll.FromId(id);
        if (selectedPayroll == null)
            return;

        rptPayrollReceipt rpt = new rptPayrollReceipt();
        rpt.Fill(selectedPayroll);
        rpt.DataSource = new[] { selectedPayroll };

        ReportViewer1.DataBind(rpt);
    }
}
