using CommonLib.Core;
using CommonLib.Models;
using DAL.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    // <copyright file="CustomerController.cs" company="Fuse Forward">
    // Copyright (c) 2018 All Rights Reserved
    // </copyright>
    // <author>Somya Raj</author>
    // <date>21/10/2018 10:23:00 AM </date>
    // <summary>Customer controller class representing customer related APIs</summary>

    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerProvider _customerProvider = new CustomerProvider();
        
        /// <summary>
        /// API to save customer data
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<SimpleResponse> Customer_Save(CustomerModel customerModel)
        {
            return await _customerProvider.Customer_Save(customerModel);
        }

        /// <summary>
        /// API to update customer data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<SimpleResponse> Customer_Update(int id, [FromBody]CustomerModel customerModel)
        {
            customerModel.CustomerId = id;
            return await _customerProvider.Customer_Save(customerModel);
        }

        /// <summary>
        /// API to search customer data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResponse> Customer_SearchAll()
        {
            
            return await _customerProvider.Customer_Search(null);
        }

        /// <summary>
        /// API to search paginated customer data 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResponse> Customer_SearchPaginated(int PageNumber, int PageSize) //CustomerSearch req)
        {
            CustomerSearch customerSearch = new CustomerSearch();
            customerSearch.PageNumber = PageNumber;
            customerSearch.PageSize = PageSize;
            return await _customerProvider.Customer_Search(customerSearch);
        }

        /// <summary>
        /// API to search customer data (On first name or last name) 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ListResponse> Cusotmer_Search(CustomerSearch customerSearch)
        {
            return await _customerProvider.Customer_Search(customerSearch);
        }

        /// <summary>
        /// API to delete customer data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<SimpleResponse> Customer_Delete(int id)
        {
            return await _customerProvider.Customer_Delete(id);
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
