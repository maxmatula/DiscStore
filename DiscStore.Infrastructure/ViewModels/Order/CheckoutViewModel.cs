using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Infrastructure.ViewModels.Order
{
    public class CheckoutViewModel
    {
        public virtual Core.Models.Cart Cart { get; set; }
        public virtual ShippingDetailsViewModel ShippingDetailsViewModel { get; set; }
    }
}
