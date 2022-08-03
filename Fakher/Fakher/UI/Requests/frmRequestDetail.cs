using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Persons;
using Fakher.UI.Reception;
using rComponents;

namespace Fakher.UI.Educational.Students
{
    public partial class frmRequestDetail : rRadDetailForm
    {
        public bool SendSMS
        {
            get { return rChkSendSMS.Checked; }
        }

        public bool SendEmail
        {
            get { return rChkSendEmail.Checked; }
        }
        public Student selectedStudent;
        public frmRequestDetail(Request request, bool canReply)
        {
            InitializeComponent();
            rTextBox2.BackColor = Color.White;
            rTextBox2.ForeColor = Color.Black;
            if (request.Student != null)
            {
                studentInfo1.Student = request.Student;
                selectedStudent = request.Student;
            }
            if (selectedStudent.NoteList != null && selectedStudent.GetNotesByType(NotesType.Explanations_Req)!=null)
                if (selectedStudent.NoteList.Any())
                {
                    lnklblDesc.ForeColor = Color.Red;
                    lnklblDesc.BackColor = Color.Red;

                }

            ControlMappings.Add(new ControlMapping { Control = rDatePicker1, ControlProperty = "Date", DataObject = request, ObjectProperty = "Date" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = request, ObjectProperty = "Title" });
            ControlMappings.Add(new ControlMapping { Control = rCmbType, ControlProperty = "SelectedIndex", DataObject = request, ObjectProperty = "Type" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Text", DataObject = request, ObjectProperty = "Text" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox3, ControlProperty = "Text", DataObject = request, ObjectProperty = "Result" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox4, ControlProperty = "Text", DataObject = request, ObjectProperty = "Result2" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox5, ControlProperty = "Text", DataObject = request, ObjectProperty = "Text2" });
            ControlMappings.Add(new ControlMapping { Control = rComboBox1, ControlProperty = "SelectedIndex", DataObject = request, ObjectProperty = "Status" });
            //ControlMappings.Add(new ControlMapping { Control = rLabel6, ControlProperty = "Text", DataObject = request, ObjectProperty = "LastUpdate" });
            //ControlMappings.Add(new ControlMapping { Control = rLabel8, ControlProperty = "Text", DataObject = request, ObjectProperty = "Employee.FarsiFullname" });

            lblResDate1.Text = "" + request.resDate1 + " " + request.resHour1 + ":" + request.resMinute1+"  "+request.Employee;
            lblReqDate1.Text = request.CreateDateTime;

            lblResDate2.Text = "" + request.resDate2 + " " + request.resHour2 + ":" + request.resMinute2 + "  " + request.Employee2;
            lblReqDate2.Text = request.reqDate2 + " " + request.reqHour2 + ":" + request.reqMinute2;

            rComboBox1.DataSource = typeof(RequestStatus).GetEnumDescriptions();
            rCmbType.DataSource = typeof (RequestType).GetEnumDescriptions();
            lblLastUpdate.Text = request.LastUpdate;
            lblEmployee.Text = request.Employee != null ? request.Employee.FarsiFullname : "نامشخص";

            rTextBox3.ReadOnly = !canReply;
            
        }    
        private void lnkStudentPanel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowDialogForm(new frmReceptionPanel(selectedStudent) { AutoCloseUnitOfWork = false });
        }

        private void lnklblSMS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSmsDetail frm = new frmSmsDetail(selectedStudent.ContactInfo.Mobile);
            frm.ShowDialog(this);
        }

        private void lnklblSMSList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowChildForm(new frmStudentSMSList(selectedStudent));
        }

        private void lnklblDesc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Notes notes = new Notes();
            frmRequestNoteList frm = new frmRequestNoteList(selectedStudent);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            notes.NotesType = (NotesType)2;
            notes.Save();
        }

        private void lnkDefaultAns_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRequestDefaultAns frm = new frmRequestDefaultAns();
            frm.ShowDialog(this);
        }

        private void lnklblDesc_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Notes notes = new Notes();
            frmRequestNoteList frm = new frmRequestNoteList(selectedStudent);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            notes.NotesType = (NotesType)2;
            notes.Save();
        }
    }
}
