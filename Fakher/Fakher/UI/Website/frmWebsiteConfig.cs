using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.WinControls.UI;
using rComponents;

namespace Fakher.UI.Website
{
    public partial class frmWebsiteConfig : rRadForm
    {
        public frmWebsiteConfig()
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Id" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });

            rGridCmbPoll.Columns.Add("نام نظرسنجی", "نام نظرسنجی", "Name");
            rGridCmbPoll.Columns.Add("تاریخ شروع", "تاریخ شروع", "StartDateText");
            rGridCmbPoll.Columns.Add("تاریخ پایان", "تاریخ پایان", "EndDateText");

            rCmbWebsiteStatus.DataSource = typeof (WebsiteStatus).GetEnumDescriptions();
            
            rCmbJudicialConsultationStatus.DataSource = typeof (ConsultationStatus).GetEnumDescriptions();
            rCmbEducationalStatus.DataSource = typeof (ConsultationStatus).GetEnumDescriptions();

            Fill();
        }

        private void Fill()
        {
            IQueryable<Webpage> articles = Webpage.GetWebpages(WebpageType.Article);
            rGridView1.DataBind(articles);

            string webgozarShow = AppSetting.GetSetting(WebsiteHandler.WebgozarSettingKey);
            rChkWebgozar.Checked = Convert.ToBoolean(webgozarShow);

            string frontpagePollShow = AppSetting.GetSetting(WebsiteHandler.ShowFrontpagePollKey);
            rChkPoll.Checked = Convert.ToBoolean(frontpagePollShow);
            rGridCmbPoll.Enabled = rChkPoll.Checked;

            IList<Core.DomainModel.Poll.Poll> polls = Core.DomainModel.Poll.Poll.GetAllPolls();
            rGridCmbPoll.DataSource = polls;

            string frontpagePollId = AppSetting.GetSetting(WebsiteHandler.FrontpagePollIdKey);
            if(!string.IsNullOrEmpty(frontpagePollId))
            {
                Core.DomainModel.Poll.Poll poll = Core.DomainModel.Poll.Poll.FromId(Convert.ToInt32(frontpagePollId));
                if (poll != null)
                {
                    rGridCmbPoll.Value = poll;
                }
            }

            rChkSectionAttachment.Checked = Convert.ToBoolean(AppSetting.GetSetting(WebsiteHandler.SectionAttachmentKey));
            rChkSectionPoll.Checked = Convert.ToBoolean(AppSetting.GetSetting(WebsiteHandler.SectionPollKey));
            rChkExamAttachment.Checked = Convert.ToBoolean(AppSetting.GetSetting(WebsiteHandler.ExamAttachmentKey));
            rChkExamPoll.Checked = Convert.ToBoolean(AppSetting.GetSetting(WebsiteHandler.ExamPollKey));

            rChkOnlineExamEnrollment.Checked = Convert.ToBoolean(AppSetting.GetSetting(WebsiteHandler.OnlineExamEnrollmentKey));
            rChkOralExamEnrollment.Checked = Convert.ToBoolean(AppSetting.GetSetting(WebsiteHandler.OralExamEnrollmentKey));

            rChkBookShow.Checked = Convert.ToBoolean(AppSetting.GetSetting(WebsiteHandler.BookShowKey));
            rChkBookShop.Checked = Convert.ToBoolean(AppSetting.GetSetting(WebsiteHandler.BookShopKey));

            rCmbWebsiteStatus.SelectedIndex = Convert.ToInt32(AppSetting.GetSetting(WebsiteHandler.WebsiteStatus));
            rTxtWebsiteStatusDescription.Text = Convert.ToString(AppSetting.GetSetting(WebsiteHandler.WebsiteStatusDescription));

            int count = Convert.ToInt32(AppSetting.GetSetting(WebsiteHandler.BookShowCount));
            if(count != 0)
                foreach (RadListDataItem item in rCmbBookShowCount.Items)
                {
                    if(item.Text == count.ToString())
                    {
                        item.Selected = true;
                        break;
                    }
                }

            rCmbJudicialConsultationStatus.SelectedIndex = Convert.ToInt32(AppSetting.GetSetting(WebsiteHandler.JudicialConsultationStatus));
            rTxtJudicialConsultationDescription.Text = Convert.ToString(AppSetting.GetSetting(WebsiteHandler.JudicialConsultationStatusDescription));
            rJudicialDatePicker1.Date = PersianDate.FromString(AppSetting.GetSetting(WebsiteHandler.JudicialConsultationStartDate));
            rTxtJudicialConsultationStartTime.Text = AppSetting.GetSetting(WebsiteHandler.JudicialConsultationStartTime);
            rJudicialDatePicker2.Date = PersianDate.FromString(AppSetting.GetSetting(WebsiteHandler.JudicialConsultationEndDate));
            rTxtJudicialConsultationEndTime.Text = AppSetting.GetSetting(WebsiteHandler.JudicialConsultationEndTime);

            rCmbEducationalStatus.SelectedIndex = Convert.ToInt32(AppSetting.GetSetting(WebsiteHandler.EducationalConsultationStatus));
            rTxtEducationalDescription.Text = Convert.ToString(AppSetting.GetSetting(WebsiteHandler.EducationalConsultationStatusDescription));
            rEducationalDatePicker1.Date = PersianDate.FromString(AppSetting.GetSetting(WebsiteHandler.EducationalConsultationStartDate));
            rTxtEducationalStartTime.Text = AppSetting.GetSetting(WebsiteHandler.EducationalConsultationStartTime);
            rEducationalDatePicker2.Date = PersianDate.FromString(AppSetting.GetSetting(WebsiteHandler.EducationalConsultationEndDate));
            rTxtEducationalEndTime.Text = AppSetting.GetSetting(WebsiteHandler.EducationalConsultationEndTime);


            string imageBytes = AppSetting.GetSetting(WebsiteHandler.SlideshowImages);
            imageList1.Images.Clear();
            listView1.Items.Clear();
            if (!string.IsNullOrEmpty(imageBytes))
            {
                string[] items = imageBytes.Split(new[] { WebsiteHandler.SlideshowSeparator}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in items)
                {
                    if(string.IsNullOrEmpty(item))
                        continue;
                    byte[] bytes = Convert.FromBase64String(item);
                    AddImage(bytes);
                }
            }
        }

        private void AddImage(byte[] bytes)
        {
            Image image = Image.FromStream(new MemoryStream(bytes));
            imageList1.Images.Add(image);
            ListViewItem item = new ListViewItem();
            item.ImageIndex = imageList1.Images.Count - 1;
            item.Tag = bytes;
            listView1.Items.Add(item);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Webpage currentWebpage = rGridView1.GetSelectedObject<Webpage>();
            int index = rGridView1.DataSource.IndexOf(currentWebpage);
            if (index == 0)
                return;

            Webpage prevWebpage = rGridView1.DataSource[index - 1] as Webpage;
            int currentPosition = currentWebpage.Position;

            currentWebpage.Position = prevWebpage.Position;
            prevWebpage.Position = currentPosition;

//            webpage.Position++;
//            webpage.Save();

            currentWebpage.Save();
            prevWebpage.Save();

            Fill();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Webpage currentWebpage = rGridView1.GetSelectedObject<Webpage>();
            int index = rGridView1.DataSource.IndexOf(currentWebpage);
            if (index == rGridView1.DataSource.Count - 1)
                return;

            Webpage nextWebpage = rGridView1.DataSource[index + 1] as Webpage;
            int currentPosition = currentWebpage.Position;

            currentWebpage.Position = nextWebpage.Position;
            nextWebpage.Position = currentPosition;

            //            webpage.Position--;
            //            webpage.Save();

            currentWebpage.Save();
            nextWebpage.Save();

            Fill();
        }

        private bool ValidateSettings()
        {
            if(rCmbWebsiteStatus.SelectedIndex > 0)
            {
                if (rMessageBox.ShowQuestion("از تغییر حالت وب سایت به {0} مطمئن هستید؟", rCmbWebsiteStatus.Text) != DialogResult.Yes)
                    return false;
            }
            return true;
        }

        private void Save()
        {
            AppSetting.SetSetting(WebsiteHandler.WebgozarSettingKey, rChkWebgozar.Checked + "");

            AppSetting.SetSetting(WebsiteHandler.ShowFrontpagePollKey, rChkPoll.Checked + "");

            Core.DomainModel.Poll.Poll poll = rGridCmbPoll.GetValue<Core.DomainModel.Poll.Poll>();
            if(poll != null)
            {
                AppSetting.SetSetting(WebsiteHandler.FrontpagePollIdKey, poll.Id + "");
            }

            AppSetting.SetSetting(WebsiteHandler.SectionAttachmentKey, rChkSectionAttachment.Checked + "");
            AppSetting.SetSetting(WebsiteHandler.SectionPollKey, rChkSectionPoll.Checked + "");
            AppSetting.SetSetting(WebsiteHandler.ExamAttachmentKey, rChkExamAttachment.Checked + "");
            AppSetting.SetSetting(WebsiteHandler.ExamPollKey, rChkExamPoll.Checked + "");

            AppSetting.SetSetting(WebsiteHandler.OnlineExamEnrollmentKey, rChkOnlineExamEnrollment.Checked + "");
            AppSetting.SetSetting(WebsiteHandler.OralExamEnrollmentKey, rChkOralExamEnrollment.Checked + "");

            AppSetting.SetSetting(WebsiteHandler.BookShowKey, rChkBookShow.Checked + "");
            AppSetting.SetSetting(WebsiteHandler.BookShowCount, rCmbBookShowCount.SelectedItem.Text + "");
            AppSetting.SetSetting(WebsiteHandler.BookShopKey, rChkBookShop.Checked + "");

            AppSetting.SetSetting(WebsiteHandler.WebsiteStatus, rCmbWebsiteStatus.SelectedIndex + "");
            AppSetting.SetSetting(WebsiteHandler.WebsiteStatusDescription, rTxtWebsiteStatusDescription.Text.Trim());

            AppSetting.SetSetting(WebsiteHandler.JudicialConsultationStatus, rCmbJudicialConsultationStatus.SelectedIndex + "");
            AppSetting.SetSetting(WebsiteHandler.JudicialConsultationStatusDescription, rTxtJudicialConsultationDescription.Text.Trim());
            AppSetting.SetSetting(WebsiteHandler.JudicialConsultationStartDate, rJudicialDatePicker1.Date + "");
            AppSetting.SetSetting(WebsiteHandler.JudicialConsultationStartTime, rTxtJudicialConsultationStartTime.Text);
            AppSetting.SetSetting(WebsiteHandler.JudicialConsultationEndDate, rJudicialDatePicker2.Date + "");
            AppSetting.SetSetting(WebsiteHandler.JudicialConsultationEndTime, rTxtJudicialConsultationEndTime.Text);

            AppSetting.SetSetting(WebsiteHandler.EducationalConsultationStatus, rCmbEducationalStatus.SelectedIndex + "");
            AppSetting.SetSetting(WebsiteHandler.EducationalConsultationStatusDescription, rTxtEducationalDescription.Text.Trim());
            AppSetting.SetSetting(WebsiteHandler.EducationalConsultationStartDate, rEducationalDatePicker1.Date + "");
            AppSetting.SetSetting(WebsiteHandler.EducationalConsultationStartTime, rTxtEducationalStartTime.Text);
            AppSetting.SetSetting(WebsiteHandler.EducationalConsultationEndDate, rEducationalDatePicker2.Date + "");
            AppSetting.SetSetting(WebsiteHandler.EducationalConsultationEndTime, rTxtEducationalEndTime.Text);

            byte[][] images = listView1.Items.Cast<ListViewItem>().Select(x => x.Tag as byte[]).ToArray();
            string bytesText = "";
            foreach (byte[] image in images)
                bytesText += Convert.ToBase64String(image) + WebsiteHandler.SlideshowSeparator;
            AppSetting.SetSetting(WebsiteHandler.SlideshowImages, bytesText);
        }

        private void radBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateSettings())
                    return;
                Program.StartWaiting();
                Save();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
            finally
            {
                Program.EndWaiting();
            }

            Close();
        }

        private void rChkPoll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rGridCmbPoll.Enabled = rChkPoll.Checked;
        }

        private void rCmbConsultationStatus_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void toolStripBtnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image|*.jpg;*.jpeg;*.png;*.gif;*.tif";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            byte[] bytes = File.ReadAllBytes(dialog.FileName);
            AddImage(bytes);
        }

        private void toolStripBtnRemoveImage_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                rMessageBox.ShowWarning("یک عکس را انتخاب کنید");
                return;
            }
            
            ListViewItem selectedItem = listView1.SelectedItems[0];
            listView1.Items.Remove(selectedItem);
        }
    }
}
