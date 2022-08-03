using System.Linq;
using DataAccessLayer;

namespace Fakher.Core.DomainModel
{
    public class EducationalCode : DbObject
    {
        public virtual string Code { get; set; }
        [NoCascade]
        public virtual Major Major { get; set; }

        public override string ToString()
        {
            return Code;
        }

        public static EducationalCode FromCode(string code)
        {
            var query = from educationalCode in DbContext.Entity<EducationalCode>()
                        where educationalCode.Code == code
                        select educationalCode;
            return query.FirstOrDefault();
        }

        public static EducationalCode FromCode(string code, Major major)
        {
            var query = from educationalCode in DbContext.Entity<EducationalCode>()
                        where educationalCode.Code == code
                              && educationalCode.Major.Id == major.Id
                        select educationalCode;
            return query.FirstOrDefault();
        }

//        public static implicit operator string(EducationalCode code)
//        {
//            return code.Code;
//        }
    }
}