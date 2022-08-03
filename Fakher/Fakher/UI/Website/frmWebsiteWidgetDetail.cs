using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.UI.Website
{
    public partial class frmWebsiteWidgetDetail : rRadDetailForm
    {
        private bool mMenuItemSet;

        public frmWebsiteWidgetDetail(WebsiteWidget widget)
        {
            InitializeComponent();
            SetProcessingObject(widget);

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = widget,
                ObjectProperty = "Title"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox2,
                ControlProperty = "Text",
                DataObject = widget,
                ObjectProperty = "Text"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTxtPosition,
                ControlProperty = "Value",
                DataObject = widget,
                ObjectProperty = "Position"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rCheckBox1,
                ControlProperty = "IsChecked",
                DataObject = widget,
                ObjectProperty = "IsActive"
            });

            rLblMenuItemText.Text = widget.MenuItem.Text;
        }

        private void lnkMenuItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WebsiteWidget widget = GetProcessingObject<WebsiteWidget>();
            if (!string.IsNullOrEmpty(rTextBox1.Text.Trim()) && string.IsNullOrEmpty(widget.MenuItem.Name))
                widget.MenuItem.Name = rTextBox1.Text.Trim();
            frmMenuItemDetail frm = new frmMenuItemDetail(widget.MenuItem);
            if (!frm.ProcessObject())
                return;

            rLblMenuItemText.Text = widget.MenuItem.Text;
            mMenuItemSet = true;
        }

        protected override void AfterValidate()
        {
            WebsiteWidget widget = GetProcessingObject<WebsiteWidget>();

            if(widget.Id == 0 && !mMenuItemSet)
            {
                rMessageBox.ShowError("منوی ویجت را تنظیم کنید.");
                CancelClosing();
                return;
            }
        }
    }
}
