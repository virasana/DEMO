using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DomainEntities;
using Interfaces;
using ResourceManagerService;

namespace ResourcesWebApiHost
{
    public class ResourcesController : ApiController, IResourcesService
    {
        public List<Resource> GetAllResources()
        {
            var service = new Service();
            return service.GetAllResources();
        }
    }
}
