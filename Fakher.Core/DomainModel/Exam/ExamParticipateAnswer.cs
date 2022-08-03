using System;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ExamParticipateAnswer : DbObject
    {
        public virtual int QuestionIndex { get; set; }
        public virtual PersianDate AnswerDate { get; set; }
        public virtual int AnswerHour { get; set; }
        public virtual int AnswerMinute { get; set; }
        public virtual int AnswerSecond { get; set; }
        public virtual int SelectedChoice { get; set; }
        [MaximumLength]
        public virtual string EssayAnswer { get; set; }
        [NoCascade]
        public virtual OnlineExamParticipate OnlineExamParticipate { get; set; }
        [NoCascade]
        public virtual ExamTestQuestion ExamTestQuestion { get; set; }
        [NoCascade]
        public virtual ExamEssayQuestion ExamEssayQuestion { get; set; }

        public ExamParticipateAnswer()
        {
            AnswerDate = PersianDate.Today;
            AnswerHour = DateTime.Now.Hour;
            AnswerMinute = DateTime.Now.Minute;
            AnswerSecond = DateTime.Now.Second;
        }
    }
}