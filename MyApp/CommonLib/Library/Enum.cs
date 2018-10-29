using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace CommonLib.Library
{
    // <copyright file="Enum.cs" company="Fuse Forward">
    // Copyright (c) 2018 All Rights Reserved
    // </copyright>
    // <author>Somya Raj</author>
    // <date>28/10/2018 01:30:00 PM </date>
    // <summary>Class representing all the enums used in application and any related methods</summary>

    public static class EnumHelper
    {
        /// <summary>
        /// Get the DisplayName from the Enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDisplayName<TEnum>(this TEnum value)
        {
            Type enumType = value.GetType();
            if (!enumType.GetTypeInfo().IsEnum)
                return "";

            string enumValue = Enum.GetName(enumType, value);
            MemberInfo member = enumType.GetMember(enumValue)[0];

            string outString = enumValue;


            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false).ToList();
            if (attrs.Count > 0)
            {
                outString = ((DisplayAttribute)attrs[0]).Name;

                if (((DisplayAttribute)attrs[0]).ResourceType != null)
                {
                    outString = ((DisplayAttribute)attrs[0]).GetName();
                }
            }
            return outString;
        }
    }

    [Flags]
    public enum SQLParamPlaces
    {
        Default = Reader | Writer,
        None = 2,
        Reader = 4,
        Writer = 8
    }
}
