using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkout.Api.Models
{
    /// <summary>
    /// Order Item Data Binding Modal
    /// <remarks>
    /// This class is done to wrap the entity framework modal stub
    /// </remarks>
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Guid ID for an Order Item
        /// </summary>
        public Guid ID { set; get; }

        /// <summary>
        /// Item ID from Customer Data
        /// </summary>
        public string ItemID { set; get; }

        /// <summary>
        /// Order ID from Customer Order
        /// </summary>
        public Guid OrderID { set; get; }

        /// <summary>
        /// Item Description
        /// </summary>
        public  string Description { set; get; }

        /// <summary>
        /// Order Quantity
        /// </summary>
        public int Quantity { set; get; }

        /// <summary>
        /// Item Unit Price
        /// </summary>
        public decimal UnitPrice { set; get; }

        /// <summary>
        /// Total Item Price
        /// </summary>
        public decimal Price { set; get; }
    }
}