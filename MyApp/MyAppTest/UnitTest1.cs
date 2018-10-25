using CommonLib.Core;
using CommonLib.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MyApp;
using MyApp.Controllers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace MyAppTest
{
    public class UnitTest1
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UnitTest1()
        {
            //string[] args = new string[0];
            //CreateWebHostBuilder(args).Build().Run();
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               // .UseUrls("http://localhost:5001")
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public void CustomerSave()
        {
            var client = new RestClient("http://localhost:15829");

            var request = new RestRequest("/Customer/Customer_Save", Method.POST);
            CustomerModel model = new CustomerModel();
            model.DateofBirth = new DateTime();
            model.FirstName = "Test";
            model.LastName = "Test last";
            model.Title = "Mr.";
            model.Gender = "MALE";
            model.CustomerAddressList = new System.Collections.Generic.List<CustomerAddress>();
            model.CustomerAddressList.Add(new CustomerAddress() { Address1 = "resr", Address2 = "sdfsd", City = "dsfsdf", Country = "sdfdsf", IsBilling = false, IsShipping = true, PostalCode = "tests", State = "sdfsf" });

            string jsonToSend = JsonConvert.SerializeObject(model);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<SimpleResponse> response =  client.Execute<SimpleResponse>(request);
             
            Assert.False(response.Data.HasError);
        }

        [Fact]
        public void OrderSave()
        {
            var client = new RestClient("http://localhost:15829");

            var request = new RestRequest("/Order/Order_Save", Method.POST);
            OrderModel model = new OrderModel();
            model.CouponCode = "Coupon code";
            model.CurrencyCode = "CAD";
            model.CustomerId = 1;
            model.DiscountAmount = 2;
            model.OrderDate = new DateTime();
            model.OrderItemList = new System.Collections.Generic.List<OrderItem>();
            model.OrderItemList.Add(new OrderItem() {
                ItemCode = "ItemCode",
                ItemName = "Item Name",
                OrderItemId = 0,
                OrderNumber = 0,
                Price = 20,
                Quantity = 2
            });
            model.OrderNumber = 1;
            model.OrderTotal = 20;
            model.ShippingCost = 3;
            model.ShippingMethodCode = "2DAY";
            model.Taxes = 5;

            string jsonToSend = JsonConvert.SerializeObject(model);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<SimpleResponse> response = client.Execute<SimpleResponse>(request);

            Assert.False(response.Data.HasError);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
