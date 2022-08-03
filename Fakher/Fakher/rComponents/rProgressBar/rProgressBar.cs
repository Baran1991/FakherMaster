using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;

namespace rComponents
{
    public partial class rProgressBar : RadProgressBar
    {
        public rProgressBar()
        {
            InitializeComponent();
        }

        public rProgressBar(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
