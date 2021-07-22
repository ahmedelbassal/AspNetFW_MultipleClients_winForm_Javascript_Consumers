using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

using System.Web.Mvc;

namespace Company.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();


        }

        //protected void Application_BeginRequest()
        //{
        //    //Preflight Request
        //    if (Request.Headers.AllKeys.Contains("Origin")&&Request.HttpMethod=="OPTIONS")
        //    {
        //        Response.Flush();
        //    }
        //}

        protected void Application_BeginRequest()
        {
            //PreFlight Request
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            }
        }

    }
}
