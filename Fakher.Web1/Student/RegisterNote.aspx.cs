using Fakher.Core.Website;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_RegisterNote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        note.Text = WebsiteHandler.CurrentRegister.Period.RegistrationNote;
    }
}