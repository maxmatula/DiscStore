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
        [StringLength(80)]
        [DataType(DataType.Text)]
        [Display(Name = "Imię i Nazwisko")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Required]
        [StringLength(12)]
        [DataType(DataType.Text)]
        [Display(Name = "Numer Domu")]
        public string HouseNumber { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Miejscowość")]
        public string City { get; set; }
        [Required]
        [StringLength(12)]
        [DataType(DataType.Text)]
        [Display(Name = "Kod Pocztowy")]
        public string PostalCode { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:###-###-###}")]
        [Display(Name = "Telefon")]
        public long Phone { get; set; }
    }
}
