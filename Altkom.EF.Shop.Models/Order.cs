using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.Models
{
    public class Order : Base
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime DateOrder { get; set; }

        public decimal TotalAmount => Details.Sum(d => d.Amount);

        public IList<OrderDetail> Details { get; set; }


        public Order()
        {
            Details = new List<OrderDetail>();
        }

    }
}
