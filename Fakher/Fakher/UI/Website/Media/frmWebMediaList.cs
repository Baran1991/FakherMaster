using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.UI.Website.Media
{
    public partial class frmWebMediaList : rRadForm
    {
        public frmWebMediaList()
        {
            InitializeComponent();

            rGridViewMedia.Mappings.Add(new ColumnMapping {Caption = "نام", ObjectProperty = "Name"});
            rGridViewMedia.Mappings.Add(new ColumnMapping {Caption = "بازدید", ObjectProperty = "Hits"});
            rGridViewMedia.DataBind(WebMedia.GetAllMedia(WebMediaType.Media));
        }

        private void rGridViewMedia_Add(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            WebMedia media = WebMedia.FromFileName(dialog.FileName, WebMediaType.Media);
            media.Save();
            rGridViewMedia.Insert(media);
        }

        private void rGridViewMedia_Edit(object sender, EventArgs e)
        {
            WebMedia media = rGridViewMedia.GetSelectedObject<WebMedia>();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            media.SetFile(dialog.FileName);
            media.Save();
            rGridViewMedia.UpdateGridView();
        }

        private void rGridViewMedia_Delete(object sender, EventArgs e)
        {
            WebMedia media = rGridViewMedia.GetSelectedObject<WebMedia>();
            media.Delete();
            rGridViewMedia.RemoveSelectedRow();
        }
    }
}

