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
        public ActionResult CategoryMenu()
        {
            var model = categoryService.GetList();
            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description")] CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var result = categoryService.Create(category);
                if (result == true)
                {
                    return RedirectToAction("Index", "Admin");
                }
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
        public ActionResult Edit([Bind(Include = "CategoryID,Name,Description")] CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var result = categoryService.Edit(category);
                if (result == true)
                {
                    return RedirectToAction("Index", "Admin");
                }
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
            return RedirectToAction("Index", "Admin");
        }

    }
}