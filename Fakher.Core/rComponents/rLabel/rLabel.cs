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
    public partial class rLabel : RadLabel
    {
        public rLabel()
        {
            InitializeComponent();
            BackColor = Color.Transparent;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Font = new Font("Tahoma", 8.25f);
        }

        public rLabel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public override string ThemeClassName
        {
            get { return typeof(RadLabel).FullName; }
        }

    }
}
