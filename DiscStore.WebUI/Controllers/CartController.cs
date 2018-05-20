using DiscStore.Core.Entities;
using DiscStore.Core.Models;
using DiscStore.Infrastructure.Services.Abstract;
using DiscStore.Infrastructure.Services.Concentre;
using DiscStore.Infrastructure.ViewModels.Cart;
using DiscStore.Infrastructure.ViewModels.Order;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscStore.WebUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public CartController()
        {
            this.productService = new ProductService();
            this.orderService = new OrderService();
        }

        [AllowAnonymous]
        public ActionResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        [AllowAnonymous]
        public ActionResult AddToCart(Cart cart, Guid productId, string returnUrl)
        {
            var product = productService.GetProductById(productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return Redirect(returnUrl);
        }

        [AllowAnonymous]
        public ActionResult RemoveFromCart(Cart cart, Guid productId, string returnUrl)
        {
            var product = productService.GetProductById(productId);

            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [AllowAnonymous]
        public ActionResult ClearCart(Cart cart, string returnUrl)
        {
            if (cart != null)
            {
                cart.Clear();
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [AllowAnonymous]
        public ActionResult Summary(Cart cart)
        {
            return PartialView(cart);
        }


        public ActionResult ShippingDetails()
        {
            var userId = User.Identity.GetUserId();
            var model = orderService.CheckShippingDetails(userId);
            return View(model);
        }

        public ActionResult Checkout(Guid shippingId, Cart cart)
        {
            if (shippingId != null)
            {
                CheckoutViewModel model = new CheckoutViewModel();
                model.Cart = cart;
                model.ShippingDetailsViewModel = orderService.FindById(shippingId);
                return View(model);
            }
            return HttpNotFound();
        }

        public ActionResult EditShipping(Guid shippingId)
        {
            if (shippingId != null)
            {
                var model = orderService.FindById(shippingId);
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditShipping(ShippingDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = orderService.EditShippingDetails(model);
                return RedirectToAction("Checkout", "Cart");
            }
            return View(model);
        }

        public ActionResult CreateShipping()
        {
            return View(new ShippingDetailsViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateShipping(ShippingDetailsViewModel model)
        {
            var userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                var result = orderService.CreateShippingDetails(model, userId);
                return RedirectToAction("ShippingDetails", "Cart");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteShipping(Guid shippingId)
        {
            if(shippingId != null)
            {
                var result = orderService.DeleteShipping(shippingId);
                return RedirectToAction("ShippingDetails", "Cart");
            }
            return HttpNotFound();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompleteCheckout(Cart cart, Guid shippingId)
        {
            var userId = User.Identity.GetUserId();
            if (cart.Lines.Any() == true && shippingId != null)
            {
                var result = orderService.CompleteOrder(shippingId, cart, userId);
                if (result == true)
                {
                    cart.Clear();
                    return RedirectToActionPermanent("OrderComplete", "Cart");
                }
                return HttpNotFound();
            }
            return HttpNotFound();
        }

        public ActionResult OrderComplete()
        {
            return View();
        }
    }
}