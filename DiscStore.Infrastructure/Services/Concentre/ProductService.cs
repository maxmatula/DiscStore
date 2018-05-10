using AutoMapper;
using DiscStore.Core.Entities;
using DiscStore.Infrastructure.DAL;
using DiscStore.Infrastructure.Services.Abstract;
using DiscStore.Infrastructure.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscStore.Infrastructure.Services.Concentre
{
    public class ProductService : IProductService
    {
        private DSDbContext db = new DSDbContext();
        public bool Create(ProductViewModel product, HttpPostedFileBase file)
        {
            try
            {
                Product prod = new Product
                {
                    Artist = product.Artist,
                    CategoryID = product.selectedCategoryID,
                    Description = product.Description,
                    Name = product.Name,
                    PremiereDate = product.PremiereDate,
                    Price = product.Price
                };
                if (file != null)
                {
                    prod.PictureMimeType = file.ContentType;
                    prod.PictureData = new byte[file.ContentLength];
                    file.InputStream.Read(prod.PictureData, 0, file.ContentLength);
                }

                db.Products.Add(prod);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Guid productId)
        {
            try
            {
                var product = db.Products.Find(productId);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(ProductViewModel product, HttpPostedFileBase file)
        {
            try
            {
                Product prod = db.Products.Find(product.ProductID);
                prod.Artist = product.Artist;
                prod.CategoryID = product.selectedCategoryID;
                prod.Description = product.Description;
                prod.Name = product.Name;
                prod.PremiereDate = product.PremiereDate;
                prod.Price = product.Price;

                if (file != null)
                {
                    prod.PictureMimeType = file.ContentType;
                    prod.PictureData = new byte[file.ContentLength];
                    file.InputStream.Read(prod.PictureData, 0, file.ContentLength);
                }
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ProductViewModel GetProductVMById(Guid productId)
        {
            var product = db.Products.Find(productId);
            var model = Mapper.Map<ProductViewModel>(product);
            var categories = db.Categories.Select(f => new SelectListItem
            {
                Value = f.CategoryID.ToString(),
                Text = f.Name
            });
            model.Categories = categories;
            model.selectedCategoryID = product.CategoryID;
            return model;
        }

        public ProductViewModel GetCreateModel()
        {
            var model = new ProductViewModel();
            var categories = db.Categories.Select(f => new SelectListItem
            {
                Value = f.CategoryID.ToString(),
                Text = f.Name
            });
            model.Categories = categories;
            return model;
        }

        public List<ProductViewModel> GetProductVMList()
        {
            var products = db.Products.ToList();
            var model = Mapper.Map<List<ProductViewModel>>(products);
            return model;
        }

        public List<ProductViewModel> GetNewProductVMList()
        {
            var products = db.Products.ToList();
            products = products.Where(x => x.PremiereDate.Date.AddDays(30) > DateTime.Now.Date).ToList();
            var model = Mapper.Map<List<ProductViewModel>>(products);
            return model;
        }

        public Product GetProductById(Guid productId)
        {
            var product = db.Products.Find(productId);
            return product;
        }
    }
}
