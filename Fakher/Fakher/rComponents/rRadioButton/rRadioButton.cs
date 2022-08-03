using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace rComponents
{
    public partial class rRadioButton : RadRadioButton
    {
        public rRadioButton()
        {
            InitializeComponent();
            Initialize();
        }

        public rRadioButton(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RightToLeft = RightToLeft.Yes;
            Font = new Font("Tahoma", 8.25f);
        }

        public override string ThemeClassName
        {
            get { return typeof(RadRadioButton).FullName; }
        }

    }
}
