using System.Collections.Generic;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ExerciseTrainingItem : TrainingItem
    {
        public virtual string Name { get; set; }
        public virtual bool IsGeneral { get; set; }
        public virtual bool IsEntranceExam { get; set; }
        public virtual bool IsMandatory { get; set; }
        public virtual int NegativeScore { get; set; }
        [NoCascade]
        public virtual EvaluationItem EvaluationItem { get; set; }
        public virtual ExamType Type { get; set; }
        public virtual ExamResultType ResultType { get; set; }
        public virtual RankCalculation RankCalculation { get; set; }
        public virtual IList<ExamItem> Items { get; set; }
        public virtual IList<ExamForm> Forms { get; set; }

        public ExerciseTrainingItem()
        {
            Items = new List<ExamItem>();
            Forms = new List<ExamForm>();
            IsGeneral = false;
            IsEntranceExam = false;
            Type = ExamType.PaperBasedExam;
            ResultType = ExamResultType.ItemsSum;
            RankCalculation = RankCalculation.TotalMark;
        }

        [NonPersistent]
        public virtual ExerciseTrainingItem CloneParent { get; set; }
        
        public override TrainingItem Clone()
        {
            ExerciseTrainingItem item = Services.Clone(this);
            item.CloneParent = this;
            item.Lesson = Lesson;
            foreach (ExamItem examItem in Items)
            {
                ExamItem clone = examItem.Clone();
                clone.ExerciseTrainingItem = item;
                item.Items.Add(clone);
            }
            foreach (ExamForm examForm in Forms)
            {
                ExamForm clone = examForm.Clone();
                clone.ExerciseTrainingItem = item;
                item.Forms.Add(clone);
            }
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