using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;
using Message = Fakher.Core.DomainModel.Message;

namespace Fakher.UI.Exam
{
    public partial class frmExamRequestDetail : rRadDetailForm
    {
        public Message Message { get; set; }

        public frmExamRequestDetail(ExamRequest request)
        {
            InitializeComponent();
//            Message = new Message();

            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = request, ObjectProperty = "ExamDate" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Value", DataObject = request, ObjectProperty = "Major" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Value", DataObject = request, ObjectProperty = "Lesson" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox3, ControlProperty = "Value", DataObject = request, ObjectProperty = "Section" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox8, ControlProperty = "Value", DataObject = request, ObjectProperty = "ParticipateCount" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox4, ControlProperty = "Value", DataObject = request, ObjectProperty = "Name" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox5, ControlProperty = "Value", DataObject = request, ObjectProperty = "StartTime" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox6, ControlProperty = "Value", DataObject = request, ObjectProperty = "EndTime" });

            if(request.Teacher.AllowedDepartments.Count == 1)
                receiverSelector1.AddReciever(request.Teacher.AllowedDepartments[0]);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ExamRequest request = GetProcessingObject<ExamRequest>();

            if (string.IsNullOrEmpty(rTextBox1.Text))
            {
                rMessageBox.ShowError("گیرنده پیام را انتخاب کنید.");
                CancelClosing();
                return;
            }

            
            Message = InternalPostMaster.FromExamRequest(request);

//            string text = "";
//            text += "تاریخ آزمون درخواستی: " + rDatePicker1.Date.ToShortDateString() + "\r\n";
//            text += "دوره/رشته: " + rTextBox2.Text + "\r\n";
//            text += "درس/سطح: " + rTextBox1.Text + "\r\n";
//            text += "گروه/کلاس: " + rTextBox3.Text + "\r\n";
//            text += "نام آزمون: " + rTextBox4.Text + "\r\n";
//            text += "از ساعت: " + rTextBox5.Text + "\r\n";
//            text += "تا ساعت: " + rTextBox6.Text + "\r\n";
//            text += "تعداد شرکت کننده: " + rTextBox8.Text + "\r\n";
//            text += "وضعیت: " + request.StatusText + "\r\n";
//            text += "\r\n";
//            Message.Body = text;

            Message.Receivers.Clear();
            foreach (Department selectedDepartment in receiverSelector1.SelectedDepartments)
                Message.AddReceiver(selectedDepartment);

//            Message.Subject = "درخواست آزمون";
//            Message.Sender = request.Teacher;
//            Message.SendDate = PersianDate.Today;
//            Message.SendTime = Time.Now.ToShortTimeString();
        }
    }
}
