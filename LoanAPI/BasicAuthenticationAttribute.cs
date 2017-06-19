using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;
using System.Text;
using DataAccessLayer;
using System.Threading;
using System.Security.Principal;

namespace LoanAPI
{
    public class BasicAuthenticationAttribute: AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            
            if(actionContext.Request.Headers.Authorization==null)
            {
               actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            else
            {
                //string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string[] usernamePasswordRoleArray = decodedAuthenticationToken.Split(':');
                string username = usernamePasswordRoleArray[0];
                string password = usernamePasswordRoleArray[1];
                string role = usernamePasswordRoleArray[2];

                if(LoginDAL.loginValidate(username,password,role))
                {
                    Thread.CurrentPrincipal =new GenericPrincipal(new GenericIdentity(username),null);
                   //actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                  
                }
            }
        }
    }
}