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
        // GET: Category
        [AllowAnonymous]
        public ActionResult CategoriesList()
        {
            return View();
        }
    }
}