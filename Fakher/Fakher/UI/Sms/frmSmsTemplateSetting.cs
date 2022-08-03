using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.SMS;
using Telerik.WinControls;
using rComponents;

namespace Fakher.UI.Reception
{
    public partial class frmSmsTemplateSetting : rRadForm
    {
        public frmSmsTemplateSetting()
        {
            InitializeComponent();
            Fill();
        }
        private void Fill()
        {
            rTxtRequestTemplate.Text = AppSetting.GetSetting(SmsHandler.RequestTemplate);
        }

        private void Save()
        {
            AppSetting.SetSetting(SmsHandler.RequestTemplate, rTxtRequestTemplate.Text);
        }
        private void radBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
                Close();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
            }
        }

        private void frmRequestSmsSetting_Load(object sender, EventArgs e)
        {

        }

        private void lnkSmartWords_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rTxtRequestTemplate.Text += " " + ((LinkLabel)sender).Tag + " ";
        }
    }
}
