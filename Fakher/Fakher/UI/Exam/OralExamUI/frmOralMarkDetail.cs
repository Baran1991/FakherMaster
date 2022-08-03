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
    public partial class frmOralMarkDetail : rRadDetailForm
    {
        public frmOralMarkDetail(OralMark mark)
        {
            InitializeComponent();

            ControlMappings.Add(new ControlMapping
            {
                Control = rDatePicker1,
                ControlProperty = "Date",
                DataObject = mark,
                ObjectProperty = "Date"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Value",
                DataObject = mark,
                ObjectProperty = "Value",
                ConvertNeeded = true
            });
        }

        #region Overrides of rRadDetailForm

        protected override void AfterBindToObject()
        {
            OralMark mark = GetProcessingObject<OralMark>();
            if(mark.Value > mark.Participate.ExamForm.Exam.EvaluationItem.Value)
            {
                rMessageBox.ShowError(
                    "مقدار نمره وارد شده بیش از نمره مجاز آزمون است. حداکثر نمره مجاز این آزمون {0} است",
                    mark.Participate.ExamForm.Exam.EvaluationItem.Value + "");
                CancelClosing();
                return;
            }
        }

        #endregion
    }
}
