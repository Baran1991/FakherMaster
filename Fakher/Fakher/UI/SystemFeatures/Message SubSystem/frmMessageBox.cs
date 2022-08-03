using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core;
using Fakher.Core.DomainModel;
using Fakher.UI.SystemFeatures;
using rComponents;
using Message = Fakher.Core.DomainModel.Message;

namespace Fakher.UI
{
    public partial class frmMessageBox : rRadForm
    {
        private Core.DomainModel.Person mPerson;
        private int mCurrentBox;
        private bool mFlag;

        public frmMessageBox(Core.DomainModel.Person person)
        {
            InitializeComponent();
            mPerson = person;

            GotoInbox();
        }

        private  void GotoInbox()
        {
            mCurrentBox = 1;

            rGridViewMessages.Reset();
            rGridViewMessages.Mappings.Add(new ColumnMapping { Caption = "تاریخ ارسال", ObjectProperty = "SendDateTime"});
            rGridViewMessages.Mappings.Add(new ColumnMapping { Caption = "فرستنده", ObjectProperty = "Sender" });
            rGridViewMessages.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "GridSubject" });
            rGridViewMessages.CustomEditText = "ارسال پاسخ";

            rGroupBox2.Text = "پیام های دریافت شده";
            IList<Message> receivedMessages = mPerson.GetReceivedMessages();
            rGridViewMessages.DataBind(receivedMessages);
            UpdateInboxLink();
        }

        private  void UpdateInboxLink()
        {
            IList<Message> receivedMessages = mPerson.GetReceivedMessages();

            int count = 0;
            foreach (Message message in receivedMessages)
            {
                MessageReceiver messageReceiver = message.GetReceiver(mPerson).FirstOrDefault();
                if (messageReceiver != null && messageReceiver.Status == MessageStatus.UnRead)
                {
                    rGridViewMessages.SetRowBold(message);
                    count++;
                }
            }

//            count = mPerson.GetReceivedMessages(MessageStatus.UnRead).Count();
            string linkText = "صندوق دریافت";
            if(count > 0)
            {
                lnkInbox.Text = linkText + " (" + count + ") ";
                lnkInbox.Font = new Font(lnkInbox.Font.Name, lnkInbox.Font.Size, FontStyle.Bold);
            }
            else
            {
                lnkInbox.Text = linkText;
                lnkInbox.Font = new Font(lnkInbox.Font.Name, lnkInbox.Font.Size, FontStyle.Regular);
            }
        }

        private void GotoSentBox()
        {
            mCurrentBox = 2;

            rGridViewMessages.Reset();
            rGridViewMessages.Mappings.Add(new ColumnMapping { Caption = "تاریخ ارسال", ObjectProperty = "SendDateTime" });
            rGridViewMessages.Mappings.Add(new ColumnMapping { Caption = "گیرنده", ObjectProperty = "ReceiverText" });
            rGridViewMessages.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "GridSubject" });
            rGridViewMessages.CustomEditText = "ارسال مجدد";

            rGroupBox2.Text = "پیام های ارسال شده";
            rGridViewMessages.DataBind(mPerson.GetSentMessages());
        }

        private void lnkInbox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GotoInbox();
        }

        private void lnkSentBox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GotoSentBox();
        }

        private void rGridViewMessages_Delete(object sender, EventArgs e)
        {
            Message message = rGridViewMessages.GetSelectedObject<Message>();
            message.Delete();
            rGridViewMessages.RemoveSelectedRow();
        }

        private void rGridViewMessages_SelectedItemChanged(object sender, EventArgs e)
        {
            Message message = rGridViewMessages.GetSelectedObject<Message>();
            
            messageThreadView1.Visible = false;
            if (message == null)
                return;

            messageThreadView1.Fill(message);
            messageThreadView1.Visible = true;

            if (!mFlag)
            {
                timer1.Enabled = false;
                timer1.Enabled = true;
            }
        }

        private void rGridViewMessages_Edit(object sender, EventArgs e)
        {
            Message message = rGridViewMessages.GetSelectedObject<Message>();
            if (message == null)
                return;

            if (mCurrentBox == 1)
            {
                Message reply = message.CreateReply();
                reply.Sender = mPerson;
                reply.AddReceiver(message.Sender);
                frmMessageDetail frm = new frmMessageDetail(reply);
                if (!frm.ProcessObject())
                    return;
                reply.Save();
            }
            else if(mCurrentBox == 2)
            {
                Message forward = message.CreateReply();
                forward.Sender = mPerson;
                frmMessageDetail frm = new frmMessageDetail(forward);
                if (!frm.ProcessObject())
                    return;
                forward.Save();
                rGridViewMessages.Insert(forward);
            }
        }

        private void radBtnNewMessage_Click(object sender, EventArgs e)
        {
            Message message = new Message();
            message.Sender = mPerson;
            frmMessageDetail frm = new frmMessageDetail(message);
            if (!frm.ProcessObject())
                return;

            message.SendDate = PersianDate.Today;
            message.SendTime = Time.Now.ToShortTimeString();
            message.Save();

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

            if(mCurrentBox == 2)
            {
                rGridViewMessages.Insert(message);
            }

            rMessageBox.ShowInformation("پیام با موفقیت ارسال گردید.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                Message message = rGridViewMessages.GetSelectedObject<Message>();
                if (message == null)
                    return;
                // yani inke dar sentBox boodim
//                if (message.Sender.Id == mPerson.Id)
                if (mCurrentBox == 2)
                    return;


                IQueryable<MessageReceiver> personReceivers = message.GetReceiver(mPerson);
                foreach (MessageReceiver receiver in personReceivers)
                {
                    if (receiver.Status == MessageStatus.Read)
                        return;

                    receiver.ReadDate = PersianDate.Today.ToShortDateString();
                    receiver.ReadTime = Time.Now.ToShortTimeString();
                    receiver.Status = MessageStatus.Read;
                    receiver.Save();
                }


                mFlag = true;
                rGridViewMessages.SetRowNormal(message);
//                rGridViewMessages.UpdateGridView();
                UpdateInboxLink();
                mFlag = false;
            }
            finally
            {
                timer1.Enabled = true;
            }
        }

        private void linkLnkMarkAllRead_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int count = 0;
            foreach (Message message in rGridViewMessages.DataSource)
            {
                IQueryable<MessageReceiver> personReceivers = message.GetReceiver(mPerson);

                foreach (MessageReceiver receiver in personReceivers)
                {
                    if (receiver.Status == MessageStatus.Read)
                        continue;

                    receiver.ReadDate = PersianDate.Today.ToShortDateString();
                    receiver.ReadTime = Time.Now.ToShortTimeString();
                    receiver.Status = MessageStatus.Read;
                    receiver.Save();
                    count++;
                }
            }
            rMessageBox.ShowInformation("تعداد {0} پیام علامت زده شد.", count);
        }
    }
}
