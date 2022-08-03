using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rComponents;
using Telerik.WinControls.UI;

namespace Fakher
{
    public partial class frmCapture : rRadForm
    {
        public Image CapturedImage { get; set; }

        public frmCapture()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CapturedImage = cameraBox1.CapturedImage;
        }

        private void frmCapture_Load(object sender, EventArgs e)
        {
            try
            {
                cameraBox1.StartCapture();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError("دوربین دیجیتال شناسایی نشد.");
                Close();
                return;
            }
        }

        private void frmCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            cameraBox1.Dispose();
        }
    }
}
