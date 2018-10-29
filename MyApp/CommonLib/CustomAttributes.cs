using CommonLib.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib
{
    // <copyright file="CustomAttributes.cs" company="Fuse Forward">
    // Copyright (c) 2018 All Rights Reserved
    // </copyright>
    // <author>Somya Raj</author>
    // <date>27/10/2018 01:00:00 PM </date>
    // <summary>Class representing custom attributes i.e. used in dapper</summary>

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
