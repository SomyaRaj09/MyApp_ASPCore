﻿using CommonLib.Core;
using CommonLib.Models;
using DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Providers
{
    public class CustomerProvider
    {
        public CustomerHandler handler = new CustomerHandler();
        public async Task<BaseResponse<bool>> Customer_Save(CustomerModel model)
        {
            return await handler.Customer_Save(model);
        }
    }
}
