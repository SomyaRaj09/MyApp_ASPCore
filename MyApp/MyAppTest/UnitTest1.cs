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
        //private readonly TestServer _server;
        //private readonly HttpClient _client;
        private RestClient client;

        public UnitTest1()
        {
            ////string[] args = new string[0];
            ////CreateWebHostBuilder(args).Build().Run();
            //// Arrange
            //_server = new TestServer(new WebHostBuilder()
            //   // .UseUrls("http://localhost:5001")
            //   .UseStartup<Startup>());
            //_client = _server.CreateClient();
            client = new RestClient("http://localhost:15829");
        }

        [Fact]
        public void CustomerSave()
        {
            //var client = new RestClient("http://localhost:15829");

            var request = new RestRequest("/Customer/Customer_Save", Method.POST);
            CustomerModel model = new CustomerModel();
            model.DateofBirth = System.DateTime.Now;
            model.FirstName = "Test first";
            model.LastName = "Test last";
            model.Title = "Mr.";
            model.Gender = "MALE";
            model.CustomerAddressList = new System.Collections.Generic.List<CustomerAddress>();
            model.CustomerAddressList.Add(new CustomerAddress() {
                                                                    Address1 = "Test address 1",
                                                                    Address2 = "Test address 2",
                                                                    City = "Test city",
                                                                    Country = "Test country",
                                                                    IsBilling = false,
                                                                    IsShipping = true,
                                                                    PostalCode = "122017",
                                                                    State = "Test state"
                                                                });
            model.CustomerBillingInfoList = new System.Collections.Generic.List<CustomerBillingInfo>();
            model.CustomerBillingInfoList.Add(new CustomerBillingInfo() {
                                                                            CardholderName = "test name",
                                                                            CardNumber = "1230 0919 0123 0912",
                                                                            CardType = "DEBIT",
                                                                            CVV = "787",
                                                                            ExpiryDate = System.DateTime.Now
                                                                        });

            string jsonToSend = JsonConvert.SerializeObject(model);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<SimpleResponse> response = client.Execute<SimpleResponse>(request);
                        
            Assert.False(response.Data.HasError);
        }

        [Fact]
        public void CustomerSaveValidation()
        {
            //var client = new RestClient("http://localhost:15829");

            var request = new RestRequest("/Customer/Customer_Save", Method.POST);
            CustomerModel model = new CustomerModel();
            model.DateofBirth = System.DateTime.Now;
            model.FirstName = "";
            model.LastName = "";
            model.Title = "Mr.";
            model.Gender = "MALE";
            model.CustomerAddressList = new System.Collections.Generic.List<CustomerAddress>();
            model.CustomerAddressList.Add(new CustomerAddress()
            {
                Address1 = "Test address 1",
                Address2 = "Test address 2",
                City = "Test city",
                Country = "Test country",
                IsBilling = false,
                IsShipping = true,
                PostalCode = "122017",
                State = "Test state"
            });
            model.CustomerBillingInfoList = new System.Collections.Generic.List<CustomerBillingInfo>();
            model.CustomerBillingInfoList.Add(new CustomerBillingInfo()
            {
                CardholderName = "test name",
                CardNumber = "1230 0919 0123 0912",
                CardType = "DEBIT",
                CVV = "787",
                ExpiryDate = System.DateTime.Now
            });

            string jsonToSend = JsonConvert.SerializeObject(model);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<SimpleResponse> response = client.Execute<SimpleResponse>(request);
            
            Assert.True(response.Data.HasError);
        }

        [Fact]
        public void CustomerUpdate()
        {
            //var client = new RestClient("http://localhost:15829");
                        
            CustomerModel model = new CustomerModel();
            model.CustomerId = 1;
            model.DateofBirth = System.DateTime.Now;
            model.FirstName = "Test first";
            model.LastName = "Test last";
            model.Title = "Mr.";
            model.Gender = "MALE";            
            model.CustomerAddressList = new System.Collections.Generic.List<CustomerAddress>();
            model.CustomerAddressList.Add(new CustomerAddress()
            {
                CustomerId = 1,
                AddressId = 1,
                Address1 = "Test address 1",
                Address2 = "Test address 2",
                City = "Test city",
                Country = "Test country",
                IsBilling = false,
                IsShipping = true,
                PostalCode = "122017",
                State = "Test state"
            });
            model.CustomerBillingInfoList = new System.Collections.Generic.List<CustomerBillingInfo>();
            model.CustomerBillingInfoList.Add(new CustomerBillingInfo()
            {
                CustomerId = 1,
                BillingInfoId = 1,
                CardholderName = "test name",
                CardNumber = "1230 0919 0123 0912",
                CardType = "DEBIT",
                CVV = "787",
                ExpiryDate = System.DateTime.Now
            });

            var request = new RestRequest("/Customer/Customer_Update?id=" + model.CustomerId, Method.PUT);
            string jsonToSend = JsonConvert.SerializeObject(model);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<SimpleResponse> response = client.Execute<SimpleResponse>(request);

            Assert.False(response.Data.HasError);
        }

        [Fact]
        public void CustomerDelete()
        {
            //var client = new RestClient("http://localhost:15829");

            var request = new RestRequest("/Customer/Customer_Delete/" + 2, Method.DELETE);
            
            IRestResponse<SimpleResponse> response = client.Execute<SimpleResponse>(request);

            Assert.False(response.Data.HasError);
        }

        [Fact]
        public void OrderSave()
        {
            //var client = new RestClient("http://localhost:15829");

            var request = new RestRequest("/Order/Order_Save", Method.POST);
            OrderModel model = new OrderModel();
            model.CouponCode = "Coupon code";
            model.CurrencyCode = "CAD";
            model.CustomerId = 1;
            model.DiscountAmount = 2;
            model.OrderDate = System.DateTime.Now;
            model.OrderItemList = new System.Collections.Generic.List<OrderItem>();
            model.OrderItemList.Add(new OrderItem() {
                ItemCode = "ItemCode",
                ItemName = "Item Name",
                Price = 20,
                Quantity = 2
            });
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

        [Fact]
        public void OrderUpdate()
        {
            //var client = new RestClient("http://localhost:15829");

            OrderModel model = new OrderModel();
            model.CouponCode = "Coupon code";
            model.CurrencyCode = "CAD";
            model.CustomerId = 1;
            model.OrderNumber = 2;
            model.DiscountAmount = 2;
            model.OrderDate = System.DateTime.Now;
            model.OrderItemList = new System.Collections.Generic.List<OrderItem>();
            model.OrderItemList.Add(new OrderItem()
            {
                OrderNumber = 2,
                OrderItemId = 1,
                ItemCode = "ItemCode",
                ItemName = "Item Name",
                Price = 20,
                Quantity = 2
            });
            model.OrderTotal = 20;
            model.ShippingCost = 3;
            model.ShippingMethodCode = "2DAY";
            model.Taxes = 5;
            
            var request = new RestRequest("/Order/Order_Update?id=" + model.OrderNumber, Method.PUT);
            string jsonToSend = JsonConvert.SerializeObject(model);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<SimpleResponse> response = client.Execute<SimpleResponse>(request);

            Assert.False(response.Data.HasError);
        }

        [Fact]
        public void OrderSaveValidation()
        {
            //var client = new RestClient("http://localhost:15829");

            var request = new RestRequest("/Order/Order_Save", Method.POST);
            OrderModel model = new OrderModel();
            model.CouponCode = "Coupon code";
            model.CurrencyCode = "";
            model.CustomerId = 1;
            model.DiscountAmount = 2;
            model.OrderDate = System.DateTime.Now;
            model.OrderItemList = new System.Collections.Generic.List<OrderItem>();
            model.OrderItemList.Add(new OrderItem()
            {
                ItemCode = "ItemCode",
                ItemName = "Item Name",
                Price = 20,
                Quantity = 2
            });
            model.OrderTotal = 20;
            model.ShippingCost = 3;
            model.ShippingMethodCode = "2DAY";
            model.Taxes = 5;

            string jsonToSend = JsonConvert.SerializeObject(model);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<SimpleResponse> response = client.Execute<SimpleResponse>(request);

            Assert.True(response.Data.HasError);
        }

        [Fact]
        public void OrderDelete()
        {
            //var client = new RestClient("http://localhost:15829");

            var request = new RestRequest("/Order/Order_Delete/" + 2, Method.DELETE);

            IRestResponse<SimpleResponse> response = client.Execute<SimpleResponse>(request);

            Assert.False(response.Data.HasError);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
