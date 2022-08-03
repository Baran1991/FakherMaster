using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;

public partial class UserControls_BookControl : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void DataBind(EducationalTool tool)
    {
        if (tool.Photo != null && tool.Photo.Picture != null)
        {
            //RadBinaryImage1.DataValue = tool.Photo.PictureBytes;
            //RadBinaryImage1.Visible = true;
        }
        else
        {
            Image1.ImageUrl = "~/images/no-book-img.gif";
            Image1.Visible = true;
        }
        lnkName.Text = tool.Name;
        lnkName.NavigateUrl = "~/BookView.aspx?" + tool.Id;
        lblAuthor.Text = tool.Author;
        lblPrice.Text = tool.LastSellPrice.ToString("C0");
        Panel1.Visible = true;
    }
}
