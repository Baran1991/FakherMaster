using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ExamParticipate : FinancialEntity
    {
        protected Dictionary<ExamItem, float> mExamItemMarks;

        public ExamParticipate()
        {
            FinancialDocument = new FinancialDocument();
            RegisterDate = PersianDate.Today;
            CardDelivered = false;
            AdditiveMark = 0;
        }

        public virtual long Code { get; set; }
        public virtual PersianDate RegisterDate { get; set; }
        public virtual int SeatNumber { get; set; }
        //public virtual int FarakhanNo { get; set; }
        public virtual int ExamNumber { get; set; }
        public virtual bool ExclusiveParticipation { get; set; }
        public virtual PersianDate CardDeliveryDate { get; set; }
        public virtual bool CardDelivered { get; set; }
        public virtual bool InternetRegisteration { get; set; }
        public virtual bool EnrollmentConfirmed { get; set; }
        [NoCascade]
        public virtual Exam Exam { get; set; }
        [NoCascade]
        public virtual ExamForm ExamForm { get; set; }
        public virtual Formation Formation { get; set; }
        public virtual float AdditiveMark { get; set; }
        public virtual Quit Quit { get; set; }
        public virtual Enrollment Enrollment { get; set; }
        [NoCascade]
        public virtual Person Person { get; set; }
        [NoCascade]
        public virtual Register Register { get; set; }
        [NoCascade]
        public virtual Participate Participate { get; set; }
        /// <summary>
        /// توضیحات در آزمون مصاحبه
        /// </summary>
        [MaximumLength]
        public virtual string Comment { get; set; }

        #region Overrides of FinancialEntity

        [NonPersistent]
        public override long PayableTuition
        {
            get
            {
                return ExamForm.Exam.GetTuitionFee(Register.Major, Register.GetRegisterParticipation(false, true));
//                return ExamForm.Exam.TuitionFee;
            }
        }

        [NonPersistent]
        public override FinancialHeading Heading
        {
            get { return FinancialHeading.ExamSignup; }
        }

        #endregion

        [NonPersistent]
        public virtual ExamParticipateStatus Status
        {
            get;set;
            //get
            //{
            //   //throw new NotImplementedException();
            //}
        }

        [NonPersistent]
        public virtual string StatusText
        {
            set { }
           
            get
            {
                return Status.ToDescription();
            }
        }

        [NonPersistent]
        public virtual Formation ExamFormation
        {
            set { }
            get
            {
                return Formation;
            }
        }

        [NonPersistent]
        public virtual string ExamTimeText
        {
            set { }
            get
            {
                Formation examFormation = ExamFormation;
                if(examFormation != null)
                    return examFormation.FarsiText;
                return "نامشخص";
            }
        }

        [NonPersistent]
        public virtual string CardStatusText
        {
            set { }
            get
            {
                if (CardDelivered)
                    return "دارد";
                return "ندارد";
            }
        }

        [NonPersistent]
        public virtual bool IsPeresent
        {
            get
            {
                throw new NotImplementedException();
//                for (int i = 0; i < ExamForm.Exam.QuestionCount; i++)
//                    if (IsAnswered(i))
//                        return true;
//                return false;
            }
        }

        [NonPersistent]
        public virtual bool IsAbsent
        {
            get
            {
                throw new NotImplementedException();
//                for (int i = 0; i < ExamForm.Exam.QuestionCount; i++)
//                    if (IsAnswered(i))
//                        return false;
//                return true;
            }
        }


        public virtual float CalculateMark()
        {
            throw new NotImplementedException();
        }

        public virtual float CalculateMarkOf20()
        {
            throw new NotImplementedException();
        }

        public virtual void EnsureExamItemMarkPreCalculation()
        {
            throw new NotImplementedException();
        }

        public virtual float CalculateMark(ExamItem examItem)
        {
            throw new NotImplementedException();
        }

        public virtual float CalculateMarkOf20(ExamItem examItem)
        {
            throw new NotImplementedException();
        }

        public virtual float CalculatePercent(ExamItem examItem)
        {
            throw new NotImplementedException();
        }

        public virtual ExamSection GetSection()
        {
//            IEnumerable<ExamSection> query;
            if (Participate != null)
            {
                var query = from examSection in ExamForm.Exam.ExamSections
                        where examSection.SectionItem.Id == Participate.SectionItem.Id
                        select examSection;
                return query.FirstOrDefault();
            }
            else
            {
                foreach (ExamSection examSection in ExamForm.Exam.ExamSections)
                {
                    var query = from participate in DbContext.Entity<Participate>()
                                where participate.SectionItem != null
                                      && participate.Register != null
                                      && participate.SectionItem.Id == examSection.SectionItem.Id
                                      && participate.Register.Id == Register.Id
                                select participate;
                    Participate resultParticipate = query.FirstOrDefault();
                    if (resultParticipate != null)
                        return examSection;
                }
//                query = from examSection in ExamForm.Exam.ExamSections
//                        //                          from participate in examSection.SectionItem.GetAllParticipates() //too old
//                        from participate in examSection.SectionItem.Participates
//                        where participate.Register != null
//                              && participate.Register.Id == Register.Id
//                        select examSection;
            }
            return null;
        }

        public virtual bool IsAnswered(int questionNumber)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsCorrect(int questionNumber)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsWrong(int questionNumber)
        {
            throw new NotImplementedException();
        }

        public virtual void Prepare(bool randomSeatNumber)
        {
            if (!ExamForm.Exam.HasHolding)
                return;

            ExamHolding examHolding = ExamForm.Exam.ExamHolding;

            if (ExamForm.Exam.Type == ExamType.PaperBasedExam)
            {
                PaperBasedExamHolding paperBasedExamHolding = examHolding as PaperBasedExamHolding;
                KeyValuePair<Formation, int> seatNumber;
                if (randomSeatNumber)
                    seatNumber = paperBasedExamHolding.GetRandomSeatNumber();
                else
                    seatNumber = paperBasedExamHolding.GetNextSeatNumber();

                Formation = seatNumber.Key;
                SeatNumber = seatNumber.Value;
            }

            if (ExamForm.Exam.Type == ExamType.OralExam)
            {
                
            }

            if (ExamForm.Exam.Type == ExamType.OnlineExam)
            {
                
            }
        }

        public virtual void PrepareExamCardForDelivery()
        {
            CardDelivered = true;
            CardDeliveryDate = PersianDate.Today;
        }

        public virtual Bitmap GetAnswersheetView()
        {
            return null;
        }

        public virtual void ConfirmEnrollment()
        {
            EnrollmentConfirmed = true;
        }

        public static ExamParticipate GetExamParticipate(long code)
        {
            var query = from participate in DbContext.Entity<ExamParticipate>()
                        where participate.Code == code
                        select participate;
            return query.FirstOrDefault();
        }

        public static ExamParticipate FromId(int id)
        {
            return DbContext.FromId<ExamParticipate>(id);
        }
    }

    public enum ExamParticipateStatus
    {
        [EnumDescription("غائب")]
        Absent,
        [EnumDescription("تصحیح شده")]
        HasResult,
        [EnumDescription("نامشخص")]
        UnKnown,
        [EnumDescription("عدم ثبت نام")]
        NotParticipate
    }
}