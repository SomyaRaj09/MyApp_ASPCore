using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLib.Core;
using CommonLib.Models;
using DAL.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerProvider prov= new CustomerProvider();

        [HttpPost]
        public async Task<BaseResponse<bool>> CreateCustomer(CustomerModel model)
        {
            return await prov.CreateCustomer(model);
        }

        //// GET: api/Customer
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Customer/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Customer
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Customer/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
