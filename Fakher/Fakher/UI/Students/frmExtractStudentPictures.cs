using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;
using DataAccessLayer;

namespace Fakher.UI.Students
{
    public partial class frmExtractStudentPictures : rRadDetailForm
    {
        private string mPath;

        public frmExtractStudentPictures()
        {
            InitializeComponent();
        }

        private void lnkPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;
            mPath = dialog.SelectedPath;
            rLabel2.Text = mPath;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            string numbers = rTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(mPath))
            {
                rMessageBox.ShowError("مسیر ذخیره عکس ها را مشخص کنید.");
                return;
            }
            if(string.IsNullOrEmpty(numbers))
            {
                rMessageBox.ShowError("شماره های دانشجویی را وارد کنید.");
                return;
            }
            string[] codes = numbers.Split('\r', '\n');
            string errors = "";
            string noImages = "";
            int count = 0;

            progressBar1.Maximum = codes.Length;
            progressBar1.Value = 0;

            foreach (string code in codes)
            {
                if (progressBar1.Value < progressBar1.Maximum)
                {
                    progressBar1.Increment(1);
                    Application.DoEvents();
                }

                if (string.IsNullOrEmpty(code))
                    continue;

                Register register = Register.FromCode(code).FirstOrDefault();
                if (register == null)
                    errors += code + ", ";
                else
                {
                    if (register.Student.Photo.Picture == null)
                    {
                        noImages += code + ", ";
                    }
                    else
                    {
//                        try
//                        {
//                            register.Student.Photo.CorrectPhoto(DbContext.CurrentSession.Connection);
//                            register.Student.Photo.RefreshEntity();
//                        }
//                        catch (Exception)
//                        {
//                        }
                        string fileName = register.Student.FarsiFullname + " - " + register.Major.Name + " - " +
                                          register.Period.Department.Name;
                        register.Student.Photo.Picture.Save(mPath + "\\" + fileName + ".jpg", ImageFormat.Jpeg);
                        count++;
                    }
                }
            }

            if (!string.IsNullOrEmpty(errors))
                rMessageBox.ShowError("دانشجویی با این شماره ها پیدا نشد؛ " + errors);
            if (!string.IsNullOrEmpty(noImages))
                rMessageBox.ShowError("این دانشجوها عکس ندارند؛ " + noImages);

            progressBar1.Value = 0;
            rMessageBox.ShowInformation("تعداد {0} عکس استخراج شد.", count);
        }
    }
}
