using DiscStore.Infrastructure.Services.Abstract;
using DiscStore.Infrastructure.Services.Concentre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController()
        {
            this.productService = new ProductService();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}