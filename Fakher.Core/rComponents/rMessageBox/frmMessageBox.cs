using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace rComponents
{
    public partial class frmMessageBox : RadForm
    {
        public string Title { get; set; }
        public string MessageText { get; set; }
        public string Button1Text { get; set; }
        public string Button2Text { get; set; }
        public MessageBoxIcon Icon { get; set; }

        public frmMessageBox()
        {
            InitializeComponent();
        }

        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            Text = Title;
            lblMessage.Text = MessageText;
            if(!string.IsNullOrEmpty(Button1Text))
                radButton1.Text = Button1Text;
            if (!string.IsNullOrEmpty(Button2Text))
                radButton1.Text = Button2Text;

            radButton1.DialogResult = DialogResult.OK;
            radButton2.DialogResult = DialogResult.Cancel;

            if (Icon == MessageBoxIcon.Information)
            {
                pictureBox2.Image = imageList1.Images["Info"];
                radButton1.Text = "تــایــیــد";
                radButton2.Visible = false;
                radLabel1.Text = String.Format(radLabel1.Text, "آگاهی");
                Height -= 41;
            }

            if (Icon == MessageBoxIcon.Question)
            {
                radLabel1.Text = String.Format(radLabel1.Text, "تصمیم");
                pictureBox2.Image = imageList1.Images["Question"];
                radButton1.DialogResult = DialogResult.Yes;
                radButton2.DialogResult = DialogResult.No;
            }

            if (Icon == MessageBoxIcon.Error)
            {
                pictureBox2.Image = imageList1.Images["Error"];
                radButton1.Text = "تــایــیــد";
                radButton2.Visible = false;
                radLabel1.Text = String.Format(radLabel1.Text, "آگاهی");
                Height -= 41;
            }

            if (Icon == MessageBoxIcon.Warning)
            {
                pictureBox2.Image = imageList1.Images["Warning"];
                radButton1.Text = "تــایــیــد";
                radButton2.Visible = false;
                radLabel1.Text = String.Format(radLabel1.Text, "آگاهی");
                Height -= 41;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
//            if (Icon == MessageBoxIcon.Information)
//                DialogResult = DialogResult.OK;

//            Close();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
