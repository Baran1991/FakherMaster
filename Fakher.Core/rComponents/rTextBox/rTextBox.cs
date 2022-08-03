using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace rComponents
{
    public partial class rTextBox : RadTextBox
    {
        private rTextBoxType mType;
        private Regex regex;
        private string mRawText;
        private string mViewText;

        public bool Required { get; set; }

        public rTextBoxType Type
        {
            get { return mType; }
            set
            {
                mType = value;
                Text = "";

                if (mType == rTextBoxType.Text)
                {
                    regex = new Regex(".*");
                }
                if (mType == rTextBoxType.Numeric)
                {
                    regex = new Regex(@"^\d+$");
                    RightToLeft = RightToLeft.No;
                }
                if (mType == rTextBoxType.Money)
                {
                    regex = new Regex(@"^\d+$");
                    RightToLeft = RightToLeft.No;
                }
            }
        }

        public object Value
        {
            get
            {
                if (Type == rTextBoxType.Text)
                    return Text;
                if (Type == rTextBoxType.Numeric)
                {
                    try
                    {
                        return Int32.Parse(Text);
                    }
                    catch
                    {
                        return 0;
                    }
                }
                if (Type == rTextBoxType.Money)
                {
                    try
                    {
                        return Int32.Parse(Text);
//                        return Int32.Parse(mRawText);
                    }
                    catch
                    {
                        return 0;
                    }
                }
                return "";
            }
            set
            {
                Text = value + "";
            }
        }

        public TextboxLanguage Language { get; set; }

        public rTextBox()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            RightToLeft = RightToLeft.Yes;
            Type = rTextBoxType.Text;
            Text = "";
            Font = new Font("Tahoma", 8.25f);
            BackColor = Color.Transparent;
            Language = TextboxLanguage.English;
        }

        public rTextBox(IContainer container) : this()
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }

        public override string ThemeClassName
        {
            get { return typeof(RadTextBox).FullName; }
        }

        private void rTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Type == rTextBoxType.Numeric)
            {
                const char delete = (char) 8;
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != delete;
            }
            if (Type == rTextBoxType.Money)
            {
                const char delete = (char) 8;
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != delete;
//                if(e.KeyChar != delete)
//                {
//                    mRawText += e.KeyChar;
//                    Text = Int32.Parse(mRawText).ToString("C");
//                } 
            }
        }

        private void rTextBox_Initialized(object sender, EventArgs e)
        {
            if(Required)
                NullText = "<اجباری>";
        }

        private void rTextBox_Enter(object sender, EventArgs e)
        {
            if (Language == TextboxLanguage.Farsi)
            {
                Services.SetLanguageFarsi();
            }
            if(Language == TextboxLanguage.English)
            {
                Services.SetLanguageEnglish();
            }
        }
    }

    public enum rTextBoxType
    {
        Text,
        Numeric,
        Money,
        Date,
        Time
    }

    public enum TextboxLanguage
    {
        English,
        Farsi
    }
}
