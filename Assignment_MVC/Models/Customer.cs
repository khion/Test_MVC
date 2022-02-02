using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_MVC.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<CustomerToService> CustomerToServices { get; set; }
    }
}