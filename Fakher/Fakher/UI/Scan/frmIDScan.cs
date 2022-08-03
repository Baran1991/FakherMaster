using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core;
using Fakher.Core.DomainModel;
using rComponents;
using rFormProcessor;
using rTwain;

namespace Fakher.UI
{
    public partial class frmIDScan : rRadForm
    {
        private string mSavePath;
        private Core.DomainModel.Person selectedperson;
        public frmIDScan(Core.DomainModel.Person person)
        {
            InitializeComponent();
            selectedperson = person;
            SetProcessingObject(person);
        }

        private void lnkIDScan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                rMessageBox.ShowInformation("لطفا مدارک مورد نظر رادر دستگاه قرار دهید");
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

        private void lnk_DelID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IDpictureBox.Image = null;
            selectedperson.Photo.IDPicture = null;
            selectedperson.Photo.IDPictureBytes = null;
        }

        private void lnkIDUploading_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image File|*.jpg;*.tif;*.tiff;*.bmp;*.png;*.gif";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;
            IDpictureBox.Image = Image.FromFile(dialog.FileName);           
        }

        private void lnk_OkID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IDpictureBox.Image != null)
            {
                FolderBrowserDialog dialog1 = new FolderBrowserDialog();
                if (dialog1.ShowDialog(this) != DialogResult.OK)
                    return;
                mSavePath = dialog1.SelectedPath;

                string fileName = selectedperson.EnglishFullname + " - " + selectedperson.NationalCode;
                IDpictureBox.Image.Save(mSavePath + "\\" + fileName + ".jpg", ImageFormat.Jpeg);
                rMessageBox.ShowInformation(string.Format("عکس شناسنامه [{0}] با موفقیت ذخیره گردید.",
                                                          selectedperson.FarsiFullname));
            }
            else
                rMessageBox.ShowInformation("تصویر موجود نمی باشد.");

        }
        private void rTwainControl1_ScanFinished(object sender, EventArgs e)
        {
            rMessageBox.ShowInformation("اسکن با موفقیت انجام شد");
        }
        private void rTwainControl1_DocumentScanned(object sender, DocumentScannedEventArgs e)
        {
            GC.Collect();
            if (e.Image == null)
                return;
            // For solving Exception "The input image format is not supported by ScanFix"
            Bitmap jpegImage = TwainImageConverter.ConvertType(e.Image, ImageFormat.Jpeg);
            IDpictureBox.Image = jpegImage;
            jpegImage.Dispose();
        }

        private void lnkPrint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IDpictureBox.Image != null)
            {
                PrintDialog pd = new PrintDialog();
                PrintDocument doc = new PrintDocument();
                doc.PrintPage += Doc_PrintPage;
                pd.Document = doc;
                if (pd.ShowDialog() == DialogResult.OK)
                    doc.Print();
            }
            else
                rMessageBox.ShowInformation("تصویر موجود نمی باشد.");
        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Print image
            Bitmap bm = new Bitmap(IDpictureBox.Width, IDpictureBox.Height);
            IDpictureBox.DrawToBitmap(bm, new Rectangle(0, 0, IDpictureBox.Width, IDpictureBox.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (IDpictureBox.Image != null)
            {
                Bitmap convertType = TwainImageConverter.ConvertType(new Bitmap(IDpictureBox.Image), ImageFormat.Jpeg);
                selectedperson.Photo.IDPicture = new Bitmap(convertType);
                convertType.Dispose();
            }
            selectedperson.Save();
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIDScan_Load(object sender, EventArgs e)
        {
            IDpictureBox.Image = selectedperson.Photo.IDPicture;
        }
    }
}
