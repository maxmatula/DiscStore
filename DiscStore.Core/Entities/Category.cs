using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscStore.Core.Entities
{
    public class Category
    {
        [Key]
        public Guid CategoryID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Nazwa kategorii nie może być dłuższa niż 50 znaków")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Opis kategorii nie może być dłuższy niż 200 znaków")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            CategoryID = Guid.NewGuid();
        }
    }
}
