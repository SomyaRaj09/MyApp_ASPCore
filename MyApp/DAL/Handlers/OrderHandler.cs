using CommonLib.Core;
using CommonLib.Models;
using DAL.Library;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Handlers
{
    public class OrderHandler : BaseDAL
    {
        public async Task<SimpleResponse> Order_Save(OrderModel req)
        {
            SimpleResponse result = new SimpleResponse();
            DynamicParameters param = new DynamicParameters();
            AutoGenerateInputParams(param, req);

            int OrderNumber = 0;
            using (SqlConnection con = await CreateConnectionAsync())
            {
                using (var trans = con.BeginTransaction())
                {
                    //Insert data into Customer table and get id in return
                    OrderNumber = await con.ExecuteScalarAsync<int>("[dbo].[Order_Save]", param, transaction: trans, commandType: CommandType.StoredProcedure);

                    //Now make a loop on address list and insert in DB
                    foreach (OrderItem orderItem in req.OrderItemList)
                    {
                        orderItem.OrderNumber = OrderNumber;
                        DynamicParameters OrderItemparam = new DynamicParameters();
                        AutoGenerateInputParams(OrderItemparam, orderItem);
                        await con.ExecuteAsync("[dbo].[OrderItem_Save]", OrderItemparam, transaction: trans, commandType: CommandType.StoredProcedure);
                    }
                    trans.Commit();
                }
                result.Result = true;
            }

            return result;
        }
    }
}
