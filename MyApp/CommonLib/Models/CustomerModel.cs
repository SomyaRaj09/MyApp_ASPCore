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
        //public string ShippingAddress1 { get; set; }
        //public string ShippingAddress2 { get; set; }
        //public string ShippingAddressCity { get; set; }
        //public string ShippingAddressState { get; set; }
        //public string ShippingAddressCountry { get; set; }
        //public string ShippingAddressPostalCode { get; set; }
        //public string BillingAddress1 { get; set; }
        //public string BillingAddress2 { get; set; }
        //public string BillingAddressCity { get; set; }
        //public string BillingAddressState { get; set; }
        //public string BillingAddressCountry { get; set; }
        //public string BillingAddressPostalCode { get; set; }
    }

    public class CustomerAddress
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool IsShipping { get; set; }
        public bool IsBilling { get; set; }
    }
}
