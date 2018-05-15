using AutoMapper;
using DiscStore.Core.Entities;
using DiscStore.Core.Models;
using DiscStore.Infrastructure.DAL;
using DiscStore.Infrastructure.Services.Abstract;
using DiscStore.Infrastructure.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Infrastructure.Services.Concentre
{
    public class OrderService : IOrderService
    {
        private DSDbContext db = new DSDbContext();

        public List<ShippingDetailsViewModel> CheckShippingDetails(string userId)
        {
            var shipping = db.ShippingDetails.Where(x => x.UserID == userId).ToList();
            var model = Mapper.Map<List<ShippingDetailsViewModel>>(shipping);
            return model;
        }

        public bool CompleteOrder(Guid shippingId, Cart cart, string userId)
        {
            Order order = new Order();
            order.ShippingID = shippingId;
            order.UserID = userId;
            order.Total = cart.ComputeTotalValue();
            db.Orders.Add(order);

            foreach(var prod in cart.Lines)
            {
                OrderProducts prodline = new OrderProducts();
                prodline.OrderID = order.OrderID;
                prodline.Quantity = prod.Quantity;
                prodline.ProductID = prod.Product.ProductID;
                db.OrderProducts.Add(prodline);
            }

            db.SaveChanges();
            return true;
        }

        public bool CreateShippingDetails(ShippingDetailsViewModel model, string userId)
        {
            try
            {
                var shipping = Mapper.Map<ShippingDetails>(model);
                shipping.ShippingID = Guid.NewGuid();
                shipping.UserID = userId;
                db.ShippingDetails.Add(shipping);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
                throw new Exception("Nie można stworzyć obiektu danych odbiorcy!");
            }
        }

        public bool EditShippingDetails(ShippingDetailsViewModel model)
        {
            try
            {
                var shipping = Mapper.Map<ShippingDetails>(model);
                db.Entry(shipping).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
                throw new Exception("Nie można edytować obiektu danych odbiorcy!");
            }
        }

        public ShippingDetailsViewModel FindById(Guid shippingId)
        {
            var shipping = db.ShippingDetails.Find(shippingId);
            var model = Mapper.Map<ShippingDetailsViewModel>(shipping);
            return model;
        }
    }
}
