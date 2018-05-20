using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Core.Entities
{
    public class OrderProducts
    {
        [Key]
        public Guid OrderProductID { get; set; }
        public int Quantity { get; set; }
        public Guid OrderID { get; set; }
        public virtual Order Order { get; set; }
        public Guid ProductID { get; set; }

        public OrderProducts()
        {
            OrderProductID = Guid.NewGuid();
        }

    }
}
