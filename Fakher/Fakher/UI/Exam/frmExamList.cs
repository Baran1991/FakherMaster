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
using SortOrder = rComponents.SortOrder;
using NHibernate;
using DataAccessLayer;
using Fakher.UI.Financial;
using Fakher.Core.Report;
using Fakher.UI.Report;
using Fakher.Reports;

namespace Fakher.UI.Exam
{
    public partial class frmExamList : rRadForm
    {
        private ExamType mExamType;
        private IConfigurableReport mReport1;
        public frmExamList(ExamType type)
        {
            InitializeComponent();

            mExamType = type;

//            rGridComboBoxMajor.Columns.Add("کد", "کد", "Code");
            rGridComboBoxMajor.Columns.Add("نام", "نام", "Name");

            rGridComboBoxEvalItem.Columns.Add("نام آیتم", "نام آیتم", "Name");

            rGridView1.Mappings.Add(new ColumnMapping {Caption = "نام آزمون", ObjectProperty = "Name", SortOrder = SortOrder.Ascending});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "گروه", ObjectProperty = "FarsiExamSectionsText" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Code" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شهر", ObjectProperty = "Register.Student.ContactInfo.ProvinceAndCityText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "فرم آزمون", ObjectProperty = "ExamForm.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره فراخوان", ObjectProperty = "Formation.FarakhanNo" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره آزمون", ObjectProperty = "SeatNumber", SortOrder = SortOrder.Ascending});
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "کارت", ObjectProperty = "CardStatusText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView2.CustomButtons.Add(new rGridViewButton { Text = "جستجو", VisibleOnSelect = true, Position = rGridViewButtonPosition.After });
            rGridView2.CustomButtons.Add(new rGridViewButton { Text = "صدور کارت آزمون", VisibleOnSelect = true, Position = rGridViewButtonPosition.After});

            rGridView2.CustomButtonClick += rGridView2_CustomButtonClick;

            rGridComboBoxMajor.DataSource = Program.CurrentDepartment.Majors;
        }
        private void rGridView2_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            if (e.ButtonIndex == 0)
            {
                var frm = new frmStudentSearch();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {

                    var examList = rGridView1.GetVisibleObjects<Core.DomainModel.Exam>();
                    foreach (var exam in examList)
                    {
                        var participates = exam.GetParticipates();
                        var participate = participates.ToList().Where(m => m.Register.Student.FarsiFirstName == frm.fName & m.Register.Student.FarsiLastName == frm.LastName);
                        if (participate.Any())
                        {

                            rGridView1.Select(exam);
                            rGridView2.Select(participate.First());
                            break;
                        }
                    }
                }
            }
            else
            {if (rGridView2.GetCheckedObjects<ExamParticipate>().Count <1)
                {
                    rMessageBox.ShowError("لطفا حداقل یک شرکت کننده در آزمون را انتخاب کنید.");
                    return;
                }
                var exam= rGridView1.GetSelectedObject<Core.DomainModel.Exam>();
                
                frmReportParameters frmRptParams = new frmReportParameters();
                frmRptParams.RightToLeft = RightToLeft.Yes;
                mReport1 = new rptFaExamCard();
                mReport1.Configure(frmRptParams);
                mReport1.DataSet = rGridView2.GetCheckedObjects<ExamParticipate>();
               
                Program.StartWaiting();
                mReport1.Apply(frmRptParams);
                Program.EndWaiting();
                frmReportViewer viewer = new frmReportViewer(mReport1 as Telerik.Reporting.Report);
                viewer.ShowDialog(frmRptParams);
            }
           
        }
        private void rGridComboBoxMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Major major = rGridComboBoxMajor.GetValue<Major>();
            rGridComboBoxEvalItem.Clear();
            if (major == null)
                return;
            rGridComboBoxEvalItem.DataSource = major.GetExamEvaluationItems(Program.CurrentPeriod, mExamType);
        }

        private void rGridComboBoxEvalItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            EvaluationItem item = rGridComboBoxEvalItem.GetValue<EvaluationItem>();
            Major major = rGridComboBoxMajor.GetValue<Major>();
            rGridView1.Clear();
            rGridView2.Clear();
            if (item == null)
                return;
            rGridView1.DataBind(major.GetExams(Program.CurrentPeriod, item, mExamType));
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Major major = rGridComboBoxMajor.GetValue<Major>();
            Core.DomainModel.Exam exam = rGridView1.GetSelectedObject<Core.DomainModel.Exam>();
            exam.RefreshEntity();

            frmExamDetail frm = new frmExamDetail(exam);
            if (!frm.ProcessObject())
                return;
            exam.Save();
            if (frm.SaveExamHolding)
                exam.ExamHolding.Save();

            Program.SaveLog(string.Format("ویرایش آزمون ({0})", exam.Name));
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Major major = rGridComboBoxMajor.GetValue<Major>();
            Core.DomainModel.Exam exam = rGridView1.GetSelectedObject<Core.DomainModel.Exam>();
            List<ExamParticipate> checkedParticipates = rGridView2.GetCheckedObjects<ExamParticipate>();

            if (exam.GetParticipates().Any())
            {
                rMessageBox.ShowWarning("برای حذف کلی آزمون {0} ابتدا همه شرکت کنندگان آن را حذف کنید.", exam.Name);
                return;
            }

            if (rMessageBox.ShowQuestion("از حذف کل آزمون {0} مطمئن هستید؟", exam.Name) != DialogResult.Yes)
                return;

            if (rMessageBox.ShowQuestion("از حذف کل آزمون {0} به همراه همه شرکت کنندگان آن واقعا مطمئن هستید؟", exam.Name) != DialogResult.Yes)
                return;

            exam.Delete();
            Program.SaveLog(string.Format("حذف آزمون ({0})", exam.Name));
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = rGridView1.GetSelectedObject<Core.DomainModel.Exam>();
            if(exam == null)
                return;
            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                exam.RefreshEntity();
                rGridView2.DataBind(exam.GetParticipates());
            }
            finally
            {
                Cursor = Cursors.Default;
                Application.DoEvents();
            }
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            List<ExamParticipate> checkedParticipates = rGridView2.GetCheckedObjects<ExamParticipate>();
            Core.DomainModel.Exam exam = rGridView1.GetSelectedObject<Core.DomainModel.Exam>();
            if (checkedParticipates.Count == 0)
            {
                rMessageBox.ShowError("فرد یا افراد موردنظر را تیک بزنید.");
                return;
            }
            if(exam.Type == ExamType.PaperBasedExam)
            {
                if (rMessageBox.ShowQuestion("حذف افراد از آزمون های کتبی، باعث اختلال در انتساب شماره صندلی به افراد می شود. اینکار فقط در موارد خاص باید انجام شود. آیا مطمئن هستید؟") != DialogResult.Yes)
                    return;
            }
            if (rMessageBox.ShowQuestion("از حذف {0} نفر از آزمون اطمینان دارید؟", checkedParticipates.Count) !=
                DialogResult.Yes)
                return;

            string participateNames = "";
            foreach (ExamParticipate participate in checkedParticipates)
                participateNames += participate.Person.FarsiFullname + "|";

            ITransaction transaction = null;
            try
            {
                transaction = DbContext.BeginTransaction();

                foreach (ExamParticipate examParticipate in checkedParticipates)
                {
                    examParticipate.Delete();
                    rGridView2.Remove(examParticipate);
                }

                Program.SaveLog(string.Format("حذف {0} شرکت کننده ({1}) از آزمون ({2})",
                                              checkedParticipates.Count, participateNames, exam.Name));

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                rMessageBox.ShowError(ex.Message);
            }
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            ExamParticipate examParticipate = rGridView2.GetSelectedObject<ExamParticipate>();
            if (examParticipate.Status != ExamParticipateStatus.HasResult)
                if (rMessageBox.ShowQuestion("برای این دانشجو هنوز نمره ای وارد نشده است. از ویرایش آن اطمینان دارید؟") !=
                    DialogResult.Yes)
                    return;
            
            examParticipate.RefreshEntity();
            frmExamParticipateDetail frm = new frmExamParticipateDetail(examParticipate);
            if (!frm.ProcessObject())
                return;
            examParticipate.Save();

            Program.SaveLog(string.Format("ویرایش ({0}) از آزمون ({1})", examParticipate.Person.FarsiFullname, examParticipate.ExamForm.Exam.Name));
            rGridView2.UpdateGridView();
        }
    }
}
