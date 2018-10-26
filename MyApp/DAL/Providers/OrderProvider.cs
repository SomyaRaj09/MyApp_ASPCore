using CommonLib.Core;
using CommonLib.Library;
using CommonLib.Models;
using DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Providers
{
    public class OrderProvider
    {
        public OrderHandler handler = new OrderHandler();

        /// <summary>
        /// Provider for api to save order data
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> Order_Save(OrderModel req)
        {
            SimpleResponse response = new SimpleResponse();
            
            response = ValidateOrderSave(response, req);
            if (response.HasError)
                return response;
            return await handler.Order_Save(req);
        }

        /// <summary>
        /// Method to check the validation while saving the order
        /// </summary>
        /// <param name="response"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        private SimpleResponse ValidateOrderSave(SimpleResponse response, OrderModel req)
        {
            //bool isNumeric = int.TryParse("123", out n);
            if (string.IsNullOrEmpty(req.CurrencyCode))
                response.SetError(ErrorCodes.CURRENCY_CODE_Required);

            if (req.CustomerId == 0)
                response.SetError(ErrorCodes.CustomerId_Required);

            if (req.ShippingCost <= 0)
                response.SetError(ErrorCodes.ShippingCost_Required);

            if (string.IsNullOrEmpty(req.ShippingMethodCode))
                response.SetError(ErrorCodes.ShippingMethodCode_Required);

            if (req.Taxes <= 0)
                response.SetError(ErrorCodes.Taxes_Required);

            if (req.OrderDate == DateTime.MinValue || req.OrderDate == DateTime.MaxValue)
                response.SetError(ErrorCodes.INVALID_ORDER_DATE);
            //try
            //{
            //    DateTime dt = DateTime.Parse(req.DateofBirth);
            //}
            //catch
            //{
            //    response.SetError(ErrorCodes.DOB_Required);
            //}
            if (req.OrderItemList == null || req.OrderItemList.Count == 0)
            {
                response.SetError(ErrorCodes.ADDRESS_Required);
            }
            else
            {
                foreach (OrderItem orderItem in req.OrderItemList)
                {
                    if (string.IsNullOrEmpty(orderItem.ItemCode))
                        response.SetError(ErrorCodes.ITEM_CODE_Required);

                    if (string.IsNullOrEmpty(orderItem.ItemName))
                        response.SetError(ErrorCodes.ITEM_NAME_Required);

                    if (orderItem.Price <= 0)
                        response.SetError(ErrorCodes.PRICE_Required);

                    if (orderItem.Quantity <= 0)
                        response.SetError(ErrorCodes.QUANTITY_Required);
                }
            }
            return response;
        }

        /// <summary>
        /// Provider for api to search order 
        /// </summary>
        /// <returns></returns>
        public async Task<ListResponse> Order_Search(OrderSearch req)
        {
            return await handler.Order_Search(req);
        }

        /// <summary>
        /// Provider to delete order data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> Order_Delete(int id)
        {
            return await handler.Order_Delete(id);
        }
    }
}
