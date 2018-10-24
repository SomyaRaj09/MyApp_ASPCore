using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Library
{
    public static class AppSettings
    {
        //private static IConfiguration _Configuration;

        public static string ConnectionString { get; set; }
        public static string MainDBConnectionString
        {
            get
            {
                //return config["MainDBConnectionString"];
                return ConnectionString;
            }
        }
        public enum SQLParamPlaces
        {
            Default = Reader | Writer,
            None = 2,
            Reader = 4,
            Writer = 8
        }
    }
}
