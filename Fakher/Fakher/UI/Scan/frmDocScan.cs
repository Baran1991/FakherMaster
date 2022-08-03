using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;
using Fakher.Core;
using Fakher.Core.DomainModel;
using rComponents;
using rFormProcessor;
using rTwain;
using System.IO;

namespace Fakher.UI
{
    public partial class frmDocScan : rRadForm
    {
        private string mSavePath=@"D:\DocPic";
        private Core.DomainModel.Person selectedperson;
        PictureBox[] pics = new PictureBox[50];
        LinkLabel[] lnk = new LinkLabel[50];
        Button[] butns = new Button[50];
        Button[] butnsUp = new Button[50];

        FlowLayoutPanel[] flws = new FlowLayoutPanel[50];
        static int brh = 0;

        public frmDocScan(Core.DomainModel.Person person)
        {
            InitializeComponent();
            selectedperson = person;
            SetProcessingObject(person);
        }
        private void lnkDocScan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                rTwainControl1.ShowUI = true;
                rTwainControl1.SelectSource();
                rTwainControl1.Scan();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
        private void rTwainControl1_DocumentScanned(object sender, rTwain.DocumentScannedEventArgs e)
        {
            GC.Collect();
            Bitmap convertedImage = TwainImageConverter.ConvertType(e.Image, ImageFormat.Jpeg);
            string fileName = selectedperson.EnglishFullname + " - " + selectedperson.NationalCode;
            if (!Directory.Exists("D:\\DocPic"))
            {
                Directory.CreateDirectory("D:\\DocPic");
            }            
            convertedImage.Save("D:\\DocPic" + fileName + ".jpg", ImageFormat.Jpeg);
            PictureBox pb = new PictureBox();
            pb.Image = convertedImage;            
            if (e.Image == null)
                return;
        }
        private void rTwainControl1_ScanFinished(object sender, EventArgs e)
        {
            rMessageBox.ShowInformation("اسکن با موفقیت انجام شد و در مسیر مورد نظر ذخبره گردبد.");
        }

        public void lnkDocUploading_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter =
            "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
            "All files (*.*)|*.*";

            openFileDialog1.Multiselect = true;
            DialogResult dr = openFileDialog1.ShowDialog();
            int i = 1;
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        PictureBox pb = new PictureBox();
                        Image loadedImage = Image.FromFile(file);
                        pb.Height = 300;
                        pb.Width = 300;
                        pb.Image = loadedImage;
                        pb.Click += new EventHandler(picture_click);
                        pb.Name = selectedperson.EnglishFullname +"_"+ selectedperson.NationalCode+i;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        flowLayoutPanel1.Controls.Add(pb);
                        i++;
                        //pb.Image.Save(mSavePath);
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                            "Error message: " + ex.Message + "\n\n" +
                            "Details (send to Support):\n\n" + ex.StackTrace
                        );
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }
            }
        }
        private PictureBox _selectedPicture;
        void picture_click(object sender, EventArgs e)
        {
            _selectedPicture.Image.Save(@"D:\DocPic");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (!Directory.Exists(mSavePath))
            {
                Directory.CreateDirectory(mSavePath);
            }
            Control[] ctrls = flowLayoutPanel1.Controls.Find("selectedperson.EnglishFullname", false);

            // Note: only one can be selected (made active), so if Find returns more than one,
            // the last one in array will be the selected control using this loop...
            //foreach (Control c in ctrls)
                

        }
    }
}
