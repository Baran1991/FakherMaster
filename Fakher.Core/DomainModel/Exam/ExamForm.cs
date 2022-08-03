using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ExamForm : DbObject
    {
        public ExamForm()
        {
            CapacityPolicy = CapacityType.UnDetermined;
//            Participates = new List<ExamParticipate>();
            Pages = new List<ExamPage>();
        }

        public virtual string Name { get; set; }
        public virtual string Key { get; set; }
        public virtual CapacityType CapacityPolicy { get; set; }
        public virtual int Capacity { get; set; }
        [NoCascade]
        public virtual Exam Exam { get; set; }
        [NoCascade]
        public virtual ExamTrainingItem ExamTrainingItem { get; set; }
        [NoCascade]
        public virtual ExerciseTrainingItem ExerciseTrainingItem { get; set; }
        [NoCascade]
        public virtual LessonTrainingItem LessonTrainingItem { get; set; }
        //        public virtual IList<ExamParticipate> Participates { get; set; }
        public virtual IList<ExamPage> Pages { get; set; }

        [NonPersistent]
        public virtual bool HasKey
        {
            get { return !string.IsNullOrEmpty(Key); }
        }

        [NonPersistent]
        public virtual int RemainderCount
        {
            get
            {
//                return Capacity - Participates.Count;
                return Capacity - GetParticipates().Count();
            }
        }

        [NonPersistent]
        public virtual int QuestionCount
        {
            get
            {
                int questionCount = 0;
                foreach (ExamPage page in Pages)
                    questionCount += page.QuestionCount;
                return questionCount;
            }
        }

        public virtual IQueryable<ExamParticipate> GetParticipates()
        {
            var query = from participate in DbContext.Entity<ExamParticipate>()
                        where participate.ExamForm.Id == Id
                        select participate;

            return query;
        }

        public virtual ExamParticipate Signup(Enrollment enrollment, Formation formation, bool safeCodeGeneration, bool allowReSignup)
        {
            ExamParticipate examParticipate = Signup(enrollment.Register, formation, safeCodeGeneration, allowReSignup);
            examParticipate.Enrollment = enrollment;
            return examParticipate;
        }

        public virtual ExamParticipate Signup(Participate participate, Formation formation, bool safeCodeGeneration, bool allowReSignup)
        {
            ExamParticipate examParticipate = Signup(participate.Register, formation, safeCodeGeneration, allowReSignup);
            examParticipate.Participate = participate;
            return examParticipate;
        }

        public virtual ExamParticipate Signup(Register register, Formation formation, bool safeCodeGeneration, bool allowReSignup)
        {
            var query = from participate in DbContext.Entity<ExamParticipate>()
                        orderby participate.Code descending
                        select participate.Code;
            long lastCode = query.FirstOrDefault();

            ExamParticipate examParticipate = Exam.CreateExamParticipate();
            if (Exam.Type == ExamType.Exercise|Exam.Type==ExamType.Lesson)
                examParticipate.FinancialDocument = null;
            else
            {
                examParticipate.FinancialDocument.Person = register.Student;
                examParticipate.FinancialDocument.Description = "ثبت نام [" + register.Student.FarsiFullname +
                                                                "] در آزمون [" + Exam.Name +
                                                                "] رشته [" + Exam.Lesson.Major.Name + "]";
            }
            examParticipate.Person = register.Student;
            examParticipate.Register = register;
            Signup(examParticipate, formation, allowReSignup);

            if (lastCode != 0)
                if (safeCodeGeneration)
                    examParticipate.Code = lastCode + Exam.GetParticipates().Count() + 1;
                else
                    examParticipate.Code = lastCode + 1;

            return examParticipate;
        }

        public virtual ExamParticipate Signup(ExamParticipate examParticipate, Formation formation, bool allowReSignup)
        {
            if (Exam.Type == ExamType.Exercise|Exam.Type==ExamType.Lesson)
                if (Exam.RemainderCount == 0)
                throw new MessageException("ظرفیت کل این تمرین تکمیل گردیده است.");
            else
                    if (Exam.RemainderCount == 0)
                    throw new MessageException("ظرفیت کل این آزمون تکمیل گردیده است.");
            CheckCapacity();
            if(formation != null)
                formation.CheckExamCapacity();


            if (!allowReSignup && examParticipate.Register.Student.SignedUpIn(Exam) && Exam.Type!=ExamType.Exercise&&Exam.Type!=ExamType.Lesson)
                throw new MessageException("دانشجو قبلا در این آزمون ثبت نام و شرکت داده شده است.");

            examParticipate.ExamForm = this;
            examParticipate.Formation = formation;
            examParticipate.SeatNumber = Exam.GetParticipates().Count() + 101;

            Exam exam = examParticipate.ExamForm.Exam;
            if (Exam.Type != ExamType.Exercise&Exam.Type!=ExamType.Lesson)
            {
                long tuition = exam.GetTuitionFee(examParticipate.Register.Major, examParticipate.Register.GetRegisterParticipation(false, true));
                FinancialItem item = new FinancialItem(FinancialType.Debt)
                {
                    //                Amount = examParticipate.ExamForm.Exam.TuitionFee,
                    Amount = tuition,
                    Text = string.Format("ثبت نام در {0}", exam.FarsiText)
                };
                examParticipate.FinancialDocument.Items.Add(item);
            }
//            Exam.Participates.Add(examParticipate);
            return examParticipate;
        }

        public virtual string GetAnswer(int questionNumber, string rawAnswers)
        {
//            if (questionNumber >= rawAnswers.Length)
//                return "9";
            if (Exam.Type == ExamType.PaperBasedExam)
                return rawAnswers[questionNumber] + "";
            if (Exam.Type == ExamType.OnlineExam)
                return rawAnswers[questionNumber] + "";
            if (Exam.Type == ExamType.Exercise)
                return rawAnswers[questionNumber] + "";

            throw new MessageException("دریافت پاسخ ها امکان پذیر نیست.");
        }

        public virtual int CalculateCorrectCount(ExamItem item, string rawAnswers)
        {
            // Key == 0 , nomrete soal be hame dade mishavad
            if (string.IsNullOrEmpty(Key))
                throw new Exception(string.Format("کلید فرم {0} وارد نشده است.", Name));

            int correctCount = 0;
            for (int i = item.StartIndex - 1; i < item.EndIndex; i++)
            {
                string answer = GetAnswer(i, rawAnswers);
                if (Key[i] == Exam.WhiteChar || (answer != Exam.WhiteChar + "" && answer == Key[i] + ""))
                    correctCount++;
            }
            return correctCount;
        }

        public virtual int CalculateWrongCount(ExamItem item, string rawAnswers)
        {
            if (string.IsNullOrEmpty(Key))
                throw new Exception(string.Format("کلید فرم {0} وارد نشده است.", Name));

            int wrongCount = 0;
            for (int i = item.StartIndex - 1; i < item.EndIndex; i++)
            {
                string answer = GetAnswer(i, rawAnswers);
                if (Key[i] != Exam.WhiteChar && answer != Exam.WhiteChar + "" && answer != Key[i] + "")
                    wrongCount++;
            }
            return wrongCount;
        }

        public virtual int CalculateWhiteCount(ExamItem item, string rawAnswers)
        {
            if (string.IsNullOrEmpty(Key))
                throw new Exception(string.Format("کلید فرم {0} وارد نشده است.", Name));

            int whiteCount = 0;
            for (int i = item.StartIndex - 1; i < item.EndIndex; i++)
            {
                string answer = GetAnswer(i, rawAnswers);
                if (Key[i] != Exam.WhiteChar && answer == Exam.WhiteChar + "")
                    whiteCount++;
            }
            return whiteCount;
        }

        public virtual float CalculateMark(string rawAnswers)
        {
            if (string.IsNullOrEmpty(rawAnswers))
                return 0;

            if (string.IsNullOrEmpty(Key))
                return 0;
                //throw new Exception(string.Format("کلید فرم {0} آزمون {1} وارد نشده است.", Name, Exam.FarsiText));

            float sum = 0;
            double coeffiecientSum = 0;
            foreach (ExamItem item in Exam.Items)
            {
                float score = CalculateMark(item, rawAnswers);
                sum += score * item.Coefficient;
                coeffiecientSum += item.Coefficient;
            }
            
            if(Exam.ResultType == ExamResultType.ItemsAverage)
                return (float) Math.Round(sum / coeffiecientSum);
            if(Exam.ResultType == ExamResultType.ItemsSum)
                return (float) Math.Round(sum);

            throw new Exception("نوع نتیجه آزمون مشخص نیست.");

//            int correctCount = 0;
//            int wrongCount = 0;
//            int whiteCount = 0;
//            for (int i = 0; i < Exam.QuestionCount; i++)
//            {
//                if (!string.IsNullOrEmpty(Key) && rawAnswers[i] == Key[i])
//                    correctCount++;
//                if (!string.IsNullOrEmpty(Key) && rawAnswers[i] != Exam.WhiteChar && rawAnswers[i] != Key[i])
//                    wrongCount++;
//                if (!string.IsNullOrEmpty(Key) && rawAnswers[i] == Exam.WhiteChar)
//                    whiteCount++;
//            }
//
//            float rawMark = CalculateRawPercent(Exam.QuestionCount, correctCount, wrongCount);
//            float mark = ConvertToMark(rawMark, Exam.EvaluationItem.Value);
//            return (float) Math.Round(mark, 2);
        }

        public virtual float CalculateMarkOf20(string rawAnswers)
        {
            if (string.IsNullOrEmpty(rawAnswers))
                return 0;

            if(string.IsNullOrEmpty(Key))
                throw new Exception(string.Format("کلید فرم {0} وارد نشده است.", Name));

            float sum = 0;
            double coeffiecientSum = 0;
            foreach (ExamItem item in Exam.Items)
            {
                float score = CalculateMarkOf20(item, rawAnswers);
                sum += score * item.Coefficient;
                coeffiecientSum += item.Coefficient;
            }
            
            if(Exam.ResultType == ExamResultType.ItemsAverage)
                return (float) Math.Round(sum / coeffiecientSum);
            if(Exam.ResultType == ExamResultType.ItemsSum)
                return (float) Math.Round(sum);

            throw new Exception("نوع نتیجه آزمون مشخص نیست.");
        }

        public virtual float ConvertToMark(float rawPercent, double evaluationValue)
        {
            return (float)(rawPercent * evaluationValue) / 100;
        }

        public virtual float CalculateRawPercent(int totalCount, int trueCount, int wrongCount)
        {
            float p;
            if (Exam.NegativeScore > 0)
                p = ((float) ((trueCount*Exam.NegativeScore) - wrongCount))/(totalCount*Exam.NegativeScore);
            else
                p = ((float)(trueCount)) / totalCount;
            return p*100;
        }

        public virtual float CalculateMark(ExamItem item, string rawAnswers)
        {
            if (string.IsNullOrEmpty(rawAnswers))
                return 0;

            int correctCount = CalculateCorrectCount(item, rawAnswers);
            int wrongCount = CalculateWrongCount(item, rawAnswers);
            float rawPercent = CalculateRawPercent(item.QuestionCount, correctCount, wrongCount);
            float mark = ConvertToMark(rawPercent, item.Mark);
//            float mark2 = (float)((correctCount * item.Mark) / item.QuestionCount);
            return (float) Math.Round(mark, 2);
        }

        public virtual float CalculateMarkOf20(ExamItem item, string rawAnswers)
        {
            if (string.IsNullOrEmpty(rawAnswers))
                return 0;

            int correctCount = CalculateCorrectCount(item, rawAnswers);
            int wrongCount = CalculateWrongCount(item, rawAnswers);
            float rawPercent = CalculateRawPercent(item.QuestionCount, correctCount, wrongCount);
            float mark = ConvertToMark(rawPercent, 20);
            return (float) Math.Round(mark, 2);
        }

        public virtual float CalculatePercent(ExamItem item, string rawAnswers)
        {
            if (string.IsNullOrEmpty(rawAnswers))
                return 0;

            int correctCount = CalculateCorrectCount(item, rawAnswers);
            int wrongCount = CalculateWrongCount(item, rawAnswers);
            float percent = CalculateRawPercent(item.QuestionCount, correctCount, wrongCount);
//            float percent2 = ((correctCount * 100) / item.QuestionCount);
            return (float)Math.Round(percent, 2);
        }

        public virtual void SetKey(string key)
        {
            if(key.Length < Exam.QuestionCount)
                throw new Exception("تعداد سئوال های کلید کمتر از تعداد سئوال های آزمون است.");
            string effectiveKey = key.Substring(0, Exam.QuestionCount);
            int index = effectiveKey.IndexOf('0');
            if(index != -1)
                throw new Exception(string.Format("کلید سئوال {0} از {1} وارد نشده است.", index, Exam.QuestionCount));

            Key = key;
        }

        public virtual ExamForm Clone()
        {
            ExamForm clone = Services.Clone(this);
            return clone;
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual void CheckCapacity()
        {
            if (CapacityPolicy == CapacityType.Determined && RemainderCount == 0)
                throw new MessageException(string.Format("ظرفیت فرم {0} از آزمون تکمیل گردیده است.", Name));
        }

        public static ExamForm FromId(int id)
        {
            return DbContext.FromId<ExamForm>(id);
        }
    }
}