using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebMVC.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            var origins = ConfigurationManager.AppSettings["cors:origins"].ToString();
            var headers = ConfigurationManager.AppSettings["cors:headers"].ToString();
            var methods = ConfigurationManager.AppSettings["cors:methods"].ToString();
            config.EnableCors(new EnableCorsAttribute(origins, headers, methods));

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
