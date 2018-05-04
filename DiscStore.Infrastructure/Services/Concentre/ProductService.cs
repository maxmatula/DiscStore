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
                Product prod = new Product();
                prod.Artist = product.Artist;
                prod.CategoryID = product.CategoryID;
                prod.Descirption = product.Descirption;
                prod.Name = product.Name;
                prod.PremiereDate = product.PremiereDate;
                prod.Price = product.Price;
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
                throw new Exception("Product Create failed!");
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
                throw new Exception("Prodyct Delete failed!");
            }
        }

        public bool Edit(Product product, HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    product.PictureMimeType = file.ContentType;
                    product.PictureData = new byte[file.ContentLength];
                    file.InputStream.Read(product.PictureData, 0, file.ContentLength);
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
                throw new Exception("Product Edit failed!");
            }
        }

        public ProductViewModel GetById(Guid productId)
        {
            try
            {
                var product = db.Products.Find(productId);
                var model = Mapper.Map<ProductViewModel>(product);
                return model;
            }
            catch
            {
                throw new Exception("Nie można znaleźć produktu!");
            }
        }

        public ProductViewModel GetCreateModel()
        {
            var model = new ProductViewModel();
            model.categories = db.Categories.Select(x => new SelectListItem
            {
                Value = x.CategoryID.ToString(),
                Text = x.Name
            });
            return model;
        }

        public List<ProductViewModel> GetList()
        {
            try
            {
                var products = db.Products.ToList();
                var model = Mapper.Map<List<ProductViewModel>>(products);
                if (products == null)
                {
                    model = new List<ProductViewModel>();
                }
                return model;
            }
            catch
            {
                throw new Exception("Nie można znaleźć produktów!");
            }
        }
    }
}
