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
using SortOrder = rComponents.SortOrder;

namespace Fakher.UI.Website
{
    public partial class frmNewsList : rRadForm
    {
        public frmNewsList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date.ToShortDateString()", SortOrder = SortOrder.Descending});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "دسته بندی", ObjectProperty = "CategoryText" });

            rGridView1.DataBind(WebNews.GetWebNews());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            WebNews news = new WebNews();
            frmNewsDetail frm = new frmNewsDetail(news);
            if (!frm.ProcessObject())
                return;
            news.Save();
            rGridView1.Insert(news);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            WebNews news = rGridView1.GetSelectedObject<WebNews>();
            frmNewsDetail frm = new frmNewsDetail(news);
            if (!frm.ProcessObject())
                return;
            news.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            WebNews news = rGridView1.GetSelectedObject<WebNews>();
            news.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
