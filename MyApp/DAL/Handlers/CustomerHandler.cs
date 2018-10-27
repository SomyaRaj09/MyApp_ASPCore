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

            //Check for duplicacy for name
            int duplicateCount = 0;

            int CustomerId = 0;
            using (SqlConnection con = await CreateConnectionAsync())
            {
                duplicateCount = await con.ExecuteScalarAsync<int>($"Select count(*) from dbo.Customers where FirstName = '{ req.FirstName }' " +
                                                                   $"and LastName = '{ req.LastName }' and CustomerId <> { req.CustomerId }");
                if (duplicateCount > 0)
                {
                    result.SetError(ErrorCodes.CUSTOMER_NAME_Duplicate);
                    result.Result = false;
                    return result;
                }
                using (var trans = con.BeginTransaction())
                {
                    //Insert data into Customer table and get id in return
                    CustomerId = await con.ExecuteScalarAsync<int>("[dbo].[Customer_Save]", param, transaction: trans, commandType: CommandType.StoredProcedure);

                    //Now make a loop on address list and save in DB
                    foreach (CustomerAddress customerAddress in req.CustomerAddressList)
                    {
                        customerAddress.CustomerId = CustomerId;
                        DynamicParameters addressparam = new DynamicParameters();
                        AutoGenerateInputParams(addressparam, customerAddress);
                        await con.ExecuteAsync("[dbo].[CustomerAddress_Save]", addressparam, transaction: trans, commandType: CommandType.StoredProcedure);
                    }
                    //Now make a loop on billing info list and save in DB
                    foreach (CustomerBillingInfo customerBillingInfo in req.CustomerBillingInfoList)
                    {
                        customerBillingInfo.CustomerId = CustomerId;
                        DynamicParameters billInfoparam = new DynamicParameters();
                        AutoGenerateInputParams(billInfoparam, customerBillingInfo);
                        await con.ExecuteAsync("[dbo].[BillingInfo_Save]", billInfoparam, transaction: trans, commandType: CommandType.StoredProcedure);
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
        public async Task<ListResponse> Customer_Search(CustomerSearch req)
        {
            ListResponse response = new ListResponse();
            
            List<CustomerModel> lstCustomer = new List<CustomerModel>();
            List<CustomerAddress> lstAddres = new List<CustomerAddress>();
            List<CustomerBillingInfo> lstBillingInfo = new List<CustomerBillingInfo>();

            DynamicParameters param = new DynamicParameters();
            if (req != null)
            {
                AutoGenerateInputParams(param, req);
                req.GenerateSQLParams(param);
            }
            
            using (SqlConnection con = await CreateConnectionAsync())
            {
                GridReader reader = await con.QueryMultipleAsync("dbo.Customers_GetAll", param, commandType: System.Data.CommandType.StoredProcedure);
                lstCustomer = (await reader.ReadAsync<CustomerModel>()).AsList<CustomerModel>();
                lstAddres = (await reader.ReadAsync<CustomerAddress>()).AsList<CustomerAddress>();
                lstBillingInfo = (await reader.ReadAsync<CustomerBillingInfo>()).AsList<CustomerBillingInfo>();
            }
            
            foreach (CustomerModel customer in lstCustomer)
            {
                customer.CustomerAddressList = new List<CustomerAddress>();
                customer.CustomerAddressList = lstAddres.Where(adr => adr.CustomerId == customer.CustomerId).ToList();
                customer.CustomerBillingInfoList = new List<CustomerBillingInfo>();
                customer.CustomerBillingInfoList = lstBillingInfo.Where(bill => bill.CustomerId == customer.CustomerId).ToList();
            }

            response.Result = lstCustomer.AsList();
            //response.TotalRecords = ret.Count();
            return response;
        }

        /// <summary>
        /// Handler to delete customer and related data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> Customer_Delete(int id)
        {
            SimpleResponse response = new SimpleResponse();

            DynamicParameters def = new DynamicParameters();
            def.Add("CustomerId", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            
            using (SqlConnection con = await CreateConnectionAsync())
            {
                using (var trans = con.BeginTransaction())
                {
                    await con.ExecuteAsync("dbo.CustomerAddress_Delete", param: def, transaction: trans, commandType: System.Data.CommandType.StoredProcedure);
                    await con.ExecuteAsync("dbo.BillingInfo_Delete", param: def, transaction: trans, commandType: System.Data.CommandType.StoredProcedure);
                    await con.ExecuteAsync("dbo.Customer_Delete", param: def, transaction: trans, commandType: System.Data.CommandType.StoredProcedure);
                 
                    trans.Commit();
                }
                response.Result = true;
            }

            return response;
        }
    }
}
