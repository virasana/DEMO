using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using Ninject;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public int PageSize = 3;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List(string category, int page = 1)
        {
            var products = _repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId);
            
            var totalItems = products.Count();

            var thisPageProducts = products.Skip((page - 1)*PageSize)
                .Take(PageSize);

            var model = new ProductsListViewModel
            {
                Products = thisPageProducts,
                PagingInfoViewModel = new PagingInfoViewModel()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = totalItems,
                    Category = category
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}