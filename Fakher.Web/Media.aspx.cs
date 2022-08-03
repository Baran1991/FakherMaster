using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;

public partial class Media : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request["c"];
        if (string.IsNullOrEmpty(code))
            return;

        WebMedia media = WebMedia.FromCode(code);
        if (media != null)
        {
            media.IncrementHits();
            media.Save();

            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = media.MimeType;
            Response.AddHeader("Content-Length", media.Bytes.Length + "");
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", media.Name));
            Response.BinaryWrite(media.Bytes);
        }
    }
}
