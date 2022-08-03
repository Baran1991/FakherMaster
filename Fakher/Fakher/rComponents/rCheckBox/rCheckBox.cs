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
    public partial class rCheckBox : RadCheckBox
    {
        public rCheckBox()
        {
            InitializeComponent();
            Initialize();
        }

        public rCheckBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }

        public override string ThemeClassName
        {
            get { return typeof(RadCheckBox).FullName; }
        }

        private void Initialize()
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Font = new Font("Tahoma", 8.25f);
            BackColor = Color.Transparent;
        }
    }
}
