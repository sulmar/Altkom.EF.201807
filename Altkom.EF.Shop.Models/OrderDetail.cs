using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.Models
{
    public class OrderDetail : Base
    {
        public int Id { get; set; }

        public Item Item { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal Amount => Quantity * UnitPrice;
    }
}
