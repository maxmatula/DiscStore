using DiscStore.Core.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Core.Entities
{
    public class FavouriteProduct
    {
        [Key]
        public Guid FavouriteID { get; set; }
        public string UserID { get; set; }
        public virtual AppUser User { get; set; }
        public Guid ProductID { get; set; }
    }
}
