using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Library
{
    // <copyright file="Contants.cs" company="Fuse Forward">
    // Copyright (c) 2018 All Rights Reserved
    // </copyright>
    // <author>Somya Raj</author>
    // <date>29/10/2018 08:30:00 AM </date>
    // <summary>Class representing all the constants used in application</summary>

    public static class Customer_Gender
    {
        public const string MALE = "MALE";
        public const string FEMALE = "FEMALE";
    }

    public static class Order_CurrencyCode
    {
        public const string USD = "USD";
        public const string CAD = "CAD";
    }

    public static class Customer_ShippingMethodCode
    {
        public const string ONE_DAY = "1DAY";
        public const string TWO_DAY = "2DAY";
        public const string GROUND = "GROUND";
    }
}
