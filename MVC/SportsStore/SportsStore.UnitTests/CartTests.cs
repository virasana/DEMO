using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject.Planning.Targets;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            var products = Helpers.GetMockProductsRepository().Object.Products.ToArray();

            var cart = new Cart();

            cart.AddItem(products[0], 1);
            cart.AddItem(products[1], 1);

            var results = cart.CartLines.ToArray();

            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Product, products[0]);
            Assert.AreEqual(results[1].Product, products[1]);
        }
    }
}
