using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PremiereDate { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
