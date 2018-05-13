using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Infrastructure.ViewModels.Order
{
    public class ShippingDetailsViewModel
    {
        public Guid ShippingID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
