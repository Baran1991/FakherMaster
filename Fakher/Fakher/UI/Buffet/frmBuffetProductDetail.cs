using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel.Buffet;
using rComponents;

namespace Fakher.UI.Buffet
{
    public partial class frmBuffetProductDetail : rRadDetailForm
    {
        public frmBuffetProductDetail(BuffetProduct product)
        {
            InitializeComponent();
            SetProcessingObject(product);

            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = product, ObjectProperty = "Name" });
        }
    }
}
