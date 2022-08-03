using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Fakher.Controls
{
    public partial class CameraBox : UserControl
    {
        private Capture capture;
        public Image CapturedImage { get; set; }

        public CameraBox()
        {
            InitializeComponent();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            Image<Bgr, byte> frame = capture.QueryFrame();
            Bitmap bitmap = frame.ToBitmap();
            pictureBox2.Image = bitmap;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            CapturedImage = pictureBox1.Image = pictureBox2.Image;
        }

        public void StartCapture()
        {
            capture = new Capture();
            Application.Idle += new EventHandler(Application_Idle);
        }

        public new void Dispose()
        {
            Application.DoEvents();
            Application.Idle -= new EventHandler(Application_Idle);
            capture.Dispose();
        }
    }
}
