using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkout.Api.Models
{
    /// <summary>
    /// Calendar Appointment
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Appointment ID
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// Appointment Start  Date
        /// </summary>
        public DateTime StartDate { set;get;}
        /// <summary>
        /// Appointment End Date
        /// </summary>
        public DateTime EndDate { set; get; }
        /// <summary>
        /// Appointment Subject
        /// </summary>
        public string Subject { set; get; }
        /// <summary>
        /// Organizer
        /// </summary>
        public string Organizer { set; get; }
        /// <summary>
        /// Attendees
        /// </summary>
        public string Attendees { set; get; }
    }
}