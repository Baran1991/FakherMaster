using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.UI.Website
{
    public partial class frmNewsDetail : rRadDetailForm
    {
        public frmNewsDetail(WebNews news)
        {
            InitializeComponent();

            rCmbType.DataSource = typeof (WebNewsCategory).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = news,
                ObjectProperty = "Title"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCheckBox1,
                ControlProperty = "IsChecked",
                DataObject = news,
                ObjectProperty = "HasTicker"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCheckBox2,
                ControlProperty = "IsChecked",
                DataObject = news,
                ObjectProperty = "IsRed"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbType,
                ControlProperty = "SelectedIndex",
                DataObject = news,
                ObjectProperty = "Category"
            });

//            rHtmlEditor1.BodyHtml = news.AbstractHtml;
//            rHtmlEditor2.BodyHtml = news.TextHtml;
        }

        private void rHtmlEditor1_Enter(object sender, EventArgs e)
        {
            rHtmlEditorToolbar1.HtmlEditor = rHtmlEditor1;
        }

        private void rHtmlEditor2_Enter(object sender, EventArgs e)
        {
            rHtmlEditorToolbar1.HtmlEditor = rHtmlEditor2;
        }

        protected override void AfterBindToObject()
        {
            WebNews news = GetProcessingObject<WebNews>();
            news.AbstractHtml = Services.NormalizeFarsiString(rHtmlEditor1.BodyHtml);
            news.TextHtml = Services.NormalizeFarsiString(rHtmlEditor2.BodyHtml);
        }

        private void frmNewsDetail_Shown(object sender, EventArgs e)
        {
            WebNews news = GetProcessingObject<WebNews>();
            rHtmlEditor1.BodyHtml = news.AbstractHtml;
            rHtmlEditor2.BodyHtml = news.TextHtml;
        }
    }
}
