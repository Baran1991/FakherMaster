using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mshtml;

namespace rComponents
{
    public partial class rHtmlLabel : UserControl
    {
        public rHtmlLabel()
        {
            InitializeComponent();
            SetupBrowser();
        }

        public string BlankDocumentHtml
        {
            get { return "<html><body></body></html>"; }
        }

        public void Clear()
        {
            if (webBrowser1.Document.Body != null)
                webBrowser1.Document.Body.InnerHtml = "";
        }

        public HtmlDocument Document
        {
            get { return webBrowser1.Document; }
        }

        [Browsable(false)]
        public string DocumentText
        {
            get
            {
                return webBrowser1.DocumentText;
            }
            set
            {
                webBrowser1.DocumentText = value;
            }
        }

        [Browsable(false)]
        public string DocumentTitle
        {
            get
            {
                return webBrowser1.DocumentTitle;
            }
        }

        [Browsable(false)]
        public string BodyHtml
        {
            get
            {
                if (webBrowser1.Document != null &&
                    webBrowser1.Document.Body != null)
                {
                    return webBrowser1.Document.Body.InnerHtml;
                }
                else
                    return string.Empty;
            }
            set
            {
                if (webBrowser1.Document.Body != null)
                    webBrowser1.Document.Body.InnerHtml = value;
            }
        }

        [Browsable(false)]
        public string BodyText
        {
            get
            {
                if (webBrowser1.Document != null &&
                    webBrowser1.Document.Body != null)
                {
                    return webBrowser1.Document.Body.InnerText;
                }
                else
                    return string.Empty;
            }
            set
            {
                if (webBrowser1.Document.Body != null)
                    webBrowser1.Document.Body.InnerText = value;
            }
        }

        private void SetupBrowser()
        {
            webBrowser1.DocumentText = BlankDocumentHtml;
//            doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
//            doc.designMode = "On";
            Application.DoEvents();
        }

    }
}
