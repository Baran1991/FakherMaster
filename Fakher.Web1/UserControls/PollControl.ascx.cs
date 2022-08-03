using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel.Poll;
using Fakher.Core.Website;

public partial class UserControls_PollControl : UserControl
{
    public PollSubmitAction SubmitAction { get; set; }
    
    public UserControls_PollControl()
    {
        SubmitAction = PollSubmitAction.HidePoll;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void DataBind(Poll poll)
    {
        lblText.Text = poll.Text;
        RepeaterPollItems.DataSource = poll.Items;
        RepeaterPollItems.DataBind();
        foreach (PollItem item in poll.Items)
        {
            ListItem listItem = new ListItem(item.Text, item.Id + "");
           
            //ListBoxItems.Items.Add(listItem);
            //RadioButtonListItems.Items.Add(listItem);
        }
        pnlPoll.Visible = true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        foreach(RepeaterItem item in RepeaterPollItems.Items)
        {
            RadioButtonList radioList = item.FindControl("RadioButtonListItems") as RadioButtonList;
            Label lblID = item.FindControl("lblItemID") as Label;
            int id = Convert.ToInt32(lblID.Text);
            PollItem pollItem = PollItem.FromId(id);
            foreach (ListItem radio in radioList.Items)
            {
                
                if (radio.Selected)
                {
                    switch(radio.Value)
                    {
                        case "1":
                            pollItem.Hits_1++;
                            break;
                        case "2":
                            pollItem.Hits_2++;
                            break;
                        case "3":
                            pollItem.Hits_3++;
                            break;
                        case "4":
                            pollItem.Hits_4++;
                            break;
                    }
                    break;
                    
                }
            }
            pollItem.Save();
      
        //if (RadioButtonListItems.SelectedIndex == -1)
        //    return;

        //string idText = RadioButtonListItems.SelectedItem.Value.Trim();
        //int id = Convert.ToInt32(idText);

        //PollItem pollItem = PollItem.FromId(id);
        ////pollItem.IncrementHits();
        //pollItem.Save();

        if (WebsiteHandler.CurrentPerson != null)
        {
            PollParticipate participate = WebsiteHandler.CurrentPerson.CreatePollParticipate(pollItem);
            participate.Save();
        }
            WebsiteHandler.PagePollRedirect = false;
        if (SubmitAction == PollSubmitAction.HidePoll)
        {
            pnlPoll.Visible = false;
            pnlThanks.Visible = false;
        }
        if (SubmitAction == PollSubmitAction.ShowThanksPanel)
        {
            pnlPoll.Visible = false;
            pnlThanks.Visible = true;
        } 
        }
    }
}

public enum PollSubmitAction
{
    HidePoll,
    ShowThanksPanel,
}
