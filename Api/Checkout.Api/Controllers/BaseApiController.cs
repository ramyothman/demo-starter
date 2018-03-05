using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Checkout.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        protected Checkout.Data.CheckoutDB entities = new Checkout.Data.CheckoutDB();
    }
}
