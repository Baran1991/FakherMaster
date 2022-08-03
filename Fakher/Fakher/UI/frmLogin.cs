using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher
{
    public partial class frmLogin : Form
    {
        private bool customChange;

        public frmLogin()
        {
            InitializeComponent();
            Program.StartupText += new EventHandler<StartupEventArgs>(Program_StartupText);
        }

        void Program_StartupText(object sender, StartupEventArgs e)
        {
            Invoke(new Program.VoidWithStringDelegate(SetLabel), e.Text);
        }

        public void StartWait(bool showProgressBar)
        {
            textBox1.Enabled = textBox2.Enabled = btnAuth.Enabled = false;
            lblBottomMessage.Visible = true;
            if (showProgressBar)
                lblWait.Visible = true;
            Application.UseWaitCursor = true;
            Application.DoEvents();
        }

        public void SetLabel(string text)
        {
            lblBottomMessage.Text = text;
            lblBottomMessage.Refresh();
        }

        public void StartWait(bool showProgressBar, string text)
        {
            SetLabel(text);
            StartWait(showProgressBar);
        }

        public void EndWait()
        {
            textBox1.Enabled = textBox2.Enabled = btnAuth.Enabled = true;
            lblBottomMessage.Visible = false;
            lblWait.Visible = false;
            textBox1.Focus();
            Application.UseWaitCursor = false;
            Application.DoEvents();
        }

        public void ShowSafePicture()
        {
            if (Program.CurrentPerson == null)
                return;

            try
            {
                Image image = null;

                if (Program.CurrentPerson.Photo.Picture != null)
                    image = Program.CurrentPerson.Photo.Picture;
                else
                {
                    if (Program.CurrentPerson.Gender == Gender.Male)
                        image = Resources.Properties.Resources.male;
                    else
                        image = Resources.Properties.Resources.female;
                }

                pictureBox3.Image = image;
                pnlPicture.Visible = true;
                pictureBox3.Refresh();
                Application.DoEvents();
            }
            catch (Exception e)
            {

            }
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            string username = Services.NormalizeFarsiString(textBox1.Text);
            string password = Services.NormalizeFarsiString(textBox2.Text);

            if (String.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "نام کاربری و رمز عبور را وارد کنید.";
                textBox1.Focus();
                return;
            }

            lblMessage.Text = "";
            StartWait(true, "احـراز هـویـت...");
            backgroundWorker1.RunWorkerAsync(new string[] { username, password });
        }

        private void Decline()
        {
            int step = 20;
            int time = 150;

            Application.DoEvents();
            Left -= step;
            Application.DoEvents();
            Thread.Sleep(time);
            Left += 2 * step;
            Application.DoEvents();
            Thread.Sleep(time);
            Left -= 2 * step;
            Application.DoEvents();
            Thread.Sleep(time);
            Left += 2 * step;
            Application.DoEvents();
            Thread.Sleep(time);
            Left -= step;
            Application.DoEvents();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] args = e.Argument as string[];
            string username = args[0];
            string password = args[1];
            Person loggedInPerson;
            try
            {
                e.Result = false;
                string encUsername = UserInfo.Encrypt(username);
                string encPassword = UserInfo.Encrypt(password);

                loggedInPerson = Person.FromLogin(encUsername, encPassword);
                //                loggedInPerson = Person.FromLogin(username, password);
                if (loggedInPerson != null)
                {
                    if (!Program.CanSignin(loggedInPerson))
                        throw new Exception("ورود شما به سیستم مجاز نیست");

                    if(PersianDate.Today < loggedInPerson.UserInfo.LastSigninDate)
                        throw new Exception("تاریخ سیستم شما، معتبر نیست");
                    if (PersianDate.Today > loggedInPerson.UserInfo.ExpireDate)
                        throw new Exception("تاریخ اعتبار شما، منقضی شده است");


                    Invoke(new Program.VoidWithStringDelegate(SetLabel), "راه اندازی زیر سیستم ها...");
                    e.Result = true;
                    Program.Signin(loggedInPerson);
                    Program.SaveLog("ورود به سیستم جامع");
                    Invoke(new Program.VoidDelegate(ShowSafePicture));
                    Invoke(new Program.VoidDelegate(Program.Start));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                EndWait();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                lblMessage.Text = "نام کاربری/گذرواژه صحیح نیست.";
                Decline();
                textBox2.SelectAll();
                textBox2.Focus();
                EndWait();
                return;
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            backgroundWorker1.Dispose();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.SelectAll();
        }

        private void lnkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }
    }
}
