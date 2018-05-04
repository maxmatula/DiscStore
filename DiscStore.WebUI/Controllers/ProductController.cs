﻿using DiscStore.Core.Entities;
using DiscStore.Infrastructure.DAL;
using DiscStore.Infrastructure.Services.Abstract;
using DiscStore.Infrastructure.Services.Concentre;
using DiscStore.Infrastructure.ViewModels.Product;
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
        // GET: Product
        [AllowAnonymous]
        public ActionResult ProductList()
        {
            var model = productService.GetList();
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Details(Guid? productId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = productService.GetById(productId.Value);
            if(product == null)
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
        public ActionResult Create(ProductViewModel product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var result = productService.Create(product, file);
            }
            return View(product);
        }

        public ActionResult Edit(Guid productId)
        {
            var product = productService.GetById(productId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var result = productService.Edit(product, file);
            }
            return View(product);
        }

        [AllowAnonymous]
        public ActionResult GetPicture(Guid productId)
        {
            var product = productService.GetById(productId);
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
            var product = productService.GetById(productId.Value);
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
            return RedirectToAction("Index");
        }
    }
}