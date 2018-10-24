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

namespace DAL.Handlers
{
    public class CustomerHandler: BaseDAL
    {
        public async Task<BaseResponse<bool>> Customer_Save(CustomerModel model)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            using (IDbConnection con = await CreateConnectionAsync())
            {
                DynamicParameters param = new DynamicParameters();

                AutoGenerateInputParams(param, model);
                
                //Insert data into Customer table and get id in return
                await con.ExecuteAsync("[dbo].[Customer_Save]", param, commandType:CommandType.StoredProcedure);

                //Now make a loop on address list and insert in DB
                foreach (CustomerAddress customerAddress in model.CustomerAddressList)
                {
                    await con.ExecuteAsync("[dbo].[CustomerAddress_Save]", param, commandType: CommandType.StoredProcedure);
                }

                result.IsSuccess = true;
                result.Result = true;
            }

           return result;
        }
    }
}
