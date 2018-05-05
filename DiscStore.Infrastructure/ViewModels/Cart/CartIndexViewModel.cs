using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Infrastructure.ViewModels.Cart
{
    public class CartIndexViewModel
    {
        public Core.Models.Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
