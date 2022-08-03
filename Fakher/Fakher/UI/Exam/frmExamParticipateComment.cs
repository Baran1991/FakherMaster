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
    public partial class frmExamParticipateComment : rRadDetailForm
    {
        public frmExamParticipateComment(ExamParticipate examParticipate)
        {
            InitializeComponent();

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox3,
                ControlProperty = "Value",
                DataObject = examParticipate,
                ObjectProperty = "Comment"
            });
        }
    }
}
