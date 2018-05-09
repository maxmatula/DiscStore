using DiscStore.Core.Entities;
using DiscStore.Core.Models;
using DiscStore.Infrastructure.Services.Abstract;
using DiscStore.Infrastructure.Services.Concentre;
using DiscStore.Infrastructure.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService productService;

        public CartController()
        {
            this.productService = new ProductService();
        }

        public ActionResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public ActionResult AddToCart(Cart cart, Guid productId, string returnUrl)
        {
            var product = productService.GetProductById(productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return Redirect(returnUrl);
        }

        public ActionResult RemoveFromCart(Cart cart, Guid productId, string returnUrl)
        {
            var product = productService.GetProductById(productId);

            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult ClearCart(Cart cart, string returnUrl)
        {
            if(cart != null)
            {
                cart.Clear();
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}