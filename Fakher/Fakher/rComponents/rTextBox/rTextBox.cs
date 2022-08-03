using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace rComponents
{
    public partial class rTextBox : RadMaskedEditBox, IValidatableControl
    {
        private int mCount;
        private rTextBoxType mType;

        public rTextBoxType Type
        {
            get { return mType; }
            set 
            {
                mType = value;
                Mask = "";
                if (mType == rTextBoxType.BankCardNumber)
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    Mask = "####,####,####,####";
                    MaskType = MaskType.Standard;
                    RightToLeft = RightToLeft.No;
                }
                if (mType == rTextBoxType.ShabaNumber)
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    Mask = "####,####,####,####,####,####";
                    MaskType = MaskType.Standard;
                    RightToLeft = RightToLeft.No;
                }

                if (mType == rTextBoxType.Text)
                {
                    MaskType = MaskType.Standard;
//                    MaskType = MaskType.Regex;
                    Mask = "";
//                    Mask = ".*";
                }
                if (mType == rTextBoxType.Numeric)
                {
                    MaskType = MaskType.Numeric;
                    Mask = "D";
//                    Mask = "g";
                    RightToLeft = RightToLeft.No;
                }
                if (mType == rTextBoxType.Float)
                {
                    MaskType = MaskType.Numeric;
                    Mask = "F";
                    RightToLeft = RightToLeft.No;
                }
                if (mType == rTextBoxType.Money)
                {
                    MaskType = MaskType.Numeric;
                    Mask = "c0";
                    RightToLeft = RightToLeft.No;
                }
                if(mType == rTextBoxType.Date)
                {
                    MaskType = MaskType.DateTime;
                    Mask = "d";
                    RightToLeft = RightToLeft.No;
                }
                if(mType == rTextBoxType.Time)
                {
                    MaskType = MaskType.DateTime;
                    Mask = "HH:mm";
                    RightToLeft = RightToLeft.No;
                }
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new object Value
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
                if (Type == rTextBoxType.Float)
                {
                    try
                    {
                        return float.Parse(Text);
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
                        return long.Parse(Text.Replace(",", "").Replace("ریال", ""));
                    }
                    catch
                    {
                        return 0;
                    }
                }
                if(Type == rTextBoxType.Date)
                {
                    try
                    {
                        return PersianDate.FromString(Text);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
                if(Type == rTextBoxType.Time)
                {
                    return Text;
                }
                return "";
            }
            set
            {
                Text = value + "";
//                if (MaskType == MaskType.DateTime)
//                {
//                    DateTime dateTime = DateTime.Now;
//                    Time fromString = Time.FromString(value + "");
//                    if (fromString != null)
//                    {
//                        DateTime datetime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, fromString.Hour,
//                                                         fromString.Minute, fromString.Second, 0);
//                        base.Value = dateTime;
//                    }
//                }
//                else
//                {
//                    base.Value = value;
//                }
            }
        }
        public TextboxLanguage Language { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get
            {
                return Services.NormalizeFarsiString(base.Text);
            }
            set
            {
                base.Text = value;
                if (MaskType == MaskType.DateTime)
                {
                    if(!string.IsNullOrEmpty(value))
                    {
                        DateTime now = DateTime.Now;
                        Time fromString = Time.FromString(value);
                        DateTime dateTime = new DateTime(now.Year, now.Month, now.Day, fromString.Hour,
                                                         fromString.Minute, fromString.Second, 0);
                        base.Value = dateTime;
                    }
                }
                else
                {
//                    base.Text = value;
                    base.Value = value;
                }
            }
        }
        [Category("Validation")]
        public ValidationType ValidationType { get; set; }
        [Category("Validation")]
        public string FieldName { get; set; }
        [Category("Validation")]
        public string ValidatingProperty { get; set; }
        [Category("Validation")]
        public string MinimumValue { get; set; }
        [Category("Validation")]
        public string MaximumValue { get; set; }
        public new event KeyEventHandler KeyDown;
        public new event KeyEventHandler KeyUp;
        public new event KeyPressEventHandler KeyPress;

        public rTextBox()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RightToLeft = RightToLeft.Yes;
            Type = rTextBoxType.Text;
//            PlaceHolder = '\0';
//            CausesValidation = false;
            Text = "";
            Font = new Font("Tahoma", 8.25f);
            Language = TextboxLanguage.DontCare;
            MaskedEditBoxElement.KeyDown += new KeyEventHandler(MaskedEditBoxElement_KeyDown);
            MaskedEditBoxElement.KeyPress += new KeyPressEventHandler(MaskedEditBoxElement_KeyPress);
            MaskedEditBoxElement.KeyUp += new KeyEventHandler(MaskedEditBoxElement_KeyUp);
        }

        private void MaskedEditBoxElement_KeyUp(object sender, KeyEventArgs e)
        {
            if (KeyUp != null)
                KeyUp(this, e);
        }

        private void MaskedEditBoxElement_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyDown != null)
                KeyDown(this, e);
//            if (e.KeyData == Keys.D0)
//                Text = "0";
        }

        private void MaskedEditBoxElement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPress != null)
                KeyPress(this, e);
            if (Type == rTextBoxType.Time)
            {
                mCount++;
                if (mCount == 2)
                {
                    SendKeys.Send("{RIGHT}");
                }
            }
        }

        public rTextBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }

        public override string ThemeClassName
        {
            get { return typeof(RadMaskedEditBox).FullName; }
        }

        private void rTextBox_Initialized(object sender, EventArgs e)
        {
            if (ValidationType == ValidationType.NotEmpty || ValidationType == ValidationType.InRange)
            {
                (MaskedEditBoxElement.Children[2] as Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = Color.Red;
                (MaskedEditBoxElement.Children[2] as Telerik.WinControls.Primitives.BorderPrimitive).GradientStyle = GradientStyles.Linear;
            }
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
            if (Type == rTextBoxType.Time)
            {
                SendKeys.Send("{RIGHT}");
                SendKeys.Send("{LEFT}");
                mCount = 0;
            }
            SelectAll();
        }

        public T GetValue<T>()
        {
            try
            {
                if (string.IsNullOrEmpty(Text))
                    return default(T);
                return (T) Convert.ChangeType(Value, typeof(T));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Validate()
        {
            if (!Enabled)
                return;

            if(ValidationType == ValidationType.NotEmpty)
                if(string.IsNullOrEmpty(Text.Trim()))
                    throw new ValidationException(this, string.Format("مقدار {0} را وارد کنید.", FieldName));
            if(ValidationType == ValidationType.InRange && Type == rTextBoxType.Numeric)
            {
                int value = GetValue<int>();
                if (!string.IsNullOrEmpty(MinimumValue))
                {
                    int minimumValue = Convert.ToInt32(MinimumValue);
                    if (value < minimumValue)
                        throw new ValidationException(this, string.Format("مقدار {0} باید بزرگتر از {1} باشد.", FieldName, minimumValue));
                }
                if (!string.IsNullOrEmpty(MaximumValue))
                {
                    int maximumValue = Convert.ToInt32(MaximumValue);
                    if (value > maximumValue)
                        throw new ValidationException(this, string.Format("مقدار {0} باید کوچکتر از {1} باشد.", FieldName, maximumValue));
                }
            }
            if(ValidationType == ValidationType.InRange && Type == rTextBoxType.Money)
            {
                long value = GetValue<long>();
                if (!string.IsNullOrEmpty(MinimumValue))
                {
                    int minimumValue = Convert.ToInt32(MinimumValue);
                    if (value < minimumValue)
                        throw new ValidationException(this, string.Format("مقدار {0} باید بزرگتر از {1} باشد.", FieldName, minimumValue));
                }
                if (!string.IsNullOrEmpty(MaximumValue))
                {
                    int maximumValue = Convert.ToInt32(MaximumValue);
                    if (value > maximumValue)
                        throw new ValidationException(this, string.Format("مقدار {0} باید کوچکتر از {1} باشد.", FieldName, maximumValue));
                }
            }
        }

        private void rTextBox_Leave(object sender, EventArgs e)
        {

        }
    }

    public enum rTextBoxType
    {
        Text,
        Numeric,
        Float,
        Money,
        Date,
        Time,
        BankCardNumber,
        ShabaNumber
    }

    public enum TextboxLanguage
    {
        DontCare,
        English,
        Farsi
    }
}
