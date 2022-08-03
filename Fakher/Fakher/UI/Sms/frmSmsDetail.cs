using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core;
using rComponents;

namespace Fakher.UI
{
    public partial class frmSmsDetail : rRadForm
    {
        public frmSmsDetail()
        {
            InitializeComponent();
        }
        public frmSmsDetail(long number)
        {
            InitializeComponent();
            rTextBox4.Text = number.ToString();
            rTextBox4.Enabled = false;
        }
        public frmSmsDetail(string toAddress) : this()
        {
            rTextBox4.Text = toAddress;
        }

        private void rTxtSms_TextChanged(object sender, EventArgs e)
        {
            UpdateSmsLabel();
        }

        private void UpdateSmsLabel()
        {
            int pages = rTxtSms.Text.Length / 70;
            rLblSms.Text = string.Format("{0}/259 ({1} صفحه)", rTxtSms.Text.Length, (pages + 1));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(rTextBox4.Text.Trim()))
            {
                rMessageBox.ShowError("گیرنده را مشخص کنید");
                return;
            }

            if (String.IsNullOrEmpty(rTxtSms.Text.Trim()))
            {
                rMessageBox.ShowError("متن را مشخص کنید");
                return;
            }
            if(rMessageBox.ShowQuestion("آیا از ارسال پیامک مطمین هستید ؟ ")==DialogResult.No)
            {
                return;
            }
            try
            {
                SmsGroup smsGroup = new SmsGroup();
                smsGroup.Text = rTxtSms.Text.Trim();
                smsGroup.Smses.Clear();
                smsGroup.Status = SmsGroupStatus.Created;
                smsGroup.ReceiverText = rTextBox4.Text.Trim();

                Sms sms = smsGroup.CreateSms();
                sms.Number = rTextBox4.Text.Trim();
                smsGroup.AddSms(sms);

                SmsPostMaster.Send(smsGroup);

                smsGroup.Status = SmsGroupStatus.Sent;
                smsGroup.Save();

                rMessageBox.ShowInformation("پیامک ارسال شد.");
                Close();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
    }
}
