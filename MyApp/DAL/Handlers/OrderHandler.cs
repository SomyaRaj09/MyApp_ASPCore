﻿using CommonLib.Core;
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
    public class OrderHandler : BaseDAL
    {
        /// <summary>
        /// Handler to save order data
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> Order_Save(OrderModel req)
        {
            SimpleResponse result = new SimpleResponse();
            
            int OrderNumber = 0;
            float orderTotal = req.OrderItemList.Sum(item => (item.Price * item.Quantity));
            req.OrderTotal = orderTotal;
            DynamicParameters param = new DynamicParameters();
            AutoGenerateInputParams(param, req);

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

        /// <summary>
        /// Handler to search order data
        /// </summary>
        /// <returns></returns>
        public async Task<ListResponse> Order_Search(OrderSearch req)
        {
            ListResponse response = new ListResponse();
            
            List<OrderModel> lstOrder = new List<OrderModel>();
            List<OrderItem> lstOrderItem = new List<OrderItem>();

            DynamicParameters param = new DynamicParameters();
            if (req != null)
                AutoGenerateInputParams(param, req);
            
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
