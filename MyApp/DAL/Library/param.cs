using System;
using System.Collections.Generic;
using System.Text;
using static CommonLib.Library.AppSettings;

namespace DAL.Library
{
    public class CustomAttributes
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
        public class SQLParam : System.Attribute
        {
            public SQLParamPlaces Usage { get; set; } = SQLParamPlaces.Default;
            public string ReaderName { get; set; }
            public string InputParamName { get; set; }
        }
    }
}
