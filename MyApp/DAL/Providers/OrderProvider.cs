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
    /// <summary>
    /// Provider class for Order controller
    /// </summary>
    public class OrderProvider
    {
        private OrderHandler _orderHandler = new OrderHandler();

        /// <summary>
        /// Provider for api to save order data
        /// </summary>
        /// <param name="orderModel"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> Order_Save(OrderModel orderModel)
        {
            SimpleResponse simpleResponse = new SimpleResponse();
            
            simpleResponse = ValidateOrderSave(simpleResponse, orderModel);
            if (simpleResponse.HasError)
                return simpleResponse;
            return await _orderHandler.Order_Save(orderModel);
        }

        /// <summary>
        /// Method to check the validation while saving the order
        /// </summary>
        /// <param name="simpleResponse"></param>
        /// <param name="orderModel"></param>
        /// <returns></returns>
        private SimpleResponse ValidateOrderSave(SimpleResponse simpleResponse, OrderModel orderModel)
        {
            //bool isNumeric = int.TryParse("123", out n);
            if (string.IsNullOrEmpty(orderModel.CurrencyCode))
                simpleResponse.SetError(ErrorCodes.CURRENCY_CODE_Required);

            if (orderModel.CustomerId == 0)
                simpleResponse.SetError(ErrorCodes.CustomerId_Required);

            if (orderModel.ShippingCost <= 0)
                simpleResponse.SetError(ErrorCodes.ShippingCost_Required);

            if (string.IsNullOrEmpty(orderModel.ShippingMethodCode))
                simpleResponse.SetError(ErrorCodes.ShippingMethodCode_Required);

            if (orderModel.Taxes <= 0)
                simpleResponse.SetError(ErrorCodes.Taxes_Required);

            if (orderModel.OrderDate == DateTime.MinValue || orderModel.OrderDate == DateTime.MaxValue)
                simpleResponse.SetError(ErrorCodes.INVALID_ORDER_DATE);
            //try
            //{
            //    DateTime dt = DateTime.Parse(req.DateofBirth);
            //}
            //catch
            //{
            //    response.SetError(ErrorCodes.DOB_Required);
            //}
            if (orderModel.OrderItemList == null || orderModel.OrderItemList.Count == 0)
            {
                simpleResponse.SetError(ErrorCodes.ADDRESS_Required);
            }
            else
            {
                foreach (OrderItem orderItem in orderModel.OrderItemList)
                {
                    if (string.IsNullOrEmpty(orderItem.ItemCode))
                        simpleResponse.SetError(ErrorCodes.ITEM_CODE_Required);

                    if (string.IsNullOrEmpty(orderItem.ItemName))
                        simpleResponse.SetError(ErrorCodes.ITEM_NAME_Required);

                    if (orderItem.Price <= 0)
                        simpleResponse.SetError(ErrorCodes.PRICE_Required);

                    if (orderItem.Quantity <= 0)
                        simpleResponse.SetError(ErrorCodes.QUANTITY_Required);
                }
            }
            return simpleResponse;
        }
        
        /// <summary>
        /// Method to check the validation while fetching the order
        /// </summary>
        /// <param name="response"></param>
        /// <param name="orderSearch"></param>
        /// <returns></returns>
        private ListResponse ValidateOrderSearch(ListResponse listResponse, OrderSearch orderSearch)
        {
            if (orderSearch.PageNumber <= 0)
                listResponse.SetError(ErrorCodes.INVALID_PAGE_NO_Required);
            if (orderSearch.PageSize <= 0)
                listResponse.SetError(ErrorCodes.INVALID_PAGE_SIZE_Required);

            return listResponse;
        }

        /// <summary>
        /// Provider for api to search order 
        /// </summary>
        /// <returns></returns>
        public async Task<ListResponse> Order_Search(OrderSearch orderSearch)
        {
            ListResponse response = new ListResponse();

            if (orderSearch != null)
            {
                response = ValidateOrderSearch(response, orderSearch);
                if (response.HasError)
                    return response;
            }

            return await _orderHandler.Order_Search(orderSearch);
        }

        /// <summary>
        /// Provider to delete order data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> Order_Delete(int id)
        {
            return await _orderHandler.Order_Delete(id);
        }
    }
}
