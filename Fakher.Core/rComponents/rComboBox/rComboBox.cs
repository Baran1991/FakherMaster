using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace rComponents
{
    public partial class rComboBox : RadDropDownList
    {
        public rComboBox()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            RightToLeft = RightToLeft.Yes;
            DropDownStyle = RadDropDownStyle.DropDownList;
        }

        public rComboBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }

        public override string ThemeClassName
        {
            get { return typeof(RadDropDownList).FullName; }
        }

        private void rComboBox_ItemDataBound(object sender, ListItemDataBoundEventArgs args)
        {
            args.NewItem.Font = Font;
        }
    }
}
