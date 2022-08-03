using System;
namespace Fakher.Core.DomainModel
{
    public class PayException : Exception
    {
        public string RawCode { get; set; }
        public ResultCode ResultCode { get; set; }
    }
}