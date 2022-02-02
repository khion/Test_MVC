using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_MVC.Models
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<CheckBoxViewModel> SevicesLists { get; set; }
    }
}