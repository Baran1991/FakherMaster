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
    public partial class frmWebpageList : rRadForm
    {
        public frmWebpageList()
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;

            rGridCmbSection.Columns.Add("نام", "نام", "Name");

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Id" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Id" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });

            rGridCmbSection.DataSource = WebsiteSection.GetWebsiteSections();
        }

        private void rGridCmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            WebsiteSection websiteSection = rGridCmbSection.GetValue<WebsiteSection>();

            rGridView1.Clear();
            rGridView2.Clear();
            if (websiteSection == null)
                return;

            IQueryable<Webpage> staticPages = websiteSection.GetWebpages(WebpageType.StaticPage);
            IQueryable<Webpage> articles = websiteSection.GetWebpages(WebpageType.Article);

            rGridView1.DataBind(staticPages);
            rGridView2.DataBind(articles);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            WebsiteSection websiteSection = rGridCmbSection.GetValue<WebsiteSection>();
            if (websiteSection == null)
                return;

            Webpage webpage = new Webpage { WebsiteSection = websiteSection, Type = WebpageType.StaticPage };
            frmWebpageDesigner frm = new frmWebpageDesigner(webpage);
            if (!frm.ProcessObject())
                return;
            websiteSection.AddPage(webpage);
            webpage.Save();
            rGridView1.Insert(webpage);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            WebsiteSection websiteSection = rGridCmbSection.GetValue<WebsiteSection>();
            if (websiteSection == null)
                return;

            Webpage webpage = rGridView1.GetSelectedObject<Webpage>();
            frmWebpageDesigner frm = new frmWebpageDesigner(webpage);
            if (!frm.ProcessObject())
                return;
            webpage.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            if (rMessageBox.ShowQuestion("از حذف کامل این صفحه از وب سایت، واقعا مطمئن هستید؟") != DialogResult.Yes)
                return;

            WebsiteSection websiteSection = rGridCmbSection.GetValue<WebsiteSection>();
            if (websiteSection == null)
                return;

            Webpage webpage = rGridView1.GetSelectedObject<Webpage>();
            websiteSection.Pages.Remove(webpage);
            webpage.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView2_Add(object sender, EventArgs e)
        {
            WebsiteSection websiteSection = rGridCmbSection.GetValue<WebsiteSection>();
            if (websiteSection == null)
                return;

            Webpage webpage = new Webpage { WebsiteSection = websiteSection, Type = WebpageType.Article };
            frmWebpageDesigner frm = new frmWebpageDesigner(webpage);
            if (!frm.ProcessObject())
                return;
            websiteSection.AddPage(webpage);
            webpage.Save();
            rGridView2.Insert(webpage);
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            WebsiteSection websiteSection = rGridCmbSection.GetValue<WebsiteSection>();
            if (websiteSection == null)
                return;

            Webpage webpage = rGridView2.GetSelectedObject<Webpage>();
            frmWebpageDesigner frm = new frmWebpageDesigner(webpage);
            if (!frm.ProcessObject())
                return;
            webpage.Save();
            rGridView2.UpdateGridView();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            if (rMessageBox.ShowQuestion("از حذف کامل این مقاله از وب سایت، واقعا مطمئن هستید؟") != DialogResult.Yes)
                return;

            WebsiteSection websiteSection = rGridCmbSection.GetValue<WebsiteSection>();
            if (websiteSection == null)
                return;

            Webpage webpage = rGridView2.GetSelectedObject<Webpage>();
            websiteSection.Pages.Remove(webpage);
            webpage.Delete();
            rGridView2.RemoveSelectedRow();
        }
    }
}
