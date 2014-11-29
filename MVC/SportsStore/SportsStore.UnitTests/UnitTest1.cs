using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebUI.Controllers;
using WebUI.HtmlHelpers;
using WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product(){ ProductId = 1, Name = "P1"},
                new Product(){ ProductId = 2, Name = "P2"},
                new Product(){ ProductId = 3, Name = "P3"},
                new Product(){ ProductId = 4, Name = "P4"},
                new Product(){ ProductId = 5, Name = "P5"}
            });

            var productController = new ProductController(mock.Object) {PageSize = 3};

            var result = ((IEnumerable<Product>)productController.List(2).Model).ToArray();

            Assert.IsTrue(result.Length == 2, "Expected to find 2 products.");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrange
            HtmlHelper htmlHelper = null;

            var pagingInfoViewModel = new PagingInfoViewModel()
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            
            Func<int, string> pageUrlBuilder = i => "Page " + i;

            // Act
            var result = htmlHelper.PageLinks(pagingInfoViewModel, pageUrlBuilder);

            // Assert
            const string match = @"<a class=""btn btn-default"" href=""Page 1"">1</a><a class=""btn btn-default btn-primary selected"" href=""Page 2"">2</a>";

            Assert.AreEqual(match, result.ToString());


        }
    }
}
