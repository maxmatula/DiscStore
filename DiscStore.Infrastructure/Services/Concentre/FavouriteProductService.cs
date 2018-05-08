using AutoMapper;
using DiscStore.Core.Entities;
using DiscStore.Infrastructure.DAL;
using DiscStore.Infrastructure.Services.Abstract;
using DiscStore.Infrastructure.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Infrastructure.Services.Concentre
{
    public class FavouriteProductService : IFavouriteProductService
    {
        private DSDbContext db = new DSDbContext();
        public bool AddToFavourites(Guid productId, string userId)
        {
            try
            {
                FavouriteProduct fav = new FavouriteProduct();
                fav.FavouriteID = Guid.NewGuid();
                fav.ProductID = productId;
                fav.UserID = userId;
                db.FavouriteProducts.Add(fav);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
                throw new Exception("Cannot add product to favourites!");
            }
        }

        public List<ProductViewModel> FavouritesProductList(string userId)
        {
            var favproducts = (from prod in db.Products
                              join fav in db.FavouriteProducts
                              on prod.ProductID equals fav.ProductID
                              where fav.UserID.ToString() == userId
                              select prod).ToList();
            var model = Mapper.Map<List<ProductViewModel>>(favproducts);
            return model;
        }

        public bool RemoveFromFavourites(Guid favouriteId)
        {
            try
            {
                var fav = db.FavouriteProducts.Find(favouriteId);
                db.FavouriteProducts.Remove(fav);
                db.SaveChanges();
                return true;
                
            }
            catch
            {
                return false;
                throw new Exception("Can't remove product from favourites");
            }
        }
    }
}
