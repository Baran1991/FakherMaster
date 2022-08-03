using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Educational.Students
{
    public partial class frmBanDetail : rRadDetailForm
    {
        public frmBanDetail(Ban ban)
        {
            InitializeComponent();

            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = ban, ObjectProperty = "Reason" });
        }
    }
}
