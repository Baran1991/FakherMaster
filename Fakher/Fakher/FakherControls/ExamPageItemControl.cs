using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;

namespace Fakher.Application_Controls
{
    public partial class ExamPageItemControl : UserControl
    {
        public bool IsSelected { get; set; }
        public event EventHandler Edit;
        public event EventHandler Delete;
        public event EventHandler MoveUp;
        public event EventHandler MoveDown;
        
        internal ExamPageItem Item;

        public ExamPageItemControl()
        {
            InitializeComponent();
        }

        public void Databind(ExamPageItem pageItem)
        {
            Item = pageItem;

            if (pageItem is ExamTestQuestion)
                rLabel1.Text = (pageItem as ExamTestQuestion).QuestionIndex + ".";
            if (pageItem is ExamEssayQuestion)
                rLabel1.Text = (pageItem as ExamEssayQuestion).QuestionIndex + ".";

            rHtmlLabel1.DocumentText = pageItem.DrawHtml();
        }

        private void pictureBoxEdit_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxEdit.Image = imageList1.Images[0];
        }

        private void pictureBoxEdit_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxEdit.Image = imageList1.Images[1];
        }

        private void pictureBoxDelete_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxDelete.Image = imageList1.Images[2];
        }

        private void pictureBoxDelete_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxDelete.Image = imageList1.Images[3];
        }

        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
            if (Edit != null)
                Edit(this, EventArgs.Empty);
        }

        private void pictureBoxDelete_Click(object sender, EventArgs e)
        {
            if (Delete != null)
                Delete(this, EventArgs.Empty);
        }

        private void pictureBoxUp_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxUp.Image = imageList1.Images[4];
        }

        private void pictureBoxUp_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxUp.Image = imageList1.Images[5];
        }

        private void pictureBoxDown_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxDown.Image = imageList1.Images[6];
        }

        private void pictureBoxDown_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxDown.Image = imageList1.Images[7];
        }

        private void pictureBoxUp_Click(object sender, EventArgs e)
        {
            if (MoveUp != null)
                MoveUp(this, EventArgs.Empty);
        }

        private void pictureBoxDown_Click(object sender, EventArgs e)
        {
            if (MoveDown != null)
                MoveDown(this, EventArgs.Empty);
        }
    }
}
