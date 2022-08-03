using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
    public partial class frmEmailDetail : rRadForm
    {
        private string mBody;

        public frmEmailDetail()
        {
            InitializeComponent();
            rPageView1.SelectedPage = rPageView1.Pages[0];
        }

        public frmEmailDetail(string toAddress) : this()
        {
            rTextBox4.Text = toAddress;
        }

        public frmEmailDetail(string toAddress, string body) : this()
        {
            rTextBox4.Text = toAddress;
            mBody = body;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(rTextBox4.Text.Trim()))
            {
                rMessageBox.ShowError("گیرنده ایمیل را مشخص کنید");
                return;
            }

            if(String.IsNullOrEmpty(rTextBox2.Text.Trim()))
            {
                rMessageBox.ShowError("عنوان ایمیل را مشخص کنید");
                return;
            }

            if(String.IsNullOrEmpty(rHtmlEditor1.BodyHtml.Trim()))
            {
                rMessageBox.ShowError("متن ایمیل را مشخص کنید");
                return;
            }

            try
            {
                InternetPostMaster.Send(InternetPostMaster.NoReply, new[] {new MailAddress(rTextBox4.Text.Trim())},
                                        rTextBox2.Text.Trim(), rHtmlEditor1.BodyHtml, true, false);
                rMessageBox.ShowInformation("ایمیل ارسال شد.");
                Close();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void frmEmailDetail_Shown(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(mBody))
                rHtmlEditor1.BodyHtml = mBody;
        }
    }
}
