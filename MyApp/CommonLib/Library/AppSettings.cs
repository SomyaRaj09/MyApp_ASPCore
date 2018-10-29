using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Library
{
    public static class AppSettings
    {
        public static string ConnectionString { get; set; }
        public static string MainDBConnectionString
        {
            get
            {
                return ConnectionString;
            }
        }
    }
}
