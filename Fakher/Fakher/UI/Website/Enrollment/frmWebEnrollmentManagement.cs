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
using Fakher.Core.Website;
using NHibernate;
using rComponents;

namespace Fakher.UI.Website.Enrollment
{
    public partial class frmWebEnrollmentManagement : rRadForm
    {
        public frmWebEnrollmentManagement()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت آموزشی", ObjectProperty = "ParticipatesText" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت آموزشی", ObjectProperty = "ParticipatesText" });

            IList<EnrollmentLicense> enrollmentLicenses = EnrollmentLicense.GetEnrollmentLicenses(Program.CurrentPeriod);
            rComboBox1.DisplayMember = "EnrollText";
            rComboBox1.DataSource = enrollmentLicenses;
        }

        private void rComboBox1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (rComboBox1.SelectedIndex == -1)
                return;
            Fill();
        }

        private void Fill()
        {
            EnrollmentLicense enrollmentLicense = rComboBox1.SelectedValue as EnrollmentLicense;
            IList<Register> registers = Register.GetRegisters(enrollmentLicense.EducationalPeriod, enrollmentLicense.Major);

            List<Register> confirmedRegisters = registers.Where(x => x.EnrollmentConfirmed).ToList();
            List<Register> unConfirmedRegisters = registers.Where(x => !x.EnrollmentConfirmed).ToList();

            rGridView1.DataBind(confirmedRegisters);
            rGridView2.DataBind(unConfirmedRegisters);

//            rComboBox1.SelectNextControl(rGridView1, true, true, false, false);
            //if (rGridView1.RadGridView.Rows.Count > 1)
            //    rGridView1.RadGridView.Rows[1].IsSelected = true;

            //if (rGridView2.RadGridView.Rows.Count > 1)
            //    rGridView2.RadGridView.Rows[1].IsSelected = true;
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            EnrollmentLicense enrollmentLicense = rComboBox1.SelectedValue as EnrollmentLicense;
            List<Register> registers = rGridView2.GetCheckedObjects<Register>();

            if (registers.Count == 0)
            {
                rMessageBox.ShowWarning("افراد موردنظر را تیک بزنید");
                return;
            }

            if (rMessageBox.ShowQuestion("از حذف {0} نفر از ترم {1} اطمینان دارید؟", registers.Count, enrollmentLicense.EducationalPeriod.Name) != DialogResult.Yes)
                return;

            if (rMessageBox.ShowQuestion("از حذف {0} نفر از ترم {1} واقعا مطمئن هستید؟", registers.Count, enrollmentLicense.EducationalPeriod.Name) != DialogResult.Yes)
                return;


            string participateNames = "";
            foreach (Register register in registers)
                participateNames += register.Student.FarsiFullname + "|";


            ITransaction transaction = null;
            try
            {
                transaction = DbContext.BeginTransaction();

                foreach (Register register in registers)
                {
                    register.Participates.Clear();
                    register.UpdateParticipateEnrollments();
                    register.Save();

//                    for (int i = register.Participates.Count - 1; i >= 0; i--)
//                    {
//                        Participate participate = register.Participates[i];
//                        register.Participates.Remove(participate);
//                        foreach (ExamParticipate examParticipate in participate.GetExamParticipates())
//                        {
//                            register.ExamParticipates.Remove(examParticipate);
//                            examParticipate.Delete();
//                        }
//                        participate.Delete();
//                    }
//
//                    for (int j = register.Student.Reserves.Count - 1; j >= 0; j--)
//                    {
//                        Reserve reserve = register.Student.Reserves[j];
//                        register.Student.Reserves.Remove(reserve);
//                        reserve.Delete();
//                    }
//
//                    for (int k = register.Enrollments.Count - 1; k >= 0; k--)
//                    {
//                        Core.DomainModel.Enrollment enrollment = register.Enrollments[k];
//                        register.Enrollments.Remove(enrollment);
//                        enrollment.Delete();
//                    }
//
//                    register.Student.Registers.Remove(register);
//                    register.Delete();
//                    rGridView2.Remove(register);
                }

                Program.SaveLog(string.Format("حذف {0} نفر تاییدنهایی نشده)", registers.Count));

                transaction.Commit();

                rGridView2.UpdateGridView();
                rGridView2.UnCheckAll();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                rMessageBox.ShowError(ex.Message);
            }
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            EnrollmentLicense enrollmentLicense = rComboBox1.SelectedValue as EnrollmentLicense;
            List<Register> registers = rGridView2.GetCheckedObjects<Register>();

            if (registers.Count == 0)
            {
                rMessageBox.ShowWarning("افراد موردنظر را تیک بزنید");
                return;
            }

            ITransaction transaction = null;
            try
            {
                transaction = DbContext.BeginTransaction();
                foreach (Register register in registers)
                {
                    register.ConfirmEnrollment();
                    register.UpdateParticipateEnrollments();
                    register.Save();
                }

                Program.SaveLog(string.Format("تایید نهایی {0} نفر", registers.Count));

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                rMessageBox.ShowError(ex.Message);
            }

            Fill();
        }

        private void frmWebEnrollmentManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            rComboBox1.DataSource = null;
            rGridView1.Clear();
            rGridView2.Clear();
        }
    }
}
