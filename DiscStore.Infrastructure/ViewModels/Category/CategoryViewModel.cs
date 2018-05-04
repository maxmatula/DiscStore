using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Infrastructure.ViewModels.Category
{
    public class CategoryViewModel
    {
        public Guid CategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Core.Entities.Product> Products { get; set; }
    }
}
