using CommonLib.Core;
using CommonLib.Library;
using CommonLib.Models;
using DAL.Handlers;
using System;
using System.Threading.Tasks;

namespace DAL.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerProvider
    {
        private CustomerHandler _customerHandler = new CustomerHandler();

        /// <summary>
        /// Provider for api to save customer data
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> Customer_Save(CustomerModel customerModel)
        {
            SimpleResponse simpleResponse = new SimpleResponse();
            //Transform_CustomerSaveObject(req);            
            simpleResponse = ValidateCustomerSave(simpleResponse, customerModel);
            if (simpleResponse.HasError)
            {
                return simpleResponse;
            }

            return await _customerHandler.Customer_Save(customerModel);
        }

       
        /// <summary>
        /// Method to validate data while saving customer data
        /// </summary>
        /// <param name="simpleResponse"></param>
        /// <param name="customerModel"></param>
        /// <returns></returns>
        private SimpleResponse ValidateCustomerSave(SimpleResponse simpleResponse, CustomerModel customerModel)

        {
            if (string.IsNullOrEmpty(customerModel.Title))
            {
                simpleResponse.SetError(ErrorCodes.TITLE_Required);
            }

            if (string.IsNullOrEmpty(customerModel.FirstName))
            {
                simpleResponse.SetError(ErrorCodes.FIRST_NAME_Required);
            }

            if (string.IsNullOrEmpty(customerModel.LastName))
            {
                simpleResponse.SetError(ErrorCodes.LAST_NAME_Required);
            }

            if (string.IsNullOrEmpty(customerModel.Gender))
            {
                simpleResponse.SetError(ErrorCodes.GENDER_Required);
            }
            else
            {
                if (customerModel.Gender.Trim().ToUpper() != Customer_Gender.MALE && customerModel.Gender.Trim().ToUpper() != Customer_Gender.FEMALE)
                {
                    simpleResponse.SetError(ErrorCodes.INVALID_GENDER);
                }
            }

            if (customerModel.DateofBirth == DateTime.MinValue || customerModel.DateofBirth == DateTime.MaxValue)
            {
                simpleResponse.SetError(ErrorCodes.INVALID_DATE_OF_BIRTH);
            }
            //try
            //{
            //    DateTime dt = DateTime.Parse(req.DateofBirth);
            //}
            //catch
            //{
            //    response.SetError(ErrorCodes.DOB_Required);
            //}
            if (customerModel.CustomerAddressList == null || customerModel.CustomerAddressList.Count == 0)
            {
                simpleResponse.SetError(ErrorCodes.ADDRESS_Required);
            }
            else
            {
                //Check if there is no IsBilling flag i.e true
                //Check if there is no IsShipping flag i.e true
                foreach (CustomerAddress customerAddress in customerModel.CustomerAddressList)
                {
                    if (string.IsNullOrEmpty(customerAddress.Address1))
                    {
                        simpleResponse.SetError(ErrorCodes.ADDRESS1_Required);
                    }

                    if (string.IsNullOrEmpty(customerAddress.Address2))
                    {
                        simpleResponse.SetError(ErrorCodes.ADDRESS2_Required);
                    }

                    if (string.IsNullOrEmpty(customerAddress.City))
                    {
                        simpleResponse.SetError(ErrorCodes.CITY_Required);
                    }

                    if (string.IsNullOrEmpty(customerAddress.Country))
                    {
                        simpleResponse.SetError(ErrorCodes.COUNTRY_Required);
                    }

                    if (string.IsNullOrEmpty(customerAddress.PostalCode))
                    {
                        simpleResponse.SetError(ErrorCodes.POSTAL_CODE_Required);
                    }

                    if (string.IsNullOrEmpty(customerAddress.State))
                    {
                        simpleResponse.SetError(ErrorCodes.STATE_Required);
                    }

                    if (!customerAddress.IsBilling && !customerAddress.IsShipping)
                    {
                        simpleResponse.SetError(ErrorCodes.EITHER_BILLING_OR_SHIPPING_FLAG_Required);
                    }
                }
            }
            if (customerModel.CustomerBillingInfoList == null || customerModel.CustomerBillingInfoList.Count == 0)
            {
                simpleResponse.SetError(ErrorCodes.BILLING_INFO_Required);
            }
            else
            {
                foreach (CustomerBillingInfo billInfo in customerModel.CustomerBillingInfoList)
                {
                    if (string.IsNullOrEmpty(billInfo.CardholderName))
                    {
                        simpleResponse.SetError(ErrorCodes.CARD_HOLDER_NAME_Required);
                    }

                    if (string.IsNullOrEmpty(billInfo.CardNumber))
                    {
                        simpleResponse.SetError(ErrorCodes.CARD_NUMBER_Required);
                    }

                    if (string.IsNullOrEmpty(billInfo.CardType))
                    {
                        simpleResponse.SetError(ErrorCodes.CARD_TYPE_Required);
                    }

                    if (string.IsNullOrEmpty(billInfo.CVV))
                    {
                        simpleResponse.SetError(ErrorCodes.CVV_Required);
                    }

                    if (billInfo.ExpiryDate == DateTime.MinValue || billInfo.ExpiryDate == DateTime.MaxValue)
                    {
                        simpleResponse.SetError(ErrorCodes.INVALID_EXPIRY_DATE);
                    }
                }
            }
            return simpleResponse;
        }

        /// <summary>
        /// Method to check the validation while fetching the customer
        /// </summary>
        /// <param name="listResponse"></param>
        /// <param name="customerSearch"></param>
        /// <returns></returns>
        private ListResponse ValidateCustomerSearch(ListResponse listResponse, CustomerSearch customerSearch)
        {

            if (customerSearch.PageNumber <= 0)
            {
                listResponse.SetError(ErrorCodes.INVALID_PAGE_NO_Required);
            }

            if (customerSearch.PageSize <= 0)
            {
                listResponse.SetError(ErrorCodes.INVALID_PAGE_SIZE_Required);
            }

            return listResponse;
        }

        /// <summary>
        /// Provider for api to search guest data
        /// </summary>
        /// <returns></returns>
        public async Task<ListResponse> Customer_Search(CustomerSearch customerSearch)
        {
            ListResponse listResponse = new ListResponse();
            if (customerSearch != null)
            {
                listResponse = ValidateCustomerSearch(listResponse, customerSearch);
                if (listResponse.HasError)
                {
                    return listResponse;
                }
            }
            return await _customerHandler.Customer_Search(customerSearch);
        }

        /// <summary>
        /// Provider to delete customer data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> Customer_Delete(int id)
        {
            return await _customerHandler.Customer_Delete(id);
        }
    }
}
