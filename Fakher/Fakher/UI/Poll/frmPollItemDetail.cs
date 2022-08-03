using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel.Poll;
using rComponents;

namespace Fakher.UI.Poll
{
    public partial class frmPollItemDetail : rRadDetailForm
    {
        public frmPollItemDetail(PollItem item)
        {
            InitializeComponent();

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox1,
                                        ControlProperty = "Text",
                                        DataObject = item,
                                        ObjectProperty = "Text"
                                    });
        }
    }
}
