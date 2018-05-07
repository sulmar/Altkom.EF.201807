using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.Models
{
    public abstract class Item : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class Product : Item
    {        
        public string Color { get; set; }
    }

    public class Service : Item
    {
     
    }


}
