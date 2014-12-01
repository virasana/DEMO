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
            var mock = GetMockProductsRepository();

            var productController = new ProductController(mock.Object) { PageSize = 3 };

            var result = ((ProductsListViewModel)productController.List(null, 2).Model).Products.ToArray();

            Assert.IsTrue(result.Length == 2, "Expected to find 2 products.");
        }

        private static Mock<IProductRepository> GetMockProductsRepository()
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
            return mock;
        }

        [TestMethod]
        public void Can_Filter_Products()
        {
            // Arrange
            var mockRepository = GetMockProductsRepository();
            var productController = GetProductController();

            // Act
            var result = ((ProductsListViewModel)productController.List("C2").Model).Products.ToArray();

            // Assert
            Assert.IsTrue(result.Length == 2, "Two products expected.");
            Assert.IsTrue(result[0].Name == "P3" && result[0].Category == "C2", "Expected Name==P3 and Cateogory==C2");
            Assert.IsTrue(result[1].Name == "P4" && result[1].Category == "C2", "Expected Name==P4 and Cateogory==C2");
        }

        private ProductController GetProductController()
        {
            return new ProductController(GetMockProductsRepository().Object);
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

            PagingHelpers.PageBuilderDelegate pageUrlBuilder = (page, category) => "Page " + category;

            // Act
            var result = htmlHelper.PageLinks(pagingInfoViewModel, pageUrlBuilder);

            // Assert
            const string match = "<a class=\"btn btn-default\" href=\"Page \">1</a><a class=\"btn btn-default btn-primary selected\" href=\"Page \">2</a><a class=\"btn btn-default\" href=\"Page \">3</a>";

            Assert.AreEqual(match, result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            var productController = GetProductController();

            var result = (ProductsListViewModel)productController.List(null, 2).Model;

            var pagingInfo = result.PagingInfoViewModel;

            Assert.AreEqual(result.PagingInfoViewModel.CurrentPage, 2);
            Assert.AreEqual(result.PagingInfoViewModel.ItemsPerPage, 3);
        }

        [TestMethod]
        public void Can_Create_Categories()
        {
            // Arrange
            var productRepository = GetMockProductsRepository().Object;
            var navController = new NavController(productRepository);
            
            // Act
            var results = ((IEnumerable<string>)navController.Menu(null).Model).ToArray();

            // Assert
            Assert.AreEqual(results.Length, 3, "Expected 3 categories");
        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            var navController = new NavController(GetMockProductsRepository().Object);
            const string selectedCategory = "C2";

            var result = navController.Menu(selectedCategory);

            Assert.AreEqual(selectedCategory, ((MenuViewModel)result.Model).SelectedCategory);
        }
    }
}
