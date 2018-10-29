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
using static Dapper.SqlMapper;
using System.Linq;

namespace DAL.Handlers
{
    // <copyright file="OrderHanlder.cs" company="Fuse Forward">
    // Copyright (c) 2018 All Rights Reserved
    // </copyright>
    // <author>Somya Raj</author>
    // <date>21/10/2018 10:23:00 AM </date>
    // <summary>Order handler class returning order related data for APIs from database</summary>

    public class OrderHandler : BaseDAL
    {
        /// <summary>
        /// Handler to save order data
        /// </summary>
        /// <param name="orderModel"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> Order_Save(OrderModel orderModel)
        {
            SimpleResponse result = new SimpleResponse();
            
            int OrderNumber = 0;
            float orderTotal = orderModel.OrderItemList.Sum(item => (item.Price * item.Quantity));
            orderModel.OrderTotal = orderTotal;
            DynamicParameters param = new DynamicParameters();
            AutoGenerateInputParams(param, orderModel);

            using (SqlConnection con = await CreateConnectionAsync())
            {
                using (var trans = con.BeginTransaction())
                {
                    //Insert data into Customer table and get id in return
                    OrderNumber = await con.ExecuteScalarAsync<int>("[dbo].[Order_Save]", param, transaction: trans, commandType: CommandType.StoredProcedure);

                    //Now make a loop on address list and insert in DB
                    foreach (OrderItem orderItem in orderModel.OrderItemList)
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

        /// <summary>
        /// Handler to search order data
        /// </summary>
        /// <returns></returns>
        public async Task<ListResponse> Order_Search(OrderSearch orderSearch)
        {
            ListResponse response = new ListResponse();
            
            List<OrderModel> lstOrder = new List<OrderModel>();
            List<OrderItem> lstOrderItem = new List<OrderItem>();

            DynamicParameters param = new DynamicParameters();
            if (orderSearch != null)
            {
                AutoGenerateInputParams(param, orderSearch);
                orderSearch.GenerateSQLParams(param);
            }
            
            using (SqlConnection con = await CreateConnectionAsync())
            {
                GridReader reader = await con.QueryMultipleAsync("dbo.Orders_GetAll", param, commandType: System.Data.CommandType.StoredProcedure);
                lstOrder = (await reader.ReadAsync<OrderModel>()).AsList<OrderModel>();
                lstOrderItem = (await reader.ReadAsync<OrderItem>()).AsList<OrderItem>();
            }

            foreach (OrderModel order in lstOrder)
            {
                order.OrderItemList = new List<OrderItem>();
                order.OrderItemList = lstOrderItem.Where(ord => ord.OrderNumber == order.OrderNumber).ToList();                
            }

            response.Result = lstOrder.AsList();
            //response.TotalRecords = ret.Count();
            return response;
        }

        /// <summary>
        /// Handler to delete order and related data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> Order_Delete(int id)
        {
            SimpleResponse response = new SimpleResponse();

            DynamicParameters def = new DynamicParameters();
            def.Add("OrderNumber", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using (SqlConnection con = await CreateConnectionAsync())
            {
                using (var trans = con.BeginTransaction())
                {
                    await con.ExecuteAsync("dbo.OrderItem_Delete", param: def, transaction: trans, commandType: System.Data.CommandType.StoredProcedure);
                    await con.ExecuteAsync("dbo.Order_Delete", param: def, transaction: trans, commandType: System.Data.CommandType.StoredProcedure);
                    response.Result = true;
                }
            }

            return response;
        }
    }
}
