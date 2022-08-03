using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataAccessLayer;
using Fakher.Core.Website;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    [EventClass("کلاس")]
    public class Section : DbObject
    {

        [EventClassProperty("شماره گروه", null)]
        public virtual int GroupNumber { get; set; }
        public virtual int HoldingHours { get; set; }
        public virtual PersianDate StartDate { get; set; }
        public virtual PersianDate FinishDate { get; set; }
        [EventClassProperty("ظرفیت", "0")]
        public virtual int Capacity { get; set; }
        public virtual string Notes { get; set; }
        public virtual double ObservGrade { get; set; }
        [EventClassProperty("رشته", null)]
        [NoCascade]
        public virtual Major Major { get; set; }
        [EventClassProperty("ترم", null)]
        [NoCascade]
        public virtual EducationalPeriod Period { get; set; }
        [EventClassProperty("مدرس اول", null)]
        [NoCascade]
        public virtual Teacher Teacher { get; set; }
        [EventClassProperty("مدرس دوم", null)]
        [NoCascade]
        public virtual Teacher SecondTeacher { get; set; }
        [EventClassProperty("برنامه آموزشی", null)]
        [NoCascade]
        public virtual TrainingPlan TrainingPlan { get; set; }
        public virtual IList<TuitionFee> TuitionFees { get; set; }
        public virtual IList<Formation> Formations { get; set; }
        public virtual IList<SectionItem> Items { get; set; }
        public virtual IList<EducationalEvent> EducationalEvents { get; set; }
        public virtual IList<WebMedia> Attachments { get; set; }
        public virtual bool HasPoll { get; set; }
        [NoCascade]
        public virtual Poll.Poll Poll { get; set; }

        //        public virtual bool WageCalculation { get; set; }

        public Section()
        {
            TuitionFees = new List<TuitionFee>();
            Formations = new List<Formation>();
            Items = new List<SectionItem>();
            EducationalEvents = new List<EducationalEvent>();
            Attachments = new List<WebMedia>();
        }

        [EventClassProperty("نام کلاس", null)]
        [NonPersistent]
        public virtual string Name
        {
            get { return FarsiName; }
        }

        [NonPersistent]
        public virtual string FarsiName
        {
            get { return "گروه " + GroupNumber; }
        }

        [NonPersistent]
        public virtual string EnglishName
        {
            get { return "Group " + GroupNumber; }
        }

        [NonPersistent]
        public virtual string ItemsText
        {
            get
            {
                if (Items.Count == 1)
                    return Items[0].Lesson.Name;
                if (Items.Count > 1)
                    return TypeText;
                return "نا مشخص";
            }
        }

        [NonPersistent]
        public virtual string MasterItemText
        {
            get
            {
                if (Type == SectionType.SingleLevel)
                    if (Items.Count > 0)
                        return Items[0].Lesson.Name;
                return "";
            }
        }

        [NonPersistent]
        public virtual string TypeText
        {
            get
            {
                return Type.ToDescription();
            }
        }

        [NonPersistent]
        public virtual string FarsiFormationText
        {
            get
            {
                string lastTime = "";
                string txt = "";
                foreach (Formation formation in Formations)
                {
                    if (!string.IsNullOrEmpty(lastTime) && formation.Time != lastTime)
                        txt += " [" + lastTime + "]";
                    if (Formations.IndexOf(formation) > 0)
                        txt += "، ";
                    txt += formation.DayText;
                    lastTime = formation.Time;

                }
                txt += " [" + lastTime + "]";
                return txt;
            }
        }

        [NonPersistent]
        public virtual string EnglishFormationText
        {
            get
            {
                string lastTime = "";
                string txt = "";
                foreach (Formation formation in Formations)
                {
                    if (!string.IsNullOrEmpty(lastTime) && formation.Time != lastTime)
                        txt += " [" + lastTime + "]";
                    if (Formations.IndexOf(formation) > 0)
                        txt += ", ";
                    txt += formation.Day;
                    lastTime = formation.Time;

                }
                txt += " [" + lastTime + "]";
                return txt;
            }
        }

        [NonPersistent]
        public virtual string FarsiVerboseFormationText
        {
            get
            {
                string txt = "";
                foreach (Formation formation in Formations)
                {
                    txt += formation.DayText + " [" + formation.Time + "]" + " کلاس " + formation.Place.Name;
                    if (Formations.IndexOf(formation) != Formations.Count - 1)
                        txt += " - ";
                }
                return txt;
            }
        }

        [NonPersistent]
        public virtual string EnglishVerboseFormationText
        {
            get
            {
                string txt = "";
                foreach (Formation formation in Formations)
                {
                    txt += formation.Day + " [" + formation.Time + "]" + " Class " + formation.Place.Name;
                    if (Formations.IndexOf(formation) != Formations.Count - 1)
                        txt += " - ";
                }
                return txt;
            }
        }

        [NonPersistent]
        public virtual SectionType Type
        {
            get
            {
                if (Items.Count > 1)
                    return SectionType.MultiLevel;
                return SectionType.SingleLevel;
            }
        }

        [NonPersistent]
        public virtual int HourPerWeek
        {
            get
            {
                int hours = 0;
                foreach (Formation formation in Formations)
                {
                    hours += formation.Duration.Hours;
                }
                return hours;
            }
        }

        [NonPersistent]
        public virtual int SessionPerWeek
        {
            get { return Formations.Count; }
        }

        [NonPersistent]
        public virtual int SessionCount
        {
            get
            {
                var query = from SectionItem item in Items select item.EndSession;
                return query.Max();
                //                PersianDate[] fridays = PersianDate.GetFridaysBetween(StartDate, FinishDate);
                //                return fridays.Length * SessionPerWeek;
            }
        }

        [NonPersistent]
        public virtual string EducationalEventsText
        {
            get
            {
                List<KeyValuePair<PersianDate, string>> events = new List<KeyValuePair<PersianDate, string>>();
                events.Add(new KeyValuePair<PersianDate, string>(StartDate, "اولین جلسه"));
                foreach (EducationalEvent @event in EducationalEvents.OrderBy(x=>x.Date))
                    events.Add(new KeyValuePair<PersianDate, string>(@event.Date, @event.Title));
                events.Add(new KeyValuePair<PersianDate, string>(FinishDate, "آخرین جلسه"));

                var sortedEvent = from KeyValuePair<PersianDate, string> item in events
                                  orderby item.Key
                                  select item;

                string txt = "";
                for (int i = 0; i < sortedEvent.Count(); i++)
                {
                    KeyValuePair<PersianDate, string> item = events.ElementAt(i);

                    txt += item.Value + " (" + item.Key + ")";

                    if (i != events.Count - 1)
                        txt += " - ";
                }

                return txt;
            }
        }

        [NonPersistent]
        public virtual string FarsiTeacherText
        {
            get
            {
                if (SecondTeacher != null)
                    return Teacher.FarsiFullname + " - " + SecondTeacher.FarsiFullname;
                return Teacher.FarsiFullname;
            }
        }

        #region Static Members

        public static List<Section> GetSections(EducationalPeriod period)
        {
            var query = from section in DbContext.Entity<Section>()
                        where section.Period.Id == period.Id
                        orderby section.GroupNumber
                        select section;
            List<Section> sections = query.ToList();
            return sections;
        }

        public static List<Section> GetSections(EducationalPeriod period, Lesson lesson)
        {
            var query = from item in DbContext.Entity<SectionItem>()
                        where item.Item.Lesson.Id == lesson.Id
                        && item.Section.Period.Id == period.Id
                        orderby item.Section.GroupNumber
                        select item.Section;
            List<Section> sections = query.ToList();
            return sections;
        }

        public static List<Section> GetSections(EducationalPeriod period, Major major)
        {
            var q = from section in DbContext.Entity<Section>()
                    where section.Period.Id == period.Id
                    && section.Major.Id == major.Id
                    orderby section.GroupNumber
                    select section;
            return q.ToList();
        }

        public static List<Section> GetSections(EducationalPeriod period, Major major, Lesson lesson)
        {
            LessonHolding lessonHolding = lesson.GetLessonHolding(period);
            if (lessonHolding == null || !lessonHolding.AllowedMajors.Contains(major))
                return new List<Section>();
            return GetSections(period, lesson);
        }

        #endregion

        public virtual void AddEvent(EducationalEvent @event)
        {
            @event.Section = this;
            EducationalEvents.Add(@event);
        }

        public virtual long GetTuitionFee(Major major)
        {
            foreach (TuitionFee tuitionFee in TuitionFees)
            {
                if (tuitionFee.Major.Id == major.Id && tuitionFee.RegisterParticipation == RegisterParticipation.ClassAndGeneralExams)
                    return tuitionFee.Fee;
            }

            var query = from item in Items select item.GetTuitionFee(major, RegisterParticipation.ClassAndGeneralExams);
            return query.Sum();
        }

        public virtual IQueryable<PersianDate> GetMarkDates(Lesson lesson, EvaluationItem item)
        {
            var query = from participate in GetParticipates(lesson)
                        from mark in participate.GetMarks(item)
                        group mark by mark.Date.ToShortDateString() into date
                        select PersianDate.FromString(date.Key);
            return query.AsQueryable();
        }

        public virtual IQueryable<int> GetMarkBatchNumbers(Lesson lesson, EvaluationItem item)
        {
            var query = from participate in GetParticipates(lesson)
                        from mark in participate.GetMarks(item)
                        group mark by mark.BatchNumber into batch
                        select batch.Key;
            return query.AsQueryable();
        }

        public virtual IList<Participate> GetParticipates(Lesson lesson)
        {
            SectionItem sectionItem = GetItem(lesson);
            return sectionItem.GetParticipates();
            //            var query = from Participate participate in DbContext.Entity<Participate>()
            //                        where participate.Quit == null 
            //                        && participate.SectionItem.Section.Id == Id 
            //                        && participate.SectionItem.Item.Lesson.Id == lesson.Id
            //                        && participate.Register != null
            //                        select participate;
            //            return query.ToList();
        }

        public virtual List<Absence> GetAbsences(Lesson lesson)
        {
            var query = from absence in DbContext.Entity<Absence>()
                        where absence.SectionItem.Section.Id == Id && absence.SectionItem.Item.Lesson.Id == lesson.Id
                        select absence;
            return query.ToList();
        }

        public virtual PersianDate GetSessionDate(int sessionNum)
        {
            int week = sessionNum / SessionPerWeek;
            int idx = sessionNum % SessionPerWeek;
            PersianDate date = StartDate.AddWeeks(week).AddDays((int)Formations[idx].Day);
            return date;
        }

        public virtual Formation GetConflictingFormation()
        {
            //            var query = from Formation f in DbContext.Entity<Formation>()
            //                        where (f.Section.StartDate < FinishDate || f.Section.FinishDate > StartDate)
            //                        select f;

            var query = from f in DbContext.Entity<Formation>()
                        where (f.Section.StartDate < FinishDate && f.Section.StartDate > StartDate) || (f.Section.FinishDate > StartDate)
                        select f;

            List<Formation> queryFormations = query.ToList();

            foreach (Formation formation in Formations)
            {
                foreach (Formation queryFormation in queryFormations)
                {
                    if (queryFormation.Place.Id != formation.Place.Id)
                        continue;
                    if (queryFormation.Day != formation.Day)
                        continue;
                    if (queryFormation.StartTimeInMinutes > formation.StartTimeInMinutes && queryFormation.StartTimeInMinutes < formation.FinishTimeInMinutes)
                        return queryFormation;
                    if (queryFormation.FinishTimeInMinutes > formation.StartTimeInMinutes && queryFormation.FinishTimeInMinutes < formation.FinishTimeInMinutes)
                        return queryFormation;
                }
            }
            return null;
        }

        public virtual IList<Participate> GetParticipates()
        {
            var query = from participate in DbContext.Entity<Participate>()
                        where participate.Quit == null
                        && participate.SectionItem.Section.Id == Id
                        && participate.Register != null
                        select participate;
            return query.ToList();
        }

        public virtual SectionItem GetItem(Lesson lesson)
        {
            var query = from item in Items
                        where item.Lesson.Id == lesson.Id
                        select item;
            return query.FirstOrDefault();
        }

        public virtual Section Clone()
        {
            return Services.Clone<Section>(this);
        }

        public virtual SectionItem GetSignupItem(Register register)
        {
            Participate lastParticipate = register.GetLastParticipate();
            if (lastParticipate == null)
                return Items[0];
            if (lastParticipate.SectionItem.Lesson.GetPlacementProtocol(lastParticipate.Register.Period) != null)
            {
                float mark = lastParticipate.CalculateMark();
                PlacementItem placementItem = lastParticipate.SectionItem.Lesson.GetPlacementProtocol(lastParticipate.Register.Period).GetPlacementItem(mark);
                if (placementItem.Type == PlacementItemType.NotSignup)
                    throw new Exception(string.Format("دانشجو [{0}] به علت نمره [{1}] در [{2}] اجازه ثبت نام ندارد.",
                                                      register.Student.FarsiFullname, mark,
                                                      lastParticipate.SectionItem.Lesson.Name));
                return GetItem(placementItem.Lesson);
            }
            else
            {
                EducationalRule educationalRule = EducationalRule.Apply(Period, register.Participates.ToArray());
                int lastIndex = Items.IndexOf(lastParticipate.SectionItem);
                if (lastIndex == -1)
                    lastIndex = 0;
                return Items[lastIndex + educationalRule.NextIndex];
            }
            throw new Exception("سیستم قادر به یافتن سطح بعدی ثبت نام نمی باشد.");
        }

        public override string ToString()
        {
            string txt = "";
            if (!string.IsNullOrEmpty(MasterItemText))
                txt += MasterItemText + " - ";
            txt += FarsiName;
            return txt;
        }

        public virtual IList<ObserveMark> GetObserveMarks()
        {
            var query = from mark in DbContext.Entity<ObserveMark>()
                        where mark.SectionItem.Section.Id == Id
                        select mark;
            return query.ToList();
        }

        public virtual ObserveMark GetLastObserveMark(ObserveMarkType type)
        {
            var query = from mark in DbContext.Entity<ObserveMark>()
                        where mark.SectionItem.Section.Id == Id
                        && mark.Type == type
                        orderby mark.Id descending
                        select mark;
            return query.FirstOrDefault();
        }

        public virtual SectionItem CreateItem()
        {
            SectionItem item = new SectionItem() { Section = this };
            return item;
        }

        public virtual SectionItem CreateItem(SectionTrainingItem trainingItem)
        {
            SectionItem item = CreateItem();
            item.Item = trainingItem;
            return item;
        }

        public virtual ReserveList GetReserveList()
        {
            var query = from reserveList in DbContext.Entity<ReserveList>()
                        where reserveList.Period.Id == Period.Id
                        && reserveList.Section.Id == Id
                        select reserveList;
            return query.FirstOrDefault();
        }

        public virtual IQueryable<Formation> GetFormations(WeekDay day)
        {
            var query = from formation in Formations
                        where formation.Day == day
                        select formation;
            return query.AsQueryable();
        }

        public virtual int GetHoldedHours(PersianDate startDate, PersianDate endDate)
        {
            int hours = 0;
            PersianDate tempDate = PersianDate.FromString(startDate.ToShortDateString());
            while (tempDate <= endDate)
            {
                WeekDay weekDay = tempDate.GetDayOfWeek();
                List<Formation> formations = GetFormations(weekDay).ToList();
                foreach (Formation formation in formations)
                    hours += formation.Duration.Hours;
                tempDate = tempDate.AddDays(1);
            }
            return hours;
        }

        public virtual int GetHoldedSessions(PersianDate startDate, PersianDate endDate)
        {
            int sessions = 0;
            PersianDate tempDate = PersianDate.FromString(startDate.ToShortDateString());
            while (tempDate <= endDate)
            {
                WeekDay weekDay = tempDate.GetDayOfWeek();
                IQueryable<Formation> formations = GetFormations(weekDay);
                sessions += formations.Count();
                tempDate = tempDate.AddDays(1);
            }
            return sessions;
        }

        //        public virtual bool CanCalculatePassPercent()
        //        {
        //            var query1 = from item in Items
        //                         where item.GetParticipates().Count() > (Capacity / 2)
        //                         select item;
        //            List<SectionItem> sectionItems = query1.ToList();

        //            var query2 = from item in query1
        //                         select item.CalculatePassPercent();
        //            List<float> floats = query2.ToList();

        //            return sectionItems.Count > 0 && floats.Count > 0;
        //        }

        public virtual float CalculatePassPercent()
        {
            // CHECK WITH CANCALCULATEPASSPERCENT Method()
            // Capacity/2 baraye section'hayee ke az 1levele khas shoro shodand va dar levelhaye ghabl tak o took
            // adam sabt shode
            var query1 = from item in Items
                         where item.GetParticipates().Count() > (Capacity / 2)
                         select item;
            List<SectionItem> sectionItems = query1.ToList();

            var query2 = from item in query1
                         select item.CalculatePassPercent();
            List<float> floats = query2.ToList();

            for (int i = floats.Count - 1; i >= 0; i--)
                if (float.IsNaN(floats[i]))
                    floats.RemoveAt(i);

            if (floats.Count == 0)
                throw new Exception("امکان محاسبه درصد قبولی در حال حاضر وجود ندارد.");
            return floats.Average();
        }

        public static Section FromId(int id)
        {
            return DbContext.FromId<Section>(id);
        }
    }

    public enum SectionType
    {
        [EnumDescription("تک درس/سطح")]
        SingleLevel,
        [EnumDescription("چند درس/سطح")]
        MultiLevel
    }
}