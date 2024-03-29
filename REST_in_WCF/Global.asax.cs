﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using REST_in_WCF.APIs;
using System.ServiceModel.Activation;
using Microsoft.ApplicationServer.Http.Activation;
using Microsoft.ApplicationServer.Http;

namespace REST_in_WCF
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            var config = new HttpConfiguration() { EnableTestClient = true };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.Add(new ServiceRoute("api/contacts", new HttpServiceHostFactory() { Configuration = config }, typeof(ContactsApi)));
            routes.Add(new ServiceRoute("api/order", new HttpServiceHostFactory() { Configuration = config }, typeof(OrderApi)));

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}