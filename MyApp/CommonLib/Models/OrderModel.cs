using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Models
{
    public class OrderModel
    {
        public int OrderNumber { get; set; }
        public int OrderTotal { get; set; }
        public string ShippingMethod { get; set; }
        public float ShippingCost { get; set; }
        public string Currency { get; set; }
        public float Taxes { get; set; }
        public float DiscountAmount { get; set; }
        public string CouponCode { get; set; }
        public List<OrderItem> OrderItemList { get; set; }
    }

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderNumber { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }        
        public float TotalPrice { get; set; }
    }
}
