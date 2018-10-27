using CommonLib.Core;
using CommonLib.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        public List<CustomerAddress> CustomerAddressList { get; set; }
        public List<CustomerBillingInfo> CustomerBillingInfoList { get; set; }
    }

    public class CustomerAddress
    {
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool IsShipping { get; set; }
        public bool IsBilling { get; set; }
    }

    public class CustomerBillingInfo
    {
        public int CustomerId { get; set; }
        public int BillingInfoId { get; set; }
        public string CardType { get; set; }
        public string CardholderName { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CVV { get; set; }
    }

    public class CustomerSearch : ListRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
