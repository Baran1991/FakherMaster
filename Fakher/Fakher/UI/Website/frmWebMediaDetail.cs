using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.UI.Website
{
    public partial class frmWebMediaDetail : rRadDetailForm
    {
        public frmWebMediaDetail(WebMedia media)
        {
            InitializeComponent();

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = media,
                ObjectProperty = "Name"
            });
        }

        private void radBtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            rTextBox2.Text = dialog.FileName;
        }

        protected override void AfterBindToObject()
        {
            WebMedia media = GetProcessingObject<WebMedia>();
            string fileName = rTextBox2.Text.Trim();
            media.Bytes = File.ReadAllBytes(fileName);
        }
    }
}
