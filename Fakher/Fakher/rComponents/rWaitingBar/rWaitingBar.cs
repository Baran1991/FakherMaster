using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;

namespace rComponents
{
    public partial class rWaitingBar : RadWaitingBar
    {
        public rWaitingBar()
        {
            InitializeComponent();
        }

        public rWaitingBar(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }
}
