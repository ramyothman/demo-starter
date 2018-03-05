using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkout.Api
{
    /// <summary>
    /// Auto Mapper Configuration
    /// </summary>
    public class MapperConfig
    {
        /// <summary>
        /// Register Custom AutoMapper Configurations
        /// </summary>
        public static void RegisterCustom()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Checkout.Data.Customer, Models.Customer>();
                cfg.CreateMap<Models.Customer, Checkout.Data.Customer>();

                cfg.CreateMap<Checkout.Data.Orders, Models.Orders>();
                cfg.CreateMap<Models.Orders, Checkout.Data.Orders>();

                cfg.CreateMap<Checkout.Data.OrderItem, Models.OrderItem>();
                cfg.CreateMap<Models.OrderItem, Checkout.Data.OrderItem>();

                cfg.CreateMap<Checkout.Data.Appointment, Models.Appointment>();
                cfg.CreateMap<Models.Appointment, Checkout.Data.Appointment>();

            });

        }
    }
}