using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_MVC.Models
{
    public class CustomerToService
    {
        public int CustomerToServiceID { get; set; }
        public int CustomerID { get; set; }
        public int ServiceID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Service Service { get; set; }

    }
}