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
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController()
        {
            this.categoryService = new CategoryService();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult CategoryList()
        {
            var model = categoryService.GetCategoryList();
            return View();
        }
    }
}