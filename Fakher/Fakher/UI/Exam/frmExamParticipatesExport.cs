using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Exam
{
    public partial class frmExamParticipatesExport : rRadForm
    {
        public frmExamParticipatesExport()
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت نام", ObjectProperty = "RegisterParticipationText" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "آزمون های ثبت نامی", ObjectProperty = "GeneralExamsText" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شناسه وب سایت", ObjectProperty = "Student.UserInfo.WebLoginText" });

            rGridCmbTrainingPlan.Columns.Add("نام", "نام", "Name");
            rGridCmbExamItem.Columns.Add("نام", "نام", "Name");
        }

        private ColumnMapping[] GetGridMappings()
        {
            List<ColumnMapping> mappings = new List<ColumnMapping>();

            mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
            mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });
            mappings.Add(new ColumnMapping { Caption = "نوع ثبت نام", ObjectProperty = "RegisterParticipationText" });
//            mappings.Add(new ColumnMapping { Caption = "آزمون های ثبت نامی", ObjectProperty = "GeneralExamsText" });

            if (radPageView1.SelectedPage.TabIndex == 0)
            {
                if (rChkEducationalStatus.Checked)
                    mappings.Add(new ColumnMapping
                                                {
                                                    Caption = "آخرین وضعیت آموزشی",
                                                    ObjectProperty = "Student.GetCurrentEducationalStatus()"
                                                });
                if (rChkFinancialStatus.Checked)
                    mappings.Add(new ColumnMapping
                                                {
                                                    Caption = "وضعیت مالی",
                                                    ObjectProperty = "Student.GetCurrentFinancialStatus()"
                                                });
                if (rChkWebLogin.Checked)
                    mappings.Add(new ColumnMapping
                                                {
                                                    Caption = "شناسه وب سایت",
                                                    ObjectProperty = "Student.UserInfo.WebLoginText"
                                                });
            }
            if (radPageView1.SelectedPage.TabIndex == 1)
            {
                if (rChkEducationalStatus2.Checked)
                    mappings.Add(new ColumnMapping
                                                {
                                                    Caption = "آخرین وضعیت آموزشی",
                                                    ObjectProperty = "Student.GetCurrentEducationalStatus()"
                                                });
                if (rChkFinancialStatus2.Checked)
                    mappings.Add(new ColumnMapping
                                                {
                                                    Caption = "وضعیت مالی",
                                                    ObjectProperty = "Student.GetCurrentFinancialStatus()"
                                                });
                if (rChkWebLogin2.Checked)
                    mappings.Add(new ColumnMapping
                                                {
                                                    Caption = "شناسه وب سایت",
                                                    ObjectProperty = "Student.UserInfo.WebLoginText"
                                                });
            }
            return mappings.ToArray();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            IEnumerable<Register> registers = new List<Register>();

            if (sectionItemSelector1.SectionItem != null)
            {
                IList<Participate> participates = sectionItemSelector1.SectionItem.GetParticipates();
                registers = participates.GroupBy(x => x.Register).Select(x => x.Key);
            }
            else if (lessonSelector1.Lesson != null)
            {
                IList<Participate> participates = Participate.GetParticipates(Program.CurrentPeriod, lessonSelector1.Lesson);
                registers = participates.GroupBy(x => x.Register).Select(x => x.Key);
            }
            else if (majorSelector1.Major != null)
            {
                registers = Register.GetRegisters(Program.CurrentPeriod, majorSelector1.Major);
            }

            if (rChkSubSet1.IsChecked)
            {
                frmSelect frm = new frmSelect(registers, GetGridMappings()) { MultiSelect = true };

                if (frm.ShowDialog(this) == DialogResult.OK)
                    registers = frm.GetSelectedObjects<Register>();
                else
                    return;
            }

            foreach (Register register in registers)
                if (!rGridView1.DataSource.Contains(register))
                    rGridView1.Insert(register);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            List<Register> registers = rGridView1.GetCheckedObjects<Register>();
            foreach (Register register in registers)
            {
                rGridView1.Remove(register);
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            ExamTrainingItem examTrainingItem = rGridCmbExamItem.GetValue<ExamTrainingItem>();
            if (examTrainingItem == null)
            {
                rMessageBox.ShowError("آزمون را انتخاب کنید.");
                return;
            }

//            IEnumerable<Register> registers = examTrainingItem.GetEnrollments().Select(x => x.Register).ToList();
            IList<Register> registers = examTrainingItem.GetEnrolledRegisters().ToList();

            if (rChkSubSet2.IsChecked)
            {
                frmSelect frm = new frmSelect(registers, GetGridMappings()) { MultiSelect = true };

                if (frm.ShowDialog(this) == DialogResult.OK)
                    registers = frm.GetSelectedObjects<Register>();
                else
                    return;
            }

            foreach (Register register in registers)
                if (!rGridView1.DataSource.Contains(register))
                    rGridView1.Insert(register);
        }

        private void majorSelector2_SelectedChanged(object sender, EventArgs e)
        {
            rGridCmbTrainingPlan.Clear();
            if (majorSelector2.Major == null)
                return;
            IList<TrainingPlan> plans = TrainingPlan.GetPlans(Program.CurrentPeriod, majorSelector2.Major);
            rGridCmbTrainingPlan.DataSource = plans;
        }

        private void rGridCmbTrainingPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridCmbExamItem.Clear();
            TrainingPlan plan = rGridCmbTrainingPlan.GetValue<TrainingPlan>();
            if (plan == null)
                return;

            rGridCmbExamItem.DataSource = plan.GetExamItems();
        }

        private void radBtnGenerateExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "XLS File (*.xls)|*.xls";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            Workbook book = new Workbook();
            Worksheet sheet = book.Worksheets[0];
            for (int i = 0; i < rGridView1.DataSource.Count; i++)
            {
                Register register = rGridView1.DataSource[i] as Register;

                if (string.IsNullOrEmpty(register.Student.IdNumber) || register.Student.IdNumber == "0" || register.Student.IdNumber == "-")
                {
                    if (rMessageBox.ShowQuestion("برای [{0}] شماره شناسنامه وارد نشده است. آیا مایل به ادامه هستید؟", register.Student.FarsiFullname) != DialogResult.Yes)
                        return;
                }

                sheet.Cells[i, 0].Value = register.Student.FarsiFirstName;
                sheet.Cells[i, 1].Value = register.Student.FarsiLastName;
                sheet.Cells[i, 2].Value = register.Code;
                sheet.Cells[i, 3].Value = register.Student.IdNumber;
            }

            book.Save(dialog.FileName);
            rMessageBox.ShowInformation("فایل با موفقیت ساخته شد.");
        }

        private void radBtnInsertIntoAccess_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MDB File (*.mdb)|*.mdb";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

//            if (rMessageBox.ShowQuestion("آیا این فایل کاملا خالی است؟") != DialogResult.Yes)
//                return;

            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + dialog.FileName); ;
            try
            {
                conn.Open();
                OleDbCommand command = conn.CreateCommand();

                command.CommandText = "Select Count(*) from list";
                int count = Convert.ToInt32(command.ExecuteScalar());
                if(count > 0)
                {
                    if (rMessageBox.ShowQuestion("این فایل خالی نیست. آیا می خواهید همه اطلاعات آن حذف شود و فایل خالی شود؟") == DialogResult.Yes)
                    {
                        if (rMessageBox.ShowQuestion("از حذف همه اطلاعات درون این فایل مطمئن هستید؟") !=
                            DialogResult.Yes)
                            return;

                        command.CommandText = "Delete from list";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        if (rMessageBox.ShowQuestion("رکوردهای جدید به انتهای لیست موجود اضافه خواهند شد. آیا مطمئن هستید؟") != DialogResult.Yes)
                            return;
                    }
                }

                for (int i = 0; i < rGridView1.DataSource.Count; i++)
                {
                    try
                    {
                        Register register = rGridView1.DataSource[i] as Register;

                        string[] num = Services.NormalizeMobileString(register.Student.ContactInfo.Mobile);
                        object cellPhone = num.Length > 0 ? num[0] : (object)DBNull.Value;
                        object provinceText = !string.IsNullOrEmpty(register.Student.ContactInfo.ProvinceAndCityText)
                                                  ? register.Student.ContactInfo.ProvinceAndCityText
                                                  : (object)DBNull.Value;
                        object idNumber = !string.IsNullOrEmpty(register.Student.IdNumber)
                                              ? register.Student.IdNumber
                                              : (object) DBNull.Value;

                        command.CommandText =
                            string.Format("INSERT INTO list VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)");

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("P1", register.Code);
                        command.Parameters.AddWithValue("P2", register.Student.FarsiFirstName);
                        command.Parameters.AddWithValue("P3", register.Student.FarsiLastName);
                        command.Parameters.AddWithValue("P4", register.Student.FarsiFatherName);
                        command.Parameters.AddWithValue("P5", register.Major.Name);
                        command.Parameters.AddWithValue("P6", 0);
                        command.Parameters.AddWithValue("P7", idNumber);
                        command.Parameters.AddWithValue("P8", cellPhone);
                        command.Parameters.AddWithValue("P9", provinceText);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError("خطا در درج رکورد " + ex.Message);
                return;
            }
            finally
            {
                conn.Close();
            }

            rMessageBox.ShowInformation("رکوردها به فایل Access افزوده شد.");
        }

        private void rChkSubSet1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rChkEducationalStatus.Enabled = rChkFinancialStatus.Enabled = rChkWebLogin.Enabled = rChkSubSet1.Checked;
        }

        private void rChkSubSet2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rChkEducationalStatus2.Enabled = rChkFinancialStatus2.Enabled = rChkWebLogin2.Enabled = rChkSubSet2.Checked;
        }
    }
}
