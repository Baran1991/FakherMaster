using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.UI.Persons;
using Fakher.UI.SystemFeatures;
using rComponents;
using rTwain;
using Telerik.WinControls.UI;

namespace Fakher.UI.Person
{
    public partial class frmReservePersonDetail : rRadDetailForm
    {
        public frmReservePersonDetail(Core.DomainModel.Person person)
        {
            InitializeComponent();

            SetProcessingObject(person);

           
            rTextBox1.Focus();

           

            ControlMappings.Add(new ControlMapping { Control = rTextBox1, ControlProperty = "Text", DataObject = person, ObjectProperty = "FarsiFirstName" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox3, ControlProperty = "Text", DataObject = person, ObjectProperty = "FarsiLastName" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox5, ControlProperty = "Text", DataObject = person, ObjectProperty = "FarsiFatherName" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox2, ControlProperty = "Text", DataObject = person, ObjectProperty = "EnglishFirstName" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox4, ControlProperty = "Text", DataObject = person, ObjectProperty = "EnglishLastName" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox6, ControlProperty = "Text", DataObject = person, ObjectProperty = "EnglishFatherName" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox7, ControlProperty = "Text", DataObject = person, ObjectProperty = "ContactInfo.Phone" });
            ControlMappings.Add(new ControlMapping { Control = rTextBox8, ControlProperty = "Text", DataObject = person, ObjectProperty = "ContactInfo.Mobile" });

            
        }





        private void frmPersonDetail_Load(object sender, EventArgs e)
        {
            
        }

       

       

        protected override void AfterValidate()
        {

        }

      
       
       
        private bool IsStudent()
        {
            return Tag is Student;
        }

        private bool IsEmployee()
        {
            return Tag is Employee;
        }

        private bool IsTeacher()
        {
            return Tag is Teacher;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string firstName = (e.Argument as string[])[0];
            string lastName = (e.Argument as string[])[1];
            string fatherName = (e.Argument as string[])[2];
            string birthDate = (e.Argument as string[])[3];

            IsPersonRepeated(firstName, lastName, fatherName, birthDate);
        }

        private bool IsPersonRepeated(string firstName, string lastName, string fatherName, string birthDate)
        {
            Core.DomainModel.Person currentPerson = GetProcessingObject<Core.DomainModel.Person>();
            Core.DomainModel.Person person;
            try
            {
                //                File.AppendAllText("D:\\log2.txt", string.Format("started {0} \r\n", firstName));
                //                person = Core.DomainModel.Person.FromName(firstName, lastName, fatherName);
                person = Core.DomainModel.Person.FromInfo(firstName, lastName, fatherName, birthDate);
                //                File.AppendAllText("D:\\log2.txt", "Finished \r\n");
            }
            catch (Exception e)
            {
                //                File.AppendAllText("D:\\log2.txt", "ex - {0} \r\n" + e);
                rMessageBox.ShowError(e.Message);
                return false;
            }

            if (person != null && person.Id != currentPerson.Id)
            {
                rMessageBox.ShowError(string.Format("این فرد قبلا با همین مشخصات با شماره پرونده [{0}] ثبت شده است.",
                                                    person.Code));
                return true;
            }
            return false;
        }

        private void rTextBox5_Leave(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            string firstName = rTextBox1.Text;
            string lastName = rTextBox3.Text;
            string fatherName = rTextBox5.Text;
            //            string birthdate = rDatePicker1.Date.ToShortDateString();

            while (backgroundWorkerTranslate.IsBusy)
            {
                backgroundWorkerTranslate.CancelAsync();
                Thread.Sleep(100);
            }

            if (string.IsNullOrEmpty(rTextBox6.Text))
                backgroundWorkerTranslate.RunWorkerAsync(new object[] { fatherName, rTextBox6 });

            //            while (backgroundWorkerTranslate.IsBusy)
            //            {
            //                backgroundWorkerTranslate.CancelAsync();
            //                Thread.Sleep(100);
            //            }

            //            while (backgroundWorker1.IsBusy)
            //            {
            //                backgroundWorker1.CancelAsync();
            //                Thread.Sleep(100);
            //            }
            //            backgroundWorker1.RunWorkerAsync(new string[] {firstName, lastName, fatherName, birthdate});
        }

        private void rTextBox1_Leave(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            string firstName = rTextBox1.Text;

            while (backgroundWorkerTranslate.IsBusy)
            {
                backgroundWorkerTranslate.CancelAsync();
                Thread.Sleep(100);
            }

            if (string.IsNullOrEmpty(rTextBox2.Text))
                backgroundWorkerTranslate.RunWorkerAsync(new object[] { firstName, rTextBox2 });
        }

        private void rTextBox3_Leave(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            string lastName = rTextBox3.Text;

            while (backgroundWorkerTranslate.IsBusy)
            {
                backgroundWorkerTranslate.CancelAsync();
                Thread.Sleep(100);
            }

            if (string.IsNullOrEmpty(rTextBox4.Text))
                backgroundWorkerTranslate.RunWorkerAsync(new object[] { lastName, rTextBox4 });
        }

        private void backgroundWorkerTranslate_DoWork(object sender, DoWorkEventArgs e)
        {
            string name = (e.Argument as object[])[0] as string;
            rTextBox resultTxt = (e.Argument as object[])[1] as rTextBox;
            string result;
            try
            {
                if (backgroundWorkerTranslate.CancellationPending)
                    return;
                //                File.AppendAllText("D:\\log.txt", string.Format("started {0} \r\n", name));
                result = Core.DomainModel.Person.FindEnglishName(name);
                //                File.AppendAllText("D:\\log.txt", "finished \r\n");

                if (backgroundWorkerTranslate.CancellationPending)
                    return;

            }
            catch (Exception ex)
            {
                //                File.AppendAllText("D:\\log.txt", "Canceled \r\n");
                e.Cancel = true;
                rMessageBox.ShowError(ex.Message);
                return;
            }
            e.Result = new object[] { resultTxt, result };
        }

        private void backgroundWorkerTranslate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (backgroundWorkerTranslate.CancellationPending)
                return;

            rTextBox resultTxt = (e.Result as object[])[0] as rTextBox;
            string name = (e.Result as object[])[1] as string;
            resultTxt.Text = name;
        }

      

      
       
    }
}
