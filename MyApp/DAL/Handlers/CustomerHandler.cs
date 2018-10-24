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
        public async Task<BaseResponse<bool>> CreateCustomer(CustomerModel model)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            using (IDbConnection con = await CreateConnectionAsync())
            {
                DynamicParameters parm = new DynamicParameters();
                AutoGenerateInputParams(parm, model);

                await con.ExecuteAsync("[dbo].[Customer_Update]",parm,commandType:CommandType.StoredProcedure);



                result.IsSuccess = true;
                result.Result = true;

            }

           return result;
        }
    }
}
