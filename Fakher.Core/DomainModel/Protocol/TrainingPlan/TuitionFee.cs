using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class TuitionFee : DbObject
    {
        public TuitionFee()
        {
            RegisterParticipation = RegisterParticipation.ClassAndGeneralExams;
        }

        public virtual long Fee { get; set; }
        public virtual RegisterParticipation RegisterParticipation { get; set; }
        [NoCascade]
        public virtual Major Major { get; set; }
        [NoCascade]
        public virtual TrainingItem TrainingItem { get; set; }
        [NoCascade]
        public virtual Section Section { get; set; }

        [NonPersistent]
        public virtual string RegisterParticipationText
        {
            get { return RegisterParticipation.ToDescription(); }
        }

        public virtual TuitionFee Clone()
        {
            TuitionFee fee = Services.Clone(this);
            fee.Major = Major;
            return fee;
        }

    }
}