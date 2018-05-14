using DiscStore.Core.Entities;
using DiscStore.Infrastructure.DAL;
using DiscStore.Infrastructure.Services.Abstract;
using DiscStore.Infrastructure.Services.Concentre;
using DiscStore.Infrastructure.ViewModels.Product;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = productService.GetProductVMList();
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Newest()
        {
            var model = productService.GetNewProductVMList();
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Details(Guid? productId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = productService.GetProductVMById(productId.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            var product = productService.GetCreateModel();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Artist,Price,PremiereDate,selectedCategoryID,Categories,PictureData,PictureMimeType")] ProductViewModel product, string file)
        {
            if (ModelState.IsValid)
            {

                var result = productService.Create(product, file);
                if (result == true)
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            product = productService.GetCreateModel();
            return View(product);
        }

        public ActionResult Edit(Guid productId)
        {
            var product = productService.GetProductVMById(productId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,Description,Artist,Price,PremiereDate,selectedCategoryID,Categories,PictureData,PictureMimeType")] ProductViewModel product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var result = productService.Edit(product, file);
                if (result == true)
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            product = productService.GetCreateModel();
            return View(product);
        }

        [AllowAnonymous]
        public ActionResult GetPicture(Guid productId)
        {
            var product = productService.GetProductVMById(productId);
            if (product != null && product.PictureData != null)
            {
                return File(product.PictureData, product.PictureMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult Delete(Guid? productId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = productService.GetProductVMById(productId.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid productId)
        {
            var result = productService.Delete(productId);
            return RedirectToAction("Index", "Admin");

        }

    }
}