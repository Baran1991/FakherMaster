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
using Fakher.Core.SMS;
using Telerik.WinControls;
using rComponents;

namespace Fakher.UI.Reception
{
    public partial class frmStoreSetting : rRadForm
    {
        private string mKey;
        public frmStoreSetting(string key)
        {
            InitializeComponent();
            mKey = key;
            Fill();
        }
        private void Fill()
        {
            rTxtTemplate.Text = AppSetting.GetSetting(mKey);
        }

        private void Save()
        {
            AppSetting.SetSetting(mKey, rTxtTemplate.Text.Trim());
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
    }
}
