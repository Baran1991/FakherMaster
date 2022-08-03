using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Buffet;
using Fakher.UI.Person;
using rComponents;

namespace Fakher.UI.Buffet
{
    public partial class frmBuffetSellerList : rRadForm
    {
        public frmBuffetSellerList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره پرونده پرسنلی", ObjectProperty = "Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام کاربری", ObjectProperty = "UserInfo.GetRawUsername()" });

            rGridView1.DataBind(BuffetSeller.GetBuffetSellers());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            BuffetSeller buffetSeller = new BuffetSeller();
            frmPersonDetail frm = new frmPersonDetail(buffetSeller);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            buffetSeller.Code = Core.DomainModel.Person.GetNextCode<BuffetSeller>();
            buffetSeller.Save();
            rGridView1.Insert(buffetSeller);
            rMessageBox.ShowInformation(string.Format("فروشنده [{0}] با شماره پرونده [{1}] ثبت گردید.", buffetSeller.FarsiFullname, buffetSeller.Code));
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            BuffetSeller buffetSeller = rGridView1.GetSelectedObject<BuffetSeller>();
            frmPersonDetail frm = new frmPersonDetail(buffetSeller);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            buffetSeller.Save();
            rGridView1.UpdateGridView();
        }
    }
}
