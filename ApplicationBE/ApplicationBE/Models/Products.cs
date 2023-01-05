using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationBE.Models
{
    public class Products
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Manufacturer { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }

        public DateTime ExpDate { get; set; }
        public String ImageUrl { get; set; }
        public int Status { get; set; }
        public string Type { get; set; }
    }
}
