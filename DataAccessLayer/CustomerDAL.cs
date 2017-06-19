using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;
using System.Collections;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class CustomerDAL:ICustomerDAL
    {

        public void AddCustomer(Customer obj)
      {
          try
          {
              using (LoanManagementEntities1 db = new LoanManagementEntities1())
              {
                  var nameParam = new SqlParameter
                  {
                      ParameterName = "Name",
                      Value = obj.Name,
                  };
                  var addressParam = new SqlParameter
                  {
                      ParameterName = "Address",
                      Value = obj.Address,
                  };
                  var ageParam = new SqlParameter
                  {
                      ParameterName = "Age",
                      Value = obj.Age,
                  };
                  var userParam = new SqlParameter
                  {
                      ParameterName = "userName",
                      Value = obj.UserName,
                  };
                  var passwordParam = new SqlParameter
                  {
                      ParameterName = "Password",
                      Value = obj.Password,
                  };
                  var query = db.Customers.SqlQuery("EXEC AddToCustomers  @Name,@Address,@Age,@userName,@Password", nameParam, addressParam, ageParam, userParam, passwordParam).ToList<Customer>();

              }
          }

         catch (Exception ex)
          {
              throw ex;
          }
	    }
       
         public Customer GetCustomerInfo(string username)
        {
            try
            {
                using (LoanManagementEntities1 obj = new LoanManagementEntities1())
                {
                    var record = (from c in obj.Customers
                                  where c.UserName == username
                                  select c).FirstOrDefault();
                    return record;
                }
            }

             catch(Exception ex)
            {
                throw ex;
            }
            
        }

         public List<LoanApplicant> GetLoanStatus(string name)
        {
            try
            {
                using (LoanManagementEntities1 obj = new LoanManagementEntities1())
                {
                    var usernameParam = new SqlParameter
                    {
                        ParameterName = "username",
                        Value = name,
                    };

                    var records = obj.LoanApplicants.SqlQuery("EXEC ProvideLoanStatus  @username", usernameParam).ToList<LoanApplicant>();
                    return records;
                }
            }
             
           catch(Exception ex)
            {
                throw ex;
            }
        }

         public void applyLoan(LoanApplicant loanApplicant,string username)
         {
             try
             {
                 using (LoanManagementEntities1 db = new LoanManagementEntities1())
                 {

                     var nameParam = new SqlParameter
                     {
                         ParameterName = "Name",
                         Value = loanApplicant.Name,
                     };

                     var ageParam = new SqlParameter
                     {
                         ParameterName = "Age",
                         Value = loanApplicant.Age,
                     };
                     var salaryParam = new SqlParameter
                     {
                         ParameterName = "Salary",
                         Value = loanApplicant.Salary,
                     };
                     var TypeOfLoanParam = new SqlParameter
                     {
                         ParameterName = "TypeOfLoan",
                         Value = loanApplicant.TypeOfLoan,
                     };
                     var durationParam = new SqlParameter
                     {
                         ParameterName = "Duration",
                         Value = loanApplicant.Duration,
                     };
                     var amountParam = new SqlParameter
                     {
                         ParameterName = "Amount",
                         Value = loanApplicant.Amount,
                     };
                     var usernameParam = new SqlParameter
                     {
                         ParameterName = "username",
                         Value = username,
                     };
                     var query = db.LoanApplicants.SqlQuery("EXEC AddToLoanApplicants  @Name,@Age,@Salary,@TypeOfLoan,@Duration,@Amount,@username", nameParam, ageParam, salaryParam, TypeOfLoanParam, durationParam,amountParam ,usernameParam).ToList<LoanApplicant>();


                 }
             }

             catch (Exception ex) 
             {
                 throw ex;
             }

         }
       
    }
}
