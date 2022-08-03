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
using Fakher.UI.Persons;
using Fakher.UI.Reception;
using rComponents;

namespace Fakher.UI.Educational.Students
{
    public partial class frmRequestDefaultAns : rRadForm
    {
        public frmRequestDefaultAns()
        {

            InitializeComponent();
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "Text" });
            rGridView1.DataBind(Notes.GetNotesByType(NotesType.DefaultAnswers));

        }
        private void rGridView1_Add(object sender, EventArgs e)
        {

            Notes ans= new Notes();
            frmRequestDefaultAnsDtl frm = new frmRequestDefaultAnsDtl(ans);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            ans.NotesType = NotesType.DefaultAnswers;
            ans.Save();
            rGridView1.Insert(ans);
            rGridView1.Update();
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Notes notes= rGridView1.GetSelectedObject<Notes>();
            notes.RefreshEntity();

            frmRequestDefaultAnsDtl frm = new frmRequestDefaultAnsDtl(notes);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            notes.Save();
            rGridView1.UpdateGridView();
        }
        private void rGridView1_Delete(object sender, EventArgs e)
        {

            Notes ans = rGridView1.GetSelectedObject<Notes>();            
            ans.Delete();
            rGridView1.RemoveSelectedRow();
            rGridView1.Update();
        }
    }
}
