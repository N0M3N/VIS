using System;
using System.Configuration;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebAPI
{
    public class WebApiApplication : HttpApplication
    {
        private readonly string allowedOrigin = ConfigurationManager.AppSettings["CorsAllowedOrigins"];
        private readonly string allowedHeaders = ConfigurationManager.AppSettings["CorsAllowedHeaders"];
        private readonly string allowedMethod = ConfigurationManager.AppSettings["CorsAllowedMethods"];

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BeginRequest += Application_BeginRequest;
        }


        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", allowedOrigin);
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true");

            if (HttpContext.Current.Request.HttpMethod == HttpMethod.Options.Method)
            {
                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", allowedMethod);
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", allowedHeaders);

                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }

    }
}
