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
    public partial class rHtmlEditorToolbar : UserControl
    {
        public rHtmlEditor HtmlEditor { get; set; }
        public event rHtmlEditor.TickDelegate Tick;
        public event EventHandler<DirectionChangedEventArgs> DirectionChanged;
 
        private bool updatingFontName = false;
        private bool updatingFontSize = false;

        public rHtmlEditorToolbar()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
        }

        [Browsable(false)]
        public FontSize FontSize
        {
            get
            {
                if (HtmlEditor == null || HtmlEditor.ReadyState != ReadyState.Complete)
                    return FontSize.NA;
                switch (HtmlEditor.doc.queryCommandValue("FontSize").ToString())
                {
                    case "1":
                        return FontSize.One;
                    case "2":
                        return FontSize.Two;
                    case "3":
                        return FontSize.Three;
                    case "4":
                        return FontSize.Four;
                    case "5":
                        return FontSize.Five;
                    case "6":
                        return FontSize.Six;
                    case "7":
                        return FontSize.Seven;
                    default:
                        return FontSize.NA;
                }
            }
            set
            {
                if (HtmlEditor == null)
                    return;
                int sz;
                switch (value)
                {
                    case FontSize.One:
                        sz = 1;
                        break;
                    case FontSize.Two:
                        sz = 2;
                        break;
                    case FontSize.Three:
                        sz = 3;
                        break;
                    case FontSize.Four:
                        sz = 4;
                        break;
                    case FontSize.Five:
                        sz = 5;
                        break;
                    case FontSize.Six:
                        sz = 6;
                        break;
                    case FontSize.Seven:
                        sz = 7;
                        break;
                    default:
                        sz = 7;
                        break;
                }
                HtmlEditor.Document.ExecCommand("FontSize", false, sz.ToString());
            }
        }

        [Browsable(false)]
        public FontFamily FontName
        {
            get
            {
                if (HtmlEditor == null || HtmlEditor.ReadyState != ReadyState.Complete)
                    return null;
                string name = HtmlEditor.doc.queryCommandValue("FontName") as string;
                if (name == null) 
                    return null;
                return new FontFamily(name);
            }
            set
            {
                if (HtmlEditor != null && value != null)
                    HtmlEditor.Document.ExecCommand("FontName", false, value.Name);
            }
        }


        public void SetupTimer()
        {
            timer.Interval = 50;
            if(ParentForm != null)
                ParentForm.FormClosed += new FormClosedEventHandler(ParentForm_FormClosed);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void ParentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopTimer();
        }

        public void StopTimer()
        {
            timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            tableButton.Enabled = HtmlEditor != null;
            imageButton.Enabled = HtmlEditor != null;

            // don't process until browser is in ready state.
            if (HtmlEditor == null || HtmlEditor.ReadyState != ReadyState.Complete)
                return;

            HtmlEditor.SetupKeyListener();
            boldButton.Checked = HtmlEditor.IsBold();
            italicButton.Checked = HtmlEditor.IsItalic();
            underlineButton.Checked = HtmlEditor.IsUnderline();
            strikeButton.Checked = HtmlEditor.IsStrikeThrough();
            subScriptButton.Checked = HtmlEditor.IsSubScript();
            superScriptButton.Checked = HtmlEditor.IsSupperScript();
            orderedListButton.Checked = HtmlEditor.IsOrderedList();
            unorderedListButton.Checked = HtmlEditor.IsUnorderedList();
            justifyLeftButton.Checked = HtmlEditor.IsJustifyLeft();
            justifyCenterButton.Checked = HtmlEditor.IsJustifyCenter();
            justifyRightButton.Checked = HtmlEditor.IsJustifyRight();
            justifyFullButton.Checked = HtmlEditor.IsJustifyFull();
            rtlButton.Checked = HtmlEditor.IsRightToLeft();
            ltrButton.Checked = HtmlEditor.IsLeftToRight();
            linkButton.Enabled = HtmlEditor.SelectionType == SelectionType.Text;
            cutStripButton.Enabled = HtmlEditor.CanCut();
            copyStripButton.Enabled = HtmlEditor.CanCopy();
            pasteStripButton.Enabled = HtmlEditor.CanPaste();


            UpdateFontComboBox();
            UpdateFontSizeComboBox();

            if (Tick != null)
                Tick();
        }

        private void UpdateFontSizeComboBox()
        {
            if (!fontSizeComboBox.Focused)
            {
                int foo;
                switch (FontSize)
                {
                    case FontSize.One:
                        foo = 1;
                        break;
                    case FontSize.Two:
                        foo = 2;
                        break;
                    case FontSize.Three:
                        foo = 3;
                        break;
                    case FontSize.Four:
                        foo = 4;
                        break;
                    case FontSize.Five:
                        foo = 5;
                        break;
                    case FontSize.Six:
                        foo = 6;
                        break;
                    case FontSize.Seven:
                        foo = 7;
                        break;
                    case FontSize.NA:
                        foo = 0;
                        break;
                    default:
                        foo = 7;
                        break;
                }
                string fontsize = Convert.ToString(foo);
                if (fontsize != fontSizeComboBox.Text)
                {
                    updatingFontSize = true;
                    fontSizeComboBox.Text = fontsize;
                    updatingFontSize = false;
                }
            }
        }

        private void UpdateFontComboBox()
        {
            if (!fontComboBox.Focused)
            {
                FontFamily fam = FontName;
                if (fam != null)
                {
                    string fontname = fam.Name;
                    if (fontname != fontComboBox.Text)
                    {
                        updatingFontName = true;
                        fontComboBox.Text = fontname;
                        updatingFontName = false;
                    }
                }
            }
        }

        private void SetupFontComboBox()
        {
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            fontComboBox.Items.Add("Times New Roman");
            ac.Add("Times New Roman");
            
            fontComboBox.Items.Add("Tahoma");
            ac.Add("Tahoma");

            fontComboBox.Items.Add("Arial");
            ac.Add("Arial");

            
                        //foreach (FontFamily fam in FontFamily.Families)
                        //{
                        //    fontComboBox.Items.Add(fam.Name);
            //                ac.Add(fam.Name);
                       // }
            fontComboBox.Leave += new EventHandler(font_Changed);
            fontComboBox.SelectedIndexChanged += new EventHandler(font_Changed);
            fontComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            fontComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            fontComboBox.AutoCompleteCustomSource = ac;
        }

        private void SetupFontSizeComboBox()
        {
            for (int x = 1; x <= 7; x++)
            {
                fontSizeComboBox.Items.Add(x.ToString());
            }
            fontSizeComboBox.TextChanged += new EventHandler(font_Changed);
            fontSizeComboBox.KeyPress += new KeyPressEventHandler(fontSizeComboBox_KeyPress);
        }

        private void fontSizeComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                if (e.KeyChar <= '7' && e.KeyChar > '0')
                    fontSizeComboBox.Text = e.KeyChar.ToString();
            }
            else if (!Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

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

        private void font_Changed(object sender, EventArgs e)
        {
            string fontName = fontComboBox.Text.Trim();
            string fontSize = fontSizeComboBox.Text.Trim();

            try
            {
                FontFamily font = new FontFamily(fontName);
                FontName = font;

                switch (fontSize)
                {
                    case "1":
                        FontSize = FontSize.One;
                        break;
                    case "2":
                        FontSize = FontSize.Two;
                        break;
                    case "3":
                        FontSize = FontSize.Three;
                        break;
                    case "4":
                        FontSize = FontSize.Four;
                        break;
                    case "5":
                        FontSize = FontSize.Five;
                        break;
                    case "6":
                        FontSize = FontSize.Six;
                        break;
                    case "7":
                        FontSize = FontSize.Seven;
                        break;
//                    default:
//                        FontSize = FontSize.Seven;
//                        break;
                }
            }
            catch (Exception ex)
            {
//                updatingFontName = true;
//                fontComboBox.Text = FontName.GetName(0);
//                updatingFontName = false;
                return;
            }
        }

//        private void fontComboBox_Leave(object sender, EventArgs e)
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

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.Cut();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.Paste();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.Copy();
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.Bold();
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.Italic();
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.Underline();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.SelectForeColor();
        }

        private void backColorButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.SelectBackColor();
        }

        private void linkButton_Click(object sender, EventArgs e)
        {
            SelectLink();
        }

        public void SelectLink()
        {
//                        using (LinkDialog dlg = new LinkDialog())
            //            {
            //                dlg.ShowDialog(this.ParentForm);
            //                if (!dlg.Accepted) return;
            //                string link = dlg.URI;
            //                if (link == null || link.Length == 0)
            //                {
            //                    MessageBox.Show(this.ParentForm, "Invalid URL");
            //                    return;
            //                }
            //                InsertLink(dlg.URL);
            //            }
            HtmlEditor.InsertLink();
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.InsertImage();
        }

        private void outdentButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.Indent();
        }

        private void indentButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.Outdent();
        }

        public bool Search(string text, bool forward, bool matchWholeWord, bool matchCase)
        {
            bool success = false;
            if (HtmlEditor.Document != null)
            {
                IHTMLDocument2 doc =
                    HtmlEditor.Document.DomDocument as IHTMLDocument2;
                IHTMLBodyElement body = doc.body as IHTMLBodyElement;
                if (body != null)
                {
                    IHTMLTxtRange range;
                    if (doc.selection != null)
                    {
                        range = doc.selection.createRange() as IHTMLTxtRange;
                        IHTMLTxtRange dup = range.duplicate();
                        dup.collapse(true);
                        // if selection is degenerate, then search whole body
                        if (range.isEqual(dup))
                        {
                            range = body.createTextRange();
                        }
                        else
                        {
                            if (forward)
                                range.moveStart("character", 1);
                            else
                                range.moveEnd("character", -1);
                        }
                    }
                    else
                        range = body.createTextRange();
                    int flags = 0;
                    if (matchWholeWord) flags += 2;
                    if (matchCase) flags += 4;
                    success =
                        range.findText(text, forward ? 999999 : -999999, flags);
                    if (success)
                    {
                        range.select();
                        range.scrollIntoView(!forward);
                    }
                }
            }
            return success;
        }

        private void orderedListButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.OrderedList();
        }

        private void unorderedListButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.UnorderedList();
        }

        private void justifyLeftButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.JustifyLeft();
        }

        private void justifyCenterButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.JustifyCenter();
        }

        private void justifyRightButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.JustifyRight();
        }

        private void justifyFullButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.JustifyFull();
        }

        private void rtlButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.SetRightToLeft();

            OnDirectionChanged(true);
        }

        private void ltrButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.SetLeftToRight();

            OnDirectionChanged(false);
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.StrikeThrough();
        }

        private void subScriptButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.SubScript();
        }

        private void superScriptButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.SupperScript();
        }

        private void rHtmlEditorToolbar_Load(object sender, EventArgs e)
        {
            SetupTimer();
            SetupFontComboBox();
            SetupFontSizeComboBox();
        }

        private void OnDirectionChanged(bool rightToLeft)
        {
            if(DirectionChanged != null)
            {
                DirectionChangedEventArgs args = new DirectionChangedEventArgs();
                args.IsRightToLeft = rightToLeft;
                DirectionChanged(this, args);
            }
        }

        private void tableButton_ButtonClick(object sender, EventArgs e)
        {
            HtmlEditor.InsertTable();
        }

        private void internalMediaButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.OnInternalMediaRequest();
        }

        private void externalMediaButton_Click(object sender, EventArgs e)
        {
            HtmlEditor.InsertExternalCode();
        }

    }

    public class DirectionChangedEventArgs : EventArgs
    {
        public bool IsRightToLeft { get; set; }
    }
}
