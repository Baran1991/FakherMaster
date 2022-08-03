using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class ResultProtocol : Protocol
    {
        public ResultProtocol()
        {
            Labels = new List<ResultLabel>();
        }

        public virtual IList<ResultLabel> Labels { get; set; }

        public virtual ResultLabel Apply(Participate participate)
        {
            float mark = participate.CalculateMark();
            int absences = participate.GetAbsences().Count();
            bool mandatoryLack = false;
            try
            {
                participate.CheckMandatoryExamsSignup();
            }
            catch (Exception e)
            {
                mandatoryLack = true;
            }

            foreach (ResultLabel label in Labels)
            {
                if (label.CanApply(mark, absences, mandatoryLack))
                    return label;
            }
            throw new ArgumentOutOfRangeException(string.Format("برای نمره [{0}] نتیجه ای تعریف نشده است.", mark));
        }

        public virtual ResultLabel Apply(ExamParticipate participate)
        {
            float mark = participate.CalculateMark();
            int absences = 0;
            bool mandatoryLack = false;

            foreach (ResultLabel label in Labels)
            {
                if (label.CanApply(mark, absences, mandatoryLack))
                    return label;
            }
            throw new ArgumentOutOfRangeException(string.Format("برای نمره [{0}] نتیجه ای تعریف نشده است.", mark));
        }

        public virtual ResultProtocol Clone()
        {
            ResultProtocol protocol = Services.Clone(this);
            foreach (ResultLabel label in Labels)
            {
                ResultLabel clone = label.Clone();
                clone.ResultProtocol = protocol;
                protocol.Labels.Add(clone);
            }
            return protocol;
        }

        public static IList<ResultProtocol> GetProtocols(EducationalPeriod period)
        {
            var query = from protocol in DbContext.Entity<ResultProtocol>()
                        where protocol.Period.Id == period.Id
                        select protocol;
            return query.ToList();
        }

        public virtual ResultLabel GetItem(string name)
        {
            var query = from item in Labels
                        where item.Name == name
                        select item;
            return query.FirstOrDefault();
        }
    }
}