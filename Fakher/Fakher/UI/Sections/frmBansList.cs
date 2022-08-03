using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Educational.Students;
using rComponents;

namespace Fakher.UI.Educational.Sections
{
    public partial class frmBansList : rRadForm
    {
        public frmBansList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Register.Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Participate.Register.Code" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Participate.Register.Student.FarsiFirstName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Participate.Register.Student.FarsiLastName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "علت", ObjectProperty = "Reason" });
        }

        private void sectionItemSelector1_SelectedChanged(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            if(sectionItemSelector1.SectionItem == null)
                return;
            rGridView1.DataBind(sectionItemSelector1.SectionItem.GetParticipates());
            rGridView2.DataBind(sectionItemSelector1.SectionItem.GetBans(BanStatus.Active));
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Participate participate = rGridView1.GetSelectedObject<Participate>();
            if(participate == null)
                return;
            if(participate.GetBans(BanStatus.Active).Count() > 0)
            {
                rMessageBox.ShowError("برای این دانشجو قبلا تعلیق ثبت شده است.");
                return;
            }

            Ban ban = new Ban();
            frmBanDetail frm = new frmBanDetail(ban);
            if(!frm.ProcessObject())
                return;
            ban.Participate = participate;
            participate.Bans.Add(ban);
            participate.Save();
            Fill();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            Ban ban = rGridView2.GetSelectedObject<Ban>();
            if (rMessageBox.ShowQuestion(string.Format("از ثبت پایان تعلیق {0} اطمینان دارید؟", ban.Participate.Register.Student.FarsiFullname)) != DialogResult.Yes)
                return;

            ban.EndDate = PersianDate.Today;
            ban.Status = BanStatus.Canceled;
            ban.Participate.Save();
            Fill();
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Ban ban = rGridView2.GetSelectedObject<Ban>();
            frmBanDetail frm = new frmBanDetail(ban);
            if(!frm.ProcessObject())
                return;
            ban.Save();
            rGridView2.UpdateGridView();
        }
    }
}
