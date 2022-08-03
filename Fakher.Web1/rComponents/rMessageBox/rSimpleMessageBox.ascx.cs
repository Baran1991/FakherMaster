using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rComponents_rMessageBox_rSimpleMessageBox : UserControl
{
    protected void Page_Init(object sender, EventArgs e)
    {

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void ShowInformation(string text)
    {
        lblTopMessage.Text = text;
        Panel1.Visible = true;
    }

    public void ShowInformation(string text, params string[] args)
    {
        ShowInformation(string.Format(text, args));
    }
}
