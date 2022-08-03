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
    public partial class rGroupBox : RadGroupBox
    {
        public rGroupBox()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            GroupBoxStyle = RadGroupBoxStyle.Office;
            Font = new System.Drawing.Font("Tahoma", 8.25f);
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Padding = new Padding(2, 20, 2, 2);
        }

        public override string ThemeClassName
        {
            get { return typeof(RadGroupBox).FullName; }
        }

        public rGroupBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }
    }
}
