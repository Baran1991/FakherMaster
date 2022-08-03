using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace rComponents
{
    public partial class rDatePicker : RadMaskedEditBox
    {
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
                Value = Text = (value + "").Substring(2);
            }
        }

        public rDatePicker()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Mask = "13##/##/##";
            MaskType = MaskType.Standard;
            RightToLeft = RightToLeft.No;
            Date = PersianDate.Today;
        }

        public rDatePicker(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }
    }
}
