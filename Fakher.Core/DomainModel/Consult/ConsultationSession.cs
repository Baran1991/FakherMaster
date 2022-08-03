using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel.Consult
{
    public class ConsultationSession : DbObject
    {
        public virtual string Name { get; set; }
        public virtual PersianDate StartDate { get; set; }
        public virtual PersianDate EndDate { get; set; }
        public virtual PersianDate HoldingDate { get; set; }
        public virtual int HoldingStartHour { get; set; }
        public virtual int HoldingStartMinute { get; set; }
        public virtual int HoldingEndHour { get; set; }
        public virtual int HoldingEndMinute { get; set; }
        public virtual int ConsultationDuration { get; set; }
        public virtual bool InternetRegisterable { get; set; }

        public virtual IList<Formation> Formations { get; set; }

        public ConsultationSession()
        {
            Formations = new List<Formation>();
        }

        [NonPersistent]
        public virtual string HoldingStartTime
        {
            get { return HoldingStartHour.ToString("D2") + ":" + HoldingStartMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                HoldingStartHour = Convert.ToInt32(timeItems[0]);
                HoldingStartMinute = Convert.ToInt32(timeItems[1]);
            }
        }

        [NonPersistent]
        public virtual string HoldingEndTime
        {
            get { return HoldingEndHour.ToString("D2") + ":" + HoldingEndMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                HoldingEndHour = Convert.ToInt32(timeItems[0]);
                HoldingEndMinute = Convert.ToInt32(timeItems[1]);
            }
        }


//        public Formation[] GetConsultationFormations()
//        {
//            List<Formation> formations = new List<Formation>();
//            DateTime start = HoldingDate.ToSystemDateTime(HoldingStartHour, HoldingStartMinute, 0);
//            DateTime end = HoldingDate.ToSystemDateTime(HoldingEndHour, HoldingEndMinute, 0);
//            DateTime startFormation = start;
//
//            while (startFormation < end)
//            {
//                Formation formation = new Formation();
//                formation.StartHour = startFormation.Hour;
//                formation.StartMinute = startFormation.Minute;
//                formation.Day = PersianDate.FromSystemDate(startFormation).GetDayOfWeek();
//                formation.CapacityPolicy = FormationCapacityPolicy.Specific;
//                formation.Capacity = rTxtFormationCapacity.GetValue<int>();
//                formation.Place = rGridComboBoxPlace.GetValue<Place>();
//
//                DateTime endFormation = startFormation.AddMinutes(ConsultationDuration);
//                formation.FinishHour = endFormation.Hour;
//                formation.FinishMinute = endFormation.Minute;
//
//                formations.Add(formation);
//
//                startFormation = endFormation;
//            }
//
//            return formations.ToArray();
//        }

        public virtual void AddFormation(Formation formation)
        {
            formation.ConsultationSession = this;
            Formations.Add(formation);
        }

        public virtual IQueryable<ConsultationApplicant> GetApplicants()
        {
            var query = from applicant in DbContext.Entity<ConsultationApplicant>()
                        where applicant.Session.Id == Id
                        select applicant;
            return query;
        }

        public virtual IQueryable<ConsultationApplicant> GetApplicants(Formation formation)
        {
            var query = from applicant in DbContext.Entity<ConsultationApplicant>()
                        where applicant.Session.Id == Id
                        && applicant.Formation.Id == formation.Id
                        select applicant;
            return query;
        }

        public virtual IQueryable<Formation> GetFreeFormations()
        {
            var query = from formation in Formations
                        where formation.HasConsultantApplicantCapacity()
                        select formation;
            return query.AsQueryable();
        }

        public static ConsultationSession FromId(int id)
        {
            return DbContext.FromId<ConsultationSession>(id);
        }
    }
}