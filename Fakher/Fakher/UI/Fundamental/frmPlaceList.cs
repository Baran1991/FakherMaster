using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Struture
{
    public partial class frmPlaceList : rRadForm
    {
        public frmPlaceList()
        {
            InitializeComponent();
            rGridView1.Mappings.Add(new ColumnMapping { Caption="نام مکان", ObjectProperty="Name"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ظرفیت", ObjectProperty = "CapacityText" });
            rGridView1.DataBind(DbContext.GetAllEntities<Place>());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Place place = new Place();
            frmPlaceDetail frm = new frmPlaceDetail(place);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            place.Save();
            rGridView1.Insert(place);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Place place = rGridView1.GetSelectedObject<Place>();
            frmPlaceDetail frm = new frmPlaceDetail(place);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            place.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Place place = rGridView1.GetSelectedObject<Place>();
            place.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
