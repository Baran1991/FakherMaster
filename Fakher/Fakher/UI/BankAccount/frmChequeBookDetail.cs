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

namespace Fakher.UI
{
    public partial class frmChequeBookDetail : rRadDetailForm
    {
        public frmChequeBookDetail(ChequeBook chequeBook)
        {
            InitializeComponent();
            SetProcessingObject(chequeBook);

            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Value", DataObject = chequeBook, ObjectProperty = "StartNumber" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Value", DataObject = chequeBook, ObjectProperty = "EndNumber" });
        }
    }
}
