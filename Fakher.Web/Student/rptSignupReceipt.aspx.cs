using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Reports;
using Fakher.Core.Website;
using Telerik.Reporting.Processing;

public partial class Student_pageSignupReceipt : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentStudent == null || WebsiteHandler.CurrentRegister == null)
        {
            Response.Redirect("Default.aspx", true);
            return;
        }

        if (!IsPostBack)
        {
            rptSignupReceipt rpt = new rptSignupReceipt();
            rpt.DataSource = new object[] {WebsiteHandler.CurrentRegister};
//            ReportViewer1.Report = rpt;

            ReportViewer1.DataBind(rpt);

//            ReportProcessor reportProcessor = new ReportProcessor();
//            RenderingResult result = reportProcessor.RenderReport("IMAGE", rpt, null);
//            MemoryStream jpegMemory = new MemoryStream();
//            MemoryStream tiffMemory = new MemoryStream(result.DocumentBytes);
//            Bitmap bmp = new Bitmap(tiffMemory);
//            bmp.Save(jpegMemory, ImageFormat.Png);
//            byte[] bytes = jpegMemory.ToArray();
//            jpegMemory.Dispose();
//            tiffMemory.Dispose();
//            bmp.Dispose();
//            RadBinaryImage1.DataValue = bytes;
        }
    }
}
