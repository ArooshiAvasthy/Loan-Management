using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessEntities
{
    public class runtimeTable
    {
       public int EmiId{get;set;}
       public double LoanAmountBeg{ get; set; }
       public double EMI { get; set; }
       public double InterestPaid { get; set; }
       public double PrincipalPaid { get; set; }
       public double LoanAmountEnd { get; set; }
       public DateTime DateofPayment { get; set; }
    }
}
