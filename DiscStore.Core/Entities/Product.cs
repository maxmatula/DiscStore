using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Core.Entities
{
    public class Product
    {
        public Product()
        {
            this.ProductID = Guid.NewGuid();
        }

        [Key]
        public Guid ProductID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "Nazwa produktu nie może być dłuższa niż 30 znaków")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Opis produktu nie może być dłuższy niż 200 znaków")]
        public string Descirption { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
