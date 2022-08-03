using System;
using System.Collections.Generic;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class PaperBasedExamHolding : ExamHolding
    {
        public PaperBasedExamHolding()
        {
            FirstSeatNumber = 101;
            SeatNumberPolicy = SeatNumberPolicy.Sequential;
            SeatAssignPolicy = SeatAssignPolicy.OnCardDelivery;
        }

        public virtual int FirstSeatNumber { get; set; }
        public virtual int LastSeatNumber { get; set; }
        public virtual SeatNumberPolicy SeatNumberPolicy { get; set; }
        public virtual SeatAssignPolicy SeatAssignPolicy { get; set; }
        public virtual int LastSequentialAssignedSeatNumber { get; set; }

        public virtual KeyValuePair<Formation, int> GetNextSeatNumber()
        {
            Formation formation;
            Formation lastAssignedFormation = GetLastAssignedFormation();
            int seat = 0;

            if (lastAssignedFormation == null)
                formation = Formations[0];
            else
                formation = lastAssignedFormation;

            int i = 1;
            bool check = false;
            while (!check)
            {
                if (LastSequentialAssignedSeatNumber == 0)
                    seat = (FirstSeatNumber - 1) + i;
                else
                    seat = LastSequentialAssignedSeatNumber + i;

                if (formation.CapacityPolicy == FormationCapacityPolicy.Specific && formation.ExamRemainderCount == 0)
                {
                    int indexOf = Formations.IndexOf(formation);
                    if (indexOf >= Formations.Count - 1)
                        throw new Exception("مکان های تعریف شده برای این برگزاری آزمون، همگی پر هستند و جای خالی دیگری وجود ندارد.");

                    formation = Formations[indexOf + 1];
                }
                if (seat > LastSeatNumber)
                    throw new Exception("محدوده مجاز شماره صندلی به پایان رسیده است.");

                check = CheckAvailablity(formation, seat);

                if (!check)
                    i++;
            }

            LastSequentialAssignedSeatNumber = seat;
            SetLastAssignedFormation(formation);
            //            lastAssignedFormation = formation;

            return new KeyValuePair<Formation, int>(formation, LastSequentialAssignedSeatNumber);
        }

        public virtual bool CheckAvailablity(Formation formation, int seatNumber)
        {
            foreach (Exam exam in Exams)
            {
                ExamParticipate examParticipate = exam.GetParticipate(formation, seatNumber);
                if (examParticipate != null && examParticipate.CardDelivered)
                    return false;
            }
            return true;
        }

        public virtual KeyValuePair<Formation, int> GetRandomSeatNumber()
        {
            //check before return
            throw new NotImplementedException();
        }

    }
    public enum SeatNumberPolicy
    {
        [EnumDescription("ترتیبی")]
        Sequential,
        [EnumDescription("تصادفی")]
        Random
    }

    public enum SeatAssignPolicy
    {
        [EnumDescription("هنگام تحویل کارت")]
        OnCardDelivery,
        [EnumDescription("هم اکنون")]
        Now
    }
}