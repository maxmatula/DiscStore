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

        public ShippingDetailsViewModel CheckShippingDetails(string userId)
        {
            var shipping = db.ShippingDetails.Where(x => x.UserID == userId).FirstOrDefault();
            var model = Mapper.Map<ShippingDetailsViewModel>(shipping);
            if(model == null)
            {
                model = new ShippingDetailsViewModel();
            }
            return model;
        }

        public bool CompleteOrder(Guid shippingId, Cart cart, string userId)
        {
            Order order = new Order();
            order.ShippingID = shippingId;
            order.UserID = userId;
            order.Cart = cart;
            order.Total = cart.ComputeTotalValue();
            db.Orders.Add(order);
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

    }
}
