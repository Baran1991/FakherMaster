using System;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.SystemFeatures
{
    public partial class frmPersonPassword : rRadDetailForm
    {
//        private UserInfo userInfo;
        public frmPersonPassword(UserInfo userInfo)
        {
            InitializeComponent();
            SetProcessingObject(userInfo);
//            this.userInfo = userInfo;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = GetProcessingObject<UserInfo>();

            string pass = rTextBox1.Text;
            string newPass = rTextBox2.Text;
            if(rTextBox2.Text != rTextBox3.Text)
            {
                rMessageBox.ShowError("رمز عبور جدید و تکرار آن با هم برابر نیستند.");
                CancelClosing();
                rTextBox3.SelectAll();
                rTextBox3.Focus();
                return;
            }

            if(userInfo.Password != UserInfo.Encrypt(pass))
            {
                rMessageBox.ShowError("رمز قبلی صحیح نیست.");
                CancelClosing();
                rTextBox1.Focus();
                rTextBox1.SelectAll();
                return;
            }

            userInfo.SetPassword(newPass);
//            userInfo.Password = newPass;
            userInfo.Save();
            rMessageBox.ShowInformation("تغییر رمز با موفقیت انجام شد.");
            Close();
        }
    }
}
