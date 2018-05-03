using DiscStore.Core.Entities;
using DiscStore.Infrastructure.Services.Abstract;
using DiscStore.Infrastructure.Services.Concentre;
using DiscStore.Infrastructure.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscStore.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController()
        {
            this.productService = new ProductService();
        }
        // GET: Product
        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = productService.GetList();
            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var result = productService.Create(product, file);
            }
            return View(product);
        }
    }
}