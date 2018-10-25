using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLib.Library
{
    public enum ErrorCodes
    {
        [Display(Name = "ERR_NO_ERROR")]
        NoError = 0,

        [Display(Name = "ERR_GENERIC_ERROR")]
        ValidationError = 1000,

        [Display(Name = "TITLE_REQUIRED")]
        TITLE_Required = 1001,

        [Display(Name = "FIRST_NAME_REQUIRED")]
        FIRST_NAME_Required = 1002,

        [Display(Name = "LAST_NAME_REQUIRED")]
        LAST_NAME_Required = 1003,

        [Display(Name = "GENDER_REQUIRED")]
        GENDER_Required = 1004,

        [Display(Name = "DOB_REQUIRED")]
        DOB_Required = 1005,

        [Display(Name = "ADDRESS_REQUIRED")]
        ADDRESS_Required = 1006,

        [Display(Name = "ADDRESS1_REQUIRED")]
        ADDRESS1_Required = 1007,

        [Display(Name = "ADDRESS2_REQUIRED")]
        ADDRESS2_Required = 1008,

        [Display(Name = "CITY_REQUIRED")]
        CITY_Required = 1009,

        [Display(Name = "COUNTRY_REQUIRED")]
        COUNTRY_Required = 1010,

        [Display(Name = "POSTAL_CODE_REQUIRED")]
        POSTAL_CODE_Required = 1011,

        [Display(Name = "STATE_REQUIRED")]
        STATE_Required = 1012,

        [Display(Name = "INVALID_GENDER")]
        INVALID_GENDER = 1013
    }
}
