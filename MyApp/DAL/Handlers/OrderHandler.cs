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

        /// <summary>
        /// Handler to search order data
        /// </summary>
        /// <returns></returns>
        public async Task<ListResponse> Order_Search()
        {
            ListResponse response = new ListResponse();
            List<OrderModel> ret = new List<OrderModel>();

            List<OrderLookup> lstOrderLookup = new List<OrderLookup>();
            List<OrderItem> lstOrderItem = new List<OrderItem>();
            using (SqlConnection con = await CreateConnectionAsync())
            {
                GridReader reader = await con.QueryMultipleAsync("dbo.Order_GetAll", commandType: System.Data.CommandType.StoredProcedure);
                lstOrderLookup = (await reader.ReadAsync<OrderLookup>()).AsList<OrderLookup>();
                lstOrderItem = (await reader.ReadAsync<OrderItem>()).AsList<OrderItem>();
            }

            foreach (OrderLookup orderLookup in lstOrderLookup)
            {
                OrderModel orderModel = new OrderModel();
                orderModel.CouponCode = orderLookup.CouponCode;
                orderModel.CurrencyCode = orderLookup.CurrencyCode;
                orderModel.CustomerId = orderLookup.CustomerId;
                orderModel.DiscountAmount = orderLookup.DiscountAmount;
                orderModel.OrderDate = orderLookup.OrderDate;
                orderModel.OrderNumber = orderLookup.OrderNumber;
                orderModel.OrderTotal = orderLookup.OrderTotal;
                orderModel.ShippingCost = orderLookup.ShippingCost;
                orderModel.ShippingMethodCode = orderLookup.ShippingMethodCode;
                orderModel.Taxes = orderLookup.Taxes;
                orderModel.OrderItemList = new List<OrderItem>();
                var orderItem = lstOrderItem.Where(ord => ord.OrderNumber == orderLookup.OrderNumber);
                orderModel.OrderItemList = orderItem.ToList();

                ret.Add(orderModel);
            }

            response.Result = ret.AsList();
            //response.TotalRecords = ret.Count();
            return response;
        }
    }
}
