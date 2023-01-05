using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationBE.Models
{
    public class Users
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public String Password { get; set; }
        public String Email{ get; set; }
        public decimal Fund { get; set; }
        public String Type { get; set; }
        public int Status { get; set; }

        public  String CreatedOn { get; set; }


    }
}
