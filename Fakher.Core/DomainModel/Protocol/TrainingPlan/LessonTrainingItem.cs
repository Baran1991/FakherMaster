using System.Collections.Generic;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class LessonTrainingItem : TrainingItem
    {
        public virtual string Name { get; set; }
        public virtual bool IsGeneral { get; set; }
        public virtual string Content { get; set; }
        [NoCascade]
        public virtual EvaluationItem EvaluationItem { get; set; }
        public virtual ExamType Type { get; set; }
       
        public virtual IList<ExamItem> Items { get; set; }
        public virtual IList<ExamForm> Forms { get; set; }

        public LessonTrainingItem()
        {
            Items = new List<ExamItem>();
            Forms = new List<ExamForm>();
            IsGeneral = false;
           
            Type = ExamType.Lesson;
           
        }

        [NonPersistent]
        public virtual LessonTrainingItem CloneParent { get; set; }
        
        public override TrainingItem Clone()
        {
            LessonTrainingItem item = Services.Clone(this);
            item.CloneParent = this;
            item.Lesson = Lesson;
            foreach (ExamItem examItem in Items)
            {
                ExamItem clone = examItem.Clone();
                clone.LessonTrainingItem = item;
                item.Items.Add(clone);
            }
         
            return item;
        }

    }
}