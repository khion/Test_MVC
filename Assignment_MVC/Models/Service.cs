using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_MVC.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<CustomerToService> CustomerToServices { get; set; }
    }
}