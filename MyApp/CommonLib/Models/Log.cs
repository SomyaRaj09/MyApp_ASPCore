using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Models
{
    public class Log
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public string LoggingLevel { get; set; }
        public string SessionID { get; set; }
        public int? StaffID { get; set; }
        public string ApplicationIdentifier { get; set; }
        public string IpAddress { get; set; }
        public string Url { get; set; }
        public string ReferrerUrl { get; set; }
        public string Headers { get; set; }
        public string MoreInfo { get; set; }
    }
}
