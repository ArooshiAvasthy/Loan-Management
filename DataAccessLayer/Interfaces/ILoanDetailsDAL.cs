using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.BusinessEntities;

namespace DataAccessLayer.Interfaces
{
    public interface ILoanDetailsDAL
    {
        List<runtimeTable> getAccountStatement(int id);
        void PayEmi(int id);
    }
}
