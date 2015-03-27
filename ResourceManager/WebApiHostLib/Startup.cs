using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
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
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            return config;
        }

        public class CrossDomainAccessFilter : ActionFilterAttribute
        {
            public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
            {
                actionExecutedContext.Response.Content.Headers.Add("Access-Control-Allow-Origin", "*");
            }
        }
    }
}