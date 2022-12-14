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
    public partial class frmRequestDefaultAnsDtl : rRadDetailForm
    {
        public frmRequestDefaultAnsDtl(Notes notes)
        {
            InitializeComponent();
            SetProcessingObject(notes);
            ControlMappings.Add(new ControlMapping { Control = rTextBox18, ControlProperty = "Text", DataObject = notes, ObjectProperty = "Text" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = notes, ObjectProperty = "Title" });
        }
    }
}
