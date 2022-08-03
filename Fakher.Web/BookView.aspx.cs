using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using rComponents;

public partial class BookView : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString.Count == 0)
        {
            Response.Redirect("~", true);
            return;
        }
        
        int id = Convert.ToInt32(Request.QueryString[0]);
        EducationalTool tool = EducationalTool.FromId(id);

        if(!tool.ShowInWebsite)
        {
            Response.Redirect("~", true);
            return;
        }

        tool.IncrementHits();
        tool.Save();

        Fill(tool);
        Title = tool.Name;
    }

    private void Fill(EducationalTool tool)
    {
        if (tool.Photo != null && tool.Photo.Picture != null)
        {
            RadBinaryImage1.DataValue = tool.Photo.PictureBytes;
            RadBinaryImage1.Visible = true;
        }
        else
        {
            Image1.ImageUrl = "~/images/no-book-img.gif";
            Image1.Visible = true;
        }
        lblName.Text = tool.Name;
        lblAuthor.Text = tool.Author;
        lblPrice.Text = tool.LastSellPrice.ToString("C0");
        lblStatus.Text = tool.StatusText;
        lblDescription.Text = Services.NormalizeWebString(tool.Description);
    }
}
