using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMVC.Models
{
    public class LoanApplicantType
    {

        public int ApplicantId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public string TypeOfLoan { get; set; }
        public string Duration { get; set; }
        public string StatusOfLoan { get; set; }
        public Nullable<double> Amount { get; set; }
    }
}