using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;
using rComponents;

public partial class Student_PagePoll : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentStudent != null && !IsPostBack)
        {
            WebsiteHandler.PagePollRedirect = true;
            if (Request.QueryString["pollID"] != null)
            {
                var pollID = int.Parse(Request.QueryString["pollID"]);
                if (pollID >0)
                {
                    bool setting = WebsiteManager.GetAppSetting<bool>(WebsiteHandler.SectionPollKey);
                    foreach (Participate participate in WebsiteHandler.CurrentRegister.Participates)
                    {
                        var section = participate.SectionItem.Section;
                        if (section.HasPoll && setting && section.Poll != null && section.Poll.Id == pollID)
                        {
                            if (!WebsiteHandler.CurrentPerson.IsParticipate(section.Poll))
                            {
                                PollControl1.DataBind(section.Poll);
                                break;
                            }

                        }
                    }
                }
            }
        }
            }
    }

