using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Ninject;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        [Inject]
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ActionResult List()
        {
            return View(_repository.Products);
        }
    }
}