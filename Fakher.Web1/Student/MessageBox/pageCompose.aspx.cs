using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;
using rComponents;

public partial class Student_MessageBox_pageCompose : Page
{
    private int[] mSelectedPersonIds
    {
        get { return ViewState["SelectedPersonIds"] as int[]; }
        set { ViewState["SelectedPersonIds"] = value; }
    }

    private Message mParentMessage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            string txt = Request.QueryString[0];
            string decrypt = WebsiteHandler.Decrypt(txt);
            int id = Convert.ToInt32(decrypt);
            mParentMessage = Message.FromId(id);

            if (!IsPostBack)
            {
                Message reply = mParentMessage.CreateReply();
                reply.Sender = WebsiteHandler.CurrentTeacher;
                reply.AddReceiver(mParentMessage.Sender);

                mSelectedPersonIds = reply.ReceiverIds;
                Fill(reply);
            }
        }
        RadWindow1.Visible = false;
    }

    private void Fill(Message message)
    {
        TxtReciever.Text = message.ReceiverText;
        txtSubject.Text = message.Subject;
        txtBody.Text = message.Body;
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
        }
    }
   
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtSubject.Text.Trim()))
        {
            rMessageBox1.ShowInformation("موضوع پیام نباید خالی باشد.");
            return;
        }
        if (string.IsNullOrEmpty(txtBody.Text.Trim()))
        {
            rMessageBox1.ShowInformation("متن پیام نباید خالی باشد.");
            return;
        }
        if(mSelectedPersonIds == null)
        {
            rMessageBox1.ShowInformation("گیرنده پیام مشخص نیست.");
            return;
        }

        Message message;
        try
        {
            if (mParentMessage != null)
                message = mParentMessage.CreateReply();
            else
                message = new Message();
            message.Sender = WebsiteHandler.CurrentPerson;
            message.Subject = Services.SecureHtml(txtSubject.Text.Trim());
            message.Body = Services.SecureHtml(txtBody.Text.Trim());

            if (mSelectedPersonIds != null)
                foreach (int personId in mSelectedPersonIds)
                {
                    Person person = Person.GetPerson(personId);
                    message.AddReceiver(person);
                }

            message.Save();
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            rMessageBox1.ShowInformation("خطا: امکان ارسال پیام وجود ندارد");
            return;
        }

        try
        {
            if (SmsPostMaster.CanSendSms())
            {
                string sms =
                    "شما یک پیام جدید دارید. جهت نمایش به وب سایت موسسه فاخر به آدرس www.fakher.ac.ir مراجعه کنید.";
                string[] mobiles =
                    Services.NormalizeMobileString(
                        message.Receivers.Select(x => x.Person.ContactInfo.Mobile).ToArray());
                SmsPostMaster.Send(sms, mobiles);
            }
        }
        catch (Exception ex)
        {
        }

        rMessageBox1.ShowInformation("پیام با موفقیت ارسال شد.", true);
    }

    protected void rMessageBox1_DialogResult(object sender, EventArgs e)
    {
        Response.Redirect("~/Student/MessageBox/Default.aspx", true);
    }

    protected void lnkTeacherSelect_Click(object sender, EventArgs e)
    {
        IQueryable<Participate> participates = WebsiteHandler.CurrentStudent.GetParticipates();
        List<Teacher> teachers = participates.ToList().Select(x => x.SectionItem.Section.Teacher).Distinct().ToList();

        RadGrid2.DataSource = teachers;
        RadGrid2.DataBind();

        RadWindow1.Visible = true;
    }

    protected void rBtnTeacherSelect_Click(object sender, EventArgs e)
    {
        List<int> selectedIds = new List<int>();

        foreach (GridDataItem gridDataItem in RadGrid2.Items)
        {
            CheckBox checkBox = gridDataItem.FindControl("chkSelect") as CheckBox;
            if (checkBox.Checked)
            {
                int id = Convert.ToInt32(RadGrid2.MasterTableView.DataKeyValues[gridDataItem.ItemIndex]["Id"]);
                Teacher teacher = Teacher.FromId(id);
                if (TxtReciever.Text.Contains(teacher.MessageAddress))
                    continue;

                TxtReciever.Text += " " + teacher.MessageAddress + " ";
                selectedIds.Add(teacher.Id);
            }
        }

        if (mSelectedPersonIds != null && mSelectedPersonIds.Length > 0)
            selectedIds.AddRange(mSelectedPersonIds);

        mSelectedPersonIds = selectedIds.ToArray();
        RadWindow1.Visible = false;
    }
}
