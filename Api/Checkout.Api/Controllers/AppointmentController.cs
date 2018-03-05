using Checkout.Api.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Checkout.Api.Controllers
{
    /// <summary>
    /// Appointment Controller
    /// </summary>
    [RoutePrefix("api/appointment")]
    public class AppointmentController : BaseApiController
    {
        /// <summary>
        /// Get Appointments
        /// </summary>
        /// <returns></returns>
        [Route("getall")]
        [HttpGet]
        [SwaggerOperation("getall")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetAll()
        {
            try
            {
                List<Appointment> result = null;
                var appointments = entities.Appointment.ToList();
                result = AutoMapper.Mapper.Map<List<Appointment>>(appointments);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Get Appointments
        /// </summary>
        /// <returns></returns>
        [Route("getbymonth")]
        [HttpGet]
        [SwaggerOperation("getbymonth")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetByMonth(int ID)
        {
            try
            {
                List<Appointment> result = null;
                var appointments = entities.Appointment.Where(c => c.StartDate.Value.Month == ID);
                result = AutoMapper.Mapper.Map<List<Appointment>>(appointments);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Get Appointments
        /// </summary>
        /// <returns></returns>
        [Route("generate")]
        [HttpGet]
        [SwaggerOperation("generate")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Generate()
        {
            try
            {
                string attendeesString = "Ramy Othman,Michael Eggers,Denys Tochkovyi,Benjamin Maertz,Moshe Schmidt,Ondrej Kelle,Christian Kaas,Markus Pfahlert,Carolin Maier";
                string[] subject = new string[] { "Meeting", "Daily", "Gym", "Interview", "Reading", "Presentation", "Study" };
                string[] attendees = attendeesString.Split(',');
                for (int i = 1; i <= 12; i++)
                {
                    int rand = new Random().Next(2,6);
                    for(int j = 0; j <= rand; j++)
                    {
                        Data.Appointment app = new Data.Appointment();
                        int randAtt = new Random().Next(2, 6);
                        string strAtt = "";
                        int l = 1;
                        while (l <= randAtt)
                        {
                            int randSelection = new Random().Next(9);
                            if (!strAtt.Contains(attendees[randSelection]))
                                strAtt += attendees[randSelection] + ",";
                            else
                                randAtt++;
                            l++;
                        }
                        strAtt = strAtt.Remove(strAtt.Length - 1, 1);
                        app.Attendees = strAtt;
                        int orgId = new Random().Next(9);
                        app.Organizer = attendees[orgId];
                        int subjId = new Random().Next(7);
                        app.Subject = subject[subjId] + " with " + app.Organizer;
                        
                        int day = new Random().Next(1, 28);
                        app.StartDate = new DateTime(2018, i, day, new Random().Next(7, 20), new Random().Next(59), 0);
                        app.EndDate = app.StartDate.Value.AddHours(1);
                        this.entities.Appointment.Add(app);
                        this.entities.SaveChanges();
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Get Appointment By ID
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <returns></returns>
        [Route("getbyid")]
        [HttpGet]
        [SwaggerOperation("getbyid")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetByID(int id)
        {
            try
            {
                Appointment result = null;
                var order = entities.Appointment.Where(c => c.ID == id).FirstOrDefault();
                result = AutoMapper.Mapper.Map<Appointment>(order);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Add Appointment
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        [SwaggerOperation("Add")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public IHttpActionResult Add(Appointment appointment)
        {
            try
            {
                var result = AutoMapper.Mapper.Map<Checkout.Data.Appointment>(appointment);
                entities.Appointment.Add(result);
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