using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer;
using System.Linq;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class EducationalRule : Protocol
    {
        public EducationalRule()
        {
            RecurrenceOperator = CountOperator.Minimum;
            RecurrenceCount = 1;
            RecurrenceType = RecurrenceType.Alternative;
            NextIndex = 1;
        }

        public virtual ResultLabel ResultLabel { get; set; }
        public virtual CountOperator RecurrenceOperator { get; set; }
        public virtual int RecurrenceCount { get; set; }
        public virtual RecurrenceType RecurrenceType { get; set; }
        public virtual int DiscountPercent { get; set; }
        public virtual int PenaltyPercent { get; set; }
        public virtual int NextIndex { get; set; }
        public virtual int Position { get; set; }
        public virtual string Text { get; set; }
        public virtual EducationalRuleResult Result { get; set; }

        [NonPersistent]
        public virtual string ResultText
        {
            get
            {
                return Result.ToDescription();
//                if(NextIndex == 1)
//                    return EducationalRuleResult.Pass;
//                if(NextIndex == 0)
//                    return EducationalRuleResult.Fail;
//                return EducationalRuleResult.Jump;                
            }
        }

        [NonPersistent]
        public virtual string RecurrenceOperatorText
        {
            get
            {
                return RecurrenceOperator.ToDescription();
            }
        }

        [NonPersistent]
        public virtual string RecurrenceTypeText
        {
            get
            {
                return RecurrenceType.ToDescription();
            }
        }

        public static IList<EducationalRule> GetRules(EducationalPeriod period)
        {
            var query = from rule in DbContext.Entity<EducationalRule>()
                        where rule.Period.Id == period.Id
                        orderby rule.Position
                        select rule;
            return query.ToList();
        }

        public virtual bool CanApply(Participate[] participates)
        {
//            foreach (Participate participate in participates)
//                if (ResultLabel.ResultProtocol.Id != participate.SectionItem.Lesson.GetResultProtocol(participate.Register.Period).Id)
//                    return false;

            int count = 0;
            List<ResultLabel> labels = new List<ResultLabel>();
            foreach (Participate participate in participates)
            {
                ResultLabel resultLabel = participate.GetResultLabel();
                labels.Add(resultLabel);
            }

            if (RecurrenceType == RecurrenceType.Continuous)
                count = GetContinuousCount(labels);
            else if (RecurrenceType == RecurrenceType.Alternative)
                count = GetAlternativeCount(labels);

            if (RecurrenceOperator == CountOperator.Maximum)
                return count <= RecurrenceCount;
            if (RecurrenceOperator == CountOperator.Only)
                return count == RecurrenceCount;
            if (RecurrenceOperator == CountOperator.Minimum)
                return count >= RecurrenceCount;

            throw new Exception("سیستم قادر به اعمال قانون آموزشی نیست.");
        }

        public virtual bool CanApply(ExamParticipate[] examParticipates)
        {
            int count = 0;
            List<ResultLabel> examLabels = new List<ResultLabel>();
            foreach (ExamParticipate examParticipate in examParticipates)
            {
                ResultLabel resultLabel = examParticipate.ExamForm.Exam.ResultProtocol.Apply(examParticipate);
                examLabels.Add(resultLabel);
            }

            if (RecurrenceType == RecurrenceType.Continuous)
                count = GetContinuousCount(examLabels);
            else if (RecurrenceType == RecurrenceType.Alternative)
                count = GetAlternativeCount(examLabels);

            if (RecurrenceOperator == CountOperator.Maximum)
                return count <= RecurrenceCount;
            if (RecurrenceOperator == CountOperator.Only)
                return count == RecurrenceCount;
            if (RecurrenceOperator == CountOperator.Minimum)
                return count >= RecurrenceCount;

            throw new Exception("سیستم قادر به اعمال قانون آموزشی نیست.");
        }

        private int GetContinuousCount(List<ResultLabel> labels)
        {
            int count = 0;
            for (int i = labels.Count - 1; i >= 0; i--)
            {
                ResultLabel label = labels[i];
//                if (label.Id == ResultLabel.Id)
                if (label.Name == ResultLabel.Name)
                {
                    count++;
                }
                else
                {
                    if (count != 0)
                        return count;
                }
            }
            return count;
        }

        private int GetAlternativeCount(List<ResultLabel> labels)
        {
            int count = 0;
            foreach (ResultLabel label in labels)
            {
//                if (label.Id == ResultLabel.Id)
                if (label.Name == ResultLabel.Name)
                    count++;
            }
            return count;
        }

        public static EducationalRule Apply(EducationalPeriod currentPeriod, Participate[] participates)
        {
            Exception lastException = null;
            List<EducationalRule> rules = GetRules(currentPeriod).ToList();
            foreach (EducationalRule rule in rules)
            {
                try
                {
                    if (rule.CanApply(participates))
                    {
                        return rule;
                    }
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }
            }
            string lastExceptionText = lastException != null ? lastException.Message : "";
            if (participates.Length > 0)
                throw new Exception(string.Format("برای رشته {0} قانون آموزشی قابل انطباقی وجود ندارد. \r\n {1}", participates[0].Register.Major.Name, lastExceptionText), lastException);
            throw new Exception(string.Format("قانون آموزشی قابل انطباقی وجود ندارد. \r\n {0}", lastExceptionText), lastException);
        }

        public static EducationalRule Apply(EducationalPeriod currentPeriod, ExamParticipate[] examParticipates)
        {
            List<EducationalRule> rules = GetRules(currentPeriod).ToList();
            foreach (EducationalRule rule in rules)
            {
                if (rule.CanApply(examParticipates))
                {
                    return rule;
                }
            }
            throw new Exception(string.Format("برای آزمون {0} قانون آموزشی قابل انطباقی وجود ندارد.", examParticipates[0].ExamForm.Exam.Name));
        }

        public virtual EducationalRule Clone()
        {
            EducationalRule rule = Services.Clone<EducationalRule>(this);
            rule.ResultLabel = ResultLabel;
            return rule;
        }
    }

    public enum RecurrenceType
    {
        [EnumDescription("متوالی")]
        Continuous,
        [EnumDescription("متناوب")]
        Alternative
    }

    public enum EducationalRuleResult
    {
        [EnumDescription("مـــردود")]
        Fail,
        [EnumDescription("قبــول")]
        Pass,
//        [EnumDescription("جــهــش")]
//        Jump
    }
}