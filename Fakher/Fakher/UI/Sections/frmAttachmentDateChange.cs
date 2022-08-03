using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Financial
{
    public partial class frmAttachmentDateChange : rRadDetailForm
    {
       
        public frmAttachmentDateChange(WebMedia media )
        {
            InitializeComponent();

           
            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker1,
                ControlProperty = "Date",
                DataObject = media,
                ObjectProperty = "StartDate"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker2,
                ControlProperty = "Date",
                DataObject = media,
                ObjectProperty = "EndDate"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = media,
                ObjectProperty = "StartTime"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox2,
                ControlProperty = "Text",
                DataObject = media,
                ObjectProperty = "EndTime"
            });
           
        }

       
       
      
    }
}
