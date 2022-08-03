using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class Certificate : FinancialEntity
    {
        public virtual string Code { get; set; }
        public virtual PersianDate RequestDate { get; set; }
        public virtual PersianDate IssueDate { get; set; }
        public virtual PersianDate DeliverDate { get; set; }
        public virtual CertificateStatus Status { get; set; }
        public virtual long Fee { get; set; }
        [NoCascade]
        public virtual Student Student { get; set; }
        [NoCascade]
        public virtual Major Major { get; set; }

        #region Overrides of FinancialEntity

        [NonPersistent]
        public override long PayableTuition
        {
            get
            {
                return Fee;
//                throw new Exception("مقدار هزینه پرداختی مشخص نیست.");
            }
        }

        [NonPersistent]
        public override FinancialHeading Heading
        {
            get { return FinancialHeading.Certificate; }
        }

        #endregion

        public Certificate()
        {
            FinancialDocument = new FinancialDocument();
            RequestDate = PersianDate.Today;
        }

        [NonPersistent]
        public virtual string StatusText
        {
            get { return Status.ToDescription(); }
        }

        public static IList<Certificate> GetCertificates(PersianDate startDate, PersianDate endDate)
        {
            var query = from certificate in DbContext.Entity<Certificate>()
                        where certificate.IssueDate >= startDate && certificate.IssueDate <= endDate
                        orderby certificate.IssueDate
                        select certificate;
            return query.ToList();
        }
    }

    public enum CertificateStatus
    {
        [EnumDescription("درخواست داده شده")]
        Requested,
        [EnumDescription("صادر شده")]
        Issued,
        [EnumDescription("تحویل داده شده")]
        Delivered,
    }
}
