using System;
using System.ComponentModel;
using DataAccessLayer;
using Fakher.Core.DomainModel.Consult;
using rComponents;
using System.Linq;

namespace Fakher.Core.DomainModel
{
    public class Formation : DbObject
    {
        public Formation()
        {
            CapacityPolicy = FormationCapacityPolicy.PlaceBased;
        }

        public virtual int StartHour { get; set; }
        public virtual int StartMinute { get; set; }
        public virtual int FinishHour { get; set; }
        public virtual int FinishMinute { get; set; }
        public virtual int FarakhanNo { get; set; }
        public virtual WeekDay Day { get; set; }
        public virtual FormationCapacityPolicy CapacityPolicy { get; set; }
        public virtual int Capacity { get; set; }
        [Attendant]
        [NoCascade]
        public virtual Place Place { get; set; }
        [NoCascade]
        public virtual Section Section { get; set; }
        [NoCascade]
        public virtual ExamHolding ExamHolding { get; set; }
        [NoCascade]
        public virtual ConsultationSession ConsultationSession { get; set; }
        public virtual bool IsLastAssigned { get; set; }

        [NonPersistent]
        public virtual string StartTime
        {
            get { return StartHour.ToString("D2") + ":" + StartMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                StartHour = Convert.ToInt32(timeItems[0]);
                StartMinute = Convert.ToInt32(timeItems[1]);
            }
        }

        [NonPersistent]
        public virtual int StartTimeInMinutes
        {
            get
            {
                return (StartHour*60) + StartMinute;
            }
        }

        [NonPersistent]
        public virtual int FinishTimeInMinutes
        {
            get
            {
                return (FinishHour*60) + FinishMinute;
            }
        }

        [NonPersistent]
        public virtual string FinishTime
        {
            get { return FinishHour.ToString("D2") + ":" + FinishMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                FinishHour = Convert.ToInt32(timeItems[0]);
                FinishMinute = Convert.ToInt32(timeItems[1]);
            }
        }

        [NonPersistent]
        public virtual string DayText
        {
            get
            {
                return Day.ToDescription();
            }
        }

        [NonPersistent]
        public virtual TimeSpan Duration
        {
            get
            {
                return new TimeSpan(FinishHour, FinishMinute, 0) - new TimeSpan(StartHour, StartMinute, 0);
            }
        }

        [NonPersistent]
        public virtual string Time
        {
            get { return StartTime + "-" + FinishTime; }
        }

        [NonPersistent]
        public virtual string FarsiHoldingText
        {
            get
            {
                if (Section != null)
                    return Section.FarsiName + "";
//                if (Exam != null)
//                    return Exam.FarsiText + "";
                return "نا مشخص";
            }
        }

        [NonPersistent]
        public virtual string EnglishHoldingText
        {
            get
            {
                if (Section != null)
                    return Section.EnglishName + "";
//                if (Exam != null)
//                    return Exam.EnglishText + "";
                return "نا مشخص";
            }
        }

        [NonPersistent]
        public virtual string FarsiText
        {
            get
            {
                return DayText + " [" + Time + "]";
                
            }
        }

        [NonPersistent]
        public virtual string EnglishText
        {
            get
            {
                return Day + " [" + Time + "]";
                
            }
        }

        [NonPersistent]
        public virtual int ExamParticipatesCount
        {
            get
            {
                if (ExamHolding != null)
                    return ExamHolding.GetParticipates(this).Count();
                return 0;
            }
        }

        [NonPersistent]
        public virtual int ExamRemainderCount
        {
            get
            {
                return Capacity - ExamParticipatesCount;
            }
        }

        [NonPersistent]
        public virtual int ConsultantApplicantsCount
        {
            get
            {
                if (ConsultationSession != null)
                    return ConsultationSession.GetApplicants(this).Count();
                return 0;
            }
        }

        [NonPersistent]
        public virtual int ConsultantApplicantsRemainderCount
        {
            get
            {
                return Capacity - ConsultantApplicantsCount;
            }
        }

        public override string ToString()
        {
            return FarsiText;
        }

        public virtual bool HasCapacity()
        {
            if (CapacityPolicy == FormationCapacityPolicy.Specific && ExamRemainderCount == 0)
                return false;
            return true;
        }

        public virtual bool HasConsultantApplicantCapacity()
        {
            if (CapacityPolicy == FormationCapacityPolicy.Specific && ConsultantApplicantsRemainderCount == 0)
                return false;
            return true;
        }

        public virtual void CheckExamCapacity()
        {
            if(!HasCapacity())
                throw new MessageException(string.Format("ظرفیت زمان {0} از آزمون تکمیل گردیده است.", FarsiText));
        }

        public static Formation FromId(int id)
        {
            return DbContext.FromId<Formation>(id);
        }
    }

    public enum FormationCapacityPolicy
    {
        [EnumDescription("بر اساس ظرفیت اتاق")]
        PlaceBased,
        [EnumDescription("ظرفیت مشخص")]
        Specific
    }
}