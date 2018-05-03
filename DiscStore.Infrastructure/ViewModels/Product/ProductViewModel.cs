using DiscStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DiscStore.Infrastructure.ViewModels.Product
{
    public class ProductViewModel
    {
        public Guid ProductID { get; set; }
        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Opis")]
        public string Descirption { get; set; }
        [Required]
        [Display(Name = "Wykonawca")]
        public string Artist { get; set; }
        [Required]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Data wydania")]
        public DateTime? PremiereDate { get; set; }
        public byte[] PictureData { get; set; }
        public string PictureMimeType { get; set; }
        [Display(Name = "Kategoria")]
        public Guid CategoryID { get; set; }
        public IEnumerable<SelectListItem> categories { get; set; }

    }
}
