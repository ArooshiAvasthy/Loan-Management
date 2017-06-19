using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanAPI.Models
{
    public class LoanApplicantModel
    {
        public int ApplicantId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public string TypeOfLoan { get; set; }
        public string StatusOfLoan { get; set; }
        public int Duration { get; set; }
        public string username { get; set; }
        
        public Nullable<double> Amount { get; set; }
    }
}