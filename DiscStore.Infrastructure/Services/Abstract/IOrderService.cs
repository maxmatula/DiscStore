using DiscStore.Core.Models;
using DiscStore.Infrastructure.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Infrastructure.Services.Abstract
{
    public interface IOrderService
    {
        bool CreateShippingDetails(ShippingDetailsViewModel model, string userId);
        bool EditShippingDetails(ShippingDetailsViewModel model);
        ShippingDetailsViewModel CheckShippingDetails(string userId);
        bool CompleteOrder(Guid shippingId, Cart cart, string userId);
    }
}
