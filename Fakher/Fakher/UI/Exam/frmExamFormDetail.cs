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

namespace Fakher.UI.Exam
{
    public partial class frmExamFormDetail : rRadDetailForm
    {
        public frmExamFormDetail(ExamForm examForm)
        {
            InitializeComponent();
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = examForm,
                ObjectProperty = "Name"
            });
        }
    }
}
