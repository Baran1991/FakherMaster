using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Educational.Reserves;
using Fakher.UI.Educational.Students;
using Fakher.UI.Persons;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Educational
{
    public partial class frmEducationalHistory : rRadForm
    {
        private Student SelectedPerson;
        public frmEducationalHistory(Student student)
        {
            InitializeComponent();
            SetProcessingObject(student);
            SelectedPerson = student;
            radPageView1.SelectedPage = radPageViewPage1;
            radPageView2.SelectedPage = radPageViewPage7;
            radPageView3.SelectedPage = radPageViewPage9;

            rGridViewRegisters.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Code", TextAlign = HorizontalAlignment.Center});
            rGridViewRegisters.Mappings.Add(new ColumnMapping { Caption = "دپارتمان", ObjectProperty = "Major.Department.Name" });
            rGridViewRegisters.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name"});
            rGridViewRegisters.Mappings.Add(new ColumnMapping { Caption = "دوره/ترم آموزشی", ObjectProperty = "Period.Name" });
            rGridViewRegisters.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });
            rGridViewRegisters.Mappings.Add(new ColumnMapping { Caption = "وضعیت آموزشی", ObjectProperty = "StatusText" });
            rGridViewRegisters.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت نام", ObjectProperty = "RegisterDate" });
            rGridViewRegisters.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت نام", ObjectProperty = "EnrollmentTypeText" });
            rGridViewRegisters.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Id" });

            rGridViewParticipates.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "SectionItem.Lesson.Name" });
            rGridViewParticipates.Mappings.Add(new ColumnMapping { Caption = "گـروه", ObjectProperty = "SectionItem.Section.Name" });
            rGridViewParticipates.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت نام", ObjectProperty = "Date" });
            rGridViewParticipates.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت نام", ObjectProperty = "EnrollmentTypeText" });
            rGridViewParticipates.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Id" });

            rGridViewReserves.Mappings.Add(new ColumnMapping { Caption = "شماره رزرو", ObjectProperty = "Code" });
            rGridViewReserves.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "ReserveList.Major.Name" });
            rGridViewReserves.Mappings.Add(new ColumnMapping { Caption = "لیست رزرو", ObjectProperty = "ReserveList.Name" });
            rGridViewReserves.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت نام", ObjectProperty = "ReserveDate" });
            rGridViewReserves.Mappings.Add(new ColumnMapping { Caption = "وضعیت آموزشی", ObjectProperty = "StatusText" });
            rGridViewReserves.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });

            rGridViewBans.Mappings.Add(new ColumnMapping { Caption = "تاریخ شروع", ObjectProperty = "StartDate" });
            rGridViewBans.Mappings.Add(new ColumnMapping { Caption = "تاریخ پایان", ObjectProperty = "EndDate" });
            rGridViewBans.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Participate.SectionItem.Section.Major.Name" });
            rGridViewBans.Mappings.Add(new ColumnMapping { Caption = "گروه", ObjectProperty = "Participate.SectionItem" });
            rGridViewBans.Mappings.Add(new ColumnMapping { Caption = "علت", ObjectProperty = "Reason" });

            rGridViewVacationRegisters.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Code", TextAlign = HorizontalAlignment.Center });
            rGridViewVacationRegisters.Mappings.Add(new ColumnMapping { Caption = "دپارتمان", ObjectProperty = "Major.Department.Name" });
            rGridViewVacationRegisters.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridViewVacationRegisters.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });
            rGridViewVacationRegisters.Mappings.Add(new ColumnMapping { Caption = "وضعیت آموزشی", ObjectProperty = "StatusText" });
            rGridViewVacationRegisters.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "RegisterDate" });

            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Code" });
            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "ExamForm.Exam.Date" });
            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "نام آزمون", ObjectProperty = "ExamForm.Exam.Name" });
            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "آیتم ارزشیابی", ObjectProperty = "ExamForm.Exam.EvaluationItem.Name" });
            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "فرم آزمون", ObjectProperty = "ExamForm.Name" });
            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "شماره آزمون", ObjectProperty = "SeatNumber" });
            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });

            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Code", TextAlign = HorizontalAlignment.Center });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "شماره انصرافی", ObjectProperty = "Quit.Code", TextAlign = HorizontalAlignment.Center });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "دوره/ترم آموزشی", ObjectProperty = "Period.Name" });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "دپارتمان", ObjectProperty = "Major.Department.Name" });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "Quit.StatusText" });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت نام", ObjectProperty = "RegisterDate" });
            rGridViewQuits.CustomButtons.Add(new rGridViewButton {VisibleOnSelect = true, Text = "چاپ رسید", Position = rGridViewButtonPosition.After});

            rGridViewTransition.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Code", TextAlign = HorizontalAlignment.Center });
            rGridViewTransition.Mappings.Add(new ColumnMapping { Caption = "شماره انتقالی", ObjectProperty = "Transition.Code", TextAlign = HorizontalAlignment.Center });
            rGridViewTransition.Mappings.Add(new ColumnMapping { Caption = "دوره/ترم آموزشی", ObjectProperty = "Period.Name" });
            rGridViewTransition.Mappings.Add(new ColumnMapping { Caption = "دپارتمان", ObjectProperty = "Major.Department.Name" });
            rGridViewTransition.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridViewTransition.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });
            rGridViewTransition.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "Transition.StatusText" });
            rGridViewTransition.Mappings.Add(new ColumnMapping { Caption = "شعبه مقصد", ObjectProperty = "Transition.BranchName" });
            rGridViewTransition.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت نام", ObjectProperty = "RegisterDate" });
            rGridViewTransition.CustomButtons.Add(new rGridViewButton { VisibleOnSelect = true, Text = "چاپ رسید", Position = rGridViewButtonPosition.After });


            rGridQuitedReserves.Mappings.Add(new ColumnMapping { Caption = "شماره رزرو", ObjectProperty = "Code" });
            rGridQuitedReserves.Mappings.Add(new ColumnMapping { Caption = "لیست رزرو", ObjectProperty = "ReserveList.Name" });
            rGridQuitedReserves.Mappings.Add(new ColumnMapping { Caption = "شماره انصرافی", ObjectProperty = "Quit.Code", TextAlign = HorizontalAlignment.Center });
            rGridQuitedReserves.Mappings.Add(new ColumnMapping { Caption = "تاریخ انصراف", ObjectProperty = "Quit.Date", TextAlign = HorizontalAlignment.Center });
            rGridQuitedReserves.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "Text" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView2.DataBind(SelectedPerson.NoteList.Where(m => m.Financial));

            IList<Register> registers = student.GetRegisters(RegisterType.Participation);
            IList<Ban> bans = student.GetBans().ToList();
            List<Register> vacationRegisters = new List<Register>();
            List<Register> quitRegisters = new List<Register>();
            List<Register> transitionRegisters = new List<Register>();
            List<Reserve> reserves = new List<Reserve>();
            List<Reserve> quitReserves = new List<Reserve>();

            foreach (Reserve reserve in student.Reserves)
            {
                if(reserve.QuitedSign == 0)
                    reserves.Add(reserve);
                if(reserve.QuitedSign == 1)
                    quitReserves.Add(reserve);
            }
            foreach (Register register in student.GetRegisters(RegisterType.TermVacation))
                vacationRegisters.Add(register);
            foreach (Register register in student.GetRegisters(RegisterType.PartialVacation))
                vacationRegisters.Add(register);
            foreach (Register register in student.Registers)
            {
                if (register.Type == RegisterType.FullQuited)
                    quitRegisters.Add(register);
               else if (register.Type == RegisterType.Transmition)
                    transitionRegisters.Add(register);
            }
            rGridViewRegisters.DataBind(registers);
            rGridViewReserves.DataBind(reserves);
            rGridViewBans.DataBind(bans);
            rGridViewVacationRegisters.DataBind(vacationRegisters);
            rGridViewQuits.DataBind(quitRegisters);
            rGridViewTransition.DataBind(transitionRegisters);
            rGridQuitedReserves.DataBind(quitReserves);

            int quitCount = quitRegisters.Count + quitReserves.Count;
            int transitionCount = transitionRegisters.Count ;
            if (registers.Count > 0)
                radPageViewPage1.Text += " (" + registers.Count + ")";
            if (reserves.Count > 0)
                radPageViewPage3.Text += " (" + student.Reserves.Count + ")";
            if (bans.Count > 0)
                radPageViewPage4.Text += " (" + bans.Count + ")";
            if (vacationRegisters.Count > 0)
                radPageViewPage5.Text += " (" + vacationRegisters.Count + ")";
            if (quitCount > 0)
            {
                radPageViewPage6.Text += " (" + quitCount + ")";
                if(quitRegisters.Count > 0)
                    radPageViewPage7.Text += " (" + quitRegisters.Count + ")";
                if (quitReserves.Count > 0)
                    radPageViewPage8.Text += " (" + quitReserves.Count + ")";
            }
            if (transitionCount > 0)
            {
                radPageViewPage2.Text += " (" + transitionCount + ")";
               
            }
        }
        private void rGridView2_Add(object sender, EventArgs e)
        {
            //Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            Notes note = new Notes() { Person = SelectedPerson, Date = PersianDate.Today, Financial = true };
            frmFinancialNoteDetail frm = new frmFinancialNoteDetail(note);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            note.Save();
            rGridView2.Insert(note);
            this.radPageViewPage11.BackColor = System.Drawing.Color.Red;
            rGridView2.Update();
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Notes note = rGridView2.GetSelectedObject<Notes>();
            note.RefreshEntity();

            frmFinancialNoteDetail frm = new frmFinancialNoteDetail(note);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            note.Save();
            rGridView2.UpdateGridView();
        }
        private void rGridViewRegisters_SelectedItemChanged(object sender, EventArgs e)
        {
            Register register = rGridViewRegisters.GetSelectedObject<Register>();
            rGridViewParticipates.Clear();
            if(register == null)
                return;
            SelectRegister(register);
        }
        private void ClearGrids()
        {
            rGridViewParticipates.Clear();
            rGridViewExamParticipates.Clear();
            rGridViewReserves.Clear();
        }

        private void SelectRegister(Register register)
        {
            ClearGrids();
            rGridViewParticipates.DataBind(register.Participates);
            rGridViewExamParticipates.DataBind(register.GetExamParticipates());
        }

        private void rGridViewRegisters_Edit(object sender, EventArgs e)
        {
            Register register = rGridViewRegisters.GetSelectedObject<Register>();
            if (register.Type == RegisterType.Participation)
            {
                register.RefreshEntity();
                frmRegister frm = new frmRegister(register);
                if (frm.ShowDialog(this) != DialogResult.OK)
                    return;

                register.Save();
                rGridViewRegisters.UpdateGridView();

                Program.SaveLog(string.Format("ویرایش [{0}]", register.ToString()));
            }
//            if(register.Type == RegisterType.FullQuited)
//            {
//                frmRegisterQuits frm = new frmRegisterQuits(register);
//                if(frm.ShowDialog(this) != DialogResult.OK)
//                    return;
//            }
        }

        private void rGridViewParticipates_Edit(object sender, EventArgs e)
        {
            Register register = rGridViewRegisters.GetSelectedObject<Register>();
            Participate participate = rGridViewParticipates.GetSelectedObject<Participate>();
        }

        private void rGridViewRegisters_Delete(object sender, EventArgs e)
        {
            if(rMessageBox.ShowQuestion("با حذف، کلیه سوابق ثبت نامی شخص در این ترم از بین خواهد رفت. آیا مطمئن هستید ؟") != DialogResult.Yes)
                return;
            if(rMessageBox.ShowQuestion("این عمل غیرقابل بازگشت است و کل ثبت نام مالی و آموزشی فرد در سیستم حذف خواهد شد. آیا واقعا مطمئن هستید؟") != DialogResult.Yes)
                return;

            Register register = rGridViewRegisters.GetSelectedObject<Register>();
            try
            {
                for (int i = register.Participates.Count - 1; i >= 0 ; i--)
                {
                    Participate participate = register.Participates[i];
                    register.Participates.Remove(participate);
                    foreach (ExamParticipate examParticipate in participate.GetExamParticipates())
                    {
                        register.RemoveExamParticipate(examParticipate);
                        examParticipate.Delete();
                    }
                    participate.Delete();
                }

                for (int j = register.Student.Reserves.Count - 1; j >= 0 ; j--)
                {
                    Reserve reserve = register.Student.Reserves[j];
                    register.Student.Reserves.Remove(reserve);
                    reserve.Delete();
                }

                for (int k = register.Enrollments.Count - 1; k >= 0; k--)
                {
                    Enrollment enrollment = register.Enrollments[k];
                    register.Enrollments.Remove(enrollment);
                    enrollment.Delete();
                }

                register.Student.Registers.Remove(register);
                register.Delete();
                rGridViewRegisters.RemoveSelectedRow();
                ClearGrids();

                Program.SaveLog(string.Format("حذف [{0}]", register.ToString()));
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void rGridViewReserves_Edit(object sender, EventArgs e)
        {
            Reserve reserve = rGridViewReserves.GetSelectedObject<Reserve>();
            frmReserveDetail frm = new frmReserveDetail(reserve);
            if(!frm.ProcessObject())
                return;
            reserve.Save();
            rGridViewReserves.UpdateGridView();

            Program.SaveLog(string.Format("ویرایش [{0}]", reserve.ToString()));
        }

        private void rGridViewReserves_Delete(object sender, EventArgs e)
        {
            Reserve reserve = rGridViewReserves.GetSelectedObject<Reserve>();
            if (rMessageBox.ShowQuestion("با انجام عمل حذف، رزرو این شخص در این لیست رزرو از بین خواهد رفت. آیا مطمئن هستید ؟") != DialogResult.Yes)
                return;
            reserve.Student.Reserves.Remove(reserve);
            reserve.ReserveList.Reserves.Remove(reserve);
            reserve.Delete();
            rGridViewReserves.RemoveSelectedRow();

            Program.SaveLog(string.Format("حذف [{0}]", reserve.ToString()));
        }
        private void rGridViewTransition_Edit(object sender, EventArgs e)
        {
            Register register = rGridViewTransition.GetSelectedObject<Register>();
            if (register.Transition == null)
            {
                rMessageBox.ShowError("امکان ویرایش انتقال این دانشجو وجود ندارد.");
                return;
            }
            frmTransitionDetail frm = new frmTransitionDetail(register.Transition, register.FinancialDocument);
            if (!frm.ProcessObject())
                return;

            register.Save();
            rGridViewTransition.UpdateGridView();

            Program.SaveLog(string.Format("ویرایش انتقال [{0}]", register.ToString()));
        }

        private void rGridViewTransition_Delete(object sender, EventArgs e)
        {
            if (rMessageBox.ShowQuestion("با حذف انتقال این دانشجو، باید دوباره او را کلاس بندی کنید. آیا موافق هستید؟") != DialogResult.Yes)
                return;

            Register register = rGridViewTransition.GetSelectedObject<Register>();
            Transition transition = register.Transition;

            register.Transition = null;
            register.Type = RegisterType.Participation;
            register.Participates.Clear();

            if (transition != null)
                transition.Delete();
            register.Save();
            rGridViewTransition.UpdateGridView();

            Program.SaveLog(string.Format("حذف انتقال [{0}]", register.ToString()));
        }
        private void rGridViewQuits_Edit(object sender, EventArgs e)
        {
            Register register = rGridViewQuits.GetSelectedObject<Register>();
            if (register.Quit == null)
            {
                rMessageBox.ShowError("امکان ویرایش انصراف این دانشجو وجود ندارد.");
                return;
            }
            frmQuitDetail frm = new frmQuitDetail(register.Quit, register.FinancialDocument);
            if (!frm.ProcessObject())
                return;

            register.Save();
            rGridViewQuits.UpdateGridView();

            Program.SaveLog(string.Format("ویرایش انصراف [{0}]", register.ToString()));
        }

        private void rGridViewQuits_Delete(object sender, EventArgs e)
        {
            if (rMessageBox.ShowQuestion("با حذف انصراف این دانشجو، باید دوباره او را کلاس بندی کنید. آیا موافق هستید؟") != DialogResult.Yes)
                return;

            Register register = rGridViewQuits.GetSelectedObject<Register>();
            Quit quit = register.Quit;

            register.Quit = null;
            register.Type = RegisterType.Participation;
            register.Participates.Clear();

            if (quit != null)
                quit.Delete();
            register.Save();
            rGridViewQuits.UpdateGridView();

            Program.SaveLog(string.Format("حذف انصراف [{0}]", register.ToString()));
        }

        private void rGridQuitedReserves_Edit(object sender, EventArgs e)
        {
            Reserve reserve = rGridQuitedReserves.GetSelectedObject<Reserve>();
            if (reserve.Quit == null)
            {
                rMessageBox.ShowError("امکان ویرایش انصراف این دانشجو وجود ندارد.");
                return;
            }
            frmQuitDetail frm = new frmQuitDetail(reserve.Quit, reserve.FinancialDocument);
            if (!frm.ProcessObject())
                return;

            reserve.Save();
            rGridQuitedReserves.UpdateGridView();
        }

        private void rGridQuitedReserves_Delete(object sender, EventArgs e)
        {
            if (rMessageBox.ShowQuestion("با حذف انصراف این دانشجو، مجددا در وضعیت رزرو قرار خواهد گرفت. آیا موافق هستید؟") != DialogResult.Yes)
                return;

            Reserve reserve = rGridQuitedReserves.GetSelectedObject<Reserve>();
            Quit quit = reserve.Quit;

            reserve.Quit = null;
            if (quit != null)
                quit.Delete();
            reserve.Save();
            rGridQuitedReserves.RemoveSelectedRow();

            Program.SaveLog(string.Format("حذف انصراف مرخصی [{0}]", reserve.ToString()));
        }

        private void rGridViewVacationRegisters_Delete(object sender, EventArgs e)
        {
            if (rMessageBox.ShowQuestion("با حذف، مرخصی دانشجو حذف خواهد شد. آیا مطمئن هستید ؟") != DialogResult.Yes)
                return;

            Register register = rGridViewVacationRegisters.GetSelectedObject<Register>();
            try
            {
                register.Student.Registers.Remove(register);
                register.Delete();
                rGridViewVacationRegisters.RemoveSelectedRow();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }

            Program.SaveLog(string.Format("حذف مرخصی [{0}]", register.ToString()));
        }

        private void rGridViewQuits_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            Register register = rGridViewQuits.GetSelectedObject<Register>();

            if(e.ButtonIndex == 0)
            {
                rptQuitReceipt rpt = new rptQuitReceipt();
                rpt.DataSource = new[] { register };
                frmReportViewer frm = new frmReportViewer(rpt) { AutoPrint = true };
                frm.ShowDialog(this);
            }
        }
        private void rGridViewTransition_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            Register register = rGridViewTransition.GetSelectedObject<Register>();

            if (e.ButtonIndex == 0)
            {

                rptTransitionReceipt rpt = new rptTransitionReceipt();
                rpt.DataSource = new[] { register };
                frmReportViewer frm = new frmReportViewer(rpt) { AutoPrint = true };
                frm.ShowDialog(this);
            }
        }
    }
}
