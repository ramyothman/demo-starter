using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkout.Api.Models
{
    /// <summary>
    /// Order Table Stub
    /// <remarks>
    /// This class is done to wrap the entity framework modal stub
    /// </remarks>
    /// </summary>
    public class Orders
    {
        /// <summary>
        /// Guid ID for an order
        /// </summary>
        public Guid ID { set; get; }

        /// <summary>
        /// Customer ID
        /// </summary>
        public int CustomerID { set; get; }
        
        /// <summary>
        /// Order Date default is Todays Date
        /// </summary>
        public DateTime OrderDate { set; get; }

        /// <summary>
        /// Total Price
        /// </summary>
        public decimal? TotalPrice { set; get; }

        /// <summary>
        /// List of Order Items
        /// </summary>
        public List<OrderItem> OrderItem { set; get; }

        /// <summary>
        /// Customer Object
        /// </summary>
        public Customer Customer { set; get; }
    }
}