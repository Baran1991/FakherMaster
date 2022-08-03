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
using Telerik.Reporting.Processing;
using Telerik.Web.UI;

public partial class UserControls_ReportViewer : UserControl
{
    private List<MemoryStream> mStreams; 

    protected void Page_Init(object sender, EventArgs e)
    {
        if(mStreams == null)
            mStreams = new List<MemoryStream>();
    }

    private Stream CreateStream(string name, string extension, Encoding encoding, string mimeType)
    {
        MemoryStream stream = new MemoryStream();
        mStreams.Add(stream);

        return stream;
    }

    private void CloseStreams()
    {
        foreach (MemoryStream stream in mStreams)
            stream.Close();
        mStreams.Clear();
    }

    public void DataBind(Telerik.Reporting.Report report)
    {
        var documentName = "";
        Hashtable deviceInfo = new Hashtable();
        deviceInfo["OutputFormat"] = "BMP";

        ReportProcessor reportProcessor = new ReportProcessor();
        reportProcessor.RenderReport("IMAGE", report, deviceInfo, CreateStream, out documentName);

        Panel1.Controls.Clear();
        foreach (MemoryStream stream in mStreams)
        {
            MemoryStream pngMemory = new MemoryStream();
            Bitmap bmp = new Bitmap(stream);
            bmp.Save(pngMemory, ImageFormat.Png);
            byte[] bytes = pngMemory.ToArray();
            pngMemory.Dispose();
            bmp.Dispose();

            RadBinaryImage binaryImage = new RadBinaryImage();
            binaryImage.Height = new Unit("300px");
            binaryImage.Width = new Unit("100%");
            binaryImage.DataValue = bytes;
            Panel1.Controls.Add(binaryImage);
        }

        CloseStreams();
        Panel1.Visible = true;
    }
}
