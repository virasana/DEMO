﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _repository;

        public CartController(IProductRepository repository)
        {
            _repository = repository;
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            var product = _repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            var product = _repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }
    }
}