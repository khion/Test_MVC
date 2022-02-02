using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_MVC.Models
{
    public class Employee : Person
    {
        public int EmployeeID { get; set; }
        public int ServiceID { get; set; }

        public virtual Service Service { get; set; }

    }
}