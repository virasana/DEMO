using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using Moq;
using Ninject;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {Name = "Football", Price = 25},
                new Product {Name = "Surfboard", Price = 179},
                new Product {Name = "Running Shoes", Price = 95}
            });

            Console.WriteLine(mock.Object.GetType().FullName);

            _kernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}