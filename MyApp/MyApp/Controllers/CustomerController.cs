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
        public CustomerProvider prov = new CustomerProvider();

        /// <summary>
        /// API to save customer data
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<SimpleResponse> Customer_Save(CustomerModel req)
        {
            return await prov.Customer_Save(req);
        }

        /// <summary>
        /// API to update customer data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<SimpleResponse> Customer_Update(int id, [FromBody]CustomerModel req)
        {
            req.CustomerId = id;
            return await prov.Customer_Save(req);
        }

        /// <summary>
        /// API to search customer data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResponse> Customer_Search()
        {
            return await prov.Customer_Search();
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
