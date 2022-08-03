using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rComponents;

namespace Fakher.UI.Exam.AnswersheetReader
{
    public partial class frmDataEntry : rRadDetailForm
    {
        public string EntryText
        {
            get { return rTextBox1.Text.Trim(); }
        }

        public frmDataEntry(string topMessage, string labelMessage, Bitmap bitmap, string entryText)
        {
            InitializeComponent();

            rLabel2.Text = topMessage;
            rLabel1.Text = labelMessage;
            pictureBox1.Image = bitmap;
            rTextBox1.Text = entryText;
            rTextBox1.SelectAll();
        }
    }
}
