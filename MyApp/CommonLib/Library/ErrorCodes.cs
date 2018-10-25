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
        INVALID_GENDER = 1013,

        [Display(Name = "CUSTOMERID_REQUIRED")]
        CustomerId_Required = 2000,

        [Display(Name = "CURRENCY_CODE_REQUIRED")]
        CURRENCY_CODE_Required = 2001,

        [Display(Name = "SHIPPING_COST_REQUIRED")]
        ShippingCost_Required = 2002,

        [Display(Name = "SHIPPING_METHOD_CODE_REQUIRED")]
        ShippingMethodCode_Required = 2003,

        [Display(Name = "TAXES_REQUIRED")]
        Taxes_Required = 2004,

        [Display(Name = "ITEM_CODE_REQUIRED")]
        ITEM_CODE_Required = 2005,

        [Display(Name = "ITEM_NAME_REQUIRED")]
        ITEM_NAME_Required = 2006,

        [Display(Name = "PRICE_REQUIRED")]
        PRICE_Required = 2007,

        [Display(Name = "QUANTITY_REQUIRED")]
        QUANTITY_Required = 2008
    }
}
