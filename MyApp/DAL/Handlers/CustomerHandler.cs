using CommonLib.Core;
using CommonLib.Library;
using CommonLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DAL.Library;
using System.Linq;
using static Dapper.SqlMapper;

namespace DAL.Handlers
{
    public class CustomerHandler: BaseDAL
    {
        /// <summary>
        /// Handler to save customer data
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> Customer_Save(CustomerModel req)
        {
            SimpleResponse result = new SimpleResponse();
            DynamicParameters param = new DynamicParameters();
            AutoGenerateInputParams(param, req);

            int CustomerId = 0;
            using (SqlConnection con = await CreateConnectionAsync())
            {
                using (var trans = con.BeginTransaction())
                {
                    //Insert data into Customer table and get id in return
                    CustomerId = await con.ExecuteScalarAsync<int>("[dbo].[Customer_Save]", param, transaction: trans, commandType: CommandType.StoredProcedure);

                    //Now make a loop on address list and insert in DB
                    foreach (CustomerAddress customerAddress in req.CustomerAddressList)
                    {
                        customerAddress.CustomerId = CustomerId;
                        DynamicParameters addressparam = new DynamicParameters();
                        AutoGenerateInputParams(addressparam, customerAddress);
                        await con.ExecuteAsync("[dbo].[CustomerAddress_Save]", addressparam, transaction: trans, commandType: CommandType.StoredProcedure);
                    }
                    trans.Commit();
                }
                result.Result = true;
            }

           return result;
        }

        /// <summary>
        /// Handler to search guest data
        /// </summary>
        /// <returns></returns>
        public async Task<ListResponse> Customer_Search()
        {
            ListResponse response = new ListResponse();
            List<CustomerModel> ret = new List<CustomerModel>();

            List<CustomerLookup> lstCustomerLookup = new List<CustomerLookup>();
            List<CustomerAddress> lstAddresLookup = new List<CustomerAddress>();
            using (SqlConnection con = await CreateConnectionAsync())
            {
                GridReader reader = await con.QueryMultipleAsync("dbo.Customers_GetAll", commandType: System.Data.CommandType.StoredProcedure);
                lstCustomerLookup = (await reader.ReadAsync<CustomerLookup>()).AsList<CustomerLookup>();
                lstAddresLookup = (await reader.ReadAsync<CustomerAddress>()).AsList<CustomerAddress>();
            }
            
            foreach (CustomerLookup customerLookup in lstCustomerLookup)
            {
                CustomerModel customerModel = new CustomerModel();
                customerModel.CustomerId = customerLookup.CustomerId;
                customerModel.DateofBirth = customerLookup.DateofBirth;
                customerModel.FirstName = customerLookup.FirstName;
                customerModel.Gender = customerLookup.Gender;
                customerModel.LastName = customerLookup.LastName;
                customerModel.Title = customerLookup.Title;
                customerModel.CustomerAddressList = new List<CustomerAddress>();
                var customerAddress = lstAddresLookup.Where(adr => adr.CustomerId == customerLookup.CustomerId);
                customerModel.CustomerAddressList = customerAddress.ToList();
                //foreach (AddressLookup addressLookup in customerAddress)
                //{
                //    customerModel.CustomerAddressList.Add(new CustomerAddress() {
                //                                                                    Address1 = addressLookup.Address1,
                //                                                                    Address2 = addressLookup.Address2,
                //                                                                    AddressId = addressLookup.AddressId,
                //                                                                    City = addressLookup.City,
                //                                                                    Country = addressLookup.Country,
                //                                                                    CustomerId = addressLookup.CustomerId,
                //                                                                    IsBilling = addressLookup.IsBilling,
                //                                                                    IsShipping = addressLookup.IsShipping,
                //                                                                    PostalCode = addressLookup.PostalCode,
                //                                                                    State = addressLookup.State
                //    });
                //}
                ret.Add(customerModel);
            }

            response.Result = ret.AsList();
            //response.TotalRecords = ret.Count();
            return response;
        }
    }
}
