using CommonLib.Core;
using CommonLib.Models;
using DAL.Providers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    // <copyright file="OrderController.cs" company="Fuse Forward">
    // Copyright (c) 2018 All Rights Reserved
    // </copyright>
    // <author>Somya Raj</author>
    // <date>21/10/2018 10:23:00 AM </date>
    // <summary>Order controller class representing order related APIs</summary>

    [Route("[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderProvider _orderProvider = new OrderProvider();

        /// <summary>
        /// API to save order data
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<SimpleResponse> Order_Save(OrderModel orderModel)
        {
            return await _orderProvider.Order_Save(orderModel);
        }

        /// <summary>
        ///  API to update order data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<SimpleResponse> Order_Update(int id, [FromBody]OrderModel orderModel)
        {
            orderModel.OrderNumber = id;
            return await _orderProvider.Order_Save(orderModel);
        }

        /// <summary>
        /// API to search order data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResponse> Order_SearchAll()
        {
            return await _orderProvider.Order_Search(null);
        }

        /// <summary>
        /// API to search paginated order data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResponse> Order_SearchPaginated(int PageNumber, int PageSize) //OrderSearch req)
        {
            OrderSearch orderSearch = new OrderSearch();
            orderSearch.PageNumber = PageNumber;
            orderSearch.PageSize = PageSize;
            return await _orderProvider.Order_Search(orderSearch);
        }

        /// <summary>
        /// API to search order data (On order number or order date or shipping method) 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ListResponse> Order_Search(OrderSearch orderSearch)
        {
            return await _orderProvider.Order_Search(orderSearch);
        }
        
        /// <summary>
        /// API to delete customer data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<SimpleResponse> Order_Delete(int id)
        {
            return await _orderProvider.Order_Delete(id);
        }
    }
}