using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly IProductRepository _repository;

        public NavController(IProductRepository repository)
        {
            _repository = repository;
        }
        public PartialViewResult Menu(string category)
        {
            var categories = _repository.Products.Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            var menuViewModel = new MenuViewModel {Categories = categories, SelectedCategory = category};
            return PartialView("Menu", menuViewModel);
        }
    }
}