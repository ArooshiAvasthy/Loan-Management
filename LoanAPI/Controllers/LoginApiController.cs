using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using System.Web.Http.Cors;
using System.Threading;

namespace LoanAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class LoginApiController : ApiController
    {
        
        [HttpGet]
        [BasicAuthentication]
        [ActionName("GetUser")]
        public string GetUserByRole()
        {
            try
            {
                string username = Thread.CurrentPrincipal.Identity.Name;
                if (!string.IsNullOrEmpty(username))
                    return "true";
                else
                    return "false";
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
