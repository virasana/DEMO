using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DomainEntities;
using Interfaces;
using ResourceManagerService;

namespace ResourcesWebApiHost
{
    public class ResourcesController : ApiController
    {
        public List<Resource> GetAllResources()
        {
            var service = new Service();
            return service.GetAllResources();
        }

        [HttpPost]
        [ActionName("Delete")]
        public HttpResponseMessage Delete(List<Resource> resources)
        {
            var service = new Service();
            var success = service.Delete(resources);
            var result = new HttpResponseMessage();
            result.Headers.Add("Access-Control-Allow-Origin", "null");
            return result;
        }
    }
}
