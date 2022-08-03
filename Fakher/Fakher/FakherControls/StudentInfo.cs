using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.Controls
{
    public partial class StudentInfo : UserControl
    {
        public Student Student { get; set; }
        public List<string> InfoFields { get; private set; }

        public StudentInfo()
        {
            InitializeComponent();
            InfoFields = new List<string>();
        }

        private void StudentInfo_Load(object sender, EventArgs e)
        {
            InfoFields.Clear();
            UpdateStudentPanel();
        }

        public void UpdateStudentPanel()
        {
            if(Student == null)
                return;
            Reserve lastReserve = Student.GetLastReserve();
            Register lastRegister = Student.GetRegisters(Program.CurrentPeriod).LastOrDefault();
            if (lastRegister == null)
                lastRegister = Student.GetLastRegister();

//            try
//            {
//                // try to fix pictures, can be removed after a while
//                Student.Photo.CorrectPhoto(DbContext.CurrentSession.Connection);
//            }
//            catch (Exception)
//            {
//            }

            UpdateStudentPanel(lastRegister, lastReserve);
        }

        public void UpdateStudentPanel(Register register, Reserve reserve)
        {
            InfoFields.Clear();
            if (Student == null)
            {
                if (register != null)
                    Student = register.Student;
                else if (reserve != null)
                    Student = reserve.Student;
                else
                    return;
            }

            try
            {
                pictureBoxStudent.Image = Student.Photo.Picture;
                if (register != null)
                    InfoFields.Add(register.Code);
                else if (reserve != null)
                    InfoFields.Add(reserve.Code);
                else if (register == null && reserve == null)
                    InfoFields.Add(Student.Code);

                InfoFields.Add(Student.FarsiFullname);
                if (register != null)
                    InfoFields.Add(register.FarsiFinancialStatusVerboseText);
                else if (reserve != null)
                    InfoFields.Add(reserve.FarsiFinancialStatusVerboseText);
                else if (register == null && reserve == null)
                    InfoFields.Add(Student.FinancialStatusVerboseText);

                InfoFields.Add("سابقه آموزشی: " + Student.GetRegisteredPeriods().Count() + " ترم ");

                if (Student.EntranceMark != 0)
                    InfoFields.Add("نمره ورودی: " + register.Student.EntranceMark + "");

                if (register != null)
                    InfoFields.Add("آخرین فعالیت: " + register.StatusText);
                else if (reserve != null)
                    InfoFields.Add("آخرین فعالیت: " + reserve.StatusText);

                InfoFields.Add("کل درخواست ها: " + Student.Requests.Count + "");
                int requestCount = Student.GetRequests(false).Count();
                InfoFields.Add("درخواست های دردست اقدام: " + (requestCount == 0 ? "ندارد" : requestCount + ""));
                InfoFields.Add("مدرک ناقص: " + (Student.IsIncomplete ? "دارد" : "ندارد"));

                //if(Student.Notes.Any())
                //    InfoFields.Add("توضیحات: " + Student.Notes);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }

            Fill();
        }

        private void Fill()
        {
            int columnSize = 4;
            int columns = (int)Math.Ceiling((decimal)InfoFields.Count / columnSize) + 1;
            int rows = 4;

            tableLayoutPanel1.ColumnCount = columns;
            tableLayoutPanel1.ColumnStyles.Clear();
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100/columns));

            tableLayoutPanel1.RowCount = rows;
            tableLayoutPanel1.RowStyles.Clear();
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute,
                                                             tableLayoutPanel1.Height/tableLayoutPanel1.RowCount));

            tableLayoutPanel1.Controls.Clear();
            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    int index = (col * columnSize) + row;
                    if (index >= InfoFields.Count)
                        return;

                    string field = InfoFields.ElementAt(index);
                    Label label = new Label() { Text = field};
                    label.AutoSize = true;
                    label.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    tableLayoutPanel1.Controls.Add(label, col, row);
                }
            }
        }
    }
}
