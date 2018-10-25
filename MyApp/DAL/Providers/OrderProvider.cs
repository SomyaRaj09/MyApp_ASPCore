using CommonLib.Core;
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
        public async Task<SimpleResponse> Order_Save(OrderModel req)
        {
            return await handler.Order_Save(req);
        }
    }
}
