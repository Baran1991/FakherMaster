using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Buffet;
using Fakher.Core.Sentinel;
using Fakher.Core.Website;
using NHibernate;
using rComponents;
using MenuItem = Fakher.Core.Website.MenuItem;

namespace Fakher.UI.SystemFeatures
{
    public partial class frmUpgrade : rRadForm
    {
        public frmUpgrade()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if(rTextBox1.Text != "new1")
                return;

            ISession session = DbContext.SessionFactory.OpenSession();
            IDbCommand dbCommand = session.Connection.CreateCommand();
            dbCommand.CommandText = "SELECT *   FROM [FakherMIS].[dbo].[EducationalTools] where IsDeleted = 0";
            IDataReader reader = dbCommand.ExecuteReader();
            while(reader.Read())
            {
                int id = (int) reader["Id"];
                EducationalTool tool = EducationalTool.FromId(id);

                EducationalToolSupply supply = new EducationalToolSupply();

                supply.Count = (int) reader["Count"];
                supply.Remainder = (int) reader["Remainder"];
                supply.BuyPrice = (long)reader["BuyPrice"];
                supply.SellPrice = (long)reader["SellPrice"];

                supply.EducationalTool = tool;
                tool.Supplies.Add(supply);
                tool.Save();
            }

            session.Close();
            rMessageBox.ShowInformation("FINISHED!");
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
            if (progressBar1.Value >= progressBar1.Maximum - 1)
                return;
            progressBar1.Increment(1);
            rLabel2.Text = progressBar1.Value + " از " + progressBar1.Maximum;
            Application.DoEvents();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (rTextBox1.Text != "new2")
                return;

            rMessageBox.ShowInformation("Starting");
            DbContext.RunSQL("Update Employee SET DailyDocument_id = Document_id;");
            rMessageBox.ShowInformation("1");
            DbContext.RunSQL("Update [LessonHoldings] SET EducationalPeriod_id = Period_id;");
            rMessageBox.ShowInformation("2");
            DbContext.RunSQL("Update [TrainingItems] SET TrainingPlan_id = Plan_id;");
            rMessageBox.ShowInformation("3");
            DbContext.RunSQL("Update [ExamTrainingItem] SET [Type] = 0 , IsGeneral = 0;");
            rMessageBox.ShowInformation("4");
            DbContext.RunSQL("Update [TrainingPlan] SET IsGeneral = 0;");
            rMessageBox.ShowInformation("5");

            List<Participate> participates = DbContext.GetAllEntities<Participate>();
            SetProgressBar(participates.Count);
            foreach (Participate participate in participates)
            {
                if(participate.Register != null)
                {
                    Enrollment enrollment = participate.Register.Enroll(participate.SectionItem.Item);
                    enrollment.Date = participate.Date;
                    participate.Enrollment = enrollment;
                    participate.Register.AddEnrollment(enrollment);
                    participate.Register.Save();
                }
                ProgressBarIncrement();
            }
            rMessageBox.ShowInformation("FINISHED!");
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            if (rTextBox1.Text != "new3")
                return;
            rMessageBox.ShowInformation("Start Send Email");

            IList<Student> students = Student.GetWebsiteStudents();
            SetProgressBar(students.Count);

            foreach (Student student in students)
            {
                InternetPostMaster.Send(InternetPostMaster.NoReply, new[] { new MailAddress(student.UserInfo.GetRawEmail()) }, "ارسال مجدد شناسه کاربری", student.UserInfo.GetLoginHtmlText(), true, true);
                ProgressBarIncrement();
            }

            rMessageBox.ShowInformation("FINISHED!");
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            if (rTextBox1.Text != "new4")
                return;

            rMessageBox.ShowInformation("Start Enc UserInfo");

            List<UserInfo> infos = DbContext.GetAllEntities<UserInfo>();
            SetProgressBar(infos.Count);

            foreach (UserInfo info in infos)
            {
                ProgressBarIncrement();
                if (info.Id == 1)
                    continue;
                if (info.LoginStatus == LoginStatus.Enabled)
                    continue;

                string username = info.Username;
                string password = info.Password;

                info.SetUsername(username);
                info.SetPassword(password);
                info.SetEmail(username);
                info.ActivateWeb();
                info.Save();
            }

            rMessageBox.ShowInformation("Staff Start");

            List<Staff> staffs = DbContext.GetAllEntities<Staff>();
            SetProgressBar(staffs.Count);
            foreach (Staff staff in staffs)
            {
                staff.UserInfo.WebLogin = false;
                staff.UserInfo.ActivateApp();
                staff.UserInfo.Save();
                ProgressBarIncrement();
            }

            rMessageBox.ShowInformation("FINISHED!");
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            if (rTextBox1.Text != "new5")
                return;

//            EducationalPeriod educationalPeriod = DbContext.FromId<EducationalPeriod>(3);
//            IList<Register> registers = Register.GetRegisters(educationalPeriod);
            IList<Register> registers = DbContext.GetAllEntities<Register>();
//            List<Core.DomainModel.Exam> exams = Core.DomainModel.Exam.GetExams(educationalPeriod);

            rMessageBox.ShowInformation("Start");
            SetProgressBar(registers.Count);
            foreach (Register register in registers)
            {
//                register.Enrollments.Clear();
//                foreach (Participate participate in register.Participates)
//                    participate.Enrollment = null;
//                register.UpdateParticipateEnrollments();
//                register.SyncParticipation();
                register.Save();
                ProgressBarIncrement();
            }
            rMessageBox.ShowInformation("FINISHED!");
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            try
            {
                ExamHolding examHolding = DbContext.FromId<ExamHolding>(2);

                foreach (Core.DomainModel.Exam exam in examHolding.Exams)
                    exam.ExamHolding = null;

                foreach (Formation formation in examHolding.Formations)
                {
//                    formation.Exam = null;
                    formation.ExamHolding = null;
                }

                examHolding.Exams.Clear();
                examHolding.Formations.Clear();
                examHolding.Delete();

                Core.DomainModel.Exam exam1 = DbContext.FromId<Core.DomainModel.Exam>(109);
                exam1.Delete();

                ExamHolding examHolding1 = DbContext.FromId<ExamHolding>(67);
                examHolding1.Delete();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
//            if(exam.HasHolding)
//            {
//                exam.ExamHolding.Exams.Remove(exam);
//                exam.ExamHolding = null;
//            }
//            exam.Delete();
        }

        private void radButton7_Click(object sender, EventArgs e)
        {
            if (rTextBox1.Text != "new7")
                return;

            List<Register> registers = DbContext.GetAllEntities<Register>();
            List<Employee> employees = DbContext.GetAllEntities<Employee>();

            SetProgressBar(registers.Count);
//            foreach (Register register in registers)
//            {
//                if(string.IsNullOrEmpty(register.Registrar))
//                    continue;
//                if(register.FinancialDocument != null)
//                {
//                    Employee employee = null;
//                    foreach (Employee employee1 in employees)
//                    {
//                        if(employee1.FarsiFormalName == register.Registrar)
//                        {
//                            employee = employee1;
//                            break;
//                        }
//                    }
//
//                    if(employee == null)
//                        continue;
//
//                    register.RegistrarPerson = employee;
//                    foreach (FinancialItem financialItem in register.FinancialDocument.Items)
//                    {
//                        financialItem.RegisterDate = register.RegisterDate;
//                        financialItem.Registrar = employee;
//                    }
//                    register.Save();
//                }
//                ProgressBarIncrement();
//            }
        }

        private void radButton8_Click(object sender, EventArgs e)
        {
            if (rTextBox1.Text != "new8")
                return;

            rMessageBox.ShowInformation("1");
            DbContext.RunSQL("Update [Uses] SET [BatchNumber] = 0;");
        }

        private void radButton9_Click(object sender, EventArgs e)
        {
            if (rTextBox1.Text != "new9")
                return;

            string connectionString = DbContext.GetConnectionString();
            IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            IDbCommand command = dbConnection.CreateCommand();
            command.CommandText = "Select * from [PersonPhotos]";

            Dictionary<int, byte[]> pics = new Dictionary<int, byte[]>();

            IDataReader reader = command.ExecuteReader();
            SetProgressBar(3000);
            while(reader.Read())
            {
                ProgressBarIncrement();

                int id = (int)reader[0];
                byte[] picture = reader["Picture"] as byte[];
                pics.Add(id, picture);
            }
            reader.Close();


            SetProgressBar(3000);
            foreach (KeyValuePair<int, byte[]> pair in pics)
            {
                ProgressBarIncrement();
                if (pair.Value == null)
                    continue;
                Bitmap Picture;
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream stream = new MemoryStream(pair.Value);
                try
                {
                    object o = bf.Deserialize(stream);
                    Picture = (Bitmap)o;
                }
                catch (Exception ex)
                {
                    Picture = null;
                }
                finally
                {
                    stream.Close();
                    stream.Dispose();
                }

                if (Picture == null)
                    continue;

                byte[] bytes = Services.ConvertToByteArray(Picture);

                IDbCommand command2 = dbConnection.CreateCommand();
                command2.CommandText = "UPDATE [PersonPhotos] SET PictureBytes = @Param1 where Id = @Param2";

                IDbDataParameter param1 = command2.CreateParameter();
                param1.ParameterName = "Param1";
                param1.Value = bytes;

                IDbDataParameter param2 = command2.CreateParameter();
                param2.ParameterName = "Param2";
                param2.Value = pair.Key;

                command2.Parameters.Add(param1);
                command2.Parameters.Add(param2);
                command2.ExecuteNonQuery();

                Picture.Dispose();
            }

            dbConnection.Close();
            rMessageBox.ShowInformation("FINISHED!");
        }

        private void radButton10_Click(object sender, EventArgs e)
        {
            if (rTextBox1.Text != "new10")
                return;

            rMessageBox.ShowInformation("Start 1");

            IList<MenuItem> oldTopMenuItems = Fakher.Core.Website.MenuItem.GetOldTopMenuItems();
            SetProgressBar(oldTopMenuItems.Count);
            foreach (MenuItem menuItem in oldTopMenuItems)
            {
                menuItem.Place = MenuItemPlace.MainTopMenu;
                menuItem.Save();
                ProgressBarIncrement();
            }

            rMessageBox.ShowInformation("Start 2");

            IList<WebsiteSection> sections = WebsiteSection.GetWebsiteSections();
            SetProgressBar(sections.Count);
            foreach (WebsiteSection section in sections)
            {
                IList<MenuItem> sectionMenuItems = Fakher.Core.Website.MenuItem.GetOldTopMenuItems(section);
                foreach (MenuItem menuItem in sectionMenuItems)
                {
                    menuItem.Place = MenuItemPlace.SectionRightMenu;
                    menuItem.Save();
                }
                ProgressBarIncrement();
            }

            rMessageBox.ShowInformation("FINISHED!");
        }

        private void radButton11_Click(object sender, EventArgs e)
        {
            if (rTextBox1.Text != "new11")
                return;

            var query1 = from reg in DbContext.Entity<Register>()
                         orderby reg.Code
                         select reg;

            var query2 = from reserve in DbContext.Entity<Reserve>()
                         orderby reserve.Code
                         select reserve;

            var query3 = from examParticipate in DbContext.Entity<ExamParticipate>()
                         select examParticipate;

            rMessageBox.ShowInformation("Start Registers");
            SetProgressBar(query1.Count());

            SqlConnection connection = new SqlConnection(DbContext.GetConnectionString());
            connection.Open();
            IDbCommand command = connection.CreateCommand();

            foreach (Register register in query1.ToList())
            {
                ProgressBarIncrement();
                if (register.Major == null)
                    continue;
                if (string.IsNullOrEmpty(register.Code))
                    continue;
                if(register.EducationalCode != null)
                    continue;
                EducationalCode educationalCode = EducationalCode.FromCode(register.Code);
                if (educationalCode == null)
                {
                    educationalCode = new EducationalCode {Code = register.Code, Major = register.Major};
                    educationalCode.Save();
                }

                command.CommandText = "UPDATE Registers SET [EducationalCode_id] = " + educationalCode.Id +
                                      " WHERE Id = " + register.Id;
                command.ExecuteNonQuery();
            }

            rMessageBox.ShowInformation("Start Reserves");
            SetProgressBar(query2.Count());
            foreach (Reserve reserve in query2.ToList())
            {
                ProgressBarIncrement();
                if (reserve.EducationalCode != null)
                    continue;
                if (string.IsNullOrEmpty(reserve.Code))
                    continue;
                if (reserve.ReserveList == null)
                    continue;
                if (reserve.ReserveList.Major == null)
                    continue;

                EducationalCode educationalCode = EducationalCode.FromCode(reserve.Code);
                if (educationalCode == null)
                {
                    educationalCode = new EducationalCode { Code = reserve.Code, Major = reserve.ReserveList.Major };
                    educationalCode.Save();
                }

                command.CommandText = "UPDATE [Reserves] SET [EducationalCode_id] = " + educationalCode.Id +
                      " WHERE Id = " + reserve.Id;
                command.ExecuteNonQuery();
            }

            rMessageBox.ShowInformation("Start ExamParticipates");
            SetProgressBar(query3.Count());
            foreach (ExamParticipate participate in query3.ToList())
            {
                ProgressBarIncrement();
                if(participate.Person != null)
                    continue;
                if (participate.Register == null)
                    continue;
                if (participate.Register.Student == null)
                    continue;

                command.CommandText = "UPDATE [ExamParticipates] SET [Person_id] = " + participate.Register.Student.Id +
                                      " WHERE Id = " + participate.Id;
                command.ExecuteNonQuery();
            }

            rMessageBox.ShowInformation("Finished!!!");
        }

        private void radButton12_Click(object sender, EventArgs e)
        {
            if (rTextBox1.Text != "new12")
                return;

            IList<Student> students = Student.GetWebsiteStudents();
            SetProgressBar(students.Count);
            foreach (Student student in students)
            {
                if(String.IsNullOrEmpty(student.UserInfo.GetRawEmail()))
                {
                    string email = student.UserInfo.GetRawUsername();
                    student.UserInfo.SetEmail(email);
                    student.UserInfo.Save();
                }
                ProgressBarIncrement();
            }

            rMessageBox.ShowInformation("Finished!!!");
        }

        private void radButton13_Click(object sender, EventArgs e)
        {
            if (rTextBox1.Text != "test")
                return;

            frmTest frm = new frmTest();
            frm.ShowDialog();
        }

        private void radButton14_Click(object sender, EventArgs e)
        {
            if (rTextBox1.Text != "test2")
                return;

            frmTeacherHistoryList frm = new frmTeacherHistoryList();
            frm.ShowDialog();
        }
    }
}
