using Fakher.Core.DomainModel;
using rComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fakher.UI.Persons
{
    public partial class frmRequestNoteList : rRadForm
    {
        public frmRequestNoteList(Core.DomainModel.Person person)
        {
            InitializeComponent();
            SetProcessingObject(person);
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "Text" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "اقدام کننده", ObjectProperty = "GetRegistrar()" });
            rGridView2.DataBind(person.NoteList.Where(m => m.NotesType==NotesType.Explanations_Req));
        }
        private void rGridView2_Add(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            Notes note = new Notes() { Person = person, Date = PersianDate.Today };
            frmRequestNoteDetail frm = new frmRequestNoteDetail(note);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            note.NotesType = NotesType.Explanations_Req;
            note.Save();
            rGridView2.Insert(note);
            rGridView2.Update();
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Notes note = rGridView2.GetSelectedObject<Notes>();
            note.RefreshEntity();

            frmRequestNoteDetail frm = new frmRequestNoteDetail(note);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            note.Save();
            rGridView2.UpdateGridView();
        }

    }
}
