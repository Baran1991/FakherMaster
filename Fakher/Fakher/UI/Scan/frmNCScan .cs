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
    public partial class frmNCScan : rRadForm
    {
        private string mSavePath;
        private Core.DomainModel.Person selectedperson;
        public frmNCScan(Core.DomainModel.Person person)
        {
            InitializeComponent();
            selectedperson = person;
            SetProcessingObject(person);
        }

        private void lnkNCScan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                rMessageBox.ShowWarning("لطفا مدارک مورد نظر رادر دستگاه قرار دهید");
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

        private void lnk_DelNC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NCpictureBox1.Image = null;
            selectedperson.Photo.NCPicture1 = null;
            selectedperson.Photo.NCPictureBytes1 = null;
        }

        private void lnkNCUploading_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image File|*.jpg;*.tif;*.tiff;*.bmp;*.png;*.gif";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;
            NCpictureBox1.Image = Image.FromFile(dialog.FileName);
        }

        private void lnk_OkNC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NCpictureBox1.Image != null)
            {
                FolderBrowserDialog dialog1 = new FolderBrowserDialog();
                if (dialog1.ShowDialog(this) != DialogResult.OK)
                    return;
                mSavePath = dialog1.SelectedPath;

                string fileName = selectedperson.EnglishFullname + " - " + selectedperson.NationalCode;
                NCpictureBox1.Image.Save(mSavePath + "\\" + fileName + ".jpg", ImageFormat.Jpeg);
                rMessageBox.ShowInformation(string.Format("عکس کارت ملی(رو) [{0}] با موفقیت ذخیره گردید.",
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
            NCpictureBox1.Image = jpegImage;
            jpegImage.Dispose();
        }

        private void lnkPrint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NCpictureBox1.Image != null)
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
            Bitmap bm = new Bitmap(NCpictureBox1.Width, NCpictureBox1.Height);
            NCpictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, NCpictureBox1.Width, NCpictureBox1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (NCpictureBox1.Image != null && NCpictureBox2.Image!=null)
            {
                Bitmap convertType1 = TwainImageConverter.ConvertType(new Bitmap(NCpictureBox1.Image), ImageFormat.Jpeg);
                Bitmap convertType2 = TwainImageConverter.ConvertType(new Bitmap(NCpictureBox1.Image), ImageFormat.Jpeg);

                selectedperson.Photo.NCPicture1 = new Bitmap(convertType1);
                selectedperson.Photo.NCPicture2 = new Bitmap(convertType1);

                convertType1.Dispose();
                convertType1.Dispose();

            }
            selectedperson.Save();
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkNCScan2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                rMessageBox.ShowWarning("لطفا مدارک مورد نظر رادر دستگاه قرار دهید");
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

        private void lnkNCUploading2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image File|*.jpg;*.tif;*.tiff;*.bmp;*.png;*.gif";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;
            NCpictureBox2.Image = Image.FromFile(dialog.FileName);
        }

        private void lnk_OkNC2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NCpictureBox2.Image != null)
            {
                FolderBrowserDialog dialog1 = new FolderBrowserDialog();
                if (dialog1.ShowDialog(this) != DialogResult.OK)
                    return;
                mSavePath = dialog1.SelectedPath;

                string fileName = selectedperson.EnglishFullname + " - " + selectedperson.NationalCode;
                NCpictureBox2.Image.Save(mSavePath + "\\" + fileName + "2.jpg", ImageFormat.Jpeg);
                rMessageBox.ShowInformation(string.Format("عکس کارت ملی(پشت) [{0}] با موفقیت ذخیره گردید.",
                                                          selectedperson.FarsiFullname));
            }
            else
                rMessageBox.ShowInformation("تصویر موجود نمی باشد.");
        }

        private void lnk_DelNC2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NCpictureBox2.Image = null;
            selectedperson.Photo.NCPicture2 = null;
            selectedperson.Photo.NCPictureBytes2 = null;
        }

        private void lnkPrint2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NCpictureBox2.Image != null)
            {
                PrintDialog pd = new PrintDialog();
                PrintDocument doc = new PrintDocument();
                doc.PrintPage += Doc_PrintPage2;
                pd.Document = doc;
                if (pd.ShowDialog() == DialogResult.OK)
                    doc.Print();
            }
            else
                rMessageBox.ShowInformation("تصویر موجود نمی باشد.");
        }
        private void Doc_PrintPage2(object sender, PrintPageEventArgs e)
        {
            //Print image
            Bitmap bm = new Bitmap(NCpictureBox2.Width, NCpictureBox2.Height);
            NCpictureBox2.DrawToBitmap(bm, new Rectangle(0, 0, NCpictureBox2.Width, NCpictureBox2.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }

        private void frmNCScan_Load(object sender, EventArgs e)
        {
            NCpictureBox1.Image = selectedperson.Photo.NCPicture1;
            NCpictureBox2.Image = selectedperson.Photo.NCPicture2;

        }
    }
}
