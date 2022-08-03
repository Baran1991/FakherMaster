using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Enrollment : DbObject
    {
        public Enrollment()
        {
            Date = PersianDate.Today;
        }

        public virtual PersianDate Date { get; set; }
        [NoProxy]
        [NoCascade]
        public virtual TrainingItem TrainingItem { get; set; }
        [NoCascade]
        public virtual Register Register { get; set; }

        public virtual long GetTuitionFee()
        {
            TuitionFee tuitionFee = TrainingItem.GetTuitionFee(Register.Major, Register.GetRegisterParticipation(TrainingItem is SectionTrainingItem, TrainingItem is ExamTrainingItem));
//            TuitionFee tuitionFee = TrainingItem.GetTuitionFee(Register.Major, Register.RegisterParticipation);
            if (tuitionFee == null)
                return 0;
            return tuitionFee.Fee;
        }
    }
}