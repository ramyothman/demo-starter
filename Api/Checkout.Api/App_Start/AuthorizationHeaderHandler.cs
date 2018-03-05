using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Checkout.Api
{
    /// <summary>
    /// AuthorizationHeaderHandler inherits DelegatingHandler. 
    /// SendAsync, will be called on every request into our API.
    /// </summary>
    public class AuthorizationHeaderHandler : DelegatingHandler
    {
        /// <summary>
        /// Called on every api request for authenticating the API Caller
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IEnumerable<string> apiKeyHeaderValues = null;
            if (request.Headers.TryGetValues("ApiKey", out apiKeyHeaderValues))
            {
                var apiKeyHeaderValue = apiKeyHeaderValues.First();

                // ... authentication logic here ...
                var username = (apiKeyHeaderValue == "12345" ? "Ramy" : "OtherUser");

                var usernameClaim = new Claim(ClaimTypes.Name, username);
                var identity = new ClaimsIdentity(new[] { usernameClaim }, "ApiKey");
                var principal = new ClaimsPrincipal(identity);

                Thread.CurrentPrincipal = principal;
            }
            //else
            //{
            //    //return request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "No API Key Provided");
                
            //    return base.SendAsync(request, new CancellationToken(true));
            //}

            return base.SendAsync(request, cancellationToken);
        }
    }
}