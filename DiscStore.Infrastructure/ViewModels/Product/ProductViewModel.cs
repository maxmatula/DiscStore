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
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Wykonawca")]
        [DataType(DataType.Text)]
        public string Artist { get; set; }
        [Required]
        [Display(Name = "Cena")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Data wydania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PremiereDate { get; set; }
        public byte[] PictureData { get; set; }
        public string PictureMimeType { get; set; }
        [Display(Name = "Kategoria")]
        public string selectedCategoryID { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}
