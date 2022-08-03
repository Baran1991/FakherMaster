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

namespace Fakher.UI.Educational
{
    public partial class frmSectionItemDetail : rRadDetailForm
    {
        public frmSectionItemDetail(SectionItem item)
        {
            InitializeComponent();
            rGridComboBox1.Columns.Add("کد درس", "کد درس" , "Code");
            rGridComboBox1.Columns.Add("نام درس", "نام درس", "Name");
            if(item.Section.Major != null)
                rGridComboBox1.DataSource = item.Section.Major.Lessons;

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rGridComboBox1,
                                        ControlProperty = "Value",
                                        DataObject = item,
                                        ObjectProperty = "Lesson"
                                    });

//            ControlMappings.Add(new ControlMapping
//                                    {
//                                        Control = rTextBox1,
//                                        ControlProperty = "Value",
//                                        DataObject = item,
//                                        ObjectProperty = "StartSession"
//                                    });
//
//            ControlMappings.Add(new ControlMapping
//                                    {
//                                        Control = rTextBox2,
//                                        ControlProperty = "Value",
//                                        DataObject = item,
//                                        ObjectProperty = "EndSession"
//                                    });
//
//            ControlMappings.Add(new ControlMapping
//                                    {
//                                        Control = rTextBox4,
//                                        ControlProperty = "Value",
//                                        DataObject = item,
//                                        ObjectProperty = "TuitionFee"
//                                    });
        }

        public frmSectionItemDetail(SectionItem item, Major major) : this(item)
        {
            rGridComboBox1.DataSource = major.Lessons;
        }

    }
}
