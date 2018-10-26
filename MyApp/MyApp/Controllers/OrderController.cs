using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLib.Core;
using CommonLib.Models;
using DAL.Providers;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderProvider prov = new OrderProvider();

        /// <summary>
        /// API to save order data
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<SimpleResponse> Order_Save(OrderModel req)
        {
            return await prov.Order_Save(req);
        }

        /// <summary>
        ///  API to update order data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<SimpleResponse> Order_Update(int id, [FromBody]OrderModel req)
        {
            req.OrderNumber = id;
            return await prov.Order_Save(req);
        }

        /// <summary>
        /// API to search order data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResponse> Order_SearchAll()
        {
            return await prov.Order_Search(null);
        }

        /// <summary>
        /// API to search paginated order data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResponse> Order_SearchPaginated(int PageNumber, int PageSize) //OrderSearch req)
        {
            OrderSearch req = new OrderSearch();
            req.PageNumber = PageNumber;
            req.PageSize = PageSize;
            return await prov.Order_Search(req);
        }

        /// <summary>
        /// API to delete customer data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<SimpleResponse> Order_Delete(int id)
        {
            return await prov.Order_Delete(id);
        }
    }
}