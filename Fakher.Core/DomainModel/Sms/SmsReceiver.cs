using System;
using System.Collections.Generic;
using System.IO;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;
using System.Linq;

namespace Fakher.Core
{
    public class SmsReceiver
    {
        public EducationalPeriod Period { get; set; }
        public Department Department { get; set; }

        public Major Major { get; set; }
        public Lesson Lesson { get; set; }
        public SectionItem SectionItem { get; set; }
        public Exam Exam { get; set; }
        public long FromNumber { get; set; }
        public long ToNumber { get; set; }
        public string FilePath { get; set; }
        public Major QuitMajor { get; set; }
        public PersianDate QuitStartDate { get; set; }
        public PersianDate QuitEndDate { get; set; }
        public List<Person> Persons { get; set; }
        public List<Reserve> Reserves { get; set; }
        public List<PreEnrollment> PreEnrollments { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Employee> Employees { get; set; }
        public List<CareerApplicant> CareerApplicants { get; set; }
        public bool FromWebsiteNewsletter { get; set; }

        public List<string> Numbers { get; set; }

        public string Text
        {
            get
            {
                if (Major != null)
                    return "رشته " + Major.Name;
                if (Lesson != null)
                    return "درس/سطح " + Lesson.Name;
                if (SectionItem != null)
                    return "گروه " + SectionItem.Section.GroupNumber;
                if(Exam != null)
                    return "آزمون " + Exam.Name;
                if(FromNumber != 0 && ToNumber != 0)
                    return "از شماره " + FromNumber + " تا " + ToNumber;
                if (!string.IsNullOrEmpty(FilePath))
                    return "فایل " + Path.GetFileName(FilePath);
                if (Persons != null)
                    return "زیرمجموعه " + " (" + Persons.Count + " نفر)";
                if (Reserves != null)
                    return "دانشجویان رزرو " + Reserves[0].ReserveList.Name + " (" + Reserves.Count + " نفر)";
                if (PreEnrollments != null)
                    return "پیش ثبت نام  " + PreEnrollments[0].PreEnrollmentList.Name + " (" + PreEnrollments.Count + " نفر)";
                if (Teachers != null)
                    return "مدرس" + " (" + Teachers.Count + " نفر)";
                if (Employees != null)
                    return "پرسنل" + " (" + Employees.Count + " نفر)";
                if (CareerApplicants != null)
                    return "فرصت همکاری " + CareerApplicants[0].Career.Name + " (" + CareerApplicants.Count + " نفر)";
                if (QuitMajor != null)
                    return "دانشجویان مرخصی رشته " + QuitMajor.Name + " از " + QuitStartDate + " تا " + QuitEndDate;
                if(FromWebsiteNewsletter)
                    return "خبرنامه پیامکی سایت";

                return "نامشخص";
            }
        }

        public SmsReceiver()
        {
            Numbers = new List<string>();
        }

        public IList<Register> GetRegisters()
        {
            if (Major != null)
            {
                return Register.GetRegisters(Period, Major);
            }
            if (Lesson != null)
            {
                IList<Participate> participates = Participate.GetParticipates(Period, Lesson);
                return participates.GroupBy(x => x.Register).Select(x => x.Key).ToList();
            }
            if (SectionItem != null)
            {
                IList<Participate> participates = SectionItem.GetParticipates();
                return participates.GroupBy(x => x.Register).Select(x => x.Key).ToList();
            }
            if(QuitMajor != null)
            {
                IQueryable<Register> registers = Register.GetFullQuitedRegisters(QuitMajor, QuitStartDate, QuitEndDate);
                return registers.ToList();
            }
            throw new Exception();
        }

        public void LoadNumbers()
        {
            Numbers.Clear();

            if (Major != null)
            {
                IList<Register> registers = Register.GetRegisters(Period, Major);
                foreach (Register register in registers)
                    Numbers.AddRange(Services.NormalizeMobileString(register.Student.ContactInfo.Mobile));
            }
            if (Lesson != null)
            {
                IList<Participate> participates = Participate.GetParticipates(Period, Lesson);
                IEnumerable<Student> students = participates.GroupBy(x => x.Register.Student).Select(x => x.Key);
                foreach (Student student in students)
                    Numbers.AddRange(Services.NormalizeMobileString(student.ContactInfo.Mobile));
            }
            if (SectionItem != null)
            {
                IList<Participate> participates = SectionItem.GetParticipates();
                IEnumerable<Student> students = participates.GroupBy(x => x.Register.Student).Select(x => x.Key);
                foreach (Student student in students)
                    Numbers.AddRange(Services.NormalizeMobileString(student.ContactInfo.Mobile));
            }
            if (Exam != null)
            {
                foreach (ExamParticipate participate in Exam.GetParticipates())
                    Numbers.AddRange(Services.NormalizeMobileString(participate.Person.ContactInfo.Mobile));
            }
            if(FromNumber != 0 && ToNumber != 0)
            {
                for (long i = FromNumber; i <= ToNumber; i++)
                    Numbers.AddRange(Services.NormalizeMobileString("0" + i));
            }
            if (!string.IsNullOrEmpty(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);
                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line))
                        continue;
                    string[] items = line.Split(';', ',');
                    foreach (string item in items)
                        Numbers.AddRange(Services.NormalizeMobileString(item));
                }
            }
            if(Persons != null)
            {
                foreach (Person person in Persons)
                {
                    Numbers.AddRange(Services.NormalizeMobileString(person.ContactInfo.Mobile));
                }
            }
            if(Reserves != null)
            {
                foreach (Reserve reserve in Reserves)
                {
                    Numbers.AddRange(Services.NormalizeMobileString(reserve.Student.ContactInfo.Mobile));
                }
            }
            if(PreEnrollments != null)
            {
                foreach (PreEnrollment enrollment in PreEnrollments)
                {
                    Numbers.AddRange(Services.NormalizeMobileString(enrollment.Phone));
                }
            }
            if(Teachers != null)
            {
                foreach (Teacher teacher in Teachers)
                {
                    Numbers.AddRange(Services.NormalizeMobileString(teacher.ContactInfo.Mobile));
                }
            }
            if (Employees != null)
            {
                foreach (Employee employee in Employees)
                {
                    Numbers.AddRange(Services.NormalizeMobileString(employee.ContactInfo.Mobile));
                }
            }
            if(CareerApplicants != null)
            {
                foreach (CareerApplicant careerApplicant in CareerApplicants)
                {
                    Numbers.AddRange(Services.NormalizeMobileString(careerApplicant.ContactInfo.Mobile));
                }
            }
            if(QuitMajor != null)
            {
                IList<Register> registers = Register.GetFullQuitedRegisters(QuitMajor, QuitStartDate, QuitEndDate).ToList();
                foreach (Register register in registers)
                    Numbers.AddRange(Services.NormalizeMobileString(register.Student.ContactInfo.Mobile));
            }
            if(FromWebsiteNewsletter)
            {
                IQueryable<NewsletterSubscriber> subscribers = NewsletterSubscriber.GetAllSubscriber();
                foreach (NewsletterSubscriber subscriber in subscribers)
                    Numbers.AddRange(Services.NormalizeMobileString(subscriber.Mobile));
            }
        }
    }
}