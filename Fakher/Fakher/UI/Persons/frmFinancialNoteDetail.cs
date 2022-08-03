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
    public partial class frmFinancialNoteDetail : rRadDetailForm
    {
        public frmFinancialNoteDetail(Notes Note)
        {
            InitializeComponent();
            SetProcessingObject(Note);
            ControlMappings.Add(new ControlMapping { Control = rTextBox18, ControlProperty = "Text", DataObject = Note, ObjectProperty = "Text" });
            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = Note, ObjectProperty = "Date" });
        }
    }
}
