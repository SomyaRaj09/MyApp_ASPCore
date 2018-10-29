using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLib.Library
{
    // <copyright file="ErrorCodes.cs" company="Fuse Forward">
    // Copyright (c) 2018 All Rights Reserved
    // </copyright>
    // <author>Somya Raj</author>
    // <date>29/10/2018 02:00:00 PM </date>
    // <summary>Class representing all error codes used in application</summary>

    public enum ErrorCodes
    {
        [Display(Name = "ERR_NO_ERROR")]
        NoError = 0,

        [Display(Name = "INVALID_PAGE_NO_Required")]
        INVALID_PAGE_NO_Required = 1,

        [Display(Name = "INVALID_PAGE_SIZE_Required")]
        INVALID_PAGE_SIZE_Required = 2,

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

        [Display(Name = "BILLING_INFO_REQUIRED")]
        BILLING_INFO_Required = 1014,

        [Display(Name = "CARD_HOLDER_NAME_REQUIRED")]
        CARD_HOLDER_NAME_Required = 1015,

        [Display(Name = "CARD_NUMBER_REQUIRED")]
        CARD_NUMBER_Required = 1016,

        [Display(Name = "CARD_TYPE_REQUIRED")]
        CARD_TYPE_Required = 1017,

        [Display(Name = "CVV_REQUIRED")]
        CVV_Required = 1018,

        [Display(Name = "EITHER_BILLING_OR_SHIPPING_FLAG_REQUIRED")]
        EITHER_BILLING_OR_SHIPPING_FLAG_Required = 1019,

        [Display(Name = "INVALID_DATE_OF_BIRTH")]
        INVALID_DATE_OF_BIRTH = 1020,

        [Display(Name = "INVALID_EXPIRY_DATE")]
        INVALID_EXPIRY_DATE = 1021,

        [Display(Name = "CUSTOMER_NAME_DUPLICATE")]
        CUSTOMER_NAME_Duplicate = 1022,


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
        QUANTITY_Required = 2008,

        [Display(Name = "INVALID_ORDER_DATE")]
        INVALID_ORDER_DATE = 2009
    }
}
