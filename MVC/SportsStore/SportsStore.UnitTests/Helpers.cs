using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;
using Moq;

namespace SportsStore.UnitTests
{
    public class Helpers
    {
        public static IProductRepository GetMockProductsRepository()
        {
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product(){ ProductId = 1, Name = "P1", Category = "C1"},
                new Product(){ ProductId = 2, Name = "P2", Category = "C1"},
                new Product(){ ProductId = 3, Name = "P3", Category = "C2"},
                new Product(){ ProductId = 4, Name = "P4", Category = "C2"},
                new Product(){ ProductId = 5, Name = "P5", Category = "C3"}
            });
            return mock.Object;
        }

    }
}
