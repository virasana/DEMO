using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject.Planning.Targets;
using WebUI.Controllers;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            var products = Helpers.GetMockProductsRepository().Products.ToArray();

            var cart = new Cart();

            cart.AddItem(products[0], 1);
            cart.AddItem(products[1], 1);

            var results = cart.CartLines.ToArray();

            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Product, products[0]);
            Assert.AreEqual(results[1].Product, products[1]);
        }

        [TestMethod]
        public void Adding_Product_To_Cart_Goes_To_Cart_Screen()
        {
            var productRepository = Helpers.GetMockProductsRepository();
            var cart = new Cart();
            var cartController = new CartController(productRepository, null);

            var result = cartController.AddToCart(cart, 2, "myUrl");

            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }

        [TestMethod]
        public void Cannot_Checkout_Empty_Cart()
        {
            // Arrange
            var orderProcessorMock = new Mock<IOrderProcessor>();
            var cart = new Cart();
            var shippingDetails = new ShippingDetails();
            var cartController = new CartController(Helpers.GetMockProductsRepository(), orderProcessorMock.Object);

            // Act
            var result = cartController.Checkout(cart, shippingDetails);

            // Assert
            orderProcessorMock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());
            Assert.AreEqual("", result.ViewName );
            Assert.IsFalse(result.ViewData.ModelState.IsValid);
        }
    }
}
