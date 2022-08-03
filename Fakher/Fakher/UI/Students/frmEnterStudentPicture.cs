using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;
using rFormProcessor;
using rTwain;

namespace Fakher.UI.Educational.Students
{
    public partial class frmEnterStudentPicture : rRadForm
    {
        private string mPath;
        private float rotateAngle;

        public frmEnterStudentPicture()
        {
            InitializeComponent();

            rotateAngle = 0;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره پرونده", ObjectProperty = "Register.Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });
        }

        private void lnkPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog(this) != DialogResult.OK)
                return;
            mPath = dialog.SelectedPath;
            rLabel1.Text = mPath;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem == null)
                return;
            string file = listBox1.SelectedItem + "";
            pictureBox1.Image = Image.FromFile(file);
        }

        private void lnkOpenFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image File|*.jpg;*.tif;*.tiff;*.bmp;*.png;*.gif";
            if(dialog.ShowDialog(this) != DialogResult.OK)
                return;

            listBox1.Items.Clear();
            pictureBox1.Image = Image.FromFile(dialog.FileName);
        }

        private void radBtnSave_Click(object sender, EventArgs e)
        {
            Participate participate = rGridView1.GetSelectedObject<Participate>();
            if (participate == null)
                return;

            Bitmap convertType = TwainImageConverter.ConvertType(new Bitmap(pictureBox1.Image), ImageFormat.Jpeg);
            participate.Register.Student.Photo.Picture = new Bitmap(convertType);
            participate.Register.Student.Save();
            rMessageBox.ShowInformation(string.Format("عکس [{0}] با موفقیت ذخیره گردید.",
                                                      participate.Register.Student.FarsiFullname));
            convertType.Dispose();
        }

//        private void sectionSelector1_SelectedChanged(object sender, EventArgs e)
//        {
//            rGridView1.Clear();
//            if(sectionSelector1.Section == null)
//                return;
//            if(lessonSelector1.Lesson == null)
//                return;
//            rGridView1.DataBind(sectionSelector1.Section.GetParticipates(lessonSelector1.Lesson));
//        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            Participate participate = rGridView1.GetSelectedObject<Participate>();
            if(participate == null)
                return;

            rotateAngle = 0;
            pictureBox1.Image = participate.Register.Student.Photo.Picture;
            if (string.IsNullOrEmpty(mPath))
            {
                return;
            }
            string[] files = Directory.GetFiles(mPath);
            var query = from file in files
                        where Services.NormalizeFarsiString(file).Contains(participate.Register.Student.FarsiFirstName)
                        || Services.NormalizeFarsiString(file).Contains(participate.Register.Student.FarsiLastName)
                        select file;
            List<string> list = query.ToList();

            listBox1.Items.Clear();
            foreach (string file in list)
                listBox1.Items.Add(file);
        }

        private void radBtnRotateRight_Click(object sender, EventArgs e)
        {
            Participate participate = rGridView1.GetSelectedObject<Participate>();
            if (participate == null)
                return;
            if (participate.Register.Student.Photo.Picture == null)
                return;
            rotateAngle++;
            pictureBox1.Image = rImageProcessor.Rotate(participate.Register.Student.Photo.Picture, rotateAngle);
        }

        private void radBtnRotateLeft_Click(object sender, EventArgs e)
        {
            Participate participate = rGridView1.GetSelectedObject<Participate>();
            if (participate == null)
                return;
            if (participate.Register.Student.Photo.Picture == null)
                return;
            rotateAngle--;
            pictureBox1.Image = rImageProcessor.Rotate(participate.Register.Student.Photo.Picture, rotateAngle);
        }

        private void sectionItemSelector1_SelectedChanged(object sender, EventArgs e)
        {
            rGridView1.Clear();
            if (sectionItemSelector1.SectionItem == null)
                return;
            if (lessonSelector1.Lesson == null)
                return;
            rGridView1.DataBind(sectionItemSelector1.SectionItem.GetParticipates());
        }
    }
}
