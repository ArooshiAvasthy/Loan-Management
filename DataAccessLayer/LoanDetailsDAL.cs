using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.BusinessEntities;
using System.Data;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class LoanDetailsDAL:ILoanDetailsDAL
    {
        SqlConnection con = new SqlConnection("Data Source=DLUAAVAST86878;Integrated Security=true;initial catalog=LoanManagement2");
        /// <summary>
        /// Fetch Account Statement of the customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<runtimeTable> getAccountStatement(int id)
        {
            try
            {
                using (LoanManagementEntities1 obj = new LoanManagementEntities1())
                {
                    string applicantIDString = id.ToString();
                    SqlCommand cmd = new SqlCommand("Select * from [" + applicantIDString + "]", con);

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    da.Fill(ds);
                    da.Fill(dt);
                    con.Close();
                    dt = ds.Tables[0];

                    List<runtimeTable> listObject = dt.AsEnumerable().Select(x => new runtimeTable()
                                      {
                                          EmiId = x.Field<int>("EmiId"),
                                          LoanAmountBeg = x.Field<double>("LoanAmountBeg"),
                                          EMI = x.Field<double>("EMI"),
                                          InterestPaid = x.Field<double>("InterestPaid"),
                                          PrincipalPaid=x.Field<double>("PrincipalPaid"),
                                          LoanAmountEnd = x.Field<double>("LoanAmountEnd"),
                                          DateofPayment = x.Field<DateTime>("DateofPayment"),
                                      }).ToList();

                    return listObject;
                }
            }
            catch (Exception ex)
            {
                //List<runtimeTable> obj = new List<runtimeTable>();
                //return obj;
                throw ex;
            }
        }

       //PayEMi
        public void PayEmi(int id)
        {
            try
            {

                using (LoanManagementEntities1 obj = new LoanManagementEntities1())
                {
                    var record = (from c in obj.SelectedApplicants
                                  where c.ApplicantId == id && c.LoanAmount>0
                                  select c).FirstOrDefault();
                   // double rateofinterest = 0;
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

                    
                    var interestParam = new SqlParameter
                   {
                       ParameterName = "interest",
                       Value = record.Interest,
                   };


                    var typeofLoanParam = new SqlParameter
                    {
                        ParameterName = "typeofLoan",
                        Value = record.TypeOfLoan,
                    };

               
                    var emiParam = new SqlParameter
                    {
                        ParameterName = "emi",
                        Value = record.EMI,
                    };


                    var query = obj.SelectedApplicants.SqlQuery("EXEC PayEMI2  @applicantID,@interest,@emi,@typeofLoan,@applicantIDString", applicantIDParam, interestParam, emiParam, typeofLoanParam, applicantIDStringParam).FirstOrDefault();

                }

            }

            catch (Exception ex)
            {
               // WriteException2LogFile(ex);
                throw ex;
            }


        }
    }
}
