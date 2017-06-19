using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICustomerDAL
    {
         void AddCustomer(Customer obj);
         Customer GetCustomerInfo(string username);
         List<LoanApplicant> GetLoanStatus(string name);
         void applyLoan(LoanApplicant loanApplicant, string username);
    }
}
