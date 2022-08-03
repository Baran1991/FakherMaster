using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.Website;
using Telerik.WinControls.UI;
using MenuItem = Fakher.Core.Website.MenuItem;
using rComponents;

namespace Fakher.UI.Website
{
    public partial class frmMenuItemDetail : rRadDetailForm
    {
        public frmMenuItemDetail(MenuItem item)
        {
            InitializeComponent();

            IList<WebsiteSection> sections = WebsiteSection.GetWebsiteSections();
            rCmbSections.DataSource = sections;
            rCmbPageSections.DataSource = sections;
            rCmbArticleSections.DataSource = sections;

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox1,
                                        ControlProperty = "Text",
                                        DataObject = item,
                                        ObjectProperty = "Name"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTxtPosition,
                                        ControlProperty = "Value",
                                        DataObject = item,
                                        ObjectProperty = "Position"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox2,
                                        ControlProperty = "Text",
                                        DataObject = item,
                                        ObjectProperty = "Url"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rCmbPageSections,
                                        ControlProperty = "SelectedValue",
                                        DataObject = item,
                                        ObjectProperty = "SectionContainer"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rCmbSections,
                                        ControlProperty = "SelectedValue",
                                        DataObject = item,
                                        ObjectProperty = "WebsiteSection"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rCmbPages,
                                        ControlProperty = "SelectedValue",
                                        DataObject = item,
                                        ObjectProperty = "Webpage"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rCmbSections,
                                        ControlProperty = "SelectedValue",
                                        DataObject = item,
                                        ObjectProperty = "WebsiteSection"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rCmbArticles,
                                        ControlProperty = "SelectedValue",
                                        DataObject = item,
                                        ObjectProperty = "Webpage"
                                    });

            rRadioButton1.IsChecked = (item.Type == MenuItemType.StaticPage);
            rRadioButton2.IsChecked = (item.Type == MenuItemType.Url);
            rRadioButton3.IsChecked = (item.Type == MenuItemType.WebsiteSection);
            rRadioButton4.IsChecked = (item.Type == MenuItemType.Article);
        }

        protected override void AfterBindToObject()
        {
            MenuItem item = GetProcessingObject<MenuItem>();
            if(rRadioButton1.IsChecked)
                item.Type = MenuItemType.StaticPage;
            if(rRadioButton2.IsChecked)
                item.Type = MenuItemType.Url;
            if(rRadioButton3.IsChecked)
                item.Type = MenuItemType.WebsiteSection;
            if(rRadioButton4.IsChecked)
                item.Type = MenuItemType.Article;
        }

        private void rRadioButton1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rCmbPages.Enabled = rCmbPageSections.Enabled = rRadioButton1.IsChecked;
        }

        private void rRadioButton2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rTextBox2.Enabled = rRadioButton2.IsChecked;
        }

        private void rRadioButton3_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rCmbSections.Enabled = rRadioButton3.IsChecked;
        }

        private void rCmbPageSections_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            rCmbPages.DataSource = null;

            if (rCmbPageSections.SelectedIndex == -1)
                return;

            WebsiteSection section = rCmbPageSections.SelectedItem.DataBoundItem as WebsiteSection;
            if (section == null)
                return;

            rCmbPages.DataSource = section.GetWebpages(WebpageType.StaticPage);
        }

        private void rRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rCmbArticles.Enabled = rCmbArticleSections.Enabled = rRadioButton4.IsChecked;
        }

        private void rCmbArticleSections_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            rCmbArticles.DataSource = null;

            if (rCmbArticleSections.SelectedIndex == -1)
                return;

            WebsiteSection section = rCmbArticleSections.SelectedItem.DataBoundItem as WebsiteSection;
            if (section == null)
                return;

            rCmbArticles.DataSource = section.GetWebpages(WebpageType.Article);
        }
    }
}
