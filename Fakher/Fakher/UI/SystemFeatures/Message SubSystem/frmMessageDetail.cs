using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;
using Message = Fakher.Core.DomainModel.Message;
using Person = Fakher.Core.DomainModel.Person;

namespace Fakher.UI.SystemFeatures
{
    public partial class frmMessageDetail : rRadDetailForm
    {
        public frmMessageDetail(Message message)
        {
            InitializeComponent();

            rPageView1.SelectedPage = rPageView1.Pages[0];

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox2,
                                        ControlProperty = "Text",
                                        DataObject = message,
                                        ObjectProperty = "Subject"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox3,
                                        ControlProperty = "Text",
                                        DataObject = message,
                                        ObjectProperty = "Body"
                                    });

            rTextBox4.Text = message.Sender.MessageAddress;

            foreach (MessageReceiver receiver in message.Receivers)
                receiverSelector1.AddReciever(receiver.Person);

            receiverSelector1.Focus();

            rGridViewAttachments.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            rGridViewAttachments.CustomButtons.Add(new rGridViewButton { Text = "نمایش", VisibleOnSelect = true, Position = rGridViewButtonPosition.After });
            rGridViewAttachments.CustomButtons.Add(new rGridViewButton { Text = "ذخیره", VisibleOnSelect = true, Position = rGridViewButtonPosition.After });
            rGridViewAttachments.DataBind(message.Attachments);

            if (message.HasAttachment)
            {
                radPageViewPage2.Text = "پیوست هــا (" + message.Attachments.Count + ")";
            }

            if (Program.CurrentPerson.Id == message.Sender.Id)
            {
                rGridViewAttachments.CanAdd = true;
                rGridViewAttachments.CanDelete = true;
            }
            else
            {
                rGridViewAttachments.CanAdd = false;
                rGridViewAttachments.CanDelete = false;
            }
        }

        protected override void AfterBindToObject()
        {
            Message message = GetProcessingObject<Message>();

            if (!receiverSelector1.HasReciever)
            {
                rMessageBox.ShowError("گیرنده پیام را انتخاب کنید.");
                CancelClosing();
                return;
            }

            message.Receivers.Clear();
            foreach (Department department in receiverSelector1.SelectedDepartments)
                message.AddReceiver(department);
            foreach (Core.DomainModel.Person person in receiverSelector1.SelectedPersons)
                message.AddReceiver(person);

            message.Attachments.SyncWith(rGridViewAttachments.DataSource);
        }

        private void rGridViewAttachments_Add(object sender, EventArgs e)
        {
            Message message = GetProcessingObject<Message>();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            WebMedia media = WebMedia.FromFileName(dialog.FileName, WebMediaType.Attachment);
            rGridViewAttachments.Insert(media);
        }

        private void rGridViewAttachments_Delete(object sender, EventArgs e)
        {
            WebMedia media = rGridViewAttachments.GetSelectedObject<WebMedia>();
            rGridViewAttachments.RemoveSelectedRow();
        }

        private void SaveMedia(WebMedia media, string filename)
        {
            media.IncrementHits();
            media.SaveTo(filename);
            media.Save();
        }

        private void rGridViewAttachments_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            WebMedia media = rGridViewAttachments.GetSelectedObject<WebMedia>();

            if (e.ButtonIndex == 0) //View
            {
                string tempPath = Path.GetTempPath();
                string tempFileName = tempPath + "\\" + media.FileName;
                SaveMedia(media, tempFileName);
                Process.Start(tempFileName);
            }
            if (e.ButtonIndex == 1)
            {
                string ext = "*" + media.FileExtension;

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = string.Format("({0})|{0}", ext);
                dialog.FileName = media.FileName;
                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                SaveMedia(media, dialog.FileName);
                rMessageBox.ShowInformation("پیوست موردنظر در آدرس [{0} ذخیره گردید.]", dialog.FileName);
            }
        }
    }
}
