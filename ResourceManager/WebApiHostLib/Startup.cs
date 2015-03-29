using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using System.Web.Routing;
using DomainEntities;
using Owin;
using WebApiContrib.Formatting.Jsonp;

namespace ResourcesWebApiHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = ConfigureWebApi();
            app.UseWebApi(webApiConfiguration);
        }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            var corsAttr = new EnableCorsAttribute("http://localhost:5000/", "*", "*");
            config.Formatters.Insert(0, new JsonpMediaTypeFormatter(new JsonMediaTypeFormatter()));
            config.EnableCors();
            config.Filters.Add(new CrossDomainAccessFilter());

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}");
            
            return config;
        }

        public class CrossDomainAccessFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var routes = actionContext.Request.GetRouteData();
                base.OnActionExecuting(actionContext);
            }

            public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
            {
                if (actionExecutedContext.Response.Content != null)
                {
                    actionExecutedContext.Response.Content.Headers.Add("Access-Control-Allow-Origin", "null");
                    actionExecutedContext.Response.Content.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
                    actionExecutedContext.Response.Content.Headers.Add("Access-Control-Allow-Headers","Content-Type, X-Requested-With");
                }
            }
        }

        protected void ShowRouteValues(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            if (context == null)
                return;
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(context));
        }
    }
}