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
using static Dapper.SqlMapper;

namespace DAL.Handlers
{
    public class CustomerHandler: BaseDAL
    {
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

        public async Task<ListResponse> Customer_Search()
        {
            ListResponse response = new ListResponse();
            IEnumerable<CustomerModel> ret = new List<CustomerModel>();

            List<CustomerLookup> lstCustomerLookup = new List<CustomerLookup>();
            List<AddressLookup> lstAddresLookup = new List<AddressLookup>();
            using (SqlConnection con = await CreateConnectionAsync())
            {
                GridReader reader = await con.QueryMultipleAsync("dbo.Customers_GetAll", commandType: System.Data.CommandType.StoredProcedure);
                lstCustomerLookup = (await reader.ReadAsync<CustomerLookup>()).AsList<CustomerLookup>();
                lstAddresLookup = (await reader.ReadAsync<AddressLookup>()).AsList<AddressLookup>();
            }

            List<CustomerModel> lstCustomerModel = new List<CustomerModel>();
            foreach (CustomerLookup customerLookup in lstCustomerLookup)
            {
                CustomerModel customerModel = new CustomerModel();
                customerModel.CustomerId = customerLookup.CustomerId;
                customerModel.DateofBirth = customerLookup.DateofBirth;
                customerModel.FirstName = customerLookup.FirstName;
                customerModel.Gender = customerLookup.Gender;

            }

            response.Result = ret.AsList();
            //response.TotalRecords = ret.Count();
            return response;
        }
    }
}
