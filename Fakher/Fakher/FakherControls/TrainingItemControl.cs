using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;

namespace Fakher.Controls
{
    public partial class TrainingItemControl : UserControl
    {
        public new event EventHandler Select;
        public event EventHandler Edit;

        public bool IsSelected
        {
            get { return BackColor == Color.DarkOrange; }
            set
            {
                if (value)
                    BackColor = Color.DarkOrange;
                else
                    BackColor = Color.Transparent;
            }
        }

        public TrainingItem TrainingItem { get; set; }
        public TrainingItemControl(Image image, string text)
        {
            InitializeComponent();
            pictureBox1.Image = image;
            label1.Text = text;
        }

        protected void OnSelect()
        {
            if (Select != null)
                Select(this, EventArgs.Empty);
        }

        protected void OnEdit()
        {
            if (Edit != null)
                Edit(this, EventArgs.Empty);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OnSelect();
        }

        private void TrainingItemControl_Click(object sender, EventArgs e)
        {
            OnSelect();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OnSelect();
        }

        private void TrainingItemControl_DoubleClick(object sender, EventArgs e)
        {
            OnEdit();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OnEdit();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            OnEdit();
        }
    }
}
