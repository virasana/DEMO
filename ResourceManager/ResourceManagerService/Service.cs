using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;
using Interfaces;

namespace ResourceManagerService
{
    public class Service : IResourcesService
    {
        public List<Resource> GetAllResources()
        {
            var result = new List<Resource>()
            {
                new Resource() { Name = "D: on PC1", Type = "DIR" },
                 new Resource() { Name = "Website 1 on PC2", Type = "IIS" }
            };
            return result;
        }
    }
}
