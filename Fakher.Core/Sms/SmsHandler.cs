using System;
using System.Collections.Generic;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using System.Web;
using Fakher.Core.DomainModel.Order;
using NHibernate;
using rComponents;

namespace Fakher.Core.SMS
{
    public static class SmsHandler
    {
        public static string RequestTemplate = "RequestSmsTemplate";
    }
}