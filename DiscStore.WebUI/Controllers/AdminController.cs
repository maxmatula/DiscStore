using DiscStore.Infrastructure.Services.Abstract;
using DiscStore.Infrastructure.Services.Concentre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscStore.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public AdminController()
        {
            this.productService = new ProductService();
            this.categoryService = new CategoryService();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product()
        {
            var model = productService.GetProductVMList();
            return View(model);
        }

        public ActionResult Category()
        {
            var model = categoryService.GetList();
            return View(model);
        }
    }
}