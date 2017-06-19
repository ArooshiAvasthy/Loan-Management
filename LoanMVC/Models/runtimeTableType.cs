using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanMVC.Models
{
    public class runtimeTableType
    {
        public int EmiId { get; set; }
        public double LoanAmountBeg { get; set; }
        public double EMI { get; set; }
        public double InterestPaid { get; set; }
        public double PrincipalPaid { get; set; }
        public double LoanAmountEnd { get; set; }
        public DateTime DateofPayment { get; set; }
    }
}

