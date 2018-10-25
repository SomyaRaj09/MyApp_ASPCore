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

        [HttpPost]
        public async Task<SimpleResponse> Order_Save(OrderModel req)
        {
            return await prov.Order_Save(req);
        }
    }
}