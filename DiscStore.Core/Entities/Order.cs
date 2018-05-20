using DiscStore.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Core.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }
        public decimal Total { get; set; }
        public string UserID { get; set; }
        [ForeignKey("ShippingDetails")]
        public Guid ShippingID { get; set; }
        public virtual ShippingDetails ShippingDetails { get; set; }

        public Order()
        {
            OrderID = Guid.NewGuid();
        }

    }
}
