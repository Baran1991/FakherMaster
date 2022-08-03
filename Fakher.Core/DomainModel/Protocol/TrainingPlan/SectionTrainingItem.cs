using rComponents;

namespace Fakher.Core.DomainModel
{
    public class SectionTrainingItem : TrainingItem
    {
        public virtual int StartSession { get; set; }
        public virtual int EndSession { get; set; }

        public override TrainingItem Clone()
        {
            SectionTrainingItem item = Services.Clone(this);
            item.Lesson = Lesson;
//            item.Parent = this;

            foreach (TuitionFee tuitionFee in TuitionFees)
            {
                TuitionFee cloneFee = tuitionFee.Clone();
                cloneFee.TrainingItem = item;
                item.TuitionFees.Add(cloneFee);
            }
            return item;
        }
    }
}