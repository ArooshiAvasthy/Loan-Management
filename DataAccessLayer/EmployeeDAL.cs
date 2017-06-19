using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class EmployeeDAL:IEmployeeDAL
    {
        public List<LoanApplicant> GetAllApplicants()
        {
            try
            {

                using (LoanManagementEntities1 obj = new LoanManagementEntities1())
                {

                    var record = (from c in obj.LoanApplicants

                                  select c).ToList();
                    return record;


                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public LoanApplicant CheckApplicantsforLoan(int id)
        {
            try 
                    { 
           
                using (LoanManagementEntities1 obj = new LoanManagementEntities1())
                {
                    
                    var record = (from c in obj.LoanApplicants
                                  where c.Age > 30 &&
                                  c.Salary > 10000 &&
                                  c.ApplicantId == id
                                  select c).FirstOrDefault();
                    double rateofinterest = 0;
                    if (record != null)
                    {
                       //Calling SP that will insert the record into selected appplicants table n change status f loan
                        var applicantIDParam = new SqlParameter
                        {
                            ParameterName = "applicantID",
                            Value = id,
                        };
                        var applicantIDStringParam = new SqlParameter
                        {
                            ParameterName = "applicantIDString",
                            Value = id.ToString(),
                        };
                       
                        if(record.TypeOfLoan=="home")
                        {
                            rateofinterest = 10;
                        }
                        else if (record.TypeOfLoan == "Education")
                        {
                            rateofinterest = 8;
                        }
                        else if (record.TypeOfLoan == "Personal")
                        {
                            rateofinterest = 5;
                        }
                        var  typeofLoanParam = new SqlParameter
                        {
                            ParameterName = "typeofLoan",
                            Value = record.TypeOfLoan,
                        };
                        var interestParam = new SqlParameter
                        {
                            ParameterName = "interest",
                            Value = rateofinterest,
                        };
                      

                        double R=(rateofinterest/12)/100;
                        int N=Convert.ToInt32(record.Duration*12);
                        double A= Math.Pow((1+R),N);
                        double B = (A-1)  ;
                        double C = (A/B);
                        double Emi = Convert.ToDouble(record.Amount * R * C);

                        var emiParam = new SqlParameter
                        {
                            ParameterName = "emi",
                            Value = Emi,
                        };
                        var query = obj.LoanApplicants.SqlQuery("EXEC ApplicantProcessApproved  @applicantID,@interest,@emi,@typeofLoan,@applicantIDString", applicantIDParam, interestParam, emiParam, typeofLoanParam,applicantIDStringParam).FirstOrDefault();
                        return query;
                    }
                       
                    
                    else
                    {
                        //Calling SP that will change status f loan to rejected
                        var applicantIDParam = new SqlParameter
                        {
                            ParameterName = "applicantID",
                            Value = id,
                        };
                        
                        var query = obj.LoanApplicants.SqlQuery("EXEC ApplicantProcessRejected  @applicantID", applicantIDParam).FirstOrDefault();
                        return query;
                    }

                 }
            }
                catch (Exception ex)
                       {
                           throw ex;
                        }
          
        }

	  }
   }

