using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkout.Api.Models
{
    /// <summary>
    /// Stub Customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Customer ID Auto Number
        /// </summary>
        public int ID { set; get; }

        /// <summary>
        /// Customer Name
        /// </summary>
        public string CustomerName { set; get; }
    }
}