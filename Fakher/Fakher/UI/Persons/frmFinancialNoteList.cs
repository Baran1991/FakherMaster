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
    public partial class frmFinancialNoteList : rRadForm
    {
        public frmFinancialNoteList(Core.DomainModel.Person person)
        {
            InitializeComponent();
            SetProcessingObject(person);
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "Text" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView2.DataBind(person.NoteList.Where(m=>m.Financial));
            
        }
        private void rGridView2_Add(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            Notes note = new Notes() { Person = person,Date=PersianDate.Today,Financial=true };
            frmFinancialNoteDetail frm = new frmFinancialNoteDetail(note);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            note.Save();
            rGridView2.Insert(note);
            rGridView2.Update();
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Notes note = rGridView2.GetSelectedObject<Notes>();
            note.RefreshEntity();

            frmFinancialNoteDetail frm = new frmFinancialNoteDetail(note);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            note.Save();
            rGridView2.UpdateGridView();
        }

    }
}
