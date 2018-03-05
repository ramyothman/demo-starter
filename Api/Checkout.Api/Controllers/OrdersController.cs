using Checkout.Api.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Checkout.Api.Controllers
{
    /// <summary>
    /// Order Controller API
    /// </summary>
    
    [RoutePrefix("api/Orders")]
    public class OrdersController : BaseApiController
    {

        /// <summary>
        /// Get Order Items by Order ID
        /// </summary>
        /// <param name="id">Order ID Guid</param>
        /// <returns></returns>
        [Route("GetItems")]
        [HttpGet]
        [SwaggerOperation("GetItems")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetItems(Guid id)
        {
            try
            {
                List<OrderItem> result = null;
                
                var items = entities.OrderItem.Where(c => c.OrderID == id);
                result = AutoMapper.Mapper.Map<List<OrderItem>>(items);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            } 
        }

        /// <summary>
        /// Get Order By ID and Order Related Items
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <returns></returns>
        [Route("GetByID")]
        [HttpGet]
        [SwaggerOperation("GetByID")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetByID(Guid id)
        {
            try
            {
                Orders result = null;
                var order = entities.Orders.Where(c => c.ID == id).FirstOrDefault();
                result = AutoMapper.Mapper.Map<Orders>(order);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Clear All Items by Order ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ClearItems")]
        [HttpGet]
        [SwaggerOperation("ClearItems")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult ClearItems(Guid id)
        {
            try
            {
                var order = entities.Orders.Where(c => c.ID == id).FirstOrDefault();
                entities.OrderItem.RemoveRange(order.OrderItem);
                entities.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Clear All Items by Order ID
        /// </summary>
        /// <param name="id">Item ID to be removed</param>
        /// <returns></returns>
        [Route("RemoveItem")]
        [HttpPost]
        [SwaggerOperation("RemoveItem")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult RemoveItem(Guid id)
        {
            try
            {
                var orderItem = entities.OrderItem.Where(c => c.ID == id).FirstOrDefault();
                entities.OrderItem.Remove(orderItem);
                entities.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Clear All Items by Order ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("AddItem")]
        [HttpPost]
        [SwaggerOperation("AddItem")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public IHttpActionResult AddItem(OrderItem item)
        {
            try
            {
                var result = AutoMapper.Mapper.Map<Checkout.Data.OrderItem>(item);
                result.ID = Guid.NewGuid(); 
                entities.OrderItem.Add(result);
                entities.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
