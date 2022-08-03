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
    public partial class frmExamBatchSignup : rRadForm
    {
        public frmExamBatchSignup()
        {
            InitializeComponent();
            
            listBox1.Font = Font;
        }

        private void SetProgressBar(int maximum)
        {
            progressBar1.Maximum = maximum;
            progressBar1.Value = 0;
            rLabel2.Text = progressBar1.Value + " از " + progressBar1.Maximum;
            Application.DoEvents();
        }

        private void ProgressBarIncrement()
        {
            progressBar1.Increment(1);
            rLabel2.Text = progressBar1.Value + " از " + progressBar1.Maximum;
            Application.DoEvents();
        }

        private void AddText(string text)
        {
            listBox1.Items.Add(text);
            Application.DoEvents();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                btnSignup.Enabled = false;
                AddText(string.Format("شروع"));

                foreach (Major major in Program.CurrentDepartment.Majors)
                {
                    IQueryable<ExamTrainingItem> items = major.GetGeneralExamItems(Program.CurrentPeriod);
                    if (items == null)
                    {
                        AddText(string.Format("آزمونهای آزاد رشته {0} در سیستم تعریف نشده است.", major.Name));
                        continue;
                    }

                    IList<Register> registers = Register.GetRegisters(Program.CurrentPeriod, major);
//                    IList<Participate> participates = Participate.GetParticipates(Program.CurrentPeriod, major);
                    SetProgressBar(registers.Count);

                    int count = 0;
                    foreach (Register register in registers)
                    {
//                        if(register.RegisterParticipation == RegisterParticipation.GeneralExamsOnly)
                        if(register.GetRegisterParticipation(false, true) == RegisterParticipation.GeneralExamsOnly)
                            continue;
                        bool saveFlag = false;
                        foreach (ExamTrainingItem examTrainingItem in items)
                        {
                            if (!register.IsEnrolled(examTrainingItem))
                            {
                                Enrollment enrollment = register.Enroll(examTrainingItem);
                                register.AddEnrollment(enrollment);
                                saveFlag = true;
                            }
                        }

                        List<Enrollment> enrollments = new List<Enrollment>();
                        foreach (Enrollment enrollment in register.Enrollments)
                        {
                            if(!(enrollment.TrainingItem is ExamTrainingItem))
                                continue;
                            if(enrollment.TrainingItem.Lesson.Major.Id != register.Major.Id)
                                enrollments.Add(enrollment);
                        }
                        register.Enrollments = register.Enrollments.Except(enrollments).ToList();

//                        if (saveFlag)
                        {
                            register.Save();
                            count++;
                        }
                        ProgressBarIncrement();
                    }
                    AddText(string.Format("تعداد {0} از {1} نفر از رشته {2} برای آزمون ها ثبت نام اولیه شدند.", count + "", registers.Count, major.Name));
                }
            }
            finally 
            {
                btnSignup.Enabled = true;
                AddText(string.Format("پایان"));
            }
        }
    }
}
