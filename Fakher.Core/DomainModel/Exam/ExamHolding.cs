using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ExamHolding : DbObject
    {
        public ExamHolding()
        {
//            FirstSeatNumber = 101;
            StartDate = PersianDate.Today;
            Exams = new List<Exam>();
            Formations = new List<Formation>();
//            SeatNumberPolicy = SeatNumberPolicy.Sequential;
//            SeatAssignPolicy = SeatAssignPolicy.OnCardDelivery;
        }

        public virtual PersianDate StartDate { get; set; }
        public virtual PersianDate EndDate { get; set; }
        public virtual bool HasEnd { get; set; }
//        public virtual bool HasEndDate { get; set; }
        public virtual IList<Exam> Exams { get; set; }
        public virtual IList<Formation> Formations { get; set; }
//        public virtual int FirstSeatNumber { get; set; }
//        public virtual int LastSeatNumber { get; set; }
//        public virtual SeatNumberPolicy SeatNumberPolicy { get; set; }
//        public virtual SeatAssignPolicy SeatAssignPolicy { get; set; }
//        public virtual int LastSequentialAssignedSeatNumber { get; set; }

        [NonPersistent]
        public virtual string Text
        {
            get
            {
                string txt = "برگزاری آزمونهای ";
                
                if(Exams.Count == 1)
                    txt = "برگزاری آزمون ";

                if(Exams.Count > 1)
                    txt = "برگزاری آزمونهای ";

                foreach (Exam exam in Exams)
                {
                    txt += exam.Lesson.Major.Name;
                    if(Exams.IndexOf(exam) != Exams.Count - 1)
                        txt += "، ";
                }
                return txt;
            }
        }

        [NonPersistent]
        public virtual string FormationText
        {
            get
            {
                string txt = "";
                foreach (Formation formation in Formations)
                {
                    txt += formation.FarsiText;
                    if (Formations.IndexOf(formation) != Formations.Count - 1)
                        txt += "، ";
                }
                return txt;
            }
        }

        public virtual void AddFormation(Formation formation)
        {
            formation.ExamHolding = this;
            Formations.Add(formation);
        }        
        
        public virtual void AddExam(Exam exam)
        {
            exam.ExamHolding = this;
            Exams.Add(exam);
        }

        public virtual void SetLastAssignedFormation(Formation formation)
        {
            foreach (Formation formation1 in Formations)
                formation1.IsLastAssigned = false;
            formation.IsLastAssigned = true;
        }

        public virtual Formation GetLastAssignedFormation()
        {
            return Formations.Where(x => x.IsLastAssigned).FirstOrDefault();
        }

//        public virtual KeyValuePair<Formation, int> GetNextSeatNumber()
//        {
//            Formation formation;
//            Formation lastAssignedFormation = GetLastAssignedFormation();
//            int seat = 0;
//
//            if (lastAssignedFormation == null)
//                formation = Formations[0];
//            else
//                formation = lastAssignedFormation;
//
//            int i = 1;
//            bool check = false;
//            while (!check)
//            {
//                if (LastSequentialAssignedSeatNumber == 0)
//                    seat = (FirstSeatNumber-1) + i;
//                else
//                    seat = LastSequentialAssignedSeatNumber + i;
//
//                if (formation.CapacityPolicy == FormationCapacityPolicy.Specific && formation.ExamRemainderCount == 0)
//                {
//                    int indexOf = Formations.IndexOf(formation);
//                    if(indexOf >= Formations.Count - 1)
//                        throw new Exception("مکان های تعریف شده برای این برگزاری آزمون، همگی پر هستند و جای خالی وجود ندارد.");
//
//                    formation = Formations[indexOf + 1];
//                }
//                if(seat > LastSeatNumber)
//                    throw new Exception("محدوده مجاز شماره صندلی به پایان رسیده است.");
//
//                check = CheckAvailablity(formation, seat);
//
//                if(!check)
//                    i++;
//            }
//
//            LastSequentialAssignedSeatNumber = seat;
//            SetLastAssignedFormation(formation);
////            lastAssignedFormation = formation;
//
//            return new KeyValuePair<Formation, int>(formation, LastSequentialAssignedSeatNumber);
//        }
//
//        public virtual bool CheckAvailablity(Formation formation, int seatNumber)
//        {
//            foreach (Exam exam in Exams)
//            {
//                ExamParticipate examParticipate = exam.GetParticipate(formation, seatNumber);
//                if(examParticipate != null && examParticipate.CardDelivered)
//                    return false;
//            }
//            return true;
//        }
//
//        public virtual KeyValuePair<Formation, int> GetRandomSeatNumber()
//        {
//            //check before return
//            throw new NotImplementedException();
//        }

        public virtual Formation GetRandomFormation()
        {
            if (Formations.Count == 0)
                return null;

            Random random = new Random();
            int idx = random.Next(0, Formations.Count);
            Formation formation = Formations[idx];
            return formation;
        }

        public virtual IQueryable<ExamParticipate> GetParticipates(Formation formation)
        {
            var query = from exam in Exams
                        from participate in exam.GetParticipates(formation)
                        select participate;
            return query.AsQueryable();
        }

        public virtual IQueryable<Formation> GetFreeFormations()
        {
            var query = from formation in Formations
                        where formation.HasCapacity()
                        select formation;
            return query.AsQueryable();
        }
    }
}