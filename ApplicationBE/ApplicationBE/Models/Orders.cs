using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationBE.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public String OrderNo { get; set; }

        public decimal OrderTotal { get; set; }
        public String OrderStatus { get; set; }
       
    }
}
