using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using rComponents;

namespace Fakher.UI.Poll
{
    public partial class frmPollList : rRadForm
    {
        public frmPollList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ شروع", ObjectProperty = "StartDateText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ پایان", ObjectProperty = "EndDateText" });

            List<Core.DomainModel.Poll.Poll> polls = DbContext.GetAllEntities<Core.DomainModel.Poll.Poll>();
            rGridView1.DataBind(polls);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Core.DomainModel.Poll.Poll poll = new Core.DomainModel.Poll.Poll();
            frmPollDetail frm = new frmPollDetail(poll);
            if (!frm.ProcessObject())
                return;
            poll.Save();
            rGridView1.Insert(poll);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Core.DomainModel.Poll.Poll poll = rGridView1.GetSelectedObject<Core.DomainModel.Poll.Poll>();
            frmPollDetail frm = new frmPollDetail(poll);
            if (!frm.ProcessObject())
                return;
            poll.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Core.DomainModel.Poll.Poll poll = rGridView1.GetSelectedObject<Core.DomainModel.Poll.Poll>();
            poll.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
