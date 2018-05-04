using DiscStore.Infrastructure.Services.Abstract;
using DiscStore.Infrastructure.Services.Concentre;
using DiscStore.Infrastructure.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult Details(Guid categoryId)
        {
            var category = categoryService.GetById(categoryId);
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var result = categoryService.Create(category);
            }
            return View(category);
        }

        public ActionResult Edit(Guid categoryId)
        {
            var category = categoryService.GetById(categoryId);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var result = categoryService.Edit(category);
            }
            return View(category);
        }

        public ActionResult Delete(Guid? categoryId)
        {
            if (categoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = categoryService.GetById(categoryId.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid categoryId)
        {
            var result = categoryService.Delete(categoryId);
            return RedirectToAction("Index");
        }

    }
}