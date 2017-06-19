using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IEmployeeDAL
    {
         List<LoanApplicant> GetAllApplicants();
         LoanApplicant CheckApplicantsforLoan(int id);

    }
}
