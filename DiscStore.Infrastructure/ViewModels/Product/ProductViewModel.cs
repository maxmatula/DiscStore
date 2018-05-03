using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Infrastructure.ViewModels.Product
{
    public class ProductViewModel
    {
        public Guid ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descirption { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime? PremiereDate { get; set; }
        public byte[] PictureData { get; set; }
        public string PictureMimeType { get; set; }
        public Guid CategoryID { get; set; }

    }
}
