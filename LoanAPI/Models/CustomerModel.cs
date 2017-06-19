using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanAPI.Models
{
    public class CustomerModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}