using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using DomainEntities;
using Interfaces;
using ResourceManagerService;

namespace ResourcesWebApiHost
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ResourcesController : ApiController
    {
        [HttpGet, Route("api/Resources/GetAllResources")]
        public List<Resource> GetAllResources()
        {
            var service = new Service();
            return service.GetAllResources();
        }

        [HttpPost, Route("api/Resources/DeleteSingle")]
        public HttpResponseMessage DeleteSingle(Resource resource)
        {
            var service = new Service();
            var success = service.DeleteSingle(resource);
            var result = Request.CreateResponse(HttpStatusCode.OK, success.ToString());
            return result;
        }

        [HttpPost, Route("api/Resources/DeleteList")]
        public HttpResponseMessage DeleteList(List<Resource> resources)
        {
            var service = new Service();
            var success = service.DeleteList(resources);
            var result = Request.CreateResponse(HttpStatusCode.OK, success.ToString());
            return result;
        }
    }
}
