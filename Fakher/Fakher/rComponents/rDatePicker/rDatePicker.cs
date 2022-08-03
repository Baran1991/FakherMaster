using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace rComponents
{
    public partial class rDatePicker : RadMaskedEditBox, IValidatableControl
    {
        [Category("Validation")]
        public ValidationType ValidationType { get; set; }
        [Category("Validation")]
        public string FieldName { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PersianDate Date
        {
            get
            {
                try
                {
                    return PersianDate.FromString(Text.Trim());
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            set
            {
                if(value == null)
                    return;
                Value = Text = value.ToShortDateString().Substring(1);
            }
        }

        public rDatePicker()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Mask = "1###/##/##";
            MaskType = MaskType.Standard;
            RightToLeft = RightToLeft.No;
        }

        public rDatePicker(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }

        public void Validate()
        {
            if (!Enabled)
                return;
            if (ValidationType == ValidationType.NotEmpty)
            {
                if(Date == null)
                    throw new ValidationException(this, string.Format("مقدار {0} را انتخاب کنید.", FieldName));
            }
        }

        private void rDatePicker_Enter(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void rDatePicker_Initialized(object sender, EventArgs e)
        {
            if (ValidationType == ValidationType.NotEmpty)
            {
                (MaskedEditBoxElement.Children[2] as Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = Color.Red;
                (MaskedEditBoxElement.Children[2] as Telerik.WinControls.Primitives.BorderPrimitive).GradientStyle = GradientStyles.Linear;
            }
        }

    }
}
