using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscStore.Core.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Nazwa produktu nie może być dłuższa niż 50 znaków")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "Opis produktu nie może być dłuższy niż 500 znaków")]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Nazwa Artysty nie może być dłuższa niż 50 znaków")]
        public string Artist { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime PremiereDate { get; set; }
        public byte[] PictureData { get; set; }
        [StringLength(50)]
        public string PictureMimeType { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public Product()
        {
            ProductID = Guid.NewGuid();
        }

    }
}
