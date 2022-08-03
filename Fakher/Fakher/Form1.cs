using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Properties;
using rComponents;
using rFormProcessor;
using rTwain;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Fakher
{
    public partial class Form1 : rRadForm
    {
        private rFormProcessor.rFormProcessor mFormProcessor;

        public Form1()
        {
            InitializeComponent();

            mFormProcessor = new rFormProcessor.rFormProcessor();
            mFormProcessor.ShowDebugItem += new EventHandler<ItemEventArgs<Image>>(mFormProcessor_ShowDebugItem);
            Image formTemplate = Fakher.Resources.Properties.Resources.Answersheet120_300;
            pictureBox1.Image = formTemplate;
            mFormProcessor.InitializeFormDefinition300(formTemplate);

            rTwainControl1.Initialize(Handle);
        }

        void mFormProcessor_ShowDebugItem(object sender, ItemEventArgs<Image> e)
        {
            pictureBox1.Image = e.Item;
            rMessageBox.ShowInformation("");
        }

//        private void twainControl1_FinishScanning(object sender, FinishScanningEventArgs e)
//        {
//            if (e.scanned)
//            {
//                GC.Collect();
//                foreach (Bitmap bitmap in e.images)
//                {
//                    Bitmap convertedImage = TwainImageConverter.ConvertType(bitmap, ImageFormat.Jpeg);
//                    Process(convertedImage);
//                }
//            }
//
//        }

        private void Process(Bitmap bitmap)
        {
            ProcessResult processResult;
            try
            {
                processResult = mFormProcessor.Process(bitmap);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError("سیستم قادر به تصحیح این پاسخنامه نمی باشد. \r\n" + ex.Message);
                return;
            }

            ExamParticipate examParticipate = null;
            {
                if (!string.IsNullOrEmpty(processResult.Identifier))
                {
                    examParticipate = DbContext.FromId<ExamParticipate>(Convert.ToInt32(processResult.Identifier));
                }
                else
                {
                    rMessageBox.ShowError("سیستم قادر به تشخیص کدینگ این پاسخنامه نمی باشد.");
                    return;
                }
            }

            if (examParticipate != null)
            {
                //examParticipate.RawAnswers = processResult.Answers;
                //examParticipate.Save();
            }
            else
            {
                rMessageBox.ShowError("خطایی در تصحیح این پاسخنامه رخ داده است.");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rTwainControl1.ShowUI = true;
            rTwainControl1.SelectSource();
            rTwainControl1.Scan();
        }

        private void rTwainControl1_DocumentScanned(object sender, rTwain.DocumentScannedEventArgs e)
        {
            GC.Collect();
            Bitmap convertedImage = TwainImageConverter.ConvertType(e.Image, ImageFormat.Jpeg);
            Process(convertedImage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mFormProcessor.Test((Bitmap) Bitmap.FromFile(@"untitled.bmp"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            radDesktopAlert1.CaptionText = "عنوان یک";
            radDesktopAlert1.ContentText = " یک دو سه چهار ";
            radDesktopAlert1.PopupAnimation = true;
            radDesktopAlert1.Show();
        }
    }
}
