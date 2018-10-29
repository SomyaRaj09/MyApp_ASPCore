using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Library
{
    // <copyright file="AppSettings.cs" company="Fuse Forward">
    // Copyright (c) 2018 All Rights Reserved
    // </copyright>
    // <author>Somya Raj</author>
    // <date>29/10/2018 11:00:00 AM </date>
    // <summary>Class representing common methods (DB connection string etc.)</summary>

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
