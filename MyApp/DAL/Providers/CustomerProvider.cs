using CommonLib.Core;
using CommonLib.Library;
using CommonLib.Models;
using DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Providers
{
    public class CustomerProvider
    {
        public CustomerHandler handler = new CustomerHandler();

        /// <summary>
        /// Provider for api to save customer data
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> Customer_Save(CustomerModel req)
        {
            SimpleResponse response = new SimpleResponse();
            //Transform_CustomerSaveObject(req);

            response = ValidateCustomerSave(response, req);
            if (response.HasError)
                return response;
            return await handler.Customer_Save(req);
        }

        private static void Transform_CustomerSaveObject(CustomerModel model)
        {
            //if (req.RecurrencePattern != RecurrencePatterns.Monthly)
            //{
            //    req.RegisteredAtEndOfMonth = false;
            //}
            //if (req.EndPattern != RecurrencePatterns_End.EndBy)
            //{
            //    req.EndDateTime = null;
            //}
            //if (req.RecurrencePattern == RecurrencePatterns.Daily || req.RecurrencePattern == RecurrencePatterns.Hourly)
            //{
            //    if (req.RecurrenceFrequency.HasValue)
            //    {
            //        req.Dow = req.RecurrenceFrequency.ToString();
            //    }
            //}
            //if (req.EndPattern != RecurrencePatterns_End.EndsAfter)
            //{
            //    req.MaxRecurrence = 0;
            //}
        }

        /// <summary>
        /// Method to validate data while saving customer data
        /// </summary>
        /// <param name="response"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        private SimpleResponse ValidateCustomerSave(SimpleResponse response, CustomerModel req)
        {
            if (string.IsNullOrEmpty(req.Title))
            {
                response.SetError(ErrorCodes.TITLE_Required);
            }
            if (string.IsNullOrEmpty(req.FirstName))
            {
                response.SetError(ErrorCodes.FIRST_NAME_Required);
            }
            if (string.IsNullOrEmpty(req.LastName))
            {
                response.SetError(ErrorCodes.LAST_NAME_Required);
            }
            if (string.IsNullOrEmpty(req.Gender))
            {
                response.SetError(ErrorCodes.GENDER_Required);
            }
            else
            {
                if (req.Gender.Trim().ToUpper() != Customer_Gender.MALE && req.Gender.Trim().ToUpper() != Customer_Gender.FEMALE)
                {
                    response.SetError(ErrorCodes.INVALID_GENDER);
                }
            }
            //try
            //{
            //    DateTime dt = DateTime.Parse(req.DateofBirth);
            //}
            //catch
            //{
            //    response.SetError(ErrorCodes.DOB_Required);
            //}
            if (req.CustomerAddressList == null || req.CustomerAddressList.Count == 0)
            {
                response.SetError(ErrorCodes.ADDRESS_Required);
            }
            else
            {
                //Check if there is no IsBilling flag i.e true
                //Check if there is no IsShipping flag i.e true
                foreach (CustomerAddress customerAddress in req.CustomerAddressList)
                {
                    if (string.IsNullOrEmpty(customerAddress.Address1))
                    {
                        response.SetError(ErrorCodes.ADDRESS1_Required);
                    }
                    if (string.IsNullOrEmpty(customerAddress.Address2))
                    {
                        response.SetError(ErrorCodes.ADDRESS2_Required);
                    }
                    if (string.IsNullOrEmpty(customerAddress.City))
                    {
                        response.SetError(ErrorCodes.CITY_Required);
                    }
                    if (string.IsNullOrEmpty(customerAddress.Country))
                    {
                        response.SetError(ErrorCodes.COUNTRY_Required);
                    }
                    if (string.IsNullOrEmpty(customerAddress.PostalCode))
                    {
                        response.SetError(ErrorCodes.POSTAL_CODE_Required);
                    }
                    if (string.IsNullOrEmpty(customerAddress.State))
                    {
                        response.SetError(ErrorCodes.STATE_Required);
                    }
                }
            }
            return response;
        }

        /// <summary>
        /// Provider for api to search guest data
        /// </summary>
        /// <returns></returns>
        public async Task<ListResponse> Customer_Search()
        {
            return await handler.Customer_Search();
        }
    }
}
