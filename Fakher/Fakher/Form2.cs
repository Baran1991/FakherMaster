using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;
using rTwain;

namespace Fakher
{
    public partial class Form2 : rRadForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rMessageBox.ShowInformation(DbContext.GetAppConfig("DataSource"));

            List<Person> persons = DbContext.GetAllEntities<Person>();
            progressBar1.Maximum = persons.Count;
            progressBar1.Value = 0;

            for (int i = 0; i < persons.Count; i++)
            {
                Person person = persons[i];
                person.FarsiFirstName = Services.NormalizeFarsiString(person.FarsiFirstName);
                person.FarsiLastName = Services.NormalizeFarsiString(person.FarsiLastName);
                person.FarsiFatherName = Services.NormalizeFarsiString(person.FarsiFatherName);

                person.EnglishFirstName = Services.NormalizeEnglishString(person.EnglishFirstName);
                person.EnglishLastName = Services.NormalizeEnglishString(person.EnglishLastName);
                person.EnglishFatherName = Services.NormalizeEnglishString(person.EnglishFatherName);

                if (person.Photo.Picture != null)
                    person.Photo.Picture = TwainImageConverter.ConvertType(new Bitmap(person.Photo.Picture),
                                                                           ImageFormat.Jpeg);

                person.Save();
                progressBar1.Increment(1);
                label1.Text = string.Format("{0} of {1}", i, persons.Count);
                Application.DoEvents();
            }
            rMessageBox.ShowError("Finished");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rMessageBox.ShowInformation(DbContext.GetAppConfig("DataSource"));
            var query = from register in DbContext.Entity<Register>()
                        where register.Code == null || register.Code == "0"
                        select register;
            foreach (Register register in query)
            {
//                register.Code = register.Student.GenerateCode(register.Period, register.Major, false);
                register.Save();
            }
            rMessageBox.ShowError("Finished");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rMessageBox.ShowInformation(DbContext.GetAppConfig("DataSource"));
            var query = from person in DbContext.Entity<Person>()
                        where person.Code == null || person.Code == "0"
                        select person;
            foreach (Person person in query)
            {
//                person.Code = Register.GetCode(register.Major);
//                register.Save();
            }
            rMessageBox.ShowError("Finished");
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            IList<Participate> participates = sectionItemSelector1.SectionItem.GetParticipates();
            int count = 0;
            foreach (Participate participate in participates)
            {
                bool changed = false;
                for (int i = participate.Marks.Count - 1; i >= 0; i--)
                {
                    Mark mark = participate.Marks[i];
                    if (mark.Lesson.Id != participate.SectionItem.Lesson.Id)
                    {
                        Participate lessonParticipate = participate.Register.GetFirstParticipate(mark.Lesson);
                        if (lessonParticipate != null)
                        {
                            participate.Marks.Remove(mark);
                            lessonParticipate.Marks.Add(mark);
                            mark.Participate = lessonParticipate;
                            changed = true;
                            count++;
                        }
                    }
                }
                if(changed)
                    participate.Register.Save();
            }
            rMessageBox.ShowError("پایان " + count);
        }
    }
}
