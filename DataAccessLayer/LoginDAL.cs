using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class LoginDAL
    {
        public static bool loginValidate(string username,string password, string role)
        {
            LoanManagementEntities1 obj = new LoanManagementEntities1();
            try
            {

                
                    var record = (from c in obj.Customers
                                  where c.UserName == username &&
                                        c.Password == password &&
                                        c.Role == role
                                  select c).FirstOrDefault();
                    if (record != null)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
