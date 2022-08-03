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
    public partial class frmWebsiteWidgetList : rRadForm
    {
        public frmWebsiteWidgetList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "منـو", ObjectProperty = "MenuItem.Text" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ترتیب", ObjectProperty = "Position" });

            Fill();
        }

        private void Fill()
        {
            IList<WebsiteWidget> widgets = WebsiteWidget.GetWidgets();
            rGridView1.DataBind(widgets);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            WebsiteWidget widget = new WebsiteWidget();
            frmWebsiteWidgetDetail frm = new frmWebsiteWidgetDetail(widget);
            if (!frm.ProcessObject())
                return;
            widget.Save();
            rGridView1.Insert(widget);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            WebsiteWidget widget = rGridView1.GetSelectedObject<WebsiteWidget>();
            frmWebsiteWidgetDetail frm = new frmWebsiteWidgetDetail(widget);
            if (!frm.ProcessObject())
                return;
            widget.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            WebsiteWidget widget = rGridView1.GetSelectedObject<WebsiteWidget>();
            widget.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
