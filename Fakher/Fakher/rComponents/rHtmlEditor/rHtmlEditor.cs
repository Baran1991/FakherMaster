using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using mshtml;
using System.Diagnostics;

namespace rComponents
{
    // http://msdn.microsoft.com/en-us/library/aa752574%28VS.85%29.aspx
    public partial class rHtmlEditor : UserControl
    {
        internal IHTMLDocument2 doc;
        private bool updatingFontName = false;
        private bool updatingFontSize = false;
        private bool setup = false;

        public delegate void TickDelegate();

        public class EnterKeyEventArgs : EventArgs
        {
            private bool _cancel = false;

            public bool Cancel
            {
                get { return _cancel; }
                set { _cancel = value; }
            }

        }

        public event WebBrowserNavigatedEventHandler Navigated;
        public event EventHandler<EnterKeyEventArgs> EnterKeyEvent;
        public static event EventHandler<EventArgs> InternalMediaRequest;

        public rHtmlEditor()
        {
            InitializeComponent();
            SetupEvents();
//            SetupTimer();
            SetupBrowser();
//            SetupFontComboBox();
//            SetupFontSizeComboBox();
//            WindowsInterop.Hook();
        }

        public string BlankDocumentHtml
        {
            get { return "<html><body></body></html>"; }
        }

        public SelectionType SelectionType
        {
            get
            {
                switch (doc.selection.type.ToLower())
                {
                    case "text":
                        return SelectionType.Text;
                    case "control":
                        return SelectionType.Control;
                    case "none":
                        return SelectionType.None;
                    default:
                        return SelectionType.None;
                }
            }
        }

        private void SetupEvents()
        {
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
            webBrowser1.GotFocus += new EventHandler(webBrowser1_GotFocus);
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
            if (doc.designMode.ToLower() != "on")
            {
                doc.designMode = "On";
                webBrowser1.Document.Write(BlankDocumentHtml);
            }
//            webBrowser1.Document.Body.InnerHtml = "123";
//            webBrowser1.DocumentText =  "<html><head></head><body>456</body></html>";
//            IHTMLElement htmlElement = doc.createElement("body");
//            htmlElement.innerHTML = "123";
//            MakeEditable();
        }

        //public void MakeEditable()
        //{
        //    if (webBrowser1.Document != null)
        //    {
        //        (webBrowser1.Document.DomDocument as IHTMLDocument2).designMode = "On";
        //    }
        //}
        
        private void webBrowser1_GotFocus(object sender, EventArgs e)
        {
            //MakeEditable();
            SuperFocus();
        }

        
        void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            SetBackgroundColor(BackColor);
            if (Navigated != null)
            {
                Navigated(this, e);
            }
        }

        public void OnInternalMediaRequest()
        {
            if (InternalMediaRequest != null)
                InternalMediaRequest(this, EventArgs.Empty);
        }
        
//        private void SetupTimer()
//        {
//            timer.Interval = 50;
//            timer.Tick += new EventHandler(timer_Tick);
//            timer.Start();
//        }

        private void SetupBrowser()
        {
            webBrowser1.Navigate("about:blank");

//            doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
//            doc.designMode = "On";
//            webBrowser1.DocumentText = BlankDocumentHtml;

            webBrowser1.Document.ContextMenuShowing += new HtmlElementEventHandler(Document_ContextMenuShowing);

            //MakeEditable();

//            Application.DoEvents();
            // http://www.codeproject.com/KB/vb/webbrowserzoom.aspx
            // http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/10939670-bb97-4da8-9131-7e41602021d9/
            // http://msdn.microsoft.com/en-us/library/ms691264.aspx
//            SHDocVw.WebBrowser activeXInstance = (SHDocVw.WebBrowser)webBrowser1.ActiveXInstance;
//            object nullObject = null;
//            activeXInstance.ExecWB(SHDocVw.OLECMDID.OLECMDID_SAVE, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, ref nullObject, ref nullObject);
//            activeXInstance.ExecWB(SHDocVw.OLECMDID.OLECMDID_SAVEAS, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, ref nullObject, ref nullObject);
//            activeXInstance.ExecWB(SHDocVw.OLECMDID.OLECMDID_SAVECOPYAS, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, ref nullObject, ref nullObject);
        }

        private void SuperFocus()
        {
            if (webBrowser1.Document != null &&
                webBrowser1.Document.Body != null)
            {
                webBrowser1.Document.Body.Focus();
                //(webBrowser1.Document.DomDocument as IHTMLDocument2).designMode = "On";
            }
        }

        
        [Browsable(true)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                if (ReadyState == ReadyState.Complete)
                {
                    SetBackgroundColor(value);
                }
            }
        }

        private void SetBackgroundColor(Color value)
        {
            if (webBrowser1.Document != null &&
                webBrowser1.Document.Body != null)
                webBrowser1.Document.Body.Style =
                    string.Format("background-color: {0}", value.Name);
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

        public bool CanUndo()
        {
            return doc.queryCommandEnabled("Undo");
        }
        
        public bool CanRedo()
        {
            return doc.queryCommandEnabled("Redo");
        }
        
        public bool CanCut()
        {
            return doc.queryCommandEnabled("Cut");
        }
        
        public bool CanCopy()
        {
            return doc.queryCommandEnabled("Copy");
        }
        
        public bool CanPaste()
        {
            return doc.queryCommandEnabled("Paste");
        }
        
        public bool CanDelete()
        {
            return doc.queryCommandEnabled("Delete");
        }
        
        public bool IsJustifyLeft()
        {
            return doc.queryCommandState("JustifyLeft");
        }
        
        public bool IsJustifyRight()
        {
            return doc.queryCommandState("JustifyRight");
        }
        
        public bool IsJustifyCenter()
        {
            return doc.queryCommandState("JustifyCenter");
        }
        
        public bool IsJustifyFull()
        {
            return doc.queryCommandState("JustifyFull");
        }

        public bool IsRightToLeft()
        {
            return doc.queryCommandState("BlockDirRTL");
        }

        public bool IsLeftToRight()
        {
            return doc.queryCommandState("BlockDirLTR");
        }
        
        public bool IsBold()
        {
            return doc.queryCommandState("Bold");
        }

        public bool IsStrikeThrough()
        {
            return doc.queryCommandState("StrikeThrough");
        }

        public bool IsSubScript()
        {
            return doc.queryCommandState("Subscript");
        }

        public bool IsSupperScript()
        {
            return doc.queryCommandState("Superscript");
        }
        
        public bool IsItalic()
        {
            return doc.queryCommandState("Italic");
        }
        
        public bool IsUnderline()
        {
            return doc.queryCommandState("Underline");
        }
        
        public bool IsOrderedList()
        {
            return doc.queryCommandState("InsertOrderedList");
        }
        
        public bool IsUnorderedList()
        {
            return doc.queryCommandState("InsertUnorderedList");
        }

        
        private void Document_ContextMenuShowing(object sender, HtmlElementEventArgs e)
        {
            e.ReturnValue = false;
            cutToolStripMenuItem1.Enabled = CanCut();
            copyToolStripMenuItem2.Enabled = CanCopy();
            pasteToolStripMenuItem3.Enabled = CanPaste();
            deleteToolStripMenuItem.Enabled = CanDelete();
            contextMenuStrip1.Show(this, e.ClientMousePosition);
        }

        

//        private void SetupFontComboBox()
//        {
//            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
//            fontComboBox.Items.Add("Tahoma");
//            ac.Add("Tahoma");
//
////            foreach (FontFamily fam in FontFamily.Families)
////            {
////                fontComboBox.Items.Add(fam.Name);
////                ac.Add(fam.Name);
////            }
//            fontComboBox.Leave += new EventHandler(fontComboBox_TextChanged);
//            fontComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
//            fontComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
//            fontComboBox.AutoCompleteCustomSource = ac;
//        }
//
//        private void SetupFontSizeComboBox()
//        {
//            for (int x = 1; x <= 7; x++)
//            {
//                fontSizeComboBox.Items.Add(x.ToString());
//            }
//            fontSizeComboBox.TextChanged += new EventHandler(fontSizeComboBox_TextChanged);
//            fontSizeComboBox.KeyPress += new KeyPressEventHandler(fontSizeComboBox_KeyPress);
//        }
        
//        private void fontSizeComboBox_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (Char.IsNumber(e.KeyChar))
//            {
//                e.Handled = true;
//                if (e.KeyChar <= '7' && e.KeyChar > '0')
//                    fontSizeComboBox.Text = e.KeyChar.ToString();
//            }
//            else if (!Char.IsControl(e.KeyChar))
//            {
//                e.Handled = true;
//            }
//        }
//        
//        private void fontSizeComboBox_TextChanged(object sender, EventArgs e)
//        {
//            if (updatingFontSize) return;
//            switch (fontSizeComboBox.Text.Trim())
//            {
//                case "1":
//                    FontSize = FontSize.One;
//                    break;
//                case "2":
//                    FontSize = FontSize.Two;
//                    break;
//                case "3":
//                    FontSize = FontSize.Three;
//                    break;
//                case "4":
//                    FontSize = FontSize.Four;
//                    break;
//                case "5":
//                    FontSize = FontSize.Five;
//                    break;
//                case "6":
//                    FontSize = FontSize.Six;
//                    break;
//                case "7":
//                    FontSize = FontSize.Seven;
//                    break;
//                default:
//                    FontSize = FontSize.Seven;
//                    break;
//            }
//        }
//        
//        private void fontComboBox_TextChanged(object sender, EventArgs e)
//        {
//            if (updatingFontName) return;
//            FontFamily ff;
//            try
//            {
//                ff = new FontFamily(fontComboBox.Text);
//            }
//            catch (Exception)
//            {
//                updatingFontName = true;
//                fontComboBox.Text = FontName.GetName(0);
//                updatingFontName = false;
//                return;
//            }
//            FontName = ff;
//        }
        
//        private void timer_Tick(object sender, EventArgs e)
//        {
//            // don't process until browser is in ready state.
//            if (ReadyState != ReadyState.Complete)
//                return;
//
//            SetupKeyListener();
//            boldButton.Checked = IsBold();
//            italicButton.Checked = IsItalic();
//            underlineButton.Checked = IsUnderline();
//            strikeButton.Checked = IsStrikeThrough();
//            subScriptButton.Checked = IsSubScript();
//            superScriptButton.Checked = IsSupperScript();
//            orderedListButton.Checked = IsOrderedList();
//            unorderedListButton.Checked = IsUnorderedList();
//            justifyLeftButton.Checked = IsJustifyLeft();
//            justifyCenterButton.Checked = IsJustifyCenter();
//            justifyRightButton.Checked = IsJustifyRight();
//            justifyFullButton.Checked = IsJustifyFull();
//            rtlButton.Checked = IsRightToLeft();
//            ltrButton.Checked = IsLeftToRight();
//
//            linkButton.Enabled = SelectionType == SelectionType.Text;
//
//            UpdateFontComboBox();
//            UpdateFontSizeComboBox();
//
//            if (Tick != null)
//                Tick();
//        }
//        
//        private void UpdateFontSizeComboBox()
//        {
//            if (!fontSizeComboBox.Focused)
//            {
//                int foo;
//                switch (FontSize)
//                {
//                    case FontSize.One:
//                        foo = 1;
//                        break;
//                    case FontSize.Two:
//                        foo = 2;
//                        break;
//                    case FontSize.Three:
//                        foo = 3;
//                        break;
//                    case FontSize.Four:
//                        foo = 4;
//                        break;
//                    case FontSize.Five:
//                        foo = 5;
//                        break;
//                    case FontSize.Six:
//                        foo = 6;
//                        break;
//                    case FontSize.Seven:
//                        foo = 7;
//                        break;
//                    case FontSize.NA:
//                        foo = 0;
//                        break;
//                    default:
//                        foo = 7;
//                        break;
//                }
//                string fontsize = Convert.ToString(foo);
//                if (fontsize != fontSizeComboBox.Text)
//                {
//                    updatingFontSize = true;
//                    fontSizeComboBox.Text = fontsize;
//                    updatingFontSize = false;
//                }
//            }
//        }
//        
//        private void UpdateFontComboBox()
//        {
//            if (!fontComboBox.Focused)
//            {
//                FontFamily fam = FontName;
//                if (fam != null)
//                {
//                    string fontname = fam.Name;
//                    if (fontname != fontComboBox.Text)
//                    {
//                        updatingFontName = true;
//                        fontComboBox.Text = fontname;
//                        updatingFontName = false;
//                    }
//                }
//            }
//        }
        
        public void SetupKeyListener()
        {
            if (!setup)
            {
                webBrowser1.Document.Body.KeyDown += new HtmlElementEventHandler(Body_KeyDown);
                setup = true;
            }
        }
        
        private void Body_KeyDown(object sender, HtmlElementEventArgs e)
        {
            if (e.KeyPressedCode == 13 && !e.ShiftKeyPressed)
            {
                // handle enter code cancellation
                bool cancel = false;
                if (EnterKeyEvent != null)
                {
                    EnterKeyEventArgs args = new EnterKeyEventArgs();
                    EnterKeyEvent(this, args);
                    cancel = args.Cancel;
                }
                e.ReturnValue = !cancel;
            }
        }
        
        public void EmbedBr()
        {
            IHTMLTxtRange range =
                doc.selection.createRange() as IHTMLTxtRange;
            range.pasteHTML("<br/>");
            range.collapse(false);
            range.select();
        }
        
        private void SuperPaste()
        {
            if (Clipboard.ContainsText())
            {
                IHTMLTxtRange range =
                    doc.selection.createRange() as IHTMLTxtRange;
                range.pasteHTML(Clipboard.GetText(TextDataFormat.Text));
                range.collapse(false);
                range.select();
            }
        }
        
        public void Print()
        {
            webBrowser1.Document.ExecCommand("Print", true, null);
        }
        
        public void InsertParagraph()
        {
            webBrowser1.Document.ExecCommand("InsertParagraph", false, null);
        }
        
        public void InsertBreak()
        {
            webBrowser1.Document.ExecCommand("InsertHorizontalRule", false, null);
        }
        
        public void SelectAll()
        {
            webBrowser1.Document.ExecCommand("SelectAll", false, null);
        }
        
        public void Undo()
        {
            webBrowser1.Document.ExecCommand("Undo", false, null);
        }
        
        public void Redo()
        {
            webBrowser1.Document.ExecCommand("Redo", false, null);
        }
        
        public void Cut()
        {
            webBrowser1.Document.ExecCommand("Cut", false, null);
        }
        
        public void Paste()
        {
            webBrowser1.Document.ExecCommand("Paste", false, null);
        }
        
        public void Copy()
        {
            webBrowser1.Document.ExecCommand("Copy", false, null);
        }
        
        public void OrderedList()
        {
            webBrowser1.Document.ExecCommand("InsertOrderedList", false, null);
        }
        
        public void UnorderedList()
        {
            webBrowser1.Document.ExecCommand("InsertUnorderedList", false, null);
        }
        
        public void JustifyLeft()
        {
            webBrowser1.Document.ExecCommand("JustifyLeft", false, null);
        }
        
        public void JustifyRight()
        {
            webBrowser1.Document.ExecCommand("JustifyRight", false, null);
        }
        
        public void JustifyCenter()
        {
            webBrowser1.Document.ExecCommand("JustifyCenter", false, null);
        }
        
        public void JustifyFull()
        {
            webBrowser1.Document.ExecCommand("JustifyFull", false, null);
        }

        public void SetRightToLeft()
        {
            webBrowser1.Document.ExecCommand("BlockDirRTL", false, null);
        }

        public void SetLeftToRight()
        {
            webBrowser1.Document.ExecCommand("BlockDirLTR", false, null);
        }
        
        public void Bold()
        {
            webBrowser1.Document.ExecCommand("Bold", false, null);
        }

        public void StrikeThrough()
        {
            webBrowser1.Document.ExecCommand("StrikeThrough", false, null);
        }

        public void SubScript()
        {
            webBrowser1.Document.ExecCommand("Subscript", false, null);
        }

        public void SupperScript()
        {
            webBrowser1.Document.ExecCommand("Superscript", false, null);
        }
        
        public void Italic()
        {
            webBrowser1.Document.ExecCommand("Italic", false, null);
        }
        
        public void Underline()
        {
            webBrowser1.Document.ExecCommand("Underline", false, null);
        }
        
        public void Delete()
        {
            webBrowser1.Document.ExecCommand("Delete", false, null);
        }
        
        public void InsertImage()
        {
            //webBrowser1.Document.ExecCommand("InsertImage", true, null);

            IHTMLControlRange control = doc.selection.createRange() as IHTMLControlRange;
            if (control != null && control.length > 0)
            {
                IHTMLElement htmlElement = control.item(0);
                
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "All Picture Types|*.jpg;*.jpeg;*.bmp;*.png;*.gif";
                if (dialog.ShowDialog(ParentForm) != DialogResult.OK)
                    return;

                string base64String;
                string src;
                using (Image image = Image.FromFile(dialog.FileName))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Convert Image to byte[]
                        image.Save(ms, ImageFormat.Png);
                        byte[] imageBytes = ms.ToArray();
                        // Convert byte[] to Base64 String
                        base64String = Convert.ToBase64String(imageBytes);
                    }
                }
                src = "data:image/png;base64," + base64String;
                HtmlElement element = webBrowser1.Document.CreateElement("img");
                element.SetAttribute("src", src);
                Guid newGuid = Guid.NewGuid();
                element.SetAttribute("name", newGuid.ToString());
                webBrowser1.Document.Body.AppendChild(element);

//                HtmlElement element = webBrowser1.Document.CreateElement("img");
//                element.SetAttribute("src", "file:///" + dialog.FileName);
//                Guid newGuid = Guid.NewGuid();
//                element.SetAttribute("name", newGuid.ToString());
//                element.Style += "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='" + src + "', sizingMethod='scale');";
//                webBrowser1.Document.Body.InsertAdjacentElement(HtmlElementInsertionOrientation.BeforeEnd, element);
            }
        }
        //public void InsertVideo()
        //{
        //    //webBrowser1.Document.ExecCommand("InsertImage", true, null);

        //    IHTMLControlRange control = doc.selection.createRange() as IHTMLControlRange;
        //    if (control != null && control.length > 0)
        //    {
        //        IHTMLElement htmlElement = control.item(0);

        //    }
        //    else
        //    {
        //        OpenFileDialog dialog = new OpenFileDialog();
        //        dialog.Filter = "Video Types|*.mp4;";
        //        if (dialog.ShowDialog(ParentForm) != DialogResult.OK)
        //            return;

        //        string base64String;
        //        string src;
        //        using (Image image = Image.FromFile(dialog.FileName))
        //        {
        //            using (MemoryStream ms = new MemoryStream())
        //            {
        //                // Convert Image to byte[]
        //                image.Save(ms, ImageFormat.Png);
        //                byte[] imageBytes = ms.ToArray();
        //                // Convert byte[] to Base64 String
        //                base64String = Convert.ToBase64String(imageBytes);
        //            }
        //        }
        //        src = "data:image/png;base64," + base64String;
        //        HtmlElement element = webBrowser1.Document.CreateElement("video");
        //        element.SetAttribute("src", src);
        //        Guid newGuid = Guid.NewGuid();
        //        element.SetAttribute("name", newGuid.ToString());
        //        webBrowser1.Document.Body.AppendChild(element);

        //        //                HtmlElement element = webBrowser1.Document.CreateElement("img");
        //        //                element.SetAttribute("src", "file:///" + dialog.FileName);
        //        //                Guid newGuid = Guid.NewGuid();
        //        //                element.SetAttribute("name", newGuid.ToString());
        //        //                element.Style += "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='" + src + "', sizingMethod='scale');";
        //        //                webBrowser1.Document.Body.InsertAdjacentElement(HtmlElementInsertionOrientation.BeforeEnd, element);
        //    }
        //}
        public void InsertExternalCode()
        {
            IHTMLControlRange control = doc.selection.createRange() as IHTMLControlRange;
            if (control != null && control.length > 0)
            {
                IHTMLElement htmlElement = control.item(0);

            }
            else
            {
                frmExternalCodeDetail frm = new frmExternalCodeDetail();
                if (frm.ShowDialog(this) != DialogResult.OK)
                    return;

                HtmlElement element = webBrowser1.Document.CreateElement("div");
                element.InnerHtml = frm.Code;
                if (frm.CodeWidth != 0)
                    element.Style += "width: " + frm.CodeWidth + "px; ";
                if(frm.CodeHeight != 0)
                    element.Style += "height: " + frm.CodeHeight + "px; ";

                webBrowser1.Document.Body.AppendChild(element);
            }
        }

        public void InsertTable()
        {
            IHTMLControlRange control = doc.selection.createRange() as IHTMLControlRange;
            if (control != null && control.length > 0)
            {
                IHTMLElement htmlElement = control.item(0);

            }
            else
            {
                HtmlElement table = webBrowser1.Document.CreateElement("table");
                frmTableDetail frm = new frmTableDetail(table);
                if (frm.ShowDialog(ParentForm) != DialogResult.OK)
                    return;
                webBrowser1.Document.Body.AppendChild(table);
            }
        }

        public void Indent()
        {
            webBrowser1.Document.ExecCommand("Indent", false, null);
        }
        
        public void Outdent()
        {
            webBrowser1.Document.ExecCommand("Outdent", false, null);
        }
        
        public void InsertLink()
        {
            webBrowser1.Document.ExecCommand("CreateLink", true, null);
            return;

            IHTMLControlRange control = doc.selection.createRange() as IHTMLControlRange;
            if (control != null && control.length > 0)
            {
                IHTMLElement htmlElement = control.item(0);
//                frmLinkDetail frm = new frmLinkDetail(htmlElement);
//                frm.ShowDialog(ParentForm);
            }
            else
            {
                HtmlElement anchor = webBrowser1.Document.CreateElement("a");
                frmLinkDetail frm = new frmLinkDetail(anchor);
                if (frm.ShowDialog(ParentForm) != DialogResult.OK)
                    return;
                webBrowser1.Document.Body.Parent.AppendChild(anchor);
            }
        }
        
        public ReadyState ReadyState
        {
            get
            {
                if(doc == null)
                    return ReadyState.Uninitialized;

                switch (doc.readyState.ToLower())
                {
                    case "uninitialized":
                        return ReadyState.Uninitialized;
                    case "loading":
                        return ReadyState.Loading;
                    case "loaded":
                        return ReadyState.Loaded;
                    case "interactive":
                        return ReadyState.Interactive;
                    case "complete":
                        return ReadyState.Complete;
                    default:
                        return ReadyState.Uninitialized;
                }
            }
        }
        
//        public SelectionType SelectionType
//        {
//            get
//            {
//                switch (doc.selection.type.ToLower())
//                {
//                    case "text":
//                        return SelectionType.Text;
//                    case "control":
//                        return SelectionType.Control;
//                    case "none":
//                        return SelectionType.None;
//                    default:
//                        return SelectionType.None;
//                }
//            }
//        }

        
//        [Browsable(false)]
//        public FontSize FontSize
//        {
//            get
//            {
//                if (ReadyState != ReadyState.Complete)
//                    return FontSize.NA;
//                switch (doc.queryCommandValue("FontSize").ToString())
//                {
//                    case "1":
//                        return FontSize.One;
//                    case "2":
//                        return FontSize.Two;
//                    case "3":
//                        return FontSize.Three;
//                    case "4":
//                        return FontSize.Four;
//                    case "5":
//                        return FontSize.Five;
//                    case "6":
//                        return FontSize.Six;
//                    case "7":
//                        return FontSize.Seven;
//                    default:
//                        return FontSize.NA;
//                }
//            }
//            set
//            {
//                int sz;
//                switch (value)
//                {
//                    case FontSize.One:
//                        sz = 1;
//                        break;
//                    case FontSize.Two:
//                        sz = 2;
//                        break;
//                    case FontSize.Three:
//                        sz = 3;
//                        break;
//                    case FontSize.Four:
//                        sz = 4;
//                        break;
//                    case FontSize.Five:
//                        sz = 5;
//                        break;
//                    case FontSize.Six:
//                        sz = 6;
//                        break;
//                    case FontSize.Seven:
//                        sz = 7;
//                        break;
//                    default:
//                        sz = 7;
//                        break;
//                }
//                webBrowser1.Document.ExecCommand("FontSize", false, sz.ToString());
//            }
//        }
//        
//        [Browsable(false)]
//        public FontFamily FontName
//        {
//            get
//            {
//                if (ReadyState != ReadyState.Complete)
//                    return null;
//                string name = doc.queryCommandValue("FontName") as string;
//                if (name == null) return null;
//                return new FontFamily(name);
//            }
//            set
//            {
//                if (value != null)
//                    webBrowser1.Document.ExecCommand("FontName", false, value.Name);
//            }
//        }
//        
        [Browsable(false)]
        public Color EditorForeColor
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return Color.Black;
                return ConvertToColor(doc.queryCommandValue("ForeColor").ToString());
            }
            set
            {
                string colorstr = 
                    string.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                webBrowser1.Document.ExecCommand("ForeColor", false, colorstr);
            }
        }
        
        [Browsable(false)]
        public Color EditorBackColor
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return Color.White;
                return ConvertToColor(doc.queryCommandValue("BackColor").ToString());
            }
            set
            {
                string colorstr =
                    string.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                webBrowser1.Document.ExecCommand("BackColor", false, colorstr);
            }
        }
        
        public void SelectForeColor()
        {
            Color color = EditorForeColor;
            if (ShowColorDialog(ref color))
                EditorForeColor = color;
        }
        
        public void SelectBackColor()
        {
            Color color = EditorBackColor;
            if (ShowColorDialog(ref color))
                EditorBackColor = color;
        }
        
        private static Color ConvertToColor(string clrs)
        {
            int red, green, blue;
            // sometimes clrs is HEX organized as (RED)(GREEN)(BLUE)
            if (clrs.StartsWith("#"))
            {
                int clrn = Convert.ToInt32(clrs.Substring(1), 16);
                red = (clrn >> 16) & 255;
                green = (clrn >> 8) & 255;
                blue = clrn & 255;
            }
            else // otherwise clrs is DECIMAL organized as (BlUE)(GREEN)(RED)
            {
                int clrn = Convert.ToInt32(clrs);
                red = clrn & 255;
                green = (clrn >> 8) & 255;
                blue = (clrn >> 16) & 255;
            }
            Color incolor = Color.FromArgb(red, green, blue);
            return incolor;
        }

        
//        private void cutToolStripButton_Click(object sender, EventArgs e)
//        {
//            Cut();
//        }
//
//        
//        private void pasteToolStripButton_Click(object sender, EventArgs e)
//        {
//            Paste();
//        }
//
//        
//        private void copyToolStripButton_Click(object sender, EventArgs e)
//        {
//            Copy();
//        }
//
//        
//        private void boldButton_Click(object sender, EventArgs e)
//        {
//            Bold();
//        }
//
//        
//        private void italicButton_Click(object sender, EventArgs e)
//        {
//            Italic();
//        }
//
//        
//        private void underlineButton_Click(object sender, EventArgs e)
//        {
//            Underline();
//        }
//
//        
//        private void colorButton_Click(object sender, EventArgs e)
//        {
//            SelectForeColor();
//        }
//
//        
//        private void backColorButton_Click(object sender, EventArgs e)
//        {
//            SelectBackColor();
//        }
//
//        
        private bool ShowColorDialog(ref Color color)
        {
            bool selected;
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.SolidColorOnly = true;
                dlg.AllowFullOpen = false;
                dlg.AnyColor = false;
                dlg.FullOpen = false;
                dlg.CustomColors = null;
                dlg.Color = color;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    selected = true;
                    color = dlg.Color;
                }
                else
                {
                    selected = false;
                }
            }
            return selected;
        }
//
//        
//        private void linkButton_Click(object sender, EventArgs e)
//        {
//            SelectLink();
//        }
//
//        
//        public void SelectLink()
//        {
////            using (LinkDialog dlg = new LinkDialog())
////            {
////                dlg.ShowDialog(this.ParentForm);
////                if (!dlg.Accepted) return;
////                string link = dlg.URI;
////                if (link == null || link.Length == 0)
////                {
////                    MessageBox.Show(this.ParentForm, "Invalid URL");
////                    return;
////                }
////                InsertLink(dlg.URL);
////            }
//        }
//
//        
//        private void imageButton_Click(object sender, EventArgs e)
//        {
//            InsertImage();
//        }
//
//        
//        private void outdentButton_Click(object sender, EventArgs e)
//        {
//            Indent();
//        }
//
//        
//        private void indentButton_Click(object sender, EventArgs e)
//        {
//            Outdent();
//        }
//
//        
        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cut();
        }

        
        private void copyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Copy();
        }

        
        private void pasteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Paste();
        }

        
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void rHtmlEditor_Load(object sender, EventArgs e)
        {
        }
//
//        
//        public bool Search(string text, bool forward, bool matchWholeWord, bool matchCase)
//        {
//            bool success = false;
//            if (webBrowser1.Document != null)
//            {
//                IHTMLDocument2 doc =
//                    webBrowser1.Document.DomDocument as IHTMLDocument2;
//                IHTMLBodyElement body = doc.body as IHTMLBodyElement;
//                if (body != null)
//                {
//                    IHTMLTxtRange range;
//                    if (doc.selection != null)
//                    {
//                        range = doc.selection.createRange() as IHTMLTxtRange;
//                        IHTMLTxtRange dup = range.duplicate();
//                        dup.collapse(true);
//                        // if selection is degenerate, then search whole body
//                        if (range.isEqual(dup))
//                        {
//                            range = body.createTextRange();
//                        }
//                        else
//                        {
//                            if (forward)
//                                range.moveStart("character", 1);
//                            else
//                                range.moveEnd("character", -1);
//                        }
//                    }
//                    else
//                        range = body.createTextRange();
//                    int flags = 0;
//                    if (matchWholeWord) flags += 2;
//                    if (matchCase) flags += 4;
//                    success =
//                        range.findText(text, forward ? 999999 : -999999, flags);
//                    if (success)
//                    {
//                        range.select();
//                        range.scrollIntoView(!forward);
//                    }
//                }
//            }
//            return success;
//        }
//
//        
//        private void orderedListButton_Click(object sender, EventArgs e)
//        {
//            OrderedList();
//        }
//
//        
//        private void unorderedListButton_Click(object sender, EventArgs e)
//        {
//            UnorderedList();
//        }
//
//        
//        private void justifyLeftButton_Click(object sender, EventArgs e)
//        {
//            JustifyLeft();
//        }
//
//        
//        private void justifyCenterButton_Click(object sender, EventArgs e)
//        {
//            JustifyCenter();
//        }
//
//        
//        private void justifyRightButton_Click(object sender, EventArgs e)
//        {
//            JustifyRight();
//        }
//
//        
//        private void justifyFullButton_Click(object sender, EventArgs e)
//        {
//            JustifyFull();
//        }
//
//        private void rtlButton_Click(object sender, EventArgs e)
//        {
//            SetRightToLeft();
//        }
//
//        private void ltrButton_Click(object sender, EventArgs e)
//        {
//            SetLeftToRight();
//        }
//
//        private void strikeButton_Click(object sender, EventArgs e)
//        {
//            StrikeThrough();
//        }
//
//        private void subScriptButton_Click(object sender, EventArgs e)
//        {
//            SubScript();
//        }
//
//        private void superScriptButton_Click(object sender, EventArgs e)
//        {
//            SupperScript();
//        }

    }

    public enum FontSize
    {
        One,
        Two,
        Three,
        Four, 
        Five,
        Six,
        Seven,
        NA
    }

    public enum SelectionType
    {
        Text,
        Control,
        None
    }

    public enum ReadyState
    {
        Uninitialized,
        Loading,
        Loaded,
        Interactive,
        Complete
    }

}